namespace NZHK
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.changeDataButton = new System.Windows.Forms.Button();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.coordLabel = new System.Windows.Forms.Label();
            this.coordTextBox = new System.Windows.Forms.TextBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.changeDataPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.successButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.latColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsListBox = new System.Windows.Forms.CheckedListBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.actionPanel.SuspendLayout();
            this.changeDataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.Dock = System.Windows.Forms.DockStyle.Left;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = true;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 18;
            this.map.MinZoom = 8;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(600, 600);
            this.map.TabIndex = 0;
            this.map.Zoom = 10D;
            this.map.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.map_OnMarkerClick);
            this.map.Load += new System.EventHandler(this.map_Load);
            this.map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.map_MouseClick);
            // 
            // actionPanel
            // 
            this.actionPanel.BackColor = System.Drawing.SystemColors.Control;
            this.actionPanel.Controls.Add(this.saveButton);
            this.actionPanel.Controls.Add(this.calculateButton);
            this.actionPanel.Controls.Add(this.pointsListBox);
            this.actionPanel.Controls.Add(this.changeDataButton);
            this.actionPanel.Controls.Add(this.infoTextBox);
            this.actionPanel.Controls.Add(this.coordLabel);
            this.actionPanel.Controls.Add(this.coordTextBox);
            this.actionPanel.Controls.Add(this.infoLabel);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.actionPanel.Location = new System.Drawing.Point(600, 0);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(200, 600);
            this.actionPanel.TabIndex = 1;
            // 
            // changeDataButton
            // 
            this.changeDataButton.Location = new System.Drawing.Point(6, 90);
            this.changeDataButton.Name = "changeDataButton";
            this.changeDataButton.Size = new System.Drawing.Size(182, 23);
            this.changeDataButton.TabIndex = 4;
            this.changeDataButton.Text = "Изменить данные";
            this.changeDataButton.UseVisualStyleBackColor = true;
            this.changeDataButton.Click += new System.EventHandler(this.changeDataButton_Click);
            // 
            // infoTextBox
            // 
            this.infoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoTextBox.Location = new System.Drawing.Point(9, 68);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.Size = new System.Drawing.Size(150, 16);
            this.infoTextBox.TabIndex = 3;
            this.infoTextBox.TabStop = false;
            this.infoTextBox.Tag = "Точка не выбрана";
            // 
            // coordLabel
            // 
            this.coordLabel.AutoSize = true;
            this.coordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coordLabel.Location = new System.Drawing.Point(6, 9);
            this.coordLabel.Name = "coordLabel";
            this.coordLabel.Size = new System.Drawing.Size(94, 17);
            this.coordLabel.TabIndex = 0;
            this.coordLabel.Text = "Координаты:";
            // 
            // coordTextBox
            // 
            this.coordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.coordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coordTextBox.Location = new System.Drawing.Point(9, 29);
            this.coordTextBox.Name = "coordTextBox";
            this.coordTextBox.ReadOnly = true;
            this.coordTextBox.Size = new System.Drawing.Size(150, 16);
            this.coordTextBox.TabIndex = 1;
            this.coordTextBox.TabStop = false;
            this.coordTextBox.Tag = "Точка не выбрана";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoLabel.Location = new System.Drawing.Point(6, 48);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(98, 17);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "Информация:";
            // 
            // changeDataPanel
            // 
            this.changeDataPanel.Controls.Add(this.cancelButton);
            this.changeDataPanel.Controls.Add(this.successButton);
            this.changeDataPanel.Controls.Add(this.dataGridView);
            this.changeDataPanel.Location = new System.Drawing.Point(0, 0);
            this.changeDataPanel.Name = "changeDataPanel";
            this.changeDataPanel.Size = new System.Drawing.Size(800, 600);
            this.changeDataPanel.TabIndex = 2;
            this.changeDataPanel.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(581, 565);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(126, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Отменить изменения";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // successButton
            // 
            this.successButton.Location = new System.Drawing.Point(713, 565);
            this.successButton.Name = "successButton";
            this.successButton.Size = new System.Drawing.Size(75, 23);
            this.successButton.TabIndex = 1;
            this.successButton.Text = "Готово";
            this.successButton.UseVisualStyleBackColor = true;
            this.successButton.Click += new System.EventHandler(this.successButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.latColumn,
            this.lonColumn,
            this.distanceColumn,
            this.infoColumn});
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(776, 547);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.TabStop = false;
            // 
            // latColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N6";
            dataGridViewCellStyle5.NullValue = "0";
            this.latColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.latColumn.HeaderText = "Широта";
            this.latColumn.Name = "latColumn";
            // 
            // lonColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N6";
            dataGridViewCellStyle6.NullValue = "0";
            this.lonColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.lonColumn.HeaderText = "Долгота";
            this.lonColumn.Name = "lonColumn";
            // 
            // distanceColumn
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.distanceColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.distanceColumn.HeaderText = "Дистанция до источника (м)";
            this.distanceColumn.Name = "distanceColumn";
            // 
            // infoColumn
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "N6";
            dataGridViewCellStyle8.NullValue = "0";
            this.infoColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.infoColumn.HeaderText = "Содержание урана";
            this.infoColumn.Name = "infoColumn";
            // 
            // pointsListBox
            // 
            this.pointsListBox.CheckOnClick = true;
            this.pointsListBox.FormattingEnabled = true;
            this.pointsListBox.Location = new System.Drawing.Point(6, 119);
            this.pointsListBox.Name = "pointsListBox";
            this.pointsListBox.Size = new System.Drawing.Size(182, 139);
            this.pointsListBox.TabIndex = 5;
            this.pointsListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.pointsListBox_ItemCheck);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(6, 264);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(182, 23);
            this.calculateButton.TabIndex = 6;
            this.calculateButton.Text = "Рассчитать";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(6, 293);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(182, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Экспорт";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.actionPanel);
            this.Controls.Add(this.changeDataPanel);
            this.Controls.Add(this.map);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 639);
            this.MinimumSize = new System.Drawing.Size(816, 639);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Карта";
            this.actionPanel.ResumeLayout(false);
            this.actionPanel.PerformLayout();
            this.changeDataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.TextBox coordTextBox;
        private System.Windows.Forms.Label coordLabel;
        private System.Windows.Forms.Button changeDataButton;
        private System.Windows.Forms.Panel changeDataPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button successButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn latColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn infoColumn;
        private System.Windows.Forms.CheckedListBox pointsListBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button saveButton;
    }
}

