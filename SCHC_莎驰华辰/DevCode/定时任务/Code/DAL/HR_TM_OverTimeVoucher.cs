using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 数据访问类:HR_TM_OverTimeVoucher
    /// </summary>
    public partial class HR_TM_OverTimeVoucher
    {
        public HR_TM_OverTimeVoucher()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.HR_TM_OverTimeVoucher model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.VoucherID != null)
            {
                strSql1.Append("VoucherID,");
                strSql2.Append("'" + model.VoucherID + "',");
            }
            if (model.VoucherCode != null)
            {
                strSql1.Append("VoucherCode,");
                strSql2.Append("'" + model.VoucherCode + "',");
            }
            if (model.cDept_num != null)
            {
                strSql1.Append("cDept_num,");
                strSql2.Append("'" + model.cDept_num + "',");
            }
            if (model.vApprover != null)
            {
                strSql1.Append("vApprover,");
                strSql2.Append("'" + model.vApprover + "',");
            }
            if (model.vJbCode != null)
            {
                strSql1.Append("vJbCode,");
                strSql2.Append("'" + model.vJbCode + "',");
            }
            if (model.iComputeType != null)
            {
                strSql1.Append("iComputeType,");
                strSql2.Append("" + model.iComputeType + ",");
            }
            if (model.vReason != null)
            {
                strSql1.Append("vReason,");
                strSql2.Append("'" + model.vReason + "',");
            }
            if (model.vRemark != null)
            {
                strSql1.Append("vRemark,");
                strSql2.Append("'" + model.vRemark + "',");
            }
            if (model.dJbDate != null)
            {
                strSql1.Append("dJbDate,");
                strSql2.Append("'" + model.dJbDate + "',");
            }
            if (model.nManHours != null)
            {
                strSql1.Append("nManHours,");
                strSql2.Append("" + model.nManHours + ",");
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
            if (model.iBeginCardAhead != null)
            {
                strSql1.Append("iBeginCardAhead,");
                strSql2.Append("" + model.iBeginCardAhead + ",");
            }
            if (model.iEndCardForward != null)
            {
                strSql1.Append("iEndCardForward,");
                strSql2.Append("" + model.iEndCardForward + ",");
            }
            if (model.rFreeCardMode != null)
            {
                strSql1.Append("rFreeCardMode,");
                strSql2.Append("" + model.rFreeCardMode + ",");
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
            if (model.bLastFlag != null)
            {
                strSql1.Append("bLastFlag,");
                strSql2.Append("" + (model.bLastFlag ? 1 : 0) + ",");
            }
            if (model.iRecordId != null)
            {
                strSql1.Append("iRecordId,");
                strSql2.Append("" + model.iRecordId + ",");
            }
            if (model.bAuditFlag != null)
            {
                strSql1.Append("bAuditFlag,");
                strSql2.Append("" + model.bAuditFlag + ",");
            }
            if (model.cAuditor != null)
            {
                strSql1.Append("cAuditor,");
                strSql2.Append("'" + model.cAuditor + "',");
            }
            if (model.cAuditorNum != null)
            {
                strSql1.Append("cAuditorNum,");
                strSql2.Append("'" + model.cAuditorNum + "',");
            }
            if (model.cCreator != null)
            {
                strSql1.Append("cCreator,");
                strSql2.Append("'" + model.cCreator + "',");
            }
            if (model.cCreatorNum != null)
            {
                strSql1.Append("cCreatorNum,");
                strSql2.Append("'" + model.cCreatorNum + "',");
            }
            if (model.cOperator != null)
            {
                strSql1.Append("cOperator,");
                strSql2.Append("'" + model.cOperator + "',");
            }
            if (model.cOperatorNum != null)
            {
                strSql1.Append("cOperatorNum,");
                strSql2.Append("'" + model.cOperatorNum + "',");
            }
            if (model.dOperatTime != null)
            {
                strSql1.Append("dOperatTime,");
                strSql2.Append("'" + model.dOperatTime + "',");
            }
            if (model.dAuditTime != null)
            {
                strSql1.Append("dAuditTime,");
                strSql2.Append("'" + model.dAuditTime + "',");
            }
            if (model.dCreatTime != null)
            {
                strSql1.Append("dCreatTime,");
                strSql2.Append("'" + model.dCreatTime + "',");
            }
            if (model.rDealType != null)
            {
                strSql1.Append("rDealType,");
                strSql2.Append("'" + model.rDealType + "',");
            }
            if (model.cExamineApproveType != null)
            {
                strSql1.Append("cExamineApproveType,");
                strSql2.Append("" + model.cExamineApproveType + ",");
            }
            strSql.Append("insert into HR_TM_OverTimeVoucher(");
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

