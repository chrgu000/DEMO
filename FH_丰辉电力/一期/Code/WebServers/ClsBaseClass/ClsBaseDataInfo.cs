using System;
using System.Collections;
using System.Web.Configuration;
namespace ClsBaseClass
{
    public class ClsBaseDataInfo
    {
        public static string sConnString = WebConfigurationManager.ConnectionStrings["sConnString"].ToString();
        public static string sDataBaseName = WebConfigurationManager.ConnectionStrings["DataBaseInfo"].ToString();
        public static string sWebUpload = WebConfigurationManager.ConnectionStrings["WebUpload"].ToString();
        public static string sUid = "";
        public static string sUFDataBaseName = "";
        public static string sUFDataBaseText = "XWSystemDB_FH";
        public static string sKey = "11111111";
        public static string sEdition = "-1";
        public static string sLogDate;
        public static int iBtnCount = 22;
        public static string sComName = "苏州德睦信息科技有限公司";
        public static string sDataBaseType = "sqlserver";
        public static string sProName;
        public static string sSnInfo;
        public static string sProForm = "";
        public static ArrayList arrList = new ArrayList();
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
    }
}
