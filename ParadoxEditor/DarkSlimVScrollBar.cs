using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadoxEditor
{
    public class DarkSlimVScrollBar : VScrollBar
    {
        public DarkSlimVScrollBar()
        {
            this.Width = 10;

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), rect);

            Rectangle thumbRect = new Rectangle(1, this.Value * (this.Height - this.LargeChange) / (this.Maximum - this.Minimum), this.Width - 3, this.LargeChange * this.Height / (this.Maximum - this.Minimum));
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, 80, 80)), thumbRect);
        }
    }
}
