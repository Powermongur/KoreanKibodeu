using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoreanKibodeu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 helpDialog = new Form2();
            helpDialog.ShowDialog(this);
            helpDialog.Dispose();
        }
    }
}
