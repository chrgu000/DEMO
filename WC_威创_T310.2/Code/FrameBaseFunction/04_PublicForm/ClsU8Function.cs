using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace FrameBaseFunction
{
    public class ClsU8Function
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = new FrameBaseFunction.ClsGetSQL();

        /// <summary>
        /// 获得单据ID
        /// </summary>
        /// <param name="sType">单据类型  PuArrival，</param>
        public void GetID(string sType, out long iID, out long iIDDetail)
        {
            string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity with (nolock) where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = '" + sType + "'";
            DataTable dt = clsSQL.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count < 1)
            {
                iID = 0;
                iIDDetail = 0;
            }
            else
            {
                iID = Convert.ToInt64(dt.Rows[0]["iFatherID"]);
                iIDDetail = Convert.ToInt64(dt.Rows[0]["iChildID"]);
            }
        }

        /// <summary>
        /// 返回其它出库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private string sSetRDOutCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "OO" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + sCode;
        }

        /// <summary>
        /// 返回其它入库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private string sSetRDInCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "IO" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + sCode;
        }

        #region 根据调拨单产生其他出库，其他入库单
        public ArrayList GenInvChangeRD(DataTable dtHead, DataTable dtDetail, long iID, long iIDDetail, out long iID2, out long iIDDetail2, long iInCode, out long iInCode2,long iOutCode,out long iOutCode2)
        {
            string sSQL = "select * from @u8.rdrecord where 1=-1";
            DataTable dtRdrecord = clsSQL.ExecQuery(sSQL);
            sSQL = "select * from @u8.rdrecords where 1=-1";
            DataTable dtRdrecords = clsSQL.ExecQuery(sSQL);

            ArrayList aList = new ArrayList();

            #region     其他入库单表头
            iInCode += 1;
            string sRDInCode = sSetRDInCode(iInCode);
            iID += 1;
            DataRow drRd = dtRdrecord.NewRow();
            drRd["ID"] = iID;
            drRd["bRdFlag"] = 1;
            drRd["cVouchType"] = "08";
            drRd["cBusType"] = "调拨入库";
            drRd["cSource"] = "调拨";
            drRd["cBusCode"] = dtHead.Rows[0]["cTVCode"];
            drRd["cWhCode"] = dtHead.Rows[0]["cIWhCode"];
            drRd["dDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            drRd["cCode"] = sRDInCode;
            drRd["cRdCode"] = "113";
            drRd["cDepCode"] = dtHead.Rows[0]["cIDepCode"];
            drRd["cPersonCode"] = dtHead.Rows[0]["cPersonCode"];
            drRd["cPTCode"] = DBNull.Value;
            drRd["cSTCode"] = DBNull.Value;
            drRd["cCusCode"] = DBNull.Value;
            drRd["cVenCode"] = DBNull.Value;
            drRd["cOrderCode"] = DBNull.Value;
            drRd["cARVCode"] = DBNull.Value;
            drRd["cBillCode"] = DBNull.Value;
            drRd["cDLCode"] = DBNull.Value;
            drRd["cProBatch"] = DBNull.Value;
            drRd["cHandler"] = DBNull.Value;
            drRd["cMemo"] = DBNull.Value;
            drRd["bTransFlag"] = 0;
            drRd["cAccounter"] = DBNull.Value;
            drRd["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
            drRd["iNetLock"] = DBNull.Value;
            drRd["cDefine1"] = DBNull.Value;
            drRd["cDefine2"] = DBNull.Value;
            drRd["cDefine3"] = DBNull.Value;
            drRd["cDefine4"] = DBNull.Value;
            drRd["cDefine5"] = DBNull.Value;
            drRd["cDefine6"] = DBNull.Value;
            drRd["cDefine7"] = DBNull.Value;
            drRd["cDefine8"] = DBNull.Value;
            drRd["cDefine9"] = DBNull.Value;
            drRd["cDefine10"] = DBNull.Value;
            drRd["dKeepDate"] = DBNull.Value;
            drRd["dVeriDate"] = DBNull.Value;
            drRd["bpufirst"] = false;
            drRd["biafirst"] = false;
            drRd["iMQuantity"] = dtHead.Rows[0]["iQuantity"];
            drRd["dARVDate"] = DBNull.Value;
            drRd["cChkCode"] = DBNull.Value;
            drRd["dChkDate"] = DBNull.Value;
            drRd["cChkPerson"] = DBNull.Value;
            drRd["VT_ID"] = "67";
            drRd["bIsSTQc"] = false;
            drRd["cDefine11"] = DBNull.Value;
            drRd["cDefine12"] = DBNull.Value;
            drRd["cDefine13"] = DBNull.Value;
            drRd["cDefine14"] = DBNull.Value;
            drRd["cDefine15"] = DBNull.Value;
            drRd["cDefine16"] = DBNull.Value;
            drRd["cPsPcode"] = dtHead.Rows[0]["cPSPCode"];
            drRd["cMPoCode"] = dtHead.Rows[0]["cMPoCode"];
            drRd["gspcheck"] = DBNull.Value;
            drRd["ipurorderid"] = DBNull.Value;
            drRd["ipurarriveid"] = DBNull.Value;
            drRd["iproorderid"] = DBNull.Value;
            drRd["iarriveid"] = DBNull.Value;
            drRd["isalebillid"] = DBNull.Value;
            //drRd["ufts"] = "0x00000000679E3997";
            drRd["iTaxRate"] = DBNull.Value;
            drRd["iExchRate"] = DBNull.Value;
            drRd["cExch_Name"] = DBNull.Value;
            drRd["cShipAddress"] = DBNull.Value;
            drRd["bOMFirst"] = false;
            drRd["bFromPreYear"] = false;
            drRd["bIsLsQuery"] = DBNull.Value;
            drRd["bIsComplement"] = DBNull.Value;
            drRd["iDiscountTaxType"] = DBNull.Value;
            drRd["iBG_OverFlag"] = DBNull.Value;
            drRd["cBG_Auditor"] = DBNull.Value;
            drRd["cBG_AuditTime"] = DBNull.Value;
            drRd["ControlResult"] = DBNull.Value;
            drRd["caddcode"] = DBNull.Value;
            drRd["ireturncount"] = DBNull.Value;
            drRd["iverifystate"] = DBNull.Value;
            drRd["iswfcontrolled"] = false;
            drRd["cModifyPerson"] = DBNull.Value;
            drRd["dModifyDate"] = DBNull.Value;
            drRd["dnmaketime"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            drRd["dnmodifytime"] = DBNull.Value;
            drRd["dnverifytime"] = DBNull.Value;
            drRd["bredvouch"] = false;
            drRd["bmotran"] = DBNull.Value;
            drRd["cVenPUOMProtocol"] = DBNull.Value;
            drRd["dCreditStart"] = DBNull.Value;
            drRd["iCreditPeriod"] = DBNull.Value;
            drRd["dGatheringDate"] = DBNull.Value;
            drRd["bCredit"] = DBNull.Value;
            dtRdrecord.Rows.Add(drRd);
            aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "RdRecord", dtRdrecord, 0));

            //更改最大入库单据号
            sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where CardNumber='0301' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            DataTable dtCodeTemp = clsSQL.ExecQuery(sSQL);
            if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
            {
                sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0301','日期','月','" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                aList.Add(sSQL);
            }
            else
            {
                sSQL = "update @u8.VoucherHistory set cNumber = '" + iInCode.ToString().Trim() + "' Where CardNumber='0301' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                aList.Add(sSQL);
            }
            iInCode2 = iInCode;
            #endregion

            #region 其他入库单表体
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                iIDDetail += 1;
                DataRow drRds = dtRdrecords.NewRow();
                drRds["AutoID"] = iIDDetail;
                drRds["ID"] = iID;
                drRds["cInvCode"] = dtDetail.Rows[i]["cInvCode"];
                drRds["iNum"] = dtDetail.Rows[i]["iTVNum"];
                drRds["iQuantity"] = dtDetail.Rows[i]["iTVQuantity"];
                drRds["iUnitCost"] = DBNull.Value;
                drRds["iPrice"] = DBNull.Value;
                drRds["iAPrice"] = DBNull.Value;
                drRds["iPUnitCost"] = DBNull.Value;
                drRds["iPPrice"] = DBNull.Value;
                drRds["cBatch"] = DBNull.Value;
                drRds["cObjCode"] = DBNull.Value;
                drRds["cVouchCode"] = DBNull.Value;
                drRds["cFree1"] = DBNull.Value;
                drRds["cFree2"] = DBNull.Value;
                drRds["iFlag"] = false;
                drRds["dSDate"] = DBNull.Value;
                drRds["iTax"] = "0";
                drRds["iSQuantity"] = 0;
                drRds["iSNum"] = 0;
                drRds["iMoney"] = 0;
                drRds["iSOutQuantity"] = 0;
                drRds["iSOutNum"] = 0;
                drRds["iFNum"] = 0;
                drRds["iFQuantity"] = 0;
                drRds["dVDate"] = DBNull.Value;
                drRds["iTrIds"] = dtDetail.Rows[i]["autoID"];
                drRds["cPosition"] = DBNull.Value;
                drRds["cDefine22"] = DBNull.Value;
                drRds["cDefine23"] = DBNull.Value;
                drRds["cDefine24"] = DBNull.Value;
                drRds["cDefine25"] = DBNull.Value;
                drRds["cDefine26"] = DBNull.Value;
                drRds["cDefine27"] = DBNull.Value;
                drRds["cItem_class"] = dtDetail.Rows[i]["cItem_class"];
                drRds["cItemCode"] = dtDetail.Rows[i]["cItemCode"];
                drRds["iPOsID"] = DBNull.Value;
                drRds["fACost"] = DBNull.Value;
                drRds["iDLsID"] = DBNull.Value;
                drRds["iSBsID"] = DBNull.Value;
                drRds["iSendQuantity"] = 0;
                drRds["iSendNum"] = 0;
                drRds["cName"] = dtDetail.Rows[i]["cName"];
                drRds["cItemCName"] =dtDetail.Rows[i]["cItemCName"];
                drRds["iEnsID"] = DBNull.Value;
                drRds["cFree3"] = DBNull.Value;
                drRds["cFree4"] = DBNull.Value;
                drRds["cFree5"] = DBNull.Value;
                drRds["cFree6"] = DBNull.Value;
                drRds["cFree7"] = DBNull.Value;
                drRds["cFree8"] = DBNull.Value;
                drRds["cFree9"] = DBNull.Value;
                drRds["cFree10"] = DBNull.Value;
                drRds["cBarCode"] = DBNull.Value;
                drRds["iNQuantity"] =dtDetail.Rows[i]["iTVQuantity"];
                drRds["iNNum"] =dtDetail.Rows[i]["iTVNum"];
                drRds["cAssUnit"] =dtDetail.Rows[i]["cAssUnit"];
                drRds["dMadeDate"] = DBNull.Value;
                drRds["iMassDate"] = DBNull.Value;
                drRds["cDefine28"] = DBNull.Value;
                drRds["cDefine29"] = DBNull.Value;
                drRds["cDefine30"] = DBNull.Value;
                drRds["cDefine31"] = DBNull.Value;
                drRds["cDefine32"] = DBNull.Value;
                drRds["cDefine33"] = DBNull.Value;
                drRds["cDefine34"] = DBNull.Value;
                drRds["cDefine35"] = DBNull.Value;
                drRds["cDefine36"] = DBNull.Value;
                drRds["cDefine37"] = DBNull.Value;
                drRds["iMPoIds"] = DBNull.Value;
                drRds["iCheckIds"] = DBNull.Value;
                drRds["cBVencode"] = DBNull.Value;
                drRds["cInVouchCode"] = DBNull.Value;
                drRds["bGsp"] = DBNull.Value;
                drRds["cGspState"] = DBNull.Value;
                drRds["iArrsId"] = DBNull.Value;
                drRds["cCheckCode"] = DBNull.Value;
                drRds["iCheckIdBaks"] = DBNull.Value;
                drRds["cRejectCode"] = DBNull.Value;
                drRds["iRejectIds"] = DBNull.Value;
                drRds["cCheckPersonCode"] = DBNull.Value;
                drRds["dCheckDate"] = DBNull.Value;
                drRds["iOriTaxCost"] = DBNull.Value;
                drRds["iOriCost"] = DBNull.Value;
                drRds["iOriMoney"] = DBNull.Value;
                drRds["iOriTaxPrice"] = DBNull.Value;
                drRds["ioriSum"] = DBNull.Value;
                drRds["iTaxRate"] = 0;
                drRds["iTaxPrice"] = DBNull.Value;
                drRds["iSum"] = DBNull.Value;
                drRds["bTaxCost"] = DBNull.Value;
                drRds["cPOID"] = DBNull.Value; 
                drRds["cMassUnit"] = 0;
                drRds["cMoLotCode"] = DBNull.Value;
                drRds["iRefundInspectFlag"] = DBNull.Value;
                drRds["iMaterialFee"] = DBNull.Value;
                drRds["iProcessCost"] = DBNull.Value;
                drRds["iProcessFee"] = DBNull.Value;
                drRds["dMSDate"] = DBNull.Value;
                drRds["iSMaterialFee"] = DBNull.Value;
                drRds["iSProcessFee"] = DBNull.Value;
                drRds["iOMoDID"] = DBNull.Value;
                drRds["iorderdid"] = DBNull.Value;
                drRds["strContractId"] = DBNull.Value;
                drRds["strCode"] = DBNull.Value;
                drRds["bFilled"] = DBNull.Value;
                drRds["bChecked"] = DBNull.Value;
                drRds["bRelated"] = DBNull.Value;
                drRds["iOMoMID"] = DBNull.Value;
                drRds["cmworkcentercode"] = DBNull.Value; 
                drRds["iMatSettleState"] = 0;
                drRds["iBillSettleCount"] = 0;
                drRds["iordertype"] = 0;
                drRds["iEqDID"] = DBNull.Value;
                drRds["cVendorCode"] = DBNull.Value;
                drRds["bLPUseFree"] = 0;
                drRds["iRSRowNO"] = DBNull.Value;
                drRds["iOriTrackID"] = DBNull.Value;
                drRds["cbaccounter"] = DBNull.Value;
                drRds["bCosting"] = 1;
                drRds["iSumBillQuantity"] = 0;
                drRds["bVMIUsed"] = 0;
                drRds["iVMISettleQuantity"] = DBNull.Value;
                drRds["iVMISettleNum"] = DBNull.Value;
                drRds["cvmivencode"] = DBNull.Value;
                drRds["iInvSNCount"] = DBNull.Value;
                drRds["cwhpersoncode"] = DBNull.Value;
                drRds["cwhpersonname"] = DBNull.Value;
                drRds["iMaIDs"] = DBNull.Value;
                drRds["impcost"] = DBNull.Value;
                drRds["iIMOSID"] = DBNull.Value;
                drRds["iIMBSID"] = DBNull.Value;
                drRds["cserviceoid"] = DBNull.Value;
                drRds["cbserviceoid"] = DBNull.Value;
                drRds["cBG_ItemCode"] = DBNull.Value;
                drRds["cBG_ItemName"] = DBNull.Value;
                drRds["cBG_CaliberKey1"] = DBNull.Value;
                drRds["cBG_CaliberKeyName1"] = DBNull.Value;
                drRds["cBG_CaliberKey2"] = DBNull.Value;
                drRds["cBG_CaliberKeyName2"] = DBNull.Value;
                drRds["cBG_CaliberKey3"] = DBNull.Value;
                drRds["cBG_CaliberKeyName3"] = DBNull.Value;
                drRds["cBG_CaliberCode1"] = DBNull.Value;
                drRds["cBG_CaliberName1"] = DBNull.Value;
                drRds["cBG_CaliberCode2"] = DBNull.Value;
                drRds["cBG_CaliberName2"] = DBNull.Value;
                drRds["cBG_CaliberCode3"] = DBNull.Value;
                drRds["cBG_CaliberName3"] = DBNull.Value;
                drRds["iBG_Ctrl"] = 0;
                drRds["cBG_Auditopinion"] = DBNull.Value;
                drRds["iBGSTSum"] = DBNull.Value;
                drRds["iBGIASum"] = DBNull.Value;
                drRds["cbarvcode"] = DBNull.Value;
                drRds["dbarvdate"] = DBNull.Value;
                drRds["iinvexchrate"] = DBNull.Value;
                drRds["cbdlcode"] = DBNull.Value;
                drRds["iordercode"] = DBNull.Value;
                drRds["iorderseq"] = DBNull.Value;
                drRds["corufts"] = DBNull.Value;
                drRds["comcode"] = DBNull.Value;
                drRds["cmocode"] = DBNull.Value;
                drRds["invcode"] = DBNull.Value;
                drRds["imoseq"] = DBNull.Value;
                drRds["iopseq"] = DBNull.Value;
                drRds["copdesc"] = DBNull.Value;
                drRds["strContractGUID"] = DBNull.Value;
                drRds["iExpiratDateCalcu"] = DBNull.Value;
                drRds["cExpirationdate"] = DBNull.Value;
                drRds["dExpirationdate"] = DBNull.Value;
                drRds["cciqbookcode"] = DBNull.Value;
                drRds["iBondedSumQty"] = DBNull.Value;
                drRds["ccusinvcode"] = DBNull.Value;
                drRds["ccusinvname"] = DBNull.Value;
                drRds["productinids"] = DBNull.Value;
                drRds["isodid"] = DBNull.Value;
                drRds["isotype"] = DBNull.Value;
                drRds["csocode"] = DBNull.Value;
                drRds["isoseq"] = DBNull.Value;
                drRds["cBatchProperty1"] = DBNull.Value;
                drRds["cBatchProperty2"] = DBNull.Value;
                drRds["cBatchProperty3"] = DBNull.Value;
                drRds["cBatchProperty4"] = DBNull.Value;
                drRds["cBatchProperty5"] = DBNull.Value;
                drRds["cBatchProperty6"] = DBNull.Value;
                drRds["cBatchProperty7"] = DBNull.Value;
                drRds["cBatchProperty8"] = DBNull.Value;
                drRds["cBatchProperty9"] = DBNull.Value;
                drRds["cBatchProperty10"] = DBNull.Value;

                dtRdrecords.Rows.Add(drRds);
                aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "RdRecords", dtRdrecords, i));

                if (dtDetail.Rows[i]["iTVNum"] == null ||dtDetail.Rows[i]["iTVNum"].ToString().Trim() == "")
                {
                    sSQL = clsGetSQL.SetCurrQty(dtDetail.Rows[i]["cInvCode"].ToString().Trim(), dtHead.Rows[0]["cIWhCode"].ToString().Trim(),Convert.ToDouble( dtDetail.Rows[i]["iTVQuantity"]));
                }
                else
                {
                    sSQL = clsGetSQL.SetCurrQty(dtDetail.Rows[i]["cInvCode"].ToString().Trim(), dtHead.Rows[0]["cIWhCode"].ToString().Trim(), Convert.ToDouble(dtDetail.Rows[i]["iTVQuantity"]), Convert.ToDouble(dtDetail.Rows[i]["iTVNum"]));
                }
                aList.Add(sSQL);
            }
            #endregion     
            
            #region     其他出库单表头
            iOutCode += 1;
            string sRDOutCode = sSetRDOutCode(iOutCode);
            iID += 1;
            drRd = null;
            dtRdrecord.Rows.Clear();
            drRd = dtRdrecord.NewRow();
            drRd["ID"] = iID;
            drRd["bRdFlag"] = 0;
            drRd["cVouchType"] = "09";
            drRd["cBusType"] = "调拨出库";
            drRd["cSource"] = "调拨";
            drRd["cBusCode"] = dtHead.Rows[0]["cTVCode"];
            drRd["cWhCode"] = dtHead.Rows[0]["cOWhCode"];
            drRd["dDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            drRd["cCode"] = sRDOutCode;
            drRd["cRdCode"] = "213";
            drRd["cDepCode"] = dtHead.Rows[0]["cODepCode"];
            drRd["cPersonCode"] = dtHead.Rows[0]["cPersonCode"];
            drRd["cPTCode"] = DBNull.Value;
            drRd["cSTCode"] = DBNull.Value;
            drRd["cCusCode"] = DBNull.Value;
            drRd["cVenCode"] = DBNull.Value;
            drRd["cOrderCode"] = DBNull.Value;
            drRd["cARVCode"] = DBNull.Value;
            drRd["cBillCode"] = DBNull.Value;
            drRd["cDLCode"] = DBNull.Value;
            drRd["cProBatch"] = DBNull.Value;
            drRd["cHandler"] = DBNull.Value;
            drRd["cMemo"] = DBNull.Value;
            drRd["bTransFlag"] = 0;
            drRd["cAccounter"] = DBNull.Value;
            drRd["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
            drRd["iNetLock"] = DBNull.Value;
            drRd["cDefine1"] = DBNull.Value;
            drRd["cDefine2"] = DBNull.Value;
            drRd["cDefine3"] = DBNull.Value;
            drRd["cDefine4"] = DBNull.Value;
            drRd["cDefine5"] = DBNull.Value;
            drRd["cDefine6"] = DBNull.Value;
            drRd["cDefine7"] = DBNull.Value;
            drRd["cDefine8"] = DBNull.Value;
            drRd["cDefine9"] = DBNull.Value;
            drRd["cDefine10"] = DBNull.Value;
            drRd["dKeepDate"] = DBNull.Value;
            drRd["dVeriDate"] = DBNull.Value;
            drRd["bpufirst"] = false;
            drRd["biafirst"] = false;
            drRd["iMQuantity"] = dtHead.Rows[0]["iQuantity"];
            drRd["dARVDate"] = DBNull.Value;
            drRd["cChkCode"] = DBNull.Value;
            drRd["dChkDate"] = DBNull.Value;
            drRd["cChkPerson"] = DBNull.Value;
            drRd["VT_ID"] = "85";
            drRd["bIsSTQc"] = false;
            drRd["cDefine11"] = DBNull.Value;
            drRd["cDefine12"] = DBNull.Value;
            drRd["cDefine13"] = DBNull.Value;
            drRd["cDefine14"] = DBNull.Value;
            drRd["cDefine15"] = DBNull.Value;
            drRd["cDefine16"] = DBNull.Value;
            drRd["cPsPcode"] = dtHead.Rows[0]["cPSPCode"];
            drRd["cMPoCode"] = dtHead.Rows[0]["cMPoCode"];
            drRd["gspcheck"] = DBNull.Value;
            drRd["ipurorderid"] = DBNull.Value;
            drRd["ipurarriveid"] = DBNull.Value;
            drRd["iproorderid"] = DBNull.Value;
            drRd["iarriveid"] = DBNull.Value;
            drRd["isalebillid"] = DBNull.Value;
            //drRd["ufts"] = "0x00000000679E3997";
            drRd["iTaxRate"] = DBNull.Value;
            drRd["iExchRate"] = DBNull.Value;
            drRd["cExch_Name"] = DBNull.Value;
            drRd["cShipAddress"] = DBNull.Value;
            drRd["bOMFirst"] = false;
            drRd["bFromPreYear"] = false;
            drRd["bIsLsQuery"] = DBNull.Value;
            drRd["bIsComplement"] = DBNull.Value;
            drRd["iDiscountTaxType"] = DBNull.Value;
            drRd["iBG_OverFlag"] = DBNull.Value;
            drRd["cBG_Auditor"] = DBNull.Value;
            drRd["cBG_AuditTime"] = DBNull.Value;
            drRd["ControlResult"] = DBNull.Value;
            drRd["caddcode"] = DBNull.Value;
            drRd["ireturncount"] = DBNull.Value;
            drRd["iverifystate"] = DBNull.Value;
            drRd["iswfcontrolled"] = false;
            drRd["cModifyPerson"] = DBNull.Value;
            drRd["dModifyDate"] = DBNull.Value;
            drRd["dnmaketime"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            drRd["dnmodifytime"] = DBNull.Value;
            drRd["dnverifytime"] = DBNull.Value;
            drRd["bredvouch"] = false;
            drRd["bmotran"] = DBNull.Value;
            drRd["cVenPUOMProtocol"] = DBNull.Value;
            drRd["dCreditStart"] = DBNull.Value;
            drRd["iCreditPeriod"] = DBNull.Value;
            drRd["dGatheringDate"] = DBNull.Value;
            drRd["bCredit"] = DBNull.Value;
            dtRdrecord.Rows.Add(drRd);
            aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "RdRecord", dtRdrecord, 0));

            //更改最大出库单据号
            sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where CardNumber='0302' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            dtCodeTemp = clsSQL.ExecQuery(sSQL);

            if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
            {
                sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0302','日期','月','" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                aList.Add(sSQL);
            }
            else
            {
                sSQL = "update @u8.VoucherHistory set cNumber = '" + iOutCode.ToString().Trim() + "' Where CardNumber='0302' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                aList.Add(sSQL);
            }
            iOutCode2 = iOutCode;
            #endregion

            #region 其他出库单表体
            dtRdrecords.Rows.Clear();
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                iIDDetail += 1;
                DataRow drRds = dtRdrecords.NewRow();
                drRds["AutoID"] = iIDDetail;
                drRds["ID"] = iID;
                drRds["cInvCode"] = dtDetail.Rows[i]["cInvCode"];
                drRds["iNum"] = dtDetail.Rows[i]["iTVNum"];
                drRds["iQuantity"] = dtDetail.Rows[i]["iTVQuantity"];
                drRds["iUnitCost"] = DBNull.Value;
                drRds["iPrice"] = DBNull.Value;
                drRds["iAPrice"] = DBNull.Value;
                drRds["iPUnitCost"] = DBNull.Value;
                drRds["iPPrice"] = DBNull.Value;
                drRds["cBatch"] = DBNull.Value;
                drRds["cObjCode"] = DBNull.Value;
                drRds["cVouchCode"] = DBNull.Value;
                drRds["cFree1"] = DBNull.Value;
                drRds["cFree2"] = DBNull.Value;
                drRds["iFlag"] = false;
                drRds["dSDate"] = DBNull.Value;
                drRds["iTax"] = "0";
                drRds["iSQuantity"] = 0;
                drRds["iSNum"] = 0;
                drRds["iMoney"] = 0;
                drRds["iSOutQuantity"] = 0;
                drRds["iSOutNum"] = 0;
                drRds["iFNum"] = 0;
                drRds["iFQuantity"] = 0;
                drRds["dVDate"] = DBNull.Value;
                drRds["iTrIds"] = dtDetail.Rows[i]["autoID"];
                drRds["cPosition"] = DBNull.Value;
                drRds["cDefine22"] = DBNull.Value;
                drRds["cDefine23"] = DBNull.Value;
                drRds["cDefine24"] = DBNull.Value;
                drRds["cDefine25"] = DBNull.Value;
                drRds["cDefine26"] = DBNull.Value;
                drRds["cDefine27"] = DBNull.Value;
                drRds["cItem_class"] = dtDetail.Rows[i]["cItem_class"];
                drRds["cItemCode"] = dtDetail.Rows[i]["cItemCode"];
                drRds["iPOsID"] = DBNull.Value;
                drRds["fACost"] = DBNull.Value;
                drRds["iDLsID"] = DBNull.Value;
                drRds["iSBsID"] = DBNull.Value;
                drRds["iSendQuantity"] = 0;
                drRds["iSendNum"] = 0;
                drRds["cName"] = dtDetail.Rows[i]["cName"];
                drRds["cItemCName"] = dtDetail.Rows[i]["cItemCName"];
                drRds["iEnsID"] = DBNull.Value;
                drRds["cFree3"] = DBNull.Value;
                drRds["cFree4"] = DBNull.Value;
                drRds["cFree5"] = DBNull.Value;
                drRds["cFree6"] = DBNull.Value;
                drRds["cFree7"] = DBNull.Value;
                drRds["cFree8"] = DBNull.Value;
                drRds["cFree9"] = DBNull.Value;
                drRds["cFree10"] = DBNull.Value;
                drRds["cBarCode"] = DBNull.Value;
                drRds["iNQuantity"] = dtDetail.Rows[i]["iTVQuantity"];
                drRds["iNNum"] = dtDetail.Rows[i]["iTVNum"];
                drRds["cAssUnit"] = dtDetail.Rows[i]["cAssUnit"];
                drRds["dMadeDate"] = DBNull.Value;
                drRds["iMassDate"] = DBNull.Value;
                drRds["cDefine28"] = DBNull.Value;
                drRds["cDefine29"] = DBNull.Value;
                drRds["cDefine30"] = DBNull.Value;
                drRds["cDefine31"] = DBNull.Value;
                drRds["cDefine32"] = DBNull.Value;
                drRds["cDefine33"] = DBNull.Value;
                drRds["cDefine34"] = DBNull.Value;
                drRds["cDefine35"] = DBNull.Value;
                drRds["cDefine36"] = DBNull.Value;
                drRds["cDefine37"] = DBNull.Value;
                drRds["iMPoIds"] = DBNull.Value;
                drRds["iCheckIds"] = DBNull.Value;
                drRds["cBVencode"] = DBNull.Value;
                drRds["cInVouchCode"] = DBNull.Value;
                drRds["bGsp"] = DBNull.Value;
                drRds["cGspState"] = DBNull.Value;
                drRds["iArrsId"] = DBNull.Value;
                drRds["cCheckCode"] = DBNull.Value;
                drRds["iCheckIdBaks"] = DBNull.Value;
                drRds["cRejectCode"] = DBNull.Value;
                drRds["iRejectIds"] = DBNull.Value;
                drRds["cCheckPersonCode"] = DBNull.Value;
                drRds["dCheckDate"] = DBNull.Value;
                drRds["iOriTaxCost"] = DBNull.Value;
                drRds["iOriCost"] = DBNull.Value;
                drRds["iOriMoney"] = DBNull.Value;
                drRds["iOriTaxPrice"] = DBNull.Value;
                drRds["ioriSum"] = DBNull.Value;
                drRds["iTaxRate"] = 0;
                drRds["iTaxPrice"] = DBNull.Value;
                drRds["iSum"] = DBNull.Value;
                drRds["bTaxCost"] = DBNull.Value;
                drRds["cPOID"] = DBNull.Value;
                drRds["cMassUnit"] = 0;
                drRds["cMoLotCode"] = DBNull.Value;
                drRds["iRefundInspectFlag"] = DBNull.Value;
                drRds["iMaterialFee"] = DBNull.Value;
                drRds["iProcessCost"] = DBNull.Value;
                drRds["iProcessFee"] = DBNull.Value;
                drRds["dMSDate"] = DBNull.Value;
                drRds["iSMaterialFee"] = DBNull.Value;
                drRds["iSProcessFee"] = DBNull.Value;
                drRds["iOMoDID"] = DBNull.Value;
                drRds["iorderdid"] = DBNull.Value;
                drRds["strContractId"] = DBNull.Value;
                drRds["strCode"] = DBNull.Value;
                drRds["bFilled"] = DBNull.Value;
                drRds["bChecked"] = DBNull.Value;
                drRds["bRelated"] = DBNull.Value;
                drRds["iOMoMID"] = DBNull.Value;
                drRds["cmworkcentercode"] = DBNull.Value;
                drRds["iMatSettleState"] = 0;
                drRds["iBillSettleCount"] = 0;
                drRds["iordertype"] = 0;
                drRds["iEqDID"] = DBNull.Value;
                drRds["cVendorCode"] = DBNull.Value;
                drRds["bLPUseFree"] = 0;
                drRds["iRSRowNO"] = DBNull.Value;
                drRds["iOriTrackID"] = DBNull.Value;
                drRds["cbaccounter"] = DBNull.Value;
                drRds["bCosting"] = 1;
                drRds["iSumBillQuantity"] = 0;
                drRds["bVMIUsed"] = 0;
                drRds["iVMISettleQuantity"] = DBNull.Value;
                drRds["iVMISettleNum"] = DBNull.Value;
                drRds["cvmivencode"] = DBNull.Value;
                drRds["iInvSNCount"] = DBNull.Value;
                drRds["cwhpersoncode"] = DBNull.Value;
                drRds["cwhpersonname"] = DBNull.Value;
                drRds["iMaIDs"] = DBNull.Value;
                drRds["impcost"] = DBNull.Value;
                drRds["iIMOSID"] = DBNull.Value;
                drRds["iIMBSID"] = DBNull.Value;
                drRds["cserviceoid"] = DBNull.Value;
                drRds["cbserviceoid"] = DBNull.Value;
                drRds["cBG_ItemCode"] = DBNull.Value;
                drRds["cBG_ItemName"] = DBNull.Value;
                drRds["cBG_CaliberKey1"] = DBNull.Value;
                drRds["cBG_CaliberKeyName1"] = DBNull.Value;
                drRds["cBG_CaliberKey2"] = DBNull.Value;
                drRds["cBG_CaliberKeyName2"] = DBNull.Value;
                drRds["cBG_CaliberKey3"] = DBNull.Value;
                drRds["cBG_CaliberKeyName3"] = DBNull.Value;
                drRds["cBG_CaliberCode1"] = DBNull.Value;
                drRds["cBG_CaliberName1"] = DBNull.Value;
                drRds["cBG_CaliberCode2"] = DBNull.Value;
                drRds["cBG_CaliberName2"] = DBNull.Value;
                drRds["cBG_CaliberCode3"] = DBNull.Value;
                drRds["cBG_CaliberName3"] = DBNull.Value;
                drRds["iBG_Ctrl"] = 0;
                drRds["cBG_Auditopinion"] = DBNull.Value;
                drRds["iBGSTSum"] = DBNull.Value;
                drRds["iBGIASum"] = DBNull.Value;
                drRds["cbarvcode"] = DBNull.Value;
                drRds["dbarvdate"] = DBNull.Value;
                drRds["iinvexchrate"] = DBNull.Value;
                drRds["cbdlcode"] = DBNull.Value;
                drRds["iordercode"] = DBNull.Value;
                drRds["iorderseq"] = DBNull.Value;
                drRds["corufts"] = DBNull.Value;
                drRds["comcode"] = DBNull.Value;
                drRds["cmocode"] = DBNull.Value;
                drRds["invcode"] = DBNull.Value;
                drRds["imoseq"] = DBNull.Value;
                drRds["iopseq"] = DBNull.Value;
                drRds["copdesc"] = DBNull.Value;
                drRds["strContractGUID"] = DBNull.Value;
                drRds["iExpiratDateCalcu"] = DBNull.Value;
                drRds["cExpirationdate"] = DBNull.Value;
                drRds["dExpirationdate"] = DBNull.Value;
                drRds["cciqbookcode"] = DBNull.Value;
                drRds["iBondedSumQty"] = DBNull.Value;
                drRds["ccusinvcode"] = DBNull.Value;
                drRds["ccusinvname"] = DBNull.Value;
                drRds["productinids"] = DBNull.Value;
                drRds["isodid"] = DBNull.Value;
                drRds["isotype"] = DBNull.Value;
                drRds["csocode"] = DBNull.Value;
                drRds["isoseq"] = DBNull.Value;
                drRds["cBatchProperty1"] = DBNull.Value;
                drRds["cBatchProperty2"] = DBNull.Value;
                drRds["cBatchProperty3"] = DBNull.Value;
                drRds["cBatchProperty4"] = DBNull.Value;
                drRds["cBatchProperty5"] = DBNull.Value;
                drRds["cBatchProperty6"] = DBNull.Value;
                drRds["cBatchProperty7"] = DBNull.Value;
                drRds["cBatchProperty8"] = DBNull.Value;
                drRds["cBatchProperty9"] = DBNull.Value;
                drRds["cBatchProperty10"] = DBNull.Value;

                dtRdrecords.Rows.Add(drRds);
                aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "RdRecords", dtRdrecords, i));

                if (dtDetail.Rows[i]["iTVNum"] == null || dtDetail.Rows[i]["iTVNum"].ToString().Trim() == "")
                {
                    sSQL = clsGetSQL.SetCurrQty(dtDetail.Rows[i]["cInvCode"].ToString().Trim(), dtHead.Rows[0]["cOWhCode"].ToString().Trim(),Convert.ToDouble( dtDetail.Rows[i]["iTVQuantity"]) * (-1));
                }
                else
                {
                    sSQL = clsGetSQL.SetCurrQty(dtDetail.Rows[i]["cInvCode"].ToString().Trim(), dtHead.Rows[0]["cOWhCode"].ToString().Trim(), Convert.ToDouble(dtDetail.Rows[i]["iTVQuantity"]) * (-1), Convert.ToDouble(dtDetail.Rows[i]["iTVNum"]) * (-1));
                }
                aList.Add(sSQL);
            }
            #endregion     

            sSQL = "update UFSystem..UA_Identity set iFatherID = " + iID + ",iChildID=" + iIDDetail + "  where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'rd'";
            aList.Add(sSQL);

            iID2 = iID;
            iIDDetail2 = iIDDetail;
            return aList;
        }
        #endregion

        #region 生成调拨单

        //public ArrayList CreateTransVouch(DataTable dtHead, DataTable dtDetail, long iID, long iIDDetail, out long iID2, out long iIDDetail2, long iCode, out long iCode2)
        //{
        //    string sSQL = "select * from @u8.TransVouch  where 1=-1";
        //    DataTable dtTransVouch = clsSQL.ExecQuery(sSQL);
        //    sSQL = "select * from @u8.TransVouchs where 1=-1";
        //    DataTable dtTransVouchs = clsSQL.ExecQuery(sSQL);


        //}
        #endregion

    }
}
