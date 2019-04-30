using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 数据访问类:rdrecords01
    /// </summary>
    public partial class RdRecords
    {
        public RdRecords()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.RdRecords model)
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
            if (model.cObjCode != null)
            {
                strSql1.Append("cObjCode,");
                strSql2.Append("'" + model.cObjCode + "',");
            }
            if (model.cVouchCode != null)
            {
                strSql1.Append("cVouchCode,");
                strSql2.Append("'" + model.cVouchCode + "',");
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
            if (model.iTrIds != null)
            {
                strSql1.Append("iTrIds,");
                strSql2.Append("" + model.iTrIds + ",");
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
            if (model.iDLsID != null)
            {
                strSql1.Append("iDLsID,");
                strSql2.Append("" + model.iDLsID + ",");
            }
            if (model.iSBsID != null)
            {
                strSql1.Append("iSBsID,");
                strSql2.Append("" + model.iSBsID + ",");
            }
            if (model.iSendQuantity != null)
            {
                strSql1.Append("iSendQuantity,");
                strSql2.Append("" + model.iSendQuantity + ",");
            }
            if (model.iSendNum != null)
            {
                strSql1.Append("iSendNum,");
                strSql2.Append("" + model.iSendNum + ",");
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
            if (model.iEnsID != null)
            {
                strSql1.Append("iEnsID,");
                strSql2.Append("" + model.iEnsID + ",");
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
            if (model.iMPoIds != null)
            {
                strSql1.Append("iMPoIds,");
                strSql2.Append("" + model.iMPoIds + ",");
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
            if (model.cInVouchCode != null)
            {
                strSql1.Append("cInVouchCode,");
                strSql2.Append("'" + model.cInVouchCode + "',");
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
            if (model.iTookQuantity != null)
            {
                strSql1.Append("iTookQuantity,");
                strSql2.Append("" + model.iTookQuantity + ",");
            }
            if (model.iInvalidQuantity != null)
            {
                strSql1.Append("iInvalidQuantity,");
                strSql2.Append("" + model.iInvalidQuantity + ",");
            }
            if (model.iOMMPoIds != null)
            {
                strSql1.Append("iOMMPoIds,");
                strSql2.Append("" + model.iOMMPoIds + ",");
            }
            if (model.iPBVQuantity != null)
            {
                strSql1.Append("iPBVQuantity,");
                strSql2.Append("" + model.iPBVQuantity + ",");
            }
            if (model.iPBVyQuantity != null)
            {
                strSql1.Append("iPBVyQuantity,");
                strSql2.Append("" + model.iPBVyQuantity + ",");
            }
            if (model.iBalance != null)
            {
                strSql1.Append("iBalance,");
                strSql2.Append("" + model.iBalance + ",");
            }
            if (model.iHXQuantity != null)
            {
                strSql1.Append("iHXQuantity,");
                strSql2.Append("" + model.iHXQuantity + ",");
            }
            if (model.cCAItemCode != null)
            {
                strSql1.Append("cCAItemCode,");
                strSql2.Append("'" + model.cCAItemCode + "',");
            }
            if (model.cCBGJDXCode != null)
            {
                strSql1.Append("cCBGJDXCode,");
                strSql2.Append("'" + model.cCBGJDXCode + "',");
            }
            if (model.bfilled != null)
            {
                strSql1.Append("bfilled,");
                strSql2.Append("" + model.bfilled + ",");
            }
            if (model.iarrptrintype != null)
            {
                strSql1.Append("iarrptrintype,");
                strSql2.Append("" + model.iarrptrintype + ",");
            }
            if (model.ichkautoid != null)
            {
                strSql1.Append("ichkautoid,");
                strSql2.Append("" + model.ichkautoid + ",");
            }
            if (model.irejid != null)
            {
                strSql1.Append("irejid,");
                strSql2.Append("" + model.irejid + ",");
            }
            if (model.crejtext != null)
            {
                strSql1.Append("crejtext,");
                strSql2.Append("'" + model.crejtext + "',");
            }
            if (model.iTaxCost != null)
            {
                strSql1.Append("iTaxCost,");
                strSql2.Append("" + model.iTaxCost + ",");
            }
            if (model.iTaxPrice != null)
            {
                strSql1.Append("iTaxPrice,");
                strSql2.Append("" + model.iTaxPrice + ",");
            }
            if (model.iTaxRate != null)
            {
                strSql1.Append("iTaxRate,");
                strSql2.Append("" + model.iTaxRate + ",");
            }
            if (model.iSum != null)
            {
                strSql1.Append("iSum,");
                strSql2.Append("" + model.iSum + ",");
            }
            if (model.iATaxCost != null)
            {
                strSql1.Append("iATaxCost,");
                strSql2.Append("" + model.iATaxCost + ",");
            }
            if (model.iATaxPrice != null)
            {
                strSql1.Append("iATaxPrice,");
                strSql2.Append("" + model.iATaxPrice + ",");
            }
            if (model.iATaxRate != null)
            {
                strSql1.Append("iATaxRate,");
                strSql2.Append("" + model.iATaxRate + ",");
            }
            if (model.iASum != null)
            {
                strSql1.Append("iASum,");
                strSql2.Append("" + model.iASum + ",");
            }
            if (model.MakePrice != null)
            {
                strSql1.Append("MakePrice,");
                strSql2.Append("" + model.MakePrice + ",");
            }
            if (model.MakeMny != null)
            {
                strSql1.Append("MakeMny,");
                strSql2.Append("" + model.MakeMny + ",");
            }
            if (model.HadBalanceQuantity != null)
            {
                strSql1.Append("HadBalanceQuantity,");
                strSql2.Append("" + model.HadBalanceQuantity + ",");
            }
            if (model.HadBalanceMny != null)
            {
                strSql1.Append("HadBalanceMny,");
                strSql2.Append("" + model.HadBalanceMny + ",");
            }
            if (model.OrgMakePrice != null)
            {
                strSql1.Append("OrgMakePrice,");
                strSql2.Append("" + model.OrgMakePrice + ",");
            }
            if (model.cBOMSoCode != null)
            {
                strSql1.Append("cBOMSoCode,");
                strSql2.Append("'" + model.cBOMSoCode + "',");
            }
            if (model.csocode != null)
            {
                strSql1.Append("csocode,");
                strSql2.Append("'" + model.csocode + "',");
            }
            if (model.ccbgjdxname != null)
            {
                strSql1.Append("ccbgjdxname,");
                strSql2.Append("'" + model.ccbgjdxname + "',");
            }
            if (model.TaxMakePrice != null)
            {
                strSql1.Append("TaxMakePrice,");
                strSql2.Append("" + model.TaxMakePrice + ",");
            }
            if (model.iMakeTaxPrice != null)
            {
                strSql1.Append("iMakeTaxPrice,");
                strSql2.Append("" + model.iMakeTaxPrice + ",");
            }
            if (model.iMakeTaxRate != null)
            {
                strSql1.Append("iMakeTaxRate,");
                strSql2.Append("" + model.iMakeTaxRate + ",");
            }
            if (model.TaxMakeMny != null)
            {
                strSql1.Append("TaxMakeMny,");
                strSql2.Append("" + model.TaxMakeMny + ",");
            }
            if (model.sosid != null)
            {
                strSql1.Append("sosid,");
                strSql2.Append("" + model.sosid + ",");
            }
            if (model.YCcode != null)
            {
                strSql1.Append("YCcode,");
                strSql2.Append("'" + model.YCcode + "',");
            }
            if (model.YCsid != null)
            {
                strSql1.Append("YCsid,");
                strSql2.Append("" + model.YCsid + ",");
            }
            strSql.Append("insert into @u8.RdRecords(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");

            return strSql.ToString();
        }

    }
}

