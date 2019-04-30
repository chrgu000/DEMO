using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BarCode.DAL
{
    /// <summary>
    /// 数据访问类:ST_LocationDetail
    /// </summary>
    public partial class ST_LocationDetail
    {
        public ST_LocationDetail()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ST_LocationDetail");
            strSql.Append(" where id=" + id + " ");
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BarCode.Model.ST_LocationDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.quantity != null)
            {
                strSql1.Append("quantity,");
                strSql2.Append("" + model.quantity + ",");
            }
            if (model.quantity2 != null)
            {
                strSql1.Append("quantity2,");
                strSql2.Append("" + model.quantity2 + ",");
            }
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
            if (model.changeRate != null)
            {
                strSql1.Append("changeRate,");
                strSql2.Append("" + model.changeRate + ",");
            }
            if (model.batch != null)
            {
                strSql1.Append("batch,");
                strSql2.Append("'" + model.batch + "',");
            }
            if (model.memo != null)
            {
                strSql1.Append("memo,");
                strSql2.Append("'" + model.memo + "',");
            }
            if (model.ts != null)
            {
                strSql1.Append("ts,");
                strSql2.Append("" + model.ts + ",");
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
            if (model.idunit != null)
            {
                strSql1.Append("idunit,");
                strSql2.Append("" + model.idunit + ",");
            }
            if (model.idunit2 != null)
            {
                strSql1.Append("idunit2,");
                strSql2.Append("" + model.idunit2 + ",");
            }
            if (model.idAssemDetachDetailDTO != null)
            {
                strSql1.Append("idAssemDetachDetailDTO,");
                strSql2.Append("" + model.idAssemDetachDetailDTO + ",");
            }
            if (model.idRDRecordDetailDTO != null)
            {
                strSql1.Append("idRDRecordDetailDTO,");
                strSql2.Append("" + model.idRDRecordDetailDTO + ",");
            }
            if (model.idShapeDetailDTO != null)
            {
                strSql1.Append("idShapeDetailDTO,");
                strSql2.Append("" + model.idShapeDetailDTO + ",");
            }
            if (model.expiryDate != null)
            {
                strSql1.Append("expiryDate,");
                strSql2.Append("'" + model.expiryDate + "',");
            }
            if (model.productionDate != null)
            {
                strSql1.Append("productionDate,");
                strSql2.Append("'" + model.productionDate + "',");
            }
            strSql.Append("insert into ST_LocationDetail(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1, 1));
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
        public string Update(BarCode.Model.ST_LocationDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ST_LocationDetail set ");
            if (model.quantity != null)
            {
                strSql.Append("quantity=" + model.quantity + ",");
            }
            else
            {
                strSql.Append("quantity= null ,");
            }
            if (model.quantity2 != null)
            {
                strSql.Append("quantity2=" + model.quantity2 + ",");
            }
            else
            {
                strSql.Append("quantity2= null ,");
            }
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
            if (model.changeRate != null)
            {
                strSql.Append("changeRate=" + model.changeRate + ",");
            }
            else
            {
                strSql.Append("changeRate= null ,");
            }
            if (model.batch != null)
            {
                strSql.Append("batch='" + model.batch + "',");
            }
            else
            {
                strSql.Append("batch= null ,");
            }
            if (model.memo != null)
            {
                strSql.Append("memo='" + model.memo + "',");
            }
            else
            {
                strSql.Append("memo= null ,");
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
            if (model.idunit != null)
            {
                strSql.Append("idunit=" + model.idunit + ",");
            }
            else
            {
                strSql.Append("idunit= null ,");
            }
            if (model.idunit2 != null)
            {
                strSql.Append("idunit2=" + model.idunit2 + ",");
            }
            else
            {
                strSql.Append("idunit2= null ,");
            }
            if (model.expiryDate != null)
            {
                strSql.Append("expiryDate='" + model.expiryDate + "',");
            }
            else
            {
                strSql.Append("expiryDate= null ,");
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
            strSql.Append("delete from ST_LocationDetail ");
            strSql.Append(" where id=" + id + "");
            return (strSql.ToString());

        }		

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

