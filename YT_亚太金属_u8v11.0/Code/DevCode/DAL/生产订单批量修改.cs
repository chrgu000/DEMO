using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections.Generic;
namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:生产订单批量修改
    /// </summary>
    public partial class 生产订单批量修改
    {
        public 生产订单批量修改()
        { }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public DataTable GetWorkOrder(string sWhere)
        {
            string sSQL = @"
select cast(0 as bit) as 选择,a.MoId,b.MoDid,a.MoCode,b.SortSeq,b.InvCode,c.cInvName,c.cInvStd,b.Qty
from @u8.mom_order a inner join @u8.mom_orderdetail b on a.moid = b.moid 
    inner join @u8.Inventory c on b.InvCode = c.cInvCode
where isnull(b.Status ,0) <> 4
	and 1=1
order by a.MoCode,b.SortSeq
";
            sSQL = sSQL.Replace("1=1", "1=1" + sWhere);
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            return dt;
        }

        public int Save(long lMoDid, DataTable dt)
        {
            int iCou = 0;

            string sErr = "";
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                string sAccid = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);

                #region 批量修改订单子件

                long iIDmom_moallocate = 0;
                string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_moallocate'";
                DataTable dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtID == null || dtID.Rows.Count < 1)
                {
                    iIDmom_moallocate = 0;
                }
                else
                {
                    iIDmom_moallocate = Convert.ToInt64(dtID.Rows[0]["iChildID"]);
                }

                 sSQL = @"
select * from @u8.mom_moallocate
where MoDId = 111111
";
                sSQL = sSQL.Replace("111111", lMoDid.ToString());
                DataTable dtMom_moallocate = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtMom_moallocate == null || dtMom_moallocate.Rows.Count == 0)
                    throw new Exception("获得源订单子件信息失败");



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool b = BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["选择"]);
                    if (!b)
                        continue;

                    long l_MoDid = BaseFunction.BaseFunction.ReturnLong(dt.Rows[i]["MoDid"]);
                    string sInvCode = dt.Rows[i]["InvCode"].ToString().Trim();

                    sSQL = @"
select * from @u8.mom_moallocate
where MoDId = 222222 and (isnull(IssQty ,0) + isnull(TransQty ,0)) > 0
    and InvCode not in 
    (
    select InvCode from @u8.mom_moallocate
    where MoDId = 111111 
    )
";
                    sSQL = sSQL.Replace("111111", lMoDid.ToString());
                    sSQL = sSQL.Replace("222222", l_MoDid.ToString());
                    DataTable dt_moallocate = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt_moallocate != null && dt_moallocate.Rows.Count > 0)
                    {
                        sErr = sErr + "生产订单 " + dt.Rows[i]["MoCode"].ToString().Trim() + "[" + dt.Rows[i]["SortSeq"].ToString().Trim() + "]已经领料不能删除子件\n";
                        continue;
                    }

                    //1. 删除未领料的多余的订单子件
                    sSQL = @"
