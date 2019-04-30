using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public  class ClsDataFormat
    {
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
            long iRet = -1;
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
