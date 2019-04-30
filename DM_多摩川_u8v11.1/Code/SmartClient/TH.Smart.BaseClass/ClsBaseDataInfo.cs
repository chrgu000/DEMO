using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TH.Smart.BaseClass
{
    /// <summary>
    /// 基础数据定义
    /// </summary>
    public class ClsBaseDataInfo
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string sConnString = "";

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
        public static string sUFDataBaseName = "UFDATA_001_2013";

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

        public static string sPrintName;

        /// <summary>
        /// Web地址
        /// </summary>
        public static string sWebPath;

        ///// <summary>
        ///// 其他数据
        ///// </summary>
        //public static System.Collections.ArrayList arrList = new System.Collections.ArrayList();

        //public static int ReturnInt(object o)
        //{
        //    int l = 0;
        //    try
        //    {
        //        l = Convert.ToInt32(o);
        //    }
        //    catch
        //    { }
        //    return l;
        //}

        //public static long ReturnLong(object o)
        //{
        //    long l = 0;
        //    try
        //    {
        //        l = Convert.ToInt64(o);
        //    }
        //    catch
        //    { }
        //    return l;
        //}

        //public static bool ReturnBool(object o)
        //{
        //    bool b = false;
        //    try
        //    {
        //        b = Convert.ToBoolean(o);
        //        if (b)
        //            return b;
        //    }
        //    catch
        //    { }

        //    try
        //    {
        //        int i = Convert.ToInt32(o);
        //        if (i == 1)
        //        {
        //            b = true;
        //            return b;
        //        }
        //    }
        //    catch
        //    { }

        //    try
        //    {
        //        string s = o.ToString().Trim().ToLower();
        //        if (s == "true")
        //        {
        //            b = true;
        //            return b;
        //        }
        //    }
        //    catch
        //    { }
        //    return b;
        //}

        //public static double ReturnDouble(object o)
        //{
        //    double l = 0;
        //    try
        //    {
        //        l = Convert.ToDouble(o);
        //    }
        //    catch
        //    { }
        //    return l;
        //}


        //public static decimal ReturnDecimal(object o)
        //{
        //    return ReturnDecimal(o, 6);
        //}


        //public static decimal ReturnDecimal(object o, int i)
        //{
        //    decimal l = 0;
        //    try
        //    {
        //        l = Convert.ToDecimal(o);
        //        l = decimal.Round(l, i);
        //    }
        //    catch
        //    { }
        //    return l;
        //}

        //public static DateTime ReturnDatetime(object o)
        //{
        //    DateTime l = Convert.ToDateTime("1900-1-1");
        //    try
        //    {
        //        l = Convert.ToDateTime(o);
        //    }
        //    catch
        //    { }
        //    return l;
        //}

        //public static decimal ReturnDatatableColSUM(DataTable dt, string sColName, string sColValue)
        //{
        //    decimal d = 0;
        //    DataRow[] dr = dt.Select("sColName = '" + sColValue + "'");
        //    DataView dv = dt.DefaultView;
        //    dv.RowFilter = sColName + " '" + sColValue + "'";
        //    DataTable dtTemp = dv.Table;
        //    d = ReturnDecimal(dtTemp.Compute("sum(" + sColName + ")", ""), 6);
        //    return d;
        //}
    }
}
