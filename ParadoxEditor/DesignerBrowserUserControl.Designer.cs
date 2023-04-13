namespace ParadoxEditor
{
    partial class DesignerBrowserUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            darkTabControl1 = new DarkTabControl();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(42, 34, 34);
            listView1.BorderStyle = BorderStyle.None;
            listView1.Dock = DockStyle.Left;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(151, 528);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // darkTabControl1
            // 
            darkTabControl1.Dock = DockStyle.Fill;
            darkTabControl1.Location = new Point(151, 0);
            darkTabControl1.Name = "darkTabControl1";
            darkTabControl1.SelectedIndex = 0;
            darkTabControl1.Size = new Size(547, 528);
            darkTabControl1.TabIndex = 1;
            // 
            // DesignerBrowserUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(darkTabControl1);
            Controls.Add(listView1);
            Name = "DesignerBrowserUserControl";
            Size = new Size(698, 528);
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private DarkTabControl darkTabControl1;
    }
}
