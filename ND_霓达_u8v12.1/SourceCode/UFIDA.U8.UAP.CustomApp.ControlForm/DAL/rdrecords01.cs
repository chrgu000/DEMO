﻿using System;
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:rdrecords01
    /// </summary>
    public partial class rdrecords01
    {
        public rdrecords01()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords01 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.AutoID != null)
            {
                strSql1.Append("AutoID,");
                strSql2.Append("" + model.AutoID + ",");
            }
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.iNum != null)
            {
                strSql1.Append("iNum,");
                strSql2.Append("" + model.iNum + ",");
            }
            if (model.iQuantity != null)
            {
                strSql1.Append("iQuantity,");
                strSql2.Append("" + model.iQuantity + ",");
            }
            if (model.iUnitCost != null)
            {
                strSql1.Append("iUnitCost,");
                strSql2.Append("" + model.iUnitCost + ",");
            }
            if (model.iPrice != null)
            {
                strSql1.Append("iPrice,");
                strSql2.Append("" + model.iPrice + ",");
            }
            if (model.iAPrice != null)
            {
                strSql1.Append("iAPrice,");
                strSql2.Append("" + model.iAPrice + ",");
            }
            if (model.iPUnitCost != null)
            {
                strSql1.Append("iPUnitCost,");
                strSql2.Append("" + model.iPUnitCost + ",");
            }
            if (model.iPPrice != null)
            {
                strSql1.Append("iPPrice,");
                strSql2.Append("" + model.iPPrice + ",");
            }
            if (model.cBatch != null)
            {
                strSql1.Append("cBatch,");
                strSql2.Append("'" + model.cBatch + "',");
            }
            if (model.cVouchCode != null)
            {
                strSql1.Append("cVouchCode,");
                strSql2.Append("" + model.cVouchCode + ",");
            }
            if (model.cInVouchCode != null)
            {
                strSql1.Append("cInVouchCode,");
                strSql2.Append("'" + model.cInVouchCode + "',");
            }
            if (model.cinvouchtype != null)
            {
                strSql1.Append("cinvouchtype,");
                strSql2.Append("'" + model.cinvouchtype + "',");
            }
            if (model.iSOutQuantity != null)
            {
                strSql1.Append("iSOutQuantity,");
                strSql2.Append("" + model.iSOutQuantity + ",");
            }
            if (model.iSOutNum != null)
            {
                strSql1.Append("iSOutNum,");
                strSql2.Append("" + model.iSOutNum + ",");
            }
            if (model.cFree1 != null)
            {
                strSql1.Append("cFree1,");
                strSql2.Append("'" + model.cFree1 + "',");
            }
            if (model.cFree2 != null)
            {
                strSql1.Append("cFree2,");
                strSql2.Append("'" + model.cFree2 + "',");
            }
            if (model.iFlag != null)
            {
                strSql1.Append("iFlag,");
                strSql2.Append("" + model.iFlag + ",");
            }
            if (model.dSDate != null)
            {
                strSql1.Append("dSDate,");
                strSql2.Append("'" + model.dSDate + "',");
            }
            if (model.iTax != null)
            {
                strSql1.Append("iTax,");
                strSql2.Append("" + model.iTax + ",");
            }
            if (model.iSQuantity != null)
            {
                strSql1.Append("iSQuantity,");
                strSql2.Append("" + model.iSQuantity + ",");
            }
            if (model.iSNum != null)
            {
                strSql1.Append("iSNum,");
                strSql2.Append("" + model.iSNum + ",");
            }
            if (model.iMoney != null)
            {
                strSql1.Append("iMoney,");
                strSql2.Append("" + model.iMoney + ",");
            }
            if (model.iFNum != null)
            {
                strSql1.Append("iFNum,");
                strSql2.Append("" + model.iFNum + ",");
            }
            if (model.iFQuantity != null)
            {
                strSql1.Append("iFQuantity,");
                strSql2.Append("" + model.iFQuantity + ",");
            }
            if (model.dVDate != null)
            {
                strSql1.Append("dVDate,");
                strSql2.Append("'" + model.dVDate + "',");
            }
            if (model.cPosition != null)
            {
                strSql1.Append("cPosition,");
                strSql2.Append("'" + model.cPosition + "',");
            }
            if (model.cDefine22 != null)
            {
                strSql1.Append("cDefine22,");
                strSql2.Append("'" + model.cDefine22 + "',");
            }
            if (model.cDefine23 != null)
            {
                strSql1.Append("cDefine23,");
                strSql2.Append("'" + model.cDefine23 + "',");
            }
            if (model.cDefine24 != null)
            {
                strSql1.Append("cDefine24,");
                strSql2.Append("'" + model.cDefine24 + "',");
            }
            if (model.cDefine25 != null)
            {
                strSql1.Append("cDefine25,");
                strSql2.Append("'" + model.cDefine25 + "',");
            }
            if (model.cDefine26 != null)
            {
                strSql1.Append("cDefine26,");
                strSql2.Append("" + model.cDefine26 + ",");
            }
            if (model.cDefine27 != null)
            {
                strSql1.Append("cDefine27,");
                strSql2.Append("" + model.cDefine27 + ",");
            }
            if (model.cItem_class != null)
            {
                strSql1.Append("cItem_class,");
                strSql2.Append("'" + model.cItem_class + "',");
            }
            if (model.cItemCode != null)
            {
                strSql1.Append("cItemCode,");
                strSql2.Append("'" + model.cItemCode + "',");
            }
            if (model.iPOsID != null)
            {
                strSql1.Append("iPOsID,");
                strSql2.Append("" + model.iPOsID + ",");
            }
            if (model.fACost != null)
            {
                strSql1.Append("fACost,");
                strSql2.Append("" + model.fACost + ",");
            }
            if (model.cName != null)
            {
                strSql1.Append("cName,");
                strSql2.Append("'" + model.cName + "',");
            }
            if (model.cItemCName != null)
            {
                strSql1.Append("cItemCName,");
                strSql2.Append("'" + model.cItemCName + "',");
            }
            if (model.cFree3 != null)
            {
                strSql1.Append("cFree3,");
                strSql2.Append("'" + model.cFree3 + "',");
            }
            if (model.cFree4 != null)
            {
                strSql1.Append("cFree4,");
                strSql2.Append("'" + model.cFree4 + "',");
            }
            if (model.cFree5 != null)
            {
                strSql1.Append("cFree5,");
                strSql2.Append("'" + model.cFree5 + "',");
            }
            if (model.cFree6 != null)
            {
                strSql1.Append("cFree6,");
                strSql2.Append("'" + model.cFree6 + "',");
            }
            if (model.cFree7 != null)
            {
                strSql1.Append("cFree7,");
                strSql2.Append("'" + model.cFree7 + "',");
            }
            if (model.cFree8 != null)
            {
                strSql1.Append("cFree8,");
                strSql2.Append("'" + model.cFree8 + "',");
            }
            if (model.cFree9 != null)
            {
                strSql1.Append("cFree9,");
                strSql2.Append("'" + model.cFree9 + "',");
            }
            if (model.cFree10 != null)
            {
                strSql1.Append("cFree10,");
                strSql2.Append("'" + model.cFree10 + "',");
            }
            if (model.cBarCode != null)
            {
                strSql1.Append("cBarCode,");
                strSql2.Append("'" + model.cBarCode + "',");
            }
            if (model.iNQuantity != null)
            {
                strSql1.Append("iNQuantity,");
                strSql2.Append("" + model.iNQuantity + ",");
            }
            if (model.iNNum != null)
            {
                strSql1.Append("iNNum,");
                strSql2.Append("" + model.iNNum + ",");
            }
            if (model.cAssUnit != null)
            {
                strSql1.Append("cAssUnit,");
                strSql2.Append("'" + model.cAssUnit + "',");
            }
            if (model.dMadeDate != null)
            {
                strSql1.Append("dMadeDate,");
                strSql2.Append("'" + model.dMadeDate + "',");
            }
            if (model.iMassDate != null)
            {
                strSql1.Append("iMassDate,");
                strSql2.Append("" + model.iMassDate + ",");
            }
            if (model.cDefine28 != null)
            {
                strSql1.Append("cDefine28,");
                strSql2.Append("'" + model.cDefine28 + "',");
            }
            if (model.cDefine29 != null)
            {
                strSql1.Append("cDefine29,");
                strSql2.Append("'" + model.cDefine29 + "',");
            }
            if (model.cDefine30 != null)
            {
                strSql1.Append("cDefine30,");
                strSql2.Append("'" + model.cDefine30 + "',");
            }
            if (model.cDefine31 != null)
            {
                strSql1.Append("cDefine31,");
                strSql2.Append("'" + model.cDefine31 + "',");
            }
            if (model.cDefine32 != null)
            {
                strSql1.Append("cDefine32,");
                strSql2.Append("'" + model.cDefine32 + "',");
            }
            if (model.cDefine33 != null)
            {
                strSql1.Append("cDefine33,");
                strSql2.Append("'" + model.cDefine33 + "',");
            }
            if (model.cDefine34 != null)
            {
                strSql1.Append("cDefine34,");
                strSql2.Append("" + model.cDefine34 + ",");
            }
            if (model.cDefine35 != null)
            {
                strSql1.Append("cDefine35,");
                strSql2.Append("" + model.cDefine35 + ",");
            }
            if (model.cDefine36 != null)
            {
                strSql1.Append("cDefine36,");
                strSql2.Append("'" + model.cDefine36 + "',");
            }
            if (model.cDefine37 != null)
            {
                strSql1.Append("cDefine37,");
                strSql2.Append("'" + model.cDefine37 + "',");
            }
            if (model.iCheckIds != null)
            {
                strSql1.Append("iCheckIds,");
                strSql2.Append("" + model.iCheckIds + ",");
            }
            if (model.cBVencode != null)
            {
                strSql1.Append("cBVencode,");
                strSql2.Append("'" + model.cBVencode + "',");
            }
            if (model.chVencode != null)
            {
                strSql1.Append("chVencode,");
                strSql2.Append("'" + model.chVencode + "',");
            }
            if (model.bGsp != null)
            {
                strSql1.Append("bGsp,");
                strSql2.Append("" + (model.bGsp ? 1 : 0) + ",");
            }
            if (model.cGspState != null)
            {
                strSql1.Append("cGspState,");
                strSql2.Append("'" + model.cGspState + "',");
            }
            if (model.iArrsId != null)
            {
                strSql1.Append("iArrsId,");
                strSql2.Append("" + model.iArrsId + ",");
            }
            if (model.cCheckCode != null)
            {
                strSql1.Append("cCheckCode,");
                strSql2.Append("'" + model.cCheckCode + "',");
            }
            if (model.iCheckIdBaks != null)
            {
                strSql1.Append("iCheckIdBaks,");
                strSql2.Append("" + model.iCheckIdBaks + ",");
            }
            if (model.cRejectCode != null)
            {
                strSql1.Append("cRejectCode,");
                strSql2.Append("'" + model.cRejectCode + "',");
            }
            if (model.iRejectIds != null)
            {
                strSql1.Append("iRejectIds,");
                strSql2.Append("" + model.iRejectIds + ",");
            }
            if (model.cCheckPersonCode != null)
            {
                strSql1.Append("cCheckPersonCode,");
                strSql2.Append("'" + model.cCheckPersonCode + "',");
            }
            if (model.dCheckDate != null)
            {
                strSql1.Append("dCheckDate,");
                strSql2.Append("'" + model.dCheckDate + "',");
            }
            if (model.iOriTaxCost != null)
            {
                strSql1.Append("iOriTaxCost,");
                strSql2.Append("" + model.iOriTaxCost + ",");
            }
            if (model.iOriCost != null)
            {
                strSql1.Append("iOriCost,");
                strSql2.Append("" + model.iOriCost + ",");
            }
            if (model.iOriMoney != null)
            {
                strSql1.Append("iOriMoney,");
                strSql2.Append("" + model.iOriMoney + ",");
            }
            if (model.iOriTaxPrice != null)
            {
                strSql1.Append("iOriTaxPrice,");
                strSql2.Append("" + model.iOriTaxPrice + ",");
            }
            if (model.ioriSum != null)
            {
                strSql1.Append("ioriSum,");
                strSql2.Append("" + model.ioriSum + ",");
            }
            if (model.iTaxRate != null)
            {
                strSql1.Append("iTaxRate,");
                strSql2.Append("" + model.iTaxRate + ",");
            }
            if (model.iTaxPrice != null)
            {
                strSql1.Append("iTaxPrice,");
                strSql2.Append("" + model.iTaxPrice + ",");
            }
            if (model.iSum != null)
            {
                strSql1.Append("iSum,");
                strSql2.Append("" + model.iSum + ",");
            }
            if (model.bTaxCost != null)
            {
                strSql1.Append("bTaxCost,");
                strSql2.Append("" + (model.bTaxCost ? 1 : 0) + ",");
            }
            if (model.cPOID != null)
            {
                strSql1.Append("cPOID,");
                strSql2.Append("'" + model.cPOID + "',");
            }
            if (model.cMassUnit != null)
            {
                strSql1.Append("cMassUnit,");
                strSql2.Append("" + model.cMassUnit + ",");
            }
            if (model.iMaterialFee != null)
            {
                strSql1.Append("iMaterialFee,");
                strSql2.Append("" + model.iMaterialFee + ",");
            }
            if (model.iProcessCost != null)
            {
                strSql1.Append("iProcessCost,");
                strSql2.Append("" + model.iProcessCost + ",");
            }
            if (model.iProcessFee != null)
            {
                strSql1.Append("iProcessFee,");
                strSql2.Append("" + model.iProcessFee + ",");
            }
            if (model.dMSDate != null)
            {
                strSql1.Append("dMSDate,");
                strSql2.Append("'" + model.dMSDate + "',");
            }
            if (model.iSMaterialFee != null)
            {
                strSql1.Append("iSMaterialFee,");
                strSql2.Append("" + model.iSMaterialFee + ",");
            }
            if (model.iSProcessFee != null)
            {
                strSql1.Append("iSProcessFee,");
                strSql2.Append("" + model.iSProcessFee + ",");
            }
            if (model.iOMoDID != null)
            {
                strSql1.Append("iOMoDID,");
                strSql2.Append("" + model.iOMoDID + ",");
            }
            if (model.strContractId != null)
            {
                strSql1.Append("strContractId,");
                strSql2.Append("'" + model.strContractId + "',");
            }
            if (model.strCode != null)
            {
                strSql1.Append("strCode,");
                strSql2.Append("'" + model.strCode + "',");
            }
            if (model.bChecked != null)
            {
                strSql1.Append("bChecked,");
                strSql2.Append("" + (model.bChecked ? 1 : 0) + ",");
            }
            if (model.bRelated != null)
            {
                strSql1.Append("bRelated,");
                strSql2.Append("" + (model.bRelated ? 1 : 0) + ",");
            }
            if (model.iOMoMID != null)
            {
                strSql1.Append("iOMoMID,");
                strSql2.Append("" + model.iOMoMID + ",");
            }
            if (model.iMatSettleState != null)
            {
                strSql1.Append("iMatSettleState,");
                strSql2.Append("" + model.iMatSettleState + ",");
            }
            if (model.iBillSettleCount != null)
            {
                strSql1.Append("iBillSettleCount,");
                strSql2.Append("" + model.iBillSettleCount + ",");
            }
            if (model.bLPUseFree != null)
            {
                strSql1.Append("bLPUseFree,");
                strSql2.Append("" + (model.bLPUseFree ? 1 : 0) + ",");
            }
            if (model.iOriTrackID != null)
            {
                strSql1.Append("iOriTrackID,");
                strSql2.Append("" + model.iOriTrackID + ",");
            }
            if (model.coritracktype != null)
            {
                strSql1.Append("coritracktype,");
                strSql2.Append("'" + model.coritracktype + "',");
            }
            if (model.cbaccounter != null)
            {
                strSql1.Append("cbaccounter,");
                strSql2.Append("'" + model.cbaccounter + "',");
            }
            if (model.dbKeepDate != null)
            {
                strSql1.Append("dbKeepDate,");
                strSql2.Append("'" + model.dbKeepDate + "',");
            }
            if (model.bCosting != null)
            {
                strSql1.Append("bCosting,");
                strSql2.Append("" + (model.bCosting ? 1 : 0) + ",");
            }
            if (model.iSumBillQuantity != null)
            {
                strSql1.Append("iSumBillQuantity,");
                strSql2.Append("" + model.iSumBillQuantity + ",");
            }
            if (model.bVMIUsed != null)
            {
                strSql1.Append("bVMIUsed,");
                strSql2.Append("" + (model.bVMIUsed ? 1 : 0) + ",");
            }
            if (model.iVMISettleQuantity != null)
            {
                strSql1.Append("iVMISettleQuantity,");
                strSql2.Append("" + model.iVMISettleQuantity + ",");
            }
            if (model.iVMISettleNum != null)
            {
                strSql1.Append("iVMISettleNum,");
                strSql2.Append("" + model.iVMISettleNum + ",");
            }
            if (model.cvmivencode != null)
            {
                strSql1.Append("cvmivencode,");
                strSql2.Append("'" + model.cvmivencode + "',");
            }
            if (model.iInvSNCount != null)
            {
                strSql1.Append("iInvSNCount,");
                strSql2.Append("" + model.iInvSNCount + ",");
            }
            if (model.cwhpersoncode != null)
            {
                strSql1.Append("cwhpersoncode,");
                strSql2.Append("'" + model.cwhpersoncode + "',");
            }
            if (model.cwhpersonname != null)
            {
                strSql1.Append("cwhpersonname,");
                strSql2.Append("'" + model.cwhpersonname + "',");
            }
            if (model.impcost != null)
            {
                strSql1.Append("impcost,");
                strSql2.Append("" + model.impcost + ",");
            }
            if (model.iIMOSID != null)
            {
                strSql1.Append("iIMOSID,");
                strSql2.Append("" + model.iIMOSID + ",");
            }
            if (model.iIMBSID != null)
            {
                strSql1.Append("iIMBSID,");
                strSql2.Append("" + model.iIMBSID + ",");
            }
            if (model.cbarvcode != null)
            {
                strSql1.Append("cbarvcode,");
                strSql2.Append("'" + model.cbarvcode + "',");
            }
            if (model.dbarvdate != null)
            {
                strSql1.Append("dbarvdate,");
                strSql2.Append("'" + model.dbarvdate + "',");
            }
            if (model.iinvexchrate != null)
            {
                strSql1.Append("iinvexchrate,");
                strSql2.Append("" + model.iinvexchrate + ",");
            }
            if (model.corufts != null)
            {
                strSql1.Append("corufts,");
                strSql2.Append("'" + model.corufts + "',");
            }
            if (model.comcode != null)
            {
                strSql1.Append("comcode,");
                strSql2.Append("'" + model.comcode + "',");
            }
            if (model.strContractGUID != null)
            {
                strSql1.Append("strContractGUID,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.iExpiratDateCalcu != null)
            {
                strSql1.Append("iExpiratDateCalcu,");
                strSql2.Append("" + model.iExpiratDateCalcu + ",");
            }
            if (model.cExpirationdate != null)
            {
                strSql1.Append("cExpirationdate,");
                strSql2.Append("'" + model.cExpirationdate + "',");
            }
            if (model.dExpirationdate != null)
            {
                strSql1.Append("dExpirationdate,");
                strSql2.Append("'" + model.dExpirationdate + "',");
            }
            if (model.cciqbookcode != null)
            {
                strSql1.Append("cciqbookcode,");
                strSql2.Append("'" + model.cciqbookcode + "',");
            }
            if (model.iBondedSumQty != null)
            {
                strSql1.Append("iBondedSumQty,");
                strSql2.Append("" + model.iBondedSumQty + ",");
            }
            if (model.iordertype != null)
            {
                strSql1.Append("iordertype,");
                strSql2.Append("" + model.iordertype + ",");
            }
            if (model.iorderdid != null)
            {
                strSql1.Append("iorderdid,");
                strSql2.Append("" + model.iorderdid + ",");
            }
            if (model.iordercode != null)
            {
                strSql1.Append("iordercode,");
                strSql2.Append("'" + model.iordercode + "',");
            }
            if (model.iorderseq != null)
            {
                strSql1.Append("iorderseq,");
                strSql2.Append("" + model.iorderseq + ",");
            }
            if (model.isodid != null)
            {
                strSql1.Append("isodid,");
                strSql2.Append("'" + model.isodid + "',");
            }
            if (model.isotype != null)
            {
                strSql1.Append("isotype,");
                strSql2.Append("" + model.isotype + ",");
            }
            if (model.csocode != null)
            {
                strSql1.Append("csocode,");
                strSql2.Append("'" + model.csocode + "',");
            }
            if (model.isoseq != null)
            {
                strSql1.Append("isoseq,");
                strSql2.Append("" + model.isoseq + ",");
            }
            if (model.cBatchProperty1 != null)
            {
                strSql1.Append("cBatchProperty1,");
                strSql2.Append("" + model.cBatchProperty1 + ",");
            }
            if (model.cBatchProperty2 != null)
            {
                strSql1.Append("cBatchProperty2,");
                strSql2.Append("" + model.cBatchProperty2 + ",");
            }
            if (model.cBatchProperty3 != null)
            {
                strSql1.Append("cBatchProperty3,");
                strSql2.Append("" + model.cBatchProperty3 + ",");
            }
            if (model.cBatchProperty4 != null)
            {
                strSql1.Append("cBatchProperty4,");
                strSql2.Append("" + model.cBatchProperty4 + ",");
            }
            if (model.cBatchProperty5 != null)
            {
                strSql1.Append("cBatchProperty5,");
                strSql2.Append("" + model.cBatchProperty5 + ",");
            }
            if (model.cBatchProperty6 != null)
            {
                strSql1.Append("cBatchProperty6,");
                strSql2.Append("'" + model.cBatchProperty6 + "',");
            }
            if (model.cBatchProperty7 != null)
            {
                strSql1.Append("cBatchProperty7,");
                strSql2.Append("'" + model.cBatchProperty7 + "',");
            }
            if (model.cBatchProperty8 != null)
            {
                strSql1.Append("cBatchProperty8,");
                strSql2.Append("'" + model.cBatchProperty8 + "',");
            }
            if (model.cBatchProperty9 != null)
            {
                strSql1.Append("cBatchProperty9,");
                strSql2.Append("'" + model.cBatchProperty9 + "',");
            }
            if (model.cBatchProperty10 != null)
            {
                strSql1.Append("cBatchProperty10,");
                strSql2.Append("'" + model.cBatchProperty10 + "',");
            }
            if (model.cbMemo != null)
            {
                strSql1.Append("cbMemo,");
                strSql2.Append("'" + model.cbMemo + "',");
            }
            if (model.iFaQty != null)
            {
                strSql1.Append("iFaQty,");
                strSql2.Append("" + model.iFaQty + ",");
            }
            if (model.isTax != null)
            {
                strSql1.Append("isTax,");
                strSql2.Append("" + model.isTax + ",");
            }
            if (model.irowno != null)
            {
                strSql1.Append("irowno,");
                strSql2.Append("" + model.irowno + ",");
            }
            if (model.strowguid != null)
            {
                strSql1.Append("strowguid,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.rowufts != null)
            {
                strSql1.Append("rowufts,");
                strSql2.Append("" + model.rowufts + ",");
            }
            if (model.ipreuseqty != null)
            {
                strSql1.Append("ipreuseqty,");
                strSql2.Append("" + model.ipreuseqty + ",");
            }
            if (model.ipreuseinum != null)
            {
                strSql1.Append("ipreuseinum,");
                strSql2.Append("" + model.ipreuseinum + ",");
            }
            if (model.iDebitIDs != null)
            {
                strSql1.Append("iDebitIDs,");
                strSql2.Append("" + model.iDebitIDs + ",");
            }
            if (model.OutCopiedQuantity != null)
            {
                strSql1.Append("OutCopiedQuantity,");
                strSql2.Append("" + model.OutCopiedQuantity + ",");
            }
            if (model.iOldPartId != null)
            {
                strSql1.Append("iOldPartId,");
                strSql2.Append("" + model.iOldPartId + ",");
            }
            if (model.fOldQuantity != null)
            {
                strSql1.Append("fOldQuantity,");
                strSql2.Append("" + model.fOldQuantity + ",");
            }
            if (model.cbsysbarcode != null)
            {
                strSql1.Append("cbsysbarcode,");
                strSql2.Append("'" + model.cbsysbarcode + "',");
            }
            if (model.bmergecheck != null)
            {
                strSql1.Append("bmergecheck,");
                strSql2.Append("" + (model.bmergecheck ? 1 : 0) + ",");
            }
            if (model.iMergeCheckAutoId != null)
            {
                strSql1.Append("iMergeCheckAutoId,");
                strSql2.Append("" + model.iMergeCheckAutoId + ",");
            }
            if (model.bnoitemused != null)
            {
                strSql1.Append("bnoitemused,");
                strSql2.Append("" + model.bnoitemused + ",");
            }
            if (model.cReworkMOCode != null)
            {
                strSql1.Append("cReworkMOCode,");
                strSql2.Append("'" + model.cReworkMOCode + "',");
            }
            if (model.iReworkMODetailsid != null)
            {
                strSql1.Append("iReworkMODetailsid,");
                strSql2.Append("" + model.iReworkMODetailsid + ",");
            }
            if (model.iProductType != null)
            {
                strSql1.Append("iProductType,");
                strSql2.Append("" + model.iProductType + ",");
            }
            if (model.cMainInvCode != null)
            {
                strSql1.Append("cMainInvCode,");
                strSql2.Append("'" + model.cMainInvCode + "',");
            }
            if (model.iMainMoDetailsID != null)
            {
                strSql1.Append("iMainMoDetailsID,");
                strSql2.Append("" + model.iMainMoDetailsID + ",");
            }
            if (model.iShareMaterialFee != null)
            {
                strSql1.Append("iShareMaterialFee,");
                strSql2.Append("" + model.iShareMaterialFee + ",");
            }
            if (model.cplanlotcode != null)
            {
                strSql1.Append("cplanlotcode,");
                strSql2.Append("'" + model.cplanlotcode + "',");
            }
            if (model.bgift != null)
            {
                strSql1.Append("bgift,");
                strSql2.Append("" + model.bgift + ",");
            }
            if (model.iposflag != null)
            {
                strSql1.Append("iposflag,");
                strSql2.Append("" + model.iposflag + ",");
            }
            strSql.Append("insert into rdrecords01(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

