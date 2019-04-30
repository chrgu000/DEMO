using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_RoutingInfo
    /// </summary>
    public partial class _RoutingInfo
    {
        public _RoutingInfo()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._RoutingInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.RoutingID != null)
            {
                strSql1.Append("RoutingID,");
                strSql2.Append("'" + model.RoutingID + "',");
            }
            if (model.RoutingForm != null)
            {
                strSql1.Append("RoutingForm,");
                strSql2.Append("'" + model.RoutingForm + "',");
            }
            if (model.RoutingTo != null)
            {
                strSql1.Append("RoutingTo,");
                strSql2.Append("'" + model.RoutingTo + "',");
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
            strSql.Append("insert into _RoutingInfo(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._RoutingInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _RoutingInfo set ");
            if (model.RoutingForm != null)
            {
                strSql.Append("RoutingForm='" + model.RoutingForm + "',");
            }
            else
            {
                strSql.Append("RoutingForm= null ,");
            }
            if (model.RoutingTo != null)
            {
                strSql.Append("RoutingTo='" + model.RoutingTo + "',");
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
            strSql.Append(" where RoutingID='" + model.RoutingID + "'");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string RoutingID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _RoutingInfo ");
            strSql.Append(" where RoutingID='" + RoutingID + "' ");

            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

