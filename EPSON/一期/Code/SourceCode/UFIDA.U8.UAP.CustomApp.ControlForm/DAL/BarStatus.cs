using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_BarStatus
    /// </summary>
    public partial class BarStatus
    {
        public BarStatus()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _BarStatus");
            strSql.Append(" where iID=" + iID + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.BarCode != null)
            {
                strSql1.Append("BarCode,");
                strSql2.Append("'" + model.BarCode + "',");
            }
            if (model.iSOsID != null)
            {
                strSql1.Append("iSOsID,");
                strSql2.Append("" + model.iSOsID + ",");
            }
            if (model.Type != null)
            {
                strSql1.Append("Type,");
                strSql2.Append("'" + model.Type + "',");
            }
            if (model.RoutingFrom != null)
            {
                strSql1.Append("RoutingFrom,");
                strSql2.Append("'" + model.RoutingFrom + "',");
            }
            if (model.RoutingTo != null)
            {
                strSql1.Append("RoutingTo,");
                strSql2.Append("'" + model.RoutingTo + "',");
            }
            if (model.UpdateTime != null)
            {
                strSql1.Append("UpdateTime,");
                strSql2.Append("'" + model.UpdateTime + "',");
            }
            if (model.QTY != null)
            {
                strSql1.Append("QTY,");
                strSql2.Append("" + model.QTY + ",");
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
            strSql.Append("insert into _BarStatus(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _BarStatus set ");
            if (model.BarCode != null)
            {
                strSql.Append("BarCode='" + model.BarCode + "',");
            }
            if (model.iSOsID != null)
            {
                strSql.Append("iSOsID=" + model.iSOsID + ",");
            }
            if (model.Type != null)
            {
                strSql.Append("Type='" + model.Type + "',");
            }
            else
            {
                strSql.Append("Type= null ,");
            }
            if (model.RoutingFrom != null)
            {
                strSql.Append("RoutingFrom='" + model.RoutingFrom + "',");
            }
            else
            {
                strSql.Append("RoutingFrom= null ,");
            }
            if (model.RoutingTo != null)
            {
                strSql.Append("RoutingTo='" + model.RoutingTo + "',");
            }
            else
            {
                strSql.Append("RoutingTo= null ,");
            }
            if (model.UpdateTime != null)
            {
                strSql.Append("UpdateTime='" + model.UpdateTime + "',");
            }
            if (model.QTY != null)
            {
                strSql.Append("QTY=" + model.QTY + ",");
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
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _BarStatus ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
        }		


        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

