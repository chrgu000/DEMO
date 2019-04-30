using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TH.BaseClass;

namespace TrialKittingGating
{
    public class BuyerGatingData
    {
        string sPath;
        public BuyerGatingData()
        {
            Config.ConnString();
            
            sPath = DbHelperSQL.sLogPath + @"&Buygating";
        }
        
        public void BuyGatingCalculate()
        {
            ClsWriteLog.WriteLog(sPath, "Buygating计算", "计算开始" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            bool bData = false; //静态任务计算gating
            string sTKVersion = "";

            string sSQL = @"
SELECT   iID, sType, Description, iStatus, SetStartTime, dtmStart, dtmEnd, iChkTime, Remark, GatingStatus
FROM      _AutoRun with (nolock)
WHERE   (sType = 'Trialkitting') AND (iStatus <> 2)
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            //定时任务必须全部成功才可以开始计算buygating
            if (dt != null && dt.Rows.Count > 0)
            {
                return;
            }

            sSQL = @"
SELECT   iID, sType, Description, iStatus, SetStartTime, dtmStart, dtmEnd, iChkTime, Remark, GatingStatus
FROM      _AutoRun with (nolock)
WHERE   (sType = 'Trialkitting') AND (iStatus = 2) and (GatingStatus = 0)
";
            dt = DbHelperSQL.Query(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                sSQL = @"
select distinct sTKVersion from [dbo].[TK_Trialkitting_Result] with (nolock) where sDataVersion in (select distinct sVersion from [dbo].[TK_NetRequirement] with (nolock))
";
                dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    sTKVersion = dt.Rows[0]["sTKVersion"].ToString().Trim();

                    sSQL = @"
update _AutoRun set GatingStatus = 1 WHERE   (sType = 'Trialkitting') 
";
                    DbHelperSQL.ExecuteSql(sSQL);

                    bData = true;
                }
            }

            if (!bData)
            {
                sSQL = @"
select count(1) as iCou from[dbo].[_AutoRun] where sType = 'Trialkitting' and isnull(iStatus, 0) <> 1
";
                dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获取进程数设置失败");
                }
                int iThread = BaseFunction.ReturnInt(dt.Rows[0][0]);        //总进程数

                sSQL = @"
SELECT   COUNT(1) AS iCou
FROM      TK_List
WHERE   (ISNULL(GatingStatus, 0) = 1)
";
                dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获取正在执行的进程数失败");
                }
                int iThreadSum = BaseFunction.ReturnInt(dt.Rows[0][0]);        //当前总进程数
                if (iThreadSum >= iThread)
                {
                    throw new Exception("当前进程已满，暂停执行");
                }

                //每次只启动一件任务
                sSQL = @"
SELECT top 1  sVerTrialkitting
FROM      TK_List WITH (nolock)
WHERE sType = 'Trialkitting'  and (ISNULL(GatingStatus, 0) = 0)
ORDER BY iID
";
                dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }

                sTKVersion = dt.Rows[0]["sVerTrialkitting"].ToString().Trim();

                ClsWriteLog.WriteLog(sPath, "Buygating计算", "计算开始 加载版本成功:" + sTKVersion);

                sSQL = @"
update TK_List set GatingStatus = 1 WHERE   (sVerTrialkitting = '{0}') 
";
                sSQL = string.Format(sSQL, sTKVersion);
                DbHelperSQL.ExecuteSql(sSQL);
            }

            if (sTKVersion == "")
                return;

            SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                ClsWriteLog.WriteLog(sPath, "Buygating计算", "清除历史版本");

                sSQL = "delete from TK_BuyerGating where sTKVersion='" + sTKVersion + "'";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                //////计算开始
                DataTable dtp = GetPeriod(tran);

                string sWhere = "";
                if (sTKVersion != "")
                {
                    sWhere = sWhere + " and a.sTKVersion = N'" + sTKVersion + "'";
                }
                //设置每月几号之前不算keep pullin
                int beforeDay = 10;
                //获得记录
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"

if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#a'))
	drop table #a
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#b'))
	drop table #b

