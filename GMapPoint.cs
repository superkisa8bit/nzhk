using GMap.NET;
using System.Drawing;

namespace NZHK
{
    class GMapPoint : GMap.NET.WindowsForms.GMapMarker
    {
        private float size_ = 2;
        private Brush brush;
        public PointLatLng Point { get; set; }
        public GMapPoint(PointLatLng p, double q) : base(p)
        {
            Point = p;
            if (q > 18)
                brush = new SolidBrush(Color.FromArgb(80, 255, 0, 0));
            else if (q > 11)
                brush = new SolidBrush(Color.FromArgb(80, 255, 128, 0));
            else if (q > 6)
                brush = new SolidBrush(Color.FromArgb(80, 255, 255, 0));
            else if (q > 2)
                brush = new SolidBrush(Color.FromArgb(80, 21, 144, 100));
            else
                brush = new SolidBrush(Color.FromArgb(80, 0, 255, 0));
        }
        public override void OnRender(Graphics g)
        {
            g.FillRectangle(brush, LocalPosition.X, LocalPosition.Y, size_, size_);
        }
    }
}
