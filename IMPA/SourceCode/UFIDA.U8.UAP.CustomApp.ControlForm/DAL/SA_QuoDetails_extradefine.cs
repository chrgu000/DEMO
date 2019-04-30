using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:SA_QuoDetails_extradefine
    /// </summary>
    public partial class SA_QuoDetails_extradefine
    {
        public SA_QuoDetails_extradefine()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.SA_QuoDetails_extradefine model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.AutoID != null)
            {
                strSql1.Append("AutoID,");
                strSql2.Append("" + model.AutoID + ",");
            }
            if (model.cbdefine4 != null)
            {
                strSql1.Append("cbdefine4,");
                strSql2.Append("'" + model.cbdefine4 + "',");
            }
            if (model.cbdefine5 != null)
            {
                strSql1.Append("cbdefine5,");
                strSql2.Append("" + model.cbdefine5 + ",");
            }
            strSql.Append("insert into SA_QuoDetails_extradefine(");
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

