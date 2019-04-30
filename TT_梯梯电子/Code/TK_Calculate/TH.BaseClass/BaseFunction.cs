using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TH.BaseClass
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
        public static decimal ReturnDecimal(object o, int i, decimal d)
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

        public static double ReturnDouble(object o, double d)
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

        public static int ReturnInt(object o, int i)
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

            if (!b && ReturnInt(o) == 1)
            {
                b = true;
            }

            return b;
        }

        public static int ReturnBoolToInt(object o)
        {
            return ReturnBoolToInt(o, -1);
        }

        public static int ReturnBoolToInt(object o, int i)
        {
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

        public static DataTable ReturnDataRowsToTable(DataRow[] rows)
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



        public static DataTable ReturnDataRowToTable(DataRow row)
        {
            if (row == null)
                return null;

            DataTable tmp = row.Table.Clone();                  // 复制DataRow的表结构      

            DataRow drtmp = tmp.NewRow();
            drtmp.ItemArray = row.ItemArray;
            tmp.Rows.Add(drtmp);                                  // 将DataRow添加到DataTable中   

            return tmp;
        }

        /// <summary>
        /// 返回datatable中需要的值
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public static DataTable ReturnDataTableSel(DataTable dt, string sWhere)
        {
            DataRow[] dr = dt.Select(sWhere);
            return ReturnDataRowsToTable(dr);
        }
    }
}