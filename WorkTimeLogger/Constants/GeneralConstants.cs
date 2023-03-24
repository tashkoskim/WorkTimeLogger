using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeLogger.Constants
{
    public static class GeneralConstants
    {
        public static string logsFolder = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\Logs\\";
        public static string templateFile = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\template.json";
        public static string bckgrImg_btnMeeting1 = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\Images\\btn_Meeting1.png";
        public static string bckgrImg_btnMeeting2 = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\Images\\btn_Meeting2.png";
        public static string bckgrImg_btnCoding1 = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\Images\\btn_Coding1.png";
        public static string bckgrImg_btnCoding2 = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\Images\\btn_Coding2.png";
        public static string bckgrImg_btnBreak1 = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\Images\\btn_Pause1.png";
        public static string bckgrImg_btnBreak2 = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\Images\\btn_Pause2.png";
    }
}
