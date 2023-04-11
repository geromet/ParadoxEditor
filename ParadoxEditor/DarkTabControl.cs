using System.Drawing;
using System.Windows.Forms;

namespace ParadoxEditor
{
    public class DarkTabControl : TabControl
    {
        private Color backgroundColor = Color.FromArgb(45, 45, 48);
        private Color foregroundColor = Color.FromArgb(220, 220, 220);
        private const int closeButtonSize = 12;
        private const int closeButtonMargin = 4;
        private List<TabPage> closedPages = new List<TabPage>();
        public DarkTabControl otherTabControl;

        public DarkTabControl()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.DoubleBuffered = true;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x000F) // WM_PAINT
            {
                using (Graphics g = this.CreateGraphics())
                {
                    // Draw the content area background
                    using (Brush backgroundBrush = new SolidBrush(backgroundColor))
                    {
                        g.FillRectangle(backgroundBrush, 0, 0, Width, Height);
                    }

                    // Draw the tab headers
                    for (int i = 0; i < this.TabCount; i++)
                    {
                        Rectangle tabBounds = this.GetTabRect(i);
                        TabPage tabPage = this.TabPages[i];

                        // Draw the tab header background
                        using (Brush backgroundBrush = new SolidBrush(backgroundColor))
                        {
                            g.FillRectangle(backgroundBrush, tabBounds);
                        }

                        // Draw the tab header text
                        using (Brush textBrush = new SolidBrush(foregroundColor))
                        {
                            StringFormat sf = new StringFormat
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center
                            };
                            g.DrawString(tabPage.Text, tabPage.Font, textBrush, tabBounds, sf);
                        }
                    }
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            for (int i = 0; i < this.TabCount; i++)
            {
                Rectangle tabBounds = this.GetTabRect(i);

                // Draw close button
                Rectangle closeButtonRect = new Rectangle(tabBounds.Right - closeButtonSize - closeButtonMargin, tabBounds.Top + closeButtonMargin, closeButtonSize, closeButtonSize);
                ControlPaint.DrawCaptionButton(e.Graphics, closeButtonRect, CaptionButton.Close, ButtonState.Normal);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            for (int i = 0; i < this.TabCount; i++)
            {
                Rectangle tabBounds = this.GetTabRect(i);
                Rectangle closeButtonRect = new Rectangle(tabBounds.Right - closeButtonSize - closeButtonMargin, tabBounds.Top + closeButtonMargin, closeButtonSize, closeButtonSize);

                if (closeButtonRect.Contains(e.Location))
                {
                    closedPages.Add(this.TabPages[i]);
                    this.TabPages.RemoveAt(i);
                    break;
                }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < this.TabCount; i++)
                {
                    Rectangle tabBounds = this.GetTabRect(i);

                    if (tabBounds.Contains(e.Location))
                    {
                        this.SelectedIndex = i;

                        ContextMenuStrip contextMenu = new ContextMenuStrip();
                        ToolStripMenuItem closeTabMenuItem = new ToolStripMenuItem("Close");
                        ToolStripMenuItem closeAllButThisMenuItem = new ToolStripMenuItem("Close all but this");
                        ToolStripMenuItem closeAllOtherTabsMenuItem = new ToolStripMenuItem("Close all tabs");
                        ToolStripMenuItem restoreClosedTabMenuItem = new ToolStripMenuItem("Restore closed tab");
                        ToolStripMenuItem pinTabMenuItem = new ToolStripMenuItem("Pin tab");
                        ToolStripMenuItem moveToOtherViewItem = new ToolStripMenuItem("Move to other view");

                        contextMenu.Items.AddRange(new ToolStripItem[] { closeTabMenuItem, closeAllButThisMenuItem, closeAllOtherTabsMenuItem, restoreClosedTabMenuItem, pinTabMenuItem, moveToOtherViewItem });

                        closeTabMenuItem.Click += (sender, args) => { closedPages.Add(this.SelectedTab); this.TabPages.Remove(this.SelectedTab); };
                        closeAllButThisMenuItem.Click += (sender, args) => { CloseAllTabsExcept(this.SelectedTab); };
                        closeAllOtherTabsMenuItem.Click += (sender, args) => { CloseAllTabs(); };
                        restoreClosedTabMenuItem.Click += (sender, args) => { RestoreLastClosedTab(); };
                        moveToOtherViewItem.Click += (sender, args) => { MoveToOtherView(); };

                        // Implement pin tab functionality based on your specific requirements

                        contextMenu.Show(this, e.Location);
                        break;
                    }
                }
            }
        }
        private void CloseAllTabsExcept(TabPage tabPageToKeep)
        {
            foreach (TabPage tabPage in this.TabPages)
            {
                if (tabPage != tabPageToKeep)
                {
                    closedPages.Add(tabPage);
                }
            }

            this.TabPages.Clear();
            this.TabPages.Add(tabPageToKeep);
        }
        private void CloseAllTabs()
        {
            foreach (TabPage tabPage in this.TabPages)
            {
                closedPages.Add(tabPage);
            }
            this.TabPages.Clear();
        }

        private void RestoreLastClosedTab()
        {
            if (closedPages.Count > 0)
            {
                TabPage lastClosedTab = closedPages[closedPages.Count - 1];
                this.TabPages.Add(lastClosedTab);
                this.SelectedTab = lastClosedTab;
                closedPages.RemoveAt(closedPages.Count - 1);
            }
        }
        private void MoveToOtherView()
        {
            if (otherTabControl != null)
            {
                TabPage selectedTab = this.SelectedTab;
                this.TabPages.Remove(selectedTab);
                otherTabControl.TabPages.Add(selectedTab);
                otherTabControl.SelectedTab = selectedTab;
            }
        }

    }
}
