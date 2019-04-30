using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
	public partial class sfc_optransform
	{
		public sfc_optransform()
		{}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.sfc_optransform model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.TransformId != null)
            {
                strSql1.Append("TransformId,");
                strSql2.Append("" + model.TransformId + ",");
            }
            if (model.DocCode != null)
            {
                strSql1.Append("DocCode,");
                strSql2.Append("'" + model.DocCode + "',");
            }
            if (model.DocDate != null)
            {
                strSql1.Append("DocDate,");
                strSql2.Append("'" + model.DocDate + "',");
            }
            if (model.MoId != null)
            {
                strSql1.Append("MoId,");
                strSql2.Append("" + model.MoId + ",");
            }
            if (model.MoDId != null)
            {
                strSql1.Append("MoDId,");
                strSql2.Append("" + model.MoDId + ",");
            }
            if (model.MoRoutingId != null)
            {
                strSql1.Append("MoRoutingId,");
                strSql2.Append("" + model.MoRoutingId + ",");
            }
            if (model.MoRoutingDId != null)
            {
                strSql1.Append("MoRoutingDId,");
                strSql2.Append("" + model.MoRoutingDId + ",");
            }
            if (model.TransformType != null)
            {
                strSql1.Append("TransformType,");
                strSql2.Append("" + model.TransformType + ",");
            }
            if (model.OpStatus != null)
            {
                strSql1.Append("OpStatus,");
                strSql2.Append("" + model.OpStatus + ",");
            }
            if (model.TransOutQty != null)
            {
                strSql1.Append("TransOutQty,");
                strSql2.Append("" + model.TransOutQty + ",");
            }
            if (model.InMoRoutingDId != null)
            {
                strSql1.Append("InMoRoutingDId,");
                strSql2.Append("" + model.InMoRoutingDId + ",");
            }
            if (model.QualifiedQty != null)
            {
                strSql1.Append("QualifiedQty,");
                strSql2.Append("" + model.QualifiedQty + ",");
            }
            if (model.ScrapQty != null)
            {
                strSql1.Append("ScrapQty,");
                strSql2.Append("" + model.ScrapQty + ",");
            }
            if (model.RefusedQty != null)
            {
                strSql1.Append("RefusedQty,");
                strSql2.Append("" + model.RefusedQty + ",");
            }
            if (model.DeclareQty != null)
            {
                strSql1.Append("DeclareQty,");
                strSql2.Append("" + model.DeclareQty + ",");
            }
            if (model.MachiningQty != null)
            {
                strSql1.Append("MachiningQty,");
                strSql2.Append("" + model.MachiningQty + ",");
            }
            if (model.DeclaredQty != null)
            {
                strSql1.Append("DeclaredQty,");
                strSql2.Append("" + model.DeclaredQty + ",");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
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
            //if (model.Ufts != null)
            //{
            //    strSql1.Append("Ufts,");
            //    strSql2.Append("" + model.Ufts + ",");
            //}
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
            if (model.QcFlag != null)
            {
                strSql1.Append("QcFlag,");
                strSql2.Append("" + (model.QcFlag ? 1 : 0) + ",");
            }
            if (model.OutQcFlag != null)
            {
                strSql1.Append("OutQcFlag,");
                strSql2.Append("" + (model.OutQcFlag ? 1 : 0) + ",");
            }
            if (model.VTid != null)
            {
                strSql1.Append("VTid,");
                strSql2.Append("" + model.VTid + ",");
            }
            if (model.InAuxUnitCode != null)
            {
                strSql1.Append("InAuxUnitCode,");
                strSql2.Append("'" + model.InAuxUnitCode + "',");
            }
            //if (model.InChangeRate != null)
            //{
            //    strSql1.Append("InChangeRate,");
            //    strSql2.Append("" + model.InChangeRate + ",");
            //}
            if (model.ReasonCode != null)
            {
                strSql1.Append("ReasonCode,");
                strSql2.Append("'" + model.ReasonCode + "',");
            }
            if (model.QualifiedReasonCode != null)
            {
                strSql1.Append("QualifiedReasonCode,");
                strSql2.Append("'" + model.QualifiedReasonCode + "',");
            }
            if (model.RefusedReasonCode != null)
            {
                strSql1.Append("RefusedReasonCode,");
                strSql2.Append("'" + model.RefusedReasonCode + "',");
            }
            if (model.ScrapReasonCode != null)
            {
                strSql1.Append("ScrapReasonCode,");
                strSql2.Append("'" + model.ScrapReasonCode + "',");
            }
            if (model.QcType != null)
            {
                strSql1.Append("QcType,");
                strSql2.Append("" + model.QcType + ",");
            }
            if (model.CheckId != null)
            {
                strSql1.Append("CheckId,");
                strSql2.Append("" + model.CheckId + ",");
            }
            if (model.WorkHrId != null)
            {
                strSql1.Append("WorkHrId,");
                strSql2.Append("" + model.WorkHrId + ",");
            }
            if (model.Status != null)
            {
                strSql1.Append("Status,");
                strSql2.Append("" + model.Status + ",");
            }
            if (model.BFedFlag != null)
            {
                strSql1.Append("BFedFlag,");
                strSql2.Append("" + (model.BFedFlag ? 1 : 0) + ",");
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
            if (model.DocTime != null)
            {
                strSql1.Append("DocTime,");
                strSql2.Append("'" + model.DocTime + "',");
            }
            if (model.PFReportId != null)
            {
                strSql1.Append("PFReportId,");
                strSql2.Append("" + model.PFReportId + ",");
            }
            if (model.PFReportDId != null)
            {
                strSql1.Append("PFReportDId,");
                strSql2.Append("" + model.PFReportDId + ",");
            }
            if (model.PFDId != null)
            {
                strSql1.Append("PFDId,");
                strSql2.Append("" + model.PFDId + ",");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            strSql.Append("insert into @u8.sfc_optransform(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TransformId,DocCode,DocDate,MoId,MoDId,MoRoutingId,MoRoutingDId,TransformType,OpStatus,TransOutQty,InMoRoutingDId,QualifiedQty,ScrapQty,RefusedQty,DeclareQty,MachiningQty,DeclaredQty,Remark,CreateDate,CreateUser,ModifyDate,ModifyUser,UpdCount,Ufts,Define1,Define2,Define3,Define4,Define5,Define6,Define7,Define8,Define9,Define10,Define11,Define12,Define13,Define14,Define15,Define16,QcFlag,OutQcFlag,VTid,InAuxUnitCode,InChangeRate,ReasonCode,QualifiedReasonCode,RefusedReasonCode,ScrapReasonCode,QcType,CheckId,WorkHrId,Status,BFedFlag,CreateTime,ModifyTime,DocTime,PFReportId,PFReportDId,PFDId,iPrintCount ");
            strSql.Append(" FROM @u8.sfc_optransform ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dDate"></param>
        /// <param name="dtDetails"></param>
        /// <returns></returns>
        public int Save(DataTable dtDetails,int ibatch)
        {
            int iCount = 0;
            try
            {
                string sReturn = "";
                string sSQL = "";

                sSQL = "select getdate()";
                DateTime d当前服务器时间 = Convert.ToDateTime(DbHelperSQL.Query(sSQL).Tables[0].Rows[0][0]);

                sSQL = "SELECT   iFatherId FROM UFSystem..UA_Identity WHERE (cVouchType = 'sfc_optransform') and cAcc_Id='" + ClsBaseDataInfo.sUFDataBaseName.Trim().Substring(7, 3) + "'";
                DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
                long lID = BaseFunction.BaseFunction.ReturnLong(dt.Rows[0][0]);

                long iRdCode = 0;
                sSQL = "select * From @u8.VoucherHistory  with (ROWLOCK) Where  CardNumber='FC31' and cContent='单据日期' and cSeed='" + d当前服务器时间.ToString("yyyyMM") + "'";
                DataTable dtTemp = DbHelperSQL.Query(sSQL).Tables[0];
                if (dtTemp == null || dtTemp.Rows.Count < 1)
                {
                    iRdCode = 1;
                }
                else
                {
                    iRdCode = BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows[0]["cNumber"]);
                }

                List<string> l = new List<string>();
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {
                    if (dtDetails.Rows[i]["MoId"].ToString() != "")
                    {
                        if (dtDetails.Rows[i]["iSave"].ToString().Trim() == "add")
                        {
                            string check = GetCheck(dtDetails, ibatch, i);
                            if (check == "")
                            {
                                iCount = iCount + 1;
                                iRdCode = iRdCode + 1;
                                lID = lID + 1;
                                long slID =  lID; 
                                string s单据号 = sGetCode(iRdCode, 5, "GXZY" + d当前服务器时间.ToString("yyMM"));
                                TH.Model.sfc_optransform model = new TH.Model.sfc_optransform();
                                model.TransformId = slID;
                                model.DocCode = s单据号;
                                model.MoId = BaseFunction.BaseFunction.ReturnInt(dtDetails.Rows[i]["MoId"]);
                                model.MoDId = BaseFunction.BaseFunction.ReturnInt(dtDetails.Rows[i]["MoDId"]);
                                model.MoRoutingDId = BaseFunction.BaseFunction.ReturnInt(dtDetails.Rows[i]["MoRoutingDId"]);
                                model.MoRoutingId = BaseFunction.BaseFunction.ReturnInt(dtDetails.Rows[i]["MoRoutingId"]);
                                string InMoRoutingDId = dtDetails.Rows[i]["InMoRoutingDId"].ToString();
                                sSQL = "select top 1 * from @u8.sfc_moroutingdetail  with (ROWLOCK) where MoRoutingId='" + dtDetails.Rows[i]["MoRoutingId"].ToString() + "' and OpSeq<'" + dtDetails.Rows[i]["移入工序"].ToString() + "' and CompleteQty =0 order by OpSeq ";
                                DataTable dtd = DbHelperSQL.Query(sSQL).Tables[0];
                                if (dtd.Rows.Count > 0)
                                {
                                    string oldmdid = InMoRoutingDId;//
                                    InMoRoutingDId = dtd.Rows[0]["MoRoutingDId"].ToString();//新的工序id
                                    string newOpSeq = dtd.Rows[0]["OpSeq"].ToString();
                                    string newOperationId = dtd.Rows[0]["OperationId"].ToString();
                                    string newDescription = dtd.Rows[0]["Description"].ToString();
                                    string newWcId = dtd.Rows[0]["WcId"].ToString();
                                    string newLastFlag = dtd.Rows[0]["LastFlag"].ToString();

                                    sSQL = "select top 1 * from @u8.sfc_moroutingdetail  with (ROWLOCK) where MoRoutingDId='" + oldmdid + "' ";
                                    DataTable dtdold = DbHelperSQL.Query(sSQL).Tables[0];
                                    string oldOpSeq = dtdold.Rows[0]["OpSeq"].ToString();
                                    string oldOperationId = dtdold.Rows[0]["OperationId"].ToString();
                                    string oldDescription = dtdold.Rows[0]["Description"].ToString();
                                    string oldWcId = dtdold.Rows[0]["WcId"].ToString();
                                    string oldLastFlag = dtdold.Rows[0]["LastFlag"].ToString();

                                    sSQL = "update @u8.sfc_moroutingdetail set OperationId='" + oldOperationId + "',Description='" + oldDescription + "',WcId='" + oldWcId + "',LastFlag='" + oldLastFlag + "' where MoRoutingDId='" + InMoRoutingDId + "'";
                                    l.Add(sSQL);
                                    sSQL = "update @u8.sfc_moroutingdetail set OperationId='" + newOperationId + "',Description='" + newDescription + "',WcId='" + newWcId + "',LastFlag='" + newLastFlag + "' where MoRoutingDId='" + oldmdid + "'";
                                    l.Add(sSQL);

                                }
                                model.InMoRoutingDId = BaseFunction.BaseFunction.ReturnInt(InMoRoutingDId);
                                model.DocDate = DateTime.Parse(dtDetails.Rows[i]["DocDate"].ToString());
                                model.TransformType = BaseFunction.BaseFunction.ReturnInt(dtDetails.Rows[i]["TransformType"]);
                                model.OpStatus = BaseFunction.BaseFunction.ReturnInt(dtDetails.Rows[i]["OpStatus"]);//转出状态

                                model.QualifiedQty = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["QualifiedQty"]);
                                model.ScrapQty = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["ScrapQty"]);
                                model.RefusedQty = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["RefusedQty"]);
                                model.DeclareQty = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["DeclareQty"]);
                                model.MachiningQty = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["MachiningQty"]);

                                decimal i可用数量 = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["可用数量"]);
                                if (i可用数量 == 0)
                                {
                                    sReturn = sReturn + dtDetails.Rows[i]["MoRoutingDId"].ToString() + "可用数量不可为0\n";
                                }
                                else
                                {
                                    decimal TransOutQty = model.QualifiedQty + model.ScrapQty + model.RefusedQty + model.DeclareQty + model.MachiningQty;
                                    model.TransOutQty = TransOutQty;//转出数量
                                    if (i可用数量 < TransOutQty)
                                    {
                                        sReturn = sReturn + dtDetails.Rows[i]["MoRoutingDId"].ToString() + "转出数量大于可用数量\n";
                                    }
                                }

                                model.Remark = dtDetails.Rows[i]["Remark"].ToString();
                                model.QcFlag = BaseFunction.BaseFunction.ReturnBool(dtDetails.Rows[i]["QcFlag"]);//是否移入检验
                                model.OutQcFlag = BaseFunction.BaseFunction.ReturnBool(dtDetails.Rows[i]["OutQcFlag"]);//是否移出检验
                                model.Define7 = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["Define7"]); //定额工时
                                model.Define16 = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i]["Define16"]); //劳动工时
                                model.Define11 = dtDetails.Rows[i]["Define11"].ToString(); //移出工作中心
                                model.Define12 = dtDetails.Rows[i]["Define12"].ToString(); //移入工作中心
                                model.Define10 = dtDetails.Rows[i]["Define10"].ToString(); //客户
                                model.Define13 = dtDetails.Rows[i]["Define13"].ToString(); //让步原因
                                model.Define14 = dtDetails.Rows[i]["Define14"].ToString(); //检验员移入工序
                                model.Define9 = dtDetails.Rows[i]["Define9"].ToString(); //工厂

                                //model.Define2 = dtDetails.Rows[i]["Define2"].ToString(); //设备
                                //model.Define3 = dtDetails.Rows[i]["Define3"].ToString(); //人员
                                //model.Define8 = dtDetails.Rows[i]["Define8"].ToString(); //炉号
                                model.CreateTime = DateTime.Now;
                                model.CreateUser = ClsBaseDataInfo.sUid;


                                sSQL = Add(model);
                                l.Add(sSQL);
                                sSQL = "delete from 工序转移单 where TransformId=" + slID + "";
                                l.Add(sSQL);
                                sSQL = "insert into 工序转移单(TransformId, 试样号, 材质, 重量, 渗层, 人员列表, 工时列表, 人员, 工时,设备,炉号,备注) values(" + slID + ",'" + dtDetails.Rows[i]["试样号"] + "',"
                                + "'" + dtDetails.Rows[i]["材质"] + "','" + dtDetails.Rows[i]["重量"] + "','" + dtDetails.Rows[i]["渗层"] + "','" + dtDetails.Rows[i]["人员列表"] + "',"
                                + "'" + dtDetails.Rows[i]["工时列表"] + "','" + dtDetails.Rows[i]["人员"] + "','" + dtDetails.Rows[i]["工时"] + "',"
                                + "'" + dtDetails.Rows[i]["设备"] + "','" + dtDetails.Rows[i]["炉号"] + "','" + dtDetails.Rows[i]["备注"] + "')";
                                l.Add(sSQL);

                                //转入
                                decimal diffqty = model.QualifiedQty + model.RefusedQty + model.ScrapQty + model.DeclareQty + model.MachiningQty;
                                sSQL = "update @u8.sfc_moroutingdetail set BalQualifiedQty=BalQualifiedQty+" + model.QualifiedQty +
                                    ",BalRefusedQty=BalRefusedQty+" + model.RefusedQty +
                                    ",BalScrapQty=BalScrapQty+" + model.ScrapQty +
                                    ",BalDeclareQty=BalDeclareQty+" + model.DeclareQty +
                                    ",BalMachiningQty=BalMachiningQty+" + model.MachiningQty +
                                    ",CompleteQty=" + diffqty +
                                    "where MoRoutingDId=" + model.InMoRoutingDId;
                                l.Add(sSQL);

                                //转出
                                sSQL = "update @u8.sfc_moroutingdetail set 1111111111111111111111111111,22222222222222222222222222222 where MoRoutingDId=" + model.MoRoutingDId;
                                if (model.OpStatus == 1)
                                {
                                    sSQL = sSQL.Replace("1111111111111111111111111111", "BalMachiningQty=BalMachiningQty-" + diffqty);
                                }
                                else if (model.OpStatus == 2)
                                {
                                    sSQL = sSQL.Replace("1111111111111111111111111111", "BalDeclareQty=BalDeclareQty-" + diffqty);
                                }
                                else if (model.OpStatus == 3)
                                {
                                    sSQL = sSQL.Replace("1111111111111111111111111111", "BalQualifiedQty=BalQualifiedQty-" + diffqty);
                                }
                                else if (model.OpStatus == 4)
                                {
                                    sSQL = sSQL.Replace("1111111111111111111111111111", "BalRefusedQty=BalRefusedQty-" + diffqty);
                                }
                                else if (model.OpStatus == 5)
                                {
                                    sSQL = sSQL.Replace("1111111111111111111111111111", "BalScrapQty=BalScrapQty-" + diffqty);
                                }
                                sSQL = sSQL.Replace(",22222222222222222222222222222", "");
                                l.Add(sSQL);

                                sSQL = "update @u8.sfc_optransform set InChangeRate=null where TransformId='" + slID + "'";
                                l.Add(sSQL);
                            }
                            else
                            {
                                sReturn = sReturn + check;
                            }
                        }
                        else if (dtDetails.Rows[i]["iSave"].ToString().Trim() == "update")
                        {
                            sSQL = "update 工序转移单 set 试样号='" + dtDetails.Rows[i]["试样号"] + "',材质='" + dtDetails.Rows[i]["材质"] + "',重量='" + dtDetails.Rows[i]["重量"] + "',"
                            + "渗层='" + dtDetails.Rows[i]["渗层"] + "',人员列表='" + dtDetails.Rows[i]["人员列表"] + "',工时列表='" + dtDetails.Rows[i]["工时列表"] + "',人员='" + dtDetails.Rows[i]["人员"] + "',工时='" + dtDetails.Rows[i]["工时"] + "',"
                            + "设备='" + dtDetails.Rows[i]["设备"] + "',炉号='" + dtDetails.Rows[i]["炉号"] + "',备注='" + dtDetails.Rows[i]["备注"] + "' where TransformId='" + dtDetails.Rows[i]["TransformId"] + "'";
                            l.Add(sSQL);

                            sSQL = "update @u8.sfc_optransform set Define16='" + dtDetails.Rows[i]["Define16"] + "',Define14='" + dtDetails.Rows[i]["Define14"] + "' where TransformId='" + dtDetails.Rows[i]["TransformId"] + "'";
                            l.Add(sSQL);
                            iCount = iCount + 1;
                        }
                    }

                }

                sSQL = @"
