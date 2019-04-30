using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_AlocationProportion
    /// </summary>
    public partial class _AlocationProportion
    {
        public _AlocationProportion()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._AlocationProportion model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.CostType != null)
            {
                strSql1.Append("CostType,");
                strSql2.Append("'" + model.CostType + "',");
            }
            if (model.cDepCode != null)
            {
                strSql1.Append("cDepCode,");
                strSql2.Append("'" + model.cDepCode + "',");
            }
            if (model.dPercentage != null)
            {
                strSql1.Append("dPercentage,");
                strSql2.Append("" + model.dPercentage + ",");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            strSql.Append("insert into _AlocationProportion(");
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

