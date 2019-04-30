using System;
using System.Collections.Generic;
using System.Text;

namespace FrameBaseFunction
{
    /// <summary>
    /// 基础数据定义
    /// </summary>
    public class ClsBaseDataInfo
    {
        /// <summary>
        /// 税率
        /// </summary>
        public static int iTaxRate_All_QJ = 13;
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string sConnString = "";

        /// <summary>
        /// 连接字符串2
        /// </summary>
        public static string sConnString2 = "";

        /// <summary>
        /// 窗体所属项目
        /// </summary>
        public static string sProForm = "";

        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string sDataBaseName = "";

        /// <summary>
        /// 登陆帐号
        /// </summary>
        public static string sUid = "";

        /// <summary>
        /// 登陆帐号归属部门
        /// </summary>
        public static string sDepCode = "";

        /// <summary>
        /// 登陆用户姓名
        /// </summary>
        public static string sUserName = "";

        /// <summary>
        /// 第二数据库名称
        /// </summary>
        public static string sUFDataBaseName = "";

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
        //public static DateTime dLogDate;
        /// <summary>
        /// 窗体按纽数量
        /// </summary>
        public static int iBtnCount = 22;

        /// <summary>
        /// 公司名称
        /// </summary>
        public static string sComName = "杰通科技";

        /// <summary>
        /// 数据库类型
        /// </summary>
        public static string sDataBaseType = "webservice";
        
        /// <summary>
        /// 程序名称
        /// </summary>
        public static string sProName;

        /// <summary>
        /// 系统注册信息
        /// </summary>
        public static string sSnInfo;

        public static string sWebURL;
        
        /// <summary>
        /// 其他数据
        /// </summary>
        public static System.Collections.ArrayList arrList = new System.Collections.ArrayList();


        /// <summary>
        /// 转换数据类型为Decimal
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal ReturnDecimal(object d)
        {
            try
            {
                decimal d1 = Convert.ToDecimal(d);
                return decimal.Round(d1, 6);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 转换数据类型为Decimal
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal ReturnDecimal(object d, int i)
        {
            try
            {
                decimal d1 = Convert.ToDecimal(d);
                if (i == -1)
                    return d1;
                else
                    return decimal.Round(d1, i);
            }
            catch
            {
                return 0;
            }
        }

        public static double ReturnDouble(object d)
        {
            try
            {
                double d1 = Convert.ToDouble(d);
                return d1;
            }
            catch
            {
                return 0;
            }
        }

        public static int ReturnInt(object o)
        {
            int iRet = -1;
            try
            {
                iRet = Convert.ToInt32(o);
            }
            catch
            {

            }
            return iRet;
        }

        public static long ReturnLong(object o)
        {
            long iRet = 0;
            try
            {
                iRet = Convert.ToInt32(o);
            }
            catch
            {

            }
            return iRet;
        }

        public static DateTime ReturnDate(object o)
        {
            DateTime d = Convert.ToDateTime("1900-01-01");
            try
            {
                d = Convert.ToDateTime(o);
            }
            catch
            {

            }
            return d;
        }

        public static int ReturnBoolToInt(object o)
        {
            int i = -1;
            try
            {
                bool b = Convert.ToBoolean(o);
                if (b)
                    i = 1;
                else
                    i = 0;
            }
            catch
            {

            }
            return i;
        }
    }
}
