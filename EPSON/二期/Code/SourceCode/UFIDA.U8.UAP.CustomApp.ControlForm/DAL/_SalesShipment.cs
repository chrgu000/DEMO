using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_SalesShipment
    /// </summary>
    public partial class _SalesShipment
    {
        public _SalesShipment()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string LotNO, int iSOsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _SalesShipment");
            strSql.Append(" where LotNO='" + LotNO + "' and iSOsID=" + iSOsID + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._SalesShipment model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.LotNO != null)
            {
                strSql1.Append("LotNO,");
                strSql2.Append("'" + model.LotNO + "',");
            }
            if (model.cSOCode != null)
            {
                strSql1.Append("cSOCode,");
                strSql2.Append("'" + model.cSOCode + "',");
            }
            if (model.CartonNo != null)
            {
                strSql1.Append("CartonNo,");
                strSql2.Append("'" + model.CartonNo + "',");
            }
            if (model.SaleOrderRow != null)
            {
                strSql1.Append("SaleOrderRow,");
                strSql2.Append("" + model.SaleOrderRow + ",");
            }
            if (model.iSOsID != null)
            {
                strSql1.Append("iSOsID,");
                strSql2.Append("" + model.iSOsID + ",");
            }
            if (model.ItemNO != null)
            {
                strSql1.Append("ItemNO,");
                strSql2.Append("'" + model.ItemNO + "',");
            }
            if (model.Description != null)
            {
                strSql1.Append("Description,");
                strSql2.Append("'" + model.Description + "',");
            }
            if (model.cCusCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
            }
            if (model.OrderQTY != null)
            {
                strSql1.Append("OrderQTY,");
                strSql2.Append("" + model.OrderQTY + ",");
            }
            if (model.LOTQTY != null)
            {
                strSql1.Append("LOTQTY,");
                strSql2.Append("" + model.LOTQTY + ",");
            }
            if (model.DEPT != null)
            {
                strSql1.Append("DEPT,");
                strSql2.Append("'" + model.DEPT + "',");
            }
            if (model.Process != null)
            {
                strSql1.Append("Process,");
                strSql2.Append("'" + model.Process + "',");
            }
            if (model.ProcessNext != null)
            {
                strSql1.Append("ProcessNext,");
                strSql2.Append("'" + model.ProcessNext + "',");
            }
            if (model.OtherQTY != null)
            {
                strSql1.Append("OtherQTY,");
                strSql2.Append("" + model.OtherQTY + ",");
            }
            if (model.Status != null)
            {
                strSql1.Append("Status,");
                strSql2.Append("'" + model.Status + "',");
            }
            if (model.cSTCode != null)
            {
                strSql1.Append("cSTCode,");
                strSql2.Append("'" + model.cSTCode + "',");
            }
            if (model.CurrQTY != null)
            {
                strSql1.Append("CurrQTY,");
                strSql2.Append("" + model.CurrQTY + ",");
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
            strSql.Append("insert into _SalesShipment(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _SalesShipment ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
        }		
        

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UFIDA.U8.UAP.CustomApp.ControlForm.Model._SalesShipment DataRowToModel(DataRow row)
        {
            UFIDA.U8.UAP.CustomApp.ControlForm.Model._SalesShipment model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._SalesShipment();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["LotNO"] != null)
                {
                    model.LotNO = row["LotNO"].ToString();
                }
                if (row["cSOCode"] != null)
                {
                    model.cSOCode = row["cSOCode"].ToString();
                }
                if (row["SaleOrderRow"] != null && row["SaleOrderRow"].ToString() != "")
                {
                    model.SaleOrderRow = int.Parse(row["SaleOrderRow"].ToString());
                }
                if (row["iSOsID"] != null && row["iSOsID"].ToString() != "")
                {
                    model.iSOsID = int.Parse(row["iSOsID"].ToString());
                }
                if (row["ItemNO"] != null)
                {
                    model.ItemNO = row["ItemNO"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["cCusCode"] != null)
                {
                    model.cCusCode = row["cCusCode"].ToString();
                }
                if (row["OrderQTY"] != null && row["OrderQTY"].ToString() != "")
                {
                    model.OrderQTY = decimal.Parse(row["OrderQTY"].ToString());
                }
                if (row["LOTQTY"] != null && row["LOTQTY"].ToString() != "")
                {
                    model.LOTQTY = decimal.Parse(row["LOTQTY"].ToString());
                }
                if (row["DEPT"] != null)
                {
                    model.DEPT = row["DEPT"].ToString();
                }
                if (row["Process"] != null)
                {
                    model.Process = row["Process"].ToString();
                }
                if (row["ProcessNext"] != null)
                {
                    model.ProcessNext = row["ProcessNext"].ToString();
                }
                if (row["OtherQTY"] != null && row["OtherQTY"].ToString() != "")
                {
                    model.OtherQTY = decimal.Parse(row["OtherQTY"].ToString());
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
                if (row["cSTCode"] != null)
                {
                    model.cSTCode = row["cSTCode"].ToString();
                }
                if (row["CurrQTY"] != null && row["CurrQTY"].ToString() != "")
                {
                    model.CurrQTY = decimal.Parse(row["CurrQTY"].ToString());
                }
                if (row["CreateUid"] != null)
                {
                    model.CreateUid = row["CreateUid"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
            }
            return model;
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

