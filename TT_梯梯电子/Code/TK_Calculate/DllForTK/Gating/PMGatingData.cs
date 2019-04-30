using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TH.BaseClass;

namespace DllForTK
{
    public class PMGatingData
    {
        string sPath;
        public PMGatingData()
        {
            Config.ConnString();

            sPath = DbHelperSQL.sLogPath + @"&PMGating";
        }

        public void PMGatingDataCalculate(string sTKVersion)
        {
            try
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

                bool bData = false; //静态任务计算gating
                
                ClsWriteLog.WriteLog(sPath, "PMGating计算", "计算开始:" + sTKVersion);

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    //////计算开始
                    DataTable dtp = GetPeriod(tran);

                    //获得记录
                    StringBuilder strSqlgroup = new StringBuilder();
                    strSqlgroup.Append(@"
select distinct PartID  from TK_PMGating a with (nolock) where a.sTKVersion = N'" + sTKVersion + "' order by PartID ");

                    DataTable resultgroup = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSqlgroup.ToString()).Tables[0];

                    for (int i = 0; i < resultgroup.Rows.Count; i++)//result.Rows.Count
                    {
                        string iItemNO = resultgroup.Rows[i]["PartID"].ToString();


                        ClsWriteLog.WriteLog(sPath, "PMGating计算", "循环物料:" + iItemNO);


                        StringBuilder strSql = new StringBuilder();
                        strSql.Append(@"
select * from TK_PMGating a with (nolock) where a.sTKVersion = N'" + sTKVersion + "' and PartID =N'" + iItemNO + "' order by dtmPeriod ");

                        DataTable result = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSql.ToString()).Tables[0];

                        StringBuilder strSqlNet = new StringBuilder();
                        strSqlNet.Append(@"
select *,Qty as LeftQty from TK_Trialkit_Net_ForPM a with (nolock) where a.sTKVersion = N'" + sTKVersion + "' and PartID =N'" + iItemNO + "' order by dtmQty ");

                        DataTable resultqt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSqlNet.ToString()).Tables[0];

                        for (int j = 0; j < result.Rows.Count; j++)
                        {
                            string iID = result.Rows[j]["iID"].ToString();
                            DateTime dNow = DateTime.Parse(result.Rows[j]["dtmPeriod"].ToString());
                            decimal planQty = ReturnDecimal(result.Rows[j]["Qty"].ToString(), 2);
                            decimal FullkitQty = 0;
                            string NonfullkitQty = "";
                            for (int s = 0; s < resultqt.Rows.Count; s++)
                            {
                                DateTime dqt = DateTime.Parse(resultqt.Rows[s]["dtmQty"].ToString());

                                int b1 = DateTime.Compare(dNow, dqt);
                                if (b1 >= 0)
                                {
                                    decimal qtyqt = ReturnDecimal(resultqt.Rows[s]["LeftQty"].ToString(), 2);
                                    if (qtyqt > planQty)
                                    {
                                        FullkitQty = FullkitQty + planQty;
                                        NonfullkitQty = NonfullkitQty + "/" + double.Parse(planQty.ToString()) + "," + dqt.ToString("yy-MM-dd");
                                        qtyqt = qtyqt - planQty;
                                        resultqt.Rows[s]["LeftQty"] = 0;
                                    }
                                    else
                                    {
                                        FullkitQty = FullkitQty + qtyqt;
                                        NonfullkitQty = NonfullkitQty + "/" + double.Parse(qtyqt.ToString()) + "," + dqt.ToString("yy-MM-dd");
                                        qtyqt = 0;
                                        resultqt.Rows[s]["LeftQty"] = planQty - qtyqt;
                                    }
                                }
                            }
                            if (FullkitQty > 0)
                            {
                                sSQL = "update TK_PMGating set FullkitQty='" + FullkitQty + "',NonfullkitQty='" + NonfullkitQty.Substring(1, NonfullkitQty.Length - 1) + "' where iID=" + iID;
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }

                    }

                    ClsWriteLog.WriteLog(sPath, "PMGating计算", "计算成功");
                    //////计算结束
                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                ClsWriteLog.WriteLog(sPath, "PMGating计算", "计算失败：" + ee.Message);
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
