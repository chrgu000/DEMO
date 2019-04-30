using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 数据访问类:hr_tm_SignCardData
    /// </summary>
    public partial class hr_tm_SignCardData
    {
        public hr_tm_SignCardData()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.hr_tm_SignCardData model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.uRecordId != null)
            {
                strSql1.Append("uRecordId,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.cPsn_Num != null)
            {
                strSql1.Append("cPsn_Num,");
                strSql2.Append("'" + model.cPsn_Num + "',");
            }
            if (model.vCardNo != null)
            {
                strSql1.Append("vCardNo,");
                strSql2.Append("'" + model.vCardNo + "',");
            }
            if (model.dDateTime != null)
            {
                strSql1.Append("dDateTime,");
                strSql2.Append("'" + model.dDateTime + "',");
            }
            if (model.bDuty != null)
            {
                strSql1.Append("bDuty,");
                strSql2.Append("" + (model.bDuty ? 1 : 0) + ",");
            }
            if (model.bOverTime != null)
            {
                strSql1.Append("bOverTime,");
                strSql2.Append("" + (model.bOverTime ? 1 : 0) + ",");
            }
            if (model.bManual != null)
            {
                strSql1.Append("bManual,");
                strSql2.Append("" + (model.bManual ? 1 : 0) + ",");
            }
            if (model.iPeriodId != null)
            {
                strSql1.Append("iPeriodId,");
                strSql2.Append("'" + model.iPeriodId + "',");
            }
            if (model.iFlag != null)
            {
                strSql1.Append("iFlag,");
                strSql2.Append("" + model.iFlag + ",");
            }
            if (model.cOptPsn_Num != null)
            {
                strSql1.Append("cOptPsn_Num,");
                strSql2.Append("'" + model.cOptPsn_Num + "',");
            }
            if (model.dSysTime != null)
            {
                strSql1.Append("dSysTime,");
                strSql2.Append("'" + model.dSysTime + "',");
            }
            if (model.vRemark != null)
            {
                strSql1.Append("vRemark,");
                strSql2.Append("'" + model.vRemark + "',");
            }
            if (model.vReason != null)
            {
                strSql1.Append("vReason,");
                strSql2.Append("'" + model.vReason + "',");
            }
            if (model.dOldDateTime != null)
            {
                strSql1.Append("dOldDateTime,");
                strSql2.Append("'" + model.dOldDateTime + "',");
            }
            if (model.iRecordId != null)
            {
                strSql1.Append("iRecordId,");
                strSql2.Append("" + model.iRecordId + ",");
            }
            if (model.bLastFlag != null)
            {
                strSql1.Append("bLastFlag,");
                strSql2.Append("" + (model.bLastFlag ? 1 : 0) + ",");
            }
            if (model.vStatus1 != null)
            {
                strSql1.Append("vStatus1,");
                strSql2.Append("'" + model.vStatus1 + "',");
            }
            if (model.nStatus2 != null)
            {
                strSql1.Append("nStatus2,");
                strSql2.Append("" + model.nStatus2 + ",");
            }
            if (model.bEffect != null)
            {
                strSql1.Append("bEffect,");
                strSql2.Append("" + model.bEffect + ",");
            }
            if (model.bAuditFlag != null)
            {
                strSql1.Append("bAuditFlag,");
                strSql2.Append("" + (model.bAuditFlag ? 1 : 0) + ",");
            }
            if (model.cAuditorNum != null)
            {
                strSql1.Append("cAuditorNum,");
                strSql2.Append("'" + model.cAuditorNum + "',");
            }
            if (model.dAuditTime != null)
            {
                strSql1.Append("dAuditTime,");
                strSql2.Append("'" + model.dAuditTime + "',");
            }
            if (model.JobNumber != null)
            {
                strSql1.Append("JobNumber,");
                strSql2.Append("'" + model.JobNumber + "',");
            }
            if (model.nMachine_Num != null)
            {
                strSql1.Append("nMachine_Num,");
                strSql2.Append("'" + model.nMachine_Num + "',");
            }
            if (model.VoucherID != null)
            {
                strSql1.Append("VoucherID,");
                strSql2.Append("'" + model.VoucherID + "',");
            }
            if (model.cExamineApproveType != null)
            {
                strSql1.Append("cExamineApproveType,");
                strSql2.Append("" + model.cExamineApproveType + ",");
            }
            if (model.cMobileSiteCode != null)
            {
                strSql1.Append("cMobileSiteCode,");
                strSql2.Append("'" + model.cMobileSiteCode + "',");
            }
            if (model.cMobileSiteAddress != null)
            {
                strSql1.Append("cMobileSiteAddress,");
                strSql2.Append("'" + model.cMobileSiteAddress + "',");
            }
            if (model.cintitude != null)
            {
                strSql1.Append("cintitude,");
                strSql2.Append("'" + model.cintitude + "',");
            }
            if (model.cLatitude != null)
            {
                strSql1.Append("cLatitude,");
                strSql2.Append("'" + model.cLatitude + "',");
            }
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
            }
            strSql.Append("insert into hr_tm_SignCardData(");
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

