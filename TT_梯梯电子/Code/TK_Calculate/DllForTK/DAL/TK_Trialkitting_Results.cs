using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DllForTK.DAL
{
    /// <summary>
    /// 数据访问类:TK_Trialkitting_Results
    /// </summary>
    public partial class TK_Trialkitting_Results
    {
        public TK_Trialkitting_Results()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(DllForTK.Model.TK_Trialkitting_Results model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
           
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("N'" + model.GUID.ToString() + "',");
            }
            if (model.sTKVersion != null)
            {
                strSql1.Append("sTKVersion,");
                strSql2.Append("N'" + model.sTKVersion + "',");
            }
            if (model.sTKVersionType != null)
            {
                strSql1.Append("sTKVersionType,");
                strSql2.Append("N'" + model.sTKVersionType + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("N'" + model.dDate + "',");
            }
            if (model.Planner != null)
            {
                strSql1.Append("Planner,");
                strSql2.Append("N'" + model.Planner + "',");
            }
            if (model.ProdGroup != null)
            {
                strSql1.Append("ProdGroup,");
                strSql2.Append("N'" + model.ProdGroup + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("N'" + model.cInvCode + "',");
            }
            if (model.NetQty != null)
            {
                strSql1.Append("NetQty,");
                strSql2.Append("" + model.NetQty + ",");
            }
            if (model.Reorderpolicy != null)
            {
                strSql1.Append("Reorderpolicy,");
                strSql2.Append("N'" + model.Reorderpolicy + "',");
            }
            if (model.DayWO != null)
            {
                strSql1.Append("DayWO,");
                strSql2.Append("" + model.DayWO + ",");
            }
            if (model.QtyCurr != null)
            {
                strSql1.Append("QtyCurr,");
                strSql2.Append("" + model.QtyCurr + ",");
            }
            if (model.QtyWO != null)
            {
                strSql1.Append("QtyWO,");
                strSql2.Append("" + model.QtyWO + ",");
            }
            if (model.Qty != null)
            {
                strSql1.Append("Qty,");
                strSql2.Append("" + model.Qty + ",");
            }
            if (model.dtmQty != null)
            {
                strSql1.Append("dtmQty,");
                strSql2.Append("N'" + model.dtmQty + "',");
            }
            strSql.Append("insert into TK_Trialkitting_Results(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

