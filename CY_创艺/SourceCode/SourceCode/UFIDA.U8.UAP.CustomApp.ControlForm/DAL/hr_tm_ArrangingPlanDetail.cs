using System;
using System.Data;
using System.Text;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:hr_tm_ArrangingPlanDetail
    /// </summary>
    public partial class hr_tm_ArrangingPlanDetail
    {
        public hr_tm_ArrangingPlanDetail()
        { }
        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.hr_tm_ArrangingPlanDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.VoucherID != null)
            {
                strSql1.Append("VoucherID,");
                strSql2.Append("'" + model.VoucherID + "',");
            }
            if (model.Date != null)
            {
                strSql1.Append("Date,");
                strSql2.Append("'" + model.Date + "',");
            }
            if (model.DutyCode != null)
            {
                strSql1.Append("DutyCode,");
                strSql2.Append("'" + model.DutyCode + "',");
            }
            if (model.DutyPepole != null)
            {
                strSql1.Append("DutyPepole,");
                strSql2.Append("'" + model.DutyPepole + "',");
            }
            if (model.DutyPepoleNames != null)
            {
                strSql1.Append("DutyPepoleNames,");
                strSql2.Append("'" + model.DutyPepoleNames + "',");
            }
            strSql.Append("insert into hr_tm_ArrangingPlanDetail(");
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

