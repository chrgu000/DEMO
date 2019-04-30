using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TH.BaseClass;

namespace DllForTK
{
    public class BuyerNetQty_BuyerData
    {
        string sPath;
        public BuyerNetQty_BuyerData()
        {
            Config.ConnString();

            sPath = DbHelperSQL.sLogPath + @"&BuyGating";
        }

        public void BuyerNetQty_BuyerCalculateCalculate(string sTKVersion)
        {
            if (sTKVersion == "")
                return;

            string sSQL;
            //定时任务有多个进程，需要最后一个完成才开始计算
            if (sTKVersion.StartsWith("00"))
            {
                sSQL = @"
SELECT   iID, sType, Description, iStatus, SetStartTime, dtmStart, dtmEnd, iChkTime, Remark, GatingStatus
FROM      _AutoRun with (nolock)
WHERE   (sType = 'Trialkitting') AND (iStatus <> 2)
";
                DataTable dt = DbHelperSQL.Query(sSQL);
                //定时任务必须全部成功才可以开始计算buygating
                if (dt != null && dt.Rows.Count > 1)
                {
                    return;
                }

                DbHelperSQL.ExecuteSql(sSQL);
            }

            ClsWriteLog.WriteLog(sPath, "Buygating计算-1", "计算开始 加载版本成功:" + sTKVersion);

            bool bData = false; //静态任务计算gating
            //string sTKVersion = "00-20181213";
         
            SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                //////计算开始
                StringBuilder strSqlDetailsGroup = new StringBuilder();
                strSqlDetailsGroup.Append(@"select distinct PartID from TK_Trialkit_Net_Details where sTKVersion='" + sTKVersion + "'");

                DataTable dtDetailsGroup = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSqlDetailsGroup.ToString()).Tables[0];

                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, @"create table #a(iID int,NetQty_Buyer decimal(18, 2))");

                for (int i = 0; i < dtDetailsGroup.Rows.Count; i++)
                {
                    string PartID = dtDetailsGroup.Rows[i]["PartID"].ToString();


                    ClsWriteLog.WriteLog(sPath, "Buygating计算-1", " 循环物料 :" + PartID);
                    

                    StringBuilder strSqlDetails = new StringBuilder();
                    strSqlDetails.Append(@"select * from TK_Trialkit_Net_Details  with (nolock) where sTKVersion='" + sTKVersion + "' and PartID='" + PartID + "' and isnull(NetQty,0)<>0 order by dtmPeriod");

                    DataTable dtDetails = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSqlDetails.ToString()).Tables[0];


                    //获取库存数量
                    decimal cQty = 0;
                    StringBuilder strSqlCurr = new StringBuilder();
                    strSqlCurr.Append(@"select isnull(sum(dQty),0) from TK_Trialkit_Net_Warehouse with (nolock) where sTKVersion='" + sTKVersion + "' and Child='" + PartID + "'");
                    DataTable dtCurr = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSqlCurr.ToString()).Tables[0];
                    if (double.Parse(dtCurr.Rows[0][0].ToString()) > 0)
                    {
                        cQty = decimal.Parse(dtCurr.Rows[0][0].ToString());
                    }

                    for (int j = 0; j < dtDetails.Rows.Count; j++)
                    {
                        decimal NetQty = decimal.Parse(dtDetails.Rows[j]["NetQty"].ToString());
                        string iID = dtDetails.Rows[j]["iID"].ToString();
                        if (cQty > 0)
                        {
                            if (NetQty > cQty)
                            {
                                NetQty = NetQty - cQty;
                                cQty = 0;
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, "insert into #a(iID,NetQty_Buyer) values(" + iID + "," + NetQty + ")");
                            }
                            else
                            {
                                cQty = cQty - NetQty;
                                //DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, "insert into #a(iID,NetQty_Buyer) values(" + iID + ",0)");
                            }
                        }
                        else
                        {
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, "insert into #a(iID,NetQty_Buyer) values(" + iID + "," + NetQty + ")");
                        }
                    }
                }
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, @"update TK_Trialkit_Net_Details set NetQty_Buyer =0
				where sTKVersion='" + sTKVersion + "'");

                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, @"update a set a.NetQty_Buyer = b.NetQty_Buyer
                from TK_Trialkit_Net_Details a
	            left join #a b on a.iID = b.iID
				where b.iID is not null");


                //////计算结束
                tran.Commit();

                ClsWriteLog.WriteLog(sPath, "Buygating计算-1", "计算成功:" + sTKVersion);

                if (bData)
                {
                    sSQL = @"
update _AutoRun set GatingStatus = 2 WHERE   (sType = 'Trialkitting') 
";
                    DbHelperSQL.ExecuteSql(sSQL);
                }
                else
                {
                    sSQL = @"
update TK_List set GatingStatus = 2 WHERE   (sVerTrialkitting = '{0}') 
";
                    sSQL = string.Format(sSQL, sTKVersion);
                    DbHelperSQL.ExecuteSql(sSQL);
                }
            }
            catch (Exception e)
            {
                tran.Rollback();
                
                ClsWriteLog.WriteLog(sPath, "Buygating计算-1", "计算失败:" + sTKVersion);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        protected decimal ReturnDecimal(object o, int iLength)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), iLength);
            }
            catch { }
            return d;
        }

        public DataTable GetPeriod(SqlTransaction tran)
        {
            int iYear = DateTime.Now.Year;
            int iMonth = DateTime.Now.Month;
            int iDay = DateTime.Now.Day;

            string dDate = iYear + "-";
            if (iMonth.ToString().Length == 1)
            {
                dDate = dDate + "0";
            }
            dDate = dDate + iMonth + "-";
            if (iDay.ToString().Length == 1)
            {
                dDate = dDate + "0";
            }
            dDate = dDate + iDay;

            string sSQL = "Select * From TK_Base_CalendarPeriod where convert(nvarchar(10),dtmStart,120)<='" + dDate + "' and convert(nvarchar(10),dtmEnd,120)>='" + dDate + "' ";
            DataTable dtc = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            if (dtc.Rows.Count != 1)
            {
                return null;
            }
            iYear = int.Parse(dtc.Rows[0]["iYear"].ToString());
            iMonth = int.Parse(dtc.Rows[0]["iMonth"].ToString());

            DateTime d = DateTime.Parse(iYear + "-" + iMonth + "-01");
            sSQL = @"SET LANGUAGE us_english
select *,substring(convert(varchar(11),iDay,106),4,3) as EgMonth from (
Select top 7 a.iYear, a.iMonth,a.dtmStart,a.dtmEnd,convert(datetime,convert(nvarchar,a.iYear)+'-'+convert(nvarchar(2),right('0'+convert(nvarchar,a.iMonth),2))+'-01') as iDay
, b.iWeek1, b.iWeek2, b.iWeek3, b.iWeek4, b.iWeek5 
From TK_Base_CalendarPeriod a 
left join  TK_Base_CalendarPeriod b on a.iYear=b.iYear and a.iMonth=b.iMonth
where convert(nvarchar,a.iYear)+right('0'+convert(nvarchar,a.iMonth),2)>=" + d.ToString("yyyyMM") + " order by a.iYear, a.iMonth) a  order by iYear, iMonth";
            DataTable result = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            return result;
        }
    }
}
