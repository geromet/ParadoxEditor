using System.Windows.Forms;
using System.Drawing;

namespace ParadoxEditor.Controls
{
    public class DarkTreeView : TreeView
    {
        private DarkSlimVScrollBar darkSlimVScrollBar;

        public DarkTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawText;
            DrawNode += DarkTreeView_DrawNode;
            Scrollable = true;

            BackColor = Color.FromArgb(53, 51, 50);
            ForeColor = Color.FromArgb(181, 177, 175);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            darkSlimVScrollBar = new DarkSlimVScrollBar();
            darkSlimVScrollBar.Scroll += DarkSlimVScrollBar_Scroll;
            Controls.Add(darkSlimVScrollBar);
            Resize += DarkTreeView_Resize;
        }

        private void DarkTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
            e.Node.BackColor = BackColor;
            e.Node.ForeColor = ForeColor;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x000F) // WM_PAINT
            {
                if (darkSlimVScrollBar.Visible != IsVerticalScrollBarVisible())
                {
                    darkSlimVScrollBar.Visible = IsVerticalScrollBarVisible();
                }
            }
        }

        private void DarkTreeView_Resize(object sender, EventArgs e)
        {
            if (darkSlimVScrollBar.Visible)
            {
                darkSlimVScrollBar.Location = new Point(Width - darkSlimVScrollBar.Width, 0);
                darkSlimVScrollBar.Size = new Size(darkSlimVScrollBar.Width, Height);
                darkSlimVScrollBar.BringToFront();
            }
        }

        private void DarkSlimVScrollBar_Scroll(object sender, ScrollEventArgs se)
        {
            if (se.Type == ScrollEventType.ThumbTrack || se.Type == ScrollEventType.SmallIncrement || se.Type == ScrollEventType.SmallDecrement)
            {
                int oldPosition = se.OldValue;
                int newPosition = se.NewValue;
                int delta = newPosition - oldPosition;

                SendMessage(Handle, 0x0115, delta << 16, IntPtr.Zero);
            }
        }

        private bool IsVerticalScrollBarVisible()
        {
            int style = (int)GetWindowLong(Handle, -16);
            return (style & 0x00200000) != 0;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    }
}

