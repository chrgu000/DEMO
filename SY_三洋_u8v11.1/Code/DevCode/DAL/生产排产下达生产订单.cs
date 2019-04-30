using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
     

    /// <summary>
    /// 数据访问类:生产排产发料计划
    /// </summary>
    public partial class 生产排产下达生产订单
    {
        public DataTable GetPCList(DateTime dTime1, DateTime dTime2, string sLineNo)
        {
            string sCol = "";

            DateTime dTime = dTime1;
            while (dTime <= dTime2)
            {
                sCol = sCol + ",sum(case when b.计划生产日期 = '" + dTime.ToString("yyyy-MM-dd") + "' then b.数量 end) as  数量" + dTime.ToString("yyMMdd");
                dTime = dTime.AddDays(1);
            }

            string sSQL = @"
select a.iID as 生产计划序号,a.来源GUID,a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,c.cInvName as 存货名称,c.cInvStd as 规格型号
	,a.数量 as 计划数量,a.产线编码,d.LineName as 产线 
	111111
	,cast( case when isnull(e.define34,'') = '' then 0 else 1 end as bit )as 已下单

from dbo.生产计划 a 
	left join dbo.生产日计划 b on a.GUID = b.来源GUID
	left join @u8.Inventory c on a.存货编码 = c.cInvCode
	left join dbo.ProductionLine d on a.产线编码 = d.[LineNo]
	left join (select distinct define34 from @u8.mom_orderdetail b inner join @u8.mom_order a on a.moid = b.moid  where a.mocode like '%444444%') e on e.define34 = a.iID
where b.计划生产日期 >= '222222' and b.计划生产日期 <= '333333' and 1=1
group by a.iID,a.来源GUID,a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,c.cInvName,c.cInvStd
	,a.数量,a.产线编码,d.LineName,e.define34
order by a.存货编码,a.产线编码
";
            sSQL = sSQL.Replace("111111", sCol);
            sSQL = sSQL.Replace("222222", dTime1.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("333333", dTime2.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("444444", dTime1.ToString("yyyyMMdd"));
            if (sLineNo.Trim().Length > 0)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.产线编码 = '" + sLineNo + "'");
            }

            return DbHelperSQL.Query(sSQL);
        }



        readonly string sBom = @"

select a.bomid,f.PartId,a.BomType,h.partid as PartIDs,c.OpComponentId 
	,g.cInvCode as 母件编码,g.cInvName as 母件名称,g.cInvAddCode as 母件代号,g.cInvStd as 母件规格
    ,j.cComUnitName as 母件计量单位,b.ParentScrap as 母件损耗率,a.Version as 版本代号
	,a.VersionDesc as 版本说明,a.VersionEffDate as 版本日期,case a.Status when 1 then '新建' when 3 then '审核' when 4 then '停用' end as 状态
	,case when ISNULL(g.bSelf,0) = 1 then '自制' when ISNULL(g.bProxyForeign,0) = 1 then '委外' end as 母件属性
	,a.ApplyDId as 变更单号,'' as 行号,c.SortSeq as 子件行号,c.OpSeq as 工序行号
	,i.cInvCode as 子件编码,i.cInvName as 子件名称,i.cInvAddCode as 子件代号,i.cInvStd as 子件规格,k.cComUnitName as 子件计量单位
	,c.BaseQtyN as 基本用量,c.BaseQtyD as 基础用量,c.CompScrap as 子件损耗率,case isnull(FVFlag,0) when 0 then '是' when 1 then '否' end as 固定用量,c.ChangeRate as 换算率
	,case d.WIPType when 1 then '入库倒冲' when 2 then '工序领用' when 3 then '领用' when 4 then '虚拟件' end as 供应类型, d.WIPType
	,c.BaseQtyN/c.BaseQtyD/(1-isnull(b.ParentScrap,0))*(1+isnull(c.CompScrap,0)) as 单阶使用数量,cast(null as decimal(16,6)) as 加成数量
	,c.EffBegDate as 子件生效日,c.EffEndDate as 子件失效日,d.Offset as 偏置期,d.PlanFactor as 计划比例,case isnull(c.ByproductFlag,0) when 0 then '否' else '是' end as 产出品
	,case isnull(c.ProductType,0) when 2 then '联产品' when 3 then '副产品' end as 产出类型,case ISNULL(d.AccuCostFlag,0) when 0 then  '否' else '是' end as 成本相关
	,case isnull(d.OptionalFlag,0) when 0 then '否' else '是' end as 可选否,'任意' as 选择规则,c.Remark as 备注
	,case when ISNULL(i.bSelf,0) = 1 then '自制' when ISNULL(i.bProxyForeign,0) = 1 then '委外' when ISNULL(i.bPurchase,0) = 1 then '采购' end as 子件属性
    ,cast(null as varchar(300)) as 母子关联
    ,cast(null as decimal(16,6)) as 需求数量,cast(null as decimal(16,6)) as 评审数量,cast(null as datetime) as 交货日期,cast(null as datetime) as 开始日期,cast(null as datetime) as 结束日期
    ,cast(l.cidefine1 as int) as 评审采购周期,cast(l.cidefine2 as int) as 评审委外周期,cast( l.cidefine3 / isnull(l.cidefine6,1) as decimal(16,10)) as 单件默认生产工时,l.cidefine4 默认产线,cast(l.cidefine5 as int) as 质检周期
    ,cast( l.cidefine3 / isnull(l.cidefine6,1) as decimal(16,10)) * 555555 as 生产合计工时
    ,cast(l.cidefine7 as  decimal(16,2)) as 生产准备时间,cast(l.cidefine8 as  decimal(16,2)) as 经济批量
    ,case when ISNULL(i.bSelf,0) = 1 then cast (null as int) when ISNULL(i.bProxyForeign,0) = 1 then cast(l.cidefine2 as int) when ISNULL(i.bPurchase,0) = 1 then cast(l.cidefine1 as int) end as 置办周期
    ,isnull(l.cidefine9,1) as 默认产线并发生产数
    ,cast(null as  decimal(16,6)) as 仓库存量,cast(null as  decimal(16,6)) as 待入库数量,cast(l.cidefine8 as  decimal(16,6)) as 待出库数量,cast(null as decimal(16,6)) as 本单需求数量
    ,cast (null as uniqueidentifier) as GUID,cast (null as uniqueidentifier) as GUIDHead
    ,d.Whcode as 仓库编码,cast (null as varchar(50)) as 仓库名称,d.DrawDeptCode as 领料部门编码,m.cInvDepCode as 生产部门编码
    ,cast (null as varchar(50)) as 评审单据号,null as iID
from @u8.bom_bom a 
    inner join @u8.bom_parent b on a.bomid = b.BomId 
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
    left join @u8.Inventory m on m.cInvCode = f.InvCode 
where 1=-1 and a.Status = 3
order by c.SortSeq,g.cInvCode,i.cInvCode
";


        DataTable dtBom = new DataTable();
        public int Save(DateTime dTime, DataTable dtDetails)
        {
            string sErr = "";

            DateTime dTimeNow = DbHelperSQL.ExecuteGetServerTime();
            DateTime dTimeDay = BaseFunction.BaseFunction.ReturnDate(dTimeNow.ToString("yyyy-MM-dd"));
            string sAccid = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);

            if (dtDetails == null || dtDetails.Rows.Count == 0)
            {
                throw new Exception("没有需要下达生产的数据");
            }

            int iCou = 0;

            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                ////获得单据ID号
                long iIDmom_order = 0;
                long iIDmom_orderdetail;
                long iIDmom_moallocate;

                string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_order'";
                DataTable dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtID == null || dtID.Rows.Count < 1)
                {
                    iIDmom_order = 0;
                }
                else
                {
                    iIDmom_order = Convert.ToInt64(dtID.Rows[0]["iChildID"]);
                }
                iIDmom_order += 1;

                sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_orderdetail'";
                dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtID == null || dtID.Rows.Count < 1)
                {
                    iIDmom_orderdetail = 0;
                }
                else
                {
                    iIDmom_orderdetail = Convert.ToInt64(dtID.Rows[0]["iChildID"]);
                }
                sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_moallocate'";
                dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtID == null || dtID.Rows.Count < 1)
                {
                    iIDmom_moallocate = 0;
                }
                else
                {
                    iIDmom_moallocate = Convert.ToInt64(dtID.Rows[0]["iChildID"]);
                }

                string s产线编码 = dtDetails.Rows[0]["产线编码"].ToString().Trim();

                sSQL = "select a.[LineNo],a.LineName,a.cDepCode,b.Remark from dbo.ProductionLine a left join _LookUpDate b on b.iType = '13' and a.cDepCode = b.iID order by a.[LineNo]";
                DataTable dt生产订单规则 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                string s生产订单号 = dTime.ToString("yyyyMMdd");
                DataRow[] dr生产订单规则 = dt生产订单规则.Select("LineNo = '" + s产线编码 + "'");
                if (dr生产订单规则.Length > 0)
                {
                    if (dr生产订单规则[0]["Remark"].ToString().Trim() != "")
                    {
                        s生产订单号 = dr生产订单规则[0]["Remark"].ToString().Trim() + s生产订单号;
                    }
                    else
                    {
                        throw new Exception("请设置部门生产订单对照档案");
                    }
                }

                //判断生产订单是否存在,存在则在后面增加流水号
                sSQL = "select a.Moid,a.MoCode from @u8.mom_order a where a.MoCode like '" + s生产订单号 + "%' order by a.MoCode desc,a.Moid desc";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    //当该产线在这一天已经有了生产订单则后缀增加1
                    string[] sCodeList = dtTemp.Rows[0]["MoCode"].ToString().Trim().Split('-');
                    int iCodeList = 1;
                    if (sCodeList.Length > 1)
                    {
                        iCodeList = BaseFunction.BaseFunction.ReturnInt(sCodeList[1].Trim());
                    }
                    iCodeList += 1;
                    s生产订单号 = sCodeList[0].Trim() + "-" + iCodeList.ToString();
                }

                bool bChoose = false;
                bool bFirst = true;
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {

                    if (!BaseFunction.BaseFunction.ReturnBool(dtDetails.Rows[i]["选择"]))
                        continue;

                    bChoose = true;
                    decimal dQty = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["数量" + dTime.ToString("yyMMdd")]);
                    if (dQty <= 0)
                        continue;

                    long l生产计划序号 = BaseFunction.BaseFunction.ReturnLong(dtDetails.Rows[i]["生产计划序号"]);
                    sSQL = "select a.Moid from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MOid = b.Moid where a.MoCode like '%" + dTime.ToString("yyyyMMdd") + "%' and b.Define28 = '" + s产线编码 + "' and Define34 = " + l生产计划序号;
                    DataTable dtTemp3 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp3 != null && dtTemp3.Rows.Count > 0)
                    {
                        sErr = sErr + "生产计划序号" + l生产计划序号.ToString() + "已经有了生产订单\n";
                        continue;
                    }

                    if (bFirst)
                    {
                        sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_order + ",iChildID=" + iIDmom_order + " where  cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_order'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        TH.Model.mom_order Modelmom_order = new TH.Model.mom_order();
                        Modelmom_order.MoId = ReturnID(iIDmom_order);
                        Modelmom_order.MoCode = s生产订单号;
                        Modelmom_order.CreateDate = dTimeDay;
                        Modelmom_order.CreateUser = FrameBaseFunction.ClsBaseDataInfo.sUid;
                        Modelmom_order.UpdCount = 0;
                        Modelmom_order.VTid = 30413;
                        Modelmom_order.CreateTime = dTimeNow;
                        Modelmom_order.iPrintCount = 0;
                        Modelmom_order.RelsVTid = 0;

                        sSQL = Addmom_order(Modelmom_order);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        bFirst = false;
                    }


                    string s物料编码 = dtDetails.Rows[i]["存货编码"].ToString().Trim();

                    dtBom = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sBom).Tables[0];
                    GetBom多阶(s物料编码, s物料编码, 1, "");

                    if (dtBom == null || dtBom.Rows.Count == 0)
                    {
                        throw new Exception("获得物料 " + s物料编码 + " BOM失败");
                    }

                    iIDmom_orderdetail += 1;

                    TH.Model.mom_orderdetail Modelmom_ordertail = new TH.Model.mom_orderdetail();
                    Modelmom_ordertail.MoDId = ReturnID(iIDmom_orderdetail);
                    Modelmom_ordertail.MoId = ReturnID(iIDmom_order);

                    sSQL = "select max(SortSeq) as 行号 from @u8.mom_orderdetail where moid = " + Modelmom_ordertail.MoId;
                    DataTable dtTemp2 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sBom).Tables[0];
                    int iRow行 = 1;
                    if (dtTemp2 != null && dtTemp2.Rows.Count > 0)
                    {
                        iRow行 = BaseFunction.BaseFunction.ReturnInt(dtTemp2.Rows[0]["行号"]) + 1;
                    }

                    Modelmom_ordertail.SortSeq = iRow行;

                    //三洋默认使用非标准订单
                    Modelmom_ordertail.MoClass = 2;
                    sSQL = "select * from @u8.Inventory where cInvCode = '" + s物料编码 + "'";
                    DataTable dtInvPro = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    //if (BaseFunction.BaseFunction.ReturnInt(dtInvPro.Rows[0]["bATOModel"]) == 1)
                    //{
                    //    //ATO物料为非标准订单
                    //    Modelmom_ordertail.MoClass = 2;
                    //}
                    //if (BaseFunction.BaseFunction.ReturnInt(dtInvPro.Rows[0]["bPTOModel"]) == 1)
                    //{
                    //    //PTO物料为非标准订单
                    //    Modelmom_ordertail.MoClass = 2;
                    //}
                    //if (BaseFunction.BaseFunction.ReturnInt(dtInvPro.Rows[0]["bInvModel"]) == 1)
                    //{
                    //    //PTO物料为非标准订单
                    //    Modelmom_ordertail.MoClass = 2;
                    //}

                    //Modelmom_ordertail.MoTypeId = 
                    Modelmom_ordertail.Qty = dQty;
                    Modelmom_ordertail.MrpQty = dQty;
                    //Modelmom_ordertail.AuxUnitCode
                    //Modelmom_ordertail.AuxQty = 0;
                    //Modelmom_ordertail.ChangeRate = 0;
                    //Modelmom_ordertail.MoLotCode 
                    Modelmom_ordertail.WhCode = dtInvPro.Rows[0]["cDefWareHouse"].ToString().Trim();
                    Modelmom_ordertail.MDeptCode = dr生产订单规则[0]["cDepCode"].ToString().Trim();
                    Modelmom_ordertail.SoType = 0;
                    //Modelmom_ordertail.SoDId = 
                    //Modelmom_ordertail.SoCode = 
                    //Modelmom_ordertail.SoSeq = 
                    Modelmom_ordertail.DeclaredQty = 0;
                    Modelmom_ordertail.QualifiedInQty = 0;
                    Modelmom_ordertail.Status = 1;
                    Modelmom_ordertail.OrgStatus = 1;
                    Modelmom_ordertail.BomId = BaseFunction.BaseFunction.ReturnLong(dtBom.Rows[0]["bomid"]);
                    Modelmom_ordertail.RoutingId = 0;
                    Modelmom_ordertail.CustBomId = 0;
                    Modelmom_ordertail.DemandId = 0;
                    //Modelmom_ordertail.PlanCode
                    Modelmom_ordertail.PartId = BaseFunction.BaseFunction.ReturnLong(dtBom.Rows[0]["PartId"]);
                    Modelmom_ordertail.InvCode = s物料编码;
                    Modelmom_ordertail.SfcFlag = false;
                    Modelmom_ordertail.CrpFlag = false;
                    Modelmom_ordertail.QcFlag = false;
                    Modelmom_ordertail.LeadTime = 0;
                    Modelmom_ordertail.OpScheduleType = 1;
                    Modelmom_ordertail.OrdFlag = false;
                    //默认使用5
                    Modelmom_ordertail.WIPType = 5;
                    Modelmom_ordertail.IsWFControlled = 0;
                    Modelmom_ordertail.iVerifyState = 0;
                    Modelmom_ordertail.iReturnCount = 0;
                    Modelmom_ordertail.SourceMoId = 0;
                    Modelmom_ordertail.SourceMoDId = 0;
                    Modelmom_ordertail.SourceQCId = 0;
                    Modelmom_ordertail.SourceQCDId = 0;
                    Modelmom_ordertail.AuditStatus = 1;
                    Modelmom_ordertail.PAllocateId = 0;
                    Modelmom_ordertail.CollectiveFlag = 0;
                    Modelmom_ordertail.OrderType = 0;
                    Modelmom_ordertail.OrderDId = 0;
                    Modelmom_ordertail.ReformFlag = false;
                    Modelmom_ordertail.SourceQCVouchType = 0;
                    Modelmom_ordertail.OrgQty = 0;
                    Modelmom_ordertail.FmFlag = false;
                    Modelmom_ordertail.BomType = BaseFunction.BaseFunction.ReturnInt(dtBom.Rows[0]["BomType"]);
                    Modelmom_ordertail.RoutingType = 0;
                    Modelmom_ordertail.RunCardFlag = false;
                    Modelmom_ordertail.RequisitionFlag = false;
                    Modelmom_ordertail.AlloVTid = 0;
                    Modelmom_ordertail.RelsAlloVTid = 0;
                    Modelmom_ordertail.iPrintCount = 0;
                    Modelmom_ordertail.Define23 = dtDetails.Rows[i]["销售订单号"].ToString().Trim();
                    Modelmom_ordertail.Define28 = dtDetails.Rows[i]["产线编码"].ToString().Trim();
                    Modelmom_ordertail.Define34 = BaseFunction.BaseFunction.ReturnLong(dtDetails.Rows[i]["生产计划序号"]);

                    sSQL = Addmom_orderdetail(Modelmom_ordertail);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    TH.Model.mom_morder Modelmom_morder = new TH.Model.mom_morder();
                    Modelmom_morder.DueDate = dTime;
                    Modelmom_morder.MoDId = ReturnID(iIDmom_orderdetail);
                    Modelmom_morder.MoId = ReturnID(iIDmom_order);
                    Modelmom_morder.StartDate = dTime;

                    sSQL = Addmom_morder(Modelmom_morder);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int j = 0; j < dtBom.Rows.Count; j++)
                    {
                        iIDmom_moallocate += 1;
                        TH.Model.mom_moallocate Modelmom_moallocate = new TH.Model.mom_moallocate();
                        Modelmom_moallocate.AllocateId = ReturnID(iIDmom_moallocate);
                        Modelmom_moallocate.MoDId = ReturnID(iIDmom_orderdetail);
                        Modelmom_moallocate.SortSeq = j + 1;
                        Modelmom_moallocate.OpSeq = "0000";
                        Modelmom_moallocate.ComponentId = BaseFunction.BaseFunction.ReturnLong(dtBom.Rows[j]["PartIDs"]);
                        Modelmom_moallocate.FVFlag = 1;
                        Modelmom_moallocate.BaseQtyN = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["基本用量"]);
                        Modelmom_moallocate.BaseQtyD = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["基础用量"]);
                        Modelmom_moallocate.ParentScrap = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["母件损耗率"]);
                        Modelmom_moallocate.CompScrap = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["母件损耗率"]);

                        decimal d母件数量 = dQty;
                        decimal d使用数量 = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["单阶使用数量"]);
                        Modelmom_moallocate.Qty = BaseFunction.BaseFunction.ReturnDecimal(d母件数量 * d使用数量);
                        Modelmom_moallocate.IssQty = 0;
                        Modelmom_moallocate.DeclaredQty = 0;
                        Modelmom_moallocate.StartDemDate = dTime;
                        Modelmom_moallocate.EndDemDate = dTime;
                        Modelmom_moallocate.WhCode = dtBom.Rows[j]["仓库编码"].ToString().Trim();
                        //Modelmom_moallocate.LotNo 
                        Modelmom_moallocate.WIPType = BaseFunction.BaseFunction.ReturnInt(dtBom.Rows[j]["WIPType"]);
                        Modelmom_moallocate.ByproductFlag = false;
                        Modelmom_moallocate.QcFlag = false;
                        Modelmom_moallocate.Offset = 0;
                        Modelmom_moallocate.InvCode = dtBom.Rows[j]["子件编码"].ToString().Trim();
                        Modelmom_moallocate.OpComponentId = BaseFunction.BaseFunction.ReturnLong(dtBom.Rows[j]["OpComponentId"]);
                        //Modelmom_moallocate.AuxUnitCode 
                        //Modelmom_moallocate.ChangeRate = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["换算率"]);
                        //Modelmom_moallocate.AuxBaseQtyN = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["基本用量"]);
                        //Modelmom_moallocate.AuxQty = BaseFunction.BaseFunction.ReturnDecimal(d母件数量 * d使用数量);
                        Modelmom_moallocate.ReplenishQty = 0;
                        Modelmom_moallocate.TransQty = 0;
                        Modelmom_moallocate.ProductType = 1;
                        Modelmom_moallocate.SoType = 0;
                        //Modelmom_moallocate.SoDId = 
                        //Modelmom_moallocate.SoCode 
                        //Modelmom_moallocate.SoSeq
                        //Modelmom_moallocate.DemandCode
                        Modelmom_moallocate.QmFlag = false;
                        Modelmom_moallocate.OrgQty = 0;
                        Modelmom_moallocate.OrgAuxQty = 0;
                        Modelmom_moallocate.RequisitionFlag = false;
                        Modelmom_moallocate.RequisitionQty = 0;
                        Modelmom_moallocate.RequisitionIssQty = 0;
                        Modelmom_moallocate.CostWIPRel = false;
                        Modelmom_moallocate.PickingQty = 0;
                        Modelmom_moallocate.PickingAuxQty = 0;

                        sSQL = Addmom_moallocate(Modelmom_moallocate);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }

                if (!bChoose)
                    throw new Exception("请选择需要保存的单据");

                if (sErr.Trim().Length > 0)
                    throw new Exception(sErr);

                //更新最大ID
                //sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_order + ",iChildID=" + iIDmom_order + " where  cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_order'";
                //DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_orderdetail + ",iChildID=" + iIDmom_orderdetail + " where  cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_orderdetail'";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_moallocate + ",iChildID=" + iIDmom_moallocate + " where  cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_moallocate'";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                if (iCou > 0)
                {
                    tran.Commit();
                }
            }
            catch (Exception error)
            {
                tran.Rollback();
                iCou = 0;
                throw new Exception(error.Message);
            }

            return iCou;
        }

        public long ReturnID(long l)
        {
            string s = l.ToString().Trim();

            while (s.Length < 9)
            {
                s = "0" + s;
            }
            s = "1" + s;

            long l2 = BaseFunction.BaseFunction.ReturnLong(s);
            return l2;
        }


        /// <summary>
        /// 展开虚拟件
        /// </summary>
        /// <returns></returns>
        public void GetBom多阶(string s母件编码, string s本阶母件编码, decimal d加成数量, string sBomID)
        {
            string sSQL = sBom;
            string sSQLWhere = "f.InvCode = '" + s本阶母件编码 + "'";
            sSQL = sSQL.Replace("1=-1", sSQLWhere);
            DataTable dtBomTemp = DbHelperSQL.Query(sSQL);

            if (dtBomTemp != null && dtBomTemp.Rows.Count > 0)
            {
                for (int i = 0; i < dtBomTemp.Rows.Count; i++)
                {
                    string s母 = dtBomTemp.Rows[i]["母件编码"].ToString().Trim();
                    string s子 = dtBomTemp.Rows[i]["子件编码"].ToString().Trim();

                    string s供应类型 = dtBomTemp.Rows[i]["供应类型"].ToString().Trim();
                    decimal d单阶使用数量 = BaseFunction.BaseFunction.ReturnDecimal(dtBomTemp.Rows[i]["单阶使用数量"]);

                    if (sBomID == "")
                    {
                        sBomID = dtBomTemp.Rows[i]["bomid"].ToString().Trim();
                    }
                    string sOpComponentId = dtBomTemp.Rows[i]["OpComponentId"].ToString().Trim();

                    decimal d加成计算数量 = BaseFunction.BaseFunction.ReturnDecimal(d单阶使用数量 * d加成数量, 6);
                    if (s供应类型 != "虚拟件")
                    {
                        DataRow drBom = dtBom.NewRow();
                        drBom.ItemArray = dtBomTemp.Rows[i].ItemArray;
                        drBom["单阶使用数量"] = d加成计算数量;
                        drBom["基本用量"] = d加成计算数量;

                        string sSQLInvoentory = @"
select * from @u8.inventory a inner join @u8.bas_part b on a.cInvCode = b.InvCode where a.cInvCode = '111111'
";
                        sSQLInvoentory = sSQLInvoentory.Replace("111111", s母件编码);
                        DataTable dtInv = DbHelperSQL.Query(sSQLInvoentory);

                        drBom["母件编码"] = s母件编码;
                        drBom["PartID"] = dtInv.Rows[0]["PartID"].ToString().Trim();
                        drBom["bomid"] = sBomID;
                        drBom["OpComponentId"] = sOpComponentId;
                        dtBom.Rows.Add(drBom);
                    }
                    else
                    {
                        string sInvCode = dtBomTemp.Rows[i]["子件编码"].ToString().Trim();

                        GetBom多阶(s母件编码, sInvCode, d加成计算数量, sBomID);
                    }
                }
            }
        }


        #region 代码生成器

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Addmom_order(TH.Model.mom_order model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.MoId != null)
            {
                strSql1.Append("MoId,");
                strSql2.Append("" + model.MoId + ",");
            }
            if (model.MoCode != null)
            {
                strSql1.Append("MoCode,");
                strSql2.Append("'" + model.MoCode + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.CreateUser != null)
            {
                strSql1.Append("CreateUser,");
                strSql2.Append("'" + model.CreateUser + "',");
            }
            if (model.ModifyDate != null)
            {
                strSql1.Append("ModifyDate,");
                strSql2.Append("'" + model.ModifyDate + "',");
            }
            if (model.ModifyUser != null)
            {
                strSql1.Append("ModifyUser,");
                strSql2.Append("'" + model.ModifyUser + "',");
            }
            if (model.UpdCount != null)
            {
                strSql1.Append("UpdCount,");
                strSql2.Append("" + model.UpdCount + ",");
            }
            if (model.Ufts != null)
            {
                strSql1.Append("Ufts,");
                strSql2.Append("" + model.Ufts + ",");
            }
            if (model.Define1 != null)
            {
                strSql1.Append("Define1,");
                strSql2.Append("'" + model.Define1 + "',");
            }
            if (model.Define2 != null)
            {
                strSql1.Append("Define2,");
                strSql2.Append("'" + model.Define2 + "',");
            }
            if (model.Define3 != null)
            {
                strSql1.Append("Define3,");
                strSql2.Append("'" + model.Define3 + "',");
            }
            if (model.Define4 != null)
            {
                strSql1.Append("Define4,");
                strSql2.Append("'" + model.Define4 + "',");
            }
            if (model.Define5 != null)
            {
                strSql1.Append("Define5,");
                strSql2.Append("" + model.Define5 + ",");
            }
            if (model.Define6 != null)
            {
                strSql1.Append("Define6,");
                strSql2.Append("'" + model.Define6 + "',");
            }
            if (model.Define7 != null)
            {
                strSql1.Append("Define7,");
                strSql2.Append("" + model.Define7 + ",");
            }
            if (model.Define8 != null)
            {
                strSql1.Append("Define8,");
                strSql2.Append("'" + model.Define8 + "',");
            }
            if (model.Define9 != null)
            {
                strSql1.Append("Define9,");
                strSql2.Append("'" + model.Define9 + "',");
            }
            if (model.Define10 != null)
            {
                strSql1.Append("Define10,");
                strSql2.Append("'" + model.Define10 + "',");
            }
            if (model.Define11 != null)
            {
                strSql1.Append("Define11,");
                strSql2.Append("'" + model.Define11 + "',");
            }
            if (model.Define12 != null)
            {
                strSql1.Append("Define12,");
                strSql2.Append("'" + model.Define12 + "',");
            }
            if (model.Define13 != null)
            {
                strSql1.Append("Define13,");
                strSql2.Append("'" + model.Define13 + "',");
            }
            if (model.Define14 != null)
            {
                strSql1.Append("Define14,");
                strSql2.Append("'" + model.Define14 + "',");
            }
            if (model.Define15 != null)
            {
                strSql1.Append("Define15,");
                strSql2.Append("" + model.Define15 + ",");
            }
            if (model.Define16 != null)
            {
                strSql1.Append("Define16,");
                strSql2.Append("" + model.Define16 + ",");
            }
            if (model.VTid != null)
            {
                strSql1.Append("VTid,");
                strSql2.Append("" + model.VTid + ",");
            }
            if (model.CreateTime != null)
            {
                strSql1.Append("CreateTime,");
                strSql2.Append("'" + model.CreateTime + "',");
            }
            if (model.ModifyTime != null)
            {
                strSql1.Append("ModifyTime,");
                strSql2.Append("'" + model.ModifyTime + "',");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.RelsVTid != null)
            {
                strSql1.Append("RelsVTid,");
                strSql2.Append("" + model.RelsVTid + ",");
            }
            if (model.cSysBarCode != null)
            {
                strSql1.Append("cSysBarCode,");
                strSql2.Append("'" + model.cSysBarCode + "',");
            }
            strSql.Append("insert into @u8.mom_order(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();

        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Addmom_orderdetail(TH.Model.mom_orderdetail model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.MoDId != null)
            {
                strSql1.Append("MoDId,");
                strSql2.Append("" + model.MoDId + ",");
            }
            if (model.MoId != null)
            {
                strSql1.Append("MoId,");
                strSql2.Append("" + model.MoId + ",");
            }
            if (model.SortSeq != null)
            {
                strSql1.Append("SortSeq,");
                strSql2.Append("" + model.SortSeq + ",");
            }
            if (model.MoClass != null)
            {
                strSql1.Append("MoClass,");
                strSql2.Append("" + model.MoClass + ",");
            }
            if (model.MoTypeId != null)
            {
                strSql1.Append("MoTypeId,");
                strSql2.Append("" + model.MoTypeId + ",");
            }
            if (model.Qty != null)
            {
                strSql1.Append("Qty,");
                strSql2.Append("" + model.Qty + ",");
            }
            if (model.MrpQty != null)
            {
                strSql1.Append("MrpQty,");
                strSql2.Append("" + model.MrpQty + ",");
            }
            if (model.AuxUnitCode != null)
            {
                strSql1.Append("AuxUnitCode,");
                strSql2.Append("'" + model.AuxUnitCode + "',");
            }
            if (model.AuxQty != null)
            {
                strSql1.Append("AuxQty,");
                strSql2.Append("" + model.AuxQty + ",");
            }
            if (model.ChangeRate != null)
            {
                strSql1.Append("ChangeRate,");
                strSql2.Append("" + model.ChangeRate + ",");
            }
            if (model.MoLotCode != null)
            {
                strSql1.Append("MoLotCode,");
                strSql2.Append("'" + model.MoLotCode + "',");
            }
            if (model.WhCode != null)
            {
                strSql1.Append("WhCode,");
                strSql2.Append("'" + model.WhCode + "',");
            }
            if (model.MDeptCode != null)
            {
                strSql1.Append("MDeptCode,");
                strSql2.Append("'" + model.MDeptCode + "',");
            }
            if (model.SoType != null)
            {
                strSql1.Append("SoType,");
                strSql2.Append("" + model.SoType + ",");
            }
            if (model.SoDId != null)
            {
                strSql1.Append("SoDId,");
                strSql2.Append("'" + model.SoDId + "',");
            }
            if (model.SoCode != null)
            {
                strSql1.Append("SoCode,");
                strSql2.Append("'" + model.SoCode + "',");
            }
            if (model.SoSeq != null)
            {
                strSql1.Append("SoSeq,");
                strSql2.Append("" + model.SoSeq + ",");
            }
            if (model.DeclaredQty != null)
            {
                strSql1.Append("DeclaredQty,");
                strSql2.Append("" + model.DeclaredQty + ",");
            }
            if (model.QualifiedInQty != null)
            {
                strSql1.Append("QualifiedInQty,");
                strSql2.Append("" + model.QualifiedInQty + ",");
            }
            if (model.Status != null)
            {
                strSql1.Append("Status,");
                strSql2.Append("" + model.Status + ",");
            }
            if (model.OrgStatus != null)
            {
                strSql1.Append("OrgStatus,");
                strSql2.Append("" + model.OrgStatus + ",");
            }
            if (model.BomId != null)
            {
                strSql1.Append("BomId,");
                strSql2.Append("" + model.BomId + ",");
            }
            if (model.RoutingId != null)
            {
                strSql1.Append("RoutingId,");
                strSql2.Append("" + model.RoutingId + ",");
            }
            if (model.CustBomId != null)
            {
                strSql1.Append("CustBomId,");
                strSql2.Append("" + model.CustBomId + ",");
            }
            if (model.DemandId != null)
            {
                strSql1.Append("DemandId,");
                strSql2.Append("" + model.DemandId + ",");
            }
            if (model.PlanCode != null)
            {
                strSql1.Append("PlanCode,");
                strSql2.Append("'" + model.PlanCode + "',");
            }
            if (model.PartId != null)
            {
                strSql1.Append("PartId,");
                strSql2.Append("" + model.PartId + ",");
            }
            if (model.InvCode != null)
            {
                strSql1.Append("InvCode,");
                strSql2.Append("'" + model.InvCode + "',");
            }
            if (model.Free1 != null)
            {
                strSql1.Append("Free1,");
                strSql2.Append("'" + model.Free1 + "',");
            }
            if (model.Free2 != null)
            {
                strSql1.Append("Free2,");
                strSql2.Append("'" + model.Free2 + "',");
            }
            if (model.Free3 != null)
            {
                strSql1.Append("Free3,");
                strSql2.Append("'" + model.Free3 + "',");
            }
            if (model.Free4 != null)
            {
                strSql1.Append("Free4,");
                strSql2.Append("'" + model.Free4 + "',");
            }
            if (model.Free5 != null)
            {
                strSql1.Append("Free5,");
                strSql2.Append("'" + model.Free5 + "',");
            }
            if (model.Free6 != null)
            {
                strSql1.Append("Free6,");
                strSql2.Append("'" + model.Free6 + "',");
            }
            if (model.Free7 != null)
            {
                strSql1.Append("Free7,");
                strSql2.Append("'" + model.Free7 + "',");
            }
            if (model.Free8 != null)
            {
                strSql1.Append("Free8,");
                strSql2.Append("'" + model.Free8 + "',");
            }
            if (model.Free9 != null)
            {
                strSql1.Append("Free9,");
                strSql2.Append("'" + model.Free9 + "',");
            }
            if (model.Free10 != null)
            {
                strSql1.Append("Free10,");
                strSql2.Append("'" + model.Free10 + "',");
            }
            if (model.SfcFlag != null)
            {
                strSql1.Append("SfcFlag,");
                strSql2.Append("" + (model.SfcFlag ? 1 : 0) + ",");
            }
            if (model.CrpFlag != null)
            {
                strSql1.Append("CrpFlag,");
                strSql2.Append("" + (model.CrpFlag ? 1 : 0) + ",");
            }
            if (model.QcFlag != null)
            {
                strSql1.Append("QcFlag,");
                strSql2.Append("" + (model.QcFlag ? 1 : 0) + ",");
            }
            if (model.RelsDate != null)
            {
                strSql1.Append("RelsDate,");
                strSql2.Append("'" + model.RelsDate + "',");
            }
            if (model.RelsUser != null)
            {
                strSql1.Append("RelsUser,");
                strSql2.Append("'" + model.RelsUser + "',");
            }
            if (model.CloseDate != null)
            {
                strSql1.Append("CloseDate,");
                strSql2.Append("'" + model.CloseDate + "',");
            }
            if (model.OrgClsDate != null)
            {
                strSql1.Append("OrgClsDate,");
                strSql2.Append("'" + model.OrgClsDate + "',");
            }
            //if (model.Ufts != null)
            //{
            //    strSql1.Append("Ufts,");
            //    strSql2.Append("" + model.Ufts + ",");
            //}
            if (model.Define22 != null)
            {
                strSql1.Append("Define22,");
                strSql2.Append("'" + model.Define22 + "',");
            }
            if (model.Define23 != null)
            {
                strSql1.Append("Define23,");
                strSql2.Append("'" + model.Define23 + "',");
            }
            if (model.Define24 != null)
            {
                strSql1.Append("Define24,");
                strSql2.Append("'" + model.Define24 + "',");
            }
            if (model.Define25 != null)
            {
                strSql1.Append("Define25,");
                strSql2.Append("'" + model.Define25 + "',");
            }
            if (model.Define26 != null)
            {
                strSql1.Append("Define26,");
                strSql2.Append("" + model.Define26 + ",");
            }
            if (model.Define27 != null)
            {
                strSql1.Append("Define27,");
                strSql2.Append("" + model.Define27 + ",");
            }
            if (model.Define28 != null)
            {
                strSql1.Append("Define28,");
                strSql2.Append("'" + model.Define28 + "',");
            }
            if (model.Define29 != null)
            {
                strSql1.Append("Define29,");
                strSql2.Append("'" + model.Define29 + "',");
            }
            if (model.Define30 != null)
            {
                strSql1.Append("Define30,");
                strSql2.Append("'" + model.Define30 + "',");
            }
            if (model.Define31 != null)
            {
                strSql1.Append("Define31,");
                strSql2.Append("'" + model.Define31 + "',");
            }
            if (model.Define32 != null)
            {
                strSql1.Append("Define32,");
                strSql2.Append("'" + model.Define32 + "',");
            }
            if (model.Define33 != null)
            {
                strSql1.Append("Define33,");
                strSql2.Append("'" + model.Define33 + "',");
            }
            if (model.Define34 != null)
            {
                strSql1.Append("Define34,");
                strSql2.Append("" + model.Define34 + ",");
            }
            if (model.Define35 != null)
            {
                strSql1.Append("Define35,");
                strSql2.Append("" + model.Define35 + ",");
            }
            if (model.Define36 != null)
            {
                strSql1.Append("Define36,");
                strSql2.Append("'" + model.Define36 + "',");
            }
            if (model.Define37 != null)
            {
                strSql1.Append("Define37,");
                strSql2.Append("'" + model.Define37 + "',");
            }
            if (model.LeadTime != null)
            {
                strSql1.Append("LeadTime,");
                strSql2.Append("" + model.LeadTime + ",");
            }
            if (model.OpScheduleType != null)
            {
                strSql1.Append("OpScheduleType,");
                strSql2.Append("" + model.OpScheduleType + ",");
            }
            if (model.OrdFlag != null)
            {
                strSql1.Append("OrdFlag,");
                strSql2.Append("" + (model.OrdFlag ? 1 : 0) + ",");
            }
            if (model.WIPType != null)
            {
                strSql1.Append("WIPType,");
                strSql2.Append("" + model.WIPType + ",");
            }
            if (model.SupplyWhCode != null)
            {
                strSql1.Append("SupplyWhCode,");
                strSql2.Append("'" + model.SupplyWhCode + "',");
            }
            if (model.ReasonCode != null)
            {
                strSql1.Append("ReasonCode,");
                strSql2.Append("'" + model.ReasonCode + "',");
            }
            if (model.IsWFControlled != null)
            {
                strSql1.Append("IsWFControlled,");
                strSql2.Append("" + model.IsWFControlled + ",");
            }
            if (model.iVerifyState != null)
            {
                strSql1.Append("iVerifyState,");
                strSql2.Append("" + model.iVerifyState + ",");
            }
            if (model.iReturnCount != null)
            {
                strSql1.Append("iReturnCount,");
                strSql2.Append("" + model.iReturnCount + ",");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.SourceMoCode != null)
            {
                strSql1.Append("SourceMoCode,");
                strSql2.Append("'" + model.SourceMoCode + "',");
            }
            if (model.SourceMoSeq != null)
            {
                strSql1.Append("SourceMoSeq,");
                strSql2.Append("" + model.SourceMoSeq + ",");
            }
            if (model.SourceMoId != null)
            {
                strSql1.Append("SourceMoId,");
                strSql2.Append("" + model.SourceMoId + ",");
            }
            if (model.SourceMoDId != null)
            {
                strSql1.Append("SourceMoDId,");
                strSql2.Append("" + model.SourceMoDId + ",");
            }
            if (model.SourceQCCode != null)
            {
                strSql1.Append("SourceQCCode,");
                strSql2.Append("'" + model.SourceQCCode + "',");
            }
            if (model.SourceQCId != null)
            {
                strSql1.Append("SourceQCId,");
                strSql2.Append("" + model.SourceQCId + ",");
            }
            if (model.SourceQCDId != null)
            {
                strSql1.Append("SourceQCDId,");
                strSql2.Append("" + model.SourceQCDId + ",");
            }
            if (model.CostItemCode != null)
            {
                strSql1.Append("CostItemCode,");
                strSql2.Append("'" + model.CostItemCode + "',");
            }
            if (model.CostItemName != null)
            {
                strSql1.Append("CostItemName,");
                strSql2.Append("'" + model.CostItemName + "',");
            }
            if (model.RelsTime != null)
            {
                strSql1.Append("RelsTime,");
                strSql2.Append("'" + model.RelsTime + "',");
            }
            if (model.CloseUser != null)
            {
                strSql1.Append("CloseUser,");
                strSql2.Append("'" + model.CloseUser + "',");
            }
            if (model.CloseTime != null)
            {
                strSql1.Append("CloseTime,");
                strSql2.Append("'" + model.CloseTime + "',");
            }
            if (model.OrgClsTime != null)
            {
                strSql1.Append("OrgClsTime,");
                strSql2.Append("'" + model.OrgClsTime + "',");
            }
            if (model.AuditStatus != null)
            {
                strSql1.Append("AuditStatus,");
                strSql2.Append("" + model.AuditStatus + ",");
            }
            if (model.PAllocateId != null)
            {
                strSql1.Append("PAllocateId,");
                strSql2.Append("" + model.PAllocateId + ",");
            }
            if (model.DemandCode != null)
            {
                strSql1.Append("DemandCode,");
                strSql2.Append("'" + model.DemandCode + "',");
            }
            if (model.CollectiveFlag != null)
            {
                strSql1.Append("CollectiveFlag,");
                strSql2.Append("" + model.CollectiveFlag + ",");
            }
            if (model.OrderType != null)
            {
                strSql1.Append("OrderType,");
                strSql2.Append("" + model.OrderType + ",");
            }
            if (model.OrderDId != null)
            {
                strSql1.Append("OrderDId,");
                strSql2.Append("" + model.OrderDId + ",");
            }
            if (model.OrderCode != null)
            {
                strSql1.Append("OrderCode,");
                strSql2.Append("'" + model.OrderCode + "',");
            }
            if (model.OrderSeq != null)
            {
                strSql1.Append("OrderSeq,");
                strSql2.Append("" + model.OrderSeq + ",");
            }
            if (model.ManualCode != null)
            {
                strSql1.Append("ManualCode,");
                strSql2.Append("'" + model.ManualCode + "',");
            }
            if (model.ReformFlag != null)
            {
                strSql1.Append("ReformFlag,");
                strSql2.Append("" + (model.ReformFlag ? 1 : 0) + ",");
            }
            if (model.SourceQCVouchType != null)
            {
                strSql1.Append("SourceQCVouchType,");
                strSql2.Append("" + model.SourceQCVouchType + ",");
            }
            if (model.OrgQty != null)
            {
                strSql1.Append("OrgQty,");
                strSql2.Append("" + model.OrgQty + ",");
            }
            if (model.FmFlag != null)
            {
                strSql1.Append("FmFlag,");
                strSql2.Append("" + (model.FmFlag ? 1 : 0) + ",");
            }
            if (model.MinSN != null)
            {
                strSql1.Append("MinSN,");
                strSql2.Append("'" + model.MinSN + "',");
            }
            if (model.MaxSN != null)
            {
                strSql1.Append("MaxSN,");
                strSql2.Append("'" + model.MaxSN + "',");
            }
            if (model.SourceSvcCode != null)
            {
                strSql1.Append("SourceSvcCode,");
                strSql2.Append("'" + model.SourceSvcCode + "',");
            }
            if (model.SourceSvcId != null)
            {
                strSql1.Append("SourceSvcId,");
                strSql2.Append("'" + model.SourceSvcId + "',");
            }
            if (model.SourceSvcDId != null)
            {
                strSql1.Append("SourceSvcDId,");
                strSql2.Append("'" + model.SourceSvcDId + "',");
            }
            if (model.BomType != null)
            {
                strSql1.Append("BomType,");
                strSql2.Append("" + model.BomType + ",");
            }
            if (model.RoutingType != null)
            {
                strSql1.Append("RoutingType,");
                strSql2.Append("" + model.RoutingType + ",");
            }
            if (model.BusFlowId != null)
            {
                strSql1.Append("BusFlowId,");
                strSql2.Append("" + model.BusFlowId + ",");
            }
            if (model.RunCardFlag != null)
            {
                strSql1.Append("RunCardFlag,");
                strSql2.Append("" + (model.RunCardFlag ? 1 : 0) + ",");
            }
            if (model.RequisitionFlag != null)
            {
                strSql1.Append("RequisitionFlag,");
                strSql2.Append("" + (model.RequisitionFlag ? 1 : 0) + ",");
            }
            if (model.AlloVTid != null)
            {
                strSql1.Append("AlloVTid,");
                strSql2.Append("" + model.AlloVTid + ",");
            }
            if (model.RelsAlloVTid != null)
            {
                strSql1.Append("RelsAlloVTid,");
                strSql2.Append("" + model.RelsAlloVTid + ",");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.cbSysBarCode != null)
            {
                strSql1.Append("cbSysBarCode,");
                strSql2.Append("'" + model.cbSysBarCode + "',");
            }
            if (model.cCurrentAuditor != null)
            {
                strSql1.Append("cCurrentAuditor,");
                strSql2.Append("'" + model.cCurrentAuditor + "',");
            }
            if (model.CustCode != null)
            {
                strSql1.Append("CustCode,");
                strSql2.Append("'" + model.CustCode + "',");
            }
            if (model.LPlanCode != null)
            {
                strSql1.Append("LPlanCode,");
                strSql2.Append("'" + model.LPlanCode + "',");
            }
            strSql.Append("insert into @u8.mom_orderdetail(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Addmom_morder(TH.Model.mom_morder model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.MoDId != null)
            {
                strSql1.Append("MoDId,");
                strSql2.Append("" + model.MoDId + ",");
            }
            if (model.StartDate != null)
            {
                strSql1.Append("StartDate,");
                strSql2.Append("'" + model.StartDate + "',");
            }
            if (model.DueDate != null)
            {
                strSql1.Append("DueDate,");
                strSql2.Append("'" + model.DueDate + "',");
            }
            if (model.Ufts != null)
            {
                strSql1.Append("Ufts,");
                strSql2.Append("" + model.Ufts + ",");
            }
            if (model.MoId != null)
            {
                strSql1.Append("MoId,");
                strSql2.Append("" + model.MoId + ",");
            }
            strSql.Append("insert into @u8.mom_morder(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Addmom_moallocate(TH.Model.mom_moallocate model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.AllocateId != null)
            {
                strSql1.Append("AllocateId,");
                strSql2.Append("" + model.AllocateId + ",");
            }
            if (model.MoDId != null)
            {
                strSql1.Append("MoDId,");
                strSql2.Append("" + model.MoDId + ",");
            }
            if (model.SortSeq != null)
            {
                strSql1.Append("SortSeq,");
                strSql2.Append("" + model.SortSeq + ",");
            }
            if (model.OpSeq != null)
            {
                strSql1.Append("OpSeq,");
                strSql2.Append("'" + model.OpSeq + "',");
            }
            if (model.ComponentId != null)
            {
                strSql1.Append("ComponentId,");
                strSql2.Append("" + model.ComponentId + ",");
            }
            if (model.FVFlag != null)
            {
                strSql1.Append("FVFlag,");
                strSql2.Append("" + model.FVFlag + ",");
            }
            if (model.BaseQtyN != null)
            {
                strSql1.Append("BaseQtyN,");
                strSql2.Append("" + model.BaseQtyN + ",");
            }
            if (model.BaseQtyD != null)
            {
                strSql1.Append("BaseQtyD,");
                strSql2.Append("" + model.BaseQtyD + ",");
            }
            if (model.ParentScrap != null)
            {
                strSql1.Append("ParentScrap,");
                strSql2.Append("" + model.ParentScrap + ",");
            }
            if (model.CompScrap != null)
            {
                strSql1.Append("CompScrap,");
                strSql2.Append("" + model.CompScrap + ",");
            }
            if (model.Qty != null)
            {
                strSql1.Append("Qty,");
                strSql2.Append("" + model.Qty + ",");
            }
            if (model.IssQty != null)
            {
                strSql1.Append("IssQty,");
                strSql2.Append("" + model.IssQty + ",");
            }
            if (model.DeclaredQty != null)
            {
                strSql1.Append("DeclaredQty,");
                strSql2.Append("" + model.DeclaredQty + ",");
            }
            if (model.StartDemDate != null)
            {
                strSql1.Append("StartDemDate,");
                strSql2.Append("'" + model.StartDemDate + "',");
            }
            if (model.EndDemDate != null)
            {
                strSql1.Append("EndDemDate,");
                strSql2.Append("'" + model.EndDemDate + "',");
            }
            if (model.WhCode != null)
            {
                strSql1.Append("WhCode,");
                strSql2.Append("'" + model.WhCode + "',");
            }
            if (model.LotNo != null)
            {
                strSql1.Append("LotNo,");
                strSql2.Append("'" + model.LotNo + "',");
            }
            if (model.WIPType != null)
            {
                strSql1.Append("WIPType,");
                strSql2.Append("" + model.WIPType + ",");
            }
            if (model.ByproductFlag != null)
            {
                strSql1.Append("ByproductFlag,");
                strSql2.Append("" + (model.ByproductFlag ? 1 : 0) + ",");
            }
            if (model.QcFlag != null)
            {
                strSql1.Append("QcFlag,");
                strSql2.Append("" + (model.QcFlag ? 1 : 0) + ",");
            }
            if (model.Offset != null)
            {
                strSql1.Append("Offset,");
                strSql2.Append("" + model.Offset + ",");
            }
            if (model.InvCode != null)
            {
                strSql1.Append("InvCode,");
                strSql2.Append("'" + model.InvCode + "',");
            }
            if (model.Free1 != null)
            {
                strSql1.Append("Free1,");
                strSql2.Append("'" + model.Free1 + "',");
            }
            if (model.Free2 != null)
            {
                strSql1.Append("Free2,");
                strSql2.Append("'" + model.Free2 + "',");
            }
            if (model.Free3 != null)
            {
                strSql1.Append("Free3,");
                strSql2.Append("'" + model.Free3 + "',");
            }
            if (model.Free4 != null)
            {
                strSql1.Append("Free4,");
                strSql2.Append("'" + model.Free4 + "',");
            }
            if (model.Free5 != null)
            {
                strSql1.Append("Free5,");
                strSql2.Append("'" + model.Free5 + "',");
            }
            if (model.Free6 != null)
            {
                strSql1.Append("Free6,");
                strSql2.Append("'" + model.Free6 + "',");
            }
            if (model.Free7 != null)
            {
                strSql1.Append("Free7,");
                strSql2.Append("'" + model.Free7 + "',");
            }
            if (model.Free8 != null)
            {
                strSql1.Append("Free8,");
                strSql2.Append("'" + model.Free8 + "',");
            }
            if (model.Free9 != null)
            {
                strSql1.Append("Free9,");
                strSql2.Append("'" + model.Free9 + "',");
            }
            if (model.Free10 != null)
            {
                strSql1.Append("Free10,");
                strSql2.Append("'" + model.Free10 + "',");
            }
            if (model.OpComponentId != null)
            {
                strSql1.Append("OpComponentId,");
                strSql2.Append("" + model.OpComponentId + ",");
            }
            if (model.Define22 != null)
            {
                strSql1.Append("Define22,");
                strSql2.Append("'" + model.Define22 + "',");
            }
            if (model.Define23 != null)
            {
                strSql1.Append("Define23,");
                strSql2.Append("'" + model.Define23 + "',");
            }
            if (model.Define24 != null)
            {
                strSql1.Append("Define24,");
                strSql2.Append("'" + model.Define24 + "',");
            }
            if (model.Define25 != null)
            {
                strSql1.Append("Define25,");
                strSql2.Append("'" + model.Define25 + "',");
            }
            if (model.Define26 != null)
            {
                strSql1.Append("Define26,");
                strSql2.Append("" + model.Define26 + ",");
            }
            if (model.Define27 != null)
            {
                strSql1.Append("Define27,");
                strSql2.Append("" + model.Define27 + ",");
            }
            if (model.Define28 != null)
            {
                strSql1.Append("Define28,");
                strSql2.Append("'" + model.Define28 + "',");
            }
            if (model.Define29 != null)
            {
                strSql1.Append("Define29,");
                strSql2.Append("'" + model.Define29 + "',");
            }
            if (model.Define30 != null)
            {
                strSql1.Append("Define30,");
                strSql2.Append("'" + model.Define30 + "',");
            }
            if (model.Define31 != null)
            {
                strSql1.Append("Define31,");
                strSql2.Append("'" + model.Define31 + "',");
            }
            if (model.Define32 != null)
            {
                strSql1.Append("Define32,");
                strSql2.Append("'" + model.Define32 + "',");
            }
            if (model.Define33 != null)
            {
                strSql1.Append("Define33,");
                strSql2.Append("'" + model.Define33 + "',");
            }
            if (model.Define34 != null)
            {
                strSql1.Append("Define34,");
                strSql2.Append("" + model.Define34 + ",");
            }
            if (model.Define35 != null)
            {
                strSql1.Append("Define35,");
                strSql2.Append("" + model.Define35 + ",");
            }
            if (model.Define36 != null)
            {
                strSql1.Append("Define36,");
                strSql2.Append("'" + model.Define36 + "',");
            }
            if (model.Define37 != null)
            {
                strSql1.Append("Define37,");
                strSql2.Append("'" + model.Define37 + "',");
            }
            //if (model.Ufts != null)
            //{
            //    strSql1.Append("Ufts,");
            //    strSql2.Append("" + model.Ufts + ",");
            //}
            if (model.AuxUnitCode != null)
            {
                strSql1.Append("AuxUnitCode,");
                strSql2.Append("'" + model.AuxUnitCode + "',");
            }
            if (model.ChangeRate != null)
            {
                strSql1.Append("ChangeRate,");
                strSql2.Append("" + model.ChangeRate + ",");
            }
            if (model.AuxBaseQtyN != null)
            {
                strSql1.Append("AuxBaseQtyN,");
                strSql2.Append("" + model.AuxBaseQtyN + ",");
            }
            if (model.AuxQty != null)
            {
                strSql1.Append("AuxQty,");
                strSql2.Append("" + model.AuxQty + ",");
            }
            if (model.ReplenishQty != null)
            {
                strSql1.Append("ReplenishQty,");
                strSql2.Append("" + model.ReplenishQty + ",");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.TransQty != null)
            {
                strSql1.Append("TransQty,");
                strSql2.Append("" + model.TransQty + ",");
            }
            if (model.ProductType != null)
            {
                strSql1.Append("ProductType,");
                strSql2.Append("" + model.ProductType + ",");
            }
            if (model.SoType != null)
            {
                strSql1.Append("SoType,");
                strSql2.Append("" + model.SoType + ",");
            }
            if (model.SoDId != null)
            {
                strSql1.Append("SoDId,");
                strSql2.Append("'" + model.SoDId + "',");
            }
            if (model.SoCode != null)
            {
                strSql1.Append("SoCode,");
                strSql2.Append("'" + model.SoCode + "',");
            }
            if (model.SoSeq != null)
            {
                strSql1.Append("SoSeq,");
                strSql2.Append("" + model.SoSeq + ",");
            }
            if (model.DemandCode != null)
            {
                strSql1.Append("DemandCode,");
                strSql2.Append("'" + model.DemandCode + "',");
            }
            if (model.QmFlag != null)
            {
                strSql1.Append("QmFlag,");
                strSql2.Append("" + (model.QmFlag ? 1 : 0) + ",");
            }
            if (model.OrgQty != null)
            {
                strSql1.Append("OrgQty,");
                strSql2.Append("" + model.OrgQty + ",");
            }
            if (model.OrgAuxQty != null)
            {
                strSql1.Append("OrgAuxQty,");
                strSql2.Append("" + model.OrgAuxQty + ",");
            }
            if (model.CostItemCode != null)
            {
                strSql1.Append("CostItemCode,");
                strSql2.Append("'" + model.CostItemCode + "',");
            }
            if (model.CostItemName != null)
            {
                strSql1.Append("CostItemName,");
                strSql2.Append("'" + model.CostItemName + "',");
            }
            if (model.RequisitionFlag != null)
            {
                strSql1.Append("RequisitionFlag,");
                strSql2.Append("" + (model.RequisitionFlag ? 1 : 0) + ",");
            }
            if (model.RequisitionQty != null)
            {
                strSql1.Append("RequisitionQty,");
                strSql2.Append("" + model.RequisitionQty + ",");
            }
            if (model.RequisitionIssQty != null)
            {
                strSql1.Append("RequisitionIssQty,");
                strSql2.Append("" + model.RequisitionIssQty + ",");
            }
            if (model.CostWIPRel != null)
            {
                strSql1.Append("CostWIPRel,");
                strSql2.Append("" + (model.CostWIPRel ? 1 : 0) + ",");
            }
            if (model.MoallocateSubId != null)
            {
                strSql1.Append("MoallocateSubId,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.cSubSysBarCode != null)
            {
                strSql1.Append("cSubSysBarCode,");
                strSql2.Append("'" + model.cSubSysBarCode + "',");
            }
            if (model.PickingQty != null)
            {
                strSql1.Append("PickingQty,");
                strSql2.Append("" + model.PickingQty + ",");
            }
            if (model.PickingAuxQty != null)
            {
                strSql1.Append("PickingAuxQty,");
                strSql2.Append("" + model.PickingAuxQty + ",");
            }
            strSql.Append("insert into @u8.mom_moallocate(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }
        #endregion
    }
}

