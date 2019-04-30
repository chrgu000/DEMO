using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections.Generic;
namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:ProductionLinePeopleNO
    /// </summary>
    public partial class ProductionLinePeopleNO
    {
        public ProductionLinePeopleNO()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LineNO, DateTime dDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductionLinePeopleNO");
            strSql.Append(" where [LineNO]='" + LineNO + "' and dDate='" + dDate + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        public int Del(DateTime dTime)
        {
            string sSQL = Delete(dTime);
            return DbHelperSQL.ExecuteSql(sSQL);
        }


        public int Save(List<TH.Model.ProductionLinePeopleNO> l)
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
                    l[i].UpdateUid = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    l[i].UpdateDate = DbHelperSQL.ExecuteGetServerTime();
                    list.Add(Update(l[i]));
                }
            }
            return DbHelperSQL.ExecuteSqlTran(list);
        }

        public int Save(DateTime dTime, DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                if (dt == null || dt.Rows.Count == 0)
                    throw new Exception("没有需要保存的数据");

                string sSQL = Delete(dTime);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TH.Model.ProductionLinePeopleNO model = new TH.Model.ProductionLinePeopleNO();
                    model = DataRowToModel(dt.Rows[i]);
                    if (model.LineNO == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "产线不能为空\n";
                        continue;
                    }
                    if (model.PeopleNO == null && model.LineNO != "99")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "人数不能为空\n";
                        continue;
                    }

                    sSQL = Add(model);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                if (sErr.Trim() != "")
                    throw new Exception(sErr);

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }


        /// <summary>
        /// 判断当天是否排产
        /// </summary>
        /// <param name="dTime"></param>
        /// <returns></returns>
        public bool CheckPC(DateTime dTime)
        {
            bool b = false;

            int iCou = 0;
            string sSQL = "select count(1) from dbo.生产日计划 where 排产日期 = '111111'";
            sSQL = sSQL.Replace("111111", dTime.ToString("yyyy-MM-dd"));
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                iCou = BaseFunction.BaseFunction.ReturnInt(dt.Rows[0][0]);
            }
            if (iCou > 0)
                b = true;

            return b;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.ProductionLinePeopleNO model)
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
            if (model.UpdateUid != null)
            {
                strSql1.Append("UpdateUid,");
                strSql2.Append("'" + model.UpdateUid + "',");
            }
            if (model.UpdateDate != null)
            {
                strSql1.Append("UpdateDate,");
                strSql2.Append("'" + model.UpdateDate + "',");
            }
            if (model.LineNO != null)
            {
                strSql1.Append("[LineNO],");
                strSql2.Append("'" + model.LineNO + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.PeopleNO != null)
            {
                strSql1.Append("PeopleNO,");
                strSql2.Append("" + model.PeopleNO + ",");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            strSql.Append("insert into ProductionLinePeopleNO(");
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
        public string Update(TH.Model.ProductionLinePeopleNO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductionLinePeopleNO set ");
            if (model.GUID != null)
            {
                strSql.Append("GUID='" + model.GUID + "',");
            }
            else
            {
                strSql.Append("GUID= null ,");
            }
            if (model.CreateUid != null)
            {
                strSql.Append("CreateUid='" + model.CreateUid + "',");
            }
            else
            {
                strSql.Append("CreateUid= null ,");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
            }
            else
            {
                strSql.Append("CreateDate= null ,");
            }
            if (model.UpdateUid != null)
            {
                strSql.Append("UpdateUid='" + model.UpdateUid + "',");
            }
            else
            {
                strSql.Append("UpdateUid= null ,");
            }
            if (model.UpdateDate != null)
            {
                strSql.Append("UpdateDate='" + model.UpdateDate + "',");
            }
            else
            {
                strSql.Append("UpdateDate= null ,");
            }
            if (model.PeopleNO != null)
            {
                strSql.Append("PeopleNO=" + model.PeopleNO + ",");
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
            return strSql.ToString();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(DateTime dTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductionLinePeopleNO ");
            strSql.Append(" where dDate='" + dTime.ToString("yyyy-MM-dd") + "'");
            return strSql.ToString();
        }		/// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string LineNO, DateTime dDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductionLinePeopleNO ");
            strSql.Append(" where [LineNO]=@LineNO and dDate=@dDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@LineNO", SqlDbType.VarChar,-1),
					new SqlParameter("@dDate", SqlDbType.DateTime)};
            parameters[0].Value = LineNO;
            parameters[1].Value = dDate;

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
        /// 获得数据列表
        /// </summary>
        public DataTable GetMonthList(string strWhere)
        {
            DateTime d = Convert.ToDateTime(strWhere);

            string sSQL = @"
select a.[LineNo] ,b.LineName
	,sum(case when day(dDate) =1 then a.PeopleNO end) as i1
	,sum(case when day(dDate) =2 then a.PeopleNO end) as i2
	,sum(case when day(dDate) =3 then a.PeopleNO end) as i3
	,sum(case when day(dDate) =4 then a.PeopleNO end) as i4
	,sum(case when day(dDate) =5 then a.PeopleNO end) as i5
	,sum(case when day(dDate) =6 then a.PeopleNO end) as i6
	,sum(case when day(dDate) =7 then a.PeopleNO end) as i7
	,sum(case when day(dDate) =8 then a.PeopleNO end) as i8
	,sum(case when day(dDate) =9 then a.PeopleNO end) as i9
	,sum(case when day(dDate) =10 then a.PeopleNO end) as i10
	,sum(case when day(dDate) =11 then a.PeopleNO end) as i11
	,sum(case when day(dDate) =12 then a.PeopleNO end) as i12
	,sum(case when day(dDate) =13 then a.PeopleNO end) as i13
	,sum(case when day(dDate) =14 then a.PeopleNO end) as i14
	,sum(case when day(dDate) =15 then a.PeopleNO end) as i15
	,sum(case when day(dDate) =16 then a.PeopleNO end) as i16
	,sum(case when day(dDate) =17 then a.PeopleNO end) as i17
	,sum(case when day(dDate) =18 then a.PeopleNO end) as i18
	,sum(case when day(dDate) =19 then a.PeopleNO end) as i19
	,sum(case when day(dDate) =20 then a.PeopleNO end) as i20
	,sum(case when day(dDate) =21 then a.PeopleNO end) as i21
	,sum(case when day(dDate) =22 then a.PeopleNO end) as i22
	,sum(case when day(dDate) =23 then a.PeopleNO end) as i23
	,sum(case when day(dDate) =24 then a.PeopleNO end) as i24
	,sum(case when day(dDate) =25 then a.PeopleNO end) as i25
	,sum(case when day(dDate) =26 then a.PeopleNO end) as i26
	,sum(case when day(dDate) =27 then a.PeopleNO end) as i27
	,sum(case when day(dDate) =28 then a.PeopleNO end) as i28
	,sum(case when day(dDate) =29 then a.PeopleNO end) as i29
	,sum(case when day(dDate) =30 then a.PeopleNO end) as i30
	,sum(case when day(dDate) =31 then a.PeopleNO end) as i31
from ProductionLinePeopleNO a inner join dbo.ProductionLine b on a.[LineNo] = b.[LineNO]
where a.dDate >= '111111' and a.dDate < '222222'
group by a.[LineNo] ,b.LineName
order by a.[LineNo] ,b.LineName
";
            sSQL = sSQL.Replace("111111", d.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("222222", d.AddMonths(1).ToString("yyyy-MM-dd"));
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string iIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductionLinePeopleNO ");
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


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public TH.Model.ProductionLinePeopleNO GetModel(int iID)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select  top 1  ");
        //    strSql.Append(" iID,GUID,CreateUid,CreateDate,UpdateUid,UpdateDate,[LineNO],dDate,PeopleNO,Remark ");
        //    strSql.Append(" from ProductionLinePeopleNO ");
        //    strSql.Append(" where iID=" + iID + "");
        //    TH.Model.ProductionLinePeopleNO model = new TH.Model.ProductionLinePeopleNO();
        //    DataTable dt = DbHelperSQL.Query(strSql.ToString());
        //    if (dt.Rows.Count > 0)
        //    {
        //        return DataRowToModel(dt.Rows[0]);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.ProductionLinePeopleNO DataRowToModel(DataRow row)
        {
            TH.Model.ProductionLinePeopleNO model = new TH.Model.ProductionLinePeopleNO();
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
                if (row["UpdateUid"] != null)
                {
                    model.UpdateUid = row["UpdateUid"].ToString();
                }
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
                }
                if (row["LineNO"] != null)
                {
                    model.LineNO = row["LineNO"].ToString();
                }
                if (row["dDate"] != null && row["dDate"].ToString() != "")
                {
                    model.dDate = DateTime.Parse(row["dDate"].ToString());
                }
                if (row["PeopleNO"] != null && row["PeopleNO"].ToString() != "")
                {
                    model.PeopleNO = int.Parse(row["PeopleNO"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select a.[LineNO],a.[LineName],b.iID, b.GUID, b.CreateUid, b.CreateDate, b.UpdateUid, b.UpdateDate, b.dDate, b.PeopleNO, b.Remark ");
            //strSql.Append(" from dbo.ProductionLine a left join dbo.ProductionLinePeopleNO b on a.[LineNo] = b.[LineNO] and b.dDate = '111111' ");

            string sSQL = @"
select a.[LineNO],a.[LineName],b.iID, b.GUID, b.CreateUid, b.CreateDate, b.UpdateUid, b.UpdateDate, b.dDate, b.PeopleNO, b.Remark 
	,isnull(d.iText,0) as 状态 
from dbo.ProductionLine a 
	left join ProductionLineState c on a.[LineNO] = c.[LineNO] and c.dDate = '111111' 
    left join dbo.ProductionLinePeopleNO b on a.[LineNo] = b.[LineNO] and b.dDate = '111111' 
	left join _LookUpDate d on isnull(d.iID,0) = isnull(c.[State],0) and d.iType = '01'
order by a.[LineNO]
";
            sSQL = sSQL.Replace("111111", strWhere);
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList2(string strWhere)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select a.[LineNO],a.[LineName],b.iID, b.GUID, b.CreateUid, b.CreateDate, b.UpdateUid, b.UpdateDate, b.dDate, a.PeopleNO, b.Remark ");
            //strSql.Append(" from dbo.ProductionLine a left join dbo.ProductionLinePeopleNO b on a.[LineNo] = b.[LineNO] and b.dDate = '111111' ");

            //string sSQL = strSql.ToString();

            string sSQL = @"
select a.[LineNO],a.[LineName],b.iID, b.GUID, b.CreateUid, b.CreateDate, b.UpdateUid, b.UpdateDate, b.dDate, a.PeopleNO, b.Remark 
	,isnull(d.iText,0) as 状态 
from dbo.ProductionLine a 
	left join ProductionLineState c on a.[LineNO] = c.[LineNO] and c.dDate = '111111' 
    left join dbo.ProductionLinePeopleNO b on a.[LineNo] = b.[LineNO] and b.dDate = '111111' 
	left join _LookUpDate d on isnull(d.iID,0) = isnull(c.[State],0) and d.iType = '01'
order by a.[LineNO]
";
            sSQL = sSQL.Replace("111111", strWhere);
            return DbHelperSQL.Query(sSQL);
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
            strSql.Append(" iID,GUID,CreateUid,CreateDate,UpdateUid,UpdateDate,[LineNO],dDate,PeopleNO,Remark ");
            strSql.Append(" FROM ProductionLinePeopleNO ");
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
            strSql.Append("select count(1) FROM ProductionLinePeopleNO ");
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
            strSql.Append(")AS Row, T.*  from ProductionLinePeopleNO T ");
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

