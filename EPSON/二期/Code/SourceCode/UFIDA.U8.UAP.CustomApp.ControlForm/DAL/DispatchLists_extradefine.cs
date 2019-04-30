using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:DispatchLists_extradefine
    /// </summary>
    public partial class DispatchLists_extradefine
    {
        public DispatchLists_extradefine()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.DispatchLists_extradefine model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.iDLsID != null)
            {
                strSql1.Append("iDLsID,");
                strSql2.Append("" + model.iDLsID + ",");
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
            if (model.cbdefine3 != null)
            {
                strSql1.Append("cbdefine3,");
                strSql2.Append("'" + model.cbdefine3 + "',");
            }
            if (model.cbdefine4 != null)
            {
                strSql1.Append("cbdefine4,");
                strSql2.Append("" + model.cbdefine4 + ",");
            }
            if (model.cbdefine5 != null)
            {
                strSql1.Append("cbdefine5,");
                strSql2.Append("'" + model.cbdefine5 + "',");
            }
            if (model.cbdefine6 != null)
            {
                strSql1.Append("cbdefine6,");
                strSql2.Append("'" + model.cbdefine6 + "',");
            }
            if (model.cbdefine7 != null)
            {
                strSql1.Append("cbdefine7,");
                strSql2.Append("'" + model.cbdefine7 + "',");
            }
            if (model.cbdefine8 != null)
            {
                strSql1.Append("cbdefine8,");
                strSql2.Append("'" + model.cbdefine8 + "',");
            }
            if (model.cbdefine9 != null)
            {
                strSql1.Append("cbdefine9,");
                strSql2.Append("'" + model.cbdefine9 + "',");
            }
            if (model.cbdefine10 != null)
            {
                strSql1.Append("cbdefine10,");
                strSql2.Append("'" + model.cbdefine10 + "',");
            }
            strSql.Append("insert into DispatchLists_extradefine(");
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

