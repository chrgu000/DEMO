using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace BaseFunction
{
    public class BaseFunction
    {
        /// <summary>
        /// 转换数据类型为Decimal
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal ReturnDecimal(object d)
        {
            return ReturnDecimal(d, 6, 0);
        }
        /// <summary>
        /// 转换数据类型为Decimal
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal ReturnDecimal(object d, int i)
        {
            return ReturnDecimal(d, i, 0);
        }

        /// <summary>
        /// 转换数据类型为Decimal
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal ReturnDecimal(object o, int i,decimal d)
        {
            decimal d1 = d;
            try
            {
                d1 = Convert.ToDecimal(o);
                d1 = decimal.Round(d1, i);
            }
            catch
            {
            }
            return d1;
        }

        public static double ReturnDouble(object o)
        {
            return ReturnDouble(o, 0);
        }

        public static double ReturnDouble(object o,double d)
        {
            double d1 = d;
            try
            {
                d1 = Convert.ToDouble(o);
                
            }
            catch
            {
                return 0;
            }
            return d1;
        }

        public static int ReturnInt(object o)
        {
            return ReturnInt(o, 0);
        }

        public static int ReturnInt(object o,int i)
        {
            int iRet = i;
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
            return ReturnLong(o, 0);
        }

        public static long ReturnLong(object o, long i)
        {
            long iRet = i;
            try
            {
                iRet = Convert.ToInt64(o);
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

        public static bool ReturnBool(object o)
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

        public static DataTable ReturnDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) 
                return null; 

            DataTable tmp = rows[0].Table.Clone();                  // 复制DataRow的表结构      
  
            foreach (DataRow row in rows)
            {
                DataRow drtmp = tmp.NewRow();
                drtmp.ItemArray = row.ItemArray;
                tmp.Rows.Add(drtmp);                                  // 将DataRow添加到DataTable中   
            }
            
            return tmp;
        }

        public static DataTable ReturnDataTableAdd(DataTable dt1, DataTable dt2)
        {
            object[] obj = new object[dt2.Columns.Count];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                dt2.Rows[i].ItemArray.CopyTo(obj, 0);

                dt1.Rows.Add(obj);
            }

            return dt1.Copy();
        }
    }
}
