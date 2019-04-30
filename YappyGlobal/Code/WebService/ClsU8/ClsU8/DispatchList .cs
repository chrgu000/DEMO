using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClsBaseClass;
using System.Data.SqlClient;

namespace ClsU8
{
    public class DispatchList
    {
        //ClsDataBase clsSQL = ClsDataBaseFactory.Instance();
        public string Add_DispatchList(SqlTransaction tran,DataTable dtData)
        {
            string s = "";
            try
            {
                string sErr = "";

                if (dtData == null || dtData.Rows.Count < 1)
                    throw new Exception("没有需要保存的数据");

                string sAccID = ClsBaseClass.ClsBaseDataInfo.sDataBaseName.Trim().Substring(7, 3);

                #region 发货单

                string sIDs = "";
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if (sIDs == "")
                    {

                        sIDs = dtData.Rows[i]["iSOsID"].ToString().Trim();
                    }
                    else
                    {
                        sIDs = sIDs + "," + dtData.Rows[i]["iSOsID"].ToString().Trim();
                    }
                }

                string sSQL = @"
select distinct cCusCode,cexch_name,cBusType
from SO_SOMain a inner join SO_SODetails b on a.id = b.id
where b.isosid in ({0})
";
                sSQL = string.Format(sSQL, sIDs);
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || dtTemp.Rows.Count > 1)
                {
                    throw new Exception("单据不存在或存在互斥的扫描数据(客户编码、币种、业务类型)");
                }

                sSQL = "select getdate()";
                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                DateTime dtmNow = ClsBaseDataInfo.RetrunObjectToDateTime(dtTemp.Rows[0][0]);
                DateTime dtmToday = ClsBaseDataInfo.RetrunObjectToDateTime(dtmNow.ToString("yyyy-MM-dd"));

                //1.   判断是否结账
                sSQL = "select * from gl_mend where iperiod=month('" + dtmNow + "') and iyear = year('" + dtmNow + "')";
                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || dtTemp.Rows.Count < 1)
                {
                    throw new Exception("加载模块结账信息失败");
                }
                int iR = ClsBaseDataInfo.ReturnObjectToInt(dtTemp.Rows[0]["bflag_SA"]);
                if (iR == 1)
                {
                    throw new Exception(DateTime.Parse(dtData.Rows[0]["单据日期"].ToString()).Month + "月已经结账");
                }

                long lID = -1;
                long lIDDetails = -1;
                sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'DISPATCH',eeeeee,@p5 output,@p6 output,default
select @p5, @p6
                                                        ";
                sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                sSQL = sSQL.Replace("dddddd", sAccID);
                sSQL = sSQL.Replace("eeeeee", dtData.Rows.Count.ToString());
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                lID = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][0]);
                lIDDetails = ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][1]) - dtData.Rows.Count;

                long lCode = 0;
                sSQL = @"
select MAX(cDLCode) AS cCode from DispatchList where cDLCode like 'DP{0}%'
";
                sSQL = string.Format(sSQL, dtmNow.ToString("yyyyMM"));
                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || dtTemp.Rows.Count == 0 || dtTemp.Rows[0][0].ToString().Trim() == "")
                {
                    lCode = 1;
                }
                else
                {
                    lCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0][0].ToString().Substring(8)) + 1;
                }

                string sCode = "DP" + dtmNow.ToString("yyyyMM") + lCode.ToString().PadLeft(4, '0');


                sSQL = @"
select a.*
from SO_SOMain a inner join SO_SODetails b on a.id = b.id
    inner join Customer cus on a.cCusCode = cus.cCusCode
    inner join Inventory inv on b.cInvCode = inv.cInvCode
