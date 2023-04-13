namespace ParadoxEditor
{
    partial class ParadoxEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importFileToolStripMenuItem = new ToolStripMenuItem();
            importDirectoryToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            projectToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            resizeToolStripMenuItem = new ToolStripMenuItem();
            minimizeToolStripMenuItem = new ToolStripMenuItem();
            treeView1 = new TreeView();
            folderBrowserDialog1 = new FolderBrowserDialog();
            splitContainer1 = new SplitContainer();
            tabControl1 = new DarkTabControl();
            tabControl2 = new DarkTabControl();
            MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            //
            // MainMenu
            //
            MainMenu.BackColor = Color.FromArgb(46, 44, 44);
            MainMenu.ImageScalingSize = new Size(20, 20);
            MainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem, projectToolStripMenuItem, exitToolStripMenuItem, resizeToolStripMenuItem, minimizeToolStripMenuItem });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Padding = new Padding(7, 3, 0, 3);
            MainMenu.Size = new Size(914, 30);
            MainMenu.TabIndex = 2;
            MainMenu.MouseDown += MainMenu_MouseDown_1;
            //
            // fileToolStripMenuItem
            //
            fileToolStripMenuItem.BackColor = Color.FromArgb(46, 44, 44);
            fileToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importFileToolStripMenuItem, importDirectoryToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            //
            // importFileToolStripMenuItem
            //
            importFileToolStripMenuItem.BackColor = Color.FromArgb(54, 52, 52);
            importFileToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            importFileToolStripMenuItem.ForeColor = Color.FromArgb(113, 111, 111);
            importFileToolStripMenuItem.Name = "importFileToolStripMenuItem";
            importFileToolStripMenuItem.Size = new Size(202, 26);
            importFileToolStripMenuItem.Text = "Import File";
            //
            // importDirectoryToolStripMenuItem
            //
            importDirectoryToolStripMenuItem.BackColor = Color.FromArgb(54, 52, 52);
            importDirectoryToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            importDirectoryToolStripMenuItem.ForeColor = Color.FromArgb(113, 111, 111);
            importDirectoryToolStripMenuItem.Name = "importDirectoryToolStripMenuItem";
            importDirectoryToolStripMenuItem.Size = new Size(202, 26);
            importDirectoryToolStripMenuItem.Text = "Import Directory";
            importDirectoryToolStripMenuItem.Click += importDirectoryToolStripMenuItem_Click;
            //
            // editToolStripMenuItem
            //
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "Edit";
            //
            // viewToolStripMenuItem
            //
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(55, 24);
            viewToolStripMenuItem.Text = "View";
            //
            // projectToolStripMenuItem
            //
            projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            projectToolStripMenuItem.Size = new Size(69, 24);
            projectToolStripMenuItem.Text = "Project";
            //
            // exitToolStripMenuItem
            //
            exitToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(47, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            //
            // resizeToolStripMenuItem
            //
            resizeToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            resizeToolStripMenuItem.Size = new Size(65, 24);
            resizeToolStripMenuItem.Text = "Resize";
            resizeToolStripMenuItem.Click += resizeToolStripMenuItem_Click;
            //
            // minimizeToolStripMenuItem
            //
            minimizeToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            minimizeToolStripMenuItem.Size = new Size(84, 24);
            minimizeToolStripMenuItem.Text = "Minimize";
            minimizeToolStripMenuItem.Click += minimizeToolStripMenuItem_Click;
            //
            // treeView1
            //
            treeView1.AllowDrop = true;
            treeView1.BackColor = Color.FromArgb(38, 36, 36);
            treeView1.BorderStyle = BorderStyle.None;
            treeView1.Dock = DockStyle.Left;
            treeView1.ForeColor = Color.FromArgb(101, 99, 99);
            treeView1.Location = new Point(0, 30);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(250, 570);
            treeView1.TabIndex = 3;
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            //
            // splitContainer1
            //
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(250, 30);
            splitContainer1.Name = "splitContainer1";
            //
            // splitContainer1.Panel1
            //
            splitContainer1.Panel1.Controls.Add(tabControl1);
            //
            // splitContainer1.Panel2
            //
            splitContainer1.Panel2.Controls.Add(tabControl2);
            splitContainer1.Size = new Size(664, 570);
            splitContainer1.SplitterDistance = 331;
            splitContainer1.TabIndex = 5;
            //
            // tabControl1
            //
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(331, 570);
            tabControl1.TabIndex = 5;
            //
            // tabControl2
            //
            tabControl2.Appearance = TabAppearance.FlatButtons;
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl2.Location = new Point(0, 0);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(329, 570);
            tabControl2.TabIndex = 5;
            //
            // ParadoxEditor
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 32, 32);
            ClientSize = new Size(914, 600);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Controls.Add(treeView1);
            Controls.Add(MainMenu);
            ForeColor = Color.FromArgb(101, 99, 99);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MinimizeBox = false;
            Name = "ParadoxEditor";
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem projectToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem resizeToolStripMenuItem;
        private ToolStripMenuItem minimizeToolStripMenuItem;
        private TreeView treeView1;
        private ToolStripMenuItem importFileToolStripMenuItem;
        private ToolStripMenuItem importDirectoryToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialog1;
        private SplitContainer splitContainer1;
        private DarkTabControl tabControl1;
        private DarkTabControl tabControl2;
    }
}