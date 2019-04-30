using System;
using System.Collections.Generic;
using System.Text;

namespace ClsBaseClass
{
    /// <summary>
    /// �������ݶ���
    /// </summary>
    public class ClsBaseDataInfo
    {
        /// <summary>
        /// �����ַ���
        /// </summary>
        //public static string sConnString = "uid=sa;pwd=;database=UFDATA_001_2013;server=192.168.150.100";
        public static string sConnString;

        /// <summary>
        /// ���ݿ�����
        /// </summary>
        public static string sDataBaseName = "";

        /// <summary>
        /// ��½�ʺ�
        /// </summary>
        public static string sUid = "";

        /// <summary>
        /// �ڶ����ݿ�����
        /// </summary>
        public static string sUFDataBaseName = "ufdata_001_2013";

        /// <summary>
        /// �ڶ����ݿ�������ʾ����
        /// </summary>
        public static string sUFDataBaseText = "";

        /// <summary>
        /// DES��Կ
        /// </summary>
        public static string sKey = "11111111";

        /// <summary>
        /// �汾
        /// </summary>
        public static string sEdition = "-1";

        /// <summary>
        /// ��½����
        /// </summary>
        public static string sLogDate;

        /// <summary>
        /// ���尴Ŧ����
        /// </summary>
        public static int iBtnCount = 22;

        /// <summary>
        /// ��˾����
        /// </summary>
        public static string sComName = "���ݵ�����Ϣ�Ƽ����޹�˾";

        /// <summary>
        /// ���ݿ�����
        /// </summary>
        public static string sDataBaseType = "SQL Server";

        /// <summary>
        /// ��������
        /// </summary>
        public static string sProName;

        /// <summary>
        /// ϵͳע����Ϣ
        /// </summary>
        public static string sSnInfo;

        /// <summary>
        /// ��������
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
