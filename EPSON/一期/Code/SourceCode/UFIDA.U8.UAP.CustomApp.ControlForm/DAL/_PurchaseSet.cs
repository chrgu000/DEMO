using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_PurchaseSet
    /// </summary>
    public partial class _PurchaseSet
    {
        public _PurchaseSet()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string ReasonCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _PurchaseSet");
            strSql.Append(" where ReasonCode='" + ReasonCode + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._PurchaseSet model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ReasonCode != null)
            {
                strSql1.Append("ReasonCode,");
                strSql2.Append("'" + model.ReasonCode + "',");
            }
            if (model.Description != null)
            {
                strSql1.Append("Description,");
                strSql2.Append("'" + model.Description + "',");
            }
            if (model.CostCenter != null)
            {
                strSql1.Append("CostCenter,");
                strSql2.Append("'" + model.CostCenter + "',");
            }
            if (model.CostCentreDescription != null)
            {
                strSql1.Append("CostCentreDescription,");
                strSql2.Append("'" + model.CostCentreDescription + "',");
            }
            if (model.GLAccountCode != null)
            {
                strSql1.Append("GLAccountCode,");
                strSql2.Append("'" + model.GLAccountCode + "',");
            }
            if (model.GLAccountDescription != null)
            {
                strSql1.Append("GLAccountDescription,");
                strSql2.Append("'" + model.GLAccountDescription + "',");
            }
            if (model.InternalOrder != null)
            {
                strSql1.Append("InternalOrder,");
                strSql2.Append("'" + model.InternalOrder + "',");
            }
            if (model.Headtext != null)
            {
                strSql1.Append("Headtext,");
                strSql2.Append("'" + model.Headtext + "',");
            }
            if (model.Reasonname != null)
            {
                strSql1.Append("Reasonname,");
                strSql2.Append("'" + model.Reasonname + "',");
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
            strSql.Append("insert into _PurchaseSet(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._PurchaseSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _PurchaseSet set ");
            if (model.Description != null)
            {
                strSql.Append("Description='" + model.Description + "',");
            }
            else
            {
                strSql.Append("Description= null ,");
            }
            if (model.CostCenter != null)
            {
                strSql.Append("CostCenter='" + model.CostCenter + "',");
            }
            else
            {
                strSql.Append("CostCenter= null ,");
            }
            if (model.CostCentreDescription != null)
            {
                strSql.Append("CostCentreDescription='" + model.CostCentreDescription + "',");
            }
            else
            {
                strSql.Append("CostCentreDescription= null ,");
            }
            if (model.GLAccountCode != null)
            {
                strSql.Append("GLAccountCode='" + model.GLAccountCode + "',");
            }
            else
            {
                strSql.Append("GLAccountCode= null ,");
            }
            if (model.GLAccountDescription != null)
            {
                strSql.Append("GLAccountDescription='" + model.GLAccountDescription + "',");
            }
            else
            {
                strSql.Append("GLAccountDescription= null ,");
            }
            if (model.InternalOrder != null)
            {
                strSql.Append("InternalOrder='" + model.InternalOrder + "',");
            }
            else
            {
                strSql.Append("InternalOrder= null ,");
            }
            if (model.Headtext != null)
            {
                strSql.Append("Headtext='" + model.Headtext + "',");
            }
            else
            {
                strSql.Append("Headtext= null ,");
            }
            if (model.Reasonname != null)
            {
                strSql.Append("Reasonname='" + model.Reasonname + "',");
            }
            else
            {
                strSql.Append("Reasonname= null ,");
            }
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
            strSql.Append("delete from _PurchaseSet ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());

        }		
  

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