where b.isosid in ({0})
";
                sSQL = string.Format(sSQL, dtData.Rows[0]["iSOsID"].ToString().Trim());
                DataTable dtSOMain = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                Model.DispatchList model = new Model.DispatchList();
                model.DLID = lID;
                model.cDLCode = sCode;
                model.cVouchType = "05";
                model.cSTCode = "01";
                model.dDate = dtmToday;
                model.cDepCode = dtSOMain.Rows[0]["cDepCode"].ToString().Trim();
                model.cPersonCode = dtSOMain.Rows[0]["cPersonCode"].ToString().Trim();
                //model.SBVID 
                //model.cSBVCode 
                model.cSOCode = dtSOMain.Rows[0]["cSOCode"].ToString().Trim();
                model.cCusCode = dtSOMain.Rows[0]["cCusCode"].ToString().Trim();

                if (dtSOMain.Rows[0]["cSCCode"].ToString().Trim() != "")
                {
                    model.cSCCode = dtSOMain.Rows[0]["cSCCode"].ToString().Trim();
                }
                model.cShipAddress = dtSOMain.Rows[0]["cCusOAddress"].ToString().Trim();
                model.cexch_name = dtSOMain.Rows[0]["cexch_name"].ToString().Trim();
                model.iExchRate = ClsBaseDataInfo.ReturnObjectToDecimal(dtSOMain.Rows[0]["iExchRate"]);
                model.iTaxRate = ClsBaseDataInfo.ReturnObjectToDecimal(dtSOMain.Rows[0]["iTaxRate"]);
                model.bFirst = false;
                model.bReturnFlag = false;
                model.bSettleAll = false;
                model.cMaker = dtData.Rows[0]["sUserName"].ToString().Trim();
                model.iSale = 0;
                model.cCusName = dtSOMain.Rows[0]["cCusName"].ToString().Trim();
                model.iVTid = 30773;
                model.cBusType = dtSOMain.Rows[0]["cBusType"].ToString().Trim();
                model.bIAFirst = false;
                model.bCredit = false;
                model.iswfcontrolled = 0;
                model.bARFirst = false;
                model.dcreatesystime = dtmNow;
                model.iflowid = 0;
                model.bsigncreate = false;
                model.bcashsale = false;
                model.bmustbook = false;
                model.bneedbill = true;
                model.baccswitchflag = false;
                model.bsaleoutcreatebill = false;
                model.cSysBarCode = "||SA01|" + model.cDLCode;
                model.cinvoicecompany = model.cCusCode;
                model.bNotToGoldTax = 0;

                DAL.DispatchList dal = new DAL.DispatchList();
                sSQL = dal.Add(model);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                if (s == "")
                {
                    s = model.cDLCode;
                }
                else
                {
                    s = s + ";" + model.cDLCode;
                }

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    long lSOsID = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToLong(dtData.Rows[i]["iSOsID"]);
                    string sInvCode = dtData.Rows[i]["cInvCode"].ToString().Trim();
                    decimal dQty = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["iQuantity"]);
                    decimal dNum = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["iNum"]);
                    string sBatch = dtData.Rows[i]["cBatch"].ToString().Trim();
                    

                    sSQL = @"
select b.*,a.csocode,inv.bInvBatch ,inv.cGroupCode,inv.cComUnitCode,inv.cSAComUnitCode
from SO_SOMain a inner join SO_SODetails b on a.id = b.id
    inner join Customer cus on a.cCusCode = cus.cCusCode
    inner join Inventory inv on b.cInvCode = inv.cInvCode
where b.isosid = ({0})
";
                    sSQL = string.Format(sSQL, lSOsID);
                    DataTable dtSODetails = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtSODetails == null || dtSODetails.Rows.Count != 1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }

                    if (sInvCode.ToLower() != dtSODetails.Rows[0]["cInvCode"].ToString().Trim().ToLower())
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "产品编码不匹配\n";
                        continue;
                    }

                    if (ClsBaseDataInfo.ReturnObjectToBool(dtSODetails.Rows[0]["bInvBatch"]) && dNum == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "产品件数不匹配\n";
                        continue;
                    }

                    decimal dSOQty = ClsBaseDataInfo.ReturnObjectToDecimal(dtSODetails.Rows[0]["iQuantity"]);
                    decimal iFHQuantity = ClsBaseDataInfo.ReturnObjectToDecimal(dtSODetails.Rows[0]["iFHQuantity"]);

                    if (dQty <= 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "发货数量必须是正数\n";
                        continue;
                    }
                    
                    if (dSOQty < iFHQuantity + dQty)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "超订单发货\n";
                        continue;
                    }

                    string cGroupCode = dtSODetails.Rows[0]["cGroupCode"].ToString().Trim();
                    string cComunitCode = dtSODetails.Rows[0]["cComUnitCode"].ToString().Trim();
                    string cSAComUnitCode = dtSODetails.Rows[0]["cSAComUnitCode"].ToString().Trim();
                    decimal dChangRate = 0;
                    
                    if (cComunitCode != cSAComUnitCode)
                    {
                        sSQL = @"
select * from ComputationUnit where cGroupCode  = '{0}' and ccomunitcode = '{1}'
";
                        sSQL = string.Format(sSQL, cGroupCode, cComunitCode);
                        dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        decimal dComunitCode = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtTemp.Rows[0]["iChangRate"]);

                        sSQL = @"
