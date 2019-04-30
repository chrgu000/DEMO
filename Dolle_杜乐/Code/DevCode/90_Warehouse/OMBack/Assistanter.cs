using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Warehouse
{
    public class Assistanter
    {
        public static string U8ConnectString
        {
            get
            {

                FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
                string conn = FrameBaseFunction.ClsBaseDataInfo.sConnString;
                string u8DB = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName;
                return conn.Replace("XWSystemDB_DL", u8DB);
            }
        }
        public static string GetFormNumber(string preFix, string tableName, string filedName, DateTime date, bool isByAddByMonth)
        {
             FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
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

            DataTable dt = clsSQLCommond.ExecQuery(sql);

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

        public static DateTime GetServerTime()
        {
             FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sql = "select getdate()";
            DataTable dt = clsSQLCommond.ExecQuery(sql);
            return DateTime.Parse(dt.Rows[0][0].ToString());

        }

        public static void GetIndentityId(string u8ConnectionString, string accId, string bussType, int count, out int parentId, out int childId)
        {
            parentId = 0;
            childId = 0;
            string sql = @"
                        declare @fatherID int
                        declare @childId int
                        exec sp_getId '','{0}','{1}',{2}, @fatherID out  , @childId out
                        select @fatherID as FatherId,@childId ChildId";
            sql = string.Format(sql, accId, bussType, count);
            DataTable dt = SqlHelper.ExecuteDataset(u8ConnectionString, CommandType.Text, sql).Tables[0];
            parentId = int.Parse(dt.Rows[0]["FatherId"].ToString());
            childId = int.Parse(dt.Rows[0]["ChildId"].ToString());
        }

        /// <summary>
        /// 获得用友单据号
        /// </summary>
        /// <param name="dbu">用友数据实体</param>
        /// <param name="cardNumber">单据代号</param>
        /// <param name="content">单据生产规则[单据日期]</param>
        /// <param name="rule">流水类型[月/日]</param>
        /// <returns></returns>
        public static string GetVouchNumber(string cardNumber, string content, string rule, string seedFormat, int serialLen)
        {

            DateTime currentDate = GetServerTime();
            string seed = currentDate.ToString(seedFormat);

            string sql = "select * from  VoucherHistory where CardNumber='{0}' and cContent='{1}' and cSeed='{2}'";
            sql = string.Format(sql, cardNumber, content, seed);
            DataTable dt = SqlHelper.ExecuteDataset(U8ConnectString, CommandType.Text, sql).Tables[0];
            string cNumber = "0";
            if (dt.Rows.Count == 0)
            {
                sql = @"insert into dbo.VoucherHistory 
                        ( CardNumber ,
                          iRdFlagSeed ,
                          cContent ,
                          cContentRule ,
                          cSeed ,
                          cNumber ,
                          bEmpty
                        )
                values  ( '{0}' , -- CardNumber - nvarchar(20)
                          null , -- iRdFlagSeed - tinyint
                          '{1}'  , -- cContent - nvarchar(50)
                          '{2}'  , -- cContentRule - nvarchar(50)
                          '{3}'  , -- cSeed - nvarchar(120)
                          '{4}'  , -- cNumber - nvarchar(30)
                           0   -- bEmpty - bit
                        )";
                sql = string.Format(sql,
                    cardNumber,
                    content,
                    rule,
                    seed,
                    "0"
                    );
                SqlHelper.ExecuteNonQuery(U8ConnectString, CommandType.Text, sql);
            }
            else
            {
                cNumber = dt.Rows[0]["cNumber"].ToString();
            }
            string serialFormat = "";
            for (int i = 0; i < serialLen - 1; i++)
            {
                serialFormat += "0";
            }
            serialFormat += "#";
            string usedNumber = seed + currentDate.ToString("dd") + (int.Parse(cNumber) + 1).ToString(serialFormat);
            sql = "Update VoucherHistory set cNumber='" + (int.Parse(cNumber) + 1).ToString() + "' where CardNumber='{0}' and cContent='{1}' and cSeed='{2}'";
            sql = string.Format(sql, cardNumber, content, seed);
            SqlHelper.ExecuteNonQuery(U8ConnectString, CommandType.Text, sql);
            return usedNumber;
        }


    }
}
