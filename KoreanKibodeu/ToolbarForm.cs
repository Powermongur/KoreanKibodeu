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
    public partial class ToolbarForm : Form
    {
        public ToolbarForm()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        MainForm mainDialog;

        private void ToolbarForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ToolbarForm_Load(object sender, EventArgs e)
        {
            mainDialog = (MainForm)Owner;
        }

        private void focusButton_Click(object sender, EventArgs e)
        {
            mainDialog.FocusText();
        }

        private void blackWhitebutton_Click(object sender, EventArgs e)
        {
            mainDialog.BlackWhite();
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            mainDialog.HideShow(false);
            Dispose();
        }

        private void moveLocationButton_Click(object sender, EventArgs e)
        {
            mainDialog.MoveLocation(Location);
        }
    }
}
