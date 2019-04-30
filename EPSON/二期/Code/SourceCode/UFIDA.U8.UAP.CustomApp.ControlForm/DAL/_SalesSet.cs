using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_SalesSet
    /// </summary>
    public partial class _SalesSet
    {
        public _SalesSet()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string GLCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from _SalesSet");
            strSql.Append(" where GLCode='" + GLCode + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._SalesSet model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.iID != null)
            {
                strSql1.Append("iID,");
                strSql2.Append("" + model.iID + ",");
            }
            if (model.Creater != null)
            {
                strSql1.Append("Creater,");
                strSql2.Append("'" + model.Creater + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.SalesType != null)
            {
                strSql1.Append("SalesType,");
                strSql2.Append("'" + model.SalesType + "',");
            }
            if (model.Headtext != null)
            {
                strSql1.Append("Headtext,");
                strSql2.Append("'" + model.Headtext + "',");
            }
            if (model.GLCode != null)
            {
                strSql1.Append("GLCode,");
                strSql2.Append("'" + model.GLCode + "',");
            }
            if (model.Internalorder != null)
            {
                strSql1.Append("Internalorder,");
                strSql2.Append("'" + model.Internalorder + "',");
            }
            if (model.ProfitCenter != null)
            {
                strSql1.Append("ProfitCenter,");
                strSql2.Append("'" + model.ProfitCenter + "',");
            }
            if (model.ItemText != null)
            {
                strSql1.Append("ItemText,");
                strSql2.Append("'" + model.ItemText + "',");
            }
            if (model.ItemText2 != null)
            {
                strSql1.Append("ItemText2,");
                strSql2.Append("'" + model.ItemText2 + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            strSql.Append("insert into _SalesSet(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._SalesSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _SalesSet set ");
            //if (model.iID != null)
            //{
            //    strSql.Append("iID=" + model.iID + ",");
            //}
            //else
            //{
            //    strSql.Append("iID= null ,");
            //}
            if (model.Creater != null)
            {
                strSql.Append("Creater='" + model.Creater + "',");
            }
            else
            {
                strSql.Append("Creater= null ,");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
            }
            else
            {
                strSql.Append("CreateDate= null ,");
            }
            if (model.SalesType != null)
            {
                strSql.Append("SalesType='" + model.SalesType + "',");
            }
            else
            {
                strSql.Append("SalesType= null ,");
            }
            if (model.Headtext != null)
            {
                strSql.Append("Headtext='" + model.Headtext + "',");
            }
            else
            {
                strSql.Append("Headtext= null ,");
            }
            if (model.Internalorder != null)
            {
                strSql.Append("Internalorder='" + model.Internalorder + "',");
            }
            else
            {
                strSql.Append("Internalorder= null ,");
            }
            if (model.ProfitCenter != null)
            {
                strSql.Append("ProfitCenter='" + model.ProfitCenter + "',");
            }
            else
            {
                strSql.Append("ProfitCenter= null ,");
            }
            if (model.ItemText != null)
            {
                strSql.Append("ItemText='" + model.ItemText + "',");
            }
            else
            {
                strSql.Append("ItemText= null ,");
            }
            if (model.ItemText2 != null)
            {
                strSql.Append("ItemText2='" + model.ItemText2 + "',");
            }
            else
            {
                strSql.Append("ItemText2= null ,");
            }
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
            strSql.Append(" where SalesType='" + model.SalesType + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string SalesType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _SalesSet ");
            strSql.Append(" where SalesType='" + SalesType + "' ");
            return (strSql.ToString());

        }		

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

