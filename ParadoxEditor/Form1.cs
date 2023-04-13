using Microsoft.EntityFrameworkCore;
using Reader;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ParadoxEditor
{
    public partial class ParadoxEditor : Form
    {
        public ParadoxEditor()
        {
            InitializeComponent();
            tabControl1.BackColor = Color.FromArgb(45, 45, 48);
            tabControl1.otherTabControl = TabControl2;
            tabControl1.ForeColor = Color.FromArgb(220, 220, 220);
            TabControl2.otherTabControl = tabControl1;
            treeView1.BackColor = Color.FromArgb(45, 45, 48);
            treeView1.ForeColor = Color.FromArgb(220, 220, 220);
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        // The method to handle the mouse down event

        private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainMenu_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void importDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (folderBrowserDialog1)
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                    PopulateTreeView(treeView1, folderBrowserDialog1.SelectedPath);
                }
            }

        }
        private void PopulateTreeView(TreeView treeView, string folderPath)
        {
            treeView.Nodes.Clear();

            TreeNode rootNode = new TreeNode(folderPath);
            treeView.Nodes.Add(rootNode);

            FillNode(rootNode, folderPath);
            rootNode.Expand();
        }

        private void FillNode(TreeNode node, string path)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);

                foreach (string dir in dirs)
                {
                        TreeNode newNode = new TreeNode(Path.GetFileName(dir), 0, 0);
                        node.Nodes.Add(newNode);
                        FillNode(newNode, dir);

                }

                foreach (string file in files)
                {
                        TreeNode fileNode = new TreeNode(Path.GetFileName(file), 1, 1);
                        node.Nodes.Add(fileNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabBounds = tabControl.GetTabRect(e.Index);
            Color backgroundColor = Color.FromArgb(45, 45, 48);
            Color foregroundColor = Color.FromArgb(220, 220, 220);

            using (Brush backgroundBrush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            using (Brush textBrush = new SolidBrush(foregroundColor))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(tabPage.Text, tabPage.Font, textBrush, tabBounds, sf);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;

                // Check if the node is a file
                if (e.Node.Nodes.Count == 0)
                {
                    ContextMenuStrip contextMenu = new ContextMenuStrip();
                    ToolStripMenuItem openInEditorMenuItem = new ToolStripMenuItem("Open in editor");
                    ToolStripMenuItem openInDesignerMenuItem = new ToolStripMenuItem("Open in designer");
                    contextMenu.Items.AddRange(new ToolStripItem[] { openInEditorMenuItem, openInDesignerMenuItem });

                    openInEditorMenuItem.Click += OpenInEditorMenuItem_Click;
                    openInDesignerMenuItem.Click += OpenInDesignerMenuItem_Click;

                    contextMenu.Show(treeView1, e.Location);
                }
            }
        }
        private void OpenInEditorMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            if (selectedNode != null)
            {
                string filePath = GetFullPath(selectedNode);

                TabPage tabPage = new TabPage(selectedNode.Text);
                TextEditorUserControl textEditor = new TextEditorUserControl();
                tabPage.Controls.Add(textEditor);
                textEditor.Dock = DockStyle.Fill;

                using (StreamReader sr = new StreamReader(filePath))
                {
                    textEditor.richTextBox1.Text = sr.ReadToEnd();
                }

                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage;
            }
        }

        private async void OpenInDesignerMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            if (selectedNode != null)
            {
                TabPage tabPage = new TabPage(selectedNode.Text);
                TextEditorUserControl textEditor = new TextEditorUserControl();
                tabPage.Controls.Add(textEditor);
                textEditor.Dock = DockStyle.Fill;
                Node rootNode =  await Reader.NodeLibrary.ParseInput(selectedNode.FullPath);
                if(rootNode!=null)
                {
                    textEditor.richTextBox1.Text = NodeLibrary.Print(rootNode);
                    tabControl1.TabPages.Add(tabPage);
                    tabControl1.SelectedTab = tabPage;
                }

            }
        }

        private string GetFullPath(TreeNode node)
        {
            string path = node.Text;
            while (node.Parent != null)
            {
                node = node.Parent;
                path = Path.Combine(node.Text, path);
            }
            return path;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}