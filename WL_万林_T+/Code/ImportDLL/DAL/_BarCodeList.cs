using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ImportDLL.DAL
{
    /// <summary>
    /// 数据访问类:_BarCodeList
    /// </summary>
    public partial class _BarCodeList
    {
        public _BarCodeList()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string BarCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _BarCodeList");
            strSql.Append(" where BarCode='" + BarCode + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(ImportDLL.Model._BarCodeList model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.BarCode != null)
            {
                strSql1.Append("BarCode,");
                strSql2.Append("'" + model.BarCode + "',");
            }
            if (model.BarCode2 != null)
            {
                strSql1.Append("BarCode2,");
                strSql2.Append("'" + model.BarCode2 + "',");
            }
            if (model.Qty != null)
            {
                strSql1.Append("Qty,");
                strSql2.Append("" + model.Qty + ",");
            }
            if (model.DetailsID != null)
            {
                strSql1.Append("DetailsID,");
                strSql2.Append("" + model.DetailsID + ",");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("'" + model.CreateUid + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.RePrintUid != null)
            {
                strSql1.Append("RePrintUid,");
                strSql2.Append("'" + model.RePrintUid + "',");
            }
            if (model.RePrintDate != null)
            {
                strSql1.Append("RePrintDate,");
                strSql2.Append("'" + model.RePrintDate + "',");
            }
            if (model.PrintCount != null)
            {
                strSql1.Append("PrintCount,");
                strSql2.Append("" + model.PrintCount + ",");
            }
            if (model.DelUid != null)
            {
                strSql1.Append("DelUid,");
                strSql2.Append("'" + model.DelUid + "',");
            }
            if (model.DelDate != null)
            {
                strSql1.Append("DelDate,");
                strSql2.Append("'" + model.DelDate + "',");
            }
            strSql.Append("insert into _BarCodeList(");
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
        public string Update(ImportDLL.Model._BarCodeList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _BarCodeList set ");
            if (model.Qty != null)
            {
                strSql.Append("Qty=" + model.Qty + ",");
            }
            else
            {
                strSql.Append("Qty= null ,");
            }
            if (model.DetailsID != null)
            {
                strSql.Append("DetailsID=" + model.DetailsID + ",");
            }
            else
            {
                strSql.Append("DetailsID= null ,");
            }
            if (model.CreateUid != null)
            {
                strSql.Append("CreateUid='" + model.CreateUid + "',");
            }
            else
            {
                strSql.Append("CreateUid= null ,");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
            }
            else
            {
                strSql.Append("CreateDate= null ,");
            }
            if (model.RePrintUid != null)
            {
                strSql.Append("RePrintUid='" + model.RePrintUid + "',");
            }
            else
            {
                strSql.Append("RePrintUid= null ,");
            }
            if (model.RePrintDate != null)
            {
                strSql.Append("RePrintDate='" + model.RePrintDate + "',");
            }
            else
            {
                strSql.Append("RePrintDate= null ,");
            }
            if (model.PrintCount != null)
            {
                strSql.Append("PrintCount=" + model.PrintCount + ",");
            }
            else
            {
                strSql.Append("PrintCount= null ,");
            }
            if (model.DelUid != null)
            {
                strSql.Append("DelUid='" + model.DelUid + "',");
            }
            else
            {
                strSql.Append("DelUid= null ,");
            }
            if (model.DelDate != null)
            {
                strSql.Append("DelDate='" + model.DelDate + "',");
            }
            else
            {
                strSql.Append("DelDate= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

