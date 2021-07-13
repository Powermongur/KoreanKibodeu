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
    public partial class NorwegianKeysForm : Form
    {
        public NorwegianKeysForm()
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
        MainForm mainDialog;

        private void NorwegianKeysForm_Load(object sender, EventArgs e)
        {
            mainDialog = (MainForm)Owner;
            TopMost = appSet.StayOnTop;

            keyMenuSelectlabel.Visible = true;
            optionsMenuSelectlabel.Visible = false;
            commandMenuSelectlabel.Visible = false;

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].TabIndex >= 1000)
                    Controls[i].MouseDown += new System.Windows.Forms.MouseEventHandler(NorwegianKeysForm_MouseDown);
            }
        }

        private void NorwegianKeysForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            mainDialog.CloseKeyDialog();
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            mainDialog.OpenOptionDialog(Location);
            mainDialog.CloseCommandDialog();
        }

        private void commandsButton_Click(object sender, EventArgs e)
        {
            mainDialog.OpenCommandDialog(Location);
            mainDialog.CloseOptionDialog();
        }
    }
}
