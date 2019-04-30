using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:RdRecord08
    /// </summary>
    public partial class RdRecord08
    {
        public RdRecord08()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.RdRecord08 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.bRdFlag != null)
            {
                strSql1.Append("bRdFlag,");
                strSql2.Append("" + model.bRdFlag + ",");
            }
            if (model.cVouchType != null)
            {
                strSql1.Append("cVouchType,");
                strSql2.Append("'" + model.cVouchType + "',");
            }
            if (model.cBusType != null)
            {
                strSql1.Append("cBusType,");
                strSql2.Append("'" + model.cBusType + "',");
            }
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
            }
            if (model.cBusCode != null)
            {
                strSql1.Append("cBusCode,");
                strSql2.Append("'" + model.cBusCode + "',");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.cRdCode != null)
            {
                strSql1.Append("cRdCode,");
                strSql2.Append("'" + model.cRdCode + "',");
            }
            if (model.cDepCode != null)
            {
                strSql1.Append("cDepCode,");
                strSql2.Append("'" + model.cDepCode + "',");
            }
            if (model.cPersonCode != null)
            {
                strSql1.Append("cPersonCode,");
                strSql2.Append("'" + model.cPersonCode + "',");
            }
            if (model.cPTCode != null)
            {
                strSql1.Append("cPTCode,");
                strSql2.Append("'" + model.cPTCode + "',");
            }
            if (model.cSTCode != null)
            {
                strSql1.Append("cSTCode,");
                strSql2.Append("'" + model.cSTCode + "',");
            }
            if (model.cCusCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
            }
            if (model.cVenCode != null)
            {
                strSql1.Append("cVenCode,");
                strSql2.Append("'" + model.cVenCode + "',");
            }
            if (model.cOrderCode != null)
            {
                strSql1.Append("cOrderCode,");
                strSql2.Append("'" + model.cOrderCode + "',");
            }
            if (model.cARVCode != null)
            {
                strSql1.Append("cARVCode,");
                strSql2.Append("'" + model.cARVCode + "',");
            }
            if (model.cBillCode != null)
            {
                strSql1.Append("cBillCode,");
                strSql2.Append("" + model.cBillCode + ",");
            }
            if (model.cDLCode != null)
            {
                strSql1.Append("cDLCode,");
                strSql2.Append("" + model.cDLCode + ",");
            }
            if (model.cProBatch != null)
            {
                strSql1.Append("cProBatch,");
                strSql2.Append("'" + model.cProBatch + "',");
            }
            if (model.cHandler != null)
            {
                strSql1.Append("cHandler,");
                strSql2.Append("'" + model.cHandler + "',");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.bTransFlag != null)
            {
                strSql1.Append("bTransFlag,");
                strSql2.Append("" + (model.bTransFlag ? 1 : 0) + ",");
            }
            if (model.cAccounter != null)
            {
                strSql1.Append("cAccounter,");
                strSql2.Append("'" + model.cAccounter + "',");
            }
            if (model.cMaker != null)
            {
                strSql1.Append("cMaker,");
                strSql2.Append("'" + model.cMaker + "',");
            }
            if (model.cDefine1 != null)
            {
                strSql1.Append("cDefine1,");
                strSql2.Append("'" + model.cDefine1 + "',");
            }
            if (model.cDefine2 != null)
            {
                strSql1.Append("cDefine2,");
                strSql2.Append("'" + model.cDefine2 + "',");
            }
            if (model.cDefine3 != null)
            {
                strSql1.Append("cDefine3,");
                strSql2.Append("'" + model.cDefine3 + "',");
            }
            if (model.cDefine4 != null)
            {
                strSql1.Append("cDefine4,");
                strSql2.Append("'" + model.cDefine4 + "',");
            }
            if (model.cDefine5 != null)
            {
                strSql1.Append("cDefine5,");
                strSql2.Append("" + model.cDefine5 + ",");
            }
            if (model.cDefine6 != null)
            {
                strSql1.Append("cDefine6,");
                strSql2.Append("'" + model.cDefine6 + "',");
            }
            if (model.cDefine7 != null)
            {
                strSql1.Append("cDefine7,");
                strSql2.Append("" + model.cDefine7 + ",");
            }
            if (model.cDefine8 != null)
            {
                strSql1.Append("cDefine8,");
                strSql2.Append("'" + model.cDefine8 + "',");
            }
            if (model.cDefine9 != null)
            {
                strSql1.Append("cDefine9,");
                strSql2.Append("'" + model.cDefine9 + "',");
            }
            if (model.cDefine10 != null)
            {
                strSql1.Append("cDefine10,");
                strSql2.Append("'" + model.cDefine10 + "',");
            }
            if (model.dKeepDate != null)
            {
                strSql1.Append("dKeepDate,");
                strSql2.Append("'" + model.dKeepDate + "',");
            }
            if (model.dVeriDate != null)
            {
                strSql1.Append("dVeriDate,");
                strSql2.Append("'" + model.dVeriDate + "',");
            }
            if (model.bpufirst != null)
            {
                strSql1.Append("bpufirst,");
                strSql2.Append("" + (model.bpufirst ? 1 : 0) + ",");
            }
            if (model.biafirst != null)
            {
                strSql1.Append("biafirst,");
                strSql2.Append("" + (model.biafirst ? 1 : 0) + ",");
            }
            if (model.iMQuantity != null)
            {
                strSql1.Append("iMQuantity,");
                strSql2.Append("" + model.iMQuantity + ",");
            }
            if (model.dARVDate != null)
            {
                strSql1.Append("dARVDate,");
                strSql2.Append("'" + model.dARVDate + "',");
            }
            if (model.cChkCode != null)
            {
                strSql1.Append("cChkCode,");
                strSql2.Append("'" + model.cChkCode + "',");
            }
            if (model.dChkDate != null)
            {
                strSql1.Append("dChkDate,");
                strSql2.Append("'" + model.dChkDate + "',");
            }
            if (model.cChkPerson != null)
            {
                strSql1.Append("cChkPerson,");
                strSql2.Append("'" + model.cChkPerson + "',");
            }
            if (model.VT_ID != null)
            {
                strSql1.Append("VT_ID,");
                strSql2.Append("" + model.VT_ID + ",");
            }
            if (model.bIsSTQc != null)
            {
                strSql1.Append("bIsSTQc,");
                strSql2.Append("" + (model.bIsSTQc ? 1 : 0) + ",");
            }
            if (model.cDefine11 != null)
            {
                strSql1.Append("cDefine11,");
                strSql2.Append("'" + model.cDefine11 + "',");
            }
            if (model.cDefine12 != null)
            {
                strSql1.Append("cDefine12,");
                strSql2.Append("'" + model.cDefine12 + "',");
            }
            if (model.cDefine13 != null)
            {
                strSql1.Append("cDefine13,");
                strSql2.Append("'" + model.cDefine13 + "',");
            }
            if (model.cDefine14 != null)
            {
                strSql1.Append("cDefine14,");
                strSql2.Append("'" + model.cDefine14 + "',");
            }
            if (model.cDefine15 != null)
            {
                strSql1.Append("cDefine15,");
                strSql2.Append("" + model.cDefine15 + ",");
            }
            if (model.cDefine16 != null)
            {
                strSql1.Append("cDefine16,");
                strSql2.Append("" + model.cDefine16 + ",");
            }
            if (model.gspcheck != null)
            {
                strSql1.Append("gspcheck,");
                strSql2.Append("'" + model.gspcheck + "',");
            }
            if (model.ufts != null)
            {
                strSql1.Append("ufts,");
                strSql2.Append("" + model.ufts + ",");
            }
            if (model.iExchRate != null)
            {
                strSql1.Append("iExchRate,");
                strSql2.Append("" + model.iExchRate + ",");
            }
            if (model.cExch_Name != null)
            {
                strSql1.Append("cExch_Name,");
                strSql2.Append("'" + model.cExch_Name + "',");
            }
            if (model.bOMFirst != null)
            {
                strSql1.Append("bOMFirst,");
                strSql2.Append("" + (model.bOMFirst ? 1 : 0) + ",");
            }
            if (model.bFromPreYear != null)
            {
                strSql1.Append("bFromPreYear,");
                strSql2.Append("" + (model.bFromPreYear ? 1 : 0) + ",");
            }
            if (model.bIsLsQuery != null)
            {
                strSql1.Append("bIsLsQuery,");
                strSql2.Append("" + (model.bIsLsQuery ? 1 : 0) + ",");
            }
            if (model.bIsComplement != null)
            {
                strSql1.Append("bIsComplement,");
                strSql2.Append("" + model.bIsComplement + ",");
            }
            if (model.iDiscountTaxType != null)
            {
                strSql1.Append("iDiscountTaxType,");
                strSql2.Append("" + model.iDiscountTaxType + ",");
            }
            if (model.ireturncount != null)
            {
                strSql1.Append("ireturncount,");
                strSql2.Append("" + model.ireturncount + ",");
            }
            if (model.iverifystate != null)
            {
                strSql1.Append("iverifystate,");
                strSql2.Append("" + model.iverifystate + ",");
            }
            if (model.iswfcontrolled != null)
            {
                strSql1.Append("iswfcontrolled,");
                strSql2.Append("" + model.iswfcontrolled + ",");
            }
            if (model.cModifyPerson != null)
            {
                strSql1.Append("cModifyPerson,");
                strSql2.Append("'" + model.cModifyPerson + "',");
            }
            if (model.dModifyDate != null)
            {
                strSql1.Append("dModifyDate,");
                strSql2.Append("'" + model.dModifyDate + "',");
            }
            if (model.dnmaketime != null)
            {
                strSql1.Append("dnmaketime,");
                strSql2.Append("'" + model.dnmaketime + "',");
            }
            if (model.dnmodifytime != null)
            {
                strSql1.Append("dnmodifytime,");
                strSql2.Append("'" + model.dnmodifytime + "',");
            }
            if (model.dnverifytime != null)
            {
                strSql1.Append("dnverifytime,");
                strSql2.Append("'" + model.dnverifytime + "',");
            }
            if (model.bredvouch != null)
            {
                strSql1.Append("bredvouch,");
                strSql2.Append("" + model.bredvouch + ",");
            }
            if (model.iFlowId != null)
            {
                strSql1.Append("iFlowId,");
                strSql2.Append("" + model.iFlowId + ",");
            }
            if (model.cPZID != null)
            {
                strSql1.Append("cPZID,");
                strSql2.Append("'" + model.cPZID + "',");
            }
            if (model.cSourceLs != null)
            {
                strSql1.Append("cSourceLs,");
                strSql2.Append("'" + model.cSourceLs + "',");
            }
            if (model.cSourceCodeLs != null)
            {
                strSql1.Append("cSourceCodeLs,");
                strSql2.Append("'" + model.cSourceCodeLs + "',");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.ctransflag != null)
            {
                strSql1.Append("ctransflag,");
                strSql2.Append("'" + model.ctransflag + "',");
            }
            if (model.csysbarcode != null)
            {
                strSql1.Append("csysbarcode,");
                strSql2.Append("'" + model.csysbarcode + "',");
            }
            if (model.cCurrentAuditor != null)
            {
                strSql1.Append("cCurrentAuditor,");
                strSql2.Append("'" + model.cCurrentAuditor + "',");
            }
            strSql.Append("insert into RdRecord08(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

