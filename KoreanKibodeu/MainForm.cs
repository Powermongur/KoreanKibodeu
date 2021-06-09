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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MainForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            HelpForm helpDialog = new HelpForm();
            helpDialog.ShowDialog(this);
            helpDialog.Dispose();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void minimizebutton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = messageTextBox.Text;

            if (msg.Length < 4)
                msg = msg.Substring(0, msg.Length);
            else
                msg = msg.Substring(msg.Length - 4, 4);
            //msg = msg.Substring(messageTextBox.SelectionStart - 4, 4);

            char syllableChar = ComposeSyllable(msg);

            button1.Text = syllableChar.ToString();
        }

        private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            { }

            int selectI = messageTextBox.SelectionStart - 1;
            string msg = messageTextBox.Text;

            if (msg.Length > 0)
            {
                if (selectI < 0)
                    selectI = 0;

                if(e.KeyCode == Keys.Space)
                {
                    //msg = msg.Remove(selectI, 1);
                    msg = msg.Replace("ng", "ㅇ");
                    msg = msg.Replace("g", "k");
                    msg = msg.Replace("d", "t");
                    msg = msg.Replace("b", "p");
                    msg = msg.Replace("l", "r");

                    string[] abcRoK = new string[] { "kk", "tt", "pp", "ss", "jj", "k", "n", "t", "r", "m", "p", "s", "j", "ch", "K", "T", "P", "h", "ng" };
                    string[] abcKrK = new string[] { "ㄲ", "ㄸ", "ㅃ", "ㅆ", "ㅉ", "ㄱ", "ㄴ", "ㄷ", "ㄹ", "ㅁ", "ㅂ", "ㅅ", "ㅈ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ", "ㅇ" };
                    string[] abcRoV = new string[] { "yae", "yeo", "wae", "eu", "ui", "ya", "ye", "yu", "yo", "wa", "wi", "wo", "ae", "eo", "oe", "a", "e", "o", "u", "i" };
                    string[] abcKrV = new string[] { "ㅒ", "ㅕ", "ㅙ", "ㅡ", "ㅢ", "ㅑ", "ㅖ", "ㅠ", "ㅛ", "ㅘ", "ㅟ", "ㅝ", "ㅐ", "ㅓ", "ㅚ", "ㅏ", "ㅔ", "ㅗ", "ㅜ", "ㅣ" };

                    for (int i = 0; i < abcRoK.Length; i++)
                    {
                        msg = msg.Replace(abcRoK[i], abcKrK[i]);
                    }

                    for (int i = 0; i < abcRoV.Length; i++)
                    {
                        msg = msg.Replace(abcRoV[i], abcKrV[i]);
                    }

                    messageTextBox.Text = msg;
                    //messageTextBox.SelectionStart = i;
                    messageTextBox.SelectionStart = msg.Length;
                }
            }
        }

        private char ComposeSyllable(string syllable)
        {
            string initialABC = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
            string medialABC = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
            string finalABC = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";

            int vowelIndex = 0;

            for (int i = 0; i < medialABC.Length; i++)
            {
                vowelIndex = syllable.IndexOf(medialABC[i]);

                if (vowelIndex != -1)
                    i = medialABC.Length;
            }

            char initialChar = (char)0;
            char medialChar = (char)0;
            char finalChar1 = (char)0;
            char finalChar2 = (char)0;

            if(vowelIndex > -1)
            {
                medialChar = syllable[vowelIndex];

                if (vowelIndex > 0)
                {
                    initialChar = syllable[vowelIndex - 1];
                    if (syllable.Length > 2)
                        finalChar1 = syllable[2];

                    if (syllable.Length > 3)
                        finalChar2 = syllable[3];
                }
            }

            char finalChar = ComposeFinalSyllable(finalChar1, finalChar2);

            int initialIndex = initialABC.IndexOf(initialChar.ToString());
            int medialIndex = medialABC.IndexOf(medialChar.ToString());
            int finalIndex = finalABC.IndexOf(finalChar.ToString());

            if (initialIndex < 0)
                initialIndex = 11;

            if (medialIndex < 0)
                return (char)0;

            if (finalIndex < 0)
                finalIndex = 0;

            int syllableChar = (initialIndex * 588) + (medialIndex * 28) + finalIndex + 44032;

            return (char)syllableChar;
        }

        private char ComposeFinalSyllable(char finalChar1, char finalChar2)
        {
            string basicABC = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
            string combinedABC = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";

            int final1Index = basicABC.IndexOf(finalChar1.ToString());
            int final2Index = basicABC.IndexOf(finalChar2.ToString());

            if (final1Index < 0)
                return (char)0;

            if (final2Index < 0)
                return basicABC[final1Index];

            int syllableChar = 4;

            return combinedABC[4];
        }


        private void settingsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
