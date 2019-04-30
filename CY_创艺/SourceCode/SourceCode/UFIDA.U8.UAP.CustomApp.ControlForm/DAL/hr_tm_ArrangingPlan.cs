using System;
using System.Data;
using System.Text;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:hr_tm_ArrangingPlan
    /// </summary>
    public partial class hr_tm_ArrangingPlan
    {
        public hr_tm_ArrangingPlan()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.hr_tm_ArrangingPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.VoucherId != null)
            {
                strSql1.Append("VoucherId,");
                strSql2.Append("'" + model.VoucherId + "',");
            }
            if (model.DeptCode != null)
            {
                strSql1.Append("DeptCode,");
                strSql2.Append("'" + model.DeptCode + "',");
            }
            if (model.Year != null)
            {
                strSql1.Append("Year,");
                strSql2.Append("'" + model.Year + "',");
            }
            if (model.Week != null)
            {
                strSql1.Append("Week,");
                strSql2.Append("'" + model.Week + "',");
            }
            if (model.HasChildDept != null)
            {
                strSql1.Append("HasChildDept,");
                strSql2.Append("" + (model.HasChildDept ? 1 : 0) + ",");
            }
            if (model.BeginDate != null)
            {
                strSql1.Append("BeginDate,");
                strSql2.Append("'" + model.BeginDate + "',");
            }
            if (model.EndDate != null)
            {
                strSql1.Append("EndDate,");
                strSql2.Append("'" + model.EndDate + "',");
            }
            if (model.SelDutys != null)
            {
                strSql1.Append("SelDutys,");
                strSql2.Append("'" + model.SelDutys + "',");
            }
            if (model.PeriodType != null)
            {
                strSql1.Append("PeriodType,");
                strSql2.Append("'" + model.PeriodType + "',");
            }
            if (model.vRemark != null)
            {
                strSql1.Append("vRemark,");
                strSql2.Append("'" + model.vRemark + "',");
            }
            if (model.cAuditor != null)
            {
                strSql1.Append("cAuditor,");
                strSql2.Append("'" + model.cAuditor + "',");
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
            strSql.Append("insert into hr_tm_ArrangingPlan(");
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

