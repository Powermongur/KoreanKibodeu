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
    public partial class KanaKeysForm : Form
    {
        public KanaKeysForm()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        AppSettings appSet = new AppSettings();
        List<Control> formControls = new List<Control>();

        private void HiraganaHelpForm_Load(object sender, EventArgs e)
        {
            TopMost = appSet.StayOnTop;

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].TabIndex >= 1000)
                    Controls[i].MouseDown += new System.Windows.Forms.MouseEventHandler(HiraganaHelpForm_MouseDown);
            }

            FormControlsAdd(kanaBasicPanel.Controls);
            FormControlsAdd(kanaBasicPanel2.Controls);
            FormControlsAdd(kanaDakutenPanel.Controls);
            FormControlsAdd(kanaHandakutenPanel.Controls);
            FormControlsAdd(kanaSuteganaPanel.Controls);
            FormControlsAdd(kanaSpecialPanel.Controls);
            FormControlsAdd(kanaSpecialPanel2.Controls);
        }

        private void HiraganaHelpForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FormControlsAdd(Control.ControlCollection controlCol)
        {
            for (int i = 0; i < controlCol.Count; i++)
            {
                formControls.Add(controlCol[i]);
            }
        }

        private void hiraganaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(hiraganaRadioButton.Checked)
                kanaLanguageLabel.Text = "Hiragana";
            else
                kanaLanguageLabel.Text = "Katagana";

            KanaConvertClass converter = new KanaConvertClass();

            for (int i = 0; i < formControls.Count; i++)
            {
                if (formControls[i].Name.Contains("kana") && !formControls[i].Name.Contains("Key"))
                    formControls[i].Text = converter.Convert(formControls[i].Text, hiraganaRadioButton.Checked);
            }
        }
    }
}
