using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:WorkProcess
    /// </summary>
    public partial class ProcessRoute
    {
        public ProcessRoute()
        { }


        public DataTable GetListInvCode(string sInvCode)
        {
            string sSQL = @"
select distinct a.cInvCode,b.cInvName,b.cInvStd,a.Versions
from ProcessRoute a	inner join @u8.Inventory b on a.cInvCode = b.cInvCode
where 1=1
order by a.cInvCode,a.Versions
";
            if (sInvCode.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cInvCode = '" + sInvCode +  "'");
            }
            return DbHelperSQL.Query(sSQL);
        }

        public DataTable GetListAll(string strWhere)
        {
            string sSQL = @"
select distinct a.cInvCode,b.cInvName,b.cInvStd,a.Versions
from ProcessRoute a	inner join @u8.Inventory b on a.cInvCode = b.cInvCode
where 1=1
order by a.cInvCode,a.Versions
";
            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + strWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }

        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select iID,GUID,CreateUid,CreateDate,UpdataUid,UpdataDate,AuditUid,AuditDate,CloseUid,CloseDate,cInvCode,Versions,WorkSort,WorkProcessNo,cDepCode,Remark,Remark2,Remark3,Remark4,Remark5 ");
            strSql.Append(" FROM ProcessRoute ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        public int Save(DataTable dt,string sInvCode)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                //判断是否使用
                string sSQL = "";

                _GetBaseData _GetBaseData = new _GetBaseData();
                DateTime dTimeNow =  _GetBaseData.GetDatetimeSer();

                sSQL = Delete(sInvCode);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TH.Model.ProcessRoute Model = new TH.Model.ProcessRoute();
                    Model = DataRowToModel(dt.Rows[i]);

                    if (Model.cDepCode == "" && Model.WorkProcessNo == "" && Model.WorkSort == "")
                        continue;

                    if (Model.WorkSort != "" && Model.WorkProcessNo == "")
                        throw new Exception("行" + (i + 1).ToString() + "工序不能为空\n");

                    //if (Model.WorkSort != "" && Model.cDepCode == "")
                    //    throw new Exception("行" + (i + 1).ToString() + "部门不能为空\n");

                    Model.cInvCode = sInvCode;

                    Model.CreateUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                    Model.CreateDate = dTimeNow;
                    sSQL = Add(Model);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (sErr.Length > 0)
                    throw new Exception(sErr);

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                iCou = 0;
                sErr = error.Message;
            }

            return iCou;
        }

        public int Del(string sInvCode)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                //判断是否使用
                string sSQL = "select * FROM [生产订单工艺路线] where 1=1 and [存货编码] = '" + sInvCode + "'";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    sErr = sErr + "工序路线 物料 " + sInvCode + " 已经使用\n";
                    throw new Exception(sErr);
                }

                sSQL = Delete(sInvCode);
                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                if (sErr.Length > 0)
                    throw new Exception(sErr);

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                iCou = 0;
                throw new Exception(error.Message);
            }

            return iCou;
        }

        public int Open(DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {

                string sSQL = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["choose"]))
                    {
                        continue;
                    }


                    sSQL = "update WorkProcess set CloseUid = null,CloseDate = null where WorkProcessNo = '" + dt.Rows[i]["WorkProcessNo"].ToString().Trim() + "'";
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                if (sErr.Length > 0)
                    throw new Exception(sErr);
                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                iCou = 0;
                sErr = error.Message;
                if (sErr.Length > 0)
                    throw new Exception(sErr);
            }

            return iCou;
        }

        public int Close(DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {

                string sSQL = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["choose"]))
                    {
                        continue;
                    }

                    sSQL = "update WorkProcess set CloseUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',CloseDate = getdate() where WorkProcessNo = '" + dt.Rows[i]["WorkProcessNo"].ToString().Trim() + "'";
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                if (sErr.Length > 0)
                    throw new Exception(sErr);
                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                iCou = 0;
                sErr = error.Message;
                if (sErr.Length > 0)
                    throw new Exception(sErr);
            }

            return iCou;
        }



        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.ProcessRoute DataRowToModel(DataRow row)
        {
            TH.Model.ProcessRoute model = new TH.Model.ProcessRoute();
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
                if (row["cInvCode"] != null)
                {
                    model.cInvCode = row["cInvCode"].ToString();
                }
                if (row["Versions"] != null)
                {
                    model.Versions = row["Versions"].ToString();
                }
                if (row["WorkSort"] != null)
                {
                    model.WorkSort = row["WorkSort"].ToString();
                }
                if (row["WorkProcessNo"] != null)
                {
                    model.WorkProcessNo = row["WorkProcessNo"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.ProcessRoute model)
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
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.Versions != null)
            {
                strSql1.Append("Versions,");
                strSql2.Append("'" + model.Versions + "',");
            }
            if (model.WorkSort != null)
            {
                strSql1.Append("WorkSort,");
                strSql2.Append("'" + model.WorkSort + "',");
            }
            if (model.WorkProcessNo != null)
            {
                strSql1.Append("WorkProcessNo,");
                strSql2.Append("'" + model.WorkProcessNo + "',");
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
            strSql.Append("insert into ProcessRoute(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return(strSql.ToString());

        }

        /// 删除一条数据
        /// </summary>
        public string Delete(string cInvCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProcessRoute ");
            strSql.Append(" where cInvCode='" + cInvCode + "'");
         
          return(strSql.ToString());

        }
        #endregion  Method
    }
}

