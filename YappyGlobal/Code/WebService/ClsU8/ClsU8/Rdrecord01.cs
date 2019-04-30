using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClsBaseClass;
using System.Data.SqlClient;

namespace ClsU8
{
    public class Rdrecord01
    {
        //ClsDataBase clsSQL = ClsDataBaseFactory.Instance();
        public string Add_Rdrecord01(SqlTransaction tran,DataTable dtData)
        {
            string s = "";
            try
            {
                string sErr = "";

                if (dtData == null || dtData.Rows.Count < 1)
                    throw new Exception("没有需要保存的数据");

                string sAccID = ClsBaseClass.ClsBaseDataInfo.sDataBaseName.Trim().Substring(7, 3);
                //ArrayList aList = new ArrayList();
                //SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                //conn.Open();
                ////启用事务
                //SqlTransaction tran = conn.BeginTransaction();

                #region 采购入库单

                string sIDs = "";
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if (sIDs == "")
                    {
                        sIDs = dtData.Rows[i]["ID"].ToString().Trim();
                    }
                    else
                    {
                        sIDs = sIDs + "," + dtData.Rows[i]["ID"].ToString().Trim();
                    }
                }

                string sSQL = @"

select distinct cVenCode,cexch_name,cPTCode ,cState 
from po_pomain a inner join PO_Podetails b on a.poid = b.poid
where isnull(cState,0) = 1 and b.id in ({0})

";
                sSQL = string.Format(sSQL, sIDs);
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || dtTemp.Rows.Count > 1)
                {
                    throw new Exception("单据不存在、未审核或存在互斥的扫描数据(供应商编码、币种、业务类型)");
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
                int iR = ClsBaseDataInfo.ReturnObjectToInt(dtTemp.Rows[0]["bflag_PU"]);
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
exec sp_GetId N'00',N'dddddd',N'rd',eeeeee,@p5 output,@p6 output,default
select @p5, @p6
                                                        ";
                sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                sSQL = sSQL.Replace("dddddd", sAccID);
                sSQL = sSQL.Replace("eeeeee", dtData.Rows.Count.ToString());
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                lID = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][0]);
                lIDDetails = ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][1]) - dtData.Rows.Count;

                ////获得单据号
                //long iRdCode = 0;
                //sSQL = "select * From VoucherHistory  with (ROWLOCK) Where  CardNumber='01' ";
                //DataTable dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                //if (dtID == null || dtID.Rows.Count < 1)
                //{
                //    iRdCode = 1;
                //}
                //else
                //{
                //    iRdCode = ClsBaseDataInfo.ReturnObjectToLong(dtID.Rows[0]["cNumber"]) + 1;
                //}
                //        sSQL = @"
                //IF EXISTS(select cNumber as Maxnumber From VoucherHistory  with (XLOCK) Where  CardNumber='27'  ) 
                //    update VoucherHistory set cNumber='222222' Where  CardNumber='27'  
                //else
                //    Insert into VoucherHistory(CardNumber,cNumber) values('27','222222')
                //";
                //        sSQL = sSQL.Replace("222222", iRdCode.ToString());
                //        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                long lCode = 0;
                sSQL = @"
select MAX(cCode) AS cCode from Rdrecord01 where cCode like 'RD{0}%'
";
                sSQL = string.Format(sSQL, dtmNow.ToString("yyyy"));
                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || dtTemp.Rows.Count == 0 || dtTemp.Rows[0][0].ToString().Trim() == "")
                {
                    lCode = 1;
                }
                else
                {
                    lCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0][0].ToString().Substring(10)) + 1;
                }

                string sCode = "RD" + dtmNow.ToString("yyyyMMdd") + lCode.ToString().PadLeft(4, '0');


                sSQL = @"

select a.* 
from po_pomain a inner join PO_Podetails b on a.poid = b.poid
where isnull(cState,0) = 1 and b.id in ({0})

";
                sSQL = string.Format(sSQL, dtData.Rows[0]["ID"].ToString().Trim());
                DataTable dtPOMain = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                string sWhCode = dtData.Rows[0]["cWhCode"].ToString().Trim();
                sSQL = @"SELECT * FROM warehouse WHERE CWHCODE = '{0}'";
                sSQL = string.Format(sSQL, sWhCode);
                DataTable dtWH = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtWH == null || dtWH.Rows.Count == 0)
                {
                    throw new Exception("仓库错误");
                }

                string sRdCode = dtData.Rows[0]["cRdCode"].ToString().Trim();
                sSQL = @"
