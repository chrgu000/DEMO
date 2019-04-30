using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:fitemss00
    /// </summary>
    public partial class fitemss00
    {
        public fitemss00()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists( string citemcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from fitemss00");
            strSql.Append(" where citemcode='" + citemcode + "'");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.fitemss00 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.citemcode != null)
            {
                strSql1.Append("citemcode,");
                strSql2.Append("'" + model.citemcode + "',");
            }
            if (model.citemname != null)
            {
                strSql1.Append("citemname,");
                strSql2.Append("'" + model.citemname + "',");
            }
            if (model.bclose != null)
            {
                strSql1.Append("bclose,");
                strSql2.Append("" + (model.bclose ? 1 : 0) + ",");
            }
            if (model.citemccode != null)
            {
                strSql1.Append("citemccode,");
                strSql2.Append("'" + model.citemccode + "',");
            }
            if (model.iotherused != null)
            {
                strSql1.Append("iotherused,");
                strSql2.Append("" + model.iotherused + ",");
            }
            if (model.金额 != null)
            {
                strSql1.Append("金额,");
                strSql2.Append("" + model.金额 + ",");
            }
            strSql.Append("insert into fitemss00(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model.fitemss00 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update fitemss00 set ");
          
            if (model.citemname != null)
            {
                strSql.Append("citemname='" + model.citemname + "',");
            }
            else
            {
                strSql.Append("citemname= null ,");
            }
            if (model.金额 != null)
            {
                strSql.Append("金额=" + model.金额 + ",");
            }
            else
            {
                strSql.Append("金额= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where citemcode='" + model.citemcode + "' and citemccode = '" + model.citemccode + "'");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

