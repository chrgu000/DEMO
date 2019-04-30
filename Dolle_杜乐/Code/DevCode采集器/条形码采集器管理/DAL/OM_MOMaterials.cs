using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BarCode.DAL
{
    /// <summary>
    /// 数据访问类:OM_MOMaterials
    /// </summary>
    public partial class OM_MOMaterials
    {
        public OM_MOMaterials()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BarCode.Model.OM_MOMaterials model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.MOMaterialsID != null)
            {
                strSql1.Append("MOMaterialsID,");
                strSql2.Append("" + model.MOMaterialsID + ",");
            }
            if (model.MoDetailsID != null)
            {
                strSql1.Append("MoDetailsID,");
                strSql2.Append("" + model.MoDetailsID + ",");
            }
            if (model.MOID != null)
            {
                strSql1.Append("MOID,");
                strSql2.Append("" + model.MOID + ",");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.iQuantity != null)
            {
                strSql1.Append("iQuantity,");
                strSql2.Append("" + model.iQuantity + ",");
            }
            if (model.dRequiredDate != null)
            {
                strSql1.Append("dRequiredDate,");
                strSql2.Append("'" + model.dRequiredDate + "',");
            }
            if (model.iSendQTY != null)
            {
                strSql1.Append("iSendQTY,");
                strSql2.Append("" + model.iSendQTY + ",");
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
            if (model.fBaseQtyN != null)
            {
                strSql1.Append("fBaseQtyN,");
                strSql2.Append("" + model.fBaseQtyN + ",");
            }
            if (model.fBaseQtyD != null)
            {
                strSql1.Append("fBaseQtyD,");
                strSql2.Append("" + model.fBaseQtyD + ",");
            }
            if (model.fCompScrp != null)
            {
                strSql1.Append("fCompScrp,");
                strSql2.Append("" + model.fCompScrp + ",");
            }
            if (model.bFVQty != null)
            {
                strSql1.Append("bFVQty,");
                strSql2.Append("" + model.bFVQty + ",");
            }
            if (model.iWIPtype != null)
            {
                strSql1.Append("iWIPtype,");
                strSql2.Append("" + model.iWIPtype + ",");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.iUnitQuantity != null)
            {
                strSql1.Append("iUnitQuantity,");
                strSql2.Append("" + model.iUnitQuantity + ",");
            }
            if (model.cBatch != null)
            {
                strSql1.Append("cBatch,");
                strSql2.Append("'" + model.cBatch + "',");
            }
            if (model.OpComponentId != null)
            {
                strSql1.Append("OpComponentId,");
                strSql2.Append("" + model.OpComponentId + ",");
            }
            if (model.SubFlag != null)
            {
                strSql1.Append("SubFlag,");
                strSql2.Append("" + model.SubFlag + ",");
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
            if (model.fbasenumn != null)
            {
                strSql1.Append("fbasenumn,");
                strSql2.Append("" + model.fbasenumn + ",");
            }
            if (model.iUnitNum != null)
            {
                strSql1.Append("iUnitNum,");
                strSql2.Append("" + model.iUnitNum + ",");
            }
            if (model.iNum != null)
            {
                strSql1.Append("iNum,");
                strSql2.Append("" + model.iNum + ",");
            }
            if (model.iSendNum != null)
            {
                strSql1.Append("iSendNum,");
                strSql2.Append("" + model.iSendNum + ",");
            }
            if (model.cUnitID != null)
            {
                strSql1.Append("cUnitID,");
                strSql2.Append("'" + model.cUnitID + "',");
            }
            if (model.iComplementQty != null)
            {
                strSql1.Append("iComplementQty,");
                strSql2.Append("" + model.iComplementQty + ",");
            }
            if (model.iComplementNum != null)
            {
                strSql1.Append("iComplementNum,");
                strSql2.Append("" + model.iComplementNum + ",");
            }
            if (model.fTransQty != null)
            {
                strSql1.Append("fTransQty,");
                strSql2.Append("" + model.fTransQty + ",");
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
            if (model.sotype != null)
            {
                strSql1.Append("sotype,");
                strSql2.Append("" + model.sotype + ",");
            }
            if (model.sodid != null)
            {
                strSql1.Append("sodid,");
                strSql2.Append("'" + model.sodid + "',");
            }
            if (model.csocode != null)
            {
                strSql1.Append("csocode,");
                strSql2.Append("'" + model.csocode + "',");
            }
            if (model.irowno != null)
            {
                strSql1.Append("irowno,");
                strSql2.Append("" + model.irowno + ",");
            }
            if (model.cdemandmemo != null)
            {
                strSql1.Append("cdemandmemo,");
                strSql2.Append("'" + model.cdemandmemo + "',");
            }
            if (model.cdetailsdemandcode != null)
            {
                strSql1.Append("cdetailsdemandcode,");
                strSql2.Append("'" + model.cdetailsdemandcode + "',");
            }
            if (model.cdetailsdemandmemo != null)
            {
                strSql1.Append("cdetailsdemandmemo,");
                strSql2.Append("'" + model.cdetailsdemandmemo + "',");
            }
            if (model.csendtype != null)
            {
                strSql1.Append("csendtype,");
                strSql2.Append("'" + model.csendtype + "',");
            }
            if (model.fsendapplyqty != null)
            {
                strSql1.Append("fsendapplyqty,");
                strSql2.Append("" + model.fsendapplyqty + ",");
            }
            if (model.fsendapplynum != null)
            {
                strSql1.Append("fsendapplynum,");
                strSql2.Append("" + model.fsendapplynum + ",");
            }
            if (model.fapplyqty != null)
            {
                strSql1.Append("fapplyqty,");
                strSql2.Append("" + model.fapplyqty + ",");
            }
            if (model.fapplynum != null)
            {
                strSql1.Append("fapplynum,");
                strSql2.Append("" + model.fapplynum + ",");
            }
            if (model.cbMemo != null)
            {
                strSql1.Append("cbMemo,");
                strSql2.Append("'" + model.cbMemo + "',");
            }
            if (model.csubsysbarcode != null)
            {
                strSql1.Append("csubsysbarcode,");
                strSql2.Append("'" + model.csubsysbarcode + "',");
            }
            if (model.iPickQty != null)
            {
                strSql1.Append("iPickQty,");
                strSql2.Append("" + model.iPickQty + ",");
            }
            if (model.iPickNum != null)
            {
                strSql1.Append("iPickNum,");
                strSql2.Append("" + model.iPickNum + ",");
            }
            if (model.iProductType != null)
            {
                strSql1.Append("iProductType,");
                strSql2.Append("" + model.iProductType + ",");
            }
            strSql.Append("insert into @u8.OM_MOMaterials(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1, 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1, 1));
            strSql.Append(")");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

