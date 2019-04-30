using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DllForTK.DAL
{
    /// <summary>
    /// 数据访问类:TK_Trialkit_Calculate
    /// </summary>
    public partial class TK_Trialkit_Calculate
    {
        public TK_Trialkit_Calculate()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(DllForTK.Model.TK_Trialkit_Calculate model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

            if (model.sTKVersion != null)
            {
                strSql1.Append("sTKVersion,");
                strSql2.Append("N'" + model.sTKVersion + "',");
            }
            if (model.sTKVersion != null)
            {
                strSql1.Append("sTKVersionType,");
                strSql2.Append("N'" + model.sTKVersionType + "',");
            }
            if (model.sDataVersion != null)
            {
                strSql1.Append("sDataVersion,");
                strSql2.Append("N'" + model.sDataVersion + "',");
            }
            if (model.iID_NetRequirement_Sum != null)
            {
                strSql1.Append("iID_NetRequirement_Sum,");
                strSql2.Append("" + model.iID_NetRequirement_Sum + ",");
            }
            if (model.toplevel != null)
            {
                strSql1.Append("toplevel,");
                strSql2.Append("N'" + model.toplevel + "',");
            }
            if (model.Qty_toplevel != null)
            {
                strSql1.Append("Qty_toplevel,");
                strSql2.Append("" + model.Qty_toplevel + ",");
            }
            if (model.dDate_toplevel != null)
            {
                strSql1.Append("dDate_toplevel,");
                strSql2.Append("N'" + model.dDate_toplevel + "',");
            }
            if (model.sProductGroup != null)
            {
                strSql1.Append("sProductGroup,");
                strSql2.Append("N'" + model.sProductGroup + "',");
            }
            if (model.child != null)
            {
                strSql1.Append("child,");
                strSql2.Append("N'" + model.child + "',");
            }
            if (model.childCycle != null)
            {
                strSql1.Append("childCycle,");
                strSql2.Append("" + model.childCycle + ",");
            }
            if (model.childsCycle != null)
            {
                strSql1.Append("childsCycle,");
                strSql2.Append("" + model.childsCycle + ",");
            }
            if (model.Qty_bom != null)
            {
                strSql1.Append("Qty_bom,");
                strSql2.Append("" + model.Qty_bom + ",");
            }
            if (model.Cumqty_bom != null)
            {
                strSql1.Append("Cumqty_bom,");
                strSql2.Append("" + model.Cumqty_bom + ",");
            }
            if (model.childsm != null)
            {
                strSql1.Append("childsm,");
                strSql2.Append("N'" + model.childsm + "',");
            }
            if (model.depth != null)
            {
                strSql1.Append("depth,");
                strSql2.Append("N'" + model.depth + "',");
            }
            if (model.qtyChild != null)
            {
                strSql1.Append("qtyChild,");
                strSql2.Append("N'" + model.qtyChild + "',");
            }
            if (model.dtmStart != null)
            {
                strSql1.Append("dtmStart,");
                strSql2.Append("N'" + model.dtmStart + "',");
            }
            if (model.dtmEnd != null)
            {
                strSql1.Append("dtmEnd,");
                strSql2.Append("N'" + model.dtmEnd + "',");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("N'" + model.CreateUid + "',");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("N'" + model.dtmCreate + "',");
            }
            strSql.Append("insert into TK_Trialkit_Calculate(");
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

