using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace ClsU8.DAL
{
    /// <summary>
    /// 数据访问类:PU_AppVouch
    /// </summary>
    public partial class PU_AppVouch
    {
        public PU_AppVouch()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(ClsU8.Model.PU_AppVouch model)
        {

            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            //if (model.ufts != null)
            //{
            //    strSql1.Append("ufts,");
            //    strSql2.Append("" + model.ufts + ",");
            //}
            if (model.iVTid != null)
            {
                strSql1.Append("iVTid,");
                strSql2.Append("" + model.iVTid + ",");
            }
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
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
            if (model.cBusType != null)
            {
                strSql1.Append("cBusType,");
                strSql2.Append("'" + model.cBusType + "',");
            }
            if (model.cMaker != null)
            {
                strSql1.Append("cMaker,");
                strSql2.Append("'" + model.cMaker + "',");
            }
            if (model.cVerifier != null)
            {
                strSql1.Append("cVerifier,");
                strSql2.Append("'" + model.cVerifier + "',");
            }
            if (model.cCloser != null)
            {
                strSql1.Append("cCloser,");
                strSql2.Append("'" + model.cCloser + "',");
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
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.cLocker != null)
            {
                strSql1.Append("cLocker,");
                strSql2.Append("'" + model.cLocker + "',");
            }
            if (model.iverifystateex != null)
            {
                strSql1.Append("iverifystateex,");
                strSql2.Append("" + model.iverifystateex + ",");
            }
            if (model.ireturncount != null)
            {
                strSql1.Append("ireturncount,");
                strSql2.Append("" + model.ireturncount + ",");
            }
            if (model.IsWfControlled != null)
            {
                strSql1.Append("IsWfControlled,");
                strSql2.Append("" + (model.IsWfControlled ? 1 : 0) + ",");
            }
            if (model.cMakeTime != null)
            {
                strSql1.Append("cMakeTime,");
                strSql2.Append("'" + model.cMakeTime + "',");
            }
            if (model.cModifyTime != null)
            {
                strSql1.Append("cModifyTime,");
                strSql2.Append("'" + model.cModifyTime + "',");
            }
            if (model.cAuditTime != null)
            {
                strSql1.Append("cAuditTime,");
                strSql2.Append("'" + model.cAuditTime + "',");
            }
            if (model.cAuditDate != null)
            {
                strSql1.Append("cAuditDate,");
                strSql2.Append("'" + model.cAuditDate + "',");
            }
            if (model.cModifyDate != null)
            {
                strSql1.Append("cModifyDate,");
                strSql2.Append("'" + model.cModifyDate + "',");
            }
            if (model.cReviser != null)
            {
                strSql1.Append("cReviser,");
                strSql2.Append("'" + model.cReviser + "',");
            }
            if (model.cchanger != null)
            {
                strSql1.Append("cchanger,");
                strSql2.Append("'" + model.cchanger + "',");
            }
            if (model.iBG_OverFlag != null)
            {
                strSql1.Append("iBG_OverFlag,");
                strSql2.Append("" + model.iBG_OverFlag + ",");
            }
            if (model.cBG_Auditor != null)
            {
                strSql1.Append("cBG_Auditor,");
                strSql2.Append("'" + model.cBG_Auditor + "',");
            }
            if (model.cBG_AuditTime != null)
            {
                strSql1.Append("cBG_AuditTime,");
                strSql2.Append("'" + model.cBG_AuditTime + "',");
            }
            if (model.ControlResult != null)
            {
                strSql1.Append("ControlResult,");
                strSql2.Append("" + model.ControlResult + ",");
            }
            if (model.iflowid != null)
            {
                strSql1.Append("iflowid,");
                strSql2.Append("" + model.iflowid + ",");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.ccleanver != null)
            {
                strSql1.Append("ccleanver,");
                strSql2.Append("'" + model.ccleanver + "',");
            }
            if (model.dCloseDate != null)
            {
                strSql1.Append("dCloseDate,");
                strSql2.Append("'" + model.dCloseDate + "',");
            }
            if (model.dCloseTime != null)
            {
                strSql1.Append("dCloseTime,");
                strSql2.Append("'" + model.dCloseTime + "',");
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
            if (model.cChangVerifier != null)
            {
                strSql1.Append("cChangVerifier,");
                strSql2.Append("'" + model.cChangVerifier + "',");
            }
            if (model.cChangAuditTime != null)
            {
                strSql1.Append("cChangAuditTime,");
                strSql2.Append("'" + model.cChangAuditTime + "',");
            }
            if (model.cChangAuditDate != null)
            {
                strSql1.Append("cChangAuditDate,");
                strSql2.Append("'" + model.cChangAuditDate + "',");
            }
            strSql.Append("insert into PU_AppVouch(");
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

