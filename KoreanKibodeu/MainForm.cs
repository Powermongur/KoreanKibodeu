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

        Keys lastKey = Keys.Shift;

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
            helpDialog.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void minimizebutton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            { }

            int cursorI = messageTextBox.SelectionStart - 1;
            string msg = messageTextBox.Text;

            if (msg.Length > 0)
            {
                if (cursorI < 0)
                    cursorI = 0;

                if(e.KeyCode == Keys.Space)
                {
                    if (lastKey != Keys.Space)
                        e.SuppressKeyPress = true;

                    msg = Command(msg);

                    msg = msg.Replace("ng", "ㅇ");
                    msg = msg.Replace("g", "k");
                    msg = msg.Replace("d", "t");
                    msg = msg.Replace("b", "p");
                    msg = msg.Replace("l", "r");

                    string[] abcRoK = new string[] { "kk", "tt", "pp", "ss", "jj", "k", "n", "t", "r", "m", "p", "s", "j", "ch", "K", "T", "P", "h", "ng" };
                    string abcKrK = "ㄲㄸㅃㅆㅉㄱㄴㄷㄹㅁㅂㅅㅈㅊㅋㅌㅍㅎㅇ";
                    string[] abcRoV = new string[] { "yae", "yeo", "wae", "eu", "ui", "ya", "ye", "yu", "yo", "wa", "wi", "wo", "ae", "eo", "oe", "a", "e", "o", "u", "i", "we" };
                    string abcKrV = "ㅒㅕㅙㅡㅢㅑㅖㅠㅛㅘㅟㅝㅐㅓㅚㅏㅔㅗㅜㅣㅞ";

                    for (int i = 0; i < abcRoK.Length; i++)
                    {
                        msg = msg.Replace(abcRoK[i], abcKrK[i].ToString());
                    }

                    for (int i = 0; i < abcRoV.Length; i++)
                    {
                        msg = msg.Replace(abcRoV[i], abcKrV[i].ToString());
                    }

                    string syllableString = " " + msg + "  ";

                    for (int i = syllableString.Length - 3; i > syllableString.Length - 7 && i > 0; i--)
                    {
                        if (IsVowel(syllableString[i]))
                        {
                            syllableString = syllableString.Substring(i - 1, 4);

                            if (!abcKrK.Contains(syllableString[0]))
                                syllableString = " " + syllableString[1].ToString() + syllableString[2].ToString() + syllableString[3].ToString();
                            if (!abcKrK.Contains(syllableString[2]))
                                syllableString = syllableString[0].ToString() + syllableString[1].ToString() + " " + syllableString[3].ToString();
                            if (!abcKrK.Contains(syllableString[3]))
                                syllableString = syllableString[0].ToString() + syllableString[1].ToString() + syllableString[2].ToString() + " ";

                            i = -1;
                        }
                    }

                    char syllableChar = ComposeSyllable(syllableString);

                    if ((int)syllableChar > 0)
                    {
                        syllableString = syllableString.Trim();
                        msg = msg.Remove(msg.Length - syllableString.Length, syllableString.Length);
                        msg += syllableChar.ToString();
                        //msg = msg.Replace(syllableString, syllableChar.ToString());
                    }

                    messageTextBox.Text = msg;
                    //messageTextBox.SelectionStart = i;
                    messageTextBox.SelectionStart = msg.Length;
                }
            }

            lastKey = e.KeyCode;
        }

        private char ComposeSyllable(string syllable)
        {
            string initialABC = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
            string medialABC = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
            string finalABC = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";

            if (syllable.Length < 1)
                return (char)0;
            else if (syllable.Length == 1)
                syllable = " " + syllable;

            syllable += "  ";

            char finalChar = ComposeFinalSyllable(syllable[2], syllable[3]);

            int initialIndex = initialABC.IndexOf(syllable[0].ToString());
            int medialIndex = medialABC.IndexOf(syllable[1].ToString());
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
            string finalABC = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";

            int final1Index = finalABC.IndexOf(finalChar1.ToString());
            int final2Index = finalABC.IndexOf(finalChar2.ToString());

            if (final1Index < 0)
                return (char)0;

            if (final2Index < 0)
                return finalABC[final1Index];

            if (finalChar1.ToString() == "ㄱ")
                return "012345678ㄳ012345678"[final2Index];
            else if (finalChar1.ToString() == "ㄴ")
                return "012345678901ㄵ34567ㄶ"[final2Index];
            else if (finalChar1.ToString() == "ㄹ")
                return "ㄺ12345ㄻㄼ8ㄽ012345ㄾㄿㅀ"[final2Index];
            else if (finalChar1.ToString() == "ㅂ")
                return "012345678ㅄ012345678"[final2Index];

            return (char)0;
        }

        private bool IsVowel(char letter)
        {
            string vowelABC = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";

            for (int i = 0; i < vowelABC.Length; i++)
            {
                if (letter == vowelABC[i])
                    return true;
            }

            return false;
        }

        private string Command(string msg)
        {
            if (msg.Contains("!help"))
            {
                HelpForm helpDialog = new HelpForm();
                helpDialog.Show();
                msg = msg.Replace("!help", "");
            }
            if (msg.Contains("!quit") || msg.Contains("!exit"))
            {
                this.Dispose();
            }

            return msg;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsDialog = new SettingsForm();
            settingsDialog.ShowDialog(this);
            settingsDialog.Dispose();
        }
    }
}
