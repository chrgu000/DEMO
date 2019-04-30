using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:Equipment
    /// </summary>
    public partial class Equipment
    {
        public Equipment()
        { }

        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select iID,GUID,CreateUid,CreateDate,UpdataUid,UpdataDate,AuditUid,AuditDate,CloseUid,CloseDate,EquipmentNo,EquipmentName,Remark,Remark2,Remark3,Remark4,Remark5 ");
            strSql.Append(" FROM Equipment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("order by  EquipmentNo ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        public int Save(DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                _GetBaseData _GetBaseData = new _GetBaseData();
                DateTime dTimeNow =  _GetBaseData.GetDatetimeSer();

                string sSQL = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["choose"]))
                    {
                        continue;
                    }

                    TH.Model.Equipment Model = new TH.Model.Equipment();
                    Model = DataRowToModel(dt.Rows[i]);
                    

                    sSQL = "select * from Equipment where EquipmentNo = '" + Model.EquipmentNo + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int iExistsCou = 0;
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        iExistsCou = BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows.Count);
                        if (dtTemp.Rows[0]["CloseUid"].ToString().Trim() != "")
                        {
                            sErr = sErr + Model.EquipmentNo + "已经关闭\n";
                            continue;
                        }
                    }

                    if (iExistsCou > 0)
                    {
                        Model.UpdataUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                        Model.UpdataDate = dTimeNow;
                        sSQL = Update(Model);
                    }
                    else
                    {
                        Model.CreateUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                        Model.CreateDate = dTimeNow;
                        sSQL = Add(Model);
                    }

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
                throw new Exception(error.Message);
            }

            return iCou;
        }

        public int Del(DataTable dt)
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

                    TH.Model.Equipment Model = new TH.Model.Equipment();
                    Model = DataRowToModel(dt.Rows[i]);

                    sSQL = "select * from dbo.工序报表 where s4 = '" + Model.EquipmentNo + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int iExistsCou = 0;
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        sErr = sErr + Model.EquipmentNo + "已经使用\n";
                        continue;
                    }
                    //判断未使用的可以删除

                    sSQL = "delete Equipment where EquipmentNo = '" + Model.EquipmentNo + "'";
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


                    sSQL = "update Equipment set CloseUid = null,CloseDate = null where EquipmentNo = '" + dt.Rows[i]["EquipmentNo"].ToString().Trim() + "'";
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

                    sSQL = "update Equipment set CloseUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',CloseDate = getdate() where EquipmentNo = '" + dt.Rows[i]["EquipmentNo"].ToString().Trim() + "'";
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
        public TH.Model.Equipment DataRowToModel(DataRow row)
        {
            TH.Model.Equipment model = new TH.Model.Equipment();
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
                if (row["EquipmentNo"] != null)
                {
                    model.EquipmentNo = row["EquipmentNo"].ToString();
                }
                if (row["EquipmentName"] != null)
                {
                    model.EquipmentName = row["EquipmentName"].ToString();
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
        public string Add(TH.Model.Equipment model)
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
            if (model.EquipmentNo != null)
            {
                strSql1.Append("EquipmentNo,");
                strSql2.Append("'" + model.EquipmentNo + "',");
            }
            if (model.EquipmentName != null)
            {
                strSql1.Append("EquipmentName,");
                strSql2.Append("'" + model.EquipmentName + "',");
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
            strSql.Append("insert into Equipment(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.Equipment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Equipment set ");
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
            if (model.EquipmentName != null)
            {
                strSql.Append("EquipmentName='" + model.EquipmentName + "',");
            }
            else
            {
                strSql.Append("EquipmentName= null ,");
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
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string EquipmentNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Equipment ");
            strSql.Append(" where EquipmentNo='" + EquipmentNo + "' ");
           

            return strSql.ToString();
        }
        #endregion  Method
    }
}

