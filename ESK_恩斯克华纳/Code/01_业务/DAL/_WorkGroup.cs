using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace 业务.DAL
{
    /// <summary>
    /// 数据访问类:_WorkGroup
    /// </summary>
    public partial class _WorkGroup
    {
        public _WorkGroup()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(业务.Model._WorkGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.WorkGroup != null)
            {
                strSql1.Append("WorkGroup,");
                strSql2.Append("'" + model.WorkGroup + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            strSql.Append("insert into _WorkGroup(");
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
        public string Update(业务.Model._WorkGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _WorkGroup set ");
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(long iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _WorkGroup ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
        }		
     

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

