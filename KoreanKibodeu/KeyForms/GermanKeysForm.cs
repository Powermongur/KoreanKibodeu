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
    public partial class GermanKeysForm : Form
    {
        public GermanKeysForm()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        AppSettingsClass appSet = new AppSettingsClass();

        private void GermanKeysForm_Load(object sender, EventArgs e)
        {
            TopMost = appSet.StayOnTop;

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].TabIndex >= 1000)
                    Controls[i].MouseDown += new System.Windows.Forms.MouseEventHandler(GermanKeysForm_MouseDown);
            }

            qwertyToQwertzCheckBox.Checked = appSet.Qwertz;
        }
        private void GermanKeysForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void qwertyToQwertzCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            appSet.Qwertz = qwertyToQwertzCheckBox.Checked;
            appSet.Save();
        }

        private void qwertyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (qwertyRadioButton.Checked)
                qwertyToQwertzCheckBox.Text = "qwerty -> qwertz";
            else
                qwertyToQwertzCheckBox.Text = "qwertz -> qwerty";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