select * from Rd_Style where brdflag = 1 and brdend = 1 and  crdcode = '{0}'
";
                sSQL = string.Format(sSQL, sRdCode);
                DataTable dtRD = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtRD == null || dtRD.Rows.Count == 0)
                {
                    throw new Exception("入库类别错误");
                }
                string sExchName = dtPOMain.Rows[0]["cexch_name"].ToString().Trim();

                Model.RdRecord01 model = new Model.RdRecord01();
                model.ID = lID;
                model.bRdFlag = 1;
                model.cVouchType = "01";
                model.cBusType = "普通采购";
                model.cSource = "采购订单";
                model.cWhCode = sWhCode;
                model.dDate = dtmToday;
                model.cCode = sCode;
                model.cRdCode = sRdCode;
                if (dtPOMain.Rows[0]["cDepCode"].ToString().Trim() != "")
                {
                    model.cDepCode = dtPOMain.Rows[0]["cDepCode"].ToString().Trim();
                }
                if (dtPOMain.Rows[0]["cPersonCode"].ToString().Trim() != "")
                {
                    model.cPersonCode = dtPOMain.Rows[0]["cPersonCode"].ToString().Trim();
                }
                if (dtPOMain.Rows[0]["cPTCode"].ToString().Trim() != "")
                {
                    model.cPTCode = dtPOMain.Rows[0]["cPTCode"].ToString().Trim();
                }

                model.cVenCode = dtPOMain.Rows[0]["cVenCode"].ToString().Trim();
                model.cOrderCode = dtPOMain.Rows[0]["cPOID"].ToString().Trim();
                model.bTransFlag = false;
                model.cMaker = dtData.Rows[0]["sUserName"].ToString().Trim();
                model.bpufirst = false;
                model.biafirst = false;
                model.VT_ID = 27;
                model.bIsSTQc = false;
                model.ipurorderid = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToLong(dtPOMain.Rows[0]["POID"]);
                model.iTaxRate = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtPOMain.Rows[0]["iTaxRate"]);
                model.iExchRate = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtPOMain.Rows[0]["nflat"]);
                model.cExch_Name = sExchName;

                model.bOMFirst = false;
                model.bFromPreYear = false;
                model.bIsComplement = 0;
                model.iDiscountTaxType = 0;
                model.ireturncount = 0;
                model.iverifystate = 0;
                model.iswfcontrolled = 0;
                model.dnmaketime = dtmNow;
                model.bredvouch = 0;
                model.iPrintCount = 0;
                model.csysbarcode = "||st01|" + model.cCode;

                DAL.RdRecord01 dal = new DAL.RdRecord01();
                sSQL = dal.Add(model);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                if (s == "")
                {
                    s = model.cCode;
                }
                else
                {
                    s = s + ";" + model.cCode;
                }

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    long lID_POs = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToLong(dtData.Rows[i]["ID"]);
                    string sInvCode = dtData.Rows[i]["cInvCode"].ToString().Trim();
                    decimal dQty = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["iQuantity"]);
                    decimal dNum = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["iNum"]);
                    string sBatch = dtData.Rows[i]["cBatch"].ToString().Trim();
                    string sWHCode2 = dtData.Rows[i]["cWhCode"].ToString().Trim();
                    string sRDCode2 = dtData.Rows[i]["cRdCode"].ToString().Trim();
                    string sExchName2 = dtPOMain.Rows[0]["cexch_name"].ToString().Trim();

                    if (sWhCode != sWHCode2)
                    {
                        throw new Exception("不同仓库请分单入库");
                    }
                    if (sRdCode != sRDCode2)
                    {
                        throw new Exception("不同入库类别请分单入库");
                    }
                    if (sExchName != sExchName2)
                    {
                        throw new Exception("不同币别请分单入库");
                    }

                    sSQL = @"
select b.*,a.cPOID,inv.bInvBatch,inv.cPUComUnitCode
from po_pomain a inner join PO_Podetails b on a.poid = b.poid
    inner join Vendor v on a.cVenCode = v.cVenCode
    inner join Inventory inv on b.cInvCode = inv.cInvCode
