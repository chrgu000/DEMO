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
    public class TK_Trialkit_Trial_UploadData
    {

        public TK_Trialkit_Trial_UploadData()
        { }

        /// <summary>
        /// 得到新的版本号
        /// </summary>
        /// <returns></returns>
        public string GetNewVersion(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select '" + UserID + "-" + DateTime.Now.ToString("yyyyMMdd") + "'+right('0'+convert(nvarchar(10),isnull(convert(int,right(max(sTKVersion),2)),0)+1),2) from TK_Trialkit_Trial_Upload ");
            strSql.Append(" where sTKVersion like '%" + UserID + "-" + DateTime.Now.ToString("yyyyMMdd") + "%'");
            string s = DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0][0].ToString();
            return s;
        }

        /// <summary>
        /// 得到新的版本号
        /// </summary>
        /// <returns></returns>
        public string GetMaxVersion()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(sVersion) as sVersion from TK_NetRequirement ");
            string s = DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0][0].ToString();
            return s;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(TK_Trialkit_Trial_UploadEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.Guid != null)
            {
                strSql1.Append("Guid,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.sTKVersion != null)
            {
                strSql1.Append("sTKVersion,");
                strSql2.Append("'" + model.sTKVersion + "',");
            }
            if (model.sDataVersion != null)
            {
                strSql1.Append("sDataVersion,");
                strSql2.Append("'" + model.sDataVersion + "',");
            }
            if (model.Partid != null)
            {
                strSql1.Append("Partid,");
                strSql2.Append("'" + model.Partid + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.dtmPeriod != null)
            {
                strSql1.Append("dtmPeriod,");
                strSql2.Append("'" + model.dtmPeriod + "',");
            }
            if (model.Qty != null)
            {
                strSql1.Append("Qty,");
                strSql2.Append("" + model.Qty + ",");
            }
            if (model.iUpload_Type != null)
            {
                strSql1.Append("iUpload_Type,");
                strSql2.Append("" + model.iUpload_Type + ",");
            }
            if (model.sTKVersion_Contrast != null)
            {
                strSql1.Append("sTKVersion_Contrast,");
                strSql2.Append("'" + model.sTKVersion_Contrast + "',");
            }
            if (model.iTK_Type != null)
            {
                strSql1.Append("iTK_Type,");
                strSql2.Append("" + model.iTK_Type + ",");
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
            strSql.Append("insert into TK_Trialkit_Trial_Upload(");
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
        public string Update(TK_Trialkit_Trial_UploadEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_Trialkit_Trial_Upload set ");
            if (model.Guid != null)
            {
                strSql.Append("Guid='" + model.Guid + "',");
            }
            else
            {
                strSql.Append("Guid= null ,");
            }
            if (model.dDate != null)
            {
                strSql.Append("dDate='" + model.dDate + "',");
            }
            else
            {
                strSql.Append("dDate= null ,");
            }
            if (model.Qty != null)
            {
                strSql.Append("Qty=" + model.Qty + ",");
            }
            else
            {
                strSql.Append("Qty= null ,");
            }
            if (model.iUpload_Type != null)
            {
                strSql.Append("iUpload_Type=" + model.iUpload_Type + ",");
            }
            else
            {
                strSql.Append("iUpload_Type= null ,");
            }
            if (model.sTKVersion_Contrast != null)
            {
                strSql.Append("sTKVersion_Contrast='" + model.sTKVersion_Contrast + "',");
            }
            else
            {
                strSql.Append("sTKVersion_Contrast= null ,");
            }
            if (model.iTK_Type != null)
            {
                strSql.Append("iTK_Type=" + model.iTK_Type + ",");
            }
            else
            {
                strSql.Append("iTK_Type= null ,");
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
            strSql.Append("delete from TK_Trialkit_Trial_Upload ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TK_Trialkit_Trial_UploadEntity DataRowToModel(DataRow row)
        {
            TK_Trialkit_Trial_UploadEntity model = new TK_Trialkit_Trial_UploadEntity();
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
                if (row["sTKVersion"] != null)
                {
                    model.sTKVersion = row["sTKVersion"].ToString();
                }
                if (row["sDataVersion"] != null)
                {
                    model.sDataVersion = row["sDataVersion"].ToString();
                }
                if (row["Partid"] != null)
                {
                    model.Partid = row["Partid"].ToString();
                }
                if (row["dDate"] != null && row["dDate"].ToString() != "")
                {
                    model.dDate = DateTime.Parse(row["dDate"].ToString());
                }
                if (row["dtmPeriod"] != null && row["dtmPeriod"].ToString() != "")
                {
                    model.dtmPeriod = DateTime.Parse(row["dtmPeriod"].ToString());
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = decimal.Parse(row["Qty"].ToString());
                }
                if (row["iUpload_Type"] != null && row["iUpload_Type"].ToString() != "")
                {
                    model.iUpload_Type = int.Parse(row["iUpload_Type"].ToString());
                }
                if (row["sTKVersion_Contrast"] != null)
                {
                    model.sTKVersion_Contrast = row["sTKVersion_Contrast"].ToString();
                }
                if (row["iTK_Type"] != null && row["iTK_Type"].ToString() != "")
                {
                    model.iTK_Type = int.Parse(row["iTK_Type"].ToString());
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere">查询条件</param>
        /// <returns></returns>
        public List<TK_Trialkit_Trial_UploadEntity> GetList(string sWhere)
        {

            List<TK_Trialkit_Trial_UploadEntity> list = new List<TK_Trialkit_Trial_UploadEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select * From TK_Trialkit_Trial_Upload where 1=1 Order By iID ");
            strSql = strSql.Replace("1=1", "1=1" + sWhere);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TK_Trialkit_Trial_UploadEntity sh = DataRowToModel(row);
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
            strCountSql.Append(" Select Count(1) From TK_Trialkit_Trial_Upload T ");
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
            strSql.Append(")AS Row, T.* from TK_Trialkit_Trial_Upload T ");
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
