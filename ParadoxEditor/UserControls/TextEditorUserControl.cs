using ParadoxEditor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;

namespace ParadoxEditor
{
    public partial class TextEditorUserControl : UserControl
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private const int WM_VSCROLL = 0x115;
        private const int SB_THUMBPOSITION = 4;
        private FindAndReplace findAndReplace;
        public TextEditorUserControl()
        {
            InitializeComponent();
        }
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                ShowSearchReplaceDialog();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void ShowSearchReplaceDialog()
        {
            if (findAndReplace == null || findAndReplace.IsDisposed)
            {
                findAndReplace = new FindAndReplace();
                findAndReplace.FindButton.Click += (s, e) =>
                {
                    int startIndex = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
                    int foundIndex = richTextBox1.Find(findAndReplace.FindBox.Text, startIndex, RichTextBoxFinds.None);

                    if (foundIndex >= 0)
                    {
                        richTextBox1.SelectionStart = foundIndex;
                        richTextBox1.SelectionLength = findAndReplace.FindBox.Text.Length;
                        ScrollToCaret(richTextBox1);
                    }
                };

                findAndReplace.ReplaceButton.Click += (s, e) =>
                    {
                        if (richTextBox1.SelectionLength > 0)
                        {
                            richTextBox1.SelectedText = findAndReplace.ReplaceBox.Text;
                            richTextBox1.SelectionStart = richTextBox1.SelectionStart + findAndReplace.ReplaceBox.Text.Length;
                            ScrollToCaret(richTextBox1);
                        }
                    };

                findAndReplace.ReplaceAllButton.Click += (s, e) =>
                    {
                        int startIndex = 0;
                        while (startIndex < richTextBox1.TextLength)
                        {
                            int foundIndex = richTextBox1.Find(findAndReplace.FindBox.Text, startIndex, RichTextBoxFinds.None);

                            if (foundIndex >= 0)
                            {
                                richTextBox1.SelectionStart = foundIndex;
                                richTextBox1.SelectionLength = findAndReplace.FindBox.Text.Length;
                                richTextBox1.SelectedText = findAndReplace.ReplaceBox.Text;

                                startIndex = foundIndex + findAndReplace.ReplaceBox.Text.Length;
                            }
                            else
                            {
                                break;
                            }
                        }
                    };

                findAndReplace.FormClosed += (s, e) =>
                {
                    findAndReplace.Dispose();
                };
                findAndReplace.Show();

            }
            else
            {
                findAndReplace.Activate();
            }
        }
        private void ScrollToCaret(RichTextBox richTextBox)
        {
            int lineIndex = richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart);
            SendMessage(richTextBox.Handle, WM_VSCROLL, (IntPtr)(SB_THUMBPOSITION + 0x10000 * lineIndex), IntPtr.Zero);
        }

    }
}
