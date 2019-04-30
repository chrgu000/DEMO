using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 数据访问类:Registers
    /// </summary>
    public partial class Registers
    {
        public Registers()
        { }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public string Add(Model.Registers model)
		{
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.VenCode != null)
            {
                strSql1.Append("VenCode,");
                strSql2.Append("'" + model.VenCode + "',");
            }
            if (model.Door != null)
            {
                strSql1.Append("Door,");
                strSql2.Append("'" + model.Door + "',");
            }
            if (model.InvCode != null)
            {
                strSql1.Append("InvCode,");
                strSql2.Append("'" + model.InvCode + "',");
            }
            if (model.iHZ != null)
            {
                strSql1.Append("iHZ,");
                strSql2.Append("'" + model.iHZ + "',");
            }
            if (model.iSheQty != null)
            {
                strSql1.Append("iSheQty,");
                strSql2.Append("" + model.iSheQty + ",");
            }
            if (model.iSheDate != null)
            {
                strSql1.Append("iSheDate,");
                strSql2.Append("'" + model.iSheDate + "',");
            }
            if (model.iBoxQty != null)
            {
                strSql1.Append("iBoxQty,");
                strSql2.Append("" + model.iBoxQty + ",");
            }
            if (model.iQty != null)
            {
                strSql1.Append("iQty,");
                strSql2.Append("" + model.iQty + ",");
            }
            if (model.OrderNo != null)
            {
                strSql1.Append("OrderNo,");
                strSql2.Append("'" + model.OrderNo + "',");
            }
            if (model.BarCode != null)
            {
                strSql1.Append("BarCode,");
                strSql2.Append("'" + model.BarCode + "',");
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
            if (model.UpdateUid != null)
            {
                strSql1.Append("UpdateUid,");
                strSql2.Append("'" + model.UpdateUid + "',");
            }
            if (model.UpdateDate != null)
            {
                strSql1.Append("UpdateDate,");
                strSql2.Append("'" + model.UpdateDate + "',");
            }
            if (model.iOutQty != null)
            {
                strSql1.Append("iOutQty,");
                strSql2.Append("" + model.iOutQty + ",");
            }
            if (model.iOutDate != null)
            {
                strSql1.Append("iOutDate,");
                strSql2.Append("'" + model.iOutDate + "',");
            }
            strSql.Append("insert into Registers(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

    }
}