IF EXISTS(select cNumber as Maxnumber From @u8.VoucherHistory  with (XLOCK) Where  CardNumber='FC31' and cContent='单据日期' and cSeed='111111') 
    update @u8.VoucherHistory set cNumber='222222' Where  CardNumber='FC31' and cContent='单据日期' and cSeed='111111'
else
    Insert into @u8.VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber) values('FC31','单据日期','月','111111','222222')
";
                sSQL = sSQL.Replace("111111", d当前服务器时间.ToString("yyyyMM"));
                sSQL = sSQL.Replace("222222", iRdCode.ToString());
                l.Add(sSQL);

                sSQL = "update  UFSystem..UA_Identity set iFatherID = " + lID + ",iChildID = " + lID + " where cAcc_Id = '" + ClsBaseDataInfo.sUFDataBaseName.Trim().Substring(7, 3) + "' and cVouchType = 'sfc_optransform'";
                l.Add(sSQL);
                if (sReturn.Trim() != "")
                    throw new Exception(sReturn);

                int c = DbHelperSQL.ExecuteSqlTran(l);
            }
            catch(Exception ee)
            {
                throw new Exception(ee.Message);
            }
            return iCount;
        }

        private string GetCheck(DataTable dtDetails, int ibatch,int i)
        {
            try
            {
                string MoId = dtDetails.Rows[i]["MoId"].ToString();
                string MoDId = dtDetails.Rows[i]["MoDId"].ToString();
                string MoRoutingDId = dtDetails.Rows[i]["MoRoutingDId"].ToString();
                string MoRoutingId = dtDetails.Rows[i]["MoRoutingId"].ToString();
                string InMoRoutingDId = dtDetails.Rows[i]["InMoRoutingDId"].ToString();
                string TransformType = dtDetails.Rows[i]["TransformType"].ToString();
                string OpStatus = dtDetails.Rows[i]["OpStatus"].ToString();
                string TransOutQty = dtDetails.Rows[i]["TransOutQty"].ToString();
                decimal d合格 = ReturnObjectToDecimal(dtDetails.Rows[i]["QualifiedQty"], 2);
                decimal d报废 = ReturnObjectToDecimal(dtDetails.Rows[i]["ScrapQty"], 2);
                decimal d让步 = ReturnObjectToDecimal(dtDetails.Rows[i]["RefusedQty"], 2);
                decimal d检验 = ReturnObjectToDecimal(dtDetails.Rows[i]["DeclareQty"], 2);
                decimal d加工 = ReturnObjectToDecimal(dtDetails.Rows[i]["MachiningQty"], 2);
                decimal d订单数量 = ReturnObjectToDecimal(dtDetails.Rows[i]["订单数量"], 2);
                string QcFlag = dtDetails.Rows[i]["QcFlag"].ToString();
                string OutQcFlag = dtDetails.Rows[i]["OutQcFlag"].ToString();
                string Define9 = dtDetails.Rows[i]["Define9"].ToString();
                string txt = "";
                if (ibatch == 2)
                {
                    txt = "第" + (i + 1) + "行";
                }

                if (MoRoutingId == "")
                {
                    throw new Exception(txt + "生产订单不能为空,请输入完整\n");
                }
                string 移入工序 = "";
                string 移出工序 = "";
                DataTable dt工序 = Get工序明细("", MoDId);
                string 移入工序分类 = "";
                string 移出工序分类 = "";
                string 关键工序 = "";
                string FirstFlag = "";
                for (int j = 0; j < dt工序.Rows.Count; j++)
                {
                    if (InMoRoutingDId == dt工序.Rows[j]["MoRoutingDId"].ToString())
                    {
                        移入工序 = dt工序.Rows[j]["OpSeq"].ToString();
                        移入工序分类 = dt工序.Rows[j]["Define34"].ToString();
                        关键工序 = dt工序.Rows[j]["Define35"].ToString();

                    }
                    if (MoRoutingDId == dt工序.Rows[j]["MoRoutingDId"].ToString())
                    {
                        移出工序 = dt工序.Rows[j]["OpSeq"].ToString();
                        移出工序分类 = dt工序.Rows[j]["Define34"].ToString();
                        FirstFlag = dt工序.Rows[j]["FirstFlag"].ToString();
                    }
                }

                if (移入工序 == "")
                {
                    throw new Exception(txt + "移入工序不能为空,请输入完整\n");
                }
                if (移出工序 == "")
                {
                    throw new Exception(txt + "移出工序不能为空,请输入完整\n");
                }
                if (OpStatus == "2" && Define9 == "")
                {
                    throw new Exception(txt + "转出状态为检验时，工厂不能为空,请输入完整\n");
                }
                if (d合格 == 0 && d加工 == 0 && d让步 == 0 && d检验 == 0 && d报废==0)
                {
                    throw new Exception(txt + "合格数量、加工数量、拒绝数量、报检数量、报废数量必须有一项大于0,请输入完整\n");
                }

                
                if (移入工序分类 != "" && 移出工序分类 != "")
                {
                    //本工序是否全部完工
                    DataTable dt本工序 = Select(dt工序, "Define34=" + 移出工序分类, "OpSeq");
                    int qyt未完工 = 0;

                    for (int j = 0; j < dt本工序.Rows.Count; j++)
                    {
                        decimal 本次移动 = 0;
                        if (移出工序 == dt工序.Rows[j]["OpSeq"].ToString())
                        {
                            本次移动 = d合格;
                        }
                        if (ReturnObjectToDecimal(dt本工序.Rows[j]["BalMachiningQty"], 2) + 本次移动 < ReturnObjectToDecimal(d订单数量, 2))
                        {
                            qyt未完工 = qyt未完工 + 1;
                        }
                    }
                    if (移入工序分类 != 移出工序分类)
                    {
                        if (关键工序 != "1")
                        {
                            if (qyt未完工 > 0)
                            {
                                throw new Exception(txt + "本分类工序未全部完工，不可移出工序到下一分类\n");
                            }
                        }
                        else if (关键工序 == "1")
                        {
                            if (qyt未完工 > 1)
                            {
                                throw new Exception(txt + "本分类工序未全部完工，不可移出工序到下一分类\n");
                            }
                        }
                        //判断下一工序点
                        DataTable dt移出 = Select(dt工序, "Define34>" + 移入工序分类, "OpSeq");
                        if (dt移出.Rows.Count > 0)
                        {
                            if (移出工序分类 == dt移出.Rows[0]["Define34"].ToString().Trim())
                            {
                                throw new Exception(txt + "该工序跨越移出工序下一道报告点工序\n");
                            }
                        }
                    }
                }
                if (d加工 != 0)
                {
                    if (移出工序 == 移入工序)
                    {
                        throw new Exception(txt + "内部工序转移移入状态不可与移出状态相同\n");
                    }
                }
            }
            catch(Exception ee)
            {
                return ee.Message;
            }
            return "";
        }

        /// <summary>
        /// 根据序号组装单据号
        /// </summary>
        /// <param name="l"></param>
        /// <param name="iLength"></param>
        /// <param name="s前缀"></param>
        /// <returns></returns>
        private string sGetCode(long l, int iLength, string s前缀)
        {
            string sCode = l.ToString();
            for (int i = 0; i < iLength; i++)
            {
                if (sCode.Length < iLength)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }
            return s前缀 + sCode;
        }

        /// <summary>
        /// 可用工序
        /// </summary>
        /// <param name="MoDId"></param>
        /// <param name="OpSeq"></param>
        /// <returns></returns>
        public decimal GetQty(string MoDId, string MoRoutingDId, string flag)
        {
            string sSQL = @"SELECT MoRoutingDId AS MoRoutingDId, MoRoutingId AS MoRoutingId, MoId AS MoId, MoDId AS MoDId, OpSeq AS OpSeq, OperationId AS OperationId, Description AS Description, WcId AS WcId, StartDate AS StartDate, DueDate AS DueDate, SubFlag AS SubFlag, SVendorCode AS SVendorCode, LtRate AS LtRate, Remark AS Remark, 
BalQualifiedQty AS BalQualifiedQty, BalRefusedQty AS BalRefusedQty, BalScrapQty AS BalScrapQty, BalDeclareQty AS BalDeclareQty, BalMachiningQty AS BalMachiningQty, LastFlag AS LastFlag, QualifiedQty AS QualifiedQty, RefusedQty AS RefusedQty, ScrapQty AS ScrapQty, MoRoutingInspId AS MoRoutingInspId, Ufts AS Ufts , Define22 AS Define22, Define23 AS Define23, Define24 AS Define24, Define25 AS Define25, Define26 AS Define26, Define27 AS Define27, Define28 AS Define28, Define29 AS Define29, Define30 AS Define30, Define31 AS Define31, Define32 AS Define32, Define33 AS Define33, Define34 AS Define34, Define35 AS Define35, Define36 AS Define36, Define37 AS Define37 , ReportFlag AS ReportFlag, BFFlag AS BFFlag, FeeFlag AS FeeFlag, PlanSubFlag AS PlanSubFlag, AuxUnitCode AS AuxUnitCode, ChangeRate AS ChangeRate, DeliveryDays AS DeliveryDays, FirstFlag AS FirstFlag,SubQty,ReworkQty,ReworkedQty,PostReworkedQty,RdReworkedQty,PostScrapQty,RdScrapQty, StartTime, DueTime,CompleteQty,SplitFlag,ShiftQty as ShiftQty,ReportQty as ReportQty,cbSysBarCode as BarCode 
FROM @u8.sfc_moroutingdetail MoroutingDetail 
 WHERE MoDId = " + MoDId + " and MoRoutingDId='" + MoRoutingDId + "'  ORDER BY OpSeq";
            DataTable dtTemp = DbHelperSQL.Query(sSQL).Tables[0];
            if (dtTemp.Rows.Count == 0)
            {
                return 0;
            }
            else if (flag == "1")
            {
                return BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows[0]["BalMachiningQty"]);//加工量
            }
            else if (flag == "2")
            {
                return BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows[0]["BalDeclareQty"]);//检验
            }
            else if (flag == "3")
            {
                return BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows[0]["BalQualifiedQty"]);//合格
            }
            else if (flag == "4")
            {
                return BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows[0]["BalRefusedQty"]);//拒绝
            }
            else if (flag == "5")
            {
                return BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows[0]["BalScrapQty"]);//报废
            }
            return 0;
        }

        public string Get工序名称(string OpCode)
        {
            string sSQL = "select OpCode,Description,Define27 as 工作时间  from ufdata_100_2014.dbo.sfc_operation where OpCode='" + OpCode + "'";
            DataTable dtTemp = DbHelperSQL.Query(sSQL).Tables[0];
            if (dtTemp.Rows.Count > 0)
            {
                return dtTemp.Rows[0]["Description"].ToString();
            }
            return "";
        }

        public DataTable Get工序()
        {
            string sSQL = "select OpCode,Description,Define27 as 工作时间  from ufdata_100_2014.dbo.sfc_operation ";
            return DbHelperSQL.Query(sSQL).Tables[0];
        }

        public DataTable Get工序明细(string MoRoutingDId, string MoDId)
        {
            string sSQL = @"Select sfc_morouting.MoDId,sfc_moroutingdetail.MoRoutingDId,sfc_moroutingdetail.OpSeq as OpSeq,sfc_moroutingdetail.Description as Description,v_mom_orderdetail.Qty as Qty,v_bas_inventory.ComUnitName as ComUnitName,
sfc_moroutingdetail.DueDate as DueDate,sfc_moroutingdetail.StartDate as StartDate,sfc_workcenter.WcCode as WcCode,sfc_workcenter.Description as WcDescription,
sfc_moroutingdetail.SubFlag,sfc_moroutingdetail.Define34,sfc_moroutingdetail.Define35,sfc_moroutingdetail.FirstFlag,
BalQualifiedQty, BalRefusedQty, BalScrapQty, BalDeclareQty, BalMachiningQty,CompleteQty  ,OpCode ,convert(varchar(10),计划生产开工日期,120) as 计划生产开工日期, convert(varchar(10),计划生产完工日期,120) as  计划生产完工日期,v_mom_orderdetail.Qty-CompleteQty as 未完成数量
FROM @u8.sfc_morouting AS sfc_morouting
LEFT JOIN @u8.v_mom_orderdetail_all AS v_mom_orderdetail ON sfc_morouting.MoDId=v_mom_orderdetail.MoDId
LEFT JOIN @u8.bas_part AS MMPartEntity_bas_part ON v_mom_orderdetail.PartId=MMPartEntity_bas_part.PartId
LEFT JOIN @u8.v_bas_inventory AS v_bas_inventory ON MMPartEntity_bas_part.InvCode=v_bas_inventory.InvCode
LEFT JOIN @u8.sfc_moroutingdetail AS sfc_moroutingdetail ON sfc_morouting.MoRoutingId=sfc_moroutingdetail.MoRoutingId
LEFT JOIN @u8.sfc_workcenter AS sfc_workcenter ON sfc_moroutingdetail.WcId=sfc_workcenter.WcId
LEFT JOIN @u8.sfc_operation as sfc_operation on sfc_operation.OperationId =sfc_moroutingdetail.OperationId
left join 生产工序日计划 i on sfc_moroutingdetail.MoRoutingDId=i.生产订单工艺路线明细ID
WHERE 1=1    ORDER BY sfc_moroutingdetail.OpSeq";
            if (MoRoutingDId != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and sfc_moroutingdetail.MoRoutingDId='" + MoRoutingDId + "'");
            }
            if (MoDId != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and sfc_morouting.MoDId = " + MoDId + "");
            }
            return DbHelperSQL.Query(sSQL).Tables[0];
        }

        public int Get未转移工序(string MoDId)
        {
            string sSQL = @"Select sfc_moroutingdetail.MoRoutingDId,sfc_moroutingdetail.OpSeq as OpSeq,sfc_moroutingdetail.Description as Description,
v_mom_orderdetail.Qty as Qty,v_bas_inventory.ComUnitName as ComUnitName,
sfc_moroutingdetail.DueDate as DueDate,sfc_moroutingdetail.StartDate as StartDate,sfc_workcenter.WcCode as WcCode,sfc_workcenter.Description as WcDescription,
sfc_moroutingdetail.SubFlag,sfc_moroutingdetail.Define34,sfc_moroutingdetail.Define35,sfc_moroutingdetail.FirstFlag,
BalQualifiedQty, BalRefusedQty, BalScrapQty, BalDeclareQty, BalMachiningQty,CompleteQty     
FROM @u8.sfc_morouting AS sfc_morouting
LEFT JOIN @u8.v_mom_orderdetail_all AS v_mom_orderdetail ON sfc_morouting.MoDId=v_mom_orderdetail.MoDId
LEFT JOIN @u8.bas_part AS MMPartEntity_bas_part ON v_mom_orderdetail.PartId=MMPartEntity_bas_part.PartId
LEFT JOIN @u8.v_bas_inventory AS v_bas_inventory ON MMPartEntity_bas_part.InvCode=v_bas_inventory.InvCode
LEFT JOIN @u8.sfc_moroutingdetail AS sfc_moroutingdetail ON sfc_morouting.MoRoutingId=sfc_moroutingdetail.MoRoutingId
LEFT JOIN @u8.sfc_workcenter AS sfc_workcenter ON sfc_moroutingdetail.WcId=sfc_workcenter.WcId
WHERE 1=1   and v_mom_orderdetail.Qty-CompleteQty>0  ORDER BY sfc_moroutingdetail.MoRoutingDId";
            if (MoDId != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and sfc_morouting.MoDId = " + MoDId + "");
            }
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            return dt.Rows.Count;
        }

        public DataTable GetImport(string OpCode,string 炉号)
        {
            string sSQL = @"SELECT case when BalQualifiedQty>0 then a.MoRoutingDId+1 else MoRoutingDId end as InMoRoutingDId,
'1' as TransformType,a.MoRoutingDId AS MoRoutingDId, a.MoRoutingId AS MoRoutingId, a.MoId AS MoId, 
a.MoDId AS MoDId, OpSeq AS OpSeq, a.OperationId AS OperationId, a.Description AS Description, a.WcId AS WcId, StartDate AS StartDate, DueDate AS DueDate, a.SubFlag AS SubFlag, 
a.SVendorCode AS SVendorCode, LtRate AS LtRate,  
BalQualifiedQty AS BalQualifiedQty, BalRefusedQty AS BalRefusedQty, BalScrapQty AS BalScrapQty, BalDeclareQty AS BalDeclareQty, BalMachiningQty AS BalMachiningQty, LastFlag AS LastFlag, 
QualifiedQty, RefusedQty AS RefusedQty, ScrapQty AS ScrapQty, MoRoutingInspId AS MoRoutingInspId, a.Ufts AS Ufts ,   
a.ReportFlag AS ReportFlag, a.BFFlag AS BFFlag, a.FeeFlag AS FeeFlag, a.PlanSubFlag AS PlanSubFlag, 
a.DeliveryDays AS DeliveryDays, FirstFlag AS FirstFlag,SubQty,ReworkQty,ReworkedQty,PostReworkedQty,RdReworkedQty,PostScrapQty,RdScrapQty, 
StartTime, DueTime,CompleteQty,SplitFlag,ShiftQty as ShiftQty,ReportQty as ReportQty,a.cbSysBarCode as BarCode ,
1 as OpStatus,c.Qty-a.CompleteQty as TransOutQty ,0 as DeclareQty,0 as MachiningQty ,c.Qty as 订单数量,0 as QcFlag,0 as OutQcFlag ,null as Define9,
i.cInvCode,i.cInvName,i.cInvStd ,o.OpCode
FROM ufdata_100_2014.dbo.sfc_moroutingdetail a 
left join ufdata_100_2014.dbo.sfc_morouting c on a.MoRoutingId=c.MoRoutingId 
left join ufdata_100_2014.dbo.mom_orderdetail m on a.MoDId=m.MoDId 
left join ufdata_100_2014.dbo.mom_order mm on mm.MoId=m.MoId
left join ufdata_100_2014.dbo.Inventory i on m.InvCode=i.cInvCode
LEFT JOIN ufdata_100_2014.dbo.sfc_operation as o on o.OperationId =a.OperationId
where (a.BalDeclareQty>0 or a.BalMachiningQty>0 or a.BalQualifiedQty>0 or a.BalRefusedQty>0 or a.BalScrapQty>0) 
and (o.OpCode='" + OpCode + "') and a.MoRoutingId>'1000055991'  and isnull(m.Status,'')<>'4'"
      + @"      union all
SELECT case when BalQualifiedQty>0 then a.MoRoutingDId+1 else MoRoutingDId end as InMoRoutingDId,
'1' as TransformType,a.MoRoutingDId AS MoRoutingDId, a.MoRoutingId AS MoRoutingId, a.MoId AS MoId, 
a.MoDId AS MoDId, OpSeq AS OpSeq, a.OperationId AS OperationId, a.Description AS Description, a.WcId AS WcId, StartDate AS StartDate, DueDate AS DueDate, a.SubFlag AS SubFlag, 
a.SVendorCode AS SVendorCode, LtRate AS LtRate,  
BalQualifiedQty AS BalQualifiedQty, BalRefusedQty AS BalRefusedQty, BalScrapQty AS BalScrapQty, BalDeclareQty AS BalDeclareQty, BalMachiningQty AS BalMachiningQty, LastFlag AS LastFlag, 
QualifiedQty, RefusedQty AS RefusedQty, ScrapQty AS ScrapQty, MoRoutingInspId AS MoRoutingInspId, a.Ufts AS Ufts ,   
a.ReportFlag AS ReportFlag, a.BFFlag AS BFFlag, a.FeeFlag AS FeeFlag, a.PlanSubFlag AS PlanSubFlag, 
a.DeliveryDays AS DeliveryDays, FirstFlag AS FirstFlag,SubQty,ReworkQty,ReworkedQty,PostReworkedQty,RdReworkedQty,PostScrapQty,RdScrapQty, 
StartTime, DueTime,CompleteQty,SplitFlag,ShiftQty as ShiftQty,ReportQty as ReportQty,a.cbSysBarCode as BarCode ,
1 as OpStatus,c.Qty-a.CompleteQty as TransOutQty ,0 as DeclareQty,0 as MachiningQty ,c.Qty as 订单数量,0 as QcFlag,0 as OutQcFlag ,null as Define9,
i.cInvCode,i.cInvName,i.cInvStd ,o.OpCode
FROM ufdata_100_2014.dbo.sfc_moroutingdetail a 
left join ufdata_100_2014.dbo.sfc_morouting c on a.MoRoutingId=c.MoRoutingId 
left join ufdata_100_2014.dbo.mom_orderdetail m on a.MoDId=m.MoDId 
left join ufdata_100_2014.dbo.mom_order mm on mm.MoId=m.MoId
left join ufdata_100_2014.dbo.Inventory i on m.InvCode=i.cInvCode
LEFT JOIN ufdata_100_2014.dbo.sfc_operation as o on o.OperationId =a.OperationId 
left join (select InMoRoutingDId,MAX(TransformId ) as TransformId   from ufdata_100_2014.dbo.sfc_optransform group by InMoRoutingDId) t on a.MoRoutingDId=t.InMoRoutingDId
left join 工序转移单 g on t.TransformId=g.TransformId
where (a.BalDeclareQty>0 or a.BalMachiningQty>0 or a.BalQualifiedQty>0 or a.BalRefusedQty>0 or a.BalScrapQty>0) and g.炉号='" + 炉号 + "'  and isnull(m.Status,'')<>'4'";
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            //for (int i = dt.Rows.Count - 1; i >= 0; i--)
            //{
            //    try
            //    {
            //        string chk = GetCheck(dt, 0, i);
            //        if (chk != "")
            //        {
            //            dt.Rows.Remove(dt.Rows[i]);
            //            throw new Exception(chk);
            //        }

            //    }
            //    catch
            //    {
                    
            //    }
            //}
            return dt;
        }

        public DataTable Get工序转移()
        {
            string sSQL = @"select 
case when FirstFlag =0 then (select top 1 a.DocDate  from UFDATA_100_2014.dbo.sfc_optransform a where s.PevMoRoutingDId=a.MoRoutingDId  order by a.DocDate  desc)
when FirstFlag =1 then (select top 1 a.DocDate  from UFDATA_100_2014.dbo.sfc_optransform a where s.MoRoutingDId=a.InMoRoutingDId order by a.DocDate  desc)
end as 完工日期,* from (

Select mo.MoCode,mos.SortSeq,mos.MoLotCode,sfc_morouting.MoDId,sfc_moroutingdetail.MoRoutingId,sfc_moroutingdetail.MoRoutingDId,sfc_moroutingdetail.OpSeq as OpSeq,

(select top 1 MoRoutingDId from UFDATA_100_2014.dbo.sfc_moroutingdetail sfc 
where sfc_moroutingdetail.MoRoutingId=sfc.MoRoutingId and OpSeq<sfc_moroutingdetail.OpSeq order by OpSeq desc) as PevMoRoutingDId,

sfc_moroutingdetail.Description,OpCode,v_mom_orderdetail.Qty as Qty,v_bas_inventory.ComUnitName as ComUnitName,
sfc_moroutingdetail.DueDate as DueDate,sfc_moroutingdetail.StartDate as StartDate,convert(varchar(10),计划生产开工日期,120) as 计划生产开工日期, convert(varchar(10),计划生产完工日期,120) as  计划生产完工日期, 计划生产天数,
sfc_workcenter.WcCode as WcCode,sfc_workcenter.Description as WcDescription,
sfc_moroutingdetail.SubFlag,sfc_moroutingdetail.Define34,sfc_moroutingdetail.Define35,sfc_moroutingdetail.FirstFlag,sfc_moroutingdetail.LastFlag,
BalQualifiedQty, BalRefusedQty, BalScrapQty, BalDeclareQty ,
BalMachiningQty,CompleteQty  as 完成数量,v_mom_orderdetail.Qty-CompleteQty as 未完成数量 
FROM UFDATA_100_2014.dbo.sfc_morouting AS sfc_morouting
LEFT JOIN UFDATA_100_2014.dbo.v_mom_orderdetail_all AS v_mom_orderdetail ON sfc_morouting.MoDId=v_mom_orderdetail.MoDId
LEFT JOIN UFDATA_100_2014.dbo.bas_part AS MMPartEntity_bas_part ON v_mom_orderdetail.PartId=MMPartEntity_bas_part.PartId
LEFT JOIN UFDATA_100_2014.dbo.v_bas_inventory AS v_bas_inventory ON MMPartEntity_bas_part.InvCode=v_bas_inventory.InvCode
LEFT JOIN UFDATA_100_2014.dbo.sfc_moroutingdetail AS sfc_moroutingdetail ON sfc_morouting.MoRoutingId=sfc_moroutingdetail.MoRoutingId
LEFT JOIN UFDATA_100_2014.dbo.sfc_workcenter AS sfc_workcenter ON sfc_moroutingdetail.WcId=sfc_workcenter.WcId
LEFT JOIN UFDATA_100_2014.dbo.sfc_operation as sfc_operation on sfc_operation.OperationId =sfc_moroutingdetail.OperationId
left join UFDATA_100_2014.dbo.mom_orderdetail mos on sfc_morouting.MoDId=mos.MoDId 
left join UFDATA_100_2014.dbo.mom_order mo on mos.MoId=mo.MoId 
left join 生产工序日计划 i on sfc_moroutingdetail.MoRoutingDId=i.生产订单工艺路线明细ID 
) s";
            return DbHelperSQL.Query(sSQL).Tables[0];
        }
        #region 
        protected bool ReturnObjectToBool(object o)
        {
            bool b = false;
            try
            {
                if (o.ToString().ToLower() == "true")
                    return true;
            }
            catch
            { }
            try
            {
                if (ReturnObjectToInt(o) == 1)
                    return true;
            }
            catch
            { }
            try
            {
                if (Convert.ToBoolean(o))
                    return true;
            }
            catch
            { }

            return b;
        }

        protected int ReturnObjectToInt(object o)
        {
            int i = 0;
            try
            {
                i = Convert.ToInt32(o);
            }
            catch
            { }
            return i;
        }


        protected long ReturnObjectToLong(object o)
        {
            long i = 0;
            try
            {
                i = Convert.ToInt64(o);
            }
            catch
            { }
            return i;
        }

        protected decimal ReturnObjectToDecimal(object o, int i)
        {
            decimal d = 0;
            try
            {
                d = Convert.ToDecimal(o);
                d = decimal.Round(d, i);
            }
            catch
            { }
            return d;
        }

        protected DateTime ReturnObjectToDatetime(object o)
        {
            DateTime d = Convert.ToDateTime("1900-01-01");
            try
            {
                d = Convert.ToDateTime(o);
            }
            catch { }
            return d;
        }

        public static DataTable Group(DataTable dt, string[] ColumnName, string Sel)
        {
            DataRow[] dw = dt.Select(Sel);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            DataView dv = new DataView(dts);
            DataTable dtgroup = dv.ToTable(true, ColumnName);
            return dtgroup;
        }

        public static DataTable Select(DataTable dt, string Sel, string Order)
        {
            DataRow[] dw = dt.Select(Sel, Order);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            return dts;
        }
        #endregion
    }
}

