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
    public partial class 生产排产
    {
        TH.DAL.GetBaseData DALGetBaseData = new GetBaseData();

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
from dbo.生产日计划 a inner join 生产计划 b on b.GUID = a.来源GUID
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
        public DataTable GetPCList(DateTime dDate, int iDaysCount, decimal dDayTime, out string sReturn, string sLineNo, int iPeopleNo)
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

                    sCols2 = sCols2 + ",(case when datediff(d,'" + sDate + "',b.计划生产日期) = " + i.ToString() + " then b.数量 end) as 数量" + dDate.AddDays(i).ToString("yyMMdd") + ",(case when datediff(d,'" + sDate + "',b.计划生产日期) = " + i.ToString() + " then b.工时 end) as 工时" + dDate.AddDays(i).ToString("yyMMdd") + ",cast((case when datediff(d,'" + sDate + "',b.计划生产日期) = " + i.ToString() + " then case when isnull(b.审核人,'') <> '' then 2 when isnull(b.制单人,'') <> ''then 1 else 0 end end) as int) as 状态" + dDate.AddDays(i).ToString("yyMMdd");

                    sCols3 = sCols3 + ",sum(数量" + dDate.AddDays(i).ToString("yyMMdd") + ") as 数量" + dDate.AddDays(i).ToString("yyMMdd") + ",sum(工时" + dDate.AddDays(i).ToString("yyMMdd") + ") as 数量" + dDate.AddDays(i).ToString("yyMMdd") + ",sum(状态" + dDate.AddDays(i).ToString("yyMMdd") + ") as 状态" + dDate.AddDays(i).ToString("yyMMdd");
                }

                sReturn = "";
                string sErr = "";

                string sSQL = "select * from 生产日计划 where 排产日期 = '" + sDate + "'";
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = "已保存";

                    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        sReturn = "已审核";
                    }
                }

                sSQL = @"
select distinct a.iID as 生产计划序号, a.GUID as 来源GUID,a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,cast(a.数量 as decimal(16,6)) as 计划数量
	,cast(a.数量 - isnull(h.完工数量,0) - isnull(k.数量,0) as decimal(16,6)) as 待排产数量,a.计划开工日期,a.计划完工日期
	,case when isnull(b.产线,'') = '' then a.产线编码 else b.产线 end as 产线编码
	,cast(e.SelfCycle / isnull(e.SelfCycleB,1) as decimal(18,10)) as 单件生产工时
	,isnull(g.PeopleNO,0) as 产线并发数
	,a.生产准备时间,a.生产部门编码,cast(null as decimal(16,6)) as 未排产数量,isnull(i.数量,0) as 其他产线排产数量
	,h.完工数量
into #a
from dbo.生产计划 a 
    left join dbo.生产日计划 b on a.GUID = b.来源GUID
	left join @u8.Inventory c on c.cInvCode = a.存货编码
	left join @u8.Inventory_extradefine d on d.cInvCode = c.cInvCode
	left join InvLineCycle e on e.cInvCode = a.存货编码 and e.[LineNo] = case when isnull(b.产线,'') = '' then a.产线编码 else b.产线 end
    left join ProductionLine g on g.[LineNo] = case when isnull(b.产线,'') = '' then a.产线编码 else b.产线 end
    left join 
    (
		select a.iID,sum(isnull(b.完工数量,0)) as 完工数量,a.来源GUID
		from dbo.生产日计划 a left join dbo.生产日计划完工登记 b on a.iID = b.生产日计划iID
		where 计划生产日期 < '555555' and isnull(b.审核人,'') <> ''
		group by a.iID,a.来源GUID 
    )h on h.来源GUID = a.GUID
    left join (select 来源GUID,sum(数量) as 数量,产线 from 生产日计划 where 产线 <> '01' group by 来源GUID,产线) i on i.来源GUID = a.GUID
    left join (select 来源GUID,sum(数量) as 数量,产线 from 生产日计划 where 计划生产日期 >= '555555' and 产线 <> '01' group by 来源GUID,产线) j on j.来源GUID = a.GUID
    left join (select 来源GUID,sum(数量) as 数量 from 生产日计划 where 计划生产日期 >= '555555' group by 来源GUID) k on k.来源GUID = a.GUID

where isnull(a.审核人,'') <> '' and isnull(a.关闭人,'') = '' and a.数量 - isnull(h.完工数量,0) > 0
    666666



select *
	111111
    ,cast(1 as bit) as 首次排产
into #b
from #a a 
where a.来源GUID not in(select 来源GUID from dbo.生产日计划)





