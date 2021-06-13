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
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void HelpForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            ShowLongNames(false);
        }

        private void longNamesCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            ShowLongNames(longNamesCheckBox.Checked);
        }

        private void ShowLongNames(bool value)
        {
            labelGiyeok.Visible = value;
            labelNieun.Visible = value;
            labelDigeut.Visible = value;
            labelRieul.Visible = value;
            labelMieum.Visible = value;
            labelBieup.Visible = value;
            labelSiot.Visible = value;
            labelIeung.Visible = value;
            labelJjeut.Visible = value;
            labelHieut.Visible = value;
            labelSsanggiyeok.Visible = value;
            labelSsangdigeut.Visible = value;
            labelSsangbieup.Visible = value;
            labelSsangsiot.Visible = value;
            labelSsangjieut.Visible = value;
            labelKieuk.Visible = value;
            labelTieut.Visible = value;
            labelPieup.Visible = value;
            labelChieut.Visible = value;
        }
    }
}
