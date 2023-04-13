﻿using System.Windows.Forms;
using System.Drawing;
using ParadoxEditor;

namespace ParadoxEditor
{
    public class DarkTreeView : TreeView
    {
        private DarkSlimVScrollBar darkSlimVScrollBar;

        public DarkTreeView()
        {
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.DrawNode += DarkTreeView_DrawNode;
            this.Scrollable = true;

            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.FromArgb(240, 240, 240);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            darkSlimVScrollBar = new DarkSlimVScrollBar();
            darkSlimVScrollBar.Scroll += DarkSlimVScrollBar_Scroll;
            this.Controls.Add(darkSlimVScrollBar);
            this.Resize += DarkTreeView_Resize;
        }

        private void DarkTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
            e.Node.BackColor = this.BackColor;
            e.Node.ForeColor = this.ForeColor;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x000F) // WM_PAINT
            {
                if (darkSlimVScrollBar.Visible != this.IsVerticalScrollBarVisible())
                {
                    darkSlimVScrollBar.Visible = this.IsVerticalScrollBarVisible();
                }
            }
        }

        private void DarkTreeView_Resize(object sender, EventArgs e)
        {
            if (darkSlimVScrollBar.Visible)
            {
                darkSlimVScrollBar.Location = new Point(this.Width - darkSlimVScrollBar.Width, 0);
                darkSlimVScrollBar.Size = new Size(darkSlimVScrollBar.Width, this.Height);
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

                SendMessage(this.Handle, 0x0115, (IntPtr)(delta << 16), IntPtr.Zero);
            }
        }

        private bool IsVerticalScrollBarVisible()
        {
            int style = (int)GetWindowLong(this.Handle, -16);
            return (style & 0x00200000) != 0;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    }
}
