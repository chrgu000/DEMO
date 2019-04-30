using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace TH.clsU8.DAL
{
    /// <summary>
    /// 数据访问类:SO_SODetails_extradefine
    /// </summary>
    public partial class SO_SODetails_extradefine
    {
        public SO_SODetails_extradefine()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.clsU8.Model.SO_SODetails_extradefine model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.iSOsID != null)
            {
                strSql1.Append("iSOsID,");
                strSql2.Append("" + model.iSOsID + ",");
            }
            if (model.cbdefine1 != null)
            {
                strSql1.Append("cbdefine1,");
                strSql2.Append("'" + model.cbdefine1 + "',");
            }
            if (model.cbdefine2 != null)
            {
                strSql1.Append("cbdefine2,");
                strSql2.Append("'" + model.cbdefine2 + "',");
            }
            if (model.cbdefine5 != null)
            {
                strSql1.Append("cbdefine5,");
                strSql2.Append("'" + model.cbdefine5 + "',");
            }
            strSql.Append("insert into SO_SODetails_extradefine(");
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

