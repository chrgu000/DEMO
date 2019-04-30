using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_ActionFCost
    /// </summary>
    public partial class _ActionFCost
    {
        public _ActionFCost()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._ActionFCost model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.ActionCode != null)
            {
                strSql1.Append("ActionCode,");
                strSql2.Append("'" + model.ActionCode + "',");
            }
            if (model.MANHOUR != null)
            {
                strSql1.Append("MANHOUR,");
                strSql2.Append("'" + model.MANHOUR + "',");
            }
            if (model.Labour != null)
            {
                strSql1.Append("Labour,");
                strSql2.Append("" + model.Labour + ",");
            }
            if (model.Process != null)
            {
                strSql1.Append("Process,");
                strSql2.Append("" + model.Process + ",");
            }
            if (model.PlatingCost != null)
            {
                strSql1.Append("PlatingCost,");
                strSql2.Append("" + model.PlatingCost + ",");
            }
            if (model.Part != null)
            {
                strSql1.Append("Part,");
                strSql2.Append("" + model.Part + ",");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
            }
            if (model.dtmStart != null)
            {
                strSql1.Append("dtmStart,");
                strSql2.Append("'" + model.dtmStart + "',");
            }
            if (model.dtmEnd != null && model.dtmEnd > Convert.ToDateTime("2000-01-01"))
            {
                strSql1.Append("dtmEnd,");
                strSql2.Append("'" + model.dtmEnd + "',");
            }

            strSql.Append("insert into _ActionFCost(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
            
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._ActionFCost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _ActionFCost set ");
            if (model.Labour != null)
            {
                strSql.Append("Labour=" + model.Labour + ",");
            }
            else
            {
                strSql.Append("Labour= null ,");
            }
            if (model.Process != null)
            {
                strSql.Append("Process=" + model.Process + ",");
            }
            else
            {
                strSql.Append("Process= null ,");
            }
            if (model.PlatingCost != null)
            {
                strSql.Append("PlatingCost=" + model.PlatingCost + ",");
            }
            else
            {
                strSql.Append("PlatingCost= null ,");
            }
            if (model.Part != null)
            {
                strSql.Append("Part=" + model.Part + ",");
            }
            else
            {
                strSql.Append("Part= null ,");
            }
            if (model.MANHOUR != null)
            {
                strSql.Append("MANHOUR=" + model.MANHOUR + ",");
            }
            else
            {
                strSql.Append("MANHOUR= null ,");
            }
            if (model.cCusCode != null)
            {
                strSql.Append("cCusCode='" + model.cCusCode + "',");
            }
            else
            {
                strSql.Append("cCusCode= null ,");
            }
            if (model.cInvCode != null)
            {
                strSql.Append("cInvCode='" + model.cInvCode + "',");
            }
            else
            {
                strSql.Append("cInvCode= null ,");
            }
            if (model.ActionCode != null)
            {
                strSql.Append("ActionCode='" + model.ActionCode + "',");
            }
            else
            {
                strSql.Append("ActionCode= null ,");
            }
            if (model.dtmStart != null)
            {
                strSql.Append("dtmStart='" + model.dtmStart + "',");
            }
            else
            {
                strSql.Append("dtmStart= null ,");
            }
            if (model.dtmEnd != null && model.dtmEnd > Convert.ToDateTime("2000-01-01"))
            {
                strSql.Append("dtmEnd='" + model.dtmEnd + "',");
            }
            else
            {
                strSql.Append("dtmEnd= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

