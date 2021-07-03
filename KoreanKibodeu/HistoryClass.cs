using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreanKibodeu
{
    class HistoryClass
    {
        private List<string> msgList = new List<string>();
        private List<string> languageList = new List<string>();

        public int index = -1;

        public HistoryClass()
        {
        }

        public string msg
        {
            get { return msgList[index]; }
            set { msgList[index] = value; }
        }

        public int Count
        {
            get { return msgList.Count; }
        }

        public int language(int iCursor)
        {
            return languageList[index][iCursor];
        }

        public void AddMsg(string msg)
        {
            msgList.Add(msg);
            languageList.Add("");
        }


    }
}
