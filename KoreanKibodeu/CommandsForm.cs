﻿using System;
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
    public partial class CommandsForm : Form
    {
        public CommandsForm()
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

        private void CommandsForm_Load(object sender, EventArgs e)
        {
            mainDialog = (MainForm)Owner;
            TopMost = appSet.StayOnTop;

            keyMenuSelectlabel.Visible = false;
            optionsMenuSelectlabel.Visible = false;
            commandMenuSelectlabel.Visible = true;

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].TabIndex >= 1000)
                    Controls[i].MouseDown += new System.Windows.Forms.MouseEventHandler(CommandsForm_MouseDown);
            }
        }

        private void CommandsForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            mainDialog.CloseCommandDialog();
        }

        private void keysButton_Click(object sender, EventArgs e)
        {
            mainDialog.OpenKeyDialog(Location);
            mainDialog.CloseCommandDialog();
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            mainDialog.OpenOptionDialog(Location);
            mainDialog.CloseCommandDialog();
        }
    }
}
