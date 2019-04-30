using System;
using System.Collections.Generic;
using System.Text;

namespace MobileBaseDLL
{
    /// <summary>
    /// 基础数据定义
    /// </summary>
    public class BaseDllMobile
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string sConnString = "http://192.168.1.2:18000/DBService.asmx";

        /// <summary>
        /// 路径
        /// </summary>
        public static string sWebPath = "";

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

        /// <summary>
        /// 其他数据
        /// </summary>
        public static System.Collections.ArrayList arrList = new System.Collections.ArrayList();
    }
}
