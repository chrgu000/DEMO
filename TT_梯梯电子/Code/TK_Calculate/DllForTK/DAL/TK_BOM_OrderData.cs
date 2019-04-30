using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DllForTK.Model;

namespace DllForTK.DAL
{
    public class TK_BOM_OrderData
    {

        public TK_BOM_OrderData()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(TK_BOM_OrderEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

            if (model.child != null)
            {
                strSql1.Append("child,");
                strSql2.Append("'" + model.child + "',");
            }
            if (model.orderid != null)
            {
                strSql1.Append("orderid,");
                strSql2.Append("" + model.orderid + ",");
            }
            strSql.Append("insert into TK_BOM_Order(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");

            return strSql.ToString();
            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TK_BOM_OrderEntity DataRowToModel(DataRow row)
        {
            TK_BOM_OrderEntity model = new TK_BOM_OrderEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["child"] != null)
                {
                    model.child = row["child"].ToString();
                }
                if (row["orderid"] != null && row["orderid"].ToString() != "")
                {
                    model.orderid = int.Parse(row["orderid"].ToString());
                }
            }
            return model;
        }

    }
}
