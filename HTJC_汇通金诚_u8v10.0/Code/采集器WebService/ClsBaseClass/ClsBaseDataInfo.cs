using System;
using System.Collections.Generic;
using System.Text;

namespace ClsBaseClass
{
    /// <summary>
    /// 基础数据定义
    /// </summary>
    public class ClsBaseDataInfo
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        //public static string sConnString = "uid=sa;pwd=;database=UFDATA_001_2013;server=192.168.150.100";
        public static string sConnString;

        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string sDataBaseName = "";

        /// <summary>
        /// 登陆帐号
        /// </summary>
        public static string sUid = "";

        /// <summary>
        /// 第二数据库名称
        /// </summary>
        public static string sUFDataBaseName = "ufdata_001_2013";

        /// <summary>
        /// 第二数据库名称显示标题
        /// </summary>
        public static string sUFDataBaseText = "";

        /// <summary>
        /// DES密钥
        /// </summary>
        public static string sKey = "11111111";

        /// <summary>
        /// 版本
        /// </summary>
        public static string sEdition = "-1";

        /// <summary>
        /// 登陆日期
        /// </summary>
        public static string sLogDate;

        /// <summary>
        /// 窗体按纽数量
        /// </summary>
        public static int iBtnCount = 22;

        /// <summary>
        /// 公司名称
        /// </summary>
        public static string sComName = "苏州德睦信息科技有限公司";

        /// <summary>
        /// 数据库类型
        /// </summary>
        public static string sDataBaseType = "SQL Server";

        /// <summary>
        /// 程序名称
        /// </summary>
        public static string sProName;

        /// <summary>
        /// 系统注册信息
        /// </summary>
        public static string sSnInfo;

        /// <summary>
        /// 其他数据
        /// </summary>
        public static System.Collections.ArrayList arrList = new System.Collections.ArrayList();

        public static int ReturnObjectToInt(object o)
        {
            int l = 0;
            try
            {
                l = Convert.ToInt32(o);
            }
            catch
            { }
            return l;
        }

        public static long ReturnObjectToLong(object o)
        {
            long l = 0;
            try
            {
                l = Convert.ToInt64(o);
            }
            catch
            { }
            return l;
        }

        public static double ReturnObjectToDouble(object o)
        {
            double l = 0;
            try
            {
                l = Convert.ToDouble(o);
            }
            catch
            { }
            return l;
        }


        public static decimal ReturnObjectToDecimal(object o, int i)
        {
            decimal l = 0;
            try
            {
                l = Convert.ToDecimal(o);
                l = decimal.Round(l, i);
            }
            catch
            { }
            return l;
        }


        public static decimal ReturnObjectToDecimal(object o)
        {
            return ReturnObjectToDecimal(o, 6);
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

        public static string ReturnCol(decimal d)
        {
            string s = "";
            if (d == 0)
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
