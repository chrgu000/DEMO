using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BarCode.DAL
{
    /// <summary>
    /// 数据访问类:ST_LocationAccount
    /// </summary>
    public partial class ST_LocationAccount
    {
        public ST_LocationAccount()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ST_LocationAccount");
            strSql.Append(" where id=" + id + " ");
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BarCode.Model.ST_LocationAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.baseQuantity != null)
            {
                strSql1.Append("baseQuantity,");
                strSql2.Append("" + model.baseQuantity + ",");
            }
            if (model.subQuantity != null)
            {
                strSql1.Append("subQuantity,");
                strSql2.Append("" + model.subQuantity + ",");
            }
            if (model.batch != null)
            {
                strSql1.Append("batch,");
                strSql2.Append("'" + model.batch + "',");
            }
            if (model.voucherQuantity != null)
            {
                strSql1.Append("voucherQuantity,");
                strSql2.Append("" + model.voucherQuantity + ",");
            }
            if (model.voucherQuantity2 != null)
            {
                strSql1.Append("voucherQuantity2,");
                strSql2.Append("" + model.voucherQuantity2 + ",");
            }
            if (model.isCarriedForwardOut != null)
            {
                strSql1.Append("isCarriedForwardOut,");
                strSql2.Append("" + model.isCarriedForwardOut + ",");
            }
            if (model.isCarriedForwardIn != null)
            {
                strSql1.Append("isCarriedForwardIn,");
                strSql2.Append("" + model.isCarriedForwardIn + ",");
            }
            if (model.ts != null)
            {
                strSql1.Append("ts,");
                strSql2.Append("" + model.ts + ",");
            }
            if (model.updatedBy != null)
            {
                strSql1.Append("updatedBy,");
                strSql2.Append("'" + model.updatedBy + "',");
            }
            if (model.freeItem0 != null)
            {
                strSql1.Append("freeItem0,");
                strSql2.Append("'" + model.freeItem0 + "',");
            }
            if (model.freeItem1 != null)
            {
                strSql1.Append("freeItem1,");
                strSql2.Append("'" + model.freeItem1 + "',");
            }
            if (model.freeItem2 != null)
            {
                strSql1.Append("freeItem2,");
                strSql2.Append("'" + model.freeItem2 + "',");
            }
            if (model.freeItem3 != null)
            {
                strSql1.Append("freeItem3,");
                strSql2.Append("'" + model.freeItem3 + "',");
            }
            if (model.freeItem4 != null)
            {
                strSql1.Append("freeItem4,");
                strSql2.Append("'" + model.freeItem4 + "',");
            }
            if (model.freeItem5 != null)
            {
                strSql1.Append("freeItem5,");
                strSql2.Append("'" + model.freeItem5 + "',");
            }
            if (model.freeItem6 != null)
            {
                strSql1.Append("freeItem6,");
                strSql2.Append("'" + model.freeItem6 + "',");
            }
            if (model.freeItem7 != null)
            {
                strSql1.Append("freeItem7,");
                strSql2.Append("'" + model.freeItem7 + "',");
            }
            if (model.freeItem8 != null)
            {
                strSql1.Append("freeItem8,");
                strSql2.Append("'" + model.freeItem8 + "',");
            }
            if (model.freeItem9 != null)
            {
                strSql1.Append("freeItem9,");
                strSql2.Append("'" + model.freeItem9 + "',");
            }
            if (model.idinventory != null)
            {
                strSql1.Append("idinventory,");
                strSql2.Append("" + model.idinventory + ",");
            }
            if (model.idinvlocation != null)
            {
                strSql1.Append("idinvlocation,");
                strSql2.Append("" + model.idinvlocation + ",");
            }
            if (model.idbaseunit != null)
            {
                strSql1.Append("idbaseunit,");
                strSql2.Append("" + model.idbaseunit + ",");
            }
            if (model.idsubunit != null)
            {
                strSql1.Append("idsubunit,");
                strSql2.Append("" + model.idsubunit + ",");
            }
            if (model.idwarehouse != null)
            {
                strSql1.Append("idwarehouse,");
                strSql2.Append("" + model.idwarehouse + ",");
            }
            if (model.expiryDate != null)
            {
                strSql1.Append("expiryDate,");
                strSql2.Append("'" + model.expiryDate + "',");
            }
            if (model.createdtime != null)
            {
                strSql1.Append("createdtime,");
                strSql2.Append("'" + model.createdtime + "',");
            }
            if (model.updated != null)
            {
                strSql1.Append("updated,");
                strSql2.Append("'" + model.updated + "',");
            }
            if (model.productionDate != null)
            {
                strSql1.Append("productionDate,");
                strSql2.Append("'" + model.productionDate + "',");
            }
            strSql.Append("insert into ST_LocationAccount(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1,1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1, 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(BarCode.Model.ST_LocationAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ST_LocationAccount set ");
            if (model.baseQuantity != null)
            {
                strSql.Append("baseQuantity=" + model.baseQuantity + ",");
            }
            else
            {
                strSql.Append("baseQuantity= null ,");
            }
            if (model.subQuantity != null)
            {
                strSql.Append("subQuantity=" + model.subQuantity + ",");
            }
            else
            {
                strSql.Append("subQuantity= null ,");
            }
            if (model.batch != null)
            {
                strSql.Append("batch='" + model.batch + "',");
            }
            else
            {
                strSql.Append("batch= null ,");
            }
            if (model.voucherQuantity != null)
            {
                strSql.Append("voucherQuantity=" + model.voucherQuantity + ",");
            }
            else
            {
                strSql.Append("voucherQuantity= null ,");
            }
            if (model.voucherQuantity2 != null)
            {
                strSql.Append("voucherQuantity2=" + model.voucherQuantity2 + ",");
            }
            else
            {
                strSql.Append("voucherQuantity2= null ,");
            }
            if (model.isCarriedForwardOut != null)
            {
                strSql.Append("isCarriedForwardOut=" + model.isCarriedForwardOut + ",");
            }
            else
            {
                strSql.Append("isCarriedForwardOut= null ,");
            }
            if (model.isCarriedForwardIn != null)
            {
                strSql.Append("isCarriedForwardIn=" + model.isCarriedForwardIn + ",");
            }
            else
            {
                strSql.Append("isCarriedForwardIn= null ,");
            }
            if (model.updatedBy != null)
            {
                strSql.Append("updatedBy='" + model.updatedBy + "',");
            }
            else
            {
                strSql.Append("updatedBy= null ,");
            }
            if (model.freeItem0 != null)
            {
                strSql.Append("freeItem0='" + model.freeItem0 + "',");
            }
            else
            {
                strSql.Append("freeItem0= null ,");
            }
            if (model.freeItem1 != null)
            {
                strSql.Append("freeItem1='" + model.freeItem1 + "',");
            }
            else
            {
                strSql.Append("freeItem1= null ,");
            }
            if (model.freeItem2 != null)
            {
                strSql.Append("freeItem2='" + model.freeItem2 + "',");
            }
            else
            {
                strSql.Append("freeItem2= null ,");
            }
            if (model.freeItem3 != null)
            {
                strSql.Append("freeItem3='" + model.freeItem3 + "',");
            }
            else
            {
                strSql.Append("freeItem3= null ,");
            }
            if (model.freeItem4 != null)
            {
                strSql.Append("freeItem4='" + model.freeItem4 + "',");
            }
            else
            {
                strSql.Append("freeItem4= null ,");
            }
            if (model.freeItem5 != null)
            {
                strSql.Append("freeItem5='" + model.freeItem5 + "',");
            }
            else
            {
                strSql.Append("freeItem5= null ,");
            }
            if (model.freeItem6 != null)
            {
                strSql.Append("freeItem6='" + model.freeItem6 + "',");
            }
            else
            {
                strSql.Append("freeItem6= null ,");
            }
            if (model.freeItem7 != null)
            {
                strSql.Append("freeItem7='" + model.freeItem7 + "',");
            }
            else
            {
                strSql.Append("freeItem7= null ,");
            }
            if (model.freeItem8 != null)
            {
                strSql.Append("freeItem8='" + model.freeItem8 + "',");
            }
            else
            {
                strSql.Append("freeItem8= null ,");
            }
            if (model.freeItem9 != null)
            {
                strSql.Append("freeItem9='" + model.freeItem9 + "',");
            }
            else
            {
                strSql.Append("freeItem9= null ,");
            }
            if (model.idbaseunit != null)
            {
                strSql.Append("idbaseunit=" + model.idbaseunit + ",");
            }
            else
            {
                strSql.Append("idbaseunit= null ,");
            }
            if (model.idsubunit != null)
            {
                strSql.Append("idsubunit=" + model.idsubunit + ",");
            }
            else
            {
                strSql.Append("idsubunit= null ,");
            }
            if (model.expiryDate != null)
            {
                strSql.Append("expiryDate='" + model.expiryDate + "',");
            }
            else
            {
                strSql.Append("expiryDate= null ,");
            }
            if (model.createdtime != null)
            {
                strSql.Append("createdtime='" + model.createdtime + "',");
            }
            else
            {
                strSql.Append("createdtime= null ,");
            }
            if (model.productionDate != null)
            {
                strSql.Append("productionDate='" + model.productionDate + "',");
            }
            else
            {
                strSql.Append("productionDate= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ST_LocationAccount ");
            strSql.Append(" where id=" + id + "");
            return (strSql.ToString());
        }		/// <summary>
       
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

