using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TH.BaseClass
{
    public class ClsWriteLog
    {
        static public void WriteLog(string sPath, string sType, string sLog,int iType)
        {
            try
            {
                string[] s = sPath.Split('&');
                if (!Directory.Exists(s[0]))
                {
                    Directory.CreateDirectory(s[0]);
                }

                string sFilePath = sPath + @"\" +"00" + iType.ToString().Trim() +"-"+ DateTime.Now.ToString("yyyyMMdd") + ".log";
                if (s.Length == 2)
                {
                    sFilePath = s[0] + @"\" + s[1] + ".log";
                }


                StringBuilder sLogInfo = new StringBuilder();
                sLogInfo.Append("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]  " + sType + "：");
                sLogInfo.Append("\t" + sLog + "\r\n");

                StreamWriter log = new StreamWriter(sFilePath, true);
                log.WriteLine(sLogInfo.ToString().Trim());
                log.Close();

            }
            catch (Exception ee)
            { }
        }
        static public void WriteLog(string sPath, string sType, string sLog)
        {
            try
            {
                string[] s = sPath.Split('&');
                if (!Directory.Exists(s[0]))
                {
                    Directory.CreateDirectory(s[0]);
                }

                string sFilePath = sPath + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                if (s.Length == 2)
                {
                    sFilePath = s[0] + @"\" + DateTime.Now.ToString("yyyyMMdd") + "_" + s[1] + ".log";
                }


                StringBuilder sLogInfo = new StringBuilder();
                sLogInfo.Append("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]  " + sType + "：");
                sLogInfo.Append("\t" + sLog + "\r\n");

                StreamWriter log = new StreamWriter(sFilePath, true);
                log.WriteLine(sLogInfo.ToString().Trim());
                log.Close();

            }
            catch (Exception ee)
            { }
        }
    }
}
