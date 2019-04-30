using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:SA_QuoMain_extradefine
    /// </summary>
    public partial class SA_QuoMain_extradefine
    {
        public SA_QuoMain_extradefine()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.SA_QuoMain_extradefine model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.chdefine1 != null)
            {
                strSql1.Append("chdefine1,");
                strSql2.Append("'" + model.chdefine1 + "',");
            }
            if (model.chdefine2 != null)
            {
                strSql1.Append("chdefine2,");
                strSql2.Append("'" + model.chdefine2 + "',");
            }
            if (model.chdefine3 != null)
            {
                strSql1.Append("chdefine3,");
                strSql2.Append("'" + model.chdefine3 + "',");
            }
            if (model.chdefine5 != null)
            {
                strSql1.Append("chdefine5,");
                strSql2.Append("'" + model.chdefine5 + "',");
            }
            if (model.chdefine6 != null)
            {
                strSql1.Append("chdefine6,");
                strSql2.Append("'" + model.chdefine6 + "',");
            }
            if (model.chdefine7 != null)
            {
                strSql1.Append("chdefine7,");
                strSql2.Append("'" + model.chdefine7 + "',");
            }
            strSql.Append("insert into SA_QuoMain_extradefine(");
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

