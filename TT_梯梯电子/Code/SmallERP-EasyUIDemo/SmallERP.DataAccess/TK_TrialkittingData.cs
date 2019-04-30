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
    public class TK_TrialkittingData
    {

        public TK_TrialkittingData()
        { }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public string Add(TK_TrialkittingEntity model)
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
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            strSql.Append("insert into TK_Trialkitting(");
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
        public string Update(TK_TrialkittingEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_Trialkitting set ");
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
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
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
        /// 
        /// </summary>
        /// <param name="model"></param>
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

        #region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TK_TrialkittingEntity DataRowToModel(DataRow row)
        {
            TK_TrialkittingEntity model = new TK_TrialkittingEntity();
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
                if (row["CreateUid"] != null)
                {
                    model.CreateUid = row["CreateUid"].ToString();
                }
                if (row["dtmCreate"] != null && row["dtmCreate"].ToString() != "")
                {
                    model.dtmCreate = DateTime.Parse(row["dtmCreate"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
            }
            return model;
        }
        #endregion  BasicMethod

        ////<summary>
        ////获得数据列表
        ////</summary>
        ////<returns></returns>
        //public List<TK_TrialkittingEntity> GetList(string sWhere)
        //{

        //    List<TK_TrialkittingEntity> list = new List<TK_TrialkittingEntity>();
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.AppendFormat(" Select * From TK_Trialkitting where 1=1 Order By iID ");
        //    strSql = strSql.Replace("1=1", "1=1" + sWhere);
        //    DataSet ds = DbHelperSQL.Query(strSql.ToString());
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            TK_TrialkittingEntity sh = DataRowToModel(row);
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
        /// 分页查询列表
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
            strCountSql.Append(" Select Count(1) From TK_Trialkitting_Result T with (nolock)");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));

            //获得记录
            List<TK_NetRequirementEntity> list = new List<TK_NetRequirementEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.iID ");
            strSql.Append(")AS Row, T.* from TK_Trialkitting_Result T with (nolock)");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql.Replace("1=1", "1=1" + sWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        /// <summary>
        /// Trialkit版本号
        /// </summary>
        /// <returns></returns>
        public DataTable GetTKTrialkitVersion()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("  Select distinct sTKVersion as iID,sTKVersion as iText From _Get_TK_Trialkit_Version with (nolock) order by sTKVersion desc ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// Trialkit版本号Result
        /// </summary>
        /// <returns></returns>
        public DataTable GetTKTrialkitVersionResult()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("  Select distinct sTKVersion as iID,sTKVersion as iText From  _Get_TK_Trialkit_Version with (nolock) order by sTKVersion desc ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        public DataTable GetNetQtyList(string queryVersion, string sPartID, string sWhere, string userId, string name, string roleId, int rowStart, int rowEnd, out int total)
        {
            StringBuilder strCountSql = new StringBuilder();
            strCountSql.Append(@" Select Count(1) From TK_Trialkit_Net_Details T with (nolock) 
                Where 1=1 group by PartID,dtmPeriod ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));
            //获得记录
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(@"SELECT ROW_NUMBER() OVER (Order By PartID,dtmPeriod)AS Row, PartID,dtmPeriod,sum(NetQty) as NetQty from TK_Trialkit_Net_Details T with (nolock) 
                Where 1=1 group by PartID,dtmPeriod ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql.Replace("1=1", "1=1" + sWhere);
            //strSql.Replace("1=1", "1=1 and sPartID='030019-TT' and R.sTKVersion='00-20181127'");
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetQueryList(string sWhere, string userId, string name, string roleId, int rowStart, int rowEnd, out int total)
        {
            //获得记录总数
            StringBuilder strCountSql = new StringBuilder();
            strCountSql.Append(@" 
select distinct a.sTKVersion,convert(nvarchar(10),dtmCreate,120) as dtmCreate,ProdGroup,Remark into #a from TK_Trialkitting_Result a  with (nolock) 
left join TK_Trialkitting_Results b on a.sTKVersion=b.sTKVersion 
left join _GET_TK_PGROUP_CATECORY c on b.ProdGroup=c.prodgroup 
where 1=1 group by a.sTKVersion,ProdGroup,Remark,convert(nvarchar(10),dtmCreate,120),default_plannerid
Select Count(1) From 
(
SELECT  sTKVersion,dtmCreate,Remark,
        ProdGroup = ( STUFF(( SELECT    ',' + ProdGroup
                          FROM      #a
                          WHERE     sTKVersion = Test.sTKVersion
                        FOR
                          XML PATH('')
                        ), 1, 1, '') )
FROM    #a Test
GROUP BY sTKVersion,dtmCreate,Remark
) T ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));

            //获得记录
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
select distinct a.sTKVersion,convert(nvarchar(10),dtmCreate,120) as dtmCreate,ProdGroup,Remark,default_plannerid into #a from TK_Trialkitting_Result a  with (nolock) 
left join TK_Trialkitting_Results b on a.sTKVersion=b.sTKVersion 
left join _GET_TK_PGROUP_CATECORY c on b.ProdGroup=c.prodgroup 
where 1=1 group by a.sTKVersion,ProdGroup,Remark,convert(nvarchar(10),dtmCreate,120) ,default_plannerid
SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.sTKVersion ");
            strSql.Append(@")AS Row, sTKVersion,dtmCreate,Remark,case when SUBSTRING(sTKVersion,1,2)='00' then 'ALL' else ProdGroup end ProdGroup from 
(
SELECT  sTKVersion,dtmCreate,Remark,
        ProdGroup = ( STUFF(( SELECT    ',' + ProdGroup
                          FROM      #a
                          WHERE     sTKVersion = Test.sTKVersion
                        FOR
                          XML PATH('')
                        ), 1, 1, '') )
FROM    #a Test
GROUP BY sTKVersion,dtmCreate,Remark
) T ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql.Replace("1=1", "1=1" + sWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }
    }
}
