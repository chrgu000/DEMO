using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.BaseClass;

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
                strSql2.Append("'" + model.BarCode.ToUpper() + "',");
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
                strSql2.Append("'" + BaseFunction.ReturnDate(model.UpdateTime).ToString("yyyy-MM-dd HH:mm:ss") + "',");
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
                strSql2.Append("'" + BaseFunction.ReturnDate(model.CreateDate).ToString("yyyy-MM-dd HH:mm:ss") + "',");
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
                strSql.Append("BarCode='" + model.BarCode.ToUpper() + "',");
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
            if (model.UpdateTime != null && model.UpdateTime > Convert.ToDateTime("2016-01-01"))
            {
                strSql.Append("UpdateTime='" + BaseFunction.ReturnDate(model.UpdateTime).ToString("yyyy-MM-dd HH:mm:ss") + "',");
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
                strSql.Append("CreateDate='" + BaseFunction.ReturnDate(model.CreateDate).ToString("yyyy-MM-dd HH:mm:ss") + "',");
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus DataRowToModel(DataRow row)
        {
            UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["BarCode"] != null)
                {
                    model.BarCode = row["BarCode"].ToString().ToUpper();
                }
                if (row["iSOsID"] != null && row["iSOsID"].ToString() != "")
                {
                    model.iSOsID = int.Parse(row["iSOsID"].ToString());
                }
                if (row["Type"] != null)
                {
                    model.Type = row["Type"].ToString();
                }
                if (row["RoutingFrom"] != null)
                {
                    model.RoutingFrom = row["RoutingFrom"].ToString();
                }
                if (row["RoutingTo"] != null)
                {
                    model.RoutingTo = row["RoutingTo"].ToString();
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                if (row["QTY"] != null && row["QTY"].ToString() != "")
                {
                    model.QTY = decimal.Parse(row["QTY"].ToString());
                }
                if (row["CreateUid"] != null)
                {
                    model.CreateUid = row["CreateUid"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["EndTime"] != null)
                {
                    model.EndTime = row["EndTime"].ToString();
                }
            }
            return model;
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

