using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SmallERP.DBUtility;
using SmallERP.Entity;

namespace SmallERP.DataAccess
{
    public class PMGatingData
    {

        public PMGatingData()
        { }
        #region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PMGatingEntity DataRowToModel(DataRow row)
        {
            PMGatingEntity model = new PMGatingEntity();
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
                if (row["sPartID"] != null)
                {
                    model.sPartID = row["sPartID"].ToString();
                }
                if (row["fOpenQTY"] != null && row["fOpenQTY"].ToString() != "")
                {
                    model.fOpenQTY = decimal.Parse(row["fOpenQTY"].ToString());
                }
                if (row["dDate"] != null && row["dDate"].ToString() != "")
                {
                    model.dDate = DateTime.Parse(row["dDate"].ToString());
                }
                if (row["sPlannerCode"] != null)
                {
                    model.sPlannerCode = row["sPlannerCode"].ToString();
                }
                if (row["sSRC"] != null)
                {
                    model.sSRC = row["sSRC"].ToString();
                }
                if (row["sProductGroup"] != null)
                {
                    model.sProductGroup = row["sProductGroup"].ToString();
                }
                if (row["sReorderPolicy"] != null)
                {
                    model.sReorderPolicy = row["sReorderPolicy"].ToString();
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

        /// <summary>
        /// 分页查询用户列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetList(string sWhere, string userId, string name, string roleId, int rowStart, int rowEnd, out int total)
        {
            //获得记录总数
            StringBuilder strCountSql = new StringBuilder();
            strCountSql.Append(" Select Count(1) From TK_PMGating T ");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));

            //获得记录
            List<TK_POEntity> list = new List<TK_POEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.PartID ");
            strSql.Append(")AS Row, * from TK_PMGating T ");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql.Replace("1=1", "1=1" + sWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);

            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];


            //StringBuilder strSqls = new StringBuilder();
            //PublicData p = new PublicData();
            //DataTable dtp = p.GetPeriod();
            //strSqls.Append("SELECT   iID, sDataVersion, sType, sPartID, Qty, dDate FROM TK_Trialkitting_Results");

            //DataTable dtqty = DbHelperSQL.Query(strSqls.ToString()).Tables[0];

            //for (int i = 0; i < result.Rows.Count; i++)
            //{
            //    string cInvCode = result.Rows[i]["Toplevel"].ToString();
            //    DataRow[] dw = dtqty.Select("sPartID='" + cInvCode + "'");
            //    string NonfullkitQty = "";
            //    for (int j = 0; j < dw.Length; j++)
            //    {
            //        if (NonfullkitQty == "")
            //        {
            //            NonfullkitQty = NonfullkitQty + "/";
            //        }
            //        NonfullkitQty = NonfullkitQty + dw[j]["Qty"].ToString() + "," + dw[j]["dDate"].ToString();
            //    }
            //}
            return result;
        }

    }
}
