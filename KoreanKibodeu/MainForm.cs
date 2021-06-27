﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Web;

namespace KoreanKibodeu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        Keys lastKey = Keys.Shift;
        bool conversionMode = true;
        public enum languageCode : ushort
        { norm = 0, en = 1, dk = 2, se = 3, no = 4, de = 5, jp = 6, kr = 7 }
        AppSettings appSet = new AppSettings();
        List<string> history = new List<string>();
        int historyIndex = -1;

        private void MainForm_Load(object sender, EventArgs e)
        {
            TopMost = true;

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].TabIndex >= 1000)
                    Controls[i].MouseDown += new System.Windows.Forms.MouseEventHandler(MainForm_MouseDown);
            }
        }

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
            Dispose();
        }

        private void minimizebutton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (conversionMode)
            {
                if (appSet.Language == (int)languageCode.kr)
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        if (lastKey != Keys.Space)
                            e.SuppressKeyPress = true;

                    }
                }
            }
            lastKey = e.KeyCode;
        }

        private void messageTextBox_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space && Control.ModifierKeys == Keys.Shift)
            {
                conversionMode = !conversionMode;
                if (conversionMode)
                    statusLabel2.Text = "Mode: x";
                else
                    statusLabel2.Text = "Mode: abc";

                return;
            }

            int cursorI = messageTextBox.SelectionStart - 1;
            string msg = messageTextBox.Text;


            if (e.KeyCode == Keys.Up)
            {
                if (historyIndex > 0)
                {
                    historyIndex--;
                    msg = history[historyIndex];
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (historyIndex < history.Count - 1)
                {
                    historyIndex++;
                    msg = history[historyIndex];
                }
            }

            if (historyIndex == -1)
            {
                history.Add(msg);
                historyIndex = history.Count - 1;
            }
            else if (history[historyIndex].Length > msg.Length)
            {
                if (!history[historyIndex].Contains(msg))
                {
                    //history.Add(msg);
                    //historyIndex = history.Count - 1;
                }
            }
            else
            {
                if (!msg.Contains(history[historyIndex]))
                {
                    history[historyIndex] = msg;
                }
                else
                {
                    history.Add(msg);
                    historyIndex = history.Count - 1;
                }
            }

            /*
            if (msg.Length > 0 && conversionMode)
            if (cursorI < 0)
                cursorI = 0;
            */

            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                msg = Command(msg);

            if (conversionMode)
            {
                if (appSet.Language == (int)languageCode.de)
                {
                    if (msg.Contains("sss"))
                        msg = msg.Replace("sss", "ß");

                    msg = ReplaceSpecialChar("„“‚‘»«›‹—–…", msg);

                    messageTextBox.SelectionStart = messageTextBox.Text.Length;
                }
                if (appSet.Language == (int)languageCode.dk || appSet.Language == (int)languageCode.no)
                {
                    if (msg.Contains("ae"))
                    {
                        msg = msg.Replace("ae", "æ");
                        messageTextBox.SelectionStart = messageTextBox.Text.Length;
                    }
                    if (msg.Contains("AE"))
                    {
                        msg = msg.Replace("AE", "Æ");
                        messageTextBox.SelectionStart = messageTextBox.Text.Length;
                    }
                    if (msg.Contains("oe"))
                    {
                        msg = msg.Replace("oe", "ø");
                        messageTextBox.SelectionStart = messageTextBox.Text.Length;
                    }
                    if (msg.Contains("OE"))
                    {
                        msg = msg.Replace("OE", "Ø");
                        messageTextBox.SelectionStart = messageTextBox.Text.Length;
                    }

                }
                if (appSet.Language == (int)languageCode.dk || appSet.Language == (int)languageCode.no || appSet.Language == (int)languageCode.se)
                {
                    if (false)
                    {
                        string[] numbersDK = new string[] { "nul", "en", "to", "tre", "fire", "fem", "seks", "syv", "otte", "ni", "ti" };
                    }

                    if (msg.Contains("aaa")) //se
                    {
                        msg = msg.Replace("aaa", "å");
                        messageTextBox.SelectionStart = messageTextBox.Text.Length;
                    }
                    if (msg.Contains("AAA")) //se
                    {
                        msg = msg.Replace("AAA", "Å");
                        messageTextBox.SelectionStart = messageTextBox.Text.Length;
                    }
                }

                if (appSet.Language == (int)languageCode.jp)
                {                   
                    msg = msg.Replace("shi", "si");
                    msg = msg.Replace("chi", "ti");
                    msg = msg.Replace("tsu", "tu");
                    msg = msg.Replace("fu", "hu");
                    msg = msg.Replace("ji", "zi");
                    msg = msg.Replace("dji", "di");
                    msg = msg.Replace("dzu", "du");

                    string abcJpC = "wrymhntskbdzgp";
                    string abcJpV = "aiueo";

                    List<string> hiraganaABC = new List<string>();
                    hiraganaABC.Add("わらやまはなたさかばだざがぱ");
                    hiraganaABC.Add(" り みひにちしきびぢじぎぴ");
                    hiraganaABC.Add(" るゆむふぬつすくぶづずぐぷ");
                    hiraganaABC.Add(" れ めへねてせけべでぜげぺ");
                    hiraganaABC.Add("をろよもほのとそこぼどぞごぽ");

                    for (int v = 0; v < abcJpV.Length; v++)
                    {
                        for (int c = 0; c < abcJpC.Length; c++)
                        {
                            if (hiraganaABC[v][c].ToString() != " ")
                                msg = msg.Replace(abcJpC[c].ToString() + abcJpV[v].ToString(), hiraganaABC[v][c].ToString());
                        }
                    }

                    string hiraganaN = "なにぬねの";

                    for (int i = 0; i < hiraganaN.Length; i++)
                    {
                        msg = msg.Replace("ん" + abcJpV[i].ToString(), hiraganaN[i].ToString());
                    }

                    string hiraganaA = "あいうえお";

                    for (int a = 0; a < hiraganaA.Length; a++)
                    {
                        msg = msg.Replace(abcJpV[a], hiraganaA[a]);
                    }

                    msg = msg.Replace("n", "ん");

                    //Sutegana
                    msg = msg.Replace("YA", "ゃ");
                    msg = msg.Replace("YU", "ゅ");
                    msg = msg.Replace("YO", "ょ");

                    msg = msg.Replace("TSU", "TU");
                    msg = msg.Replace("TU", "っ");

                    string suteganaABCa = "ぁぃぅぇぉ";

                    for (int i = 0; i < suteganaABCa.Length; i++)
                    {
                        msg = msg.Replace(abcJpV[i].ToString().ToUpper(), suteganaABCa[i].ToString());
                    }

                    msg = msg.Replace("v", "ゔ");
                    msg = ReplaceSpecialChar("ーゝゞ、。", msg);
                }

                if (appSet.Language == (int)languageCode.kr)
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        msg = msg.Replace("ng", "ㅇ");
                        msg = msg.Replace("g", "k");
                        msg = msg.Replace("d", "t");
                        msg = msg.Replace("b", "p");
                        msg = msg.Replace("l", "r");

                        string[] abcRoC = new string[] { "kk", "tt", "pp", "ss", "jj", "k", "n", "t", "r", "m", "p", "s", "j", "ch", "K", "T", "P", "h", "ng"};
                        string abcKrC = "ㄲㄸㅃㅆㅉㄱㄴㄷㄹㅁㅂㅅㅈㅊㅋㅌㅍㅎㅇ";
                        string[] abcRoV = new string[] { "yae", "yeo", "wae", "eu", "ui", "ya", "ye", "yu", "yo", "wa", "we", "wi", "wo", "ae", "eo", "oe", "a", "e", "o", "u", "i" };
                        string abcKrV = "ㅒㅕㅙㅡㅢㅑㅖㅠㅛㅘㅞㅟㅝㅐㅓㅚㅏㅔㅗㅜㅣ";

                        for (int i = 0; i < abcRoC.Length; i++)
                        {
                            msg = msg.Replace(abcRoC[i], abcKrC[i].ToString());
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

                                if (!abcKrC.Contains(syllableString[0]))
                                    syllableString = " " + syllableString[1].ToString() + syllableString[2].ToString() + syllableString[3].ToString();
                                if (!abcKrC.Contains(syllableString[2]))
                                    syllableString = syllableString[0].ToString() + syllableString[1].ToString() + " " + syllableString[3].ToString();
                                if (!abcKrC.Contains(syllableString[3]))
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

                    }

                }

                messageTextBox.Text = msg;
                //messageTextBox.SelectionStart = i;
                messageTextBox.SelectionStart = msg.Length;
            }

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

        private string DecomposeSyllable(char syllable)
        {
            string initialABC = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
            string medialABC = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
            string finalABC = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";

            int syllableChar = (int)syllable;

            if (syllableChar > 44032)
                syllableChar -= 44032;

            int initialIndex = syllableChar / 588;
            int medialIndex = (syllableChar % 588) / 28;
            int finalIndex = (syllableChar % 588) % 28;

            return initialABC[initialIndex].ToString() + medialABC[medialIndex].ToString() + finalABC[finalIndex].ToString();
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
            if (msg.Length > 1)
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

                /*
                 string tester = "string%20%20%25amp%25lt%25gt%5C%25%2339%2C%3A";

                string rawString = "string  &<>\"',:;";
                //string rawString = @"this & that";
                var uriEncoded = Uri.EscapeDataString(rawString);
                var httpUtilityEncoded = HttpUtility.UrlEncode(rawString); //,Encoding.UTF8
                var httpUtilityEncoded2 = HttpUtility.HtmlEncode(rawString);

                statusLabel.Text = httpUtilityEncoded2;
                statusLabel.Text = Uri.EscapeDataString(statusLabel.Text);
                statusLabel.Text = statusLabel.Text.Replace("%3B", "");
                statusLabel.Text = statusLabel.Text.Replace("%26", "%25");
                statusLabel.Text = statusLabel.Text.Replace("%25quot", "%5C");

                if (tester == statusLabel.Text)
                    statusLabel.Text = "true";

                //statusLabel.Text = uriEncoded;
                // uriEncoded = "this%20%26%20that"

                //statusLabel.Text = httpUtilityEncoded;
                // httpUtilityEncoded = "this+%26+that"

                //statusLabel.Text = httpUtilityEncoded2;
                // httpUtilityEncoded = "this amp; that"

                //this%20%25amp%20that
                */

                int tran = 0;

                if (msg.Contains("!trans"))
                {
                    msg = msg.Replace("!trans", "");
                    if (tran == 0)
                        OpenBrowser("https://papago.naver.com/?sk=en&tk=ko&hn=1&st=" + PapagoURL(msg));
                    else
                        OpenBrowser("https://translate.google.com/?sl=en&tl=ko&text=" + msg + "&op=translate");
                }
                if (msg.Contains("!tts"))
                {
                    msg = msg.Replace("!tts", "");
                    if (tran == 0)
                        OpenBrowser("https://papago.naver.com/?sk=ko&tk=en&st=" + PapagoURL(msg));
                    else
                        OpenBrowser("https://translate.google.com/?sl=ko&tl=en&text=" + msg + "&op=translate");
                }

                if (msg.Contains("!search"))
                {
                    msg = msg.Replace("!search", "");
                    OpenBrowser("https://www.google.com");
                }

                if (msg.Contains("!yt"))
                {
                    msg = msg.Replace("!yt", "");
                    OpenBrowser("https://www.youtube.com");
                }

                int convertCheck = msg.Length;

                if (msg.Contains("!en"))
                {
                    appSet.Language = (int)languageCode.en;
                    msg = msg.Replace("!en", "");
                    statusLabel2.Text = "Mode: abc en";
                }
                if (msg.Contains("!dk"))
                {
                    appSet.Language = (int)languageCode.dk;
                    msg = msg.Replace("!dk", "");
                    statusLabel2.Text = "Mode: abc dk";
                }
                if (msg.Contains("!se"))
                {
                    appSet.Language = (int)languageCode.se;
                    msg = msg.Replace("!se", "");
                    statusLabel2.Text = "Mode: abc se";
                }
                if (msg.Contains("!no"))
                {
                    appSet.Language = (int)languageCode.no;
                    msg = msg.Replace("!no", "");
                    statusLabel2.Text = "Mode: abc no";
                }
                if (msg.Contains("!de"))
                {
                    appSet.Language = (int)languageCode.de;
                    msg = msg.Replace("!de", "");
                    statusLabel2.Text = "Mode: abc de";
                }
                if (msg.Contains("!jp"))
                {
                    appSet.Language = (int)languageCode.jp;
                    msg = msg.Replace("!jp", "");
                    statusLabel2.Text = "Mode: ひらがな";
                }
                if (msg.Contains("!kr"))
                {
                    appSet.Language = (int)languageCode.kr;
                    msg = msg.Replace("!kr", "");
                    statusLabel2.Text = "Mode: 한글";
                }

                if (convertCheck != msg.Length)
                    conversionMode = true;

                appSet.Save();
                messageTextBox.SelectionStart = messageTextBox.Text.Length;                
            }

            return msg;
        }

        private void OpenBrowser(string url)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo{ FileName = url, UseShellExecute = true };

            try
            { Process.Start(psInfo); }
            catch (Exception ex)
            { Process.Start("iexplore.exe", psInfo.FileName); }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            /*
            SettingsForm settingsDialog = new SettingsForm();
            settingsDialog.ShowDialog(this);
            settingsDialog.Dispose();
            */

            HiraganaHelpForm hiraganaHelpDialog = new HiraganaHelpForm();
            hiraganaHelpDialog.ShowDialog(this);
            hiraganaHelpDialog.Dispose();
        }

        private void translateButton_Click(object sender, EventArgs e)
        {
            Command(messageTextBox.Text + "!trans");
        }

        private void ttsButton_Click(object sender, EventArgs e)
        {
            Command(messageTextBox.Text + "!tts");
        }

        private string PapagoURL(string url)
        {
            url = HttpUtility.HtmlEncode(url);
            url = Uri.EscapeDataString(url);
            url = url.Replace("%3B", "");
            url = url.Replace("%26", "%25");
            url = url.Replace("%25quot", "%5C");
            return url;
        }

        private string ReplaceSpecialChar(string specialCharABC, string msg)
        {
            for (int i = 0; i < specialCharABC.Length; i++)
            {
                msg = msg.Replace("x" + (i + 1).ToString() + " ", specialCharABC[i].ToString());
            }

            return msg;
        }
    }
}
