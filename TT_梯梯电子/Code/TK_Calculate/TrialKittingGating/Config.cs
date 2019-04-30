using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using TH.BaseClass;

namespace TrialKittingGating
{
    public class Config
    {
        public static void ConnString()
        {
            try
            {
                string sPathConfig = System.Windows.Forms.Application.StartupPath + @"\Config.dll";
                string ConnStr = "server=172.8.13.248;uid=sa;pwd=189.cn;database=Trialkitting";

                if (File.Exists(sPathConfig))
                {
                    string sServer = GetConfigValue(sPathConfig, "ServerInfo");
                    string sDataBase = GetConfigValue(sPathConfig, "DataBaseInfo");
                    string sUserID = GetConfigValue(sPathConfig, "SQLUID");
                    string sPasswd = GetConfigValue(sPathConfig, "SQLPWD");
                    
                    ConnStr = "pooling=true;Max Pool Size = 512;server={0};uid={1};pwd={2};database={3};timeout=0;";
                    ConnStr = string.Format(ConnStr, sServer, sUserID, sPasswd, sDataBase);

                }

                DbHelperSQL.connectionString = ConnStr;
                DbHelperSQL.iTypeThread = GetConfigValue(sPathConfig, "iTypeThread").ToString();
                DbHelperSQL.sLogPath = GetConfigValue(sPathConfig, "sLogPath").ToString();

            }
            catch (Exception ee)
            {
                throw new Exception("获得配置文件失败：" + ee.Message);
            }
        }

        /// <summary>
        /// Read confing
        /// </summary>
        /// <param name="path"></param>
        /// <param name="appKey"></param>
        /// <returns></returns>
        public static string GetConfigValue(string path, string appKey)
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(path);
                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
