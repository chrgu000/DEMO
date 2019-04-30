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
        /// 连接字符串
        /// </summary>
        public static string sConnString = "";

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
    }
}