select * from ComputationUnit where cGroupCode  = '{0}' and ccomunitcode = '{1}'
";
                        sSQL = string.Format(sSQL, cGroupCode, cSAComUnitCode);
                        dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        decimal dcSAComUnitCode = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtTemp.Rows[0]["iChangRate"]);

                        dChangRate = dComunitCode * dcSAComUnitCode;

                        dNum = dQty * dChangRate;
                    }

                    lIDDetails = lIDDetails + 1;

                    Model.DispatchLists models = new ClsU8.Model.DispatchLists();
                    models.DLID = model.DLID;
                    models.AutoID = lIDDetails;
                    models.iCorID = 0;
                    models.cWhCode = dtData.Rows[i]["cWhCode"].ToString().Trim();
                    models.cInvCode = sInvCode;
                    models.iQuantity = dQty;
                    if (dNum != 0)
                    {
                        models.iNum = dNum;
                        models.iInvExchRate = dChangRate;
                        models.cUnitID = cSAComUnitCode;
                    }
                    models.iQuotedPrice = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtSODetails.Rows[0]["iQuotedPrice"]);
                    models.iUnitPrice = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtSODetails.Rows[0]["iUnitPrice"]);
                    models.iTaxUnitPrice = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtSODetails.Rows[0]["iTaxUnitPrice"]);
                    models.iMoney = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(models.iUnitPrice * dQty, 2);
                    models.iSum = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(models.iTaxUnitPrice * dQty, 2);
                    models.iTax = models.iSum - models.iMoney;

                    models.iDisCount = 0;
                    models.iNatUnitPrice = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtSODetails.Rows[0]["iNatUnitPrice"]);
                    models.iNatMoney = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(models.iNatUnitPrice * dQty, 2);

                    models.iNatSum = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(models.iNatMoney * (1 + model.iExchRate / 100), 2);
                    models.iNatTax = models.iNatSum - models.iNatMoney;

                    models.iNatDisCount = 0;

                    models.iSettleNum = 0;
                    models.iSettleQuantity = 0;

                    if (sBatch != "")
                    {
                        //models.iBatch = sBatch;
                        models.cBatch = sBatch;
                    }

                    models.bSettleAll = false;
                    models.iTB = 0;
                    models.TBQuantity = 0;
                    models.TBNum = 0;
                    models.iSOsID = lSOsID;
                    models.iDLsID = lIDDetails;
                    models.KL = 100;
                    models.KL2 = 100;
                    models.iTaxRate = ClsBaseDataInfo.ReturnObjectToDecimal(dtSODetails.Rows[0]["iTaxRate"]);
                    models.fOutQuantity = 0;
                    models.fOutNum = 0;
                    models.fSaleCost = 0;
                    models.fSalePrice = 0;
                    models.bIsSTQc = false;
                    models.fEnSettleQuan = 0;
                    models.fEnSettleSum = 0;
                    models.bGsp = false;
                    models.cSoCode = dtSODetails.Rows[0]["cSoCode"].ToString().Trim();
                    models.cMassUnit = 0;
                    models.bQANeedCheck = false;
                    models.bQAUrgency = false;
                    models.bQAChecked = false;
                    models.bQAChecking = false;
                    models.fsumsignquantity = 0;
                    models.fsumsignnum = 0;
                    models.bcosting = true;
                    models.cordercode = dtSODetails.Rows[0]["cSoCode"].ToString().Trim();
                    models.iorderrowno = ClsBaseDataInfo.ReturnObjectToInt(dtSODetails.Rows[0]["iRowNo"]);
                    models.fcusminprice = 0;
                    models.iExpiratDateCalcu = 0;
                    models.bneedsign = false;
                    models.bsaleprice = false;
                    models.bmpforderclosed = false;
                    models.irowno = i + 1;
                    models.cbSysBarCode = model.cSysBarCode + "|" + models.irowno.ToString();
                    models.bIAcreatebill = false;

                    DAL.DispatchLists dals = new ClsU8.DAL.DispatchLists();
                    sSQL = dals.Add(models);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
update SO_SODetails 
    set iFHNum = isnull(iFHNum,0)  + {1}
        ,iFHQuantity  = isnull(iFHQuantity,0)  + {2}
        ,iFHMoney  = isnull(iFHMoney,0)  + {3} 
where iSOsID = {0}
";
                    sSQL = string.Format(sSQL, lSOsID, models.iNum, models.iQuantity, models.iMoney);      //累计原币金额是否含税？
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //回写销售订单状态，（单据非一次发完，或多张订单发货怎么办？）
                    sSQL = @"
update so_somain set cDefine5 = 10
where id in (select id from SO_SODetails where iSOsID = {0})
";
                    sSQL = string.Format(sSQL, lSOsID);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                }

                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                //tran.Commit();
                s = "生成单据号：" + s;
                //}
                //catch (Exception error)
                //{
                //    tran.Rollback();
                //    throw new Exception(error.Message);
                //}
                #endregion
            }
            catch (Exception ee)
            {
                s = "Err:" + ee.Message;
            }
            return s;
        }
    }
}

