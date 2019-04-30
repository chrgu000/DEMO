using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections.Generic;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:ProductionLine
    /// </summary>
    public partial class ProductionLine
    {
        public ProductionLine()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LineNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductionLine");
            strSql.Append(" where [LineNo]='" + LineNo + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 是否引用过该记录
        /// </summary>
        public bool bUsed(string LineNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductionLineState");
            strSql.Append(" where [LineNo]='" + LineNo + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        public int Del(List<TH.Model.ProductionLine> l)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].iID == 0)
                {
                    continue;
                }

                list.Add(Delete(l[i].LineNo));
            }
            return DbHelperSQL.ExecuteSqlTran(list);
        }

        public DataTable GetLookup()
        {
            string sSQL = "select * from dbo._LookUpDate where iType = '01' and iID <> 0 order by iID";
            DataTable dt = DbHelperSQL.Query(sSQL);
            return dt;
        }

        public int Save(List<TH.Model.ProductionLine> l)
        {
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < l.Count; i++)
                {
                    string sSQL = "select * from ProductionLine where [LineNo] = '" + l[i].LineNo + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        l[i].UpdataUid = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                        l[i].UpdataDate = DbHelperSQL.ExecuteGetServerTime();
                        sSQL = Update(l[i]);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        l[i].CreateUid = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                        l[i].CreateDate = DbHelperSQL.ExecuteGetServerTime();
                         sSQL = Add(l[i]);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        public int Open(List<TH.Model.ProductionLine> l)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].CloseUid == "")
                    continue;

                l[i].CloseUid = null;
                l[i].CloseDate = null;
                list.Add(Update(l[i]));

            }
            return DbHelperSQL.ExecuteSqlTran(list);
        }

        public int Close(List<TH.Model.ProductionLine> l)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].CloseUid != "")
                    continue;

                l[i].CloseUid = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                l[i].CloseDate = DbHelperSQL.ExecuteGetServerTime();

                list.Add(Update(l[i]));

            }
            return DbHelperSQL.ExecuteSqlTran(list);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.ProductionLine model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
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
            if (model.UpdataUid != null)
            {
                strSql1.Append("UpdataUid,");
                strSql2.Append("'" + model.UpdataUid + "',");
            }
            if (model.UpdataDate != null)
            {
                strSql1.Append("UpdataDate,");
                strSql2.Append("'" + model.UpdataDate + "',");
            }
            if (model.AuditUid != null)
            {
                strSql1.Append("AuditUid,");
                strSql2.Append("'" + model.AuditUid + "',");
            }
            if (model.AuditDate != null)
            {
                strSql1.Append("AuditDate,");
                strSql2.Append("'" + model.AuditDate + "',");
            }
            if (model.CloseUid != null)
            {
                strSql1.Append("CloseUid,");
                strSql2.Append("'" + model.CloseUid + "',");
            }
            if (model.CloseDate != null)
            {
                strSql1.Append("CloseDate,");
                strSql2.Append("'" + model.CloseDate + "',");
            }
            if (model.LineNo != null)
            {
                strSql1.Append("[LineNo],");
                strSql2.Append("'" + model.LineNo + "',");
            }
            if (model.LineName != null)
            {
                strSql1.Append("LineName,");
                strSql2.Append("'" + model.LineName + "',");
            }
            if (model.cDepCode != null)
            {
                strSql1.Append("cDepCode,");
                strSql2.Append("'" + model.cDepCode + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.Remark2 != null)
            {
                strSql1.Append("Remark2,");
                strSql2.Append("'" + model.Remark2 + "',");
            }
            if (model.Remark3 != null)
            {
                strSql1.Append("Remark3,");
                strSql2.Append("'" + model.Remark3 + "',");
            }
            if (model.Remark4 != null)
            {
                strSql1.Append("Remark4,");
                strSql2.Append("'" + model.Remark4 + "',");
            }
            if (model.Remark5 != null)
            {
                strSql1.Append("Remark5,");
                strSql2.Append("'" + model.Remark5 + "',");
            }
            if (model.PeopleNO != null)
            {
                strSql1.Append("PeopleNO,");
                strSql2.Append("'" + model.PeopleNO + "',");
            }
            strSql.Append("insert into ProductionLine(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.ProductionLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductionLine set ");
            if (model.GUID != null)
            {
                strSql.Append("GUID='" + model.GUID + "',");
            }
            if (model.CreateUid != null)
            {
                strSql.Append("CreateUid='" + model.CreateUid + "',");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
            }
            if (model.UpdataUid != null)
            {
                strSql.Append("UpdataUid='" + model.UpdataUid + "',");
            }
            else
            {
                strSql.Append("UpdataUid= null ,");
            }
            if (model.UpdataDate != null)
            {
                strSql.Append("UpdataDate='" + model.UpdataDate + "',");
            }
            else
            {
                strSql.Append("UpdataDate= null ,");
            }
            if (model.AuditUid != null)
            {
                strSql.Append("AuditUid='" + model.AuditUid + "',");
            }
            else
            {
                strSql.Append("AuditUid= null ,");
            }
            if (model.AuditDate != null)
            {
                strSql.Append("AuditDate='" + model.AuditDate + "',");
            }
            else
            {
                strSql.Append("AuditDate= null ,");
            }
            if (model.CloseUid != null)
            {
                strSql.Append("CloseUid='" + model.CloseUid + "',");
            }
            else
            {
                strSql.Append("CloseUid= null ,");
            }
            if (model.CloseDate != null)
            {
                strSql.Append("CloseDate='" + model.CloseDate + "',");
            }
            else
            {
                strSql.Append("CloseDate= null ,");
            }
            if (model.LineName != null)
            {
                strSql.Append("LineName='" + model.LineName + "',");
            }
            else
            {
                strSql.Append("LineName= null ,");
            }
            if (model.cDepCode != null)
            {
                strSql.Append("cDepCode='" + model.cDepCode + "',");
            }
            else
            {
                strSql.Append("cDepCode= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.Remark2 != null)
            {
                strSql.Append("Remark2='" + model.Remark2 + "',");
            }
            else
            {
                strSql.Append("Remark2= null ,");
            }
            if (model.Remark3 != null)
            {
                strSql.Append("Remark3='" + model.Remark3 + "',");
            }
            else
            {
                strSql.Append("Remark3= null ,");
            }
            if (model.Remark4 != null)
            {
                strSql.Append("Remark4='" + model.Remark4 + "',");
            }
            else
            {
                strSql.Append("Remark4= null ,");
            }
            if (model.Remark5 != null)
            {
                strSql.Append("Remark5='" + model.Remark5 + "',");
            }
            else
            {
                strSql.Append("Remark5= null ,");
            }
            if (model.PeopleNO != null)
            {
                strSql.Append("PeopleNO=" + model.PeopleNO + ",");
            }
            else
            {
                strSql.Append("PeopleNO= null ,");
            }

            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where [LineNo]=" + model.LineNo + "");

            return strSql.ToString();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductionLine ");
            strSql.Append(" where iID=" + iID + "");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
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
        public string Delete(string LineNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductionLine ");
            strSql.Append(" where [LineNo]='" + LineNo + "' ");
       
            return strSql.ToString();
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string iIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductionLine ");
            strSql.Append(" where iID in (" + iIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.ProductionLine GetModel(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" iID,GUID,CreateUid,CreateDate,UpdataUid,UpdataDate,AuditUid,AuditDate,CloseUid,CloseDate,[LineNo],LineName,cDepCode,Remark,Remark2,Remark3,Remark4,Remark5,PeopleNO ");
            strSql.Append(" from ProductionLine ");
            strSql.Append(" where iID=" + iID + "");
            TH.Model.ProductionLine model = new TH.Model.ProductionLine();
            DataTable dt = DbHelperSQL.Query(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return DataRowToModel(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.ProductionLine DataRowToModel(DataRow row)
        {
            TH.Model.ProductionLine model = new TH.Model.ProductionLine();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["GUID"] != null && row["GUID"].ToString() != "")
                {
                    model.GUID = new Guid(row["GUID"].ToString());
                }
                if (row["CreateUid"] != null)
                {
                    model.CreateUid = row["CreateUid"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["UpdataUid"] != null)
                {
                    model.UpdataUid = row["UpdataUid"].ToString();
                }
                if (row["UpdataDate"] != null && row["UpdataDate"].ToString() != "")
                {
                    model.UpdataDate = DateTime.Parse(row["UpdataDate"].ToString());
                }
                if (row["AuditUid"] != null)
                {
                    model.AuditUid = row["AuditUid"].ToString();
                }
                if (row["AuditDate"] != null && row["AuditDate"].ToString() != "")
                {
                    model.AuditDate = DateTime.Parse(row["AuditDate"].ToString());
                }
                if (row["CloseUid"] != null)
                {
                    model.CloseUid = row["CloseUid"].ToString();
                }
                if (row["CloseDate"] != null && row["CloseDate"].ToString() != "")
                {
                    model.CloseDate = DateTime.Parse(row["CloseDate"].ToString());
                }
                if (row["LineNo"] != null)
                {
                    model.LineNo = row["LineNo"].ToString();
                }
                if (row["LineName"] != null)
                {
                    model.LineName = row["LineName"].ToString();
                }
                if (row["cDepCode"] != null)
                {
                    model.cDepCode = row["cDepCode"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Remark2"] != null)
                {
                    model.Remark2 = row["Remark2"].ToString();
                }
                if (row["Remark3"] != null)
                {
                    model.Remark3 = row["Remark3"].ToString();
                }
                if (row["Remark4"] != null)
                {
                    model.Remark4 = row["Remark4"].ToString();
                }
                if (row["Remark5"] != null)
                {
                    model.Remark5 = row["Remark5"].ToString();
                }
                if (row["PeopleNO"] != null && row["PeopleNO"].ToString() != "")
                {
                    model.PeopleNO = int.Parse(row["PeopleNO"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select iID,GUID,CreateUid,CreateDate,UpdataUid,UpdataDate,AuditUid,AuditDate,CloseUid,CloseDate,[LineNo],LineName,cDepCode,Remark,Remark2,Remark3,Remark4,Remark5,PeopleNO ");
            strSql.Append(" FROM ProductionLine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by [LineNo] ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" iID,GUID,CreateUid,CreateDate,UpdataUid,UpdataDate,AuditUid,AuditDate,CloseUid,CloseDate,[LineNo],LineName,cDepCode,Remark,Remark2,Remark3,Remark4,Remark5 ");
            strSql.Append(" FROM ProductionLine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ProductionLine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.iID desc");
            }
            strSql.Append(")AS Row, T.*  from ProductionLine T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        */

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

