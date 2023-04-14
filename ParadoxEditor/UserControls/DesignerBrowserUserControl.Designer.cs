using ParadoxEditor.Controls;

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
            listView1.BackColor = Color.FromArgb(53, 51, 50);
            listView1.BorderStyle = BorderStyle.None;
            listView1.Dock = DockStyle.Left;
            listView1.ForeColor = Color.FromArgb(181, 177, 175);
            listView1.Location = new Point(0, 0);
            listView1.Margin = new Padding(3, 2, 3, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(132, 396);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // darkTabControl1
            // 
            darkTabControl1.Dock = DockStyle.Fill;
            darkTabControl1.Location = new Point(132, 0);
            darkTabControl1.Margin = new Padding(3, 2, 3, 2);
            darkTabControl1.Name = "darkTabControl1";
            darkTabControl1.SelectedIndex = 0;
            darkTabControl1.Size = new Size(479, 396);
            darkTabControl1.TabIndex = 1;
            // 
            // DesignerBrowserUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(25, 25, 25);
            Controls.Add(darkTabControl1);
            Controls.Add(listView1);
            ForeColor = Color.FromArgb(130, 131, 131);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DesignerBrowserUserControl";
            Size = new Size(611, 396);
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private DarkTabControl darkTabControl1;
    }
}
