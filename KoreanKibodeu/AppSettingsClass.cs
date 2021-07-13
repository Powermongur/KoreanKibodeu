using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreanKibodeu
{
    class AppSettingsClass
    {
        public bool ShowLongNames;
        public ushort Language;
        public ushort JPlanguage;
        public bool StayOnTop;
        public bool Qwertz;
        public int LocationX;
        public int LocationY;

        public enum languageCode : ushort
        { norm = 0, en = 1, dk = 2, se = 3, no = 4, de = 5, jp = 6, kr = 7, fr = 8, es = 9, it = 10 }

        public AppSettingsClass()
        {
            ShowLongNames = (bool)Properties.Settings.Default["ShowLongNames"];
            Language = (ushort)Properties.Settings.Default["Language"];
            JPlanguage = (ushort)Properties.Settings.Default["JPlanguage"];
            StayOnTop = (bool)Properties.Settings.Default["StayOnTop"];
            Qwertz = (bool)Properties.Settings.Default["Qwertz"];
            LocationX = (int)Properties.Settings.Default["LocationX"];
            LocationY = (int)Properties.Settings.Default["LocationY"];
        }

        public void Save()
        {
            Properties.Settings.Default["ShowLongNames"] = ShowLongNames;
            Properties.Settings.Default["Language"] = Language;
            Properties.Settings.Default["JPlanguage"] = JPlanguage;
            Properties.Settings.Default["StayOnTop"] = StayOnTop;
            Properties.Settings.Default["Qwertz"] = Qwertz;
            Properties.Settings.Default["LocationX"] = LocationX;
            Properties.Settings.Default["LocationY"] = LocationY;
            Properties.Settings.Default.Save();
        }
    }
}
