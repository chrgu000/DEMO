using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SmallERP.DBUtility;
using SmallERP.Entity;

namespace SmallERP.DataAccess
{
    public class CurrentStockData
    {

        public CurrentStockData()
        { }
        #region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CurrentStockEntity DataRowToModel(DataRow row)
        {
            CurrentStockEntity model = new CurrentStockEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["Guid"] != null && row["Guid"].ToString() != "")
                {
                    model.Guid = new Guid(row["Guid"].ToString());
                }
                if (row["sVersion"] != null)
                {
                    model.sVersion = row["sVersion"].ToString();
                }
                if (row["Warehouse"] != null)
                {
                    model.Warehouse = row["Warehouse"].ToString();
                }
                if (row["sPartID"] != null)
                {
                    model.sPartID = row["sPartID"].ToString();
                }
                if (row["dQty"] != null && row["dQty"].ToString() != "")
                {
                    model.dQty = decimal.Parse(row["dQty"].ToString());
                }
                if (row["sRemark"] != null)
                {
                    model.sRemark = row["sRemark"].ToString();
                }
                if (row["sPreparedBy"] != null)
                {
                    model.sPreparedBy = row["sPreparedBy"].ToString();
                }
                if (row["dtmPreparedBy"] != null && row["dtmPreparedBy"].ToString() != "")
                {
                    model.dtmPreparedBy = DateTime.Parse(row["dtmPreparedBy"].ToString());
                }
                if (row["sUpdateUid"] != null)
                {
                    model.sUpdateUid = row["sUpdateUid"].ToString();
                }
                if (row["dtmUpdate"] != null && row["dtmUpdate"].ToString() != "")
                {
                    model.dtmUpdate = DateTime.Parse(row["dtmUpdate"].ToString());
                }
                if (row["iStatus"] != null && row["iStatus"].ToString() != "")
                {
                    model.iStatus = int.Parse(row["iStatus"].ToString());
                }
                if (row["bDel"] != null && row["bDel"].ToString() != "")
                {
                    if ((row["bDel"].ToString() == "1") || (row["bDel"].ToString().ToLower() == "true"))
                    {
                        model.bDel = true;
                    }
                    else
                    {
                        model.bDel = false;
                    }
                }
            }
            return model;
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        //<summary>
        //获得数据列表
        //</summary>
        //<returns></returns>
        public List<CurrentStockEntity> GetList()
        {

            List<CurrentStockEntity> list = new List<CurrentStockEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * From TK_CurrentStock where bDel=0 Order By iID ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    CurrentStockEntity sh = DataRowToModel(row);
                    list.Add(sh);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

    }
}
