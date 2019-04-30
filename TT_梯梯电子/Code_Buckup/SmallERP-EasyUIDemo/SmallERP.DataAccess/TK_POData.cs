using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SmallERP.DBUtility;
using SmallERP.Entity;
using System.Collections;

namespace SmallERP.DataAccess
{
    public class TK_POData
    {

        public TK_POData()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(TK_POEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.Guid != null)
            {
                strSql1.Append("Guid,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.sVersion != null)
            {
                strSql1.Append("sVersion,");
                strSql2.Append("'" + model.sVersion + "',");
            }
            if (model.sPONo != null)
            {
                strSql1.Append("sPONo,");
                strSql2.Append("'" + model.sPONo + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.POLine != null)
            {
                strSql1.Append("POLine,");
                strSql2.Append("" + model.POLine + ",");
            }
            if (model.iItemNO != null)
            {
                strSql1.Append("iItemNO,");
                strSql2.Append("'" + model.iItemNO + "',");
            }
            if (model.fQTY != null)
            {
                strSql1.Append("fQTY,");
                strSql2.Append("" + model.fQTY + ",");
            }
            if (model.fOpenQTY != null)
            {
                strSql1.Append("fOpenQTY,");
                strSql2.Append("" + model.fOpenQTY + ",");
            }
            if (model.dtmRequirement != null)
            {
                strSql1.Append("dtmRequirement,");
                strSql2.Append("'" + model.dtmRequirement + "',");
            }
            if (model.dtmDuedate != null)
            {
                strSql1.Append("dtmDuedate,");
                strSql2.Append("'" + model.dtmDuedate + "',");
            }
            if (model.dtmCommitdate != null)
            {
                strSql1.Append("dtmCommitdate,");
                strSql2.Append("'" + model.dtmCommitdate + "',");
            }
            if (model.sProductGroup != null)
            {
                strSql1.Append("sProductGroup,");
                strSql2.Append("'" + model.sProductGroup + "',");
            }
            if (model.sBuyer != null)
            {
                strSql1.Append("sBuyer,");
                strSql2.Append("'" + model.sBuyer + "',");
            }
            if (model.sPreparedBy != null)
            {
                strSql1.Append("sPreparedBy,");
                strSql2.Append("'" + model.sPreparedBy + "',");
            }
            if (model.dtmPreparedBy != null)
            {
                strSql1.Append("dtmPreparedBy,");
                strSql2.Append("'" + model.dtmPreparedBy + "',");
            }
            strSql.Append("insert into TK_PO(");
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
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(TK_POEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_PO set ");
            if (model.Guid != null)
            {
                strSql.Append("Guid='" + model.Guid + "',");
            }
            else
            {
                strSql.Append("Guid= null ,");
            }
            if (model.sVersion != null)
            {
                strSql.Append("sVersion='" + model.sVersion + "',");
            }
            else
            {
                strSql.Append("sVersion= null ,");
            }
            if (model.sPONo != null)
            {
                strSql.Append("sPONo='" + model.sPONo + "',");
            }
            if (model.dDate != null)
            {
                strSql.Append("dDate='" + model.dDate + "',");
            }
            else
            {
                strSql.Append("dDate= null ,");
            }
            if (model.POLine != null)
            {
                strSql.Append("POLine=" + model.POLine + ",");
            }
            else
            {
                strSql.Append("POLine= null ,");
            }
            if (model.iItemNO != null)
            {
                strSql.Append("iItemNO='" + model.iItemNO + "',");
            }
            if (model.fQTY != null)
            {
                strSql.Append("fQTY=" + model.fQTY + ",");
            }
            if (model.fOpenQTY != null)
            {
                strSql.Append("fOpenQTY=" + model.fOpenQTY + ",");
            }
            else
            {
                strSql.Append("fOpenQTY= null ,");
            }
            if (model.dtmRequirement != null)
            {
                strSql.Append("dtmRequirement='" + model.dtmRequirement + "',");
            }
            else
            {
                strSql.Append("dtmRequirement= null ,");
            }
            if (model.dtmDuedate != null)
            {
                strSql.Append("dtmDuedate='" + model.dtmDuedate + "',");
            }
            else
            {
                strSql.Append("dtmDuedate= null ,");
            }
            if (model.dtmCommitdate != null)
            {
                strSql.Append("dtmCommitdate='" + model.dtmCommitdate + "',");
            }
            else
            {
                strSql.Append("dtmCommitdate= null ,");
            }
            if (model.sProductGroup != null)
            {
                strSql.Append("sProductGroup='" + model.sProductGroup + "',");
            }
            else
            {
                strSql.Append("sProductGroup= null ,");
            }
            if (model.sBuyer != null)
            {
                strSql.Append("sBuyer='" + model.sBuyer + "',");
            }
            else
            {
                strSql.Append("sBuyer= null ,");
            }
            if (model.sPreparedBy != null)
            {
                strSql.Append("sPreparedBy='" + model.sPreparedBy + "',");
            }
            else
            {
                strSql.Append("sPreparedBy= null ,");
            }
            if (model.dtmPreparedBy != null)
            {
                strSql.Append("dtmPreparedBy='" + model.dtmPreparedBy + "',");
            }
            else
            {
                strSql.Append("dtmPreparedBy= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");

            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return strSql.ToString();
        }

        /// <summary>
        /// 更新多数据行
        /// </summary>
        /// <param name="aList"></param>
        /// <returns></returns>
        public bool Update(ArrayList aList)
        {
            int rows = DbHelperSQL.ExecuteSqlTran(aList);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="iID">删除ID</param>
        /// <returns></returns>
        public string Delete(string iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TK_PO ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TK_POEntity DataRowToModel(DataRow row)
        {
            TK_POEntity model = new TK_POEntity();
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
                if (row["sPONo"] != null)
                {
                    model.sPONo = row["sPONo"].ToString();
                }
                if (row["dDate"] != null && row["dDate"].ToString() != "")
                {
                    model.dDate = DateTime.Parse(row["dDate"].ToString());
                }
                if (row["POLine"] != null && row["POLine"].ToString() != "")
                {
                    model.POLine = int.Parse(row["POLine"].ToString());
                }
                if (row["iItemNO"] != null)
                {
                    model.iItemNO = row["iItemNO"].ToString();
                }
                if (row["fQTY"] != null && row["fQTY"].ToString() != "")
                {
                    model.fQTY = decimal.Parse(row["fQTY"].ToString());
                }
                if (row["fOpenQTY"] != null && row["fOpenQTY"].ToString() != "")
                {
                    model.fOpenQTY = decimal.Parse(row["fOpenQTY"].ToString());
                }
                if (row["dtmRequirement"] != null && row["dtmRequirement"].ToString() != "")
                {
                    model.dtmRequirement = DateTime.Parse(row["dtmRequirement"].ToString());
                }
                if (row["dtmDuedate"] != null && row["dtmDuedate"].ToString() != "")
                {
                    model.dtmDuedate = DateTime.Parse(row["dtmDuedate"].ToString());
                }
                if (row["dtmCommitdate"] != null && row["dtmCommitdate"].ToString() != "")
                {
                    model.dtmCommitdate = DateTime.Parse(row["dtmCommitdate"].ToString());
                }
                if (row["sProductGroup"] != null)
                {
                    model.sProductGroup = row["sProductGroup"].ToString();
                }
                if (row["sBuyer"] != null)
                {
                    model.sBuyer = row["sBuyer"].ToString();
                }
                if (row["sPreparedBy"] != null)
                {
                    model.sPreparedBy = row["sPreparedBy"].ToString();
                }
                if (row["dtmPreparedBy"] != null && row["dtmPreparedBy"].ToString() != "")
                {
                    model.dtmPreparedBy = DateTime.Parse(row["dtmPreparedBy"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere">查询条件</param>
        /// <returns></returns>
        public List<TK_POEntity> GetList(string sWhere)
        {
            List<TK_POEntity> list = new List<TK_POEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select * From TK_PO where 1=1 Order By iID ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql = strSql.Replace("1=1", "1=1" + sWhere);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TK_POEntity sh = DataRowToModel(row);
                    list.Add(sh);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

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
            strCountSql.Append(" Select Count(1) From TK_PO T ");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));

            StringBuilder strSqls = new StringBuilder();
            PublicData p = new PublicData();
            DataTable dtp = p.GetPeriod();
            strSqls.Append("(select cInvCode,ProdGroup,Planner");
            for (int i = 0; i < dtp.Rows.Count; i++)
            {
                strSqls.Append(",sum(case when convert(nvarchar(10),dtmQty,120) between '" + dtp.Rows[i]["dtmStart"].ToString() + "' and '" + dtp.Rows[i]["dtmEnd"].ToString() + "' then Qty end) as Week" + (i + 1) + " ");
            }
            strSqls.Append("from TK_Trialkitting_Results T group by cInvCode,ProdGroup,Planner)");

            //获得记录
            List<TK_POEntity> list = new List<TK_POEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.iID ");
            strSql.Append(")AS Row, T.* from TK_PO T ");
            strSql.AppendFormat("left join {0} R on T.iItemNO=R.cInvCode and T.sBuyer=R.Planner and T.sProductGroup=R.ProdGroup", strSqls);
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql.Replace("1=1", "1=1" + sWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);

            
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

    }
}