select ProdGroup,Planner,iItemNO,dtmQty,Qty
into #a 
from _Get_TK_Buying a with (nolock) 
where 1=1 

SELECT  iItemNO ,dtmQty,Qty,
        ProdGroup = ( STUFF(( SELECT   distinct ',' + ProdGroup
                          FROM      #a
                          WHERE     iItemNO = Test.iItemNO
                        FOR
                          XML PATH('')
                        ), 1, 1, '') ),
		Planner = ( STUFF(( SELECT   distinct ',' + Planner
                          FROM      #a
                          WHERE     iItemNO = Test.iItemNO
                        FOR
                          XML PATH('')
                        ), 1, 1, '') )
into #b 
FROM    #a AS Test
GROUP BY iItemNO,dtmQty,Qty

select iItemNO,ProdGroup,Planner,mpn as MPN, manuf as MFR,vc as Vendor");
                for (int i = 0; i < dtp.Rows.Count; i++)
                {
                    strSql.Append(@"
,convert(nvarchar(50),sum(case when convert(nvarchar(10),dtmQty,120) between '" + DateTime.Parse(dtp.Rows[i]["dtmStart"].ToString()).ToString("yyyy-MM-dd")
                        + "' and '" + DateTime.Parse(dtp.Rows[i]["dtmEnd"].ToString()).ToString("yyyy-MM-dd") + "' then Qty end)) as Month" + (i + 1) + " ");
                }
                strSql.Append(@"
from #b a left join TK_BOM b with (nolock) on a.iItemNO=b.parent 
left join _GET_TK_AVL_INFO c on a.iItemNO=c.child 
left join _Get_TK_Material_Combine_String d on a.iItemNO=d.partnum
group by iItemNO,ProdGroup,Planner,mpn,manuf,vc having ");

                for (int i = 0; i < dtp.Rows.Count; i++)
                {
                    if (i > 0)
                    {
                        strSql.Append(@" 
or ");
                    }
                    strSql.Append("sum(case when convert(nvarchar(10),dtmQty,120) between '" + DateTime.Parse(dtp.Rows[i]["dtmStart"].ToString()).ToString("yyyy-MM-dd")
                        + "' and '" + DateTime.Parse(dtp.Rows[i]["dtmEnd"].ToString()).ToString("yyyy-MM-dd") + "' then Qty end) >0 ");
                }
                if (!string.IsNullOrEmpty(sWhere))
                    strSql.Replace("1=1", "1=1" + sWhere + " ");//and ProdGroup='ELPSU'


                DataTable result = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSql.ToString()).Tables[0];

                for (int i = 0; i < result.Rows.Count; i++)//result.Rows.Count
                {
                    ClsWriteLog.WriteLog(sPath, "Buygating计算", "循环物料" + result.Rows[i]["iItemNO"].ToString());
                string iItemNO = result.Rows[i]["iItemNO"].ToString();

                    string sProductGroup = result.Rows[i]["ProdGroup"].ToString();
                    string Planner = result.Rows[i]["Planner"].ToString();

                    string Vendor = result.Rows[i]["Vendor"].ToString();
                    string MPN = result.Rows[i]["MPN"].ToString();
                    string MFR = result.Rows[i]["MFR"].ToString();

                    //获取PO
                    StringBuilder strSqlPO = new StringBuilder();
                    strSqlPO.AppendFormat(@"select case when dtmRequirement is null then dtmDuedate else dtmRequirement end as dtmQty,sPONo,fOpenQTY,fOpenQTY as leftQty from TK_PO with (nolock) where iItemNO='" + iItemNO + "' and sPONo <> 'VPO' order by dtmDuedate");
                    DataTable dtPO = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSqlPO.ToString()).Tables[0];

                    //获取数量
                    StringBuilder strSqlResult = new StringBuilder();
                    strSqlResult.AppendFormat(@"select Qty,dtmQty from _Get_TK_Buying where sTKVersion = '" + sTKVersion + "' and iItemNO='" + iItemNO + "'");
                    //strSqlResult.AppendFormat(@"select cInvCode,dtmQty,Qty from TK_Trialkitting_Results with (nolock) where cInvCode='" + iItemNO + "' and sTKVersion = '" + sTKVersion + "' ");
                    DataTable dtResultPlan = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSqlResult.ToString()).Tables[0];

                    //获取开启的PO数量
                    decimal fOpenQTY = 0;
                    StringBuilder strSqlPOSum = new StringBuilder();
                    strSqlPOSum.Append(@"select isnull(sum(fOpenQTY),0) from TK_PO with (nolock) where iItemNO='" + iItemNO + "' and sPONo <> 'VPO'");
                    DataTable dtPOSum = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSqlPOSum.ToString()).Tables[0];
                    if (double.Parse(dtPOSum.Rows[0][0].ToString()) > 0)
                    {
                        fOpenQTY = decimal.Parse(dtPOSum.Rows[0][0].ToString());
                    }

                    //获取库存数量
                    decimal currQTY = 0;
                    StringBuilder strSqlCurr = new StringBuilder();
                    strSqlCurr.Append(@"select isnull(sum(dQty),0) from TK_CurrentStock with (nolock) where sItemNo='" + iItemNO + "'");
                    DataTable dtCurr = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSqlPOSum.ToString()).Tables[0];
                    if (double.Parse(dtCurr.Rows[0][0].ToString()) > 0)
                    {
                        currQTY = decimal.Parse(dtCurr.Rows[0][0].ToString());
                    }

                    for (int q = 0; q < dtp.Rows.Count; q++)
                    {
                        string sBuyer = "";
                        string dtmDuedate = "";
                        string Gating = "";
                        string sPONo = "";
                        string Remark = "";
                        string Action = "";
                        bool isdelay = false;

                        if (result.Rows[i]["Month" + (q + 1)].ToString() != "")
                        {
                            decimal planQtySum = ReturnDecimal(result.Rows[i]["Month" + (q + 1)].ToString(), 2);
                            ////前三个月
                            //if (q <= 2)
                            //{
                            #region 前三个月
                            for (int r = 1; r <= 5; r++)
                            {
                                if (dtp.Rows[q]["iWeek" + r] != null && dtp.Rows[q]["iWeek" + r].ToString() != "")
                                {
                                    //本周 
                                    string sd = DateTime.Parse(dtp.Rows[q]["iWeek" + r].ToString()).ToString("yyyy-MM-dd");
                                    string ed = DateTime.Parse(dtp.Rows[q]["iWeek" + r].ToString()).AddDays(7).ToString("yyyy-MM-dd");
                                    //获取计划
                                    object objweek = dtResultPlan.Compute("sum(Qty)", "dtmQty>='" + sd + "' and dtmQty<='" + ed + "'");
                                    decimal qtyweek = 0;
                                    if (objweek.ToString() != "")
                                    {
                                        qtyweek = ReturnDecimal(objweek.ToString(), 2);
                                    }

                                    if (qtyweek == 0)
                                    {
                                        continue;
                                    }

                                    if (currQTY > 0)
                                    {
                                        if (qtyweek > currQTY)
                                        {
                                            qtyweek = qtyweek - currQTY;
                                            currQTY = 0;
                                        }
                                        else
                                        {
                                            currQTY = currQTY - qtyweek;
                                            qtyweek = 0;
                                        }
                                    }
                                    //判断是否在采购订单中
                                    for (int s = 0; s < dtPO.Rows.Count; s++)
                                    {
                                        decimal planQty = ReturnDecimal(dtPO.Rows[s]["LeftQty"].ToString(), 2);
                                        if (planQty == 0)
                                        {
                                            continue;
                                        }
                                        //有采购数量
                                        string dtmNow = dtPO.Rows[s]["dtmQty"].ToString();
                                        int b1 = DateTime.Compare(DateTime.Parse(dtmNow), DateTime.Parse(ed));
                                        if (b1 > 0 && DateTime.Parse(dtmNow).Day <= beforeDay)
                                        {
                                            isdelay = true;
                                            Gating = "Y";
                                            Action = "keep pullin";
                                        }
                                        if (qtyweek > planQty)
                                        {
                                            qtyweek = qtyweek - planQty;
                                            dtPO.Rows[s]["LeftQty"] = 0;
                                        }
                                        else
                                        {
                                            qtyweek = 0;
                                            dtPO.Rows[s]["LeftQty"] = planQty - qtyweek;
                                        }

                                        string dtmDuedatetemp = DateTime.Parse(dtPO.Rows[s]["dtmQty"].ToString()).ToString("yyyy-MM-dd");
                                        if (dtmDuedate.IndexOf(dtmDuedatetemp) < 0)
                                        {
                                            if (dtmDuedate != "")
                                            {
                                                dtmDuedate = dtmDuedate + ",";
                                            }
                                            dtmDuedate = dtmDuedate + dtmDuedatetemp;
                                        }

                                        string sPONotemp = dtPO.Rows[s]["sPONo"].ToString();
                                        if (sPONo.IndexOf(sPONotemp) < 0)
                                        {
                                            if (sPONo != "")
                                            {
                                                sPONo = sPONo + ",";
                                            }
                                            sPONo = sPONo + sPONotemp;
                                        }
                                    }

                                }
                            }
                            #endregion
                            if (isdelay == true)
                            {
                                result.Rows[i]["Month" + (q + 1)] = "(" + planQtySum + ")";//缺料
                            }
                            else
                            {
                                result.Rows[i]["Month" + (q + 1)] = planQtySum;
                            }



                            Model.TK_BuyerGatingEntity model = new Model.TK_BuyerGatingEntity();
                            model.sTKVersion = sTKVersion;
                            if ((q + 1) == 1)
                            {
                                model.Period01 = result.Rows[i]["Month" + (q + 1)].ToString();
                            }
                            else if ((q + 1) == 2)
                            {
                                model.Period02 = result.Rows[i]["Month" + (q + 1)].ToString();
                            }
                            else if ((q + 1) == 3)
                            {
                                model.Period03 = result.Rows[i]["Month" + (q + 1)].ToString();
                            }
                            else if ((q + 1) == 4)
                            {
                                model.Period04 = result.Rows[i]["Month" + (q + 1)].ToString();
                            }
                            else if ((q + 1) == 5)
                            {
                                model.Period05 = result.Rows[i]["Month" + (q + 1)].ToString();
                            }
                            else if ((q + 1) == 6)
                            {
                                model.Period06 = result.Rows[i]["Month" + (q + 1)].ToString();
                            }
                            else if ((q + 1) == 7)
                            {
                                model.Period07 = result.Rows[i]["Month" + (q + 1)].ToString();
                            }
                            model.sProductGroup = sProductGroup;
                            model.sBuyer = sBuyer;
                            model.iItemNO = iItemNO;
                            model.dtmDuedate = dtmDuedate;
                            model.dockDate = dtmDuedate;
                            model.Gating = Gating;
                            model.sPONo = sPONo;
                            model.Action = Action;
                            model.CreateUid = "";
                            model.dtmCreate = DateTime.Now;
                            model.fOpenQTY = fOpenQTY.ToString();

                            //model.Vendor = Vendor;
                            //model.MFR = MFR;
                            //model.MPN = MPN;
                            model.Vendor = Vendor.Replace("'", "''");
                            model.MFR = MFR.Replace("'", "''");
                            model.MPN = MPN.Replace("'", "''");


                            DAL.TK_BuyerGatingData dal = new DAL.TK_BuyerGatingData();
                            sSQL = dal.Add(model);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                }

                //////计算结束
                tran.Commit();

                ClsWriteLog.WriteLog(sPath, "Buygating计算", "计算成功" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

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

                ClsWriteLog.WriteLog(sPath, "Buygating计算", "计算失败：" + e.Message);

                if (bData)
                {
                    sSQL = @"
update _AutoRun set GatingStatus = 3 WHERE   (sType = 'Trialkitting') 
";
                    DbHelperSQL.ExecuteSql(sSQL);
                }
                else
                {
                    sSQL = @"
update TK_List set GatingStatus = 3 WHERE   (sVerTrialkitting = '{0}') 
";
                    sSQL = string.Format(sSQL, sTKVersion);
                    DbHelperSQL.ExecuteSql(sSQL);
                }

                // throw new Exception(e.Message);

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
