using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.Business
{
    public class Utils
    {
        public static string GetFormNumber(string preFix, string tableName, string filedName, DateTime date, bool isByAddByMonth,string conn)
        {
            string result = "";
            string datePre = date.ToString("yyyyMMdd");
            string dateSearch = "";
            if (isByAddByMonth)
            {
                dateSearch = date.ToString("yyyyMM");
            }
            else
            {
                dateSearch = date.ToString("yyyyMMdd");
            }

            string sql = string.Format("select max({0}) as MaxNum from {1}  with (nolock) where {2} like '" + preFix + "{3}%'",
                filedName, tableName, filedName, dateSearch);

            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["MaxNum"].ToString();
                if (result == "")
                    result = preFix + datePre + "001";
                else
                {

                    int currentNumber = int.Parse(result.Substring(11, 3)) + 1;

                    result = preFix + datePre + string.Format("{0:000}", currentNumber);
                }
            }
            return result;
        }

        public static string GetFormNumber2(string preFix, string tableName, string filedName, DateTime date, bool isByAddByMonth, string conn)
        {
            string result = "";
            string datePre = date.ToString("yyMMdd");
            string dateSearch = "";
            if (isByAddByMonth)
            {
                dateSearch = date.ToString("yyMM");
            }
            else
            {
                dateSearch = date.ToString("yyMMdd");
            }

            string sql = string.Format("select max({0}) as MaxNum from {1}  with (nolock) where {2} like '" + preFix + "{3}%'",
                filedName, tableName, filedName, dateSearch);

            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["MaxNum"].ToString();
                if (result == "")
                    result = preFix + datePre + "000001";
                else
                {

                    int currentNumber = int.Parse(result.Substring(6,6)) + 1;

                    result = preFix + datePre + string.Format("{0:000000}", currentNumber);
                }
            }
            return result;
        }

        public static DateTime GetServerTime(string conn)
        {
            string sql = "select getdate() as ServerDate";

            DataTable dt = SqlHelper.ExecuteDataset(conn , CommandType.Text, sql).Tables[0];
            DateTime dtime = DateTime.Parse(dt.Rows[0]["ServerDate"].ToString());
            return dtime;

        }
    }
}
