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
{public class RadioButton_M :RadioButton
    {
        private Color checkedColor = Color.MediumSlateBlue;
        private Color uncheckedColor = Color.Gray;

        public Color CheckedColor { get => checkedColor; set { checkedColor = value; this.Invalidate(); } }
        public Color UncheckedColor { get => uncheckedColor; set { uncheckedColor = value; this.Invalidate(); } }

        public RadioButton_M()
        {
            this.MinimumSize = new Size(0, 21);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float rbBorderSize = 18F;
            float rbCheckSize = 12F;
            RectangleF rectRbBorder = new RectangleF()
            {
                X = 0.5F,
                Y=(this.Height-rbBorderSize)/2,
                Width=rbBorderSize,
                Height=rbBorderSize
            };
            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width-rbCheckSize)/2),
                Y=(this.Height - rbCheckSize)/2,
                Width=rbCheckSize,
                Height=rbCheckSize
            };

            using (Pen penBorder = new Pen(checkedColor, 1.6F))
            using (SolidBrush brushRbCheck = new SolidBrush(checkedColor))
            using (SolidBrush brushText = new SolidBrush(this.ForeColor))
            {
                graphics.Clear(this.BackColor);
                if (this.Checked)
                {
                    graphics.DrawEllipse(penBorder, rectRbBorder);
                    graphics.FillEllipse(brushRbCheck, rectRbCheck);
                }
                else 
                {
                    penBorder.Color = uncheckedColor;
                    graphics.DrawEllipse(penBorder,rectRbCheck);
                }
                graphics.DrawString(this.Text,this.Font,brushText,rbBorderSize+8,(this.Height-TextRenderer.MeasureText(this.Text,this.Font).Height)/2);

            }
            
                
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = TextRenderer.MeasureText(this.Text,this.Font).Width+30;
        }
    }
}
