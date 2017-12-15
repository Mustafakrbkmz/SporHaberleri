using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rssssss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            Reader oku = new Reader();
            foreach (Haberler zamazingo in oku.News())
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = zamazingo.haber;
                lv.SubItems.Add(zamazingo.link);
                listView1.Items.Add(lv);
            }

            
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                Form2 frm = new Form2();
                frm.Show();
                frm.webBrowser1.Navigate(listView1.SelectedItems[0].SubItems[1].Text);
            }
            
        }
    }
}
