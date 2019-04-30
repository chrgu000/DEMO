using System;
using System.Collections;
using System.Web.Configuration;
using System.Xml;

namespace ClsBaseClass
{
    public class ClsBaseDataInfo
    {
        public static string sConnString;
        public static string sUFDataBaseName;
        public static string sDataBaseName;
        public static ArrayList arrList = new ArrayList();
        public static string sPathConfig;
        public static string sAccID;
        public static string sKey;


        
        public static bool ReturnObjectToBoolean(object o)
        {
            bool b = false;
            try
            {
                b = Convert.ToBoolean(o);
            }
            catch
            {
            }
            return b;
        }
        public static DateTime ReturnObjectToDateTime(object o)
        {
            DateTime dtm = Convert.ToDateTime("1900-01-01");
            try
            {
                dtm = Convert.ToDateTime(o);
            }
            catch
            {
            }
            return dtm;
        }
        public static int ReturnObjectToInt(object o)
        {
            int i = 0;
            try
            {
                i = Convert.ToInt32(o);
            }
            catch
            {
            }
            return i;
        }
        public static long ReturnObjectToLong(object o)
        {
            long i = 0L;
            try
            {
                i = Convert.ToInt64(o);
            }
            catch
            {
            }
            return i;
        }
        public static double ReturnObjectToDouble(object o)
        {
            double i = 0.0;
            try
            {
                i = Convert.ToDouble(o);
            }
            catch
            {
            }
            return i;
        }
        public static decimal ReturnObjectToDecimal(object o, int i)
        {
            decimal j = 0m;
            try
            {
                j = Convert.ToDecimal(o);
                j = decimal.Round(j, i);
            }
            catch
            {
            }
            return j;
        }
        public static decimal ReturnObjectToDecimal(object o)
        {
            return ClsBaseDataInfo.ReturnObjectToDecimal(o, 6);
        }
        public static string ReturnCol(string s)
        {
            if (s.Trim() == "")
            {
                s = "null";
            }
            else
            {
                s = "'" + s + "'";
            }
            return s;
        }
        public static string ReturnCol(object o)
        {
            return ClsBaseDataInfo.ReturnCol(o.ToString());
        }
        public static string ReturnCol(decimal d)
        {
            string s;
            if (d == 0m)
            {
                s = "null";
            }
            else
            {
                s = d.ToString().Trim();
            }
            return s;
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
