namespace ParadoxEditor.Forms
{
    partial class FindAndReplace
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            Find = new Label();
            Replace = new Label();
            FindBox = new TextBox();
            ReplaceBox = new TextBox();
            FindButton = new Button();
            ReplaceButton = new Button();
            ReplaceAllButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(Find, 0, 0);
            tableLayoutPanel1.Controls.Add(Replace, 0, 1);
            tableLayoutPanel1.Controls.Add(FindBox, 1, 0);
            tableLayoutPanel1.Controls.Add(ReplaceBox, 1, 1);
            tableLayoutPanel1.Controls.Add(FindButton, 2, 0);
            tableLayoutPanel1.Controls.Add(ReplaceButton, 2, 1);
            tableLayoutPanel1.Controls.Add(ReplaceAllButton, 2, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // Find
            // 
            Find.AutoSize = true;
            Find.Dock = DockStyle.Fill;
            Find.Location = new Point(3, 0);
            Find.Name = "Find";
            Find.Size = new Size(82, 50);
            Find.TabIndex = 0;
            Find.Text = "Find :";
            Find.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Replace
            // 
            Replace.AutoSize = true;
            Replace.Dock = DockStyle.Fill;
            Replace.FlatStyle = FlatStyle.System;
            Replace.Location = new Point(3, 50);
            Replace.Name = "Replace";
            Replace.Size = new Size(82, 50);
            Replace.TabIndex = 1;
            Replace.Text = "Replace all";
            Replace.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FindBox
            // 
            FindBox.Dock = DockStyle.Fill;
            FindBox.Location = new Point(91, 20);
            FindBox.Margin = new Padding(3, 20, 3, 3);
            FindBox.Name = "FindBox";
            FindBox.Size = new Size(492, 27);
            FindBox.TabIndex = 2;
            // 
            // ReplaceBox
            // 
            ReplaceBox.Dock = DockStyle.Fill;
            ReplaceBox.Location = new Point(91, 70);
            ReplaceBox.Margin = new Padding(3, 20, 3, 3);
            ReplaceBox.Name = "ReplaceBox";
            ReplaceBox.Size = new Size(492, 27);
            ReplaceBox.TabIndex = 3;
            // 
            // FindButton
            // 
            FindButton.Dock = DockStyle.Fill;
            FindButton.FlatStyle = FlatStyle.System;
            FindButton.Location = new Point(589, 3);
            FindButton.Name = "FindButton";
            FindButton.Size = new Size(208, 44);
            FindButton.TabIndex = 4;
            FindButton.Text = "Find next";
            FindButton.UseVisualStyleBackColor = true;
            // 
            // ReplaceButton
            // 
            ReplaceButton.Dock = DockStyle.Fill;
            ReplaceButton.FlatStyle = FlatStyle.System;
            ReplaceButton.Location = new Point(589, 53);
            ReplaceButton.Name = "ReplaceButton";
            ReplaceButton.Size = new Size(208, 44);
            ReplaceButton.TabIndex = 5;
            ReplaceButton.Text = "Replace next";
            ReplaceButton.UseVisualStyleBackColor = true;
            // 
            // ReplaceAllButton
            // 
            ReplaceAllButton.Dock = DockStyle.Fill;
            ReplaceAllButton.FlatStyle = FlatStyle.System;
            ReplaceAllButton.Location = new Point(589, 103);
            ReplaceAllButton.Name = "ReplaceAllButton";
            ReplaceAllButton.Size = new Size(208, 344);
            ReplaceAllButton.TabIndex = 8;
            ReplaceAllButton.Text = "Replace all";
            ReplaceAllButton.UseVisualStyleBackColor = true;
            // 
            // FindAndReplace
            // 
            AcceptButton = FindButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FindAndReplace";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FindAndReplace";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label Find;
        private Label Replace;
        internal Button FindButton;
        internal Button ReplaceButton;
        internal Button ReplaceAllButton;
        internal TextBox FindBox;
        internal TextBox ReplaceBox;
    }
}