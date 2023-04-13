﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParadoxEditor
{
    public partial class DesignerBrowserUserControl : UserControl
    {
        public DesignerBrowserUserControl()
        {
            InitializeComponent();
        }
        public void PopulateListView(List<string> names)
        {
            listView1.Items.Clear();
            foreach (string name in names)
            {
                listView1.Items.Add(new ListViewItem(name));
            }
        }
    }
}