select distinct a.生产计划序号,a.来源GUID,a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,a.计划数量,a.待排产数量,a.计划开工日期,a.计划完工日期
	,a.产线编码
	,a.单件生产工时
	,a.产线并发数
	,a.生产准备时间,a.生产部门编码,a.未排产数量,a.其他产线排产数量,a.完工数量
	222222
	,cast(0 as bit) as 首次排产
into #c
from #a a inner join 生产日计划 b on a.来源GUID = b.来源GUID and a.产线编码 = b.产线
where a.产线编码 = '444444' 





insert into #b
select a.生产计划序号,a.来源GUID,a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,a.计划数量,a.待排产数量,a.计划开工日期,a.计划完工日期
	,a.产线编码
	,a.单件生产工时
	,a.产线并发数
	,a.生产准备时间,a.生产部门编码,a.未排产数量,a.其他产线排产数量,a.完工数量
	333333
	,cast(0 as bit) as 首次排产
from #c a
group by  a.生产计划序号,a.来源GUID,a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,a.计划数量,a.待排产数量,a.计划开工日期,a.计划完工日期
	,a.产线编码
	,a.单件生产工时
	,a.产线并发数
	,a.生产准备时间,a.生产部门编码,a.未排产数量,a.其他产线排产数量,a.完工数量


select *,cast(0 as decimal(16,6)) as 当前页面排产数量,cast(null as varchar(200)) as 排产说明,cast(null as datetime) as 排产最大日期
from #b 
order by a.计划开工日期,a.存货编码

