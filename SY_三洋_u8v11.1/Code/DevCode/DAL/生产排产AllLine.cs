using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:生产排产
    /// </summary>
    public partial class 生产排产AllLine
    {
        TH.DAL.GetBaseData DALGetBaseData = new GetBaseData();

        DataTable dt日历 = new DataTable();

        public DataTable TZ天数(int iDays, DataTable dt, DateTime dtmPlan, out string sReturn)
        {
            DataTable dtTemp = dt.Copy();

            try
            {
                sReturn = "";
                DataTable dtTemp日历 = GetWorkCalendar(dtmPlan.Year);

                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (!Convert.ToBoolean(dtTemp.Rows[i]["choose"]))
                    {
                        continue;
                    }

                    #region 调整天数（往后）

                    if (iDays > 0)
                    {
                        string sMaxCol = "";
                        DateTime dMaxDate = dtmPlan;

                        for (int j = dtTemp.Columns.Count - 1; j >= 0; j--)
                        {
                            string sColName = dtTemp.Columns[j].ColumnName.Trim();
                            if (sColName.Length == 8 && sColName.Substring(0, 2) == "数量")
                            {
                                if (sMaxCol == "")
                                {
                                    sMaxCol = sColName;

                                    string s = sMaxCol.Substring(2);
                                    dMaxDate = BaseFunction.BaseFunction.ReturnDate("20" + s.Substring(0, 2) + "-" + s.Substring(2, 2) + "-" + s.Substring(4));
                                }
                                decimal dQty = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[i][j]);
                                decimal d工时 = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[i]["工时" + sColName.Substring(2)]);
                                int i状态 = BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows[i]["状态" + sColName.Substring(2)]);
                                if (dQty == 0)
                                {
                                    continue;
                                }
                                string sNowCol = dtTemp.Columns[j].ColumnName.Trim();
                                string s2 = sNowCol.Substring(2);
                                DateTime dNowDate = BaseFunction.BaseFunction.ReturnDate("20" + s2.Substring(0, 2) + "-" + s2.Substring(2, 2) + "-" + s2.Substring(4));

                                DateTime dTime = dNowDate;
                                int iColAdd = 0;
                                int iDaysTemp = iDays;
                                while (iDaysTemp > 0)
                                {
                                    dTime = dTime.AddDays(1);
                                    iColAdd += 1;

                                    string sLineNo = dtTemp.Rows[i]["产线编码"].ToString().Trim();
                                    DataRow[] dr = dtTemp日历.Select("iYear = " + dTime.Year + " and iMonth = " + dTime.Month + " and LineNo = '" + sLineNo + "' ");
                                    int iDayTime = BaseFunction.BaseFunction.ReturnInt(dr[0]["i" + dTime.Day.ToString()]);

                                    if (iDayTime > 0)
                                    {
                                        iDaysTemp -= 1;
                                    }
                                }
                                if (dTime > dMaxDate)
                                {
                                    sReturn = sReturn + "行" + (i + 1).ToString() + "超出当前排产日期\n";

                                    //gridView1.SetRowCellValue(i, gridView1.Columns[j], DBNull.Value);
                                    dtTemp.Rows[i]["数量" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                    dtTemp.Rows[i]["工时" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                    dtTemp.Rows[i]["状态" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                }
                                else
                                {
                                    dtTemp.Rows[i]["数量" + dTime.ToString("yyMMdd")] = dQty;
                                    dtTemp.Rows[i]["工时" + dTime.ToString("yyMMdd")] = d工时;
                                    dtTemp.Rows[i]["状态" + dTime.ToString("yyMMdd")] = i状态;

                                    dtTemp.Rows[i]["数量" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                    dtTemp.Rows[i]["工时" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                    dtTemp.Rows[i]["状态" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                }

                            }
                        }
                    }

                    #endregion
                    #region 调整天数（往前）

                    else
                    {
                        string sMinCol = "";
                        DateTime dMinDate = dtmPlan;

                        for (int j = 0; j < dtTemp.Columns.Count; j++)
                        {
                            string sColName = dtTemp.Columns[j].ColumnName.Trim();
                            if (sColName.Length == 8 && sColName.Substring(0, 2) == "数量")
                            {
                                if (sMinCol == "")
                                {
                                    sMinCol = sColName;

                                    string s = sMinCol.Substring(2);
                                    dMinDate = BaseFunction.BaseFunction.ReturnDate("20" + s.Substring(0, 2) + "-" + s.Substring(2, 2) + "-" + s.Substring(4));
                                }
                                decimal dQty = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[i][j]);
                                decimal d工时 = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[i]["工时" + sColName.Substring(2)]);
                                int i状态 = BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows[i]["状态" + sColName.Substring(2)]);
                                if (dQty == 0)
                                {
                                    continue;
                                }
                                string sNowCol = dtTemp.Columns[j].ColumnName.Trim();
                                string s2 = sNowCol.Substring(2);
                                DateTime dNowDate = BaseFunction.BaseFunction.ReturnDate("20" + s2.Substring(0, 2) + "-" + s2.Substring(2, 2) + "-" + s2.Substring(4));

                                DateTime dTime = dNowDate;
                                int iColAdd = 0;
                                int iDaysTemp = iDays;
                                while (iDaysTemp < 0)
                                {
                                    dTime = dTime.AddDays(-1);
                                    iColAdd += 1;

                                    DataRow[] dr = dtTemp日历.Select("iYear = " + dTime.Year + " and iMonth = " + dTime.Month + " ");
                                    int iDayTime = BaseFunction.BaseFunction.ReturnInt(dr[0]["i" + dTime.Day.ToString()]);

                                    if (iDayTime > 0)
                                    {
                                        iDaysTemp += 1;
                                    }
                                }
                                if (dTime < dMinDate)
                                {
                                    sReturn = sReturn + "行" + (i + 1).ToString() + "早于当前排产日期\n";

                                    dtTemp.Rows[i]["数量" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                    dtTemp.Rows[i]["工时" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                    dtTemp.Rows[i]["状态" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                }
                                else
                                {
                                    dtTemp.Rows[i]["数量" + dTime.ToString("yyMMdd")] = dQty;
                                    dtTemp.Rows[i]["工时" + dTime.ToString("yyMMdd")] = d工时;
                                    dtTemp.Rows[i]["状态" + dTime.ToString("yyMMdd")] = i状态;

                                    dtTemp.Rows[i]["数量" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                    dtTemp.Rows[i]["工时" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                    dtTemp.Rows[i]["状态" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                }

                            }
                        }
                    }

                    #endregion
                }

                dt = dtTemp.Copy();
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            return dt;
        }

        /// <summary>
        /// 检查数量是否超出计划
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string CheckQty(long lID)
        {
            string sErr = "";
            try
            {
                string sSQL = @"
select b.存货编码, b.数量,sum(a.数量) as 排产数量
from dbo.生产日计划 a right join 生产计划 b on b.GUID = a.来源GUID
where b.iID = 111111
group by b.存货编码, b.数量
";
                sSQL = sSQL.Replace("111111", lID.ToString());
                DataTable dt生产计划 = DbHelperSQL.Query(sSQL);
                if (dt生产计划 == null || dt生产计划.Rows.Count == 0)
                {
                    throw new Exception("生产计划序号" + lID.ToString().Trim() + "的生产计划不存在");
                }

                decimal d数量 = BaseFunction.BaseFunction.ReturnDecimal(dt生产计划.Rows[0]["数量"]);
                decimal d排产数量 = BaseFunction.BaseFunction.ReturnDecimal(dt生产计划.Rows[0]["排产数量"]);

                if (d数量 < d排产数量)
                {
                    sErr = sErr + "排产数量超过计划\n";
                }

            }
            catch (Exception ee)
            {
                sErr = sErr + ee.Message + "\n";
            }


            return sErr;
        }

        /// <summary>
        /// 生产排产
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetPCList(DateTime dDate, int iDaysCount, int iPCType)
        {
            DataTable dtPC = new DataTable();
            try
            {
                string sCols1 = "";
                string sCols2 = "";
                string sCols3 = "";
                string sDate = dDate.ToString("yyyy-MM-dd");

                for (int i = 0; i < iDaysCount; i++)
                {
                    sCols1 = sCols1 + ",cast (null as decimal(16,6)) as 数量" + dDate.AddDays(i).ToString("yyMMdd") + ",cast (null as decimal(16,6)) as 工时" + dDate.AddDays(i).ToString("yyMMdd") + ",cast (null as decimal(16,6)) as 状态" + dDate.AddDays(i).ToString("yyMMdd");

                    if (i == 0)
                    {
                        sCols2 = sCols2 + "数量" + dDate.AddDays(i).ToString("yyMMdd") + " = ISNULL(数量" + dDate.AddDays(i).ToString("yyMMdd") + ",0) + case when b.计划生产日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then b.数量 else 0 end";
                        sCols2 = sCols2 + ",工时" + dDate.AddDays(i).ToString("yyMMdd") + " = ISNULL(工时" + dDate.AddDays(i).ToString("yyMMdd") + ",0) + case when b.计划生产日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then b.工时 else 0 end";
                    }
                    else
                    {
                        sCols2 = sCols2 + ",数量" + dDate.AddDays(i).ToString("yyMMdd") + " = ISNULL(数量" + dDate.AddDays(i).ToString("yyMMdd") + ",0) + case when b.计划生产日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then b.数量 else 0 end";
                        sCols2 = sCols2 + ",工时" + dDate.AddDays(i).ToString("yyMMdd") + " = ISNULL(工时" + dDate.AddDays(i).ToString("yyMMdd") + ",0) + case when b.计划生产日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then b.工时 else 0 end";
                    }

                    if (i == 0)
                    {
                        sCols3 = sCols3 + "数量" + dDate.AddDays(i).ToString("yyMMdd") + " = case when ISNULL(数量" + dDate.AddDays(i).ToString("yyMMdd") + " ,0) = 0 then null else 数量" + dDate.AddDays(i).ToString("yyMMdd") + " end ";
                        sCols3 = sCols3 + ",工时" + dDate.AddDays(i).ToString("yyMMdd") + " = case when ISNULL(工时" + dDate.AddDays(i).ToString("yyMMdd") + " ,0) = 0 then null else 工时" + dDate.AddDays(i).ToString("yyMMdd") + " end ";
                    }
                    else
                    {
                        sCols3 = sCols3 + ",数量" + dDate.AddDays(i).ToString("yyMMdd") + " = case when ISNULL(数量" + dDate.AddDays(i).ToString("yyMMdd") + " ,0) = 0 then null else 数量" + dDate.AddDays(i).ToString("yyMMdd") + " end ";
                        sCols3 = sCols3 + ",工时" + dDate.AddDays(i).ToString("yyMMdd") + " = case when ISNULL(工时" + dDate.AddDays(i).ToString("yyMMdd") + " ,0) = 0 then null else 工时" + dDate.AddDays(i).ToString("yyMMdd") + " end ";
                    }
                }

                string sErr = "";

                int iCou = 0;
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = @"

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[生产排产临时表]') AND type in (N'U'))
DROP TABLE [dbo].[生产排产临时表]

select distinct cast(0 as bit) as choose
	,a.iID as 生产计划序号
	, a.GUID as 来源GUID,a.单据类型
	,a.评审单据号,a.销售订单号,a.销售订单行号
	,a.存货编码,cast(a.数量 as decimal(16,6)) as 计划数量,cast(a.数量 - isnull(i.完工数量,0)  - isnull(k.数量,0) as decimal(16,6)) as 待排产数量
	,CONVERT(varchar(10),a.计划开工日期,111) as 计划开工日期,CONVERT(varchar(10),a.计划完工日期,111) as 计划完工日期
	,cast(case when a.产线编码 = e.[LineNo] then 1 else 0 end as bit) as 计划产线
	,e.[LineNo] as 产线编码
	,cast(e.SelfCycle / isnull(e.SelfCycleB,1) as decimal(18,10)) as 单件生产工时
	,isnull(g.PeopleNO,0) as 产线并发数
	,a.生产准备时间,a.生产部门编码,cast(null as decimal(16,6)) as 未排产数量,cast (null as decimal(16,6)) as 当前页面排产数量,cast(0 as bit) as 排产状态,cast(null as varchar(200)) as 排产说明
    ,i.完工数量,cast(case when isnull(b.数量,0) > 0 then 0 else 1 end as bit) as 首次排产
    111111
into 生产排产临时表
from dbo.生产计划 a 
	left join @u8.Inventory c on c.cInvCode = a.存货编码
	left join InvLineCycle e on e.cInvCode = a.存货编码
	left join dbo.生产日计划 b on a.GUID = b.来源GUID and b.产线 = a.产线编码
    left join ProductionLine g on g.[LineNo] = case when isnull(b.产线,'') = '' then a.产线编码 else b.产线 end
    left join (select 来源GUID,sum(数量) as 数量 from 生产日计划 where 计划生产日期 >= '555555' group by 来源GUID) k on k.来源GUID = a.GUID
    left join (select 来源GUID,sum(数量) as 数量 from 生产日计划 where 排产日期 < '555555' group by 来源GUID) l on k.来源GUID = a.GUID
    left join 
    (
		select sum(isnull(b.完工数量,0)) as 完工数量,a.来源GUID
		from dbo.生产日计划 a left join dbo.生产日计划完工登记 b on a.iID = b.生产日计划iID
		where 计划生产日期 < '555555' and isnull(b.审核人,'') <> ''
		group by a.来源GUID 
    )i on i.来源GUID = a.GUID
where isnull(a.审核人,'') <> '' and isnull(a.关闭人,'') = '' and a.数量 > isnull(i.完工数量,0)


";
                    sSQL = sSQL.Replace("111111", sCols1);
                    sSQL = sSQL.Replace("222222", sCols2);
                    sSQL = sSQL.Replace("333333", sCols3);
                    sSQL = sSQL.Replace("555555", dDate.ToString("yyyy-MM-dd"));

                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "select * from 生产日计划 where 计划生产日期 >= '" + sDate + "' and 计划生产日期 < '" + dDate.AddDays(iDaysCount).ToString("yyyy-MM-dd") + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DateTime d计划生产日期 = BaseFunction.BaseFunction.ReturnDate(dt.Rows[i]["计划生产日期"]);
                        string s日期 = d计划生产日期.ToString("yyMMdd");
                        decimal d数量 = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i]["数量"]);
                        decimal d工时 = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i]["工时"]);
                        sSQL = "update 生产排产临时表 set 排产状态 = 1,数量" + s日期 + " = isnull(数量" + s日期 + ",0) + " + d数量 + ",工时" + s日期 + " = isnull(工时" + s日期 + ",0) + " + d工时 + " where 来源GUID = '" + dt.Rows[i]["来源GUID"].ToString().Trim() + "' and 产线编码 = '" + dt.Rows[i]["产线"].ToString().Trim() + "'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    sSQL = @"
select * from 生产排产临时表 

order by 计划完工日期,计划开工日期,生产计划序号,计划产线 desc";
                    dtPC = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }

                if (dtPC == null || dtPC.Rows.Count < 0)
                {
                    throw new Exception("获得排产计划失败");
                }

                dt日历 = GetWorkCalendar(dDate.Year);

                for (int i = 0; i < dtPC.Rows.Count; i++)
                {
                    string sInvCode = dtPC.Rows[i]["存货编码"].ToString().Trim();

                    if (i == 18 && sInvCode == "A53114600")
                    {

                    }

                    DateTime d计划开工日期 = BaseFunction.BaseFunction.ReturnDate(dtPC.Rows[i]["计划开工日期"]);
                    DateTime d计划完工日期 = BaseFunction.BaseFunction.ReturnDate(dtPC.Rows[i]["计划完工日期"]);
                    decimal d待排产数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["待排产数量"], 0);
                    decimal d当前页面排产数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["当前页面排产数量"], 0);
                    bool b默认产线 = BaseFunction.BaseFunction.ReturnBool(dtPC.Rows[i]["计划产线"]);

                    //默认产线基础资料
                    string s产线编码 = dtPC.Rows[i]["产线编码"].ToString().Trim();
                    decimal d产线并发 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["产线并发数"], 0);
                    decimal d单件生产工时 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["单件生产工时"], 10);
                    long l生产计划序号 = BaseFunction.BaseFunction.ReturnLong(dtPC.Rows[i]["生产计划序号"]);

                    DateTime d排产最大日期 = dDate.AddDays(-1);

                    //分三段处理排产数据
                    //10. 已经排产的直接加载
                    //20. 按日期排产的不考虑切换产线,直接排产                                                    
                    //30. 自动切换产线的,默认产线不能排完自动切换其他产线

                    #region 10. 已经排产的不论日期直接加载排产数据,获取最大的排产日期

                    for (int j = 0; j < iDaysCount; j++)
                    {
                        string sColName数量 = "数量" + dDate.AddDays(j).ToString("yyMMdd");
                        string sColName工时 = "工时" + dDate.AddDays(j).ToString("yyMMdd");
                        string sColName状态 = "状态" + dDate.AddDays(j).ToString("yyMMdd");

                        decimal d日排产数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i][sColName数量]);
                        if (d日排产数量 > 0)
                        {
                            dtPC.Rows[i][sColName状态] = dtPC.Rows[i]["排产状态"];
                            d排产最大日期 = dDate.AddDays(j);
                        }
                    }

                    #endregion

                    #region 20. 按日期排产的不考虑切换产线,直接排产

                    if (d待排产数量 > 0 && b默认产线 && iPCType == 0)
                    {
                        for (int j = 0; j < iDaysCount; j++)
                        {
                            if (dDate.AddDays(j) <= d排产最大日期)
                                continue;

                            if (dDate.AddDays(j) < d计划开工日期)
                                continue;

                            decimal dDayTime = Get生产日历工时(s产线编码, dDate.AddDays(j));
                            if (dDayTime == 0)
                                continue;


                            string sColName数量 = "数量" + dDate.AddDays(j).ToString("yyMMdd");
                            string sColName工时 = "工时" + dDate.AddDays(j).ToString("yyMMdd");
                            string sColName状态 = "状态" + dDate.AddDays(j).ToString("yyMMdd");

                            decimal d日累计工时 = dDayTime * d产线并发;
                            decimal d产线累计排产工时 = GetTableColSum(dtPC.Copy(), s产线编码, sColName工时);

                            if (d产线累计排产工时 >= d日累计工时)
                                continue;

                            decimal d当前剩余工时 = d日累计工时 - d产线累计排产工时;

                            decimal d生产总工时 = BaseFunction.BaseFunction.ReturnDecimal(d待排产数量 * d单件生产工时, 10);
                            //当该日工时充足,直接排产
                            if (d当前剩余工时 >= d生产总工时)
                            {
                                dtPC.Rows[i][sColName数量] = d待排产数量;
                                dtPC.Rows[i][sColName工时] = d生产总工时;
                                dtPC.Rows[i][sColName状态] = 0;
                                d待排产数量 = 0;

                                DataRow[] dr = dtPC.Select("生产计划序号 = " + l生产计划序号);
                                if (dr.Length > 0)
                                {
                                    for (int ii = 0; ii < dr.Length; ii++)
                                    {
                                        dr[ii]["待排产数量"] = d待排产数量;
                                    }
                                }
                                break;
                            }
                            else
                            {
                                //当该日工时不足,用剩余工时获得可生产数量排入当天,其余的排入下一天
                                decimal d当前可生产数量 = BaseFunction.BaseFunction.ReturnDecimal(d当前剩余工时 / d单件生产工时, 0);
                                dtPC.Rows[i][sColName数量] = d当前可生产数量;
                                dtPC.Rows[i][sColName工时] = d当前剩余工时;
                                dtPC.Rows[i][sColName状态] = 0;

                                d待排产数量 = d待排产数量 - d当前可生产数量;

                                DataRow[] dr = dtPC.Select("生产计划序号 = " + l生产计划序号);
                                if (dr.Length > 0)
                                {
                                    for (int ii = 0; ii < dr.Length; ii++)
                                    {
                                        dr[ii]["待排产数量"] = d待排产数量;
                                    }
                                }
                            }

                        }
                    }

                    #endregion

                    #region 30. 自动切换产线
                    
                    if (d待排产数量 > 0 && iPCType == 1)
                    {
                        for (int j = 0; j < iDaysCount; j++)
                        {
                            DateTime d排产日期 = dDate.AddDays(j);

                            #region 当前排产日期小于 默认产线排产日期,查看其它产线产能是否空闲

                            if (d排产日期 < d排产最大日期)
                            {
                                DataRow[] dr = dtPC.Select("生产计划序号 = " + l生产计划序号 + " and 产线编码 <> '" + s产线编码 + "'");
                                if (dr.Length > 0)
                                {
                                    for (int ii = 0; ii < dr.Length; ii++)
                                    {
                                        if (d待排产数量 > 0)
                                        {
                                            string s产线编码2 = dr[ii]["产线编码"].ToString().Trim();
                                            decimal d产线并发2 = BaseFunction.BaseFunction.ReturnDecimal(dr[ii]["产线并发数"], 0);
                                            decimal d单件生产工时2 = BaseFunction.BaseFunction.ReturnDecimal(dr[ii]["单件生产工时"], 10);


                                            string sColName数量2 = "数量" + d排产日期.ToString("yyMMdd");
                                            string sColName工时2 = "工时" + d排产日期.ToString("yyMMdd");
                                            string sColName状态2 = "状态" + d排产日期.ToString("yyMMdd");


                                            decimal dDayTime2 = Get生产日历工时(s产线编码2, d排产日期);
                                            if (dDayTime2 == 0)
                                                continue;

                                            decimal d日累计工时2 = dDayTime2 * d产线并发2;
                                            decimal d产线累计排产工时2 = GetTableColSum(dtPC.Copy(), s产线编码2, sColName工时2);

                                            if (d产线累计排产工时2 >= d日累计工时2)
                                                continue;

                                            decimal d当前剩余工时2 = d日累计工时2 - d产线累计排产工时2;

                                            decimal d生产总工时2 = BaseFunction.BaseFunction.ReturnDecimal(d待排产数量 * d单件生产工时2, 10);
                                            //当该日工时充足,直接排产
                                            if (d当前剩余工时2 >= d生产总工时2)
                                            {
                                                dr[ii][sColName数量2] = d待排产数量;
                                                dr[ii][sColName工时2] = d生产总工时2;
                                                dr[ii][sColName状态2] = 0;
                                                d待排产数量 = 0;

                                                DataRow[] dr3 = dtPC.Select("生产计划序号 = " + l生产计划序号);
                                                if (dr3.Length > 0)
                                                {
                                                    for (int iii = 0; iii < dr3.Length; iii++)
                                                    {
                                                        dr3[iii]["待排产数量"] = d待排产数量;
                                                    }
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                //当该日工时不足,用剩余工时获得可生产数量排入当天,其余的排入下一天
                                                decimal d当前可生产数量2 = BaseFunction.BaseFunction.ReturnDecimal(d当前剩余工时2 / d单件生产工时2, 0);
                                                dr[ii][sColName数量2] = d当前可生产数量2;
                                                dr[ii][sColName工时2] = d当前剩余工时2;
                                                dr[ii][sColName状态2] = 0;

                                                d待排产数量 = d待排产数量 - d当前可生产数量2;


                                                DataRow[] dr3 = dtPC.Select("生产计划序号 = " + l生产计划序号);
                                                if (dr3.Length > 0)
                                                {
                                                    for (int iii = 0; iii < dr3.Length; iii++)
                                                    {
                                                        dr3[iii]["待排产数量"] = d待排产数量;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            #endregion
                            #region 当前排产日期等于 默认产线排产日期,先排默认产线,然后查看其它产线产能是否空闲

                            else
                            {
                                //先排计划产线
                                DataRow[] dr = dtPC.Select("生产计划序号 = " + l生产计划序号 + " and 计划产线 = 1 ");
                                if (dr.Length > 0)
                                {
                                    for (int ii = 0; ii < dr.Length; ii++)
                                    {
                                        if (d待排产数量 > 0)
                                        {
                                            string s产线编码2 = dr[ii]["产线编码"].ToString().Trim();
                                            decimal d产线并发2 = BaseFunction.BaseFunction.ReturnDecimal(dr[ii]["产线并发数"], 0);
                                            decimal d单件生产工时2 = BaseFunction.BaseFunction.ReturnDecimal(dr[ii]["单件生产工时"], 10);


                                            string sColName数量2 = "数量" + d排产日期.ToString("yyMMdd");
                                            string sColName工时2 = "工时" + d排产日期.ToString("yyMMdd");
                                            string sColName状态2 = "状态" + d排产日期.ToString("yyMMdd");


                                            decimal dDayTime2 = Get生产日历工时(s产线编码2, d排产日期);
                                            if (dDayTime2 == 0)
                                                continue;

                                            decimal d日累计工时2 = dDayTime2 * d产线并发2;
                                            decimal d产线累计排产工时2 = GetTableColSum(dtPC.Copy(), s产线编码2, sColName工时2);

                                            if (d产线累计排产工时2 >= d日累计工时2)
                                                continue;

                                            decimal d当前剩余工时2 = d日累计工时2 - d产线累计排产工时2;

                                            decimal d生产总工时2 = BaseFunction.BaseFunction.ReturnDecimal(d待排产数量 * d单件生产工时2, 10);
                                            //当该日工时充足,直接排产
                                            if (d当前剩余工时2 >= d生产总工时2)
                                            {
                                                dr[ii][sColName数量2] = d待排产数量;
                                                dr[ii][sColName工时2] = d生产总工时2;
                                                dr[ii][sColName状态2] = 0;
                                                d待排产数量 = 0;

                                                DataRow[] dr3 = dtPC.Select("生产计划序号 = " + l生产计划序号);
                                                if (dr3.Length > 0)
                                                {
                                                    for (int iii = 0; iii < dr3.Length; iii++)
                                                    {
                                                        dr3[iii]["待排产数量"] = d待排产数量;
                                                    }
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                //当该日工时不足,用剩余工时获得可生产数量排入当天,其余的排入下一天
                                                decimal d当前可生产数量2 = BaseFunction.BaseFunction.ReturnDecimal(d当前剩余工时2 / d单件生产工时2, 0);
                                                dr[ii][sColName数量2] = d当前可生产数量2;
                                                dr[ii][sColName工时2] = d当前剩余工时2;
                                                dr[ii][sColName状态2] = 0;

                                                d待排产数量 = d待排产数量 - d当前可生产数量2;


                                                DataRow[] dr3 = dtPC.Select("生产计划序号 = " + l生产计划序号);
                                                if (dr3.Length > 0)
                                                {
                                                    for (int iii = 0; iii < dr3.Length; iii++)
                                                    {
                                                        dr3[iii]["待排产数量"] = d待排产数量;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                dr = dtPC.Select("生产计划序号 = " + l生产计划序号 + " and 计划产线 <> 1 ");
                                if (dr.Length > 0)
                                {
                                    for (int ii = 0; ii < dr.Length; ii++)
                                    {
                                        if (d待排产数量 > 0)
                                        {
                                            string s产线编码2 = dr[ii]["产线编码"].ToString().Trim();
                                            if (s产线编码2 == "")
                                            {
                                                throw new Exception("请设定物料 " + dr[ii]["存货编码"].ToString().Trim() + " 对应产线");
                                            }


                                            decimal d产线并发2 = BaseFunction.BaseFunction.ReturnDecimal(dr[ii]["产线并发数"], 0);
                                            decimal d单件生产工时2 = BaseFunction.BaseFunction.ReturnDecimal(dr[ii]["单件生产工时"], 10);


                                            string sColName数量2 = "数量" + d排产日期.ToString("yyMMdd");
                                            string sColName工时2 = "工时" + d排产日期.ToString("yyMMdd");
                                            string sColName状态2 = "状态" + d排产日期.ToString("yyMMdd");


                                            decimal dDayTime2 = Get生产日历工时(s产线编码2, d排产日期);
                                            if (dDayTime2 == 0)
                                                continue;

                                            decimal d日累计工时2 = dDayTime2 * d产线并发2;
                                            decimal d产线累计排产工时2 = GetTableColSum(dtPC.Copy(), s产线编码2, sColName工时2);

                                            if (d产线累计排产工时2 >= d日累计工时2)
                                                continue;

                                            decimal d当前剩余工时2 = d日累计工时2 - d产线累计排产工时2;

                                            decimal d生产总工时2 = BaseFunction.BaseFunction.ReturnDecimal(d待排产数量 * d单件生产工时2, 10);
                                            //当该日工时充足,直接排产
                                            if (d当前剩余工时2 >= d生产总工时2)
                                            {
                                                dr[ii][sColName数量2] = d待排产数量;
                                                dr[ii][sColName工时2] = d生产总工时2;
                                                dr[ii][sColName状态2] = 0;
                                                d待排产数量 = 0;

                                                DataRow[] dr3 = dtPC.Select("生产计划序号 = " + l生产计划序号);
                                                if (dr3.Length > 0)
                                                {
                                                    for (int iii = 0; iii < dr3.Length; iii++)
                                                    {
                                                        dr3[iii]["待排产数量"] = d待排产数量;
                                                    }
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                //当该日工时不足,用剩余工时获得可生产数量排入当天,其余的排入下一天
                                                decimal d当前可生产数量2 = BaseFunction.BaseFunction.ReturnDecimal(d当前剩余工时2 / d单件生产工时2, 0);
                                                dr[ii][sColName数量2] = d当前可生产数量2;
                                                dr[ii][sColName工时2] = d当前剩余工时2;
                                                dr[ii][sColName状态2] = 0;

                                                d待排产数量 = d待排产数量 - d当前可生产数量2;


                                                DataRow[] dr3 = dtPC.Select("生产计划序号 = " + l生产计划序号);
                                                if (dr3.Length > 0)
                                                {
                                                    for (int iii = 0; iii < dr3.Length; iii++)
                                                    {
                                                        dr3[iii]["待排产数量"] = d待排产数量;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            #endregion
                        }
                    }

                    #endregion
                  
                }

                if (sErr.Trim() != "")
                    throw new Exception(sErr);

                //for (int i = dtPC.Rows.Count - 1; i >= 0; i--)
                //{
                //    decimal d待排产数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["待排产数量"]);
                //    if (d待排产数量 <= 0)
                //    {
                //        dtPC.Rows.RemoveAt(i);
                //    }
                //}
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

            return dtPC;
        }

        private decimal Get生产日历工时(string sLineNo,DateTime dDay)
        {
            DataRow[] dr = dt日历.Select("iYear = " + dDay.Year + " and iMonth = " + dDay.Month + " and LineNo = '" + sLineNo + "'");
            if (dr.Length == 0)
                throw new Exception("请设定" + dDay.ToString("yyyy-MM-dd") +" " + sLineNo + "产线工作日历");

            return BaseFunction.BaseFunction.ReturnDecimal(dr[0]["i" + dDay.Day.ToString()], 1);
        }

        /// <summary>
        /// 获得物料可生产的产线信息
        /// </summary>
        /// <param name="sInvCode"></param>
        /// <returns></returns>
        private DataTable GetInvLineNo(string sInvCode)
        {
            string sSQL = @"
select a.cInvCode as 存货编码,a.[LineNO] as 产线编码,cast(a.SelfCycle / isnull(a.SelfCycleB,1) as decimal(16,10)) as 单件生产工时
	,case when isnull(a.Priority,0) = 0 then 2 else a.Priority end as Priority
	,a.SelfSetupCycle as 生产准备时间
    ,b.PeopleNO as 产线并发,b.cDepCode as 生产部门编码
from dbo.InvLineCycle a inner join dbo.ProductionLine b on a.[LineNo] = b.[LineNo]
where a.cInvCode = '111111'
order by case when isnull(a.Priority,0) = 0 then 2 else a.Priority end,a.[LineNo] 
";
            sSQL = sSQL.Replace("111111", sInvCode);
            DataTable dt = DbHelperSQL.Query(sSQL);
            return dt;
        }

        /// <summary>
        /// 获得DataTable中某一列的值汇总
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sColName"></param>
        /// <returns></returns>
        public decimal GetTableColSum(DataTable dt1,string sLineNo, string sColName)
        {
            DataView dv1 = dt1.DefaultView;
            dv1.RowFilter = "产线编码 = '" + sLineNo + "'";

            DataView dv = dv1.ToTable().DefaultView;
            decimal d1 = BaseFunction.BaseFunction.ReturnDecimal(dv.Table.Compute("sum(" + sColName + ")", ""), 10);

            return d1;
        }

        /// <summary>
        /// 获得生产排产默认天数
        /// </summary>
        public int GetPCDays()
        {
            int i = 0;
            string sSQL = "select * from dbo._Code where sType = '生产排产默认天数'";
            DataTable ds = DbHelperSQL.Query(sSQL);
            i = BaseFunction.BaseFunction.ReturnInt(ds.Rows[0]["cCode"]);

            return i;
        }


        /// <summary>
        /// 获得生产默认日工时
        /// </summary>
        public decimal GetDayTime()
        {
            decimal d = 0;
            string sSQL = "select * from dbo._Code where sType = '生产默认日工时'";
            DataTable ds = DbHelperSQL.Query(sSQL);
            d = BaseFunction.BaseFunction.ReturnDecimal(ds.Rows[0]["cCode"], 1);

            return d;
        }

        /// <summary>
        /// 获得工作日历
        /// </summary>
        /// <param name="iYear"></param>
        /// <returns></returns>
        private DataTable GetWorkCalendar(int iYear)
        {
            string sSQL = "select * from WorkCalendar where iYear = 111111 or iYear = 222222 order by iYear,iMonth";
            sSQL = sSQL.Replace("111111", iYear.ToString());
            sSQL = sSQL.Replace("222222", (iYear + 1).ToString());
            return DbHelperSQL.Query(sSQL);
        }

        public int Save(DateTime dDate, DataTable dtDetails)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                DateTime d当前日期 = DALGetBaseData.GetDatetimeSer();

                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dtDetails.Rows[i]["choose"]))
                        continue;

                    for (int j = 0; j < dtDetails.Columns.Count; j++)
                    {
                        string sColName = dtDetails.Columns[j].ColumnName.Trim();
                        if (sColName.Length == 8 && sColName.Substring(0, 2) == "数量")
                        {
                            string sTemp = sColName.Substring(2);
                            string sTemp2 = sTemp.Substring(0, 2) + "-" + sTemp.Substring(2, 2) + "-" + sTemp.Substring(4, 2);
                            DateTime d计划生产日期 = BaseFunction.BaseFunction.ReturnDate(sTemp2);

                            decimal dQty = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i][j]);
                    
                            TH.Model.生产日计划 model = new TH.Model.生产日计划();
                            model.CreateDate = DALGetBaseData.GetDatetimeSer();
                            model.产线 = dtDetails.Rows[i]["产线编码"].ToString().Trim();
                            model.产线并发数 = BaseFunction.BaseFunction.ReturnInt(dtDetails.Rows[i]["产线并发数"]);
                            model.单件生产工时 = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["单件生产工时"], 10);
                            model.计划生产日期 = d计划生产日期;
                            model.来源GUID = (Guid)dtDetails.Rows[i]["来源GUID"];
                            model.来源类型 = dtDetails.Rows[i]["单据类型"].ToString().Trim();
                            model.排产日期 = dDate;
                            model.生产部门编码 = dtDetails.Rows[i]["生产部门编码"].ToString().Trim();
                            model.生产准备时间 = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["生产准备时间"], 1);
                            model.数量 = dQty;
                            model.制单人 = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                            model.制单日期 = DALGetBaseData.GetDatetimeSer();
                            model.工时 = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["工时" + d计划生产日期.ToString("yyMMdd")]);
                            model.状态 = BaseFunction.BaseFunction.ReturnInt(dtDetails.Rows[i]["状态" + d计划生产日期.ToString("yyMMdd")]);

                            string sSQL = "select * from 生产日计划 where 产线 = '" + model.产线 + "' and 来源GUID = '" + model.来源GUID + "' and 计划生产日期 = '" + model.计划生产日期 + "'";
                            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                            //历史记录表不存在则创建新表,历史表每个月一张
                            string sTableName = "生产日计划历史" + BaseFunction.BaseFunction.ReturnDate(model.排产日期).ToString("yyMM");
                            sSQL = @"
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[111111]') AND type in (N'U'))
    
CREATE TABLE [dbo].[111111](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[来源类型] [varchar](50) NULL,
	[来源GUID] [uniqueidentifier] NOT NULL,
	[排产日期] [datetime] NOT NULL,
	[计划生产日期] [datetime] NOT NULL,
	[产线] [varchar](50) NOT NULL,
	[审核人] [varchar](50) NULL,
	[审核日期] [datetime] NULL,
	[制单人] [varchar](50) NULL,
	[制单日期] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
	[数量] [decimal](16, 6) NULL,
	[工时] [decimal](18, 2) NULL,
	[产线并发数] [int] NULL,
	[生产准备时间] [decimal](18, 1) NULL,
	[单件生产工时] [decimal](18, 10) NULL,
	[生产部门编码] [varchar](50) NULL,
    [状态] [int] NULL,
 CONSTRAINT [PK_111111] PRIMARY KEY CLUSTERED 
(
	[来源GUID] ASC,
	[排产日期] ASC,
	[计划生产日期] ASC,
	[产线] ASC,
	[CreateDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

";
                            sSQL = sSQL.Replace("111111", sTableName);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = Add历史(model,sTableName);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            if (dt == null || dt.Rows.Count == 0)
                            {
                                if (model.数量 == 0)
                                {
                                    sSQL = Delete(model);
                                }
                                else
                                {
                                    sSQL = Add(model);
                                }
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            else
                            {
                                if (model.数量 == 0)
                                {
                                    sSQL = Delete(model);
                                }
                                else
                                {
                                    sSQL = Update(model);
                                }
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                    }
                }
                if (sErr.Trim() != "")
                    throw new Exception(sErr);

                if (iCou == 0)
                    throw new Exception("请选择需要保存的数据");

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }


        public DataTable GetWorkTime()
        {
            string sSQL = "select * from _LookUpDate where iType = '12' order by iID";
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 工时核查
        /// </summary>
        /// <param name="dDate"></param>
        /// <param name="dtGrid"></param>
        /// <returns></returns>
        public DataTable GetLineWorkTime(DateTime dTime1, DateTime dTime2, string sLineNo, DataTable dtGrid)
        {
            //获得其他产线工时数据
            string sCol = "";
            while (dTime1 <= dTime2)
            {
                sCol = sCol + ",sum(case when a.计划生产日期 = '" + dTime1.ToString("yyyy-MM-dd") + "' then 工时 end) as  工时" + dTime1.ToString("yyMMdd");
                sCol = sCol + ",cast(sum(case when a.计划生产日期 = '" + dTime1.ToString("yyyy-MM-dd") + "' then 工时 end) / case when isnull(b.PeopleNO,0) = 0 then 1 else b.PeopleNO end as decimal(16,2)) as 人均工时" + dTime1.ToString("yyMMdd");

                dTime1 = dTime1.AddDays(1);
            }

            string sSQL = @"
select b.[LineNo] as 产线编码,b.LineName as 产线,b.PeopleNO as 人数
	111111
from dbo.ProductionLine b 
    left join [SystemDB_SY].[dbo].[生产日计划] a on a.产线 = b.[LineNo] and 1=1
group by b.[LineNo],b.LineName,b.PeopleNO
";
            sSQL = sSQL.Replace("111111", sCol);
            if (sLineNo.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.产线 <> '" + sLineNo + "'");
            }
            DataTable dt = DbHelperSQL.Query(sSQL);

            int iRow = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = dt.Rows[i]["产线编码"].ToString().Trim();
                if (s == sLineNo)
                {
                    iRow = i;
                    break;
                }
            }


            for (int j = 0; j < dtGrid.Columns.Count; j++)
            {
                decimal d工时 = 0;
                string sName = dtGrid.Columns[j].ToString().Trim();
                if (sName.Length == 8 && sName.Substring(0, 2) == "工时")
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        d工时 = d工时 + BaseFunction.BaseFunction.ReturnDecimal(dtGrid.Rows[i][j]);
                    }
                    if (d工时 > 0)
                    {
                        dt.Rows[iRow][sName] = BaseFunction.BaseFunction.ReturnDecimal(d工时, 2);

                        int iPeople = BaseFunction.BaseFunction.ReturnInt(dt.Rows[iRow]["人数"]);
                        if (iPeople == 0)
                            iPeople = 1;

                        dt.Rows[iRow]["人均" + sName] = BaseFunction.BaseFunction.ReturnDecimal(d工时 / iPeople, 2);
                    }
                }
            }

            return dt;
        }

        public DataTable GetLineInvCode(string sLineNO, string sInvCode)
        {
            string sSQL = "select a.*,b.PeopleNO from InvLineCycle a inner join dbo.ProductionLine b on a.[LineNo] = b.[LineNo] where a.cInvCode = '" + sInvCode + "' and a.[LineNO] = '" + sLineNO + "'";
            return DbHelperSQL.Query(sSQL);
        }


        public DateTime GetPCMinDate(string sTime)
        {
            string sSQL = "select min(计划生产日期) from 111111 where convert(varchar(20),排产日期,121) = '222222'";
            sSQL = sSQL.Replace("111111", "生产日计划历史" + BaseFunction.BaseFunction.ReturnDate(sTime).ToString("yyMM"));
            sSQL = sSQL.Replace("222222", sTime);
            DataTable dt = DbHelperSQL.Query(sSQL);

            DateTime dtmTime = BaseFunction.BaseFunction.ReturnDate("2000-1-1");
            if (dt != null && dt.Rows.Count > 0)
            {
                dtmTime = BaseFunction.BaseFunction.ReturnDate(dt.Rows[0][0]);
            }
            return dtmTime;
        }

        public DateTime GetPCMaxDate(string sTime)
        {
            string sSQL = "select max(计划生产日期) from 111111 where convert(varchar(20),排产日期,121) = '222222'";
            sSQL = sSQL.Replace("111111", "生产日计划历史" + BaseFunction.BaseFunction.ReturnDate(sTime).ToString("yyMM"));
            sSQL = sSQL.Replace("222222", sTime);
            DataTable dt = DbHelperSQL.Query(sSQL);

            DateTime dtmTime = BaseFunction.BaseFunction.ReturnDate("2000-1-1");
            if (dt != null && dt.Rows.Count > 0)
            {
                dtmTime = BaseFunction.BaseFunction.ReturnDate(dt.Rows[0][0]);
            }
            return dtmTime;
        }

        public DataTable GetList(DateTime dTime,string sLineNo)
        {
            string sSQL = "select distinct convert(varchar(20),排产日期,121) as 排产日期 ,制单人 from 333333 where year(排产日期) = 111111 and month(排产日期) = 222222 and 1=1 order by 排产日期";
            sSQL = sSQL.Replace("111111", dTime.Year.ToString().Trim());
            sSQL = sSQL.Replace("222222", dTime.Month.ToString().Trim());
            sSQL = sSQL.Replace("333333", "生产日计划历史" + dTime.ToString("yyMM"));
            if (sLineNo != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 产线 = '" + sLineNo + "'");
            }

           return DbHelperSQL.Query(sSQL);
        }


        /// <summary>
        /// 生产排产历史查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetPC历史(string s排产日期)
        {
            //string sCols1 = "";
            string sCols2 = "";
            string sCols3 = "";
            DateTime dMinDate = GetPCMinDate(s排产日期);
            DateTime dMaxDate = GetPCMaxDate(s排产日期);

            //for (DateTime dDate = dMinDate; dDate <= dMaxDate; dDate.AddDays(1))

            DateTime dDate = dMinDate;
            string sDate = dDate.ToString("yyyy-MM-dd");
            int i = 0;
            while (dDate <= dMaxDate)
            {
                //sCols1 = sCols1 + ",cast (null as decimal(16,6)) as 数量" + dDate.ToString("yyMMdd") + ",cast (null as decimal(16,6)) as 工时" + dDate.ToString("yyMMdd") + ",cast (null as decimal(16,6)) as 状态" + dDate.ToString("yyMMdd");

                sCols2 = sCols2 + ",(case when datediff(d,'" + sDate + "',b.计划生产日期) = " + i.ToString() + " then b.数量 end) as 数量" + dDate.ToString("yyMMdd") + ",(case when datediff(d,'" + sDate + "',b.计划生产日期) = " + i.ToString() + " then b.工时 end) as 工时" + dDate.ToString("yyMMdd") + ",cast((case when datediff(d,'" + sDate + "',b.计划生产日期) = " + i.ToString() + " then case when isnull(b.审核人,'') <> '' then 2 when isnull(b.制单人,'') <> ''then 1 else 0 end end) as int) as 状态" + dDate.ToString("yyMMdd");

                sCols3 = sCols3 + ",sum(数量" + dDate.ToString("yyMMdd") + ") as 数量" + dDate.ToString("yyMMdd") + ",sum(工时" + dDate.ToString("yyMMdd") + ") as 工时" + dDate.ToString("yyMMdd") + ",sum(状态" + dDate.ToString("yyMMdd") + ") as 状态" + dDate.ToString("yyMMdd");

                i += 1;
                dDate = dMinDate.AddDays(i);
            }

            string sSQL = @"
select distinct a.iID as 生产计划序号, a.GUID as 来源GUID,a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,cast(a.数量 as decimal(16,6)) as 计划数量,b.数量 as 排产数量,a.计划开工日期,a.计划完工日期
	,case when isnull(b.产线,'') = '' then a.产线编码 else b.产线 end as 产线编码
	,cast(e.SelfCycle / isnull(e.SelfCycleB,1) as decimal(18,10)) as 单件生产工时
	,isnull(g.PeopleNO,0) as 产线并发数
	,a.生产准备时间,a.生产部门编码
into #a
from dbo.生产计划 a 
	inner join dbo.888888 b on a.GUID = b.来源GUID
	left join @u8.Inventory c on c.cInvCode = a.存货编码
	left join @u8.Inventory_extradefine d on d.cInvCode = c.cInvCode
	left join InvLineCycle e on e.cInvCode = a.存货编码 and e.[LineNo] = case when isnull(b.产线,'') = '' then a.产线编码 else b.产线 end
    left join (select InvCode,sum(Qty) as Qty,isnull(Define34 ,-1) as 生产计划序号 from @u8.mom_orderdetail group by InvCode,Define34) f on f.InvCode = a.存货编码 and f.生产计划序号 = a.iID
    left join ProductionLine g on g.[LineNo] = case when isnull(b.产线,'') = '' then a.产线编码 else b.产线 end
where convert(varchar(20),b.排产日期,121) = '777777'


select distinct a.生产计划序号,a.来源GUID,a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,a.计划数量,a.计划开工日期,a.计划完工日期
	,a.产线编码
	,a.单件生产工时
	,a.产线并发数
	,a.生产准备时间,a.生产部门编码
	222222
	,0 as 首次排产
into #c
from #a a inner join 生产日计划历史1408 b on a.来源GUID = b.来源GUID
where  convert(varchar(20),b.排产日期,121) = '777777'


select a.生产计划序号,a.来源GUID,a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,a.计划数量,a.计划开工日期,a.计划完工日期
	,a.产线编码
	,a.单件生产工时
	,a.产线并发数
	,a.生产准备时间,a.生产部门编码
	333333
	,0 as 首次排产
into #b
from #c a
group by  a.生产计划序号,a.来源GUID,a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,a.计划数量,a.计划开工日期,a.计划完工日期
	,a.产线编码
	,a.单件生产工时
	,a.产线并发数
	,a.生产准备时间,a.生产部门编码

select *,cast(0 as decimal(16,6)) as 当前页面排产数量,cast(null as varchar(200)) as 排产说明,cast(null as datetime) as 排产最大日期
from #b 
order by a.计划开工日期,a.存货编码

";
            sSQL = sSQL.Replace("222222", sCols2);
            sSQL = sSQL.Replace("333333", sCols3);
            sSQL = sSQL.Replace("555555", dDate.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("777777", s排产日期);

            DateTime d排产日期 = BaseFunction.BaseFunction.ReturnDate(s排产日期);
            sSQL = sSQL.Replace("888888", "生产日计划历史" + d排产日期.ToString("yyMM"));

            DataTable dtPC = DbHelperSQL.Query(sSQL);

            return dtPC;
        }

        #region 代码生成器

        /// <summary>
        /// 更新一数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(TH.Model.生产日计划 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 生产日计划 set ");
            if (model.来源类型 != null)
            {
                strSql.Append("来源类型='" + model.来源类型 + "',");
            }
            else
            {
                strSql.Append("来源类型= null ,");
            }
            if (model.排产日期 != null)
            {
                strSql.Append("排产日期='" + model.排产日期 + "',");
            }
            if (model.审核人 != null)
            {
                strSql.Append("审核人='" + model.审核人 + "',");
            }
            else
            {
                strSql.Append("审核人= null ,");
            }
            if (model.审核日期 != null)
            {
                strSql.Append("审核日期='" + model.审核日期 + "',");
            }
            else
            {
                strSql.Append("审核日期= null ,");
            }
            if (model.制单人 != null)
            {
                strSql.Append("制单人='" + model.制单人 + "',");
            }
            else
            {
                strSql.Append("制单人= null ,");
            }
            if (model.制单日期 != null)
            {
                strSql.Append("制单日期='" + model.制单日期 + "',");
            }
            else
            {
                strSql.Append("制单日期= null ,");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
            }
            else
            {
                strSql.Append("CreateDate= null ,");
            }
            if (model.数量 != null)
            {
                strSql.Append("数量=" + model.数量 + ",");
            }
            else
            {
                strSql.Append("数量= null ,");
            }
            if (model.工时 != null)
            {
                strSql.Append("工时=" + model.工时 + ",");
            }
            else
            {
                strSql.Append("工时= null ,");
            }
            if (model.产线并发数 != null)
            {
                strSql.Append("产线并发数=" + model.产线并发数 + ",");
            }
            else
            {
                strSql.Append("产线并发数= null ,");
            }
            if (model.生产准备时间 != null)
            {
                strSql.Append("生产准备时间=" + model.生产准备时间 + ",");
            }
            else
            {
                strSql.Append("生产准备时间= null ,");
            }
            if (model.单件生产工时 != null)
            {
                strSql.Append("单件生产工时=" + model.单件生产工时 + ",");
            }
            else
            {
                strSql.Append("单件生产工时= null ,");
            }
            if (model.生产部门编码 != null)
            {
                strSql.Append("生产部门编码='" + model.生产部门编码 + "',");
            }
            else
            {
                strSql.Append("生产部门编码= null ,");
            }
            if (model.状态 != null)
            {
                strSql.Append("状态=" + model.状态 + ",");
            }
            else
            {
                strSql.Append("状态= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where 来源GUID = '" + model.来源GUID + "' and 计划生产日期 = '" + model.计划生产日期 + "' and 产线 = '" + model.产线 + "'");
            return strSql.ToString();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.生产日计划 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.来源类型 != null)
            {
                strSql1.Append("来源类型,");
                strSql2.Append("'" + model.来源类型 + "',");
            }
            if (model.来源GUID != null)
            {
                strSql1.Append("来源GUID,");
                strSql2.Append("'" + model.来源GUID + "',");
            }
            if (model.排产日期 != null)
            {
                strSql1.Append("排产日期,");
                strSql2.Append("'" + model.排产日期 + "',");
            }
            if (model.计划生产日期 != null)
            {
                strSql1.Append("计划生产日期,");
                strSql2.Append("'" + model.计划生产日期 + "',");
            }
            if (model.产线 != null)
            {
                strSql1.Append("产线,");
                strSql2.Append("'" + model.产线 + "',");
            }
            if (model.审核人 != null)
            {
                strSql1.Append("审核人,");
                strSql2.Append("'" + model.审核人 + "',");
            }
            if (model.审核日期 != null)
            {
                strSql1.Append("审核日期,");
                strSql2.Append("'" + model.审核日期 + "',");
            }
            if (model.制单人 != null)
            {
                strSql1.Append("制单人,");
                strSql2.Append("'" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql1.Append("制单日期,");
                strSql2.Append("'" + model.制单日期 + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
            }
            if (model.工时 != null)
            {
                strSql1.Append("工时,");
                strSql2.Append("" + model.工时 + ",");
            }
            if (model.产线并发数 != null)
            {
                strSql1.Append("产线并发数,");
                strSql2.Append("" + model.产线并发数 + ",");
            }
            if (model.生产准备时间 != null)
            {
                strSql1.Append("生产准备时间,");
                strSql2.Append("" + model.生产准备时间 + ",");
            }
            if (model.单件生产工时 != null)
            {
                strSql1.Append("单件生产工时,");
                strSql2.Append("" + model.单件生产工时 + ",");
            }
            if (model.生产部门编码 != null)
            {
                strSql1.Append("生产部门编码,");
                strSql2.Append("'" + model.生产部门编码 + "',");
            }
            if (model.状态 != null)
            {
                strSql1.Append("状态,");
                strSql2.Append("" + model.状态 + ",");
            }
            strSql.Append("insert into 生产日计划(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add历史(TH.Model.生产日计划 model,string sTableName)
        {


            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.来源类型 != null)
            {
                strSql1.Append("来源类型,");
                strSql2.Append("'" + model.来源类型 + "',");
            }
            if (model.来源GUID != null)
            {
                strSql1.Append("来源GUID,");
                strSql2.Append("'" + model.来源GUID + "',");
            }
            if (model.排产日期 != null)
            {
                strSql1.Append("排产日期,");
                strSql2.Append("'" + model.排产日期 + "',");
            }
            if (model.计划生产日期 != null)
            {
                strSql1.Append("计划生产日期,");
                strSql2.Append("'" + model.计划生产日期 + "',");
            }
            if (model.产线 != null)
            {
                strSql1.Append("产线,");
                strSql2.Append("'" + model.产线 + "',");
            }
            if (model.审核人 != null)
            {
                strSql1.Append("审核人,");
                strSql2.Append("'" + model.审核人 + "',");
            }
            if (model.审核日期 != null)
            {
                strSql1.Append("审核日期,");
                strSql2.Append("'" + model.审核日期 + "',");
            }
            if (model.制单人 != null)
            {
                strSql1.Append("制单人,");
                strSql2.Append("'" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql1.Append("制单日期,");
                strSql2.Append("'" + model.制单日期 + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
            }
            if (model.工时 != null)
            {
                strSql1.Append("工时,");
                strSql2.Append("" + model.工时 + ",");
            }
            if (model.产线并发数 != null)
            {
                strSql1.Append("产线并发数,");
                strSql2.Append("" + model.产线并发数 + ",");
            }
            if (model.生产准备时间 != null)
            {
                strSql1.Append("生产准备时间,");
                strSql2.Append("" + model.生产准备时间 + ",");
            }
            if (model.单件生产工时 != null)
            {
                strSql1.Append("单件生产工时,");
                strSql2.Append("" + model.单件生产工时 + ",");
            }
            if (model.生产部门编码 != null)
            {
                strSql1.Append("生产部门编码,");
                strSql2.Append("'" + model.生产部门编码 + "',");
            }
            if (model.状态 != null)
            {
                strSql1.Append("状态,");
                strSql2.Append("" + model.状态 + ",");
            }
            strSql.Append("insert into " + sTableName + "(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(TH.Model.生产日计划 model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 生产日计划 ");
            strSql.Append(" where 来源GUID = '" + model.来源GUID + "' and 计划生产日期 = '" + model.计划生产日期 + "' and 产线 = '" + model.产线 + "'");
            return strSql.ToString();
           
        }
        #endregion
    }
}

