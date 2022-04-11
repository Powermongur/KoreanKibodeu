using System;
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

using System.Runtime.InteropServices;
using HWND = System.IntPtr;

namespace KoreanKibodeu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //Move window
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Activate an application window.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        //Minimize/Show app from toolbar
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }


        /// <summary>Contains functionality to get all the open windows.</summary>
        public static class OpenWindowGetter
        {
            /// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
            /// <returns>A dictionary that contains the handle and title of all the open windows.</returns>
            public static IDictionary<HWND, string> GetOpenWindows()
            {
                HWND shellWindow = GetShellWindow();
                Dictionary<HWND, string> windows = new Dictionary<HWND, string>();

                EnumWindows(delegate (HWND hWnd, int lParam)
                {
                    if (hWnd == shellWindow) return true;
                    if (!IsWindowVisible(hWnd)) return true;

                    int length = GetWindowTextLength(hWnd);
                    if (length == 0) return true;

                    StringBuilder builder = new StringBuilder(length);
                    GetWindowText(hWnd, builder, length + 1);

                    windows[hWnd] = builder.ToString();
                    return true;

                }, 0);

                return windows;
            }

            private delegate bool EnumWindowsProc(HWND hWnd, int lParam);
            [DllImport("USER32.DLL")]
            private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);
            [DllImport("USER32.DLL")]
            private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);
            [DllImport("USER32.DLL")]
            private static extern int GetWindowTextLength(HWND hWnd);
            [DllImport("USER32.DLL")]
            private static extern bool IsWindowVisible(HWND hWnd);
            [DllImport("USER32.DLL")]
            private static extern IntPtr GetShellWindow();
        }

        Keys lastKey = Keys.Shift;
        bool conversionMode = true;
        string setWindow = "";
        AppSettingsClass appSet = new AppSettingsClass();
        HistoryClass history = new HistoryClass();
        DanishKeysForm danishDialog = null;
        FrenchKeysForm frenchDialog = null;
        GermanKeysForm germanDialog = null;
        ItalienKeysForm italienDialog = null;
        KanaKeysForm kanaDialog = null;
        KoreanKeysForm koreanDialog = null;
        NorwegianKeysForm norwegianDialog = null;
        SpanishKeysForm spanishDialog = null;
        SwedishKeysForm swedishDialog = null;
        CommandsForm commandDialog = null;
        OptionsForm optionDialog = null;

        public void OpenKeyDialog(Point position)
        {
            if (appSet.Language == (ushort)AppSettingsClass.languageCode.dk)
            {
                danishDialog = new DanishKeysForm();
                danishDialog.Show(this);
                if (!position.IsEmpty)
                    danishDialog.Location = position;
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.se)
            {
                swedishDialog = new SwedishKeysForm();
                swedishDialog.Show(this);
                if (!position.IsEmpty)
                    swedishDialog.Location = position;
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.no)
            {
                norwegianDialog = new NorwegianKeysForm();
                norwegianDialog.Show(this);
                if (!position.IsEmpty)
                    norwegianDialog.Location = position;
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.de)
            {
                germanDialog = new GermanKeysForm();
                germanDialog.Show(this);
                if (!position.IsEmpty)
                    germanDialog.Location = position;
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.jp)
            {
                kanaDialog = new KanaKeysForm();
                kanaDialog.Show(this);
                if (!position.IsEmpty)
                    kanaDialog.Location = position;
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.kr)
            {
                koreanDialog = new KoreanKeysForm();
                koreanDialog.Show(this);
                if (!position.IsEmpty)
                    koreanDialog.Location = position;
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.fr)
            {
                frenchDialog = new FrenchKeysForm();
                frenchDialog.Show(this);
                if (!position.IsEmpty)
                    frenchDialog.Location = position;
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.es)
            {
                spanishDialog = new SpanishKeysForm();
                spanishDialog.Show(this);
                if (!position.IsEmpty)
                    spanishDialog.Location = position;
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.it)
            {
                italienDialog = new ItalienKeysForm();
                italienDialog.Show(this);
                if (!position.IsEmpty)
                    italienDialog.Location = position;
            }

            CloseCommandDialog();
            CloseOptionDialog();
        }

        public void CloseKeyDialog()
        {
            if (danishDialog != null)
                danishDialog.Dispose();
            if (frenchDialog != null)
                frenchDialog.Dispose();
            if (germanDialog != null)
                germanDialog.Dispose();
            if (italienDialog != null)
                italienDialog.Dispose();
            if (kanaDialog != null)
                kanaDialog.Dispose();
            if (koreanDialog != null)
                koreanDialog.Dispose();
            if (norwegianDialog != null)
                norwegianDialog.Dispose();
            if (spanishDialog != null)
                spanishDialog.Dispose();
            if (swedishDialog != null)
                swedishDialog.Dispose();

            danishDialog = null;
            frenchDialog = null;
            germanDialog = null;
            italienDialog = null;
            kanaDialog = null;
            koreanDialog = null;
            norwegianDialog = null;
            spanishDialog = null;
            swedishDialog = null;

            appSet = new AppSettingsClass();
        }

        public void OpenCommandDialog(Point position)
        {
            commandDialog = new CommandsForm();
            commandDialog.Show(this);
            if (!position.IsEmpty)
                commandDialog.Location = position;

            CloseKeyDialog();
            CloseOptionDialog();
        }

        public void CloseCommandDialog()
        {
            if (commandDialog != null)
            {
                commandDialog.Dispose();
                commandDialog = null;
                appSet = new AppSettingsClass();
            }
        }

        public void OpenOptionDialog(Point position)
        {
            optionDialog = new OptionsForm();
            optionDialog.Show(this);
            if (!position.IsEmpty)
                optionDialog.Location = position;

            CloseKeyDialog();
            CloseCommandDialog();
        }

        public void CloseOptionDialog()
        {
            if (optionDialog != null)
            {
                optionDialog.Dispose();
                optionDialog = null;
                appSet = new AppSettingsClass();
            }
        }

        public void FocusText()
        {
            Focus();
            messageTextBox.Focus();
        }

        public void MoveLocation(Point setLocation)
        {
            Location = setLocation;
        }

        public void BlackWhite()
        {
            if(messageTextBox.ForeColor == Color.FromArgb(255, 255, 255))
                messageTextBox.ForeColor = Color.FromArgb(0, 0, 0);
            else
                messageTextBox.ForeColor = Color.FromArgb(255, 255, 255);

            this.Refresh();
        }

        public void HideShow(bool hide)
        {
            if(hide)
            {
                TransparencyKey = Color.FromArgb(255, 254, 255);
                BackColor = Color.FromArgb(255, 254, 255);
                messageTextBox.BackColor = Color.FromArgb(255, 254, 255);
                messageTextBox.ForeColor = Color.FromArgb(0, 0, 0);

                ToolbarForm toolbarDialog = new ToolbarForm();
                toolbarDialog.Show(this);
            }
            else
            {
                BackColor = Color.FromArgb(40, 40, 40);
                messageTextBox.BackColor = Color.FromArgb(70, 70, 70);
                messageTextBox.ForeColor = Color.FromArgb(255, 255, 255);
            }

            topBarlabel.Visible = !hide;
            translateButton.Visible = !hide;
            ttsButton.Visible = !hide;
            statusLabel2.Visible = !hide;
            statusLabel.Visible = !hide;
            minimizeButton.Visible = !hide;
            closeButton.Visible = !hide;
            nameLabel.Visible = !hide;
            nameBottomPanel.Visible = !hide;
            helpButton.Visible = !hide;
            optionsButton.Visible = !hide;
            commandsButton.Visible = !hide;
            keysButton.Visible = !hide;

            this.Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TopMost = appSet.StayOnTop;

            if (appSet.LocationX != 0 || appSet.LocationY != 0)
                Location = new Point(appSet.LocationX, appSet.LocationY);

            appSet.LocationX = 0;
            appSet.LocationY = 0;
            appSet.Save();

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

        private void closeButton_Click(object sender, EventArgs e)
        {
            appSet.LocationX = Location.X;
            appSet.LocationY = Location.Y;
            appSet.Save();
            Dispose();
        }

        private void minimizebutton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private IntPtr FindNotepad(string name)
        {
            foreach (KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
            {
                IntPtr handle = window.Key;
                string title = window.Value;

                if (title.Contains(name))
                    return handle;
            }

            return new IntPtr();
        }


        private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Shift)
            {
                messageTextBox.Text = "";
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (messageTextBox.Text == "")
                {
                    Clipboard.SetText(System.Environment.NewLine);
                }
                else
                {
                    messageTextBox.Copy();
                    Clipboard.SetText(messageTextBox.Text);
                    messageTextBox.Text = "";
                }
                if (Control.ModifierKeys == Keys.Shift)
                {
                    SetForegroundWindow(FindNotepad(setWindow));

                    SendKeys.SendWait("^v");
                    if (messageTextBox.Text == "")
                        SendKeys.SendWait("{ENTER}");

                    SetForegroundWindow(FindNotepad("IXI Kibodeu"));
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (conversionMode)
            {
                if (appSet.Language == (ushort)AppSettingsClass.languageCode.kr)
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        if (lastKey != Keys.Space)
                            e.SuppressKeyPress = true;
                    }
                }
                if (appSet.Language == (ushort)AppSettingsClass.languageCode.de && appSet.Qwertz)
                {
                    if (e.KeyCode == Keys.Y)
                    {
                        if(Control.ModifierKeys == Keys.Shift)
                            messageTextBox.Text = messageTextBox.Text + "Z";
                        else
                            messageTextBox.Text = messageTextBox.Text + "z";
                        
                        messageTextBox.SelectionStart = messageTextBox.Text.Length;
                        e.SuppressKeyPress = true;
                    }
                    if (e.KeyCode == Keys.Z)
                    {
                        if (Control.ModifierKeys == Keys.Shift)
                            messageTextBox.Text = messageTextBox.Text + "Y";
                        else
                            messageTextBox.Text = messageTextBox.Text + "y";

                        messageTextBox.SelectionStart = messageTextBox.Text.Length;
                        e.SuppressKeyPress = true;
                    }
                }
            }
            lastKey = e.KeyCode;

            if (Control.ModifierKeys == Keys.Alt && false)
            {
                string msg = messageTextBox.Text;
                msg = msg.Replace("I", "[I-i]");
                msg = msg.Replace("l", "[l-L]");

                if (messageTextBox.Text != msg)
                {
                    messageTextBox.Text = msg;
                    messageTextBox.SelectionStart = msg.Length;
                }
            }
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
                if (history.index > 0)
                {
                    history.index--;
                    msg = history.msg;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (history.index < history.Count - 1)
                {
                    history.index++;
                    msg = history.msg;
                }
            }

            if (history.index == -1)
            {
                history.AddMsg(msg);
                history.index = history.Count - 1;
            }
            else if (history.msg.Length > msg.Length)
            {
                if (!history.msg.Contains(msg))
                {
                    //history.Add(msg);
                    //historyIndex = history.Count - 1;
                }
            }
            else
            {
                if (!msg.Contains(history.msg))
                {
                    history.msg = msg;
                }
                else
                {
                    history.AddMsg(msg);
                    history.index = history.Count - 1;
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
                if (appSet.Language == (ushort)AppSettingsClass.languageCode.dk || appSet.Language == (ushort)AppSettingsClass.languageCode.no)
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
                if (appSet.Language == (ushort)AppSettingsClass.languageCode.dk || appSet.Language == (ushort)AppSettingsClass.languageCode.no || appSet.Language == (ushort)AppSettingsClass.languageCode.se)
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
                    if (msg.Contains("euro"))
                    {
                        msg = msg.Replace("euro ", "€");
                        messageTextBox.SelectionStart = messageTextBox.Text.Length;
                    }
                }
                if (appSet.Language == (ushort)AppSettingsClass.languageCode.de)
                {
                    msg = msg.Replace("sss", "ß");
                    msg = msg.Replace("euro ", "€");

                    msg = ReplaceSpecialChar("“„‘‚«»‹›—–…", msg);

                    messageTextBox.SelectionStart = messageTextBox.Text.Length;
                }
                if (appSet.Language == (ushort)AppSettingsClass.languageCode.jp)
                {
                    KanaConvertClass converter = new KanaConvertClass();
                    msg = converter.Convert(msg, true);

                    msg = msg.Replace("yen ", "¥");
                    msg = msg.Replace("yenw ", "￥");

                    msg = ReplaceSpecialChar("ーゝゞ、。", msg);

                    messageTextBox.SelectionStart = messageTextBox.Text.Length;
                }
                if (appSet.Language == (ushort)AppSettingsClass.languageCode.kr)
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
                    msg = msg.Replace("won ", "￦");

                }
                if (appSet.Language == (ushort)AppSettingsClass.languageCode.fr)
                {
                    msg = msg.Replace("ae", "æ");
                    msg = msg.Replace("AE", "Æ");
                    msg = msg.Replace("oe", "œ");
                    msg = msg.Replace("OE", "Œ");

                    string[] frenchABC = new string[] { "àâ", "ÀÂ", "éèê", "ÉÈÊ", "ùû", "ÙÛ", "ç", "Ç", "î", "Î", "ô", "Ô" };
                    string inputABC = "aAeEuUcCiIoO";

                    for (int x = 0; x < frenchABC.Length; x++)
                    {
                        msg = msg.Replace(inputABC[x].ToString() + "..", frenchABC[x][0].ToString());
                        msg = msg.Replace(inputABC[x].ToString() + ",,", frenchABC[x][frenchABC[x].Length - 1].ToString());

                        if (frenchABC[x].Length > 1)
                        {
                            for (int y = 0; y < frenchABC[x].Length; y++)
                            {
                                if (y == frenchABC[x].Length - 1)
                                    msg = msg.Replace(frenchABC[x][y].ToString() + ".", frenchABC[x][0].ToString());
                                else
                                    msg = msg.Replace(frenchABC[x][y].ToString() + ".", frenchABC[x][y + 1].ToString());
                                if (y == 0)
                                    msg = msg.Replace(frenchABC[x][y].ToString() + ",", frenchABC[x][frenchABC[x].Length - 1].ToString());
                                else
                                    msg = msg.Replace(frenchABC[x][y].ToString() + ",", frenchABC[x][y - 1].ToString());
                            }
                        }
                    }

                    msg = msg.Replace("euro ", "€");

                    msg = ReplaceSpecialChar("«»“”’—–… ", msg);
                }
                if (appSet.Language == (ushort)AppSettingsClass.languageCode.es)
                {
                    string spanishABC = "áÁéÉíÍñÑóÓúÚ";
                    string inputAB2C = "aAeEiInNoOuU";

                    for (int i = 0; i < spanishABC.Length; i++)
                    {
                        msg = msg.Replace(inputAB2C[i].ToString() + "..", spanishABC[i].ToString());
                        msg = msg.Replace(inputAB2C[i].ToString() + ",,", spanishABC[i].ToString());
                    }

                    msg = msg.Replace("euro ", "€");

                    msg = ReplaceSpecialChar("¿¡«»“”‘’—–…", msg);
                }
                if (appSet.Language == (ushort)AppSettingsClass.languageCode.it)
                {
                    string[] italienhABC = new string[] { "à", "À", "éè", "ÉÈ", "ìî", "ÌÎ", "óò", "ÓÒ", "ù", "Ù" };
                    string inputABC = "aAeEiIoOuU";

                    for (int x = 0; x < italienhABC.Length; x++)
                    {
                        msg = msg.Replace(inputABC[x].ToString() + "..", italienhABC[x][0].ToString());
                        msg = msg.Replace(inputABC[x].ToString() + ",,", italienhABC[x][italienhABC[x].Length - 1].ToString());

                        if (italienhABC[x].Length > 1)
                        {
                            for (int y = 0; y < italienhABC[x].Length; y++)
                            {
                                if (y == italienhABC[x].Length - 1)
                                    msg = msg.Replace(italienhABC[x][y].ToString() + ".", italienhABC[x][0].ToString());
                                else
                                    msg = msg.Replace(italienhABC[x][y].ToString() + ".", italienhABC[x][y + 1].ToString());
                                if (y == 0)
                                    msg = msg.Replace(italienhABC[x][y].ToString() + ",", italienhABC[x][italienhABC[x].Length - 1].ToString());
                                else
                                    msg = msg.Replace(italienhABC[x][y].ToString() + ",", italienhABC[x][y - 1].ToString());
                            }
                        }
                    }

                    msg = msg.Replace("euro ", "€");

                    msg = ReplaceSpecialChar("«»“”‘’—–…", msg);
                }

                if (messageTextBox.Text != msg)
                {
                    messageTextBox.Text = msg;
                    //messageTextBox.SelectionStart = i;
                    messageTextBox.SelectionStart = msg.Length;
                }
            }

            if (Control.ModifierKeys == Keys.Alt)
            {
                msg = msg.Replace("[I-i]", "I");
                msg = msg.Replace("[l-L]", "l");
            }

            if (messageTextBox.Text != msg)
            {
                messageTextBox.Text = msg;
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
                    if (danishDialog != null || frenchDialog != null || germanDialog != null || italienDialog != null || kanaDialog != null || koreanDialog != null || norwegianDialog != null || spanishDialog != null || swedishDialog != null)
                        CloseKeyDialog();
                    else
                        OpenKeyDialog(new Point());
                    msg = msg.Replace("!help", "");
                }
                if (msg.Contains("!quit") || msg.Contains("!exit"))
                {
                    Dispose();
                }
                if (msg.Contains("!topon"))
                {
                    appSet.StayOnTop = true;
                    TopMost = appSet.StayOnTop;
                    msg = msg.Replace("!topon", "");
                }
                if (msg.Contains("!topoff"))
                {
                    appSet.StayOnTop = false;
                    TopMost = appSet.StayOnTop;
                    msg = msg.Replace("!topoff", "");
                }
                if (msg.Contains("!setwindow "))
                {
                    msg = msg.Replace("!setwindow ", "");
                    setWindow = msg;
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
                if (msg.Contains("!qwertzoff"))
                {
                    appSet.Qwertz = false;
                    msg = msg.Replace("!qwertzoff", "");
                }
                if (msg.Contains("!qwertz"))
                {
                    appSet.Qwertz = true;
                    msg = msg.Replace("!qwertz", "");
                }
                if (msg.Contains("!hira") || msg.Contains("!hiragana"))
                {
                    appSet.JPlanguage = 0;
                    msg = msg.Replace("!hira", "");
                }
                if (msg.Contains("!kata") || msg.Contains("!katakana"))
                {
                    appSet.JPlanguage = 1;
                    msg = msg.Replace("!kata", "");
                }
                if (msg.Contains("!kanji"))
                {
                    appSet.JPlanguage = 2;
                    msg = msg.Replace("!kanji", "");
                    OpenBrowser("https://jisho.org/");
                }
                if (msg.Contains("!hide"))
                {
                    msg = msg.Replace("!hide", "");
                    HideShow(true);
                }

                int convertCheck = msg.Length;

                if (msg.Contains("!en"))
                {
                    appSet.Language = (ushort)AppSettingsClass.languageCode.en;
                    msg = msg.Replace("!en", "");
                    statusLabel2.Text = "Mode: abc en";

                    var culture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
                    var language = InputLanguage.FromCulture(culture);
                    if (InputLanguage.InstalledInputLanguages.IndexOf(language) >= 0)
                        InputLanguage.CurrentInputLanguage = language;
                }
                if (msg.Contains("!dk"))
                {
                    appSet.Language = (ushort)AppSettingsClass.languageCode.dk;
                    msg = msg.Replace("!dk", "");
                    statusLabel2.Text = "Mode: abc dk";

                    var culture = System.Globalization.CultureInfo.GetCultureInfo("da-DK");
                    var language = InputLanguage.FromCulture(culture);
                    if (InputLanguage.InstalledInputLanguages.IndexOf(language) >= 0)
                        InputLanguage.CurrentInputLanguage = language;
                }
                if (msg.Contains("!se"))
                {
                    appSet.Language = (ushort)AppSettingsClass.languageCode.se;
                    msg = msg.Replace("!se", "");
                    statusLabel2.Text = "Mode: abc se";
                }
                if (msg.Contains("!no"))
                {
                    appSet.Language = (ushort)AppSettingsClass.languageCode.no;
                    msg = msg.Replace("!no", "");
                    statusLabel2.Text = "Mode: abc no";
                }
                if (msg.Contains("!de"))
                {
                    appSet.Language = (ushort)AppSettingsClass.languageCode.de;
                    msg = msg.Replace("!de", "");
                    statusLabel2.Text = "Mode: abc de";
                }
                if (msg.Contains("!jp"))
                {
                    appSet.Language = (ushort)AppSettingsClass.languageCode.jp;
                    msg = msg.Replace("!jp", "");
                    statusLabel2.Text = "Mode: ひらがな";
                }
                if (msg.Contains("!kr"))
                {
                    appSet.Language = (ushort)AppSettingsClass.languageCode.kr;
                    msg = msg.Replace("!kr", "");
                    statusLabel2.Text = "Mode: 한글";
                }
                if (msg.Contains("!fr"))
                {
                    appSet.Language = (ushort)AppSettingsClass.languageCode.fr;
                    msg = msg.Replace("!fr", "");
                    statusLabel2.Text = "Mode: abc fr";
                }
                if (msg.Contains("!es"))
                {
                    appSet.Language = (ushort)AppSettingsClass.languageCode.es;
                    msg = msg.Replace("!es", "");
                    statusLabel2.Text = "Mode: abc es";
                }
                if (msg.Contains("!it"))
                {
                    appSet.Language = (ushort)AppSettingsClass.languageCode.it;
                    msg = msg.Replace("!it", "");
                    statusLabel2.Text = "Mode: abc it";
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

        private void helpButton_Click(object sender, EventArgs e)
        {
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {            
            if (optionDialog == null)
                OpenOptionDialog(new Point());
            else
                CloseOptionDialog();
        }

        private void commandsButton_Click(object sender, EventArgs e)
        {
            if (commandDialog == null)
                OpenCommandDialog(new Point());
            else
                CloseCommandDialog();
        }

        private void keysButton_Click(object sender, EventArgs e)
        {
            if (danishDialog != null || frenchDialog != null || germanDialog != null || italienDialog != null || kanaDialog != null || koreanDialog != null || norwegianDialog != null || spanishDialog != null || swedishDialog != null)
                CloseKeyDialog();
            else
                OpenKeyDialog(new Point());
        }
    }
}
