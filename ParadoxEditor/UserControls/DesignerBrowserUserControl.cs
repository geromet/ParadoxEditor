using Reader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ParadoxEditor
{
    public partial class DesignerBrowserUserControl : UserControl
    {
        public Node RootNode { get; set; }
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
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                Node node = RootNode.Children.Find(node => node.Name == selectedItem.Text);
                TabPage tabPage = new TabPage(selectedItem.Text);
                TextEditorUserControl textEditor = new TextEditorUserControl();
                tabPage.Controls.Add(textEditor);
                textEditor.Dock = DockStyle.Fill;
                textEditor.richTextBox1.Text = NodeLibrary.Print(node);
                darkTabControl1.TabPages.Add(tabPage);
                darkTabControl1.SelectedTab = tabPage;
            }
        }
    }
}
