using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_InvProcessPrice
    /// </summary>
    public partial class _InvProcessPrice
    {
        public _InvProcessPrice()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string FromWorkCentre)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _InvProcessPrice");
            strSql.Append(" where FromWorkCentre='" + FromWorkCentre + "' ");
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._InvProcessPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.FromWorkCenter != null)
            {
                strSql1.Append("FromWorkCenter,");
                strSql2.Append("'" + model.FromWorkCenter + "',");
            }
            if (model.CaseType != null)
            {
                strSql1.Append("CaseType,");
                strSql2.Append("'" + model.CaseType + "',");
            }
            if (model.Price != null)
            {
                strSql1.Append("Price,");
                strSql2.Append("" + model.Price + ",");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
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
            strSql.Append("insert into _InvProcessPrice(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._InvProcessPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _InvProcessPrice set ");
           
            if (model.Price != null)
            {
                strSql.Append("Price=" + model.Price + ",");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
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
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where FromWorkCenter='" + model.FromWorkCenter + "' and CaseType='" + model.CaseType + "'");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _InvProcessPrice ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
        }		/// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string FromWorkCentre)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _InvProcessPrice ");
            strSql.Append(" where FromWorkCenter='" + FromWorkCentre + "'");
            return (strSql.ToString());
        }
      

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

