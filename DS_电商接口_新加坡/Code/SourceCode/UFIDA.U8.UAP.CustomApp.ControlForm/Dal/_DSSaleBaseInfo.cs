using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_DSSaleBaseInfo
    /// </summary>
    public partial class _DSSaleBaseInfo
    {
        public _DSSaleBaseInfo()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._DSSaleBaseInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cSTCode != null)
            {
                strSql1.Append("cSTCode,");
                strSql2.Append("'" + model.cSTCode + "',");
            }
            if (model.bDS != null)
            {
                strSql1.Append("bDS,");
                strSql2.Append("" + (model.bDS ? 1 : 0) + ",");
            }
          
            strSql.Append("insert into _DSSaleBaseInfo(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._DSSaleBaseInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _DSSaleBaseInfo set ");
            if (model.bDS != null)
            {
                strSql.Append("bDS=" + (model.bDS ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("bDS= null ,");
            }
          
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where cSTCode='" + model.cSTCode + "' ");
            return (strSql.ToString());
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string cSTCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _DSSaleBaseInfo");
            strSql.Append(" where cSTCode='" + cSTCode + "' ");
            return (strSql.ToString());
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

