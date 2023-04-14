using ParadoxEditor.Controls;

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
            importDirectoryToolStripMenuItem = new ToolStripMenuItem();
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
            MainMenu.BackColor = Color.FromArgb(25, 25, 25);
            MainMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            MainMenu.ImageScalingSize = new Size(20, 20);
            MainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, exitToolStripMenuItem, resizeToolStripMenuItem, minimizeToolStripMenuItem });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(800, 25);
            MainMenu.TabIndex = 2;
            MainMenu.MouseDown += MainMenu_MouseDown_1;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.BackColor = Color.FromArgb(25, 25, 25);
            fileToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importDirectoryToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(39, 21);
            fileToolStripMenuItem.Text = "File";
            fileToolStripMenuItem.Click += fileToolStripMenuItem_Click;
            // 
            // importDirectoryToolStripMenuItem
            // 
            importDirectoryToolStripMenuItem.BackColor = Color.FromArgb(54, 52, 52);
            importDirectoryToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            importDirectoryToolStripMenuItem.ForeColor = Color.FromArgb(113, 111, 111);
            importDirectoryToolStripMenuItem.Name = "importDirectoryToolStripMenuItem";
            importDirectoryToolStripMenuItem.Size = new Size(180, 22);
            importDirectoryToolStripMenuItem.Text = "Import Directory";
            importDirectoryToolStripMenuItem.Click += importDirectoryToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(40, 21);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // resizeToolStripMenuItem
            // 
            resizeToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            resizeToolStripMenuItem.Size = new Size(57, 21);
            resizeToolStripMenuItem.Text = "Resize";
            resizeToolStripMenuItem.Click += resizeToolStripMenuItem_Click;
            // 
            // minimizeToolStripMenuItem
            // 
            minimizeToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            minimizeToolStripMenuItem.Size = new Size(72, 21);
            minimizeToolStripMenuItem.Text = "Minimize";
            minimizeToolStripMenuItem.Click += minimizeToolStripMenuItem_Click;
            // 
            // treeView1
            // 
            treeView1.AllowDrop = true;
            treeView1.BackColor = Color.FromArgb(53, 51, 50);
            treeView1.BorderStyle = BorderStyle.None;
            treeView1.Dock = DockStyle.Left;
            treeView1.ForeColor = Color.FromArgb(181, 177, 175);
            treeView1.Location = new Point(0, 25);
            treeView1.Margin = new Padding(3, 2, 3, 2);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(219, 425);
            treeView1.TabIndex = 3;
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(219, 25);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl2);
            splitContainer1.Size = new Size(581, 425);
            splitContainer1.SplitterDistance = 289;
            splitContainer1.TabIndex = 5;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(289, 425);
            tabControl1.TabIndex = 5;
            // 
            // tabControl2
            // 
            tabControl2.Appearance = TabAppearance.FlatButtons;
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl2.Location = new Point(0, 0);
            tabControl2.Margin = new Padding(3, 2, 3, 2);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(288, 425);
            tabControl2.TabIndex = 5;
            tabControl2.SelectedIndexChanged += tabControl2_SelectedIndexChanged;
            // 
            // ParadoxEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Controls.Add(treeView1);
            Controls.Add(MainMenu);
            ForeColor = Color.FromArgb(130, 131, 131);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ParadoxEditor";
            StartPosition = FormStartPosition.CenterScreen;
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
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem resizeToolStripMenuItem;
        private ToolStripMenuItem minimizeToolStripMenuItem;
        private TreeView treeView1;
        private ToolStripMenuItem importDirectoryToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialog1;
        private SplitContainer splitContainer1;
        private DarkTabControl tabControl1;
        private DarkTabControl tabControl2;
    }
}