where b.ID = {0}
";
                    sSQL = string.Format(sSQL, lID_POs);
                    DataTable dtPODetails = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtPODetails == null || dtPODetails.Rows.Count != 1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }

                    if (sInvCode.ToLower() != dtPODetails.Rows[0]["cInvCode"].ToString().Trim().ToLower())
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "物料编码不匹配\n";
                        continue;
                    }

                    if (ClsBaseDataInfo.ReturnObjectToBool(dtPODetails.Rows[0]["bInvBatch"]) && sBatch == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "批号不匹配\n";
                        continue;
                    }

                    decimal dPOQty = ClsBaseDataInfo.ReturnObjectToDecimal(dtPODetails.Rows[0]["iQuantity"]);
                    decimal dPONum = ClsBaseDataInfo.ReturnObjectToDecimal(dtPODetails.Rows[0]["iNum"]);
                    decimal iReceivedQTY = ClsBaseDataInfo.ReturnObjectToDecimal(dtPODetails.Rows[0]["iReceivedQTY"]);
                    if (dQty <= 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "入库数量必须是正数\n";
                        continue;
                    }

                    if (dPOQty < iReceivedQTY + dQty)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "超订单入库\n";
                        continue;
                    }

                    lIDDetails = lIDDetails + 1;

                    Model.rdrecords01 models = new ClsU8.Model.rdrecords01();

                    models.AutoID = lIDDetails;
                    models.ID = lID;
                    models.cInvCode = dtData.Rows[i]["cInvCode"].ToString().Trim();
                    models.iQuantity = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["iQuantity"]);

                    if (dPONum != 0)
                    {
                        models.iinvexchrate = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dPOQty / dPONum, 6);
                        models.iNum = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(models.iQuantity / models.iinvexchrate, 6);
                    }
                    
                    models.iUnitCost = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtPODetails.Rows[0]["iUnitPrice"]);
                    models.iPrice = models.iUnitCost * models.iQuantity;
                    models.iAPrice = models.iUnitCost * models.iQuantity;
                    models.iMoney = 0;
                    models.fACost = models.iUnitCost;
                    models.iOriTaxCost = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtPODetails.Rows[0]["iTaxPrice"]);
                    models.iOriCost = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtPODetails.Rows[0]["iUnitPrice"]);
                    models.iOriMoney = models.iOriCost * models.iQuantity;
                    models.iOriTaxPrice = models.iOriTaxCost * models.iQuantity - models.iOriCost * models.iQuantity;
                    models.ioriSum = models.iOriTaxCost * models.iQuantity;
                    models.iTaxRate= ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtPODetails.Rows[0]["iPerTaxRate"]);
                    models.iSum = models.iUnitCost * models.iQuantity;
                    models.iTaxPrice = models.iOriTaxCost * models.iQuantity - models.iOriCost * models.iQuantity;


                    if (dtData.Rows[i]["cBatch"].ToString().Trim() != "")
                    {
                        models.cBatch = dtData.Rows[i]["cBatch"].ToString().Trim();
                    }
                    models.iFlag = 0;
                    models.iSQuantity = 0;
                    models.iSNum = 0;

                    models.iSQuantity = 0;
                    models.iSNum = 0;
                    models.iPOsID = lID_POs;
                    models.iNQuantity= ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtPODetails.Rows[0]["iQuantity"]);
                    models.iNNum = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtPODetails.Rows[0]["iNum"]);
                    models.cAssUnit = dtPODetails.Rows[0]["cPUComUnitCode"].ToString().Trim();
                    models.chVencode = model.cVenCode;
                    models.bTaxCost = true;
                    models.cPOID = dtPOMain.Rows[0]["cPOID"].ToString().Trim();
                    models.iMatSettleState = 0;
                    models.iBillSettleCount = 0;
                    models.bLPUseFree = false;
                    models.iOriTrackID = 0;
                    models.bCosting = true;
                    //models.iinvexchrate
                    //models.corufts
                    models.iExpiratDateCalcu = 0;
                    models.iordertype = 0;
                    models.isotype = 0;
                    models.irowno = i + 1;
                    models.cbsysbarcode = model.csysbarcode + "|" + models.irowno.ToString();
                    models.bgift = 0;


                    DAL.rdrecords01 dals = new ClsU8.DAL.rdrecords01();
                    sSQL = dals.Add(models);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //回写采购订单
                    sSQL = @"
update PO_Podetails set iReceivedQTY  = isnull(iReceivedQTY ,0) + {0},iReceivedNum   = isnull(iReceivedNum ,0) + {1}
where ID = {2}
";
                    sSQL = string.Format(sSQL, models.iQuantity, models.iNum, lID_POs);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //刷新现存量
                    sSQL = @"
