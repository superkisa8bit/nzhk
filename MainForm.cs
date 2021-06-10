using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace NZHK
{
    public partial class MainForm : Form
    {
        private static double x0 = 55.097646;
        private static double y0 = 82.993348;

        private static GMapOverlay pointsOverlay = new GMapOverlay();
        private static GMapOverlay resultOverlay = new GMapOverlay();

        private static string json = File.ReadAllText("Points.json");
        private List<Point> points = JsonConvert.DeserializeObject<List<Point>>(json);
        private DataTable dataPoints = new DataTable();
        private List<Point> checkedPoints = new List<Point>();
        public MainForm()
        {
            InitializeComponent();

            GMaps.Instance.Mode = AccessMode.ServerOnly;

            map.MapProvider = GMapProviders.GoogleMap;
            map.Position = new PointLatLng(x0, y0);
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;

            coordTextBox.Text = (string)coordTextBox.Tag;
            infoTextBox.Text = (string)infoTextBox.Tag;

            dataPoints.Columns.Add("Широта");
            dataPoints.Columns.Add("Долгота");
            dataPoints.Columns.Add("Дистанция до источника (м)");
            dataPoints.Columns.Add("Содержание урана");

            changeDataPanel.Left = 0;
            changeDataPanel.Top = 0;

            for (int i = 1; i < points.Count - 1; i++)
                pointsListBox.Items.Add(i);
        }

        private void map_Load(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (Point point in points)
            {
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(point.X, point.Y), GMarkerGoogleType.gray_small);
                marker.Tag = point;
                marker.ToolTipText = counter.ToString();
                counter++;
                pointsOverlay.Markers.Add(marker);
            }
            map.Overlays.Add(pointsOverlay);
        }

        private void map_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            Point point = (Point)item.Tag;
            coordTextBox.Text = point.X.ToString() + ", " + point.Y.ToString();
            if (Double.TryParse(point.Info.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double temp))
                infoTextBox.Text = "Уран: " + point.Info.ToString();
            else
                infoTextBox.Text = point.Info.ToString();
        }

        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            coordTextBox.Text = (string)coordTextBox.Tag;
            infoTextBox.Text = (string)infoTextBox.Tag;
        }

        private void successButton_Click(object sender, EventArgs e)
        {
            dataPoints.Rows.Clear();

            List<Point> newPoints = new List<Point>();
            DataTable newDataPoints = new DataTable();
            newDataPoints.Columns.Add("Широта");
            newDataPoints.Columns.Add("Долгота");
            newDataPoints.Columns.Add("Дистанция до источника (м)");
            newDataPoints.Columns.Add("Содержание урана");

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                Point temp = new Point();
                temp.X = Convert.ToDouble(dataGridView.Rows[i].Cells[0].Value);
                temp.Y = Convert.ToDouble(dataGridView.Rows[i].Cells[1].Value);
                temp.Distance = Convert.ToDouble(dataGridView.Rows[i].Cells[2].Value);
                temp.Info = dataGridView.Rows[i].Cells[3].Value;
                newPoints.Add(temp);

                newDataPoints.Rows.Add(dataGridView.Rows[i].Cells[0].Value, dataGridView.Rows[i].Cells[1].Value,
                    dataGridView.Rows[i].Cells[2].Value, dataGridView.Rows[i].Cells[3].Value);
            }

            Console.WriteLine(points);

            points = newPoints;
            dataPoints = newDataPoints;

            json = JsonConvert.SerializeObject(points);
            File.WriteAllText("Points.json", json);

            map.Overlays.Clear();
            foreach (Point point in points)
            {
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(point.X, point.Y), GMarkerGoogleType.gray_small);
                marker.Tag = point;
                pointsOverlay.Markers.Add(marker);
            }
            map.Overlays.Add(pointsOverlay);

            changeDataPanel.Visible = false;
            actionPanel.Visible = true;
        }

        private void changeDataButton_Click(object sender, EventArgs e)
        {
            coordTextBox.Text = (string)coordTextBox.Tag;
            infoTextBox.Text = (string)infoTextBox.Tag;

            dataGridView.Rows.Clear();

            foreach (Point point in points)
            {
                dataGridView.Rows.Add(point.X, point.Y, point.Distance, point.Info);
                dataPoints.Rows.Add(point.X, point.Y, point.Distance, point.Info);
            }

            changeDataPanel.Visible = true;
            actionPanel.Visible = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            dataGridView.Enabled = false;
            dataGridView.Rows.Clear();
            foreach (Point point in points)
            {
                dataGridView.Rows.Add(point.X, point.Y, point.Distance, point.Info);
            }
            dataGridView.Enabled = true;
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (pointsListBox.CheckedItems.Count < 2)
            {
                MessageBox.Show("Выберите не менее двух точек");
                return;
            }

            double[] qt = new double[checkedPoints.Count];
            double[] windt = new double[checkedPoints.Count];
            double[] rt = new double[checkedPoints.Count];
            int counter = 0;
            foreach (Point point in checkedPoints)
            {
                double x = point.X;
                double y = point.Y;
                double info = Convert.ToDouble(point.Info);
                qt[counter] = info;
                windt[counter] = Wind(x, y);
                double angle = Math.Sin(x0 * Math.PI / 180) * Math.Sin(x * Math.PI / 180) 
                    + Math.Cos(x0 * Math.PI / 180) * Math.Cos(x * Math.PI / 180) * Math.Cos(y0 * Math.PI / 180 - y * Math.PI / 180);
                rt[counter] = Math.Acos(angle) * 6371;
                counter++;
            }

            double s1 = 0, s2 = 0, temp1, temp2;
            double rm = 3.5;
            double[] tempQt = new double[checkedPoints.Count];
            double mnk = Double.MaxValue, mnk1 = 0;
            for (temp1 = 1; temp1 <= 10000; temp1 += 1)
                for (temp2 = -2; temp2 < 2; temp2 += 0.01)
                {
                    for (int i = 0; i < checkedPoints.Count; i++)
                    {
                        tempQt[i] = windt[i] * temp1 * Math.Pow(rt[i], temp2) * Math.Exp(-2 * rm / rt[i]);
                        mnk1 += Math.Pow(tempQt[i] - qt[i], 2);
                    }
                    if (mnk1 < mnk)
                    {
                        mnk = mnk1;
                        s1 = temp1;
                        s2 = temp2;
                    }
                    mnk1 = 0;
                }
            resultOverlay.Clear();
            resultOverlay.Markers.Clear();
            for (double i = x0 - 0.11; i < x0 + 0.11; i += 0.001)
            {
                for (double j = y0 - 0.2; j < y0 + 0.2; j += 0.001)
                {
                    Qpole(i, j, s1, s2);
                }
            }
            if (map.Overlays.Contains(resultOverlay))
            {
                map.Overlays.Clear();

            }
            map.Overlays.Add(resultOverlay);

            counter = 0;
            foreach (Point point in points)
            {
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(point.X, point.Y), GMarkerGoogleType.gray_small);
                marker.Tag = point;
                marker.ToolTipText = counter.ToString();
                counter++;
                pointsOverlay.Markers.Add(marker);
            }
            map.Overlays.Add(pointsOverlay);
        }

        private void pointsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedPoints.Clear();
            if (e.NewValue == CheckState.Checked)
                checkedPoints.Add(points[(int)pointsListBox.Items[e.Index]]);
            else
                checkedPoints.Remove(points[(int)pointsListBox.Items[e.Index]]);
        }

        private static double Wind(double x, double y)
        {
            double ugol = 180 / Math.PI * Math.Atan((x - x0) / (y - y0));
            double[] roza = { 10.4, 37.1, 10.8, 7.8, 12.4, 4.7, 0.9, 3.1 };
            double wind;

            if (y - y0 <= 0)
                ugol += 180;
            if (ugol < 0)
                ugol += 360;
            if (ugol >= 0 & ugol <= 45)
                wind = roza[0] + (roza[1] - roza[0]) * (ugol) / 45;
            else if (ugol >= 45 & ugol <= 90)
                wind = roza[1] + (roza[2] - roza[1]) * (ugol - 45) / 45;
            else if (ugol >= 90 & ugol < 135)
                wind = roza[2] + (roza[3] - roza[2]) * (ugol - 90) / 45;
            else if (ugol >= 135 & ugol <= 180)
                wind = roza[3] + (roza[4] - roza[3]) * (ugol - 135) / 45;
            else if (ugol >= 180 & ugol <= 225)
                wind = roza[4] + (roza[5] - roza[4]) * (ugol - 180) / 45;
            else if (ugol >= 225 & ugol <= 270)
                wind = roza[5] + (roza[6] - roza[5]) * (ugol - 225) / 45;
            else if (ugol >= 270 & ugol <= 315)
                wind = roza[6] + (roza[7] - roza[6]) * (ugol - 270) / 45;
            else
                wind = roza[7] + (roza[0] - roza[7]) * (ugol - 315) / 45;
            
            return wind;
        }

        private static void Qpole(double x, double y, double s1, double s2)
        {
            double windt = Wind(x, y);
            double angle = Math.Sin(x0 * Math.PI / 180) * Math.Sin(x * Math.PI / 180) 
                + Math.Cos(x0 * Math.PI / 180) * Math.Cos(x * Math.PI / 180) * Math.Cos(y0 * Math.PI / 180 - y * Math.PI / 180);
            double rt = Math.Acos(angle) * 6371;
            double qt = windt * s1 * Math.Pow(rt, s2) * Math.Exp(-2 * 1.5 / rt);
            GMapPoint point = new GMapPoint(new PointLatLng(x, y), qt);
            resultOverlay.Markers.Add(point);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "PNG (*.png)|*.png";
                dialog.FileName = "GMap.NET image";
                Image image = map.ToImage();
                if (image != null)
                {
                    using (image)
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = dialog.FileName;

                            if (!fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                                fileName += ".png";
                            image.Save(fileName);

                            MessageBox.Show("Карта успешно сохранена в директории： " + Environment.NewLine + dialog.FileName, 
                                "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
        }
    }
}

