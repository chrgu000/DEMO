using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 数据访问类:hr_tm_OverTimeresult
    /// </summary>
    public partial class hr_tm_OverTimeresult
    {
        public hr_tm_OverTimeresult()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.hr_tm_OverTimeresult model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.uRecordId != null)
            {
                strSql1.Append("uRecordId,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.uOverTimeCode != null)
            {
                strSql1.Append("uOverTimeCode,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.cPsn_Num != null)
            {
                strSql1.Append("cPsn_Num,");
                strSql2.Append("'" + model.cPsn_Num + "',");
            }
            if (model.nOvertimeHours != null)
            {
                strSql1.Append("nOvertimeHours,");
                strSql2.Append("" + model.nOvertimeHours + ",");
            }
            if (model.nSubOVTime != null)
            {
                strSql1.Append("nSubOVTime,");
                strSql2.Append("" + model.nSubOVTime + ",");
            }
            if (model.vCardTime != null)
            {
                strSql1.Append("vCardTime,");
                strSql2.Append("'" + model.vCardTime + "',");
            }
            if (model.nManHours != null)
            {
                strSql1.Append("nManHours,");
                strSql2.Append("" + model.nManHours + ",");
            }
            if (model.dJbDate != null)
            {
                strSql1.Append("dJbDate,");
                strSql2.Append("'" + model.dJbDate + "',");
            }
            if (model.vJbCode != null)
            {
                strSql1.Append("vJbCode,");
                strSql2.Append("'" + model.vJbCode + "',");
            }
            if (model.vReason != null)
            {
                strSql1.Append("vReason,");
                strSql2.Append("'" + model.vReason + "',");
            }
            if (model.vApprover != null)
            {
                strSql1.Append("vApprover,");
                strSql2.Append("'" + model.vApprover + "',");
            }
            if (model.vRemark != null)
            {
                strSql1.Append("vRemark,");
                strSql2.Append("'" + model.vRemark + "',");
            }
            if (model.dBegintime != null)
            {
                strSql1.Append("dBegintime,");
                strSql2.Append("'" + model.dBegintime + "',");
            }
            if (model.dEndTime != null)
            {
                strSql1.Append("dEndTime,");
                strSql2.Append("'" + model.dEndTime + "',");
            }
            if (model.nMaxDelay != null)
            {
                strSql1.Append("nMaxDelay,");
                strSql2.Append("" + model.nMaxDelay + ",");
            }
            if (model.nMaxLeave != null)
            {
                strSql1.Append("nMaxLeave,");
                strSql2.Append("" + model.nMaxLeave + ",");
            }
            if (model.nAbsent0 != null)
            {
                strSql1.Append("nAbsent0,");
                strSql2.Append("" + model.nAbsent0 + ",");
            }
            if (model.nAbsent1 != null)
            {
                strSql1.Append("nAbsent1,");
                strSql2.Append("" + model.nAbsent1 + ",");
            }
            if (model.nRestTime != null)
            {
                strSql1.Append("nRestTime,");
                strSql2.Append("" + model.nRestTime + ",");
            }
            if (model.dDutyTime != null)
            {
                strSql1.Append("dDutyTime,");
                strSql2.Append("'" + model.dDutyTime + "',");
            }
            if (model.dOffTime != null)
            {
                strSql1.Append("dOffTime,");
                strSql2.Append("'" + model.dOffTime + "',");
            }
            if (model.bOverDate != null)
            {
                strSql1.Append("bOverDate,");
                strSql2.Append("" + model.bOverDate + ",");
            }
            if (model.bOverDate2 != null)
            {
                strSql1.Append("bOverDate2,");
                strSql2.Append("" + model.bOverDate2 + ",");
            }
            if (model.bPeriod != null)
            {
                strSql1.Append("bPeriod,");
                strSql2.Append("" + model.bPeriod + ",");
            }
            if (model.bCompute != null)
            {
                strSql1.Append("bCompute,");
                strSql2.Append("" + model.bCompute + ",");
            }
            if (model.iComputeType != null)
            {
                strSql1.Append("iComputeType,");
                strSql2.Append("" + model.iComputeType + ",");
            }
            if (model.dOVStartCard != null)
            {
                strSql1.Append("dOVStartCard,");
                strSql2.Append("'" + model.dOVStartCard + "',");
            }
            if (model.dOVEndCard != null)
            {
                strSql1.Append("dOVEndCard,");
                strSql2.Append("'" + model.dOVEndCard + "',");
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
            if (model.iActualOverMinute != null)
            {
                strSql1.Append("iActualOverMinute,");
                strSql2.Append("" + model.iActualOverMinute + ",");
            }
            if (model.cAuditorNum != null)
            {
                strSql1.Append("cAuditorNum,");
                strSql2.Append("'" + model.cAuditorNum + "',");
            }
            if (model.cAuditor != null)
            {
                strSql1.Append("cAuditor,");
                strSql2.Append("'" + model.cAuditor + "',");
            }
            if (model.dAuditTime != null)
            {
                strSql1.Append("dAuditTime,");
                strSql2.Append("'" + model.dAuditTime + "',");
            }
            if (model.bAuditFlag != null)
            {
                strSql1.Append("bAuditFlag,");
                strSql2.Append("" + (model.bAuditFlag ? 1 : 0) + ",");
            }
            if (model.cCreatorNum != null)
            {
                strSql1.Append("cCreatorNum,");
                strSql2.Append("'" + model.cCreatorNum + "',");
            }
            if (model.cCreator != null)
            {
                strSql1.Append("cCreator,");
                strSql2.Append("'" + model.cCreator + "',");
            }
            if (model.dCreatTime != null)
            {
                strSql1.Append("dCreatTime,");
                strSql2.Append("'" + model.dCreatTime + "',");
            }
            if (model.cOperatorNum != null)
            {
                strSql1.Append("cOperatorNum,");
                strSql2.Append("'" + model.cOperatorNum + "',");
            }
            if (model.cOperator != null)
            {
                strSql1.Append("cOperator,");
                strSql2.Append("'" + model.cOperator + "',");
            }
            if (model.dOperatTime != null)
            {
                strSql1.Append("dOperatTime,");
                strSql2.Append("'" + model.dOperatTime + "',");
            }
            if (model.rFreeCardMode != null)
            {
                strSql1.Append("rFreeCardMode,");
                strSql2.Append("'" + model.rFreeCardMode + "',");
            }
            if (model.JobNumber != null)
            {
                strSql1.Append("JobNumber,");
                strSql2.Append("'" + model.JobNumber + "',");
            }
            if (model.iLAbsentMinute != null)
            {
                strSql1.Append("iLAbsentMinute,");
                strSql2.Append("" + model.iLAbsentMinute + ",");
            }
            if (model.iEAbsentMinute != null)
            {
                strSql1.Append("iEAbsentMinute,");
                strSql2.Append("" + model.iEAbsentMinute + ",");
            }
            if (model.iAbsentMinute != null)
            {
                strSql1.Append("iAbsentMinute,");
                strSql2.Append("" + model.iAbsentMinute + ",");
            }
            if (model.rSignCardReason1 != null)
            {
                strSql1.Append("rSignCardReason1,");
                strSql2.Append("'" + model.rSignCardReason1 + "',");
            }
            if (model.rSignCardReason2 != null)
            {
                strSql1.Append("rSignCardReason2,");
                strSql2.Append("'" + model.rSignCardReason2 + "',");
            }
            if (model.nAbsentOverHours != null)
            {
                strSql1.Append("nAbsentOverHours,");
                strSql2.Append("" + model.nAbsentOverHours + ",");
            }
            if (model.dRealDutyTime != null)
            {
                strSql1.Append("dRealDutyTime,");
                strSql2.Append("'" + model.dRealDutyTime + "',");
            }
            if (model.dRealOffTime != null)
            {
                strSql1.Append("dRealOffTime,");
                strSql2.Append("'" + model.dRealOffTime + "',");
            }
            if (model.VoucherID != null)
            {
                strSql1.Append("VoucherID,");
                strSql2.Append("'" + model.VoucherID + "',");
            }
            if (model.cTimeUseless1 != null)
            {
                strSql1.Append("cTimeUseless1,");
                strSql2.Append("'" + model.cTimeUseless1 + "',");
            }
            if (model.cTimeUseless2 != null)
            {
                strSql1.Append("cTimeUseless2,");
                strSql2.Append("'" + model.cTimeUseless2 + "',");
            }
            if (model.nDeductedTime != null)
            {
                strSql1.Append("nDeductedTime,");
                strSql2.Append("" + model.nDeductedTime + ",");
            }
            if (model.nCanceledTime != null)
            {
                strSql1.Append("nCanceledTime,");
                strSql2.Append("" + model.nCanceledTime + ",");
            }
            if (model.nBalancedTime != null)
            {
                strSql1.Append("nBalancedTime,");
                strSql2.Append("" + model.nBalancedTime + ",");
            }
            if (model.dValidityDate != null)
            {
                strSql1.Append("dValidityDate,");
                strSql2.Append("'" + model.dValidityDate + "',");
            }
            if (model.cExamineApproveType != null)
            {
                strSql1.Append("cExamineApproveType,");
                strSql2.Append("" + model.cExamineApproveType + ",");
            }
            if (model.cInitPeriod != null)
            {
                strSql1.Append("cInitPeriod,");
                strSql2.Append("'" + model.cInitPeriod + "',");
            }
            if (model.nAvailableOverHours != null)
            {
                strSql1.Append("nAvailableOverHours,");
                strSql2.Append("" + model.nAvailableOverHours + ",");
            }
            if (model.iRowNo != null)
            {
                strSql1.Append("iRowNo,");
                strSql2.Append("" + model.iRowNo + ",");
            }
            if (model.hrts != null)
            {
                strSql1.Append("hrts,");
                strSql2.Append("" + model.hrts + ",");
            }
            if (model.concurrencyHrts != null)
            {
                strSql1.Append("concurrencyHrts,");
                strSql2.Append("" + model.concurrencyHrts + ",");
            }
            if (model.rDealType != null)
            {
                strSql1.Append("rDealType,");
                strSql2.Append("'" + model.rDealType + "',");
            }
            strSql.Append("insert into hr_tm_OverTimeresult(");
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

