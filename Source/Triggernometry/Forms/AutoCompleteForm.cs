using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.Forms
{

    public partial class AutoCompleteForm : Form
    {

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        public AutoCompleteForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }


        public string GetChosenAutocomplete()
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                return listBox1.SelectedItem.ToString();
            }
            return "";
        }

        public void NextAutocompleteItem()
        {
            int i = listBox1.SelectedIndex + 1;
            if (i > listBox1.Items.Count - 1)
            {
                i = 0;
            }
            listBox1.SelectedIndex = i;
        }

        public void PreviousAutocompleteItem()
        {
            int i = listBox1.SelectedIndex - 1;
            if (i < 0)
            {
                i = listBox1.Items.Count - 1;
            }
            listBox1.SelectedIndex = i;
        }

        public void NextAutocompletePage()
        {
            int i = listBox1.SelectedIndex + 5;
            if (i > listBox1.Items.Count - 1)
            {
                i = listBox1.Items.Count - 1;
            }
            listBox1.SelectedIndex = i;
        }

        public void PreviousAutocompletePage()
        {
            int i = listBox1.SelectedIndex - 5;
            if (i < 0)
            {
                i = 0;
            }
            listBox1.SelectedIndex = i;
        }

        public void BuildList(IEnumerable<string> strs)
        {
            SuspendLayout();
            bool hadold = false;
            string str = "";
            int calcheight = 1 + Math.Min(5, strs.Count());
            calcheight *= listBox1.ItemHeight;
            float longeststr = 0.0f;
            using (Graphics g = CreateGraphics())
            {
                foreach (string st in strs)
                {
                    longeststr = Math.Max(longeststr, g.MeasureString(st, listBox1.Font).Width);
                }
            }
            int strw = Math.Min(300, (int)Math.Ceiling(longeststr) + 40);
            listBox1.Width = strw;
            listBox1.Height = calcheight;
            if (listBox1.Items.Count > 0 && listBox1.SelectedItem != null)
            {
                str = listBox1.SelectedItem.ToString();
                hadold = true;
            }
            listBox1.Items.Clear();
            listBox1.Items.AddRange(strs.ToArray());
            if (hadold == true)
            {
                int i = 0;
                foreach (string s in strs)
                {
                    if (string.Compare(s, str, true) == 0)
                    {                        
                        break;
                    }
                    i++;
                }
                if (i > strs.Count() - 1)
                {
                    i = 0;
                }
                listBox1.SelectedIndex = i;
            }
            else
            {
                listBox1.SelectedIndex = 0;
            }
            ResumeLayout();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)0x84)
            {
                m.Result = (IntPtr)(-1);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

    }

}