";
                sSQL = sSQL.Replace("111111", sCols1);
                sSQL = sSQL.Replace("222222", sCols2);
                sSQL = sSQL.Replace("333333", sCols3);
                sSQL = sSQL.Replace("444444", sLineNo);
                sSQL = sSQL.Replace("555555", dDate.ToString("yyyy-MM-dd"));
                if (sLineNo.Trim() != "")
                {
                    sSQL = sSQL.Replace("666666", "and case when isnull(b.产线,'') = '' then a.产线编码 else b.产线 end = '" + sLineNo + "'");
                }

                dtPC = DbHelperSQL.Query(sSQL);

                DataTable dt日历 = GetWorkCalendar(dDate.Year);

                for (int i = 0; i < dtPC.Rows.Count; i++)
                {
                    decimal d产线并发 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["产线并发数"], 0);
                    decimal d生产计划数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["计划数量"], 0);
                    decimal d未排产数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["待排产数量"], 0);
                    decimal d单件生产工时 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["单件生产工时"], 10);
                    string s产线 = dtPC.Rows[i]["产线编码"].ToString().Trim();

                    if (d单件生产工时 == 0)
                    {
                        sErr = sErr + "存货" + dtPC.Rows[i]["存货编码"].ToString().Trim() + "需要设置单件工时\n";
                        continue;
                    }

                    bool b首次排产 = BaseFunction.BaseFunction.ReturnBool(dtPC.Rows[i]["首次排产"]);

                    //1. 将已经排产过的数据加载
                    //2. 根据每天已经排产的工时按照顺序加载未排产过的数据，工时不能超过日正常工时
                    if (!b首次排产)
                    {
                        DateTime d排产最大日期 = dDate;
                        for (int j = 0; j < iDaysCount; j++)
                        {
                            if (d未排产数量 <= 0)
                                break;

                            string sColName数量 = "数量" + dDate.AddDays(j).ToString("yyMMdd");
                            string sColName工时 = "工时" + dDate.AddDays(j).ToString("yyMMdd");

                            decimal d日排产数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i][sColName数量]);
                            if (d日排产数量 > 0)
                            {
                                d未排产数量 = d未排产数量 - d日排产数量;
                                d排产最大日期 = dDate.AddDays(j);
                            }
                        }

                        dtPC.Rows[i]["未排产数量"] = d未排产数量;

                        //全部排产,则继续下一行数据
                        if (d未排产数量 <= 0)
                            continue;
                        for (int j = 0; j < iDaysCount; j++)
                        {
                            if (d未排产数量 <= 0)
                                break;

                            string sColName数量 = "数量" + dDate.AddDays(j).ToString("yyMMdd");
                            string sColName工时 = "工时" + dDate.AddDays(j).ToString("yyMMdd");

                            DateTime d计划开工日期 = BaseFunction.BaseFunction.ReturnDate(dtPC.Rows[i]["计划开工日期"]);
                            //未到开工日期,循环下一天
                            if (d计划开工日期 > dDate.AddDays(j))
                            {
                                continue;
                            }

                            DataRow[] dr = dt日历.Select("iYear = " + dDate.AddDays(j).Year + " and iMonth = " + dDate.AddDays(j).Month + " ");
                            dDayTime = BaseFunction.BaseFunction.ReturnDecimal(dr[0]["i" + dDate.AddDays(j).Day.ToString()], 1);

                            decimal d日累计工时 = dDayTime * iPeopleNo;
                            decimal d当前剩余工时 = d日累计工时 - GetTableColSum(dtPC, sColName工时);
                            if (d当前剩余工时 <= 0)
                                continue;

                            decimal d生产总工时 = BaseFunction.BaseFunction.ReturnDecimal(d未排产数量 * d单件生产工时, 10);
                            //当该日工时充足,直接排产
                            if (d当前剩余工时 >= d生产总工时)
                            {
                                dtPC.Rows[i][sColName数量] = d未排产数量;
                                dtPC.Rows[i][sColName工时] = d生产总工时;
                                d未排产数量 = 0; ;
                                break;
                            }
                            else
                            {
                                //当改日工时不足,用剩余工时获得可生产数量排入当天,其余的排入下一天
                                decimal d当前可生产数量 = BaseFunction.BaseFunction.ReturnDecimal(d当前剩余工时 / d单件生产工时, 0);
                                dtPC.Rows[i][sColName数量] = d当前可生产数量;
                                dtPC.Rows[i][sColName工时] = d当前剩余工时;

                                d未排产数量 = d未排产数量 - d当前可生产数量;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < iDaysCount; j++)
                        {
                            if (d未排产数量 <= 0)
                                break;

                            string sColName数量 = "数量" + dDate.AddDays(j).ToString("yyMMdd");
                            string sColName工时 = "工时" + dDate.AddDays(j).ToString("yyMMdd");

                            DateTime d计划开工日期 = BaseFunction.BaseFunction.ReturnDate(dtPC.Rows[i]["计划开工日期"]);
                            //未到开工日期,循环下一天
                            if (d计划开工日期 > dDate.AddDays(j))
                            {
                                continue;
                            }

                            DataRow[] dr = dt日历.Select("iYear = " + dDate.AddDays(j).Year + " and iMonth = " + dDate.AddDays(j).Month + " and LineNo = '" + s产线 + "'");
                            if (dr.Length == 0)
                                throw new Exception("请设定" + dDate.AddDays(j).Year + "年" + dDate.AddDays(j).Month + "月" + s产线 + "产线工作日历");

                            string sCol = "i" + dDate.AddDays(j).Day.ToString();
                            dDayTime = BaseFunction.BaseFunction.ReturnDecimal(dr[0][sCol], 1);

                            decimal d日累计工时 = dDayTime * iPeopleNo;
                            decimal d当前剩余工时 = d日累计工时 - GetTableColSum(dtPC, sColName工时);
                            if (d当前剩余工时 <= 0)
                                continue;

                            decimal d生产总工时 = BaseFunction.BaseFunction.ReturnDecimal(d未排产数量 * d单件生产工时, 10);
                            //当该日工时充足,直接排产
                            if (d当前剩余工时 >= d生产总工时)
                            {
                                dtPC.Rows[i][sColName数量] = d未排产数量;
                                dtPC.Rows[i][sColName工时] = d生产总工时;
                                d未排产数量 = 0;
                                break;
                            }
                            else
                            {
                                //当该日工时不足,用剩余工时获得可生产数量排入当天,其余的排入下一天
                                decimal d当前可生产数量 = BaseFunction.BaseFunction.ReturnDecimal(d当前剩余工时 / d单件生产工时, 0);
                                dtPC.Rows[i][sColName数量] = d当前可生产数量;
                                dtPC.Rows[i][sColName工时] = d当前剩余工时;

                                d未排产数量 = d未排产数量 - d当前可生产数量;
                            }
                        }
                    }
                }

                if (sErr.Trim() != "")
                    throw new Exception(sErr);

                for (int i = 0; i < dtPC.Rows.Count; i++)
                {
                    decimal d当前页排产数量 = 0;

                    for (int j = 0; j < dtPC.Columns.Count; j++)
                    {
                        if (dtPC.Columns[j].ColumnName.Substring(0, 2) == "数量" && dtPC.Columns[j].ColumnName.Length == 8)
                        {
                            d当前页排产数量 = d当前页排产数量 + BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i][j]);
                        }
                    }

                    dtPC.Rows[i]["当前页面排产数量"] = d当前页排产数量;

                    decimal d未排产数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["计划数量"]) - BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["其他产线排产数量"]) - BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["完工数量"]) - d当前页排产数量;
                    dtPC.Rows[i]["未排产数量"] = d未排产数量;

                    if (d未排产数量 > 0)
                    {
                        dtPC.Rows[i]["排产说明"] = "计划未排完";
                    }
                    if (d未排产数量 < 0)
                    {
                        dtPC.Rows[i]["排产说明"] = "超计划";
                    }
                }
            }
            catch(Exception ee)
            {
                throw new Exception(ee.Message);
            }

            return dtPC;
        }

        /// <summary>
        /// 获得DataTable中某一列的值汇总
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sColName"></param>
        /// <returns></returns>
        public decimal GetTableColSum(DataTable dt, string sColName)
        {
            DataView dv = dt.DefaultView;
            decimal d = BaseFunction.BaseFunction.ReturnDecimal(dv.Table.Compute("sum(" + sColName + ")", ""),10);
            return d;
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
            string sSQL = "";
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                DateTime d当前日期 = DALGetBaseData.GetDatetimeSer();

                //历史记录表不存在则创建新表,历史表每个月一张
                string sTableName = "生产日计划历史" + dDate.ToString("yyMM");
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
	[iID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

";
                sSQL = sSQL.Replace("111111", sTableName);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {
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

                            sSQL = "select * from 生产日计划 where 产线 = '" + model.产线 + "' and 来源GUID = '" + model.来源GUID + "' and 计划生产日期 = '" + model.计划生产日期 + "'";
                            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

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
        /// 工时核查(含产线数据)
        /// </summary>
        /// <param name="dDate"></param>
        /// <param name="dtGrid"></param>
        /// <returns></returns>
        public DataTable GetLineWorkTime(DateTime dTime1, DateTime dTime2, string sLineNo, DataTable dtGrid)
        {
            if (sLineNo != null && sLineNo.Trim() != "")
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

                sSQL = sSQL.Replace("1=1", "1=1 and a.产线 <> '" + sLineNo + "'");

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
            else
            {
                string sCol = "";
                while (dTime1 <= dTime2)
                {
                    sCol = sCol + ",null as  工时" + dTime1.ToString("yyMMdd");
                    sCol = sCol + ",null as 人均工时" + dTime1.ToString("yyMMdd");

                    dTime1 = dTime1.AddDays(1);
                }

                string sSQL = @"
select b.[LineNo] as 产线编码,b.LineName as 产线,b.PeopleNO as 人数
	111111
from dbo.ProductionLine b 
group by b.[LineNo],b.LineName,b.PeopleNO
";
                sSQL = sSQL.Replace("111111", sCol);

                DataTable dt = DbHelperSQL.Query(sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string s产线编码 = dt.Rows[i]["产线编码"].ToString().Trim();
                    int iPeople = BaseFunction.BaseFunction.ReturnInt(dt.Rows[i]["人数"].ToString().Trim());

                    for (int j = 0; j < dtGrid.Columns.Count; j++)
                    {
                        string sName = dtGrid.Columns[j].ToString().Trim();
                        if (sName.Length == 8 && sName.Substring(0, 2) == "工时")
                        {
                            decimal d工时 = 0;

                            for (int k = 0; k < dtGrid.Rows.Count; k++)
                            {
                                string s产线编码2 = dtGrid.Rows[k]["产线编码"].ToString().Trim();
                                if (s产线编码 != s产线编码2)
                                    continue;


                                d工时 = d工时 + BaseFunction.BaseFunction.ReturnDecimal(dtGrid.Rows[k][sName], 2);
                            }
                            if (d工时 > 0)
                            {
                                dt.Rows[i][sName] = BaseFunction.BaseFunction.ReturnDecimal(d工时, 1);
                                if (iPeople == 0)
                                    iPeople = 1;
                                dt.Rows[i]["人均" + sName] = BaseFunction.BaseFunction.ReturnDecimal(d工时 / iPeople, 1);
                            }
                        }
                    }
                }
                return dt;
            }
            return null;
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
            string sCols2 = "";
            string sCols3 = "";
            DateTime dMinDate = GetPCMinDate(s排产日期);
            DateTime dMaxDate = GetPCMaxDate(s排产日期);

            DateTime dDate = dMinDate;
            string sDate = dDate.ToString("yyyy-MM-dd");
            int i = 0;
            while (dDate <= dMaxDate)
            {
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
from #a a inner join 888888 b on a.来源GUID = b.来源GUID
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

