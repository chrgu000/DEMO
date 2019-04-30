using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_AQLLevelMap
    /// </summary>
    public partial class _AQLLevelMap
    {
        public _AQLLevelMap()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._AQLLevelMap model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.CodeLetter != null)
            {
                strSql1.Append("CodeLetter,");
                strSql2.Append("'" + model.CodeLetter + "',");
            }
            if (model.AQLLevel != null)
            {
                strSql1.Append("AQLLevel,");
                strSql2.Append("" + model.AQLLevel + ",");
            }
            if (model.Accept != null)
            {
                strSql1.Append("Accept,");
                strSql2.Append("" + model.Accept + ",");
            }
            if (model.Reject != null)
            {
                strSql1.Append("Reject,");
                strSql2.Append("" + model.Reject + ",");
            }
            strSql.Append("insert into _AQLLevelMap(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._AQLLevelMap model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _AQLLevelMap set ");
            if (model.Accept != null)
            {
                strSql.Append("Accept=" + model.Accept + ",");
            }
            else
            {
                strSql.Append("Accept= null ,");
            }
            if (model.Reject != null)
            {
                strSql.Append("Reject=" + model.Reject + ",");
            }
            else
            {
                strSql.Append("Reject= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where CodeLetter='" + model.CodeLetter + "' and AQLLevel=" + model.AQLLevel + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string CodeLetter, decimal AQLLevel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _AQLLevelMap ");
            strSql.Append(" where CodeLetter='" + CodeLetter + "' and AQLLevel=" + AQLLevel + " ");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

