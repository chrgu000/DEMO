using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TH.BaseClass;

namespace DllForTK
{
    public class BuyerGatingData
    {
        string sPath;
        public BuyerGatingData()
        {
            Config.ConnString();
            
            sPath = DbHelperSQL.sLogPath + @"&BuyGating";
        }
        
        public void BuyGatingCalculate(string sTKVersion)
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

            string sTableName = "#TK_BuyerGating" + DateTime.Now.ToString("yyMMddHHmmss");

            ClsWriteLog.WriteLog(sPath, "Buygating计算-2", "计算开始:" + sTKVersion);

            SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                //////计算开始
                DataTable dtp = GetPeriod(tran, sTKVersion);

                //设置每月几号之前不算keep pullin
                int beforeDay = 10;

                //获得记录
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"
                    if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#a')) drop table #a
                    if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#b')) drop table #b
                    
                    select ProdGroup,iItemNO,dtmQty,Qty
                    into #a from _Get_TK_Buying a with (nolock) 
                    where 1=1 
                    
                    SELECT  iItemNO ,dtmQty,Qty,
                            ProdGroup = ( STUFF(( SELECT   distinct ',' + ProdGroup
                                              FROM      #a
                                              WHERE     iItemNO = Test.iItemNO
                                            FOR
                                              XML PATH('')
                                            ), 1, 1, '') )
                    into #b 
                    FROM    #a AS Test
                    GROUP BY iItemNO,dtmQty,Qty
                    
                    select iItemNO,ProdGroup,mpn as MPN, manuf as MFR,vc as Vendor");
                for (int i = 0; i < dtp.Rows.Count; i++)
                {
                    strSql.Append(@"
                    ,convert(nvarchar(50),sum(case when convert(nvarchar(10),dtmQty,120) between '" + DateTime.Parse(dtp.Rows[i]["dtmStart"].ToString()).ToString("yyyy-MM-dd")
                        + "' and '" + DateTime.Parse(dtp.Rows[i]["dtmEnd"].ToString()).ToString("yyyy-MM-dd") + "' then Qty end)) as Month" + (i + 1) + " ");
                }
                strSql.Append(@"
                    from #b a  
                    left join _GET_TK_AVL_INFO c on a.iItemNO=c.child 
                    left join _Get_TK_Material_Combine_String d on a.iItemNO=d.partnum
                    group by iItemNO,ProdGroup,mpn,manuf,vc having ");

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
                if (sTKVersion != "")
                {
                    strSql.Replace("1=1", "1=1" + " and a.sTKVersion = N'" + sTKVersion + "'");//and ProdGroup='ELPSU'
                }


                DataTable result = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, strSql.ToString()).Tables[0];

                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, @"select sTKVersion, Period01, Period02, Period03, Period04, Period05, Period06, Period07, sProductGroup, 
                sBuyer, iItemNO, dtmDuedate, dockDate, Gating, sPONo, fOpenQTY, Vendor, MPN, MFR, Remark, Action, CreateUid, 
                dtmCreate into #temp FROM      TK_BuyerGating where 1=-1");

                for (int i = 0; i < result.Rows.Count; i++)//result.Rows.Count
                {
                    string iItemNO = result.Rows[i]["iItemNO"].ToString();

                    ClsWriteLog.WriteLog(sPath, "Buygating计算-2", "循环物料:" + iItemNO);


                    string sProductGroup = result.Rows[i]["ProdGroup"].ToString();
                    string Planner = "";

                    string Vendor = result.Rows[i]["Vendor"].ToString();
                    string MPN = result.Rows[i]["MPN"].ToString();
                    string MFR = result.Rows[i]["MFR"].ToString();

                    //获取PO
                    StringBuilder strSqlPO = new StringBuilder();
                    strSqlPO.AppendFormat(@"select sBuyer,case when dtmRequirement is null then dtmDuedate else dtmRequirement end as dtmQty,sPONo,fOpenQTY,fOpenQTY as leftQty from TK_PO with (nolock) 
                                        where iItemNO='" + iItemNO + "' and sPONo <> 'VPO' order by dtmDuedate");
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
      
                            #region 
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

                                        string sBuyertemp = dtPO.Rows[s]["sBuyer"].ToString();
                                        if (sBuyer.IndexOf(sBuyertemp) < 0)
                                        {
                                            if (sBuyer != "")
                                            {
                                                sBuyer = sBuyer + ",";
                                            }
                                            sBuyer = sBuyer + sBuyertemp;
                                        }
                                    }
                                   
                                }
                            }
                            #endregion
                            if (isdelay == true)
                            {
                                result.Rows[i]["Month" + (q + 1)] = -1 * planQtySum;//缺料
                            }
                            else
                            {
                                result.Rows[i]["Month" + (q + 1)] = planQtySum;
                            }

                            Model.TK_BuyerGating model = new Model.TK_BuyerGating();
                            model.sTKVersion = sTKVersion;
                            if ((q + 1) == 1)
                            {
                                model.Period01 = BaseFunction.ReturnDecimal(result.Rows[i]["Month" + (q + 1)], 2);
                            }
                            else if ((q + 1) == 2)
                            {
                                model.Period02 = BaseFunction.ReturnDecimal(result.Rows[i]["Month" + (q + 1)], 2);
                            }
                            else if ((q + 1) == 3)
                            {
                                model.Period03 = BaseFunction.ReturnDecimal(result.Rows[i]["Month" + (q + 1)], 2);
                            }
                            else if ((q + 1) == 4)
                            {
                                model.Period04 = BaseFunction.ReturnDecimal(result.Rows[i]["Month" + (q + 1)], 2);
                            }
                            else if ((q + 1) == 5)
                            {
                                model.Period05 = BaseFunction.ReturnDecimal(result.Rows[i]["Month" + (q + 1)], 2);
                            }
                            else if ((q + 1) == 6)
                            {
                                model.Period06 = BaseFunction.ReturnDecimal(result.Rows[i]["Month" + (q + 1)], 2);
                            }
                            else if ((q + 1) == 7)
                            {
                                model.Period07 = BaseFunction.ReturnDecimal(result.Rows[i]["Month" + (q + 1)], 2);
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

                            model.Vendor = Vendor.Replace("'", "''");
                            model.MFR = MFR.Replace("'", "''");
                            model.MPN = MPN.Replace("'", "''");

                            DAL.TK_BuyerGating dal = new DAL.TK_BuyerGating();
                            sSQL = dal.Add(model);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL.Replace("TK_BuyerGating", "#temp"));
                        }
                    }
                }

                sSQL = "delete from TK_BuyerGating where sTKVersion='" + sTKVersion + "'";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, @"
