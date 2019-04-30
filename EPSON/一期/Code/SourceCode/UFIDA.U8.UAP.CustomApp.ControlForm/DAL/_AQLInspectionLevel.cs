using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_AQL
    /// </summary>
    public partial class _AQLInspectionLevel
    {
        public _AQLInspectionLevel()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._AQLInspectionLevel model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.minQty != null)
            {
                strSql1.Append("minQty,");
                strSql2.Append("" + model.minQty + ",");
            }
            if (model.maxQty != null)
            {
                strSql1.Append("maxQty,");
                strSql2.Append("" + model.maxQty + ",");
            }
            if (model.Level1 != null)
            {
                strSql1.Append("Level1,");
                strSql2.Append("'" + model.Level1 + "',");
            }
            if (model.Level2 != null)
            {
                strSql1.Append("Level2,");
                strSql2.Append("'" + model.Level2 + "',");
            }
            if (model.Level3 != null)
            {
                strSql1.Append("Level3,");
                strSql2.Append("'" + model.Level3 + "',");
            }
            strSql.Append("insert into _AQLInspectionLevel(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._AQLInspectionLevel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _AQLInspectionLevel set ");
            if (model.minQty != null)
            {
                strSql.Append("minQty=" + model.minQty + ",");
            }
            else
            {
                strSql.Append("minQty= null ,");
            }
            if (model.maxQty != null)
            {
                strSql.Append("maxQty=" + model.maxQty + ",");
            }
            else
            {
                strSql.Append("maxQty= null ,");
            }
            if (model.Level1 != null)
            {
                strSql.Append("Level1='" + model.Level1 + "',");
            }
            else
            {
                strSql.Append("Level1= null ,");
            }
            if (model.Level2 != null)
            {
                strSql.Append("Level2='" + model.Level2 + "',");
            }
            else
            {
                strSql.Append("Level2= null ,");
            }
            if (model.Level3 != null)
            {
                strSql.Append("Level3='" + model.Level3 + "',");
            }
            else
            {
                strSql.Append("Level3= null ,");
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
            strSql.Append("delete from [_AQLInspectionLevel] ");
            return (" where iID=" + iID + "");
        }	
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

