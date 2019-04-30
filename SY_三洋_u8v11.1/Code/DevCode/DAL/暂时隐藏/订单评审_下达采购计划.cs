using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
     

    /// <summary>
    /// 数据访问类:订单评审_下达采购计划
    /// </summary>
    public partial class 订单评审_下达采购计划
    {

//        readonly string sBom = @"
//
//select a.bomid,f.PartId,a.BomType,h.partid as PartIDs,c.OpComponentId 
//	,g.cInvCode as 母件编码,g.cInvName as 母件名称,g.cInvAddCode as 母件代号,g.cInvStd as 母件规格
//    ,j.cComUnitName as 母件计量单位,b.ParentScrap as 母件损耗率,a.Version as 版本代号
//	,a.VersionDesc as 版本说明,a.VersionEffDate as 版本日期,case a.Status when 1 then '新建' when 3 then '审核' when 4 then '停用' end as 状态
//	,case when ISNULL(g.bSelf,0) = 1 then '自制' when ISNULL(g.bProxyForeign,0) = 1 then '委外' end as 母件属性
//	,a.ApplyDId as 变更单号,'' as 行号,c.SortSeq as 子件行号,c.OpSeq as 工序行号
//	,i.cInvCode as 子件编码,i.cInvName as 子件名称,i.cInvAddCode as 子件代号,i.cInvStd as 子件规格,k.cComUnitName as 子件计量单位
//	,c.BaseQtyN as 基本用量,c.BaseQtyD as 基础用量,c.CompScrap as 子件损耗率,case isnull(FVFlag,0) when 0 then '是' when 1 then '否' end as 固定用量,c.ChangeRate as 换算率
//	,case d.WIPType when 1 then '入库倒冲' when 2 then '工序领用' when 3 then '领用' when 4 then '虚拟件' end as 供应类型, d.WIPType
//	,c.BaseQtyN/c.BaseQtyD/(1-isnull(b.ParentScrap,0))*(1+isnull(c.CompScrap,0)) as 单阶使用数量,cast(null as decimal(16,6)) as 加成数量
//	,c.EffBegDate as 子件生效日,c.EffEndDate as 子件失效日,d.Offset as 偏置期,d.PlanFactor as 计划比例,case isnull(c.ByproductFlag,0) when 0 then '否' else '是' end as 产出品
//	,case isnull(c.ProductType,0) when 2 then '联产品' when 3 then '副产品' end as 产出类型,case ISNULL(d.AccuCostFlag,0) when 0 then  '否' else '是' end as 成本相关
//	,case isnull(d.OptionalFlag,0) when 0 then '否' else '是' end as 可选否,'任意' as 选择规则,c.Remark as 备注
//	,case when ISNULL(i.bSelf,0) = 1 then '自制' when ISNULL(i.bProxyForeign,0) = 1 then '委外' when ISNULL(i.bPurchase,0) = 1 then '采购' end as 子件属性
//    ,cast(null as varchar(300)) as 母子关联
//    ,cast(null as decimal(16,6)) as 需求数量,cast(null as decimal(16,6)) as 评审数量,cast(null as datetime) as 交货日期,cast(null as datetime) as 开始日期,cast(null as datetime) as 结束日期
//    ,cast(l.cidefine1 as int) as 评审采购周期,cast(l.cidefine2 as int) as 评审委外周期,cast( l.cidefine3 / isnull(l.cidefine6,1) as decimal(16,10)) as 单件默认生产工时,l.cidefine4 默认产线,cast(l.cidefine5 as int) as 质检周期
//    ,cast( l.cidefine3 / isnull(l.cidefine6,1) as decimal(16,10)) * 555555 as 生产合计工时
//    ,cast(l.cidefine7 as  decimal(16,2)) as 生产准备时间,cast(l.cidefine8 as  decimal(16,2)) as 经济批量
//    ,case when ISNULL(i.bSelf,0) = 1 then cast (null as int) when ISNULL(i.bProxyForeign,0) = 1 then cast(l.cidefine2 as int) when ISNULL(i.bPurchase,0) = 1 then cast(l.cidefine1 as int) end as 置办周期
//    ,isnull(l.cidefine9,1) as 默认产线并发生产数
//    ,cast(null as  decimal(16,6)) as 仓库存量,cast(null as  decimal(16,6)) as 待入库数量,cast(l.cidefine8 as  decimal(16,6)) as 待出库数量,cast(null as decimal(16,6)) as 本单需求数量
//    ,cast (null as uniqueidentifier) as GUID,cast (null as uniqueidentifier) as GUIDHead
//    ,d.Whcode as 仓库编码,cast (null as varchar(50)) as 仓库名称,d.DrawDeptCode as 领料部门编码,m.cInvDepCode as 生产部门编码
//    ,cast (null as varchar(50)) as 评审单据号,null as iID
//from @u8.bom_bom a 
//    inner join @u8.bom_parent b on a.bomid = b.BomId 
//    inner join @u8.bas_part f on f.PartId = b.ParentId
//    inner join @u8.Inventory g on g.cinvcode = f.invcode
//	inner join @u8.bom_opcomponent c on a.bomid = c.bomid
//    inner join @u8.bas_part h on h.partid = c.ComponentId 
//    inner join @u8.Inventory i on i.cinvcode = h.invcode
//	left join @u8.bom_opcomponentopt d on d.OptionsId = c.OpComponentId
//	left join @u8.bom_opcomponentloc e on e.OpComponentId = d.OptionsId
//    left join @u8.ComputationUnit j on j.cComunitCode = g.cComUnitCode
//	left join @u8.ComputationUnit k on k.cComunitCode = i.cComUnitCode
//    left join @u8.Inventory_extradefine l on l.cInvCode = i.cInvCode 
//    left join @u8.Inventory m on m.cInvCode = f.InvCode 
//where 1=-1 and a.Status = 3
//order by c.SortSeq,g.cInvCode,i.cInvCode
//";


        public int Save(string s采购请购单号, DataTable dtDetails)
        {

            //DateTime dTimeNow = DbHelperSQL.ExecuteGetServerTime();
            //DateTime dTimeDay = BaseFunction.BaseFunction.ReturnDate(dTimeNow.ToString("yyyy-MM-dd"));
            //string sAccid = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);

            //if(s生产订单号 == "")
            //    throw new Exception("生产订单号不能为空");

            //if(dtDetails == null || dtDetails.Rows.Count ==0)
            //{
            //    throw new Exception("没有需要下达生产的数据"); 
            //}

            //int iCou = 0;

            //SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            //conn.Open();
            ////启用事务
            //SqlTransaction tran = conn.BeginTransaction();

            //try
            //{
            //    string sPSCode = dtDetails.Rows[0]["评审单据号"].ToString().Trim();

            //    string sSQL = "select * from 订单评审 where 评审单据号 = '" + sPSCode + "'";
            //    DataTable dtPS = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            //    if (dtPS == null || dtPS.Rows.Count == 0)
            //    {
            //        throw new Exception("评审单 " + sPSCode + " 不存在，或已经删除");
            //    }
            //    if (dtPS.Rows[0]["审核人"].ToString().Trim() == "")
            //    {
            //        throw new Exception("评审单 " + sPSCode + " 未审核");
            //    }
            //    if (dtPS.Rows[0]["关闭人"].ToString().Trim() != "")
            //    {
            //        throw new Exception("评审单 " + sPSCode + " 已关闭");
            //    }
            //    if (dtPS.Rows[0]["下达生产人"].ToString().Trim() != "")
            //    {
            //        throw new Exception("评审单 " + sPSCode + " 已下达生产计划");
            //    }


            //    sSQL = "select * from @u8.mom_order where MoCode = '" + s生产订单号 + "'";
            //    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            //    if (dtTemp != null && dtTemp.Rows.Count > 0)
            //    {
            //        throw new Exception("生产订单号 " + s生产订单号 + " 已经存在");
            //    }

            //    #region 生产订单号手工输入，不处理
            //    //    //获得最大单据号
            //    //    long iVouMOM;
            //    //    sSQL = "select isnull(max(cast (cNumber as int)),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where CardNumber='MO21' and (cSeed = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            //    //    DataTable dtMOM = clsSQLCommond.ExecQuery(sSQL);
            //    //    iVouMOM = Convert.ToInt64(dtMOM.Rows[0]["Maxnumber"]);

            //    //    bool bVouMOM = false;            //当月第一张单据
            //    //    if (iVouMOM == 0)
            //    //    {
            //    //        bVouMOM = true;
            //    //    }
            //    #endregion


            //    ////获得单据ID号
            //    long iIDmom_order;
            //    long iIDmom_orderdetail;
            //    long iIDmom_moallocate;
            //    sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_order'";
            //    DataTable dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            //    if (dtID == null || dtID.Rows.Count < 1)
            //    {
            //        iIDmom_order = 0;
            //    }
            //    else
            //    {
            //        iIDmom_order = Convert.ToInt64(dtID.Rows[0]["iChildID"]);
            //    }
            //    sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_orderdetail'";
            //    dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            //    if (dtID == null || dtID.Rows.Count < 1)
            //    {
            //        iIDmom_orderdetail = 0;
            //    }
            //    else
            //    {
            //        iIDmom_orderdetail = Convert.ToInt64(dtID.Rows[0]["iChildID"]);
            //    }
            //    sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_moallocate'";
            //    dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            //    if (dtID == null || dtID.Rows.Count < 1)
            //    {
            //        iIDmom_moallocate = 0;
            //    }
            //    else
            //    {
            //        iIDmom_moallocate = Convert.ToInt64(dtID.Rows[0]["iChildID"]);
            //    }


            //    iIDmom_order += 1;

            //    TH.Model.mom_order Modelmom_order = new TH.Model.mom_order();
            //    Modelmom_order.MoId = ReturnID(iIDmom_order);
            //    Modelmom_order.MoCode = s生产订单号;
            //    Modelmom_order.CreateDate = dTimeDay;
            //    Modelmom_order.CreateUser = FrameBaseFunction.ClsBaseDataInfo.sUid;
            //    Modelmom_order.UpdCount = 0;
            //    Modelmom_order.VTid = 30413;
            //    Modelmom_order.CreateTime = dTimeNow;
            //    Modelmom_order.iPrintCount = 0;
            //    Modelmom_order.RelsVTid = 0;

            //    sSQL = Addmom_order(Modelmom_order);
            //    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            //    int iRow行 = 0;

            //    for (int i = 0; i < dtDetails.Rows.Count; i++)
            //    {
            //        if (BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["本单需求数量"]) <= 0)
            //            continue;

            //        string s物料编码 = dtDetails.Rows[i]["子件编码"].ToString().Trim();
            //        string sBomTemp = sBom;
            //        sBomTemp = sBomTemp.Replace("1=-1", " f.InvCode = '" + s物料编码 + "'");
            //        DataTable dtBom = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sBomTemp).Tables[0];

            //        if (dtBom == null || dtBom.Rows.Count == 0)
            //        {
            //            throw new Exception("获得物料 " + s物料编码 + " BOM失败");
            //        }

            //        iIDmom_orderdetail += 1;


            //        TH.Model.mom_orderdetail Modelmom_ordertail = new TH.Model.mom_orderdetail();
            //        Modelmom_ordertail.MoDId = ReturnID(iIDmom_orderdetail);
            //        Modelmom_ordertail.MoId = ReturnID(iIDmom_order);

            //        iRow行 += 1;
            //        Modelmom_ordertail.SortSeq = iRow行;
            //        Modelmom_ordertail.MoClass = 1;
            //        //Modelmom_ordertail.MoTypeId = 
            //        Modelmom_ordertail.Qty = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["本单需求数量"]);
            //        Modelmom_ordertail.MrpQty = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["本单需求数量"]);
            //        //Modelmom_ordertail.AuxUnitCode
            //        //Modelmom_ordertail.AuxQty = 0;
            //        //Modelmom_ordertail.ChangeRate = 0;
            //        //Modelmom_ordertail.MoLotCode 
            //        Modelmom_ordertail.WhCode = dtDetails.Rows[i]["仓库编码"].ToString().Trim();
            //        Modelmom_ordertail.MDeptCode = dtDetails.Rows[i]["生产部门编码"].ToString().Trim();
            //        Modelmom_ordertail.SoType = 0;
            //        //Modelmom_ordertail.SoDId = 
            //        //Modelmom_ordertail.SoCode = 
            //        //Modelmom_ordertail.SoSeq = 
            //        Modelmom_ordertail.DeclaredQty = 0;
            //        Modelmom_ordertail.QualifiedInQty = 0;
            //        Modelmom_ordertail.Status = 1;
            //        Modelmom_ordertail.OrgStatus = 1;
            //        Modelmom_ordertail.BomId = BaseFunction.BaseFunction.ReturnLong(dtBom.Rows[0]["bomid"]);
            //        Modelmom_ordertail.RoutingId = 0;
            //        Modelmom_ordertail.CustBomId = 0;
            //        Modelmom_ordertail.DemandId = 0;
            //        //Modelmom_ordertail.PlanCode
            //        Modelmom_ordertail.PartId = BaseFunction.BaseFunction.ReturnLong(dtBom.Rows[0]["PartId"]);
            //        Modelmom_ordertail.InvCode = dtDetails.Rows[i]["子件编码"].ToString().Trim();
            //        Modelmom_ordertail.SfcFlag = false;
            //        Modelmom_ordertail.CrpFlag = false;
            //        Modelmom_ordertail.QcFlag = false;
            //        Modelmom_ordertail.LeadTime = 0;
            //        Modelmom_ordertail.OpScheduleType = 1;
            //        Modelmom_ordertail.OrdFlag = false;
            //        //默认使用5
            //        Modelmom_ordertail.WIPType = 5;
            //        Modelmom_ordertail.IsWFControlled = 0;
            //        Modelmom_ordertail.iVerifyState = 0;
            //        Modelmom_ordertail.iReturnCount = 0;
            //        Modelmom_ordertail.SourceMoId = 0;
            //        Modelmom_ordertail.SourceMoDId = 0;
            //        Modelmom_ordertail.SourceQCId = 0;
            //        Modelmom_ordertail.SourceQCDId = 0;
            //        Modelmom_ordertail.AuditStatus = 1;
            //        Modelmom_ordertail.PAllocateId = 0;
            //        Modelmom_ordertail.CollectiveFlag = 0;
            //        Modelmom_ordertail.OrderType = 0;
            //        Modelmom_ordertail.OrderDId = 0;
            //        Modelmom_ordertail.ReformFlag = false;
            //        Modelmom_ordertail.SourceQCVouchType = 0;
            //        Modelmom_ordertail.OrgQty = 0;
            //        Modelmom_ordertail.FmFlag = false;
            //        Modelmom_ordertail.BomType = BaseFunction.BaseFunction.ReturnInt(dtBom.Rows[0]["BomType"]);
            //        Modelmom_ordertail.RoutingType = 0;
            //        Modelmom_ordertail.RunCardFlag = false;
            //        Modelmom_ordertail.RequisitionFlag = false;
            //        Modelmom_ordertail.AlloVTid = 0;
            //        Modelmom_ordertail.RelsAlloVTid = 0;
            //        Modelmom_ordertail.iPrintCount = 0;
            //        Modelmom_ordertail.Define33 = dtDetails.Rows[i]["GUID"].ToString().Trim();

            //        sSQL = Addmom_orderdetail(Modelmom_ordertail);
            //        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


            //        TH.Model.mom_morder Modelmom_morder = new TH.Model.mom_morder();
            //        Modelmom_morder.DueDate = BaseFunction.BaseFunction.ReturnDate(dtDetails.Rows[i]["结束日期"]);
            //        Modelmom_morder.MoDId = ReturnID(iIDmom_orderdetail);
            //        Modelmom_morder.MoId = ReturnID(iIDmom_order);
            //        Modelmom_morder.StartDate = BaseFunction.BaseFunction.ReturnDate(dtDetails.Rows[i]["开始日期"]);

            //        sSQL = Addmom_morder(Modelmom_morder);
            //        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            //        for (int j = 0; j < dtBom.Rows.Count; j++)
            //        {
            //            iIDmom_moallocate += 1;
            //            TH.Model.mom_moallocate Modelmom_moallocate = new TH.Model.mom_moallocate();
            //            Modelmom_moallocate.AllocateId = ReturnID(iIDmom_moallocate);
            //            Modelmom_moallocate.MoDId = ReturnID(iIDmom_orderdetail);
            //            Modelmom_moallocate.SortSeq = j + 1;
            //            Modelmom_moallocate.OpSeq = "0000";
            //            Modelmom_moallocate.ComponentId = BaseFunction.BaseFunction.ReturnLong(dtBom.Rows[j]["PartIDs"]);
            //            Modelmom_moallocate.FVFlag = 1;
            //            Modelmom_moallocate.BaseQtyN = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["基本用量"]);
            //            Modelmom_moallocate.BaseQtyD = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["基础用量"]);
            //            Modelmom_moallocate.ParentScrap = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["母件损耗率"]);
            //            Modelmom_moallocate.CompScrap = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["母件损耗率"]);

            //            decimal d母件数量 = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["本单需求数量"]);
            //            decimal d使用数量 = BaseFunction.BaseFunction.ReturnDecimal(dtBom.Rows[j]["单阶使用数量"]);
            //            Modelmom_moallocate.Qty = BaseFunction.BaseFunction.ReturnDecimal(d母件数量 * d使用数量);
            //            Modelmom_moallocate.IssQty = 0;
            //            Modelmom_moallocate.DeclaredQty = 0;
            //            Modelmom_moallocate.StartDemDate = BaseFunction.BaseFunction.ReturnDate(dtDetails.Rows[i]["开始日期"]);
            //            Modelmom_moallocate.EndDemDate = BaseFunction.BaseFunction.ReturnDate(dtDetails.Rows[i]["结束日期"]);
            //            Modelmom_moallocate.WhCode = dtBom.Rows[j]["仓库编码"].ToString().Trim();
            //            //Modelmom_moallocate.LotNo 
            //            Modelmom_moallocate.WIPType = BaseFunction.BaseFunction.ReturnInt(dtBom.Rows[j]["WIPType"]);
            //            Modelmom_moallocate.ByproductFlag = false;
            //            Modelmom_moallocate.QcFlag = false;
            //            Modelmom_moallocate.Offset = 0;
            //            Modelmom_moallocate.InvCode = dtBom.Rows[j]["子件编码"].ToString().Trim();
            //            Modelmom_moallocate.OpComponentId = BaseFunction.BaseFunction.ReturnLong(dtBom.Rows[j]["OpComponentId"]);
            //            //Modelmom_moallocate.AuxUnitCode 
            //            //Modelmom_moallocate.ChangeRate
            //            //Modelmom_moallocate.AuxBaseQtyN
            //            //Modelmom_moallocate.AuxQty 
            //            Modelmom_moallocate.ReplenishQty = 0;
            //            Modelmom_moallocate.TransQty = 0;
            //            Modelmom_moallocate.ProductType = 1;
            //            Modelmom_moallocate.SoType = 0;
            //            //Modelmom_moallocate.SoDId = 
            //            //Modelmom_moallocate.SoCode 
            //            //Modelmom_moallocate.SoSeq
            //            //Modelmom_moallocate.DemandCode
            //            Modelmom_moallocate.QmFlag = false;
            //            Modelmom_moallocate.OrgQty = 0;
            //            Modelmom_moallocate.OrgAuxQty = 0;
            //            Modelmom_moallocate.RequisitionFlag = false;
            //            Modelmom_moallocate.RequisitionQty = 0;
            //            Modelmom_moallocate.RequisitionIssQty = 0;
            //            Modelmom_moallocate.CostWIPRel = false;
            //            Modelmom_moallocate.PickingQty = 0;
            //            Modelmom_moallocate.PickingAuxQty = 0;

            //            sSQL = Addmom_moallocate(Modelmom_moallocate);
            //            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            //        }
            //    }

            //    //更新最大ID
            //    sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_order + ",iChildID=" + iIDmom_order + " where  cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_order'";
            //    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            //    sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_orderdetail + ",iChildID=" + iIDmom_orderdetail + " where  cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_orderdetail'";
            //    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            //    sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_moallocate + ",iChildID=" + iIDmom_moallocate + " where  cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_moallocate'";
            //    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            //    sSQL = "update dbo.订单评审 set 下达生产人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',下达生产日期 = getdate() where 评审单据号 = '" + sPSCode + "'";
            //    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            //    tran.Commit();
            //}
            //catch (Exception error)
            //{
            //    tran.Rollback();
            //    iCou = 0;
            //    throw new Exception(error.Message);
            //}

            //return iCou;
            return 0;
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
        /// 增加一条数据
        /// </summary>
        public string Addmom_order(TH.Model.mom_order model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

            strSql1.Append("MoId,");
            strSql2.Append("" + model.MoId + ",");
            
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
            strSql.Append("insert into  @u8.mom_moallocate(");
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

            if (model.MoId != null)
            {
                strSql1.Append("MoId,");
                strSql2.Append("" + model.MoId + ",");
            }
            strSql.Append("insert into  @u8.mom_morder(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

        #region MyRegion
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
                strSql1.Append("[Status],");
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
            strSql.Append("insert into  @u8.mom_orderdetail(");
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

