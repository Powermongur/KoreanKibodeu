﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreanKibodeu
{
    class AppSettings
    {
        public bool ShowLongNames;
        public int Language;

        public AppSettings()
        {
            ShowLongNames = (bool)Properties.Settings.Default["ShowLongNames"];
            Language = (int)Properties.Settings.Default["Language"];
        }

        public void Save()
        {
            Properties.Settings.Default["ShowLongNames"] = ShowLongNames;
            Properties.Settings.Default["Language"] = Language;
            Properties.Settings.Default.Save();
        }
    }
}
