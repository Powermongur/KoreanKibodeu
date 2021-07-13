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
    public partial class OptionsForm : Form
    {
        public OptionsForm()
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

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            TopMost = appSet.StayOnTop;

            keyMenuSelectlabel.Visible = false;
            optionsMenuSelectlabel.Visible = true;
            commandMenuSelectlabel.Visible = false;

            inputLanguagelabel.Text =  InputLanguage.CurrentInputLanguage.Culture.Name + " " + InputLanguage.CurrentInputLanguage.Culture.EnglishName;
            IXILanguageLabel.Text = IXIlanString();
            conversionModeCheckBox.Checked = false;
            stayOnTopCheckBox.Checked = appSet.StayOnTop;

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].TabIndex >= 1000)
                    Controls[i].MouseDown += new System.Windows.Forms.MouseEventHandler(OptionsForm_MouseDown);
            }
        }

        private void OptionsForm_MouseDown(object sender, MouseEventArgs e)
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

        private void keysButton_Click(object sender, EventArgs e)
        {
            if (appSet.Language == (ushort)AppSettingsClass.languageCode.dk)
            {
                DanishKeysForm dkDialog = new DanishKeysForm();
                dkDialog.Show();
                dkDialog.Location = Location;
                Dispose();
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.se)
            {
                SwedishKeysForm seDialog = new SwedishKeysForm();
                seDialog.Show();
                seDialog.Location = Location;
                Dispose();
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.no)
            {
                NorwegianKeysForm noDialog = new NorwegianKeysForm();
                noDialog.Show();
                noDialog.Location = Location;
                Dispose();
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.de)
            {
                GermanKeysForm deDialog = new GermanKeysForm();
                deDialog.Show();
                deDialog.Location = Location;
                Dispose();
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.jp)
            {
                KanaKeysForm jpDialog = new KanaKeysForm();
                jpDialog.Show();
                jpDialog.Location = Location;
                Dispose();
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.kr)
            {
                KoreanKeysForm krDialog = new KoreanKeysForm();
                krDialog.Show();
                krDialog.Location = Location;
                Dispose();
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.fr)
            {
                FrenchKeysForm frDialog = new FrenchKeysForm();
                frDialog.Show();
                frDialog.Location = Location;
                Dispose();
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.es)
            {
                SpanishKeysForm esDialog = new SpanishKeysForm();
                esDialog.Show();
                esDialog.Location = Location;
                Dispose();
            }
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.it)
            {
                ItalienKeysForm itDialog = new ItalienKeysForm();
                itDialog.Show();
                itDialog.Location = Location;
                Dispose();
            }
        }

        private void commandsButton_Click(object sender, EventArgs e)
        {
            CommandsForm cmdDialog = new CommandsForm();
            cmdDialog.Show();
            cmdDialog.Location = Location;
            Dispose();
        }

        private string IXIlanString()
        {
            if (appSet.Language == (ushort)AppSettingsClass.languageCode.dk)
                return "Danish";
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.se)
                return "Swedish";
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.no)
                return "Norwegian";
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.de)
                return "German";
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.jp)
                return "Japanese";
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.kr)
                return "Korean";
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.fr)
                return "French";
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.es)
                return "Spanish";
            else if (appSet.Language == (ushort)AppSettingsClass.languageCode.it)
                return "Italien";

            return "";
        }
    }
}
