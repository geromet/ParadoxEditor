using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadoxEditor.Controls
{
    public class DarkSlimVScrollBar : VScrollBar
    {
        public DarkSlimVScrollBar()
        {
            Width = 10;

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), rect);

            Rectangle thumbRect = new Rectangle(1, Value * (Height - LargeChange) / (Maximum - Minimum), Width - 3, LargeChange * Height / (Maximum - Minimum));
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, 80, 80)), thumbRect);
        }
    }
}
