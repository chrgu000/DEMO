using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections.Generic;
namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:ProductionLineState
    /// </summary>
    public partial class ProductionLineState
    {
        public ProductionLineState()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LineNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductionLineState");
            strSql.Append(" where [LineNo]='" + LineNo + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        public int Del(DateTime dTime)
        {
            bool b = CheckCanEdit(dTime);
            if (b)
            {
                throw new Exception("已经登记生产并发数量信息,不能删除");
            }

            if (CheckPC(dTime))
            {
                throw new Exception("已经排产,不能删除");
            }

            string sSQL = Delete(dTime);
            return DbHelperSQL.ExecuteSql(sSQL);
        }

        /// <summary>
        /// 判断当天是否登记并发生产数
        /// </summary>
        /// <param name="dTime"></param>
        /// <returns></returns>
        public bool CheckCanEdit(DateTime dTime)
        {
            bool b = false;

            string sSQL = "select * from ProductionLinePeopleNO where dDate = '111111'";
            sSQL = sSQL.Replace("111111", dTime.ToString("yyyy-MM-dd"));
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt != null && dt.Rows.Count > 0)
                b = true;

            return b;
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
                if (CheckCanEdit(dTime))
                {
                    throw new Exception("已经登记生产并发数量信息,不能修改");
                }

                if (CheckPC(dTime))
                {
                    throw new Exception("已经排产,不能删除");
                }

                if (dt == null || dt.Rows.Count == 0)
                    throw new Exception("没有需要保存的数据");

                string sSQL = Delete(dTime);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TH.Model.ProductionLineState model = new TH.Model.ProductionLineState();
                    model = DataRowToModel(dt.Rows[i]);

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

        //public int Save(List<TH.Model.ProductionLineState> l)
        //{
        //    List<string> list = new List<string>();
        //    for (int i = 0; i < l.Count; i++)
        //    {
        //        if (l[i].iID == 0)
        //        {
        //            l[i].CreateUid = FrameBaseFunction.ClsBaseDataInfo.sUserName;
        //            l[i].CreateDate = DbHelperSQL.ExecuteGetServerTime();
        //            list.Add(Add(l[i]));
        //        }
        //        else
        //        {
        //            l[i].UpdateUid = FrameBaseFunction.ClsBaseDataInfo.sUserName;
        //            l[i].UpdateDate = DbHelperSQL.ExecuteGetServerTime();
        //            list.Add(Update(l[i]));
        //        }
        //    }
        //    return DbHelperSQL.ExecuteSqlTran(list);
        //}

        ///// <summary>
        ///// 获得参照表
        ///// </summary>
        //public DataSet GetLookUp(List<string> l)
        //{
        //    DataTable ds = new DataTable();

        //    for (int i = 0; i < l.Count; i++)
        //    {
        //        string SQL = l[i].ToString().Trim();
        //        DataTable dt = DbHelperSQL.Query(SQL);
        //    }
        //    return ds;
        //}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.ProductionLineState model)
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
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.State != null)
            {
                strSql1.Append("State,");
                strSql2.Append("'" + model.State + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            strSql.Append("insert into ProductionLineState(");
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
        public string Update(TH.Model.ProductionLineState model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductionLineState set ");
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
            if (model.LineName != null)
            {
                strSql.Append("LineName='" + model.LineName + "',");
            }
            else
            {
                strSql.Append("LineName= null ,");
            }
            if (model.State != null)
            {
                strSql.Append("State='" + model.State + "',");
            }
            else
            {
                strSql.Append("State= null ,");
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
            strSql.Append("delete from ProductionLineState ");
            strSql.Append(" where dDate='" + dTime.ToString("yyyy-MM-dd") + "'");
            return strSql.ToString();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string LineNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductionLineState ");
            strSql.Append(" where [LineNo]=@LineNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@LineNo", SqlDbType.VarChar,-1)};
            parameters[0].Value = LineNo;

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
            strSql.Append("delete from ProductionLineState ");
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
        public TH.Model.ProductionLineState GetModel(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" iID,GUID,CreateUid,CreateDate,UpdateUid,UpdateDate,[LineNo],LineName,dDate,State,Remark ");
            strSql.Append(" from ProductionLineState ");
            strSql.Append(" where iID=" + iID + "");
            TH.Model.ProductionLineState model = new TH.Model.ProductionLineState();
            DataTable ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Rows.Count > 0)
            {
                return DataRowToModel(ds.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.ProductionLineState DataRowToModel(DataRow row)
        {
            TH.Model.ProductionLineState model = new TH.Model.ProductionLineState();
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
                if (row["LineNo"] != null)
                {
                    model.LineNo = row["LineNo"].ToString();
                }
                if (row["LineName"] != null)
                {
                    model.LineName = row["LineName"].ToString();
                }
                if (row["dDate"] != null && row["dDate"].ToString() != "")
                {
                    model.dDate = DateTime.Parse(row["dDate"].ToString());
                }
                if (row["State"] != null)
                {
                    model.State = int.Parse(row["State"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.iID,b.GUID, a.[LineNo],a.LineName,b.CreateUid,b.CreateDate,b.UpdateUid,b.UpdateDate,isnull(b.[State],0) as [State],b.dDate,b.Remark ");
            strSql.Append(" from dbo.ProductionLine a left join dbo.ProductionLineState b on a.[LineNo] = b.[LineNo] and dDate = '111111' ");
            strSql.Append(" where convert(varchar(10),dateadd(day,1,isnull(a.closedate,'2099-1-1')),120) > '111111' ");
            strSql.Append(" order by a.[LineNo]");
            string sSQL = strSql.ToString();
            sSQL = sSQL.Replace("111111", strWhere);
            return DbHelperSQL.Query(sSQL);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetMonthList(string strWhere)
        {
            DateTime d = Convert.ToDateTime(strWhere);

            string sSQL = @"
select a.[LineNo] ,a.LineName
	,sum(case when day(dDate) =1 then isnull(a.State,0) end) as i1
	,sum(case when day(dDate) =2 then isnull(a.State,0) end) as i2
	,sum(case when day(dDate) =3 then isnull(a.State,0) end) as i3
	,sum(case when day(dDate) =4 then isnull(a.State,0) end) as i4
	,sum(case when day(dDate) =5 then isnull(a.State,0) end) as i5
	,sum(case when day(dDate) =6 then isnull(a.State,0) end) as i6
	,sum(case when day(dDate) =7 then isnull(a.State,0) end) as i7
	,sum(case when day(dDate) =8 then isnull(a.State,0) end) as i8
	,sum(case when day(dDate) =9 then isnull(a.State,0) end) as i9
	,sum(case when day(dDate) =10 then isnull(a.State,0) end) as i10
	,sum(case when day(dDate) =11 then isnull(a.State,0) end) as i11
	,sum(case when day(dDate) =12 then isnull(a.State,0) end) as i12
	,sum(case when day(dDate) =13 then isnull(a.State,0) end) as i13
	,sum(case when day(dDate) =14 then isnull(a.State,0) end) as i14
	,sum(case when day(dDate) =15 then isnull(a.State,0) end) as i15
	,sum(case when day(dDate) =16 then isnull(a.State,0) end) as i16
	,sum(case when day(dDate) =17 then isnull(a.State,0) end) as i17
	,sum(case when day(dDate) =18 then isnull(a.State,0) end) as i18
	,sum(case when day(dDate) =19 then isnull(a.State,0) end) as i19
	,sum(case when day(dDate) =20 then isnull(a.State,0) end) as i20
	,sum(case when day(dDate) =21 then isnull(a.State,0) end) as i21
	,sum(case when day(dDate) =22 then isnull(a.State,0) end) as i22
	,sum(case when day(dDate) =23 then isnull(a.State,0) end) as i23
	,sum(case when day(dDate) =24 then isnull(a.State,0) end) as i24
	,sum(case when day(dDate) =25 then isnull(a.State,0) end) as i25
	,sum(case when day(dDate) =26 then isnull(a.State,0) end) as i26
	,sum(case when day(dDate) =27 then isnull(a.State,0) end) as i27
	,sum(case when day(dDate) =28 then isnull(a.State,0) end) as i28
	,sum(case when day(dDate) =29 then isnull(a.State,0) end) as i29
	,sum(case when day(dDate) =30 then isnull(a.State,0) end) as i30
	,sum(case when day(dDate) =31 then isnull(a.State,0) end) as i31
from ProductionLineState a
where dDate >= '111111' and dDate < '222222'
group by a.[LineNo] ,a.LineName
order by a.[LineNo] ,a.LineName
";
            sSQL = sSQL.Replace("111111", d.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("222222", d.AddMonths(1).ToString("yyyy-MM-dd"));
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetMonthList2(string strWhere)
        {
            DateTime d = Convert.ToDateTime(strWhere);

            string sSQL = @"
select distinct a.[LineNo] ,a.LineName
	,cast(null as int) as i1,cast(null as int) as i2,cast(null as int) as i3,cast(null as int) as i4,cast(null as int) as i5,cast(null as int) as i6,cast(null as int) as i7,cast(null as int) as i8,cast(null as int) as i9,cast(null as int) as i10
	,cast(null as int) as i11,cast(null as int) as i12,cast(null as int) as i13,cast(null as int) as i14,cast(null as int) as i15,cast(null as int) as i16,cast(null as int) as i17,cast(null as int) as i18,cast(null as int) as i19,cast(null as int) as i20
	,cast(null as int) as i21,cast(null as int) as i22,cast(null as int) as i23,cast(null as int) as i24,cast(null as int) as i25,cast(null as int) as i26,cast(null as int) as i27,cast(null as int) as i28,cast(null as int) as i29,cast(null as int) as i30
	,cast(null as int) as i31
from ProductionLineState a
where dDate >= '111111' and dDate < '222222'
";
            sSQL = sSQL.Replace("111111", d.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("222222", d.AddMonths(1).ToString("yyyy-MM-dd"));
            return DbHelperSQL.Query(sSQL);
        }

        public DataTable GetLookup()
        {
            string sSQL =  "select * from dbo._LookUpDate where iType = '01' order by iID";
            return DbHelperSQL.Query(sSQL);
        }
        /*
        */

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

