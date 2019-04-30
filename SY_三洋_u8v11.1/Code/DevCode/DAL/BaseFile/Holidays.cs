using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections.Generic;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:Holidays
    /// </summary>
    public partial class Holidays
    {
        public Holidays()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(DateTime dHolidays)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Holidays");
            strSql.Append(" where dHolidays='" + dHolidays + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        public int Del(List<TH.Model.Holidays> l)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].iID == 0)
                {
                    continue;
                }

                list.Add(Delete(l[i].iID));
            }
            return DbHelperSQL.ExecuteSqlTran(list);
        }

        public int Save(List<TH.Model.Holidays> l)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].iID == 0)
                {
                    l[i].CreateUid = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    l[i].CreateDate = DbHelperSQL.ExecuteGetServerTime();
                    list.Add(Add(l[i]));
                }
                else
                {
                    l[i].UpdataUid = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    l[i].UpdataDate = DbHelperSQL.ExecuteGetServerTime();
                    list.Add(Update(l[i]));
                }
            }
            return DbHelperSQL.ExecuteSqlTran(list);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.Holidays model)
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
            if (model.dHolidays != null)
            {
                strSql1.Append("dHolidays,");
                strSql2.Append("'" + model.dHolidays + "',");
            }
            if (model.HolidaysText != null)
            {
                strSql1.Append("HolidaysText,");
                strSql2.Append("'" + model.HolidaysText + "',");
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
            strSql.Append("insert into Holidays(");
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
        public string Update(TH.Model.Holidays model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Holidays set ");
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
            if (model.HolidaysText != null)
            {
                strSql.Append("HolidaysText='" + model.HolidaysText + "',");
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
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return strSql.ToString();

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Holidays ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();

        }		
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(DateTime dHolidays)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Holidays ");
            strSql.Append(" where dHolidays=@dHolidays ");
            SqlParameter[] parameters = {
					new SqlParameter("@dHolidays", SqlDbType.DateTime)};
            parameters[0].Value = dHolidays;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string iIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Holidays ");
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
        public TH.Model.Holidays GetModel(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" iID,GUID,CreateUid,CreateDate,UpdataUid,UpdataDate,AuditUid,AuditDate,dHolidays,HolidaysText,Remark,Remark2,Remark3,Remark4,Remark5 ");
            strSql.Append(" from Holidays ");
            strSql.Append(" where iID=" + iID + "");
            TH.Model.Holidays model = new TH.Model.Holidays();
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
        public TH.Model.Holidays DataRowToModel(DataRow row)
        {
            TH.Model.Holidays model = new TH.Model.Holidays();
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
                if (row["dHolidays"] != null && row["dHolidays"].ToString() != "")
                {
                    model.dHolidays = DateTime.Parse(row["dHolidays"].ToString());
                }
                if (row["HolidaysText"] != null)
                {
                    model.HolidaysText = row["HolidaysText"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select iID,GUID,CreateUid,CreateDate,UpdataUid,UpdataDate,AuditUid,AuditDate,dHolidays,HolidaysText,Remark,Remark2,Remark3,Remark4,Remark5 ");
            strSql.Append(" FROM Holidays ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" iID,GUID,CreateUid,CreateDate,UpdataUid,UpdataDate,AuditUid,AuditDate,dHolidays,HolidaysText,Remark,Remark2,Remark3,Remark4,Remark5 ");
            strSql.Append(" FROM Holidays ");
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
            strSql.Append("select count(1) FROM Holidays ");
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
            strSql.Append(")AS Row, T.*  from Holidays T ");
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

