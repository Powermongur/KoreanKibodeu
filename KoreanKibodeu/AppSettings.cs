using System;
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
        public int JPlanguage;
        public bool StayOnTop;
        public bool Qwertz;

        public AppSettings()
        {
            ShowLongNames = (bool)Properties.Settings.Default["ShowLongNames"];
            Language = (int)Properties.Settings.Default["Language"];
            JPlanguage = (int)Properties.Settings.Default["JPlanguage"];
            StayOnTop = (bool)Properties.Settings.Default["StayOnTop"];
            Qwertz = (bool)Properties.Settings.Default["Qwertz"];
        }

        public void Save()
        {
            Properties.Settings.Default["ShowLongNames"] = ShowLongNames;
            Properties.Settings.Default["Language"] = Language;
            Properties.Settings.Default["JPlanguage"] = JPlanguage;
            Properties.Settings.Default["StayOnTop"] = StayOnTop;
            Properties.Settings.Default["Qwertz"] = Qwertz;
            Properties.Settings.Default.Save();
        }
    }
}
