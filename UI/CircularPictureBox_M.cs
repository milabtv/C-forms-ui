using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace AikidoSystem.UI
{
    public class CircularPictureBox_M : PictureBox
    {
        private int borderSize = 2;
        private Color borderColor = Color.RoyalBlue;
        private Color borderColor2 = Color.HotPink;
        private DashStyle borderLineStyle = DashStyle.Solid;
        private DashCap borderCapStyle = DashCap.Flat;
        private float gradientAngle = 50F;

        public CircularPictureBox_M()
        {
            this.Size = new Size();
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        public Color BorderColor2
        {
            get => borderColor2;
            set
            {
                borderColor2 = value;
                this.Invalidate();
            }
        }
        public DashStyle BorderLineStyle
        {
            get => borderLineStyle;
            set
            {
                borderLineStyle = value;
                this.Invalidate();
            }
        }
        public DashCap BorderCapStyle
        {
            get => borderCapStyle;
            set
            {
                borderCapStyle = value;
                this.Invalidate();
            }
        }
        public float GradientAngle
        {
            get => gradientAngle;
            set
            {
                gradientAngle = value;
                this.Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(this.Width, this.Width);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var graph = pe.Graphics;
            var rectContourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var rectBorder = Rectangle.Inflate(rectContourSmooth, -borderSize, -borderSize);
            var smoothSize = borderSize > 0 ? borderSize * 3 : 1;
            using (var borderGColor = new LinearGradientBrush(rectBorder, borderColor, borderColor2, gradientAngle))
            using (var pathRegion = new GraphicsPath())
            using (var penSmooth = new Pen(this.Parent.BackColor, smoothSize))
            using (var penBorder = new Pen(borderGColor, BorderSize))
            {
                penBorder.DashStyle = borderLineStyle;
                penBorder.DashCap = BorderCapStyle;
                pathRegion.AddEllipse(rectContourSmooth);
                this.Region = new Region(pathRegion);
                graph.SmoothingMode = SmoothingMode.AntiAlias;

                graph.DrawEllipse(penSmooth, rectContourSmooth);
                if (BorderSize > 0)
                    graph.DrawEllipse(penBorder, rectBorder);

            }
        }
    }
}