delete @u8.mom_moallocate
where AllocateId  in
(
   select AllocateId from @u8.mom_moallocate
    where MoDId = 222222 and (isnull(IssQty ,0) + isnull(TransQty ,0)) = 0
    and InvCode not in 
    (
        select InvCode from @u8.mom_moallocate
        where MoDId = 111111 
    ) 
)
";
                    sSQL = sSQL.Replace("111111", lMoDid.ToString());
                    sSQL = sSQL.Replace("222222", l_MoDid.ToString());
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //2. 已经存在物料,Update; 不存在的物料Insert
                    for (int j = 0; j < dtMom_moallocate.Rows.Count; j++)
                    {
                        string s_cInvCode = dtMom_moallocate.Rows[j]["InvCode"].ToString().Trim();
                        string s_Sodid = dtMom_moallocate.Rows[j]["SoDId"].ToString().Trim();

                        sSQL = @"
select *
from  @u8.mom_moallocate
where  MoDId = 111111 and InvCode = '222222'
";
                        sSQL = sSQL.Replace("111111", l_MoDid.ToString());
                        sSQL = sSQL.Replace("222222", s_cInvCode);

                        DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        //不存在该子件,新增
                        if (dtTemp == null || dtTemp.Rows.Count == 0)
                        {
                            TH.Model.mom_moallocate Modelmoallocate = new TH.Model.mom_moallocate();
                            Modelmoallocate = DataRowToModel(dtMom_moallocate.Rows[j]);

                            iIDmom_moallocate += 1;
                            Modelmoallocate.AllocateId = ReturnID(iIDmom_moallocate);
                            Modelmoallocate.MoDId = l_MoDid;
                            Modelmoallocate.SoDId = s_Sodid;

                            sSQL = Add(Modelmoallocate);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        //存在该子件,更新,需要注意已领料,调拨数量的控制
                        else
                        {
                            TH.Model.mom_moallocate Modelmoallocate = new TH.Model.mom_moallocate();
                            Modelmoallocate = DataRowToModel(dtMom_moallocate.Rows[j]);
                            Modelmoallocate.MoDId = l_MoDid;
                            Modelmoallocate.SoDId = s_Sodid;
                            Modelmoallocate.AllocateId = BaseFunction.BaseFunction.ReturnLong(dtTemp.Rows[0]["AllocateId"]);

                            decimal d_数量 = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[0]["Qty"]);
                            decimal d_已领料 = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[0]["Qty"]);
                            decimal d_已调拨 = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[0]["IssQty"]);

                            decimal d数量 = BaseFunction.BaseFunction.ReturnDecimal(Modelmoallocate.Qty);
                            if (d数量 < (d_已领料 + d_已调拨))
                            {
                                sErr = sErr + "生产订单 " + dt.Rows[i]["MoCode"].ToString().Trim() + "[" + dt.Rows[i]["SortSeq"].ToString().Trim() + "]子件" + Modelmoallocate.InvCode + "领料或调拨数量超过修改后数量\n";
                                continue;
                            }

                            sSQL = Update(Modelmoallocate);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                }

                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_moallocate + ",iChildID=" + iIDmom_moallocate + " where  cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_moallocate'";

                #endregion


                #region 批量修改订单生产订单工艺路线明细

                /*

                long iMoRoutingDId = 0;
                sSQL = "select max(MoRoutingDId) as MoRoutingDId from @u8.sfc_moroutingdetail  where cVouchType = 'sfc_moroutingdetail'";
                dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtID == null || dtID.Rows.Count < 1)
                {
                    iMoRoutingDId = 0;
                }
                else
                {
                    iMoRoutingDId = Convert.ToInt64(dtID.Rows[0]["MoRoutingDId"]);
                }

                sSQL = @"
select * from @u8.sfc_moroutingdetail
where MoDId = 111111
";
                sSQL = sSQL.Replace("111111", lMoDid.ToString());
                DataTable dtsfc_moroutingdetail = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtsfc_moroutingdetail != null && dtsfc_moroutingdetail.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        long l_MoDid = BaseFunction.BaseFunction.ReturnLong(dt.Rows[i]["MoDid"]);
                        string sInvCode = dt.Rows[i]["InvCode"].ToString().Trim();

                        sSQL = @"
select * from @u8.mom_moallocate
where MoDId = 222222 and (isnull(IssQty ,0) + isnull(TransQty ,0)) > 0
    and InvCode not in 
    (
    select InvCode from @u8.mom_moallocate
    where MoDId = 111111 
    )
";
                        sSQL = sSQL.Replace("111111", lMoDid.ToString());
                        sSQL = sSQL.Replace("222222", l_MoDid.ToString());
                        DataTable dt_moallocate = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt_moallocate != null && dt_moallocate.Rows.Count > 0)
                        {
                            sErr = sErr + "生产订单 " + dt.Rows[i]["MoCode"].ToString().Trim() + "[" + dt.Rows[i]["SortSeq"].ToString().Trim() + "]已经领料不能删除子件\n";
                            continue;
                        }

                        //1. 删除未领料的多余的订单子件
                        sSQL = @"
delete @u8.mom_moallocate
where AllocateId  in
(
   select AllocateId from @u8.mom_moallocate
    where MoDId = 222222 and (isnull(IssQty ,0) + isnull(TransQty ,0)) > 0
    and InvCode not in 
    (
        select InvCode from @u8.mom_moallocate
        where MoDId = 111111 
    ) 
)
";
                        sSQL = sSQL.Replace("111111", lMoDid.ToString());
                        sSQL = sSQL.Replace("222222", l_MoDid.ToString());
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //2. 已经存在物料,Update; 不存在的物料Insert
                        for (int j = 0; j < dtMom_moallocate.Rows.Count; j++)
                        {
                            string s_cInvCode = dtMom_moallocate.Rows[j]["InvCode"].ToString().Trim();
                            string s_Sodid = dtMom_moallocate.Rows[j]["SoDId"].ToString().Trim();

                            sSQL = @"
select *
from  @u8.mom_moallocate
where  MoDId = 111111 and InvCode = '222222'
";
                            sSQL = sSQL.Replace("111111", l_MoDid.ToString());
                            sSQL = sSQL.Replace("222222", s_cInvCode);

                            DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            //不存在该子件,新增
                            if (dtTemp == null || dtTemp.Rows.Count == 0)
                            {
                                TH.Model.mom_moallocate Modelmoallocate = new TH.Model.mom_moallocate();
                                Modelmoallocate = DataRowToModel(dtMom_moallocate.Rows[j]);

                                iIDmom_moallocate += 1;
                                Modelmoallocate.AllocateId = ReturnID(iIDmom_moallocate);
                                Modelmoallocate.MoDId = l_MoDid;
                                Modelmoallocate.SoDId = s_Sodid;

                                sSQL = Add(Modelmoallocate);
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            //存在该子件,更新,需要注意已领料,调拨数量的控制
                            else
                            {
                                TH.Model.mom_moallocate Modelmoallocate = new TH.Model.mom_moallocate();
                                Modelmoallocate = DataRowToModel(dtMom_moallocate.Rows[j]);
                                Modelmoallocate.MoDId = l_MoDid;
                                Modelmoallocate.SoDId = s_Sodid;

                                decimal d_数量 = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[0]["Qty"]);
                                decimal d_已领料 = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[0]["Qty"]);
                                decimal d_已调拨 = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[0]["IssQty"]);

                                decimal d数量 = BaseFunction.BaseFunction.ReturnDecimal(Modelmoallocate.Qty);
                                if (d数量 < (d_已领料 + d_已调拨))
                                {
                                    sErr = sErr + "生产订单 " + dt.Rows[i]["MoCode"].ToString().Trim() + "[" + dt.Rows[i]["SortSeq"].ToString().Trim() + "]子件" + Modelmoallocate.InvCode + "领料或调拨数量超过修改后数量\n";
                                    continue;
                                }

                                sSQL = Update(Modelmoallocate);
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                    }
                }

                //sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_moallocate + ",iChildID=" + iIDmom_moallocate + " where  cAcc_Id = '" + sAccid + "' and cVouchType = 'mom_moallocate'";

                 */ 
                #endregion


                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                if (sErr != "")
                {
                    throw new Exception(sErr);
                }

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        #region 代码生成器

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.mom_moallocate model)
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
            strSql.Append("insert into @u8.mom_moallocate(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.mom_moallocate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update @u8.mom_moallocate set ");
            if (model.SortSeq != null)
            {
                strSql.Append("SortSeq=" + model.SortSeq + ",");
            }
            if (model.OpSeq != null)
            {
                strSql.Append("OpSeq='" + model.OpSeq + "',");
            }
            else
            {
                strSql.Append("OpSeq= null ,");
            }
            if (model.ComponentId != null)
            {
                strSql.Append("ComponentId=" + model.ComponentId + ",");
            }
            else
            {
                strSql.Append("ComponentId= null ,");
            }
            if (model.FVFlag != null)
            {
                strSql.Append("FVFlag=" + model.FVFlag + ",");
            }
            else
            {
                strSql.Append("FVFlag= null ,");
            }
            if (model.BaseQtyN != null)
            {
                strSql.Append("BaseQtyN=" + model.BaseQtyN + ",");
            }
            else
            {
                strSql.Append("BaseQtyN= null ,");
            }
            if (model.BaseQtyD != null)
            {
                strSql.Append("BaseQtyD=" + model.BaseQtyD + ",");
            }
            else
            {
                strSql.Append("BaseQtyD= null ,");
            }
            if (model.ParentScrap != null)
            {
                strSql.Append("ParentScrap=" + model.ParentScrap + ",");
            }
            else
            {
                strSql.Append("ParentScrap= null ,");
            }
            if (model.CompScrap != null)
            {
                strSql.Append("CompScrap=" + model.CompScrap + ",");
            }
            else
            {
                strSql.Append("CompScrap= null ,");
            }
            if (model.Qty != null)
            {
                strSql.Append("Qty=" + model.Qty + ",");
            }
            else
            {
                strSql.Append("Qty= null ,");
            }
            if (model.IssQty != null)
            {
                strSql.Append("IssQty=" + model.IssQty + ",");
            }
            else
            {
                strSql.Append("IssQty= null ,");
            }
            if (model.DeclaredQty != null)
            {
                strSql.Append("DeclaredQty=" + model.DeclaredQty + ",");
            }
            else
            {
                strSql.Append("DeclaredQty= null ,");
            }
            if (model.StartDemDate != null)
            {
                strSql.Append("StartDemDate='" + model.StartDemDate + "',");
            }
            else
            {
                strSql.Append("StartDemDate= null ,");
            }
            if (model.EndDemDate != null)
            {
                strSql.Append("EndDemDate='" + model.EndDemDate + "',");
            }
            else
            {
                strSql.Append("EndDemDate= null ,");
            }
            if (model.WhCode != null)
            {
                strSql.Append("WhCode='" + model.WhCode + "',");
            }
            else
            {
                strSql.Append("WhCode= null ,");
            }
            if (model.LotNo != null)
            {
                strSql.Append("LotNo='" + model.LotNo + "',");
            }
            else
            {
                strSql.Append("LotNo= null ,");
            }
            if (model.WIPType != null)
            {
                strSql.Append("WIPType=" + model.WIPType + ",");
            }
            else
            {
                strSql.Append("WIPType= null ,");
            }
            if (model.QcFlag != null)
            {
                strSql.Append("QcFlag=" + (model.QcFlag ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("QcFlag= null ,");
            }
            if (model.Offset != null)
            {
                strSql.Append("Offset=" + model.Offset + ",");
            }
            else
            {
                strSql.Append("Offset= null ,");
            }
            if (model.InvCode != null)
            {
                strSql.Append("InvCode='" + model.InvCode + "',");
            }
            else
            {
                strSql.Append("InvCode= null ,");
            }
            if (model.Free1 != null)
            {
                strSql.Append("Free1='" + model.Free1 + "',");
            }
            else
            {
                strSql.Append("Free1= null ,");
            }
            if (model.Free2 != null)
            {
                strSql.Append("Free2='" + model.Free2 + "',");
            }
            else
            {
                strSql.Append("Free2= null ,");
            }
            if (model.Free3 != null)
            {
                strSql.Append("Free3='" + model.Free3 + "',");
            }
            else
            {
                strSql.Append("Free3= null ,");
            }
            if (model.Free4 != null)
            {
                strSql.Append("Free4='" + model.Free4 + "',");
            }
            else
            {
                strSql.Append("Free4= null ,");
            }
            if (model.Free5 != null)
            {
                strSql.Append("Free5='" + model.Free5 + "',");
            }
            else
            {
                strSql.Append("Free5= null ,");
            }
            if (model.Free6 != null)
            {
                strSql.Append("Free6='" + model.Free6 + "',");
            }
            else
            {
                strSql.Append("Free6= null ,");
            }
            if (model.Free7 != null)
            {
                strSql.Append("Free7='" + model.Free7 + "',");
            }
            else
            {
                strSql.Append("Free7= null ,");
            }
            if (model.Free8 != null)
            {
                strSql.Append("Free8='" + model.Free8 + "',");
            }
            else
            {
                strSql.Append("Free8= null ,");
            }
            if (model.Free9 != null)
            {
                strSql.Append("Free9='" + model.Free9 + "',");
            }
            else
            {
                strSql.Append("Free9= null ,");
            }
            if (model.Free10 != null)
            {
                strSql.Append("Free10='" + model.Free10 + "',");
            }
            else
            {
                strSql.Append("Free10= null ,");
            }
            if (model.OpComponentId != null)
            {
                strSql.Append("OpComponentId=" + model.OpComponentId + ",");
            }
            else
            {
                strSql.Append("OpComponentId= null ,");
            }
            if (model.Define22 != null)
            {
                strSql.Append("Define22='" + model.Define22 + "',");
            }
            else
            {
                strSql.Append("Define22= null ,");
            }
            if (model.Define23 != null)
            {
                strSql.Append("Define23='" + model.Define23 + "',");
            }
            else
            {
                strSql.Append("Define23= null ,");
            }
            if (model.Define24 != null)
            {
                strSql.Append("Define24='" + model.Define24 + "',");
            }
            else
            {
                strSql.Append("Define24= null ,");
            }
            if (model.Define25 != null)
            {
                strSql.Append("Define25='" + model.Define25 + "',");
            }
            else
            {
                strSql.Append("Define25= null ,");
            }
            if (model.Define26 != null)
            {
                strSql.Append("Define26=" + model.Define26 + ",");
            }
            else
            {
                strSql.Append("Define26= null ,");
            }
            if (model.Define27 != null)
            {
                strSql.Append("Define27=" + model.Define27 + ",");
            }
            else
            {
                strSql.Append("Define27= null ,");
            }
            if (model.Define28 != null)
            {
                strSql.Append("Define28='" + model.Define28 + "',");
            }
            else
            {
                strSql.Append("Define28= null ,");
            }
            if (model.Define29 != null)
            {
                strSql.Append("Define29='" + model.Define29 + "',");
            }
            else
            {
                strSql.Append("Define29= null ,");
            }
            if (model.Define30 != null)
            {
                strSql.Append("Define30='" + model.Define30 + "',");
            }
            else
            {
                strSql.Append("Define30= null ,");
            }
            if (model.Define31 != null)
            {
                strSql.Append("Define31='" + model.Define31 + "',");
            }
            else
            {
                strSql.Append("Define31= null ,");
            }
            if (model.Define32 != null)
            {
                strSql.Append("Define32='" + model.Define32 + "',");
            }
            else
            {
                strSql.Append("Define32= null ,");
            }
            if (model.Define33 != null)
            {
                strSql.Append("Define33='" + model.Define33 + "',");
            }
            else
            {
                strSql.Append("Define33= null ,");
            }
            if (model.Define34 != null)
            {
                strSql.Append("Define34=" + model.Define34 + ",");
            }
            else
            {
                strSql.Append("Define34= null ,");
            }
            if (model.Define35 != null)
            {
                strSql.Append("Define35=" + model.Define35 + ",");
            }
            else
            {
                strSql.Append("Define35= null ,");
            }
            if (model.Define36 != null)
            {
                strSql.Append("Define36='" + model.Define36 + "',");
            }
            else
            {
                strSql.Append("Define36= null ,");
            }
            if (model.Define37 != null)
            {
                strSql.Append("Define37='" + model.Define37 + "',");
            }
            else
            {
                strSql.Append("Define37= null ,");
            }
            if (model.AuxUnitCode != null)
            {
                strSql.Append("AuxUnitCode='" + model.AuxUnitCode + "',");
            }
            else
            {
                strSql.Append("AuxUnitCode= null ,");
            }
            if (model.ChangeRate != null)
            {
                strSql.Append("ChangeRate=" + model.ChangeRate + ",");
            }
            else
            {
                strSql.Append("ChangeRate= null ,");
            }
            if (model.AuxBaseQtyN != null)
            {
                strSql.Append("AuxBaseQtyN=" + model.AuxBaseQtyN + ",");
            }
            else
            {
                strSql.Append("AuxBaseQtyN= null ,");
            }
            if (model.AuxQty != null)
            {
                strSql.Append("AuxQty=" + model.AuxQty + ",");
            }
            else
            {
                strSql.Append("AuxQty= null ,");
            }
            if (model.ReplenishQty != null)
            {
                strSql.Append("ReplenishQty=" + model.ReplenishQty + ",");
            }
            else
            {
                strSql.Append("ReplenishQty= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.TransQty != null)
            {
                strSql.Append("TransQty=" + model.TransQty + ",");
            }
            else
            {
                strSql.Append("TransQty= null ,");
            }
            if (model.ProductType != null)
            {
                strSql.Append("ProductType=" + model.ProductType + ",");
            }
            else
            {
                strSql.Append("ProductType= null ,");
            }
            if (model.SoType != null)
            {
                strSql.Append("SoType=" + model.SoType + ",");
            }
            else
            {
                strSql.Append("SoType= null ,");
            }
            if (model.SoDId != null)
            {
                strSql.Append("SoDId='" + model.SoDId + "',");
            }
            else
            {
                strSql.Append("SoDId= null ,");
            }
            if (model.SoCode != null)
            {
                strSql.Append("SoCode='" + model.SoCode + "',");
            }
            else
            {
                strSql.Append("SoCode= null ,");
            }
            if (model.SoSeq != null)
            {
                strSql.Append("SoSeq=" + model.SoSeq + ",");
            }
            else
            {
                strSql.Append("SoSeq= null ,");
            }
            if (model.DemandCode != null)
            {
                strSql.Append("DemandCode='" + model.DemandCode + "',");
            }
            else
            {
                strSql.Append("DemandCode= null ,");
            }
            if (model.QmFlag != null)
            {
                strSql.Append("QmFlag=" + (model.QmFlag ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("QmFlag= null ,");
            }
            if (model.OrgQty != null)
            {
                strSql.Append("OrgQty=" + model.OrgQty + ",");
            }
            else
            {
                strSql.Append("OrgQty= null ,");
            }
            if (model.OrgAuxQty != null)
            {
                strSql.Append("OrgAuxQty=" + model.OrgAuxQty + ",");
            }
            else
            {
                strSql.Append("OrgAuxQty= null ,");
            }
            if (model.CostItemCode != null)
            {
                strSql.Append("CostItemCode='" + model.CostItemCode + "',");
            }
            else
            {
                strSql.Append("CostItemCode= null ,");
            }
            if (model.CostItemName != null)
            {
                strSql.Append("CostItemName='" + model.CostItemName + "',");
            }
            else
            {
                strSql.Append("CostItemName= null ,");
            }
            if (model.RequisitionFlag != null)
            {
                strSql.Append("RequisitionFlag=" + (model.RequisitionFlag ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("RequisitionFlag= null ,");
            }
            if (model.RequisitionQty != null)
            {
                strSql.Append("RequisitionQty=" + model.RequisitionQty + ",");
            }
            else
            {
                strSql.Append("RequisitionQty= null ,");
            }
            if (model.RequisitionIssQty != null)
            {
                strSql.Append("RequisitionIssQty=" + model.RequisitionIssQty + ",");
            }
            else
            {
                strSql.Append("RequisitionIssQty= null ,");
            }
            if (model.CostWIPRel != null)
            {
                strSql.Append("CostWIPRel=" + (model.CostWIPRel ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("CostWIPRel= null ,");
            }
            if (model.MoallocateSubId != null)
            {
                strSql.Append("MoallocateSubId='" + model.MoallocateSubId + "',");
            }
            else
            {
                strSql.Append("MoallocateSubId= null ,");
            }
            if (model.cSubSysBarCode != null)
            {
                strSql.Append("cSubSysBarCode='" + model.cSubSysBarCode + "',");
            }
            else
            {
                strSql.Append("cSubSysBarCode= null ,");
            }
            if (model.PickingQty != null)
            {
                strSql.Append("PickingQty=" + model.PickingQty + ",");
            }
            else
            {
                strSql.Append("PickingQty= null ,");
            }
            if (model.PickingAuxQty != null)
            {
                strSql.Append("PickingAuxQty=" + model.PickingAuxQty + ",");
            }
            else
            {
                strSql.Append("PickingAuxQty= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where AllocateId=" + model.AllocateId + " and MoDId=" + model.MoDId + " ");
            return strSql.ToString();

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.mom_moallocate GetModel(int AllocateId, int MoDId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" AllocateId,MoDId,SortSeq,OpSeq,ComponentId,FVFlag,BaseQtyN,BaseQtyD,ParentScrap,CompScrap,Qty,IssQty,DeclaredQty,StartDemDate,EndDemDate,WhCode,LotNo,WIPType,ByproductFlag,QcFlag,Offset,InvCode,Free1,Free2,Free3,Free4,Free5,Free6,Free7,Free8,Free9,Free10,OpComponentId,Define22,Define23,Define24,Define25,Define26,Define27,Define28,Define29,Define30,Define31,Define32,Define33,Define34,Define35,Define36,Define37,Ufts,AuxUnitCode,ChangeRate,AuxBaseQtyN,AuxQty,ReplenishQty,Remark,TransQty,ProductType,SoType,SoDId,SoCode,SoSeq,DemandCode,QmFlag,OrgQty,OrgAuxQty,CostItemCode,CostItemName,RequisitionFlag,RequisitionQty,RequisitionIssQty,CostWIPRel,MoallocateSubId,cSubSysBarCode,PickingQty,PickingAuxQty ");
            strSql.Append(" from mom_moallocate ");
            strSql.Append(" where AllocateId=" + AllocateId + " and MoDId=" + MoDId + " ");
            TH.Model.mom_moallocate model = new TH.Model.mom_moallocate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.mom_moallocate DataRowToModel(DataRow row)
        {
            TH.Model.mom_moallocate model = new TH.Model.mom_moallocate();
            if (row != null)
            {
                if (row["AllocateId"] != null && row["AllocateId"].ToString() != "")
                {
                    model.AllocateId = long.Parse(row["AllocateId"].ToString());
                }
                if (row["MoDId"] != null && row["MoDId"].ToString() != "")
                {
                    model.MoDId = long.Parse(row["MoDId"].ToString());
                }
                if (row["SortSeq"] != null && row["SortSeq"].ToString() != "")
                {
                    model.SortSeq = long.Parse(row["SortSeq"].ToString());
                }
                if (row["OpSeq"] != null)
                {
                    model.OpSeq = row["OpSeq"].ToString();
                }
                if (row["ComponentId"] != null && row["ComponentId"].ToString() != "")
                {
                    model.ComponentId = long.Parse(row["ComponentId"].ToString());
                }
                if (row["FVFlag"] != null && row["FVFlag"].ToString() != "")
                {
                    model.FVFlag = long.Parse(row["FVFlag"].ToString());
                }
                if (row["BaseQtyN"] != null && row["BaseQtyN"].ToString() != "")
                {
                    model.BaseQtyN = decimal.Parse(row["BaseQtyN"].ToString());
                }
                if (row["BaseQtyD"] != null && row["BaseQtyD"].ToString() != "")
                {
                    model.BaseQtyD = decimal.Parse(row["BaseQtyD"].ToString());
                }
                if (row["ParentScrap"] != null && row["ParentScrap"].ToString() != "")
                {
                    model.ParentScrap = decimal.Parse(row["ParentScrap"].ToString());
                }
                if (row["CompScrap"] != null && row["CompScrap"].ToString() != "")
                {
                    model.CompScrap = decimal.Parse(row["CompScrap"].ToString());
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = decimal.Parse(row["Qty"].ToString());
                }
                if (row["IssQty"] != null && row["IssQty"].ToString() != "")
                {
                    model.IssQty = decimal.Parse(row["IssQty"].ToString());
                }
                if (row["DeclaredQty"] != null && row["DeclaredQty"].ToString() != "")
                {
                    model.DeclaredQty = decimal.Parse(row["DeclaredQty"].ToString());
                }
                if (row["StartDemDate"] != null && row["StartDemDate"].ToString() != "")
                {
                    model.StartDemDate = DateTime.Parse(row["StartDemDate"].ToString());
                }
                if (row["EndDemDate"] != null && row["EndDemDate"].ToString() != "")
                {
                    model.EndDemDate = DateTime.Parse(row["EndDemDate"].ToString());
                }
                if (row["WhCode"] != null)
                {
                    model.WhCode = row["WhCode"].ToString();
                }
                if (row["LotNo"] != null)
                {
                    model.LotNo = row["LotNo"].ToString();
                }
                if (row["WIPType"] != null && row["WIPType"].ToString() != "")
                {
                    model.WIPType = long.Parse(row["WIPType"].ToString());
                }
                if (row["ByproductFlag"] != null && row["ByproductFlag"].ToString() != "")
                {
                    if ((row["ByproductFlag"].ToString() == "1") || (row["ByproductFlag"].ToString().ToLower() == "true"))
                    {
                        model.ByproductFlag = true;
                    }
                    else
                    {
                        model.ByproductFlag = false;
                    }
                }
                if (row["QcFlag"] != null && row["QcFlag"].ToString() != "")
                {
                    if ((row["QcFlag"].ToString() == "1") || (row["QcFlag"].ToString().ToLower() == "true"))
                    {
                        model.QcFlag = true;
                    }
                    else
                    {
                        model.QcFlag = false;
                    }
                }
                if (row["Offset"] != null && row["Offset"].ToString() != "")
                {
                    model.Offset = long.Parse(row["Offset"].ToString());
                }
                if (row["InvCode"] != null)
                {
                    model.InvCode = row["InvCode"].ToString();
                }
                if (row["Free1"] != null)
                {
                    model.Free1 = row["Free1"].ToString();
                }
                if (row["Free2"] != null)
                {
                    model.Free2 = row["Free2"].ToString();
                }
                if (row["Free3"] != null)
                {
                    model.Free3 = row["Free3"].ToString();
                }
                if (row["Free4"] != null)
                {
                    model.Free4 = row["Free4"].ToString();
                }
                if (row["Free5"] != null)
                {
                    model.Free5 = row["Free5"].ToString();
                }
                if (row["Free6"] != null)
                {
                    model.Free6 = row["Free6"].ToString();
                }
                if (row["Free7"] != null)
                {
                    model.Free7 = row["Free7"].ToString();
                }
                if (row["Free8"] != null)
                {
                    model.Free8 = row["Free8"].ToString();
                }
                if (row["Free9"] != null)
                {
                    model.Free9 = row["Free9"].ToString();
                }
                if (row["Free10"] != null)
                {
                    model.Free10 = row["Free10"].ToString();
                }
                if (row["OpComponentId"] != null && row["OpComponentId"].ToString() != "")
                {
                    model.OpComponentId = long.Parse(row["OpComponentId"].ToString());
                }
                if (row["Define22"] != null)
                {
                    model.Define22 = row["Define22"].ToString();
                }
                if (row["Define23"] != null)
                {
                    model.Define23 = row["Define23"].ToString();
                }
                if (row["Define24"] != null)
                {
                    model.Define24 = row["Define24"].ToString();
                }
                if (row["Define25"] != null)
                {
                    model.Define25 = row["Define25"].ToString();
                }
                if (row["Define26"] != null && row["Define26"].ToString() != "")
                {
                    model.Define26 = decimal.Parse(row["Define26"].ToString());
                }
                if (row["Define27"] != null && row["Define27"].ToString() != "")
                {
                    model.Define27 = decimal.Parse(row["Define27"].ToString());
                }
                if (row["Define28"] != null)
                {
                    model.Define28 = row["Define28"].ToString();
                }
                if (row["Define29"] != null)
                {
                    model.Define29 = row["Define29"].ToString();
                }
                if (row["Define30"] != null)
                {
                    model.Define30 = row["Define30"].ToString();
                }
                if (row["Define31"] != null)
                {
                    model.Define31 = row["Define31"].ToString();
                }
                if (row["Define32"] != null)
                {
                    model.Define32 = row["Define32"].ToString();
                }
                if (row["Define33"] != null)
                {
                    model.Define33 = row["Define33"].ToString();
                }
                if (row["Define34"] != null && row["Define34"].ToString() != "")
                {
                    model.Define34 = long.Parse(row["Define34"].ToString());
                }
                if (row["Define35"] != null && row["Define35"].ToString() != "")
                {
                    model.Define35 = long.Parse(row["Define35"].ToString());
                }
                if (row["Define36"] != null && row["Define36"].ToString() != "")
                {
                    model.Define36 = DateTime.Parse(row["Define36"].ToString());
                }
                if (row["Define37"] != null && row["Define37"].ToString() != "")
                {
                    model.Define37 = DateTime.Parse(row["Define37"].ToString());
                }
                //if (row["Ufts"] != null && row["Ufts"].ToString() != "")
                //{
                //    model.Ufts = DateTime.Parse(row["Ufts"].ToString());
                //}
                if (row["AuxUnitCode"] != null)
                {
                    model.AuxUnitCode = row["AuxUnitCode"].ToString();
                }
                if (row["ChangeRate"] != null && row["ChangeRate"].ToString() != "")
                {
                    model.ChangeRate = decimal.Parse(row["ChangeRate"].ToString());
                }
                if (row["AuxBaseQtyN"] != null && row["AuxBaseQtyN"].ToString() != "")
                {
                    model.AuxBaseQtyN = decimal.Parse(row["AuxBaseQtyN"].ToString());
                }
                if (row["AuxQty"] != null && row["AuxQty"].ToString() != "")
                {
                    model.AuxQty = decimal.Parse(row["AuxQty"].ToString());
                }
                if (row["ReplenishQty"] != null && row["ReplenishQty"].ToString() != "")
                {
                    model.ReplenishQty = decimal.Parse(row["ReplenishQty"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["TransQty"] != null && row["TransQty"].ToString() != "")
                {
                    model.TransQty = decimal.Parse(row["TransQty"].ToString());
                }
                if (row["ProductType"] != null && row["ProductType"].ToString() != "")
                {
                    model.ProductType = long.Parse(row["ProductType"].ToString());
                }
                if (row["SoType"] != null && row["SoType"].ToString() != "")
                {
                    model.SoType = long.Parse(row["SoType"].ToString());
                }
                if (row["SoDId"] != null)
                {
                    model.SoDId = row["SoDId"].ToString();
                }
                if (row["SoCode"] != null)
                {
                    model.SoCode = row["SoCode"].ToString();
                }
                if (row["SoSeq"] != null && row["SoSeq"].ToString() != "")
                {
                    model.SoSeq = long.Parse(row["SoSeq"].ToString());
                }
                if (row["DemandCode"] != null)
                {
                    model.DemandCode = row["DemandCode"].ToString();
                }
                if (row["QmFlag"] != null && row["QmFlag"].ToString() != "")
                {
                    if ((row["QmFlag"].ToString() == "1") || (row["QmFlag"].ToString().ToLower() == "true"))
                    {
                        model.QmFlag = true;
                    }
                    else
                    {
                        model.QmFlag = false;
                    }
                }
                if (row["OrgQty"] != null && row["OrgQty"].ToString() != "")
                {
                    model.OrgQty = decimal.Parse(row["OrgQty"].ToString());
                }
                if (row["OrgAuxQty"] != null && row["OrgAuxQty"].ToString() != "")
                {
                    model.OrgAuxQty = decimal.Parse(row["OrgAuxQty"].ToString());
                }
                if (row["CostItemCode"] != null)
                {
                    model.CostItemCode = row["CostItemCode"].ToString();
                }
                if (row["CostItemName"] != null)
                {
                    model.CostItemName = row["CostItemName"].ToString();
                }
                if (row["RequisitionFlag"] != null && row["RequisitionFlag"].ToString() != "")
                {
                    if ((row["RequisitionFlag"].ToString() == "1") || (row["RequisitionFlag"].ToString().ToLower() == "true"))
                    {
                        model.RequisitionFlag = true;
                    }
                    else
                    {
                        model.RequisitionFlag = false;
                    }
                }
                if (row["RequisitionQty"] != null && row["RequisitionQty"].ToString() != "")
                {
                    model.RequisitionQty = decimal.Parse(row["RequisitionQty"].ToString());
                }
                if (row["RequisitionIssQty"] != null && row["RequisitionIssQty"].ToString() != "")
                {
                    model.RequisitionIssQty = decimal.Parse(row["RequisitionIssQty"].ToString());
                }
                if (row["CostWIPRel"] != null && row["CostWIPRel"].ToString() != "")
                {
                    if ((row["CostWIPRel"].ToString() == "1") || (row["CostWIPRel"].ToString().ToLower() == "true"))
                    {
                        model.CostWIPRel = true;
                    }
                    else
                    {
                        model.CostWIPRel = false;
                    }
                }
                if (row["MoallocateSubId"] != null && row["MoallocateSubId"].ToString() != "")
                {
                    model.MoallocateSubId = new Guid(row["MoallocateSubId"].ToString());
                }
                if (row["cSubSysBarCode"] != null)
                {
                    model.cSubSysBarCode = row["cSubSysBarCode"].ToString();
                }
                if (row["PickingQty"] != null && row["PickingQty"].ToString() != "")
                {
                    model.PickingQty = decimal.Parse(row["PickingQty"].ToString());
                }
                if (row["PickingAuxQty"] != null && row["PickingAuxQty"].ToString() != "")
                {
                    model.PickingAuxQty = decimal.Parse(row["PickingAuxQty"].ToString());
                }
            }
            return model;
        }
        #endregion

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
    }
}

