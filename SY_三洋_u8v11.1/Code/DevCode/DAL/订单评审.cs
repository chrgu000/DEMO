using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
     

    /// <summary>
    /// 数据访问类:订单评审
    /// </summary>
    public partial class 订单评审
    {
        private readonly TH.DAL.GetBaseData dalBaseData = new TH.DAL.GetBaseData();
        DataTable dtWorkCalendar;



        public DataTable dtBom;

        string sBom = @"

select 0 as 序号,a.bomid
    ,cast(null as int) as 级别,cast('444444' as varchar(50)) as 顶级母件编码
	,g.cInvCode as 母件编码,g.cInvName as 母件名称,g.cInvAddCode as 母件代号,g.cInvStd as 母件规格
    ,j.cComUnitName as 母件计量单位,b.ParentScrap as 母件损耗率,a.Version as 版本代号
	,a.VersionDesc as 版本说明,a.VersionEffDate as 版本日期,case a.Status when 1 then '新建' when 3 then '审核' when 4 then '停用' end as 状态
	,case when ISNULL(g.bSelf,0) = 1 then '自制' when ISNULL(g.bProxyForeign,0) = 1 then '委外' end as 母件属性
	,a.ApplyDId as 变更单号,'' as 行号,c.SortSeq as 子件行号,c.OpSeq as 工序行号
	,i.cInvCode as 子件编码,i.cInvName as 子件名称,i.cInvAddCode as 子件代号,i.cInvStd as 子件规格,k.cComUnitName as 子件计量单位
	,c.BaseQtyN as 基本用量,c.BaseQtyD as 基础用量,c.CompScrap as 子件损耗率,case isnull(FVFlag,0) when 0 then '是' when 1 then '否' end as 固定用量,c.ChangeRate as 换算率
	,case d.WIPType when 1 then '入库倒冲' when 2 then '工序领用' when 3 then '领用' when 4 then '虚拟件' end as 供应类型
	,c.BaseQtyN/c.BaseQtyD/(1-isnull(b.ParentScrap,0))*(1+isnull(c.CompScrap,0)) as 单阶使用数量,cast(null as decimal(16,6)) as 加成数量
	,c.EffBegDate as 子件生效日,c.EffEndDate as 子件失效日,d.Offset as 偏置期,d.PlanFactor as 计划比例,case isnull(c.ByproductFlag,0) when 0 then '否' else '是' end as 产出品
	,case isnull(c.ProductType,0) when 2 then '联产品' when 3 then '副产品' end as 产出类型,case ISNULL(d.AccuCostFlag,0) when 0 then  '否' else '是' end as 成本相关
	,case isnull(d.OptionalFlag,0) when 0 then '否' else '是' end as 可选否,'任意' as 选择规则,c.Remark as 备注
	,case when ISNULL(i.bSelf,0) = 1 then '自制' when ISNULL(i.bProxyForeign,0) = 1 then '委外' when ISNULL(i.bPurchase,0) = 1 then '采购' end as 子件属性
    ,cast(null as varchar(300)) as 母子关联
    ,'111111' as 销售订单号,'222222' as 销售订单行号,333333 as 销售订单子表ID
    ,cast(null as decimal(16,6)) as 需求数量,cast(null as decimal(16,6)) as 评审数量,cast(null as decimal(16,6)) as 本单需求数量,cast(null as datetime) as 交货日期,cast(null as datetime) as 开始日期,cast(null as datetime) as 结束日期
    ,cast(l.cidefine1 as int) as 评审采购周期,cast(l.cidefine2 as int) as 评审委外周期,cast( l.cidefine3 / isnull(l.cidefine6,1) as decimal(16,10)) as 单件默认生产工时,l.cidefine4 默认产线,cast(l.cidefine5 as int) as 质检周期
    ,cast( l.cidefine3 / isnull(l.cidefine6,1) as decimal(16,10)) * 555555 as 生产合计工时
    ,cast(l.cidefine7 as  decimal(16,2)) as 生产准备时间,cast(l.cidefine8 as  decimal(16,2)) as 经济批量
    ,case when ISNULL(i.bSelf,0) = 1 then cast (null as int) when ISNULL(i.bProxyForeign,0) = 1 then cast(l.cidefine2 as int) when ISNULL(i.bPurchase,0) = 1 then cast(l.cidefine1 as int) end as 置办周期
    ,isnull(n.PeopleNO,1) as 默认产线并发生产数
    ,cast(null as  decimal(16,6)) as 仓库存量,cast(null as  decimal(16,6)) as 待入库数量,cast(l.cidefine8 as  decimal(16,6)) as 待出库数量
    ,'666666' as 销售单号
    ,cast (null as uniqueidentifier) as GUID,cast (null as uniqueidentifier) as GUIDHead
    ,d.Whcode as 仓库编码,m.cWhName as 仓库名称,d.DrawDeptCode as 领料部门编码,i.cInvDepCode as 生产部门编码
    ,cast (null as varchar(50)) as 评审单据号,null as iID
from @u8.bom_bom a inner join @u8.bom_parent b on a.bomid = b.BomId 
    inner join @u8.bas_part f on f.PartId = b.ParentId
    inner join @u8.Inventory g on g.cinvcode = f.invcode
	inner join @u8.bom_opcomponent c on a.bomid = c.bomid
    inner join @u8.bas_part h on h.partid = c.ComponentId 
    inner join @u8.Inventory i on i.cinvcode = h.invcode
	left join @u8.bom_opcomponentopt d on d.OptionsId = c.OpComponentId
	left join @u8.bom_opcomponentloc e on e.OpComponentId = d.OptionsId
    left join @u8.ComputationUnit j on j.cComunitCode = g.cComUnitCode
	left join @u8.ComputationUnit k on k.cComunitCode = i.cComUnitCode
    left join @u8.Inventory_extradefine l on l.cInvCode = i.cInvCode 
    left join @u8.Warehouse m on m.cWhCode = d.Whcode
    left join dbo.ProductionLine n on n.[LineNo] = l.cidefine4

where 1=-1 and a.Status = 3
order by c.SortSeq,g.cInvCode,i.cInvCode
";


        /// <summary>
        /// BOM逆排
        /// </summary>
        public DataTable dtInitBomN = new DataTable();

        public 订单评审()
        {
            dtWorkCalendar = GetWorkCalendar(DateTime.Today.Year);


            //string sSQL = sBom;
            //dtBom = DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 订单展开
        /// 1. 逐行循环销售订单列表
        /// 2. 将产品编码递归运算获得数量及日期
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable GetBomAll(DataTable dt, out string sErrInfo,string sPCCode)
        {

            dtWorkCalendar = GetWorkCalendar(DateTime.Today.Year);
            DataTable dtBomAllTemp = new DataTable();
            sErrInfo = "";
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sSQL = sBom;
                    dtBom = DbHelperSQL.Query(sSQL);

                    string sInvCode = dt.Rows[i]["存货编码"].ToString().Trim();
                    string s销售订单号 = dt.Rows[i]["销售订单号"].ToString().Trim();
                    string s行号 = dt.Rows[i]["行号"].ToString().Trim();
                    long l订单子表ID = Convert.ToInt64(dt.Rows[i]["销售订单子表ID"]);
                    string s顶级母件编码 = sInvCode;
                    DateTime d交货日期 = Convert.ToDateTime(dt.Rows[i]["交货日期"]);
                    decimal d数量 = Convert.ToDecimal(dt.Rows[i]["数量"]);

                    GetBom多阶(sInvCode, 1, 1, sInvCode, s销售订单号, s行号, l订单子表ID, s顶级母件编码, d数量, d交货日期);
                    DataTable dtBomTemp = dtBom.Copy();

                    DataTable dt存货 = dalBaseData.GetInventory("and cInvCode = '" + sInvCode + "'");
                    DataTable dt存货扩展自定义项 = dalBaseData.GetInventory_extradefine("and cInvCode = '" + sInvCode + "'");

                    DataRow[] drTemp = dtBomTemp.Select("顶级母件编码 = 母件编码");
                    if (drTemp.Length > 0)
                    {
                        DataRow dr = dtBomTemp.NewRow();
                        dr["序号"] = 0;
                        dr["级别"] = 0;
                        dr["顶级母件编码"] = sInvCode;
                        dr["母件编码"] = "--";
                        dr["母件名称"] = "--";
                        dr["母件规格"] = "--";
                        dr["子件编码"] = drTemp[0]["母件编码"];
                        dr["子件名称"] = drTemp[0]["母件名称"];
                        dr["子件规格"] = drTemp[0]["母件规格"];
                        dr["子件计量单位"] = drTemp[0]["母件计量单位"];
                        dr["子件属性"] = drTemp[0]["母件属性"];
                        dr["母子关联"] = "--";
                        dr["销售订单号"] = drTemp[0]["销售订单号"];
                        dr["销售订单行号"] = drTemp[0]["销售订单行号"];
                        dr["销售订单子表ID"] = drTemp[0]["销售订单子表ID"];
                        dr["需求数量"] = dt.Rows[i]["待评审数量"];
                        dr["本单需求数量"] = dt.Rows[i]["待评审数量"];
                        dr["评审数量"] = d数量;
                        dr["结束日期"] = d交货日期;
                        dr["销售单号"] = drTemp[0]["销售订单号"].ToString().Trim() + "【" + drTemp[0]["销售订单行号"].ToString().Trim() + "】";
                        dr["加成数量"] = 1;
                        dr["单阶使用数量"] = 1;

                        if (dt存货扩展自定义项 != null && dt存货扩展自定义项.Rows.Count > 0)
                        {
                            dr["评审采购周期"] = dt存货扩展自定义项.Rows[0]["ciDefine1"];
                            dr["评审委外周期"] = dt存货扩展自定义项.Rows[0]["ciDefine2"];

                            decimal d单件生产工时基数 = BaseFunction.BaseFunction.ReturnDecimal(dt存货扩展自定义项.Rows[0]["ciDefine6"], 1, 1);
                            decimal d单件默认生产工时 = BaseFunction.BaseFunction.ReturnDecimal(dt存货扩展自定义项.Rows[0]["ciDefine3"], 6);
                            dr["单件默认生产工时"] = BaseFunction.BaseFunction.ReturnDecimal(d单件默认生产工时 / d单件生产工时基数, 10);
                            dr["默认产线"] = dt存货扩展自定义项.Rows[0]["ciDefine4"];
                            dr["生产准备时间"] = dt存货扩展自定义项.Rows[0]["ciDefine7"];
                            dr["经济批量"] = dt存货扩展自定义项.Rows[0]["ciDefine8"];

                            DataTable dt产线 = dalBaseData.GetProductionLine(" and [LineNo] = '" + dr["默认产线"].ToString().Trim() + "'");
                            if (dt产线 != null && dt产线.Rows.Count > 0)
                            {
                                dr["默认产线并发生产数"] = BaseFunction.BaseFunction.ReturnInt(dt产线.Rows[0]["PeopleNO"], 1);
                            }

                            switch (dr["子件属性"].ToString().Trim())
                            {
                                case "自制":
                                    dr["生产合计工时"] = BaseFunction.BaseFunction.ReturnDecimal(dr["单件默认生产工时"], 10) * d数量 + BaseFunction.BaseFunction.ReturnDecimal(dr["生产准备时间"]);
                                    dr["置办周期"] = DBNull.Value;
                                    dr["生产部门编码"] = dt存货.Rows[0]["cInvDepCode"].ToString().Trim();
                                    break;
                                case "采购":
                                    dr["置办周期"] = dr["评审采购周期"];
                                    break;
                                case "委外":
                                    dr["置办周期"] = dr["评审委外周期"];
                                    break;
                            }

                        }
                        dtBomTemp.Rows.InsertAt(dr, 0);
                    }

                    if (dtBomAllTemp == null || dtBomAllTemp.Rows.Count == 0)
                    {
                        dtBomAllTemp = dtBomTemp.Copy();
                        dtBom = null;
                    }
                    else
                    {
                        object[] objArray = new object[dtBomAllTemp.Columns.Count];
                        for (int j = 0; j < dtBomTemp.Rows.Count; j++)
                        {
                            dtBomTemp.Rows[j].ItemArray.CopyTo(objArray, 0);            //将表的一行的值存放数组中。
                            dtBomAllTemp.Rows.Add(objArray);                            //将数组的值添加到新表中。
                        }
                        dtBom = null;
                    }
                }
                Get供需分析(dtBomAllTemp, sPCCode);

                dtInitBomN = dtBomAllTemp.Copy();
                for (int i = 0; i < dtBomAllTemp.Rows.Count; i++)
                {
                    string sInvCode = dtBomAllTemp.Rows[i]["母件编码"].ToString().Trim();
                    if (sInvCode == "--")
                    {
                        string scInvCode = dtBomAllTemp.Rows[i]["子件编码"].ToString().Trim();
                        string sMZ = dtBomAllTemp.Rows[i]["母子关联"].ToString().Trim();
                        string sSaleRow = dtBomAllTemp.Rows[i]["销售单号"].ToString().Trim();
                        decimal dQty = BaseFunction.BaseFunction.ReturnDecimal(dtBomAllTemp.Rows[i]["需求数量"].ToString().Trim());
                        DateTime dTime = Convert.ToDateTime(dtBomAllTemp.Rows[i]["结束日期"]);

                        GetInitBomAddN(sSaleRow, sInvCode, sMZ, dQty, dTime);
                    }
                }

                dtBomAllTemp = dtInitBomN.Copy();
            }
            catch (Exception ee)
            {
                sErrInfo = sErrInfo + ee.Message + "\n";
                throw new Exception(ee.Message);
            }


            return dtBomAllTemp;
        }

        public void GetInitBomAddN(string sSaleRow, string sInvCode, string sMZ, decimal dQty, DateTime dTime)
        {
            try
            {
                string sWhere = " 母件编码 = '" + sInvCode + "' and 母子关联 like '" + sMZ + "%' and 销售单号 = '" + sSaleRow + "'";

                DataRow[] drList = dtInitBomN.Select(sWhere);

                foreach (DataRow dr in drList)
                {
                    decimal d当前物料累计下单 = 0;
                    decimal d累计下单 = 0;
                    for (int i = 0; i < dtInitBomN.Rows.Count; i++)
                    {
                        string s本次下单 = dtInitBomN.Rows[i]["本单需求数量"].ToString().Trim();
                        if (s本次下单.Length == 0)
                            continue;
                        string s子件编码 = dtInitBomN.Rows[i]["子件编码"].ToString().Trim();
                        if (s子件编码 != dr["子件编码"].ToString().Trim())
                            continue;
                        decimal d1 = BaseFunction.BaseFunction.ReturnDecimal(dtInitBomN.Rows[i]["本单需求数量"]);
                        decimal d2 = BaseFunction.BaseFunction.ReturnDecimal(dtInitBomN.Rows[i]["需求数量"]);
                        d当前物料累计下单 = d当前物料累计下单 + d2 - d1;
                        d累计下单 = d累计下单 + d1;
                    }

                    string sLineNO = dr["默认产线"].ToString().Trim();
                    decimal d需求数量 = decimal.Round(dQty * BaseFunction.BaseFunction.ReturnDecimal(dr["单阶使用数量"]), 6);
                    decimal d现存量 = BaseFunction.BaseFunction.ReturnDecimal(dr["仓库存量"]);
                    if (d现存量 <= BaseFunction.BaseFunction.ReturnDecimal(0.000001))
                        d现存量 = 0;

                    decimal d待入库 = BaseFunction.BaseFunction.ReturnDecimal(dr["待入库数量"]);
                    decimal d待出库 = BaseFunction.BaseFunction.ReturnDecimal(dr["待出库数量"]);
                    decimal d经济批量 = BaseFunction.BaseFunction.ReturnDecimal(dr["经济批量"]);
                    //decimal d调整数量 = BaseFunction.BaseFunction.ReturnDecimal(dr["调整数量"]);
                    decimal d调整数量 = 0;
                    decimal d当前行可用量 = d现存量 + d待入库 - d待出库 - d当前物料累计下单 - d调整数量;
                    decimal d本单需求数量 = 0;

                    dr["需求数量"] = d需求数量;

                    if (d需求数量 == 0)
                    {
                        d本单需求数量 = 0;
                    }
                    else
                    {
                        if (d需求数量 > d当前行可用量)
                        {
                            d本单需求数量 = d需求数量 - d当前行可用量;
                            if (d累计下单 + d本单需求数量 < d经济批量)
                            {
                                d本单需求数量 = d经济批量;
                            }
                        }
                        else
                            d本单需求数量 = 0;
                    }

                    //销售订单物料,如果本单需求数量超过订单数量,则采用订单数量
                    //if (sInvCode == "--" && d本单需求数量 > d需求数量)
                    //{
                    //    d本单需求数量 = d需求数量;
                    //}
                    if (sInvCode == "--")
                    {
                        d本单需求数量 = d需求数量;
                    }
                    dr["本单需求数量"] = d本单需求数量;

                    int i周期 = 0;
                    if (d本单需求数量 > 0)
                    {
                        int i质检 = BaseFunction.BaseFunction.ReturnInt(dr["质检周期"]);

                        DateTime d结束日期 = dTime;
                        if (sInvCode == "--")
                        {
                            d结束日期 = dTime;
                        }
                        else
                        {
                            d结束日期 = dTime.AddDays(-1 * i质检).AddDays(-1);
                        }
                        dr["结束日期"] = d结束日期;

                        if (dr["子件属性"].ToString().Trim() == "自制")
                        {
                            if (sLineNO != "99")
                            {
                                decimal d生产合计工时 = BaseFunction.BaseFunction.ReturnDecimal(dr["单件默认生产工时"]) * d本单需求数量;
                                if (d生产合计工时 == 0 && sInvCode != "--")
                                {
                                    //未设置生产档案的自制属性物料，在BOM如果有下一层则报错
                                    string sWhereTemp = " 母件编码 = '" + dr["子件编码"].ToString().Trim() + "' and 销售单号 = '" + sSaleRow + "'";
                                    DataRow[] drListTemp = dtInitBomN.Select(sWhereTemp);
                                    if (drListTemp.Length > 0)
                                    {
                                        throw new Exception("存货 " + dr["子件编码"].ToString().Trim() + " 未设置生产档案");
                                    }
                                }

                                dr["生产合计工时"] = d生产合计工时;
                                decimal d产线并发生产 = BaseFunction.BaseFunction.ReturnDecimal(dr["默认产线并发生产数"], 1, 0);


                                decimal d产线占用时间 = d生产合计工时 / d产线并发生产;
                                decimal d生产准备时间 = BaseFunction.BaseFunction.ReturnDecimal(dr["生产准备时间"]);
                                decimal d生产共需要时间 = d产线占用时间 + d生产准备时间;


                                dr["置办周期"] = GetTimeN(d本单需求数量, d结束日期, d产线并发生产, BaseFunction.BaseFunction.ReturnDecimal(dr["单件默认生产工时"]), sLineNO);
                            }
                            else
                            {
                                dr["置办周期"] = 1;
                            }
                        }
                        i周期 = BaseFunction.BaseFunction.ReturnInt(dr["置办周期"]);
                    }
                    else
                    {
                        dr["结束日期"] = dTime;
                    }

                    if (dr["子件属性"].ToString().Trim() != "采购")
                    {
                        if (i周期 >= 1)
                            i周期 = i周期 - 1;

                        dr["开始日期"] = Convert.ToDateTime(dr["结束日期"]).AddDays(-1 * i周期);
                        GetInitBomAddN(sSaleRow, dr["子件编码"].ToString().Trim(), dr["母子关联"].ToString().Trim(), BaseFunction.BaseFunction.ReturnDecimal(dr["本单需求数量"]), Convert.ToDateTime(Convert.ToDateTime(dr["开始日期"]).ToString("yyyy-MM-dd")));
                    }
                    else
                    {
                        dr["开始日期"] = DBNull.Value;
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 编辑状态逆排计划
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">母件编码</param>
        /// <param name="sInvCode2">母子对应</param>
        /// <param name="dQty">母件下单数量</param>
        /// <param name="dDate1">计划结束日期</param>
        /// <param name="i行号">销售订单行号</param>
        public void GetInitBomEditN(string sInvCode, string sMZ, decimal dQty, DateTime dDate1, string sSaleRow,string sPCCode)
        {
            try
            {
                DataRow[] drList = dtInitBomN.Select(" 母件编码 = '" + sInvCode + "' and 销售单号 = '" + sSaleRow + "' and 母子关联 like '" + sMZ + "%'");

                foreach (DataRow dr in drList)
                {
                    decimal d当前物料累计下单 = 0;
                    decimal d当前物料累计需求 = 0;

                    for (int i = 0; i < dtInitBomN.Rows.Count; i++)
                    {
                        string s本次下单 = dtInitBomN.Rows[i]["本单需求数量"].ToString().Trim();
                        if (s本次下单.Length == 0)
                            continue;
                        string s子件编码 = dtInitBomN.Rows[i]["子件编码"].ToString().Trim();
                        if (s子件编码 == dr["子件编码"].ToString().Trim())
                        {
                            decimal d1 = BaseFunction.BaseFunction.ReturnDecimal(dtInitBomN.Rows[i]["本单需求数量"]);
                            d当前物料累计下单 = d当前物料累计下单 + d1;
                            decimal d2 = BaseFunction.BaseFunction.ReturnDecimal(dtInitBomN.Rows[i]["需求数量"]);
                            d当前物料累计需求 = d当前物料累计需求 + d2;
                        }
                    }

                    string sLineNO = dr["默认产线"].ToString().Trim();
                    decimal d当前需求 = BaseFunction.BaseFunction.ReturnDecimal(dr["需求数量"]);
                    decimal d当前下单 = BaseFunction.BaseFunction.ReturnDecimal(dr["本单需求数量"]);
                    d当前物料累计需求 = d当前物料累计需求 - d当前需求;
                    d当前物料累计下单 = d当前物料累计下单 - d当前下单;

                    string s当前子件编码 = dr["子件编码"].ToString().Trim();
                    DataTable dt供需分析 = Get物料供需分析汇总(s当前子件编码, sPCCode);
                    decimal d现存量 = 0;
                    decimal d待入库 = 0;
                    decimal d待出库 = 0;
                    if (dt供需分析 != null && dt供需分析.Rows.Count > 0)
                    {
                        d现存量 = BaseFunction.BaseFunction.ReturnDecimal(dt供需分析.Rows[0]["现存量"]);
                        d待入库 = BaseFunction.BaseFunction.ReturnDecimal(dt供需分析.Rows[0]["待入库"]);
                        d待出库 = BaseFunction.BaseFunction.ReturnDecimal(dt供需分析.Rows[0]["待出库"]);

                        dr["仓库存量"] = d现存量;
                        dr["待入库数量"] = d待入库;
                        dr["待出库数量"] = d待出库;
                    }

                    decimal d经济批量 = BaseFunction.BaseFunction.ReturnDecimal(dr["经济批量"]);
                    //decimal d调整数量 = BaseFunction.BaseFunction.ReturnDecimal(dr["调整数量"]);
                    decimal d调整数量 = 0;
                    decimal d当前行可用量 = d现存量 - d调整数量 + d待入库 - d待出库 - (d当前物料累计需求 - d当前物料累计下单);
                    decimal d本单需求数量 = 0;

                    decimal d需求数量 = BaseFunction.BaseFunction.ReturnDecimal(dQty * BaseFunction.BaseFunction.ReturnDecimal(dr["单阶使用数量"]), 6);
                    dr["需求数量"] = d需求数量;
                    if (d需求数量 == 0)
                    {
                        d本单需求数量 = 0;
                    }
                    else
                    {
                        if (d需求数量 > d当前行可用量)
                        {
                            d本单需求数量 = d需求数量 - d当前行可用量;
                            if (d当前物料累计下单 < d经济批量)
                            {
                                d本单需求数量 = d经济批量;
                            }
                        }
                        else
                            d本单需求数量 = 0;
                    }
                    dr["本单需求数量"] = d本单需求数量;

                    int i置办周期 = 0;
                    int i质检周期 = 0;
                    int i周期 = 0;


                    if (d本单需求数量 > 0)
                    {
                        if (dr["子件属性"].ToString().Trim() == "自制")
                        {
                            decimal d生产合计工时 = BaseFunction.BaseFunction.ReturnDecimal(dr["单件默认生产工时"]) * d本单需求数量;
                            decimal d产线并发生产 = BaseFunction.BaseFunction.ReturnDecimal(dr["默认产线并发生产数"], 1, 1);
                            dr["生产合计工时"] = d生产合计工时;
                            decimal d产线占用时间 = d生产合计工时 / d产线并发生产;

                            decimal d生产准备时间 = BaseFunction.BaseFunction.ReturnDecimal(dr["生产准备时间"]);
                            decimal d生产共需要时间 = d产线占用时间 + d生产准备时间;
                            //i置办周期 = GetiTimeN(dDate1, d生产共需要时间);
                            i置办周期 = GetTimeN(d本单需求数量, dDate1, d产线并发生产, BaseFunction.BaseFunction.ReturnDecimal(dr["单件默认生产工时"]), sLineNO);
                            dr["置办周期"] = i置办周期;
                        }
                        else
                        {
                            i置办周期 = BaseFunction.BaseFunction.ReturnInt(dr["置办周期"]);
                        }

                        i质检周期 = BaseFunction.BaseFunction.ReturnInt(dr["质检周期"]);

                        i周期 = i置办周期 + i质检周期 - 1;
                        DateTime d结束日期 = dDate1.AddDays(-1 * i质检周期).AddDays(-1);
                        dr["结束日期"] = d结束日期;

                        if (dr["子件属性"].ToString().Trim() != "采购")
                        {
                            if (i置办周期 >= 1)
                                i置办周期 = i置办周期 - 1;
                            dr["开始日期"] = d结束日期.AddDays(-1 * i置办周期);
                        }
                        else
                        {
                            dr["开始日期"] = DBNull.Value;
                        }
                    }
                    else
                    {
                        i周期 = 0;
                        dr["结束日期"] = dDate1;
                        dr["开始日期"] = dDate1;
                    }

                    string s母子关联 = dr["母子关联"].ToString().Trim() + "→" + dr["子件编码"].ToString().Trim();
                    GetInitBomEditN(dr["子件编码"].ToString().Trim(), s母子关联, BaseFunction.BaseFunction.ReturnDecimal(dr["本单需求数量"]), BaseFunction.BaseFunction.ReturnDate(dr["开始日期"]), sSaleRow, sPCCode);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 编辑状态顺排计划
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">子件编码</param>
        /// <param name="dQty">本次下单数量</param>
        /// <param name="dDate1">计划开始日期</param>
        public void GetInitEditS(string sInvCode, string s母子关联, DateTime dDate1, string sSaleRow)
        {
            try
            {
                DataRow[] drList = dtInitBomN.Select(" 子件编码 = '" + sInvCode + "'  and 销售单号 = '" + sSaleRow + "' and 母子关联 = '" + s母子关联 + "'");
                while (drList.Length == 0)
                {
                    int iLast = s母子关联.LastIndexOf("→");
                    if (iLast > 0)
                    {
                        s母子关联 = s母子关联.Substring(0, iLast);
                        drList = dtInitBomN.Select(" 子件编码 = '" + sInvCode + "'  and 销售单号 = '" + sSaleRow + "' and 母子关联 = '" + s母子关联 + "'");
                    }
                    else
                    {
                        break;
                    }

                }

                //日期减少时，确保使用同阶最大日期来推算，避免产品提前至其子件之前
                DataRow[] drList2 = dtInitBomN.Select(" 母件编码 = '" + sInvCode + "'  and 销售单号 = '" + sSaleRow + "' and 母子关联 = '" + s母子关联 + "→" + sInvCode + "'");
                foreach (DataRow dr in drList2)
                {
                    DateTime d1 = BaseFunction.BaseFunction.ReturnDate(dr["结束日期"]).AddDays(1);
                    int i质检周期 = BaseFunction.BaseFunction.ReturnInt(dr["质检周期"]);      //作为母件的开工时间，必须考虑子件的质检周期
                    d1 = d1.AddDays(i质检周期);

                    if (dDate1 < d1)
                        dDate1 = d1;
                }

                foreach (DataRow dr in drList)
                {
                    int i置办周期 = 0;
                    int i周期 = 0;
                    int i质检周期 = 0;
                    decimal d本单需求数量 = BaseFunction.BaseFunction.ReturnDecimal(dr["本单需求数量"]);
                    if (d本单需求数量 > 0)
                    {
                        if (dr["子件属性"].ToString().Trim() == "自制")
                        {
                            decimal d单件默认生产工时 = BaseFunction.BaseFunction.ReturnDecimal(dr["单件默认生产工时"]);
                            decimal d生产合计工时 = d单件默认生产工时 * d本单需求数量;
                            decimal d产线并发生产 = BaseFunction.BaseFunction.ReturnDecimal(dr["默认产线并发生产数"], 1, 1);
                            dr["生产合计工时"] = d生产合计工时;
                            decimal d产线占用时间 = d生产合计工时 / d产线并发生产;

                            decimal d生产准备时间 = BaseFunction.BaseFunction.ReturnDecimal(dr["生产准备时间"]);
                            decimal d生产共需要时间 = d产线占用时间 + d生产准备时间;

                            string sLineNo = dr["默认产线"].ToString().Trim();
                            i置办周期 = GetTimeS(d本单需求数量, dDate1, d产线并发生产, d单件默认生产工时, sLineNo);
                            dr["置办周期"] = i置办周期;
                        }
                        else
                        {
                            i置办周期 = BaseFunction.BaseFunction.ReturnInt(dr["置办周期"]);
                        }

                        i质检周期 = BaseFunction.BaseFunction.ReturnInt(dr["质检周期"]);

                        if (i置办周期 >= 1)
                            i置办周期 -= 1;

                        i周期 = i置办周期 + i质检周期;

                        dr["开始日期"] = dDate1;
                        dr["结束日期"] = dDate1.AddDays(i置办周期);
                    }
                    else
                    {
                        dr["开始日期"] = dDate1;
                        dr["结束日期"] = dDate1;
                    }
                    string s母子 = dr["母子关联"].ToString().Trim();
                    int iLast = s母子.LastIndexOf("→");
                    if (iLast > 0)
                    {
                        s母子 = s母子.Substring(0, iLast);
                        GetInitEditS(dr["母件编码"].ToString().Trim(), s母子, Convert.ToDateTime(Convert.ToDateTime(dr["结束日期"]).ToString("yyyy-MM-dd")).AddDays(1).AddDays(i质检周期), sSaleRow);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        public int GetTimeN(decimal dQty, DateTime dEndDate, decimal d产线并发, decimal d单件生产工时, string sLineNo)
        {
            int iDays = 0;
            try
            {
                while (dQty > 0)
                {
                    DataRow[] dr = dtWorkCalendar.Select("iYear = " + dEndDate.Year + " and iMonth = " + dEndDate.Month + " and [LineNo] = '" + sLineNo + "' ");
                    int iDayTime = GetDayTime();

                    if (dr.Length > 0 && BaseFunction.BaseFunction.ReturnInt(dr[0]["i" + dEndDate.Day.ToString()]) > 0)
                    {
                        if (dEndDate > BaseFunction.BaseFunction.ReturnDate("2014-1-1"))
                        {
                            iDayTime = BaseFunction.BaseFunction.ReturnInt(dr[0]["i" + dEndDate.Day.ToString()]);
                        }
                    }

                    //休息日不排产（日工时为0）
                    if (iDayTime > 0)
                    {
                        decimal d日产量 = 0;

                        if (d单件生产工时 != 0)
                        {
                            d日产量 = BaseFunction.BaseFunction.ReturnDecimal(d产线并发 * iDayTime / d单件生产工时, 2);
                        }
                        else
                        {
                            //当未设置生产工时时默认产能无限大,在前台颜色标示
                            d日产量 = 99999999;
                        }

                        if (dQty >= d日产量)
                        {
                            dQty = dQty - d日产量;
                        }
                        else
                        {
                            dQty = 0;
                        }
                    }
                    iDays += 1;
                    dEndDate = dEndDate.AddDays(-1);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("逆排日期超出工作日历:" + ee.Message);
            }
            return iDays;
        }
        public int GetTimeS(decimal dQty, DateTime dStartDate, decimal d产线并发, decimal d单件生产工时, string sLineNo)
        {
            int iDays = 0;
            try
            {
                while (dQty > 0)
                {
                    DataRow[] dr = dtWorkCalendar.Select("iYear = " + dStartDate.Year + " and iMonth = " + dStartDate.Month + " and [LineNo] = '" + sLineNo + "' ");
                    int iDayTime = GetDayTime();
                    if (dr.Length > 0 && BaseFunction.BaseFunction.ReturnInt(dr[0]["i" + dStartDate.Day.ToString()]) > 0)
                    {
                        iDayTime = BaseFunction.BaseFunction.ReturnInt(dr[0]["i" + dStartDate.Day.ToString()]);
                    }

                    //休息日不排产（日工时为0）
                    if (iDayTime > 0)
                    {
                        decimal d日产量 = BaseFunction.BaseFunction.ReturnDecimal(d产线并发 * iDayTime / d单件生产工时, 2);

                        if (dQty >= d日产量)
                        {
                            dQty = dQty - d日产量;
                        }
                        else
                        {
                            dQty = 0;
                        }
                    }
                    iDays += 1;
                    dStartDate = dStartDate.AddDays(1);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            return iDays;
        }
        /// <summary>
        /// 工作日历(逆排)
        /// </summary>
        /// <param name="dEndDate">结束日期</param>
        /// <param name="dWorkTime">生产工时（小时）</param>
        /// <returns></returns>
        public int GetiTimeN(DateTime dEndDate, decimal dWorkTime, string sLineNo)
        {
            int iWorkTime = BaseFunction.BaseFunction.ReturnInt(Math.Ceiling(dWorkTime));
            int iDays = 0;
            for (int i = 0; i <= iWorkTime; i++)
            {
                decimal dDayWorkTime = GetDayTime();
                DataRow[] dr = dtWorkCalendar.Select("iYear = " + dEndDate.Year + " and iMonth = " + dEndDate.Month + " and [LineNo] = '" + sLineNo + "' ");
                //if (dr.Length == 0 && dEndDate >= DateTime.Today)
                //{
                //    throw new Exception("请设定工作日历");
                //}

                if (dEndDate > Convert.ToDateTime("2014-1-1"))
                {
                    dDayWorkTime = BaseFunction.BaseFunction.ReturnDecimal(dr[0]["i" + dEndDate.Day.ToString()]);
                }
                dEndDate.AddDays(-1);


                dEndDate.AddDays(-1);
                if (dWorkTime > dDayWorkTime)
                {
                    dWorkTime = dWorkTime - dDayWorkTime;
                    iDays += 1;
                }
                else if (dWorkTime == dDayWorkTime)
                {
                    dWorkTime = 0;
                    iDays += 1;
                    break;
                }
                else
                {
                    dWorkTime = 0;
                    iDays += 1;
                    break;
                }
            }

            return iDays;
        }

        ///// <summary>
        ///// 工作日历(顺排)
        ///// </summary>
        ///// <param name="dStartDate">开始日期</param>
        ///// <param name="dWorkTime">生产工时（小时）</param>
        ///// <returns></returns>
        //public int GetiTimeS(DateTime dStartDate, decimal dWorkTime, string sLineNo)
        //{
        //    int iWorkTime = BaseFunction.BaseFunction.ReturnInt(Math.Ceiling(dWorkTime));
        //    int iDays = 0;
        //    for (int i = 0; i <= iWorkTime; i++)
        //    {
        //        decimal dDayWorkTime = GetDayTime();
        //        DataRow[] dr = dtWorkCalendar.Select("iYear = " + dStartDate.Year + " and iMonth = " + dStartDate.Month + " and [LineNo] = '" + sLineNo + "' ");
        //        if (dr.Length == 0)
        //        {
        //            throw new Exception("请设定工作日历");
        //        }

        //        dDayWorkTime = BaseFunction.BaseFunction.ReturnDecimal(dr[0]["i" + dStartDate.Day.ToString()]);

        //        dStartDate.AddDays(1);

        //        if (dWorkTime > dDayWorkTime)
        //        {
        //            dWorkTime = dWorkTime - dDayWorkTime;
        //            iDays += 1;
        //        }
        //        else if (dWorkTime == dDayWorkTime)
        //        {
        //            dWorkTime = 0;
        //            iDays += 1;
        //            break;
        //        }
        //        else
        //        {
        //            dWorkTime = 0;
        //            iDays += 1;
        //            break;
        //        }
        //    }

        //    return iDays;
        //}

        #region 待删除
        
        ///// <summary>
        ///// 获得销售订单数据列表
        ///// </summary>
        //public DataTable GetSoMainList(string strWhere)
        //{
        //    return GetSoMainList(strWhere);
        //}

        //public DataTable GetSoCode(string strWhere)
        //{
        //    return dalBaseData.GetSoCode("");
        //}

        //public DataTable GetPSCode(string strWhere)
        //{
        //    return GetPSCode(strWhere);
        //}


        ///// <summary>
        ///// 根据单据号获得单据信息
        ///// </summary>
        ///// <param name="sPSCode"></param>
        ///// <returns></returns>
        //public DataTable GetPSListHead(string sPSCode)
        //{
        //    return GetPSListHead(sPSCode);
        //}
        ///// <summary>
        ///// 根据单据号获得单据信息
        ///// </summary>
        ///// <param name="sPSCode"></param>
        ///// <returns></returns>
        //public DataTable GetPSListDetail(string sPSCode)
        //{
        //    return GetPSListDetail(sPSCode);
        //}
        ///// <summary>
        ///// 根据单据号获得单据信息
        ///// </summary>
        ///// <param name="sPSCode"></param>
        ///// <returns></returns>
        //public DataTable GetPSListHead(string sPSCode,string sTrWhere)
        //{
        //    return GetPSListHead(sPSCode, sTrWhere);
        //}
        ///// <summary>
        ///// 根据单据号获得单据信息
        ///// </summary>
        ///// <param name="sPSCode"></param>
        ///// <returns></returns>
        //public DataTable GetPSListDetail(string sPSCode, string sTrWhere)
        //{
        //    return GetPSListDetail(sPSCode, sTrWhere);
        //}

        //public TH.Model.订单评审 DataRowToModel(DataRow row, DataTable dtDetail,string sPSCode)
        //{
        //    return DataRowToModel(row, dtDetail, sPSCode);
        //}

        //#region  BasicMethod


        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(Guid Guid)
        //{
        //    return Exists(Guid);
        //}

        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public bool Add(TH.Model.订单评审 model)
        //{
        //    return Add(model);
        //}

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(TH.Model.订单评审 model)
        //{
        //    return Update(model);
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(Guid Guid)
        //{

        //    return Delete(Guid);
        //}
        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool DeleteList(string Guidlist)
        //{
        //    return DeleteList(Guidlist);
        //}

        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public TH.Model.订单评审 GetModel(Guid Guid)
        //{

        //    return GetModel(Guid);
        //}

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataTable GetList(string strWhere)
        //{
        //    return GetList(strWhere);
        //}
        ///// <summary>
        ///// 获得前几行数据
        ///// </summary>
        //public DataTable GetList(int Top, string strWhere, string filedOrder)
        //{
        //    return GetList(Top, strWhere, filedOrder);
        //}
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public List<TH.Model.订单评审> GetModelList(string strWhere)
        //{
        //    DataSet ds = GetList(strWhere);
        //    return DataTableToList(ds);
        //}
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public List<TH.Model.订单评审> DataTableToList(DataTable dt)
        //{
        //    List<TH.Model.订单评审> modelList = new List<TH.Model.订单评审>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        TH.Model.订单评审 model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = DataRowToModel(dt.Rows[n]);
        //            if (model != null)
        //            {
        //                modelList.Add(model);
        //            }
        //        }
        //    }
        //    return modelList;
        //}

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataTable GetAllList()
        //{
        //    return GetList("");
        //}
        #endregion

        public int Save(string sState, string s评审单据号, DataTable dtHead, DataTable dtDetails)
        {
            TH.Model.订单评审 Model = new TH.Model.订单评审();
            string sReturn = "";

            List<TH.Model.订单评审> l = new List<TH.Model.订单评审>();
            for (int i = 0; i < dtHead.Rows.Count; i++)
            {
                string sGuid = dtHead.Rows[i]["guid"].ToString().Trim();

                DataRow[] drDetails = dtDetails.Select("guidhead = '" + sGuid + "'");
                DataTable dtDetail_Row = BaseFunction.BaseFunction.ReturnDataRowsToTable(drDetails);

                Model = DataRowToModel(dtHead.Rows[i], dtDetail_Row, s评审单据号);
                l.Add(Model);
            }
            if (sReturn.Trim() != "")
                throw new Exception(sReturn);

            int iCou = Save(sState, l);
            return iCou;
        }

        public void GetBom多阶(string s母件编码, decimal d加成数量, int i级别, string s母子关联, string s销售订单号, string s行号, long l订单子表ID, string s顶级母件编码, decimal d评审数量, DateTime d结束日期)
        {
            string sSQL = sBom;
            string sSQLWhere = "g.cInvCode = '" + s母件编码 + "'";
            sSQL = sSQL.Replace("1=-1", sSQLWhere);
            sSQL = sSQL.Replace("111111", s销售订单号);
            sSQL = sSQL.Replace("222222", s行号);
            sSQL = sSQL.Replace("333333", l订单子表ID.ToString());
            sSQL = sSQL.Replace("444444", s顶级母件编码);
            sSQL = sSQL.Replace("555555", d评审数量.ToString());
            sSQL = sSQL.Replace("666666", s销售订单号 + "【" + s行号 + "】");
            DataTable dtBomTemp = DbHelperSQL.Query(sSQL);
            if (dtBomTemp != null && dtBomTemp.Rows.Count > 0)
            {
                for (int i = 0; i < dtBomTemp.Rows.Count; i++)
                {
                    dtBomTemp.Rows[i]["序号"] = i + 1;
                    DataRow drBom = dtBom.NewRow();

                    if (s母件编码 == s顶级母件编码)
                    {
                        drBom["结束日期"] = d结束日期;
                        drBom["开始日期"] = d结束日期;
                    }

                    DateTime d开始日期 = d结束日期.AddDays(-1);

                    drBom.ItemArray = dtBomTemp.Rows[i].ItemArray;
                    drBom["级别"] = i级别;
                    decimal d加成 = BaseFunction.BaseFunction.ReturnDecimal(BaseFunction.BaseFunction.ReturnDecimal(drBom["单阶使用数量"]) * d加成数量);
   
                    drBom["加成数量"] = d加成;

                    d评审数量 = BaseFunction.BaseFunction.ReturnDecimal(d加成 * d评审数量);
                    drBom["需求数量"] = d评审数量;
                    drBom["评审数量"] = d评审数量;
                    drBom["本单需求数量"] = d评审数量;


                    drBom["交货日期"] = d结束日期;

                    if (s母子关联 == s母件编码)
                        s母子关联 = "--→" + s母子关联;
                    else
                    {
                        string[] s = s母子关联.Split('→');

                        if (s[s.Length - 1] != s母件编码)
                        {
                            s母子关联 = s母子关联 + "→" + s母件编码;
                        }
                    }

                    drBom["母子关联"] = s母子关联;
                    dtBom.Rows.Add(drBom);

                    dtBomTemp.Rows[i]["加成数量"] = d加成;
                    string sInvCode = dtBomTemp.Rows[i]["子件编码"].ToString().Trim();
                    string s子件属性 = dtBomTemp.Rows[i]["子件属性"].ToString().Trim();

                    if (s子件属性 != "采购")
                    {
                        GetBom多阶(sInvCode, d加成, i级别 + 1, s母子关联, s销售订单号, s行号, l订单子表ID, s顶级母件编码, d评审数量, d开始日期.AddDays(-1));
                    }
                }
            }
        }


        public DataTable Get供需分析(DataTable dt, string sPCCode)
        {

            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                string sSQL = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sInvCode = dt.Rows[i]["子件编码"].ToString().Trim();
                    string sSoCode = dt.Rows[i]["销售订单号"].ToString().Trim();
                    int iRow = BaseFunction.BaseFunction.ReturnInt(dt.Rows[i]["销售订单行号"]);

                    sSQL = "exec @u8._Get供需分析 '" + sInvCode + "','" + sSoCode + "'," + iRow + "";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "select 存货编码,sum(现存量) as 现存量,sum(待入库) as 待入库,sum(待出库) as 待出库 from @u8.Get供需分析 where 存货编码 = '" + sInvCode + "' group by 存货编码";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp.Rows != null && dtTemp.Rows.Count > 0)
                    {
                        dt.Rows[i]["仓库存量"] = dtTemp.Rows[0]["现存量"];
                        dt.Rows[i]["待入库数量"] = dtTemp.Rows[0]["待入库"];
                        dt.Rows[i]["待出库数量"] = dtTemp.Rows[0]["待出库"];
                    }
                }

                tran.Commit();
            }
            catch(Exception ee)
            {
                tran.Rollback();
                throw new Exception(ee.Message);
            }
            return dt;
        }

        public DataTable Get物料供需分析汇总(string s存货编码,string sPCCode)
        {
            DataTable dtTemp = new DataTable();
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                string sSQL = "exec @u8._Get供需分析 '" + s存货编码 + "','-1',-1";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = "select 存货编码,sum(现存量) as 现存量,sum(待入库) as 待入库,sum(待出库) as 待出库 from  @u8.Get供需分析 group by 存货编码";
                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                tran.Commit();
            }
            catch (Exception ee)
            {
                tran.Rollback();
                throw new Exception(ee.Message);
            }
            return dtTemp;
        }

        public DataTable Get物料供需分析(string s存货编码,string sPCCode)
        {
            DataTable dtTemp = new DataTable();
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                string sSQL = "exec @u8._Get供需分析 '" + s存货编码 + "','-1',-1";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = "select a.*,b.cInvName as 存货名称,b.cInvStd as 规格型号 from  @u8.Get供需分析 a inner join  @u8.Inventory b on a.存货编码 = b.cInvCode order by a.供需类型,a.供需日期";
                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                tran.Commit();
            }
            catch (Exception ee)
            {
                tran.Rollback();
                throw new Exception(ee.Message);
            }
            return dtTemp;
        }

        public DataTable GetWorkCalendar(int iYear)
        {
            string sSQL = "select * from WorkCalendar where iYear = 111111 or iYear = 222222 order by iYear,iMonth";
            sSQL = sSQL.Replace("111111", iYear.ToString());
            sSQL = sSQL.Replace("222222", (iYear + 1).ToString());
            return DbHelperSQL.Query(sSQL);
        }

        public DataTable GetSoMainList(string strWhere)
        {
            string sSQL = @"
select cast(0 as bit) as Choose, a.cSoCode as 销售订单号,a.dDate as 单据日期, case when isnull(f.cbdefine2,'') = '' then b.dPreDate else f.cbdefine2 end as 交货日期 ,a.cCusCode as 客户编码,d.cCusAbbName as 客户简称,b.cInvCode as 存货编码,e.cInvName as 存货名称
    ,e.cInvStd as 规格型号,cast (b.iQuantity as decimal(16,2)) as 订单数量,b.AutoID as 销售订单子表ID
	,cast (b.iQuantity - isnull(c.数量,0) as decimal(16,2)) as 数量,cast (c.数量 as decimal(16,2)) as 已评审数量,cast (b.iQuantity - isnull(c.数量,0) as decimal(16,2)) as 待评审数量,b.iRowNo as 行号
    ,cast (null as varchar(50)) as 评审单据号,cast (null as datetime) as 评审单据日期,cast (null as varchar(50)) as 帐套号
     ,cast (null as varchar(50)) as 制单人,cast (null as datetime) as 制单日期 ,cast (null as varchar(50)) as 审核人,cast (null as datetime) as 审核日期
     ,cast (null as varchar(50)) as 锁定人,cast (null as datetime) as 锁定日期 ,cast (null as varchar(50)) as 关闭人,cast (null as datetime) as 关闭日期
    ,newid() as GUID
from @u8.so_somain a inner join @u8.so_sodetails b on a.id = b.id
	left join dbo.订单评审 c on c.销售订单子表ID = b.AutoID 
	left join @u8.Customer d on a.cCusCode = d.cCusCode
	left join @u8.Inventory e on e.cInvCode = b.cInvCode
    left join @u8.SO_SODetails_ExtraDefine f on f.iSOsID = b.iSOsID
where b.iQuantity > isnull(c.数量,0) and isnull(a.cVerifier,'') <> '' and isnull(a.cCloser ,'') = '' and 1=1
    and isnull(f.cbdefine1,0) = 1
order by case when isnull(f.cbdefine2,'') = '' then b.dPreDate else f.cbdefine2 end,a.cSoCode,b.iRowNo 
        ";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public bool Edit(string sPSCode)
        {
            bool b = true;
            try
            {
                if (sPSCode == "")
                    throw new Exception("请选择需要审核的单据");

                DataTable dtCode = GetPSListHead(sPSCode);
                if (dtCode == null || dtCode.Rows.Count == 0)
                    throw new Exception("单据不存在");

                //关闭单据不能审核
                if (dtCode.Rows[0]["关闭人"].ToString().Trim() != "")
                    throw new Exception("单据已经关闭");

                //已审核
                if (dtCode.Rows[0]["审核人"].ToString().Trim() != "")
                    throw new Exception("单据已经审核");

                //使用单据不能删除
            }
            catch (Exception ee)
            {
                b = false;
                throw new Exception(ee.Message);
            }

            return b;

        }

        /// <summary>
        /// 获得评审单列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetPSCodeList(string strWhere)
        {
            string sSQL = @"
select distinct cast (0 as bit) as 选择, 评审单据号,评审单据日期 ,制单人,制单日期,审核人,审核日期,关闭人,关闭日期
from 订单评审 
where 1=1
order by 评审单据号
        ";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }

        public DataTable GetPSListHead(string sPSCode)
        {
            return GetPSListHead(sPSCode, "");
        }
        public DataTable GetPSListDetail(string sPSCode)
        {
            return GetPSListDetail(sPSCode, "");
        }

        public DataTable GetPSListHead(string sPSCode,string sTrWhere)
        {
            string sSQL = @"
select cast(0 as bit) as 选择, a.*,a.产品编码 as 存货编码,b.cInvName as 存货名称,b.cInvStd as 存货规格
from 订单评审 a inner join @u8.Inventory b on a.产品编码 = b.cInvCode
where 评审单据号 = '111111' and 1=1
order by a.iID;
        ";

            sSQL = sSQL.Replace("111111", sPSCode);

            if (sTrWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + sTrWhere);
            }

            return DbHelperSQL.Query(sSQL);
        }

        public DataTable GetPSListDetail(string sPSCode, string sTrWhere)
        {
            string sSQL = @"
select cast(0 as bit) as 选择, * ,cast(null as varchar(50)) as 生产订单号
from 订单评审明细 a
where  a.评审单据号 = '111111' and 1=1
order by a.iID
        ";

            sSQL = sSQL.Replace("111111", sPSCode);

            if (sTrWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + sTrWhere);
            }

            return DbHelperSQL.Query(sSQL);
        }


        /// <summary>
        /// 获得评审单据号
        /// </summary>
        /// <returns></returns>
        public DataTable GetPSCode(string strWhere)
        {
            string sSQL = @"
select distinct 评审单据号
from 订单评审 
where 1=1
order by 评审单据号
";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }

        public string GetNewCode(string sPSCode)
        {
            string sSQL = @"
select max(评审单据号) from 订单评审 where 评审单据号 like '111111%'
";
            sSQL = sSQL.Replace("111111", sPSCode);

            DataTable ds = DbHelperSQL.Query(sSQL);
           return ds.Rows[0][0].ToString().Trim();
        }

        public int Save(string sState,List<TH.Model.订单评审> l)
        {
            List<CommandInfo> list = new List<CommandInfo>();

            DateTime d = DbHelperSQL.ExecuteGetServerTime();
            for (int i = 0; i < l.Count; i++)
            {
                List<CommandInfo> listTemp = new List<CommandInfo>();

                if (sState == "add")
                {
                    l[i].评审单据日期 = BaseFunction.BaseFunction.ReturnDate(d.ToString("yyyy-MM-dd"));
                    l[i].制单人 = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    l[i].制单日期 = d;
                    listTemp = Add(l[i]);
                }
                if (sState == "edit")
                {
                    listTemp = Update(l[i]);
                }

                foreach (CommandInfo commandInfo in listTemp)
                {
                    list.Add(commandInfo);
                }
            }
            
            return DbHelperSQL.ExecuteSqlTran(list);
        }



        /// <summary>
        /// 获得生产默认日工时
        /// </summary>
        public int GetDayTime()
        {
            int i = 0;
            string sSQL = "select * from dbo._Code where sType = '生产默认日工时'";
            DataTable ds = DbHelperSQL.Query(sSQL);
            i = BaseFunction.BaseFunction.ReturnInt(ds.Rows[0]["cCode"]);

            return i;
        }


        /// <summary>
        /// 审核
        /// </summary>
        public bool Audit(string sPSCode)
        {
            if (sPSCode == "")
                throw new Exception("请选择需要审核的单据");

            DataTable dtCode = GetPSListHead(sPSCode);
            if (dtCode == null || dtCode.Rows.Count == 0)
                throw new Exception("单据不存在，不能审核");

            //关闭单据不能审核
            if (dtCode.Rows[0]["关闭人"].ToString().Trim() != "")
                throw new Exception("单据已经关闭，不能审核");

            //已审核
            if (dtCode.Rows[0]["审核人"].ToString().Trim() != "")
                throw new Exception("单据已经审核");

            //使用单据不能删除


            string sSQL = "update 订单评审 set 审核人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',审核日期 = '" + DbHelperSQL.ExecuteGetServerTime() + "' where 评审单据号 = '" + sPSCode + "'";
            int rowsAffected = DbHelperSQL.ExecuteSql(sSQL);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 弃审
        /// </summary>
        public bool UnAudit(string sPSCode)
        {
            if (sPSCode == "")
                throw new Exception("请选择需要弃审的单据");

            DataTable dtCode = GetPSListHead(sPSCode);
            if (dtCode == null || dtCode.Rows.Count == 0)
                throw new Exception("单据不存在，不能弃审");

            //未审核
            if (dtCode.Rows[0]["审核人"].ToString().Trim() == "")
                throw new Exception("单据尚未审核");

            //关闭单据不能审核
            if (dtCode.Rows[0]["关闭人"].ToString().Trim() != "")
                throw new Exception("单据已经关闭，不能弃审");

            //下达生产不能弃审
            if (dtCode.Rows[0]["下达生产人"].ToString().Trim() != "")
                throw new Exception("单据已经下达生产，不能弃审");


            //使用单据

            string sSQL = "select * from dbo.订单评审明细 where 评审单据号 = '" + sPSCode + "' and GUID in (select 来源GUID from dbo.生产计划 where 单据类型 = '评审')";
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt != null && dt.Rows.Count != 0)
            {
                throw new Exception("存在已下单生产计划,不能弃审");
            }


            sSQL = "update 订单评审 set 审核人 = null,审核日期 = null where 评审单据号 = '" + sPSCode + "'";
            int rowsAffected = DbHelperSQL.ExecuteSql(sSQL);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public bool Close(string sPSCode)
        {
            if (sPSCode == "")
                throw new Exception("请选择需要关闭的单据");

            DataTable dtCode = GetPSListHead(sPSCode);
            if (dtCode == null || dtCode.Rows.Count == 0)
                throw new Exception("单据不存在，不能关闭");

            //关闭单据
            if (dtCode.Rows[0]["关闭人"].ToString().Trim() != "")
                throw new Exception("单据关闭");

            //未审核
            if (dtCode.Rows[0]["审核人"].ToString().Trim() == "")
                throw new Exception("单据未审核");

            //使用单据不能删除

            string sSQL = "update 订单评审 set 关闭人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',关闭日期 = '" + DbHelperSQL.ExecuteGetServerTime() + "' where 评审单据号 = '" + sPSCode + "'";
            int rowsAffected = DbHelperSQL.ExecuteSql(sSQL);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 打开
        /// </summary>
        public bool Open(string sPSCode)
        {
            if (sPSCode == "")
                throw new Exception("请选择需要打开的单据");

            DataTable dtCode = GetPSListHead(sPSCode);
            if (dtCode == null || dtCode.Rows.Count == 0)
                throw new Exception("单据不存在，不能打开");

            //未关闭单据
            if (dtCode.Rows[0]["关闭人"].ToString().Trim() == "")
                throw new Exception("单据尚未关闭");

            //未审核
            if (dtCode.Rows[0]["审核人"].ToString().Trim() == "")
                throw new Exception("单据尚未审核");

            string sSQL = "update 订单评审 set 关闭人 = null,关闭日期 = null where 评审单据号 = '" + sPSCode + "'";
            int rowsAffected = DbHelperSQL.ExecuteSql(sSQL);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region 数据库操作脚本

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid Guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 订单评审");
            strSql.Append(" where Guid=@Guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
		/// 增加一条数据,及其子表数据
		/// </summary>
        public List<CommandInfo> Add(TH.Model.订单评审 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 订单评审(");
            strSql.Append("产品编码,待评审数量,交货日期,订单数量,已评审数量,销售订单子表ID,数量,备注,制单人,制单日期,评审单据号,锁定人,锁定日期,审核人,审核日期,关闭人,关闭日期,下达请购人,下达请购日期,下达委外人,下达委外日期,评审单据日期,下达生产人,下达生产日期,Guid,帐套号,销售订单号,单据日期,客户编码,客户简称,行号)");
            strSql.Append(" values (");
            strSql.Append("@产品编码,@待评审数量,@交货日期,@订单数量,@已评审数量,@销售订单子表ID,@数量,@备注,@制单人,@制单日期,@评审单据号,@锁定人,@锁定日期,@审核人,@审核日期,@关闭人,@关闭日期,@下达请购人,@下达请购日期,@下达委外人,@下达委外日期,@评审单据日期,@下达生产人,@下达生产日期,@Guid,@帐套号,@销售订单号,@单据日期,@客户编码,@客户简称,@行号)");
            SqlParameter[] parameters = {
					new SqlParameter("@产品编码", SqlDbType.VarChar,50),
					new SqlParameter("@待评审数量", SqlDbType.Decimal,9),
					new SqlParameter("@交货日期", SqlDbType.DateTime),
					new SqlParameter("@订单数量", SqlDbType.Decimal,9),
					new SqlParameter("@已评审数量", SqlDbType.Decimal,9),
					new SqlParameter("@销售订单子表ID", SqlDbType.VarChar,50),
					new SqlParameter("@数量", SqlDbType.Decimal,9),
					new SqlParameter("@备注", SqlDbType.VarChar,300),
					new SqlParameter("@制单人", SqlDbType.VarChar,50),
					new SqlParameter("@制单日期", SqlDbType.DateTime),
					new SqlParameter("@评审单据号", SqlDbType.VarChar,50),
					new SqlParameter("@锁定人", SqlDbType.VarChar,50),
					new SqlParameter("@锁定日期", SqlDbType.DateTime),
					new SqlParameter("@审核人", SqlDbType.VarChar,50),
					new SqlParameter("@审核日期", SqlDbType.DateTime),
					new SqlParameter("@关闭人", SqlDbType.VarChar,50),
					new SqlParameter("@关闭日期", SqlDbType.DateTime),
					new SqlParameter("@下达请购人", SqlDbType.VarChar,50),
					new SqlParameter("@下达请购日期", SqlDbType.DateTime),
					new SqlParameter("@下达委外人", SqlDbType.VarChar,50),
					new SqlParameter("@下达委外日期", SqlDbType.DateTime),
					new SqlParameter("@评审单据日期", SqlDbType.DateTime),
					new SqlParameter("@下达生产人", SqlDbType.VarChar,50),
					new SqlParameter("@下达生产日期", SqlDbType.DateTime),
					new SqlParameter("@Guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@帐套号", SqlDbType.VarChar,50),
					new SqlParameter("@销售订单号", SqlDbType.VarChar,50),
					new SqlParameter("@单据日期", SqlDbType.DateTime),
					new SqlParameter("@客户编码", SqlDbType.VarChar,50),
					new SqlParameter("@客户简称", SqlDbType.VarChar,50),
					new SqlParameter("@行号", SqlDbType.VarChar,50)};
            parameters[0].Value = model.存货编码;
            parameters[1].Value = model.待评审数量;
            parameters[2].Value = model.交货日期;
            parameters[3].Value = model.订单数量;
            parameters[4].Value = model.已评审数量;
            parameters[5].Value = model.销售订单子表ID;
            parameters[6].Value = model.数量;
            parameters[7].Value = model.备注;
            parameters[8].Value = model.制单人;
            parameters[9].Value = model.制单日期;
            parameters[10].Value = model.评审单据号;
            parameters[11].Value = model.锁定人;
            parameters[12].Value = model.锁定日期;
            parameters[13].Value = model.审核人;
            parameters[14].Value = model.审核日期;
            parameters[15].Value = model.关闭人;
            parameters[16].Value = model.关闭日期;
            parameters[17].Value = model.下达请购人;
            parameters[18].Value = model.下达请购日期;
            parameters[19].Value = model.下达委外人;
            parameters[20].Value = model.下达委外日期;
            parameters[21].Value = model.评审单据日期;
            parameters[22].Value = model.下达生产人;
            parameters[23].Value = model.下达生产日期;
            parameters[24].Value = model.Guid;
            parameters[25].Value = model.帐套号;
            parameters[26].Value = model.销售订单号;
            parameters[27].Value = model.单据日期;
            parameters[28].Value = model.客户编码;
            parameters[29].Value = model.客户简称;
            parameters[30].Value = model.行号;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            StringBuilder strSql2;
            foreach (TH.Model.订单评审明细 models in model.订单评审明细s)
            {
                strSql2 = new StringBuilder();
                strSql2.Append("insert into 订单评审明细(");
                strSql2.Append("母件计量单位,母件损耗率,版本代号,版本说明,版本日期,状态,母件属性,变更单号,行号,子件行号,评审单据号,工序行号,子件编码,子件名称,子件代号,子件规格,子件计量单位,基本用量,基础用量,子件损耗率,固定用量,序号,供应类型,单阶使用数量,加成数量,换算率,子件生效日,子件失效日,偏置期,计划比例,产出品,产出类型,级别,成本相关,可选否,选择规则,备注,子件属性,母子关联,销售订单号,销售订单行号,销售订单子表ID,需求数量,顶级母件编码,评审数量,本单需求数量,交货日期,开始日期,结束日期,评审采购周期,评审委外周期,单件默认生产工时,默认产线,质检周期,母件编码,生产准备时间,经济批量,置办周期,生产合计工时,默认产线并发生产数,仓库存量,待入库数量,待出库数量,销售单号,仓库编码,母件名称,仓库名称,领料部门编码,生产部门编码,GUIDHead,GUID,母件代号,母件规格)");
                strSql2.Append(" values (");
                strSql2.Append("@母件计量单位,@母件损耗率,@版本代号,@版本说明,@版本日期,@状态,@母件属性,@变更单号,@行号,@子件行号,@评审单据号,@工序行号,@子件编码,@子件名称,@子件代号,@子件规格,@子件计量单位,@基本用量,@基础用量,@子件损耗率,@固定用量,@序号,@供应类型,@单阶使用数量,@加成数量,@换算率,@子件生效日,@子件失效日,@偏置期,@计划比例,@产出品,@产出类型,@级别,@成本相关,@可选否,@选择规则,@备注,@子件属性,@母子关联,@销售订单号,@销售订单行号,@销售订单子表ID,@需求数量,@顶级母件编码,@评审数量,@本单需求数量,@交货日期,@开始日期,@结束日期,@评审采购周期,@评审委外周期,@单件默认生产工时,@默认产线,@质检周期,@母件编码,@生产准备时间,@经济批量,@置办周期,@生产合计工时,@默认产线并发生产数,@仓库存量,@待入库数量,@待出库数量,@销售单号,@仓库编码,@母件名称,@仓库名称,@领料部门编码,@生产部门编码,@GUIDHead,@GUID,@母件代号,@母件规格)");
                SqlParameter[] parameters2 = {
						new SqlParameter("@母件计量单位", SqlDbType.VarChar,50),
						new SqlParameter("@母件损耗率", SqlDbType.Decimal,9),
						new SqlParameter("@版本代号", SqlDbType.VarChar,50),
						new SqlParameter("@版本说明", SqlDbType.VarChar,50),
						new SqlParameter("@版本日期", SqlDbType.DateTime),
						new SqlParameter("@状态", SqlDbType.VarChar,50),
						new SqlParameter("@母件属性", SqlDbType.VarChar,50),
						new SqlParameter("@变更单号", SqlDbType.VarChar,50),
						new SqlParameter("@行号", SqlDbType.VarChar,50),
						new SqlParameter("@子件行号", SqlDbType.VarChar,50),
						new SqlParameter("@评审单据号", SqlDbType.VarChar,50),
						new SqlParameter("@工序行号", SqlDbType.VarChar,50),
						new SqlParameter("@子件编码", SqlDbType.VarChar,50),
						new SqlParameter("@子件名称", SqlDbType.VarChar,150),
						new SqlParameter("@子件代号", SqlDbType.VarChar,150),
						new SqlParameter("@子件规格", SqlDbType.VarChar,200),
						new SqlParameter("@子件计量单位", SqlDbType.VarChar,50),
						new SqlParameter("@基本用量", SqlDbType.Decimal,9),
						new SqlParameter("@基础用量", SqlDbType.Decimal,9),
						new SqlParameter("@子件损耗率", SqlDbType.Decimal,9),
						new SqlParameter("@固定用量", SqlDbType.VarChar,50),
						new SqlParameter("@序号", SqlDbType.VarChar,50),
						new SqlParameter("@供应类型", SqlDbType.VarChar,50),
						new SqlParameter("@单阶使用数量", SqlDbType.Decimal,9),
						new SqlParameter("@加成数量", SqlDbType.Decimal,9),
						new SqlParameter("@换算率", SqlDbType.Decimal,9),
						new SqlParameter("@子件生效日", SqlDbType.DateTime),
						new SqlParameter("@子件失效日", SqlDbType.DateTime),
						new SqlParameter("@偏置期", SqlDbType.Int,4),
						new SqlParameter("@计划比例", SqlDbType.Decimal,9),
						new SqlParameter("@产出品", SqlDbType.VarChar,50),
						new SqlParameter("@产出类型", SqlDbType.VarChar,50),
						new SqlParameter("@级别", SqlDbType.VarChar,50),
						new SqlParameter("@成本相关", SqlDbType.Bit,1),
						new SqlParameter("@可选否", SqlDbType.Bit,1),
						new SqlParameter("@选择规则", SqlDbType.VarChar,50),
						new SqlParameter("@备注", SqlDbType.VarChar,300),
						new SqlParameter("@子件属性", SqlDbType.VarChar,50),
						new SqlParameter("@母子关联", SqlDbType.VarChar,300),
						new SqlParameter("@销售订单号", SqlDbType.VarChar,50),
						new SqlParameter("@销售订单行号", SqlDbType.VarChar,50),
						new SqlParameter("@销售订单子表ID", SqlDbType.Int,4),
						new SqlParameter("@需求数量", SqlDbType.Decimal,9),
						new SqlParameter("@顶级母件编码", SqlDbType.VarChar,50),
						new SqlParameter("@评审数量", SqlDbType.Decimal,9),
						new SqlParameter("@本单需求数量", SqlDbType.Decimal,9),
						new SqlParameter("@交货日期", SqlDbType.DateTime),
						new SqlParameter("@开始日期", SqlDbType.DateTime),
						new SqlParameter("@结束日期", SqlDbType.DateTime),
						new SqlParameter("@评审采购周期", SqlDbType.Int,4),
						new SqlParameter("@评审委外周期", SqlDbType.Int,4),
						new SqlParameter("@单件默认生产工时", SqlDbType.Decimal,9),
						new SqlParameter("@默认产线", SqlDbType.VarChar,50),
						new SqlParameter("@质检周期", SqlDbType.Decimal,9),
						new SqlParameter("@母件编码", SqlDbType.VarChar,50),
						new SqlParameter("@生产准备时间", SqlDbType.Decimal,9),
						new SqlParameter("@经济批量", SqlDbType.Decimal,9),
						new SqlParameter("@置办周期", SqlDbType.Decimal,9),
						new SqlParameter("@生产合计工时", SqlDbType.Decimal,9),
						new SqlParameter("@默认产线并发生产数", SqlDbType.Decimal,9),
						new SqlParameter("@仓库存量", SqlDbType.Decimal,9),
						new SqlParameter("@待入库数量", SqlDbType.Decimal,9),
						new SqlParameter("@待出库数量", SqlDbType.Decimal,9),
						new SqlParameter("@销售单号", SqlDbType.VarChar,50),
						new SqlParameter("@仓库编码", SqlDbType.VarChar,50),
						new SqlParameter("@母件名称", SqlDbType.VarChar,150),
						new SqlParameter("@仓库名称", SqlDbType.VarChar,150),
						new SqlParameter("@领料部门编码", SqlDbType.VarChar,50),
						new SqlParameter("@生产部门编码", SqlDbType.VarChar,50),
						new SqlParameter("@GUIDHead", SqlDbType.UniqueIdentifier,16),
						new SqlParameter("@GUID", SqlDbType.UniqueIdentifier,16),
						new SqlParameter("@母件代号", SqlDbType.VarChar,150),
						new SqlParameter("@母件规格", SqlDbType.VarChar,150)};
                parameters2[0].Value = models.母件计量单位;
                parameters2[1].Value = models.母件损耗率;
                parameters2[2].Value = models.版本代号;
                parameters2[3].Value = models.版本说明;
                parameters2[4].Value = models.版本日期;
                parameters2[5].Value = models.状态;
                parameters2[6].Value = models.母件属性;
                parameters2[7].Value = models.变更单号;
                parameters2[8].Value = models.行号;
                parameters2[9].Value = models.子件行号;
                parameters2[10].Value = models.评审单据号;
                parameters2[11].Value = models.工序行号;
                parameters2[12].Value = models.子件编码;
                parameters2[13].Value = models.子件名称;
                parameters2[14].Value = models.子件代号;
                parameters2[15].Value = models.子件规格;
                parameters2[16].Value = models.子件计量单位;
                parameters2[17].Value = models.基本用量;
                parameters2[18].Value = models.基础用量;
                parameters2[19].Value = models.子件损耗率;
                parameters2[20].Value = models.固定用量;
                parameters2[21].Value = models.序号;
                parameters2[22].Value = models.供应类型;
                parameters2[23].Value = models.单阶使用数量;
                parameters2[24].Value = models.加成数量;
                parameters2[25].Value = models.换算率;
                parameters2[26].Value = models.子件生效日;
                parameters2[27].Value = models.子件失效日;
                parameters2[28].Value = models.偏置期;
                parameters2[29].Value = models.计划比例;
                parameters2[30].Value = models.产出品;
                parameters2[31].Value = models.产出类型;
                parameters2[32].Value = models.级别;
                parameters2[33].Value = models.成本相关;
                parameters2[34].Value = models.可选否;
                parameters2[35].Value = models.选择规则;
                parameters2[36].Value = models.备注;
                parameters2[37].Value = models.子件属性;
                parameters2[38].Value = models.母子关联;
                parameters2[39].Value = models.销售订单号;
                parameters2[40].Value = models.销售订单行号;
                parameters2[41].Value = models.销售订单子表ID;
                parameters2[42].Value = models.需求数量;
                parameters2[43].Value = models.顶级母件编码;
                parameters2[44].Value = models.评审数量;
                parameters2[45].Value = models.本单需求数量;
                parameters2[46].Value = models.交货日期;
                parameters2[47].Value = models.开始日期;
                parameters2[48].Value = models.结束日期;
                parameters2[49].Value = models.评审采购周期;
                parameters2[50].Value = models.评审委外周期;
                parameters2[51].Value = models.单件默认生产工时;
                parameters2[52].Value = models.默认产线;
                parameters2[53].Value = models.质检周期;
                parameters2[54].Value = models.母件编码;
                parameters2[55].Value = models.生产准备时间;
                parameters2[56].Value = models.经济批量;
                parameters2[57].Value = models.置办周期;
                parameters2[58].Value = models.生产合计工时;
                parameters2[59].Value = models.默认产线并发生产数;
                parameters2[60].Value = models.仓库存量;
                parameters2[61].Value = models.待入库数量;
                parameters2[62].Value = models.待出库数量;
                parameters2[63].Value = models.销售单号;
                parameters2[64].Value = models.仓库编码;
                parameters2[65].Value = models.母件名称;
                parameters2[66].Value = models.仓库名称;
                parameters2[67].Value = models.领料部门编码;
                parameters2[68].Value = models.生产部门编码;
                parameters2[69].Value = models.GUIDHead;
                parameters2[70].Value = models.GUID;
                parameters2[71].Value = models.母件代号;
                parameters2[72].Value = models.母件规格;

                cmd = new CommandInfo(strSql2.ToString(), parameters2);
                sqllist.Add(cmd);
            }

            return sqllist;
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public List<CommandInfo> Update(TH.Model.订单评审 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 订单评审 set ");
            strSql.Append("产品编码=@产品编码,");
            strSql.Append("待评审数量=@待评审数量,");
            strSql.Append("交货日期=@交货日期,");
            strSql.Append("订单数量=@订单数量,");
            strSql.Append("已评审数量=@已评审数量,");
            strSql.Append("销售订单子表ID=@销售订单子表ID,");
            strSql.Append("数量=@数量,");
            strSql.Append("备注=@备注,");
            strSql.Append("制单人=@制单人,");
            strSql.Append("制单日期=@制单日期,");
            strSql.Append("锁定人=@锁定人,");
            strSql.Append("锁定日期=@锁定日期,");
            strSql.Append("审核人=@审核人,");
            strSql.Append("审核日期=@审核日期,");
            strSql.Append("关闭人=@关闭人,");
            strSql.Append("关闭日期=@关闭日期,");
            strSql.Append("下达请购人=@下达请购人,");
            strSql.Append("下达请购日期=@下达请购日期,");
            strSql.Append("下达委外人=@下达委外人,");
            strSql.Append("下达委外日期=@下达委外日期,");
            strSql.Append("评审单据日期=@评审单据日期,");
            strSql.Append("下达生产人=@下达生产人,");
            strSql.Append("下达生产日期=@下达生产日期,");
            strSql.Append("Guid=@Guid,");
            strSql.Append("帐套号=@帐套号,");
            strSql.Append("销售订单号=@销售订单号,");
            strSql.Append("单据日期=@单据日期,");
            strSql.Append("客户编码=@客户编码,");
            strSql.Append("客户简称=@客户简称,");
            strSql.Append("行号=@行号,");
            strSql.Append("评审单据号=@评审单据号");
            strSql.Append(" where Guid=@Guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@产品编码", SqlDbType.VarChar,50),
					new SqlParameter("@待评审数量", SqlDbType.Decimal,9),
					new SqlParameter("@交货日期", SqlDbType.DateTime),
					new SqlParameter("@订单数量", SqlDbType.Decimal,9),
					new SqlParameter("@已评审数量", SqlDbType.Decimal,9),
					new SqlParameter("@销售订单子表ID", SqlDbType.VarChar,50),
					new SqlParameter("@数量", SqlDbType.Decimal,9),
					new SqlParameter("@备注", SqlDbType.VarChar,300),
					new SqlParameter("@制单人", SqlDbType.VarChar,50),
					new SqlParameter("@制单日期", SqlDbType.DateTime),
					new SqlParameter("@评审单据号", SqlDbType.VarChar,50),
					new SqlParameter("@锁定人", SqlDbType.VarChar,50),
					new SqlParameter("@锁定日期", SqlDbType.DateTime),
					new SqlParameter("@审核人", SqlDbType.VarChar,50),
					new SqlParameter("@审核日期", SqlDbType.DateTime),
					new SqlParameter("@关闭人", SqlDbType.VarChar,50),
					new SqlParameter("@关闭日期", SqlDbType.DateTime),
					new SqlParameter("@下达请购人", SqlDbType.VarChar,50),
					new SqlParameter("@下达请购日期", SqlDbType.DateTime),
					new SqlParameter("@下达委外人", SqlDbType.VarChar,50),
					new SqlParameter("@下达委外日期", SqlDbType.DateTime),
					new SqlParameter("@评审单据日期", SqlDbType.DateTime),
					new SqlParameter("@下达生产人", SqlDbType.VarChar,50),
					new SqlParameter("@下达生产日期", SqlDbType.DateTime),
					new SqlParameter("@Guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@帐套号", SqlDbType.VarChar,50),
					new SqlParameter("@销售订单号", SqlDbType.VarChar,50),
					new SqlParameter("@单据日期", SqlDbType.DateTime),
					new SqlParameter("@客户编码", SqlDbType.VarChar,50),
					new SqlParameter("@客户简称", SqlDbType.VarChar,50),
					new SqlParameter("@行号", SqlDbType.VarChar,50)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.存货编码;
            parameters[2].Value = model.待评审数量;
            parameters[3].Value = model.交货日期;
            parameters[4].Value = model.订单数量;
            parameters[5].Value = model.已评审数量;
            parameters[6].Value = model.销售订单子表ID;
            parameters[7].Value = model.数量;
            parameters[8].Value = model.备注;
            parameters[9].Value = model.制单人;
            parameters[10].Value = model.制单日期;
            parameters[11].Value = model.评审单据号;
            parameters[12].Value = model.锁定人;
            parameters[13].Value = model.锁定日期;
            parameters[14].Value = model.审核人;
            parameters[15].Value = model.审核日期;
            parameters[16].Value = model.关闭人;
            parameters[17].Value = model.关闭日期;
            parameters[18].Value = model.下达请购人;
            parameters[19].Value = model.下达请购日期;
            parameters[20].Value = model.下达委外人;
            parameters[21].Value = model.下达委外日期;
            parameters[22].Value = model.评审单据日期;
            parameters[23].Value = model.下达生产人;
            parameters[24].Value = model.下达生产日期;
            parameters[25].Value = model.Guid;
            parameters[26].Value = model.帐套号;
            parameters[27].Value = model.销售订单号;
            parameters[28].Value = model.单据日期;
            parameters[29].Value = model.客户编码;
            parameters[30].Value = model.客户简称;
            parameters[31].Value = model.行号;


            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete 订单评审明细 ");
            strSql3.Append(" where GuidHead=@Guid ");
            SqlParameter[] parameters3 = {
					new SqlParameter("@Guid", SqlDbType.UniqueIdentifier,16)};
            parameters3[0].Value = model.Guid;
            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            StringBuilder strSql2;
            foreach (TH.Model.订单评审明细 models in model.订单评审明细s)
            {
                strSql2 = new StringBuilder();
                strSql2.Append("insert into 订单评审明细(");
                strSql2.Append("母件计量单位,母件损耗率,版本代号,版本说明,版本日期,状态,母件属性,变更单号,行号,子件行号,评审单据号,工序行号,子件编码,子件名称,子件代号,子件规格,子件计量单位,基本用量,基础用量,子件损耗率,固定用量,序号,供应类型,单阶使用数量,加成数量,换算率,子件生效日,子件失效日,偏置期,计划比例,产出品,产出类型,级别,成本相关,可选否,选择规则,备注,子件属性,母子关联,销售订单号,销售订单行号,销售订单子表ID,需求数量,顶级母件编码,评审数量,本单需求数量,交货日期,开始日期,结束日期,评审采购周期,评审委外周期,单件默认生产工时,默认产线,质检周期,母件编码,生产准备时间,经济批量,置办周期,生产合计工时,默认产线并发生产数,仓库存量,待入库数量,待出库数量,销售单号,仓库编码,母件名称,仓库名称,领料部门编码,生产部门编码,GUIDHead,GUID,母件代号,母件规格)");
                strSql2.Append(" values (");
                strSql2.Append("@母件计量单位,@母件损耗率,@版本代号,@版本说明,@版本日期,@状态,@母件属性,@变更单号,@行号,@子件行号,@评审单据号,@工序行号,@子件编码,@子件名称,@子件代号,@子件规格,@子件计量单位,@基本用量,@基础用量,@子件损耗率,@固定用量,@序号,@供应类型,@单阶使用数量,@加成数量,@换算率,@子件生效日,@子件失效日,@偏置期,@计划比例,@产出品,@产出类型,@级别,@成本相关,@可选否,@选择规则,@备注,@子件属性,@母子关联,@销售订单号,@销售订单行号,@销售订单子表ID,@需求数量,@顶级母件编码,@评审数量,@本单需求数量,@交货日期,@开始日期,@结束日期,@评审采购周期,@评审委外周期,@单件默认生产工时,@默认产线,@质检周期,@母件编码,@生产准备时间,@经济批量,@置办周期,@生产合计工时,@默认产线并发生产数,@仓库存量,@待入库数量,@待出库数量,@销售单号,@仓库编码,@母件名称,@仓库名称,@领料部门编码,@生产部门编码,@GUIDHead,@GUID,@母件代号,@母件规格)");
                SqlParameter[] parameters2 = {
						new SqlParameter("@母件计量单位", SqlDbType.VarChar,50),
						new SqlParameter("@母件损耗率", SqlDbType.Decimal,9),
						new SqlParameter("@版本代号", SqlDbType.VarChar,50),
						new SqlParameter("@版本说明", SqlDbType.VarChar,50),
						new SqlParameter("@版本日期", SqlDbType.DateTime),
						new SqlParameter("@状态", SqlDbType.VarChar,50),
						new SqlParameter("@母件属性", SqlDbType.VarChar,50),
						new SqlParameter("@变更单号", SqlDbType.VarChar,50),
						new SqlParameter("@行号", SqlDbType.VarChar,50),
						new SqlParameter("@子件行号", SqlDbType.VarChar,50),
						new SqlParameter("@评审单据号", SqlDbType.VarChar,50),
						new SqlParameter("@工序行号", SqlDbType.VarChar,50),
						new SqlParameter("@子件编码", SqlDbType.VarChar,50),
						new SqlParameter("@子件名称", SqlDbType.VarChar,50),
						new SqlParameter("@子件代号", SqlDbType.VarChar,50),
						new SqlParameter("@子件规格", SqlDbType.VarChar,50),
						new SqlParameter("@子件计量单位", SqlDbType.VarChar,50),
						new SqlParameter("@基本用量", SqlDbType.Decimal,9),
						new SqlParameter("@基础用量", SqlDbType.Decimal,9),
						new SqlParameter("@子件损耗率", SqlDbType.Decimal,9),
						new SqlParameter("@固定用量", SqlDbType.VarChar,50),
						new SqlParameter("@序号", SqlDbType.VarChar,50),
						new SqlParameter("@供应类型", SqlDbType.VarChar,50),
						new SqlParameter("@单阶使用数量", SqlDbType.Decimal,9),
						new SqlParameter("@加成数量", SqlDbType.Decimal,9),
						new SqlParameter("@换算率", SqlDbType.Decimal,9),
						new SqlParameter("@子件生效日", SqlDbType.DateTime),
						new SqlParameter("@子件失效日", SqlDbType.DateTime),
						new SqlParameter("@偏置期", SqlDbType.Int,4),
						new SqlParameter("@计划比例", SqlDbType.Decimal,9),
						new SqlParameter("@产出品", SqlDbType.VarChar,50),
						new SqlParameter("@产出类型", SqlDbType.VarChar,50),
						new SqlParameter("@级别", SqlDbType.VarChar,50),
						new SqlParameter("@成本相关", SqlDbType.Bit,1),
						new SqlParameter("@可选否", SqlDbType.Bit,1),
						new SqlParameter("@选择规则", SqlDbType.VarChar,50),
						new SqlParameter("@备注", SqlDbType.VarChar,300),
						new SqlParameter("@子件属性", SqlDbType.VarChar,50),
						new SqlParameter("@母子关联", SqlDbType.VarChar,300),
						new SqlParameter("@销售订单号", SqlDbType.VarChar,50),
						new SqlParameter("@销售订单行号", SqlDbType.VarChar,50),
						new SqlParameter("@销售订单子表ID", SqlDbType.Int,4),
						new SqlParameter("@需求数量", SqlDbType.Decimal,9),
						new SqlParameter("@顶级母件编码", SqlDbType.VarChar,50),
						new SqlParameter("@评审数量", SqlDbType.Decimal,9),
						new SqlParameter("@本单需求数量", SqlDbType.Decimal,9),
						new SqlParameter("@交货日期", SqlDbType.DateTime),
						new SqlParameter("@开始日期", SqlDbType.DateTime),
						new SqlParameter("@结束日期", SqlDbType.DateTime),
						new SqlParameter("@评审采购周期", SqlDbType.Int,4),
						new SqlParameter("@评审委外周期", SqlDbType.Int,4),
						new SqlParameter("@单件默认生产工时", SqlDbType.Decimal,9),
						new SqlParameter("@默认产线", SqlDbType.VarChar,50),
						new SqlParameter("@质检周期", SqlDbType.Decimal,9),
						new SqlParameter("@母件编码", SqlDbType.VarChar,50),
						new SqlParameter("@生产准备时间", SqlDbType.Decimal,9),
						new SqlParameter("@经济批量", SqlDbType.Decimal,9),
						new SqlParameter("@置办周期", SqlDbType.Decimal,9),
						new SqlParameter("@生产合计工时", SqlDbType.Decimal,9),
						new SqlParameter("@默认产线并发生产数", SqlDbType.Decimal,9),
						new SqlParameter("@仓库存量", SqlDbType.Decimal,9),
						new SqlParameter("@待入库数量", SqlDbType.Decimal,9),
						new SqlParameter("@待出库数量", SqlDbType.Decimal,9),
						new SqlParameter("@销售单号", SqlDbType.VarChar,50),
						new SqlParameter("@仓库编码", SqlDbType.VarChar,50),
						new SqlParameter("@母件名称", SqlDbType.VarChar,50),
						new SqlParameter("@仓库名称", SqlDbType.VarChar,50),
						new SqlParameter("@领料部门编码", SqlDbType.VarChar,50),
						new SqlParameter("@生产部门编码", SqlDbType.VarChar,50),
						new SqlParameter("@GUIDHead", SqlDbType.UniqueIdentifier,16),
						new SqlParameter("@GUID", SqlDbType.UniqueIdentifier,16),
						new SqlParameter("@母件代号", SqlDbType.VarChar,50),
						new SqlParameter("@母件规格", SqlDbType.VarChar,50)};
                parameters2[0].Value = models.母件计量单位;
                parameters2[1].Value = models.母件损耗率;
                parameters2[2].Value = models.版本代号;
                parameters2[3].Value = models.版本说明;
                parameters2[4].Value = models.版本日期;
                parameters2[5].Value = models.状态;
                parameters2[6].Value = models.母件属性;
                parameters2[7].Value = models.变更单号;
                parameters2[8].Value = models.行号;
                parameters2[9].Value = models.子件行号;
                parameters2[10].Value = model.评审单据号;
                parameters2[11].Value = models.工序行号;
                parameters2[12].Value = models.子件编码;
                parameters2[13].Value = models.子件名称;
                parameters2[14].Value = models.子件代号;
                parameters2[15].Value = models.子件规格;
                parameters2[16].Value = models.子件计量单位;
                parameters2[17].Value = models.基本用量;
                parameters2[18].Value = models.基础用量;
                parameters2[19].Value = models.子件损耗率;
                parameters2[20].Value = models.固定用量;
                parameters2[21].Value = models.序号;
                parameters2[22].Value = models.供应类型;
                parameters2[23].Value = models.单阶使用数量;
                parameters2[24].Value = models.加成数量;
                parameters2[25].Value = models.换算率;
                parameters2[26].Value = models.子件生效日;
                parameters2[27].Value = models.子件失效日;
                parameters2[28].Value = models.偏置期;
                parameters2[29].Value = models.计划比例;
                parameters2[30].Value = models.产出品;
                parameters2[31].Value = models.产出类型;
                parameters2[32].Value = models.级别;
                parameters2[33].Value = models.成本相关;
                parameters2[34].Value = models.可选否;
                parameters2[35].Value = models.选择规则;
                parameters2[36].Value = models.备注;
                parameters2[37].Value = models.子件属性;
                parameters2[38].Value = models.母子关联;
                parameters2[39].Value = models.销售订单号;
                parameters2[40].Value = models.销售订单行号;
                parameters2[41].Value = models.销售订单子表ID;
                parameters2[42].Value = models.需求数量;
                parameters2[43].Value = models.顶级母件编码;
                parameters2[44].Value = models.评审数量;
                parameters2[45].Value = models.本单需求数量;
                parameters2[46].Value = models.交货日期;
                parameters2[47].Value = models.开始日期;
                parameters2[48].Value = models.结束日期;
                parameters2[49].Value = models.评审采购周期;
                parameters2[50].Value = models.评审委外周期;
                parameters2[51].Value = models.单件默认生产工时;
                parameters2[52].Value = models.默认产线;
                parameters2[53].Value = models.质检周期;
                parameters2[54].Value = models.母件编码;
                parameters2[55].Value = models.生产准备时间;
                parameters2[56].Value = models.经济批量;
                parameters2[57].Value = models.置办周期;
                parameters2[58].Value = models.生产合计工时;
                parameters2[59].Value = models.默认产线并发生产数;
                parameters2[60].Value = models.仓库存量;
                parameters2[61].Value = models.待入库数量;
                parameters2[62].Value = models.待出库数量;
                parameters2[63].Value = models.销售单号;
                parameters2[64].Value = models.仓库编码;
                parameters2[65].Value = models.母件名称;
                parameters2[66].Value = models.仓库名称;
                parameters2[67].Value = models.领料部门编码;
                parameters2[68].Value = models.生产部门编码;
                parameters2[69].Value = models.GUIDHead;
                parameters2[70].Value = models.GUID;
                parameters2[71].Value = models.母件代号;
                parameters2[72].Value = models.母件规格;

                cmd = new CommandInfo(strSql2.ToString(), parameters2);
                sqllist.Add(cmd);
            }
            return sqllist;
        }
    

		/// <summary>
		/// 删除一条数据，及子表所有相关数据
		/// </summary>
		public bool Delete(string sPSCode)
		{
            if (sPSCode == "")
                throw new Exception("请选择需要删除的单据");

            DataTable dtCode = GetPSListHead(sPSCode);
            if (dtCode == null || dtCode.Rows.Count == 0)
                throw new Exception("单据不存在，不能删除");

            //关闭单据不能删除
            if (dtCode.Rows[0]["关闭人"].ToString().Trim() != "")
                throw new Exception("单据已经关闭，不能删除");

            //审核单据不能删除
            if (dtCode.Rows[0]["审核人"].ToString().Trim() != "")
                throw new Exception("单据已经审核，不能删除");

            //使用单据不能删除

			List<CommandInfo> sqllist = new List<CommandInfo>();
			StringBuilder strSql2=new StringBuilder();
			strSql2.Append("delete 订单评审明细 ");
            strSql2.Append(" where 评审单据号=@评审单据号 ");
			SqlParameter[] parameters2 = {
					new SqlParameter("@评审单据号", SqlDbType.VarChar,50)};
            parameters2[0].Value = sPSCode;

			CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
			sqllist.Add(cmd);
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete 订单评审 ");
            strSql.Append(" where 评审单据号=@评审单据号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@评审单据号", SqlDbType.VarChar,50)			};
            parameters[0].Value = sPSCode;

			cmd = new CommandInfo(strSql.ToString(), parameters);
			sqllist.Add(cmd);
			int rowsAffected=DbHelperSQL.ExecuteSqlTran(sqllist);
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Guidlist )
		{
			List<string> sqllist = new List<string>();
			StringBuilder strSql2=new StringBuilder();
			strSql2.Append("delete from 订单评审明细 ");
			strSql2.Append(" where GUIDHead in ("+Guidlist + ")  ");
			sqllist.Add(strSql2.ToString());
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 订单评审 ");
			strSql.Append(" where Guid in ("+Guidlist + ")  ");
			sqllist.Add(strSql.ToString());
			int rowsAffected=DbHelperSQL.ExecuteSqlTran(sqllist);
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TH.Model.订单评审 DataRowToModel(DataRow row,DataTable dtDetail,string sPSCode)
		{
			TH.Model.订单评审 model=new TH.Model.订单评审();
			if (row != null)
			{
                //if(row["iID"]!=null && row["iID"].ToString()!="")
                //{
                //    model.iID=int.Parse(row["iID"].ToString());
                //}
				if(row["存货编码"]!=null && row["存货编码"].ToString()!="")
				{
					model.存货编码=row["存货编码"].ToString();
				}
				if(row["待评审数量"]!=null && row["待评审数量"].ToString()!="")
				{
					model.待评审数量=decimal.Parse(row["待评审数量"].ToString());
				}
				if(row["交货日期"]!=null && row["交货日期"].ToString()!="")
				{
					model.交货日期=DateTime.Parse(row["交货日期"].ToString());
				}
				if(row["订单数量"]!=null && row["订单数量"].ToString()!="")
				{
					model.订单数量=decimal.Parse(row["订单数量"].ToString());
				}
				if(row["已评审数量"]!=null && row["已评审数量"].ToString()!="")
				{
					model.已评审数量=decimal.Parse(row["已评审数量"].ToString());
				}
				if(row["销售订单子表ID"]!=null && row["销售订单子表ID"].ToString()!="")
				{
					model.销售订单子表ID=row["销售订单子表ID"].ToString();
				}
				if(row["数量"]!=null && row["数量"].ToString()!="")
				{
					model.数量=decimal.Parse(row["数量"].ToString());
				}
                //if(row["备注"]!=null && row["备注"].ToString()!="")
                //{
                //    model.备注=row["备注"].ToString();
                //}
				if(row["制单人"]!=null && row["制单人"].ToString()!="")
				{
					model.制单人=row["制单人"].ToString();
				}
				if(row["制单日期"]!=null && row["制单日期"].ToString()!="")
				{
					model.制单日期=DateTime.Parse(row["制单日期"].ToString());
				}
                model.评审单据号 = sPSCode;
				if(row["锁定人"]!=null && row["锁定人"].ToString()!="")
				{
					model.锁定人=row["锁定人"].ToString();
				}
				if(row["锁定日期"]!=null && row["锁定日期"].ToString()!="")
				{
					model.锁定日期=DateTime.Parse(row["锁定日期"].ToString());
				}
				if(row["审核人"]!=null && row["审核人"].ToString()!="")
				{
					model.审核人=row["审核人"].ToString();
				}
				if(row["审核日期"]!=null && row["审核日期"].ToString()!="")
				{
					model.审核日期=DateTime.Parse(row["审核日期"].ToString());
				}
				if(row["关闭人"]!=null && row["关闭人"].ToString()!="")
				{
					model.关闭人=row["关闭人"].ToString();
				}
				if(row["关闭日期"]!=null && row["关闭日期"].ToString()!="")
				{
					model.关闭日期=DateTime.Parse(row["关闭日期"].ToString());
				}
			
				if(row["评审单据日期"]!=null && row["评审单据日期"].ToString()!="")
				{
					model.评审单据日期=DateTime.Parse(row["评审单据日期"].ToString());
				}
			
				if(row["Guid"]!=null && row["Guid"].ToString()!="")
				{
					model.Guid= new Guid(row["Guid"].ToString());
				}
                //if(row["帐套号"]!=null && row["帐套号"].ToString()!="")
                //{
                //    model.帐套号=row["帐套号"].ToString();
                //}
                model.帐套号 = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);
				if(row["销售订单号"]!=null && row["销售订单号"].ToString()!="")
				{
					model.销售订单号=row["销售订单号"].ToString();
				}
				if(row["单据日期"]!=null && row["单据日期"].ToString()!="")
				{
					model.单据日期=row["单据日期"].ToString();
				}
				if(row["客户编码"]!=null && row["客户编码"].ToString()!="")
				{
					model.客户编码=row["客户编码"].ToString();
				}
				if(row["客户简称"]!=null && row["客户简称"].ToString()!="")
				{
					model.客户简称=row["客户简称"].ToString();
				}
				if(row["行号"]!=null && row["行号"].ToString()!="")
				{
					model.行号=row["行号"].ToString();
				}


                List<TH.Model.订单评审明细> l = new List<TH.Model.订单评审明细>();
                for(int i=0;i<dtDetail.Rows.Count;i++)
                {
                    TH.Model.订单评审明细 models = new TH.Model.订单评审明细();
                    models = DataRowToModels(dtDetail.Rows[i], sPSCode);
                    l.Add(models);
                }
                model.订单评审明细s = l;
                //dtDetail
			}
			return model;
		}

        public TH.Model.订单评审明细 DataRowToModels(DataRow row,string s评审单据号)
        {
            TH.Model.订单评审明细 model = new TH.Model.订单评审明细();
            if (row != null)
            {
                //if (row["iID"] != null && row["iID"].ToString() != "")
                //{
                //    model.iID = int.Parse(row["iID"].ToString());
                //}
                //if (row["评审单据号"] != null)
                //{
                model.评审单据号 = s评审单据号;
                //}
                if (row["序号"] != null)
                {
                    model.序号 = row["序号"].ToString();
                }
                if (row["级别"] != null)
                {
                    model.级别 = row["级别"].ToString();
                }
                if (row["顶级母件编码"] != null)
                {
                    model.顶级母件编码 = row["顶级母件编码"].ToString();
                }
                if (row["母件编码"] != null)
                {
                    model.母件编码 = row["母件编码"].ToString();
                }
                if (row["母件名称"] != null)
                {
                    model.母件名称 = row["母件名称"].ToString();
                }
                if (row["母件代号"] != null)
                {
                    model.母件代号 = row["母件代号"].ToString();
                }
                if (row["母件规格"] != null)
                {
                    model.母件规格 = row["母件规格"].ToString();
                }
                if (row["母件计量单位"] != null)
                {
                    model.母件计量单位 = row["母件计量单位"].ToString();
                }
                if (row["母件损耗率"] != null && row["母件损耗率"].ToString() != "")
                {
                    model.母件损耗率 = decimal.Parse(row["母件损耗率"].ToString());
                }
                if (row["版本代号"] != null)
                {
                    model.版本代号 = row["版本代号"].ToString();
                }
                if (row["版本说明"] != null)
                {
                    model.版本说明 = row["版本说明"].ToString();
                }
                if (row["版本日期"] != null && row["版本日期"].ToString() != "")
                {
                    model.版本日期 = DateTime.Parse(row["版本日期"].ToString());
                }
                if (row["状态"] != null)
                {
                    model.状态 = row["状态"].ToString();
                }
                if (row["母件属性"] != null)
                {
                    model.母件属性 = row["母件属性"].ToString();
                }
                if (row["变更单号"] != null)
                {
                    model.变更单号 = row["变更单号"].ToString();
                }
                if (row["行号"] != null)
                {
                    model.行号 = row["行号"].ToString();
                }
                if (row["子件行号"] != null)
                {
                    model.子件行号 = row["子件行号"].ToString();
                }
                if (row["工序行号"] != null)
                {
                    model.工序行号 = row["工序行号"].ToString();
                }
                if (row["子件编码"] != null)
                {
                    model.子件编码 = row["子件编码"].ToString();
                }
                if (row["子件名称"] != null)
                {
                    model.子件名称 = row["子件名称"].ToString();
                }
                if (row["子件代号"] != null)
                {
                    model.子件代号 = row["子件代号"].ToString();
                }
                if (row["子件规格"] != null)
                {
                    model.子件规格 = row["子件规格"].ToString();
                }
                if (row["子件计量单位"] != null)
                {
                    model.子件计量单位 = row["子件计量单位"].ToString();
                }
                if (row["基本用量"] != null && row["基本用量"].ToString() != "")
                {
                    model.基本用量 = decimal.Parse(row["基本用量"].ToString());
                }
                if (row["基础用量"] != null && row["基础用量"].ToString() != "")
                {
                    model.基础用量 = decimal.Parse(row["基础用量"].ToString());
                }
                if (row["子件损耗率"] != null && row["子件损耗率"].ToString() != "")
                {
                    model.子件损耗率 = decimal.Parse(row["子件损耗率"].ToString());
                }
                if (row["固定用量"] != null)
                {
                    model.固定用量 = row["固定用量"].ToString();
                }
                if (row["供应类型"] != null)
                {
                    model.供应类型 = row["供应类型"].ToString();
                }
                if (row["单阶使用数量"] != null && row["单阶使用数量"].ToString() != "")
                {
                    model.单阶使用数量 = decimal.Parse(row["单阶使用数量"].ToString());
                }
                if (row["加成数量"] != null && row["加成数量"].ToString() != "")
                {
                    model.加成数量 = decimal.Parse(row["加成数量"].ToString());
                }
                if (row["换算率"] != null && row["换算率"].ToString() != "")
                {
                    model.换算率 = decimal.Parse(row["换算率"].ToString());
                }
                if (row["子件生效日"] != null && row["子件生效日"].ToString() != "")
                {
                    model.子件生效日 = DateTime.Parse(row["子件生效日"].ToString());
                }
                if (row["子件失效日"] != null && row["子件失效日"].ToString() != "")
                {
                    model.子件失效日 = DateTime.Parse(row["子件失效日"].ToString());
                }
                if (row["偏置期"] != null && row["偏置期"].ToString() != "")
                {
                    model.偏置期 = int.Parse(row["偏置期"].ToString());
                }
                if (row["计划比例"] != null && row["计划比例"].ToString() != "")
                {
                    model.计划比例 = decimal.Parse(row["计划比例"].ToString());
                }
                if (row["产出品"] != null)
                {
                    model.产出品 = row["产出品"].ToString();
                }
                if (row["产出类型"] != null)
                {
                    model.产出类型 = row["产出类型"].ToString();
                }
                if (row["成本相关"] != null && row["成本相关"].ToString() != "")
                {
                    if ((row["成本相关"].ToString() == "1") || (row["成本相关"].ToString().ToLower() == "true"))
                    {
                        model.成本相关 = true;
                    }
                    else
                    {
                        model.成本相关 = false;
                    }
                }
                if (row["可选否"] != null && row["可选否"].ToString() != "")
                {
                    if ((row["可选否"].ToString() == "1") || (row["可选否"].ToString().ToLower() == "true"))
                    {
                        model.可选否 = true;
                    }
                    else
                    {
                        model.可选否 = false;
                    }
                }
                if (row["选择规则"] != null)
                {
                    model.选择规则 = row["选择规则"].ToString();
                }
                if (row["备注"] != null)
                {
                    model.备注 = row["备注"].ToString();
                }
                if (row["子件属性"] != null)
                {
                    model.子件属性 = row["子件属性"].ToString();
                }
                if (row["母子关联"] != null)
                {
                    model.母子关联 = row["母子关联"].ToString();
                }
                if (row["销售订单号"] != null)
                {
                    model.销售订单号 = row["销售订单号"].ToString();
                }
                if (row["销售订单行号"] != null)
                {
                    model.销售订单行号 = row["销售订单行号"].ToString();
                }
                if (row["销售订单子表ID"] != null && row["销售订单子表ID"].ToString() != "")
                {
                    model.销售订单子表ID = int.Parse(row["销售订单子表ID"].ToString());
                }
                if (row["需求数量"] != null && row["需求数量"].ToString() != "")
                {
                    model.需求数量 = decimal.Parse(row["需求数量"].ToString());
                }
                if (row["评审数量"] != null && row["评审数量"].ToString() != "")
                {
                    model.评审数量 = decimal.Parse(row["评审数量"].ToString());
                }
                if (row["本单需求数量"] != null && row["本单需求数量"].ToString() != "")
                {
                    model.本单需求数量 = decimal.Parse(row["本单需求数量"].ToString());
                }
                if (row["交货日期"] != null && row["交货日期"].ToString() != "")
                {
                    model.交货日期 = DateTime.Parse(row["交货日期"].ToString());
                }
                if (row["开始日期"] != null && row["开始日期"].ToString() != "")
                {
                    model.开始日期 = DateTime.Parse(row["开始日期"].ToString());
                }
                if (row["结束日期"] != null && row["结束日期"].ToString() != "")
                {
                    model.结束日期 = DateTime.Parse(row["结束日期"].ToString());
                }
                if (row["评审采购周期"] != null && row["评审采购周期"].ToString() != "")
                {
                    model.评审采购周期 = int.Parse(row["评审采购周期"].ToString());
                }
                if (row["评审委外周期"] != null && row["评审委外周期"].ToString() != "")
                {
                    model.评审委外周期 = int.Parse(row["评审委外周期"].ToString());
                }
                if (row["单件默认生产工时"] != null && row["单件默认生产工时"].ToString() != "")
                {
                    model.单件默认生产工时 = decimal.Parse(row["单件默认生产工时"].ToString());
                }
                if (row["默认产线"] != null)
                {
                    model.默认产线 = row["默认产线"].ToString();
                }
                if (row["质检周期"] != null && row["质检周期"].ToString() != "")
                {
                    model.质检周期 = decimal.Parse(row["质检周期"].ToString());
                }
                if (row["生产准备时间"] != null && row["生产准备时间"].ToString() != "")
                {
                    model.生产准备时间 = decimal.Parse(row["生产准备时间"].ToString());
                }
                if (row["经济批量"] != null && row["经济批量"].ToString() != "")
                {
                    model.经济批量 = decimal.Parse(row["经济批量"].ToString());
                }
                if (row["置办周期"] != null && row["置办周期"].ToString() != "")
                {
                    model.置办周期 = decimal.Parse(row["置办周期"].ToString());
                }
                if (row["生产合计工时"] != null && row["生产合计工时"].ToString() != "")
                {
                    model.生产合计工时 = decimal.Parse(row["生产合计工时"].ToString());
                }
                if (row["默认产线并发生产数"] != null && row["默认产线并发生产数"].ToString() != "")
                {
                    model.默认产线并发生产数 = decimal.Parse(row["默认产线并发生产数"].ToString());
                }
                if (row["仓库存量"] != null && row["仓库存量"].ToString() != "")
                {
                    model.仓库存量 = decimal.Parse(row["仓库存量"].ToString());
                }
                if (row["待入库数量"] != null && row["待入库数量"].ToString() != "")
                {
                    model.待入库数量 = decimal.Parse(row["待入库数量"].ToString());
                }
                if (row["待出库数量"] != null && row["待出库数量"].ToString() != "")
                {
                    model.待出库数量 = decimal.Parse(row["待出库数量"].ToString());
                }
                if (row["销售单号"] != null)
                {
                    model.销售单号 = row["销售单号"].ToString();
                }
                if (row["仓库编码"] != null)
                {
                    model.仓库编码 = row["仓库编码"].ToString();
                }
                if (row["仓库名称"] != null)
                {
                    model.仓库名称 = row["仓库名称"].ToString();
                }
                if (row["领料部门编码"] != null)
                {
                    model.领料部门编码 = row["领料部门编码"].ToString();
                }
                if (row["生产部门编码"] != null)
                {
                    model.生产部门编码 = row["生产部门编码"].ToString();
                }
                if (row["GUIDHead"] != null && row["GUIDHead"].ToString() != "")
                {
                    model.GUIDHead = new Guid(row["GUIDHead"].ToString());
                }
                if (row["GUID"] != null && row["GUID"].ToString() != "")
                {
                    model.GUID = new Guid(row["GUID"].ToString());
                }
            }
            return model;

        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select iID,产品编码,待评审数量,交货日期,订单数量,已评审数量,销售订单子表ID,数量,备注,制单人,制单日期,评审单据号,锁定人,锁定日期,审核人,审核日期,关闭人,关闭日期,下达请购人,下达请购日期,下达委外人,下达委外日期,评审单据日期,下达生产人,下达生产日期,Guid,帐套号,销售订单号,单据日期,客户编码,客户简称,行号 ");
			strSql.Append(" FROM 订单评审 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}    
        #endregion
	}
}

