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
    public class TK_ListData
    {

        public TK_ListData()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(TK_ListEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.sType != null)
            {
                strSql1.Append("sType,");
                strSql2.Append("'" + model.sType + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.sVerData != null)
            {
                strSql1.Append("sVerData,");
                strSql2.Append("'" + model.sVerData + "',");
            }
            if (model.sVerTrialkitting != null)
            {
                strSql1.Append("sVerTrialkitting,");
                strSql2.Append("'" + model.sVerTrialkitting + "',");
            }
            if (model.ProdGroup != null)
            {
                strSql1.Append("ProdGroup,");
                strSql2.Append("'" + model.ProdGroup + "',");
            }
            if (model.Planner != null)
            {
                strSql1.Append("Planner,");
                strSql2.Append("'" + model.Planner + "',");
            }
            if (model.sVersion != null)
            {
                strSql1.Append("sVersion,");
                strSql2.Append("'" + model.sVersion + "',");
            }
            if (model.iState != null)
            {
                strSql1.Append("iState,");
                strSql2.Append("" + model.iState + ",");
            }
            if (model.sResult != null)
            {
                strSql1.Append("sResult,");
                strSql2.Append("'" + model.sResult + "',");
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
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("'" + model.dtmCreate + "',");
            }
            if (model.dtmStart != null)
            {
                strSql1.Append("dtmStart,");
                strSql2.Append("'" + model.dtmStart + "',");
            }
            if (model.dtmEnd != null)
            {
                strSql1.Append("dtmEnd,");
                strSql2.Append("'" + model.dtmEnd + "',");
            }
            if (model.iCheckTime != null)
            {
                strSql1.Append("iCheckTime,");
                strSql2.Append("" + model.iCheckTime + ",");
            }
            strSql.Append("insert into TK_List(");
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
        public string Update(TK_ListEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_List set ");
            if (model.sType != null)
            {
                strSql.Append("sType='" + model.sType + "',");
            }
            else
            {
                strSql.Append("sType= null ,");
            }
            if (model.dDate != null)
            {
                strSql.Append("dDate='" + model.dDate + "',");
            }
            else
            {
                strSql.Append("dDate= null ,");
            }
            if (model.sVerData != null)
            {
                strSql.Append("sVerData='" + model.sVerData + "',");
            }
            else
            {
                strSql.Append("sVerData= null ,");
            }
            if (model.sVerTrialkitting != null)
            {
                strSql.Append("sVerTrialkitting='" + model.sVerTrialkitting + "',");
            }
            else
            {
                strSql.Append("sVerTrialkitting= null ,");
            }
            if (model.ProdGroup != null)
            {
                strSql.Append("ProdGroup='" + model.ProdGroup + "',");
            }
            else
            {
                strSql.Append("ProdGroup= null ,");
            }
            if (model.Planner != null)
            {
                strSql.Append("Planner='" + model.Planner + "',");
            }
            else
            {
                strSql.Append("Planner= null ,");
            }
            if (model.sVersion != null)
            {
                strSql.Append("sVersion='" + model.sVersion + "',");
            }
            else
            {
                strSql.Append("sVersion= null ,");
            }
            if (model.iState != null)
            {
                strSql.Append("iState=" + model.iState + ",");
            }
            else
            {
                strSql.Append("iState= null ,");
            }
            if (model.sResult != null)
            {
                strSql.Append("sResult='" + model.sResult + "',");
            }
            else
            {
                strSql.Append("sResult= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.CreateUid != null)
            {
                strSql.Append("CreateUid='" + model.CreateUid + "',");
            }
            else
            {
                strSql.Append("CreateUid= null ,");
            }
            if (model.dtmCreate != null)
            {
                strSql.Append("dtmCreate='" + model.dtmCreate + "',");
            }
            else
            {
                strSql.Append("dtmCreate= null ,");
            }
            if (model.dtmStart != null)
            {
                strSql.Append("dtmStart='" + model.dtmStart + "',");
            }
            else
            {
                strSql.Append("dtmStart= null ,");
            }
            if (model.dtmEnd != null)
            {
                strSql.Append("dtmEnd='" + model.dtmEnd + "',");
            }
            else
            {
                strSql.Append("dtmEnd= null ,");
            }
            if (model.iCheckTime != null)
            {
                strSql.Append("iCheckTime=" + model.iCheckTime + ",");
            }
            else
            {
                strSql.Append("iCheckTime= null ,");
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

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        ///// <param name="iID">删除ID</param>
        ///// <returns></returns>
        //public string Delete(string iID)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("delete from TK_List ");
        //    strSql.Append(" where iID=" + iID + "");
        //    return strSql.ToString();
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TK_ListEntity DataRowToModel(DataRow row)
        {
            TK_ListEntity model = new TK_ListEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["sType"] != null)
                {
                    model.sType = row["sType"].ToString();
                }
                if (row["dDate"] != null && row["dDate"].ToString() != "")
                {
                    model.dDate = DateTime.Parse(row["dDate"].ToString());
                }
                if (row["sVerData"] != null)
                {
                    model.sVerData = row["sVerData"].ToString();
                }
                if (row["sVerTrialkitting"] != null)
                {
                    model.sVerTrialkitting = row["sVerTrialkitting"].ToString();
                }
                if (row["ProdGroup"] != null)
                {
                    model.ProdGroup = row["ProdGroup"].ToString();
                }
                if (row["Planner"] != null)
                {
                    model.Planner = row["Planner"].ToString();
                }
                if (row["sVersion"] != null)
                {
                    model.sVersion = row["sVersion"].ToString();
                }
                if (row["iState"] != null && row["iState"].ToString() != "")
                {
                    model.iState = int.Parse(row["iState"].ToString());
                }
                if (row["sResult"] != null)
                {
                    model.sResult = row["sResult"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CreateUid"] != null)
                {
                    model.CreateUid = row["CreateUid"].ToString();
                }
                if (row["dtmCreate"] != null && row["dtmCreate"].ToString() != "")
                {
                    model.dtmCreate = DateTime.Parse(row["dtmCreate"].ToString());
                }
                if (row["dtmStart"] != null && row["dtmStart"].ToString() != "")
                {
                    model.dtmStart = DateTime.Parse(row["dtmStart"].ToString());
                }
                if (row["dtmEnd"] != null && row["dtmEnd"].ToString() != "")
                {
                    model.dtmEnd = DateTime.Parse(row["dtmEnd"].ToString());
                }
                if (row["iCheckTime"] != null && row["iCheckTime"].ToString() != "")
                {
                    model.iCheckTime = int.Parse(row["iCheckTime"].ToString());
                }
            }
            return model;
        }

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        ///// <param name="sWhere">查询条件</param>
        ///// <returns></returns>
        //public List<TK_ListEntity> GetList(string sWhere)
        //{
        //    List<TK_ListEntity> list = new List<TK_ListEntity>();
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.AppendFormat(" Select * From TK_List where 1=1 Order By iID ");
        //    if (!string.IsNullOrEmpty(sWhere))
        //        strSql = strSql.Replace("1=1", "1=1" + sWhere);
        //    DataSet ds = DbHelperSQL.Query(strSql.ToString());
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            TK_ListEntity sh = DataRowToModel(row);
        //            list.Add(sh);
        //        }
        //        return list;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere">查询条件</param>
        /// <returns></returns>
        public DataTable GetList(string sWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select * From TK_List where 1=1 Order By iID ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql = strSql.Replace("1=1", "1=1" + sWhere);
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
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
            strCountSql.Append(" Select Count(1) From TK_List T ");
            strCountSql.Append(" Where isdel=0 and 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));
            //获得记录
            List<TK_ListEntity> list = new List<TK_ListEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.iID desc ");
            strSql.Append(")AS Row, T.* from TK_List T ");
            strSql.Append(" WHERE isdel=0 and 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql.Replace("1=1", "1=1" + sWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        public int GetIsRun(string sWhere)
        {
            //获得记录总数
            StringBuilder strCountSql = new StringBuilder();
            strCountSql.Append(" Select Count(1) From TK_List T ");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));

        }

        public string Stop(string iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_List set iState=4 ");
            strSql.Append(" where iID=" + iID + "");

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

        public string Delete(string iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_List set isdel=1 ");
            strSql.Append(" where iID=" + iID + "");

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
    }
}