insert into TK_BuyerGating (
                sTKVersion, Period01, Period02, Period03, Period04, Period05, Period06, Period07, sProductGroup, 
                sBuyer, iItemNO, dtmDuedate, dockDate, Gating, sPONo, fOpenQTY, Vendor, MPN, MFR, Remark, Action, CreateUid, dtmCreate)
select sTKVersion
    ,case when isnull(Period01,0) = 0 then null else Period01 end
    ,case when isnull(Period02,0) = 0 then null else Period02 end
    ,case when isnull(Period03,0) = 0 then null else Period03 end
    ,case when isnull(Period04,0) = 0 then null else Period04 end
    ,case when isnull(Period05,0) = 0 then null else Period05 end
    ,case when isnull(Period06,0) = 0 then null else Period06 end
    ,case when isnull(Period07,0) = 0 then null else Period07 end
    , sProductGroup, sBuyer, iItemNO, dtmDuedate, dockDate, Gating, sPONo, fOpenQTY, Vendor, MPN, MFR, Remark, Action, CreateUid, dtmCreate 
from #temp
                ");

               

                //////计算结束
                tran.Commit();

                ClsWriteLog.WriteLog(sPath, "Buygating计算-2", "计算成功");

                if (sTKVersion.StartsWith("00"))
                {
                    sSQL = @"
update      _AutoRun  set GatingStatus = 2
WHERE   (sType = 'Trialkitting')
";
                    DbHelperSQL.ExecuteSql(sSQL);
                }

                ClsWriteLog.WriteLog(sPath, "Buygating计算", "计算成功" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception e)
            {
                if (sTKVersion.StartsWith("00"))
                {
                    sSQL = @"
update      _AutoRun  set GatingStatus = 3
WHERE   (sType = 'Trialkitting')
";
                    DbHelperSQL.ExecuteSql(sSQL);
                }

                tran.Rollback();

                ClsWriteLog.WriteLog(sPath, "Buygating计算-2", "计算失败：" + e.Message);          
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

        public DataTable GetPeriod(SqlTransaction tran, string sTKVersion)
        {
            int iYear = int.Parse(sTKVersion.Split('-')[1].Substring(0, 4));
            int iMonth = int.Parse(sTKVersion.Split('-')[1].Substring(4, 2));
            int iDay = int.Parse(sTKVersion.Split('-')[1].Substring(6, 2));

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
