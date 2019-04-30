using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_Defects
    /// </summary>
    public partial class _Defects
    {
        public _Defects()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._Defects model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cCusCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
            }
            if (model.DefectCode != null)
            {
                strSql1.Append("DefectCode,");
                strSql2.Append("'" + model.DefectCode + "',");
            }
            strSql.Append("insert into _Defects(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._Defects model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _Defects set ");
            if (model.cCusCode != null)
            {
                strSql.Append("cCusCode='" + model.cCusCode + "',");
            }
            else
            {
                strSql.Append("cCusCode= null ,");
            }
            if (model.DefectCode != null)
            {
                strSql.Append("DefectCode='" + model.DefectCode + "',");
            }
            else
            {
                strSql.Append("DefectCode= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
           return (strSql.ToString());

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _Defects ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());

        }		

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