select isnull(cValue,0) as cValue from AccInformation where cSysId =N'ST' and  cName= N'bPurchaseInCheck'
";
                    bool bUpdateCurr = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToBool(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                    if (!bUpdateCurr)
                    {
                        sSQL = @"
if exists
    (select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'
        and isnull(cFree1,'') = @cFree1 
        and isnull(cFree2,'') = @cFree2
        and isnull(cFree3,'') = @cFree3
        and isnull(cFree4,'') = @cFree4
        and isnull(cFree5,'') = @cFree5
        and isnull(cFree6,'') = @cFree6
        and isnull(cFree7,'') = @cFree7
        and isnull(cFree8,'') = @cFree8
        and isnull(cFree9,'') = @cFree9
        and isnull(cFree10,'') = @cFree10
        and isnull(cBatch,'') = @cBatch 
    )
  	update  CurrentStock set iQuantity = isnull(iQuantity,0) + @iQuantity  
    where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' 
        and isnull(cFree1,'') = @cFree1 
        and isnull(cFree2,'') = @cFree2
        and isnull(cFree3,'') = @cFree3
        and isnull(cFree4,'') = @cFree4
        and isnull(cFree5,'') = @cFree5
        and isnull(cFree6,'') = @cFree6
        and isnull(cFree7,'') = @cFree7
        and isnull(cFree8,'') = @cFree8
        and isnull(cFree9,'') = @cFree9
        and isnull(cFree10,'') = @cFree10
        and isnull(cBatch,'') = @cBatch 
else 
    begin 
        declare @itemid varchar(20); 
        declare @iCount int;  
        select @iCount=count(itemid) from CurrentStock where cInvCode = '@cInvCode';
        if( @iCount > 0 )
	        select @itemid=itemid from CurrentStock where cInvCode = '@cInvCode';
        else  
            select @itemid=max(itemid+1) from CurrentStock  
            insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid, cFree1, cFree2, cFree3, cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10,cBatch,iSoDid)
            values('@cWhCode','@cInvCode', @iQuantity,isnull(@itemid,1), @cFree1, @cFree2, @cFree3, @cFree4, @cFree5, @cFree6, @cFree7, @cFree8, @cFree9, @cFree10,@cBatch,'') 
    end
";
                        sSQL = sSQL.Replace("@cInvCode", models.cInvCode);
                        sSQL = sSQL.Replace("@cWhCode", model.cWhCode);
                        sSQL = sSQL.Replace("@iQuantity", models.iQuantity.ToString());
                        sSQL = sSQL.Replace("@iNum", models.iNum.ToString());
                        sSQL = sSQL.Replace("@cFree10", models.cFree10 == null ? "''" : "'" + models.cFree10 + "'");
                        sSQL = sSQL.Replace("@cFree1", models.cFree1 == null ? "''" : "'" + models.cFree1 + "'");
                        sSQL = sSQL.Replace("@cFree2", models.cFree2 == null ? "''" : "'" + models.cFree2 + "'");
                        sSQL = sSQL.Replace("@cFree3", models.cFree3 == null ? "''" : "'" + models.cFree3 + "'");
                        sSQL = sSQL.Replace("@cFree4", models.cFree4 == null ? "''" : "'" + models.cFree4 + "'");
                        sSQL = sSQL.Replace("@cFree5", models.cFree5 == null ? "''" : "'" + models.cFree5 + "'");
                        sSQL = sSQL.Replace("@cFree6", models.cFree6 == null ? "''" : "'" + models.cFree6 + "'");
                        sSQL = sSQL.Replace("@cFree7", models.cFree7 == null ? "''" : "'" + models.cFree7 + "'");
                        sSQL = sSQL.Replace("@cFree8", models.cFree8 == null ? "''" : "'" + models.cFree8 + "'");
                        sSQL = sSQL.Replace("@cFree9", models.cFree9 == null ? "''" : "'" + models.cFree9 + "'");
                        sSQL = sSQL.Replace("@cBatch", models.cBatch == null ? "''" : "'" + models.cBatch + "'");
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }

                sSQL = @"
exec ST_SaveForStock N'01',N'aaaaaa',1,0 ,1
";
                sSQL = sSQL.Replace("aaaaaa", model.ID.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
exec ST_SaveForTrackStock N'01',N'aaaaaa', 0 ,1
";
                sSQL = sSQL.Replace("aaaaaa", model.ID.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
exec IA_SP_WriteUnAccountVouchForST 'aaaaaa',N'01'
";
                sSQL = sSQL.Replace("aaaaaa", model.ID.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


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

