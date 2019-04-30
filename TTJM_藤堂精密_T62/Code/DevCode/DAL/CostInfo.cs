using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:基础档案列表
    /// </summary>
    public partial class CostInfo
    {
        public CostInfo()
        { }

        _GetBaseData _GetBase = new _GetBaseData();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cast(0 as bit) as bChoose, iID,Guid,sType,sCode,sText,sTextEn,sText2,sText3,sText4,sText5,sRemark,sRemark2,sRemark3,sRemark4,sRemark5,CreateUid,CreateDate,UpdateUid,UpdateDate,CloseUid,CloseDate ");
            strSql.Append(" FROM _BaseDataList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sType,sCode");
            return DbHelperSQL.Query(strSql.ToString());
        }
      

        public int Save(DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            try
            {
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["bChoose"]))
                        {
                            TH.Model._BaseDataList model = DataRowToModel(dt.Rows[i]);

                            if (model.CloseUid.Trim() != "")
                            {
                                sErr = sErr + "编号：" + dt.Rows[i]["sCode"].ToString().Trim() + "已经关闭\n";
                                continue;
                            }

                            long l = BaseFunction.BaseFunction.ReturnLong(model.iID);
                            if (l == 0)
                            {
                                model.CreateUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                                model.CreateDate = _GetBase.GetDatetimeSer();
                                string sSQL = Add(model);
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            else
                            {
                                model.UpdateUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                                model.UpdateDate = _GetBase.GetDatetimeSer();
                                string sSQL = Update(model);
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
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
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

            return iCou;
        }

        public int Del(DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            try
            {
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["bChoose"]))
                        {
                            long l = BaseFunction.BaseFunction.ReturnLong(dt.Rows[i]["iID"]);

                            string sSQL = @"
select *
FROM _BaseDataList
where sCode in
(
	select sCode
	FROM dbo._BaseDataList
	where sType = '成本中心' and iID = 111111
) and sType = '成本中心对照'
";
                            sSQL = sSQL.Replace("111111", l.ToString().Trim());
                            DataTable dtTemp = DbHelperSQL.Query(sSQL);
                            if (dtTemp != null && dtTemp.Rows.Count > 0)
                            {
                                sErr = sErr + "成本中心 " + dt.Rows[i]["sCode"].ToString().Trim() + " 已经使用\n";
                                continue;
                            }

                            sSQL = Delete(l);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
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
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
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
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["bChoose"]))
                    {
                        continue;
                    }

                    if (dt.Rows[i]["CloseUid"].ToString().Trim() == "")
                    {
                        sErr = sErr + "编号：" + dt.Rows[i]["sCode"].ToString().Trim() + "未关闭\n";
                        continue;
                    }

                    sSQL = "update _BaseDataList set CloseUid = null,CloseDate = null where sType = '" + dt.Rows[i]["sType"].ToString().Trim() + "' and sCode = '" + dt.Rows[i]["sCode"].ToString().Trim() + "'";
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                //if (sErr.Length > 0)
                //    throw new Exception(sErr);

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
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["bChoose"]))
                    {
                        continue;
                    }

                    if (dt.Rows[i]["CloseUid"].ToString().Trim() != "")
                    {
                        sErr = sErr + "编号：" + dt.Rows[i]["sCode"].ToString().Trim() + "已经关闭\n";
                        continue;
                    }

                    sSQL = "update _BaseDataList set CloseUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',CloseDate = getdate() where sType = '" + dt.Rows[i]["sType"].ToString().Trim() + "' and sCode = '" + dt.Rows[i]["sCode"].ToString().Trim() + "'";
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

        #region 代码生成器

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model._BaseDataList model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.Guid != null)
            {
                strSql1.Append("Guid,");
                strSql2.Append("" + model.Guid + ",");
            }
            if (model.sType != null)
            {
                strSql1.Append("sType,");
                strSql2.Append("'" + model.sType + "',");
            }
            if (model.sCode != null)
            {
                strSql1.Append("sCode,");
                strSql2.Append("'" + model.sCode + "',");
            }
            if (model.sText != null)
            {
                strSql1.Append("sText,");
                strSql2.Append("'" + model.sText + "',");
            }
            if (model.sTextEn != null)
            {
                strSql1.Append("sTextEn,");
                strSql2.Append("'" + model.sTextEn + "',");
            }
            if (model.sText2 != null)
            {
                strSql1.Append("sText2,");
                strSql2.Append("'" + model.sText2 + "',");
            }
            if (model.sText3 != null)
            {
                strSql1.Append("sText3,");
                strSql2.Append("'" + model.sText3 + "',");
            }
            if (model.sText4 != null)
            {
                strSql1.Append("sText4,");
                strSql2.Append("'" + model.sText4 + "',");
            }
            if (model.sText5 != null)
            {
                strSql1.Append("sText5,");
                strSql2.Append("'" + model.sText5 + "',");
            }
            if (model.sRemark != null)
            {
                strSql1.Append("sRemark,");
                strSql2.Append("'" + model.sRemark + "',");
            }
            if (model.sRemark2 != null)
            {
                strSql1.Append("sRemark2,");
                strSql2.Append("'" + model.sRemark2 + "',");
            }
            if (model.sRemark3 != null)
            {
                strSql1.Append("sRemark3,");
                strSql2.Append("'" + model.sRemark3 + "',");
            }
            if (model.sRemark4 != null)
            {
                strSql1.Append("sRemark4,");
                strSql2.Append("'" + model.sRemark4 + "',");
            }
            if (model.sRemark5 != null)
            {
                strSql1.Append("sRemark5,");
                strSql2.Append("'" + model.sRemark5 + "',");
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
            strSql.Append("insert into _BaseDataList(");
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
        public string Update(TH.Model._BaseDataList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _BaseDataList set ");
            if (model.sText != null)
            {
                strSql.Append("sText='" + model.sText + "',");
            }
            else
            {
                strSql.Append("sText= null ,");
            }
            if (model.sTextEn != null)
            {
                strSql.Append("sTextEn='" + model.sTextEn + "',");
            }
            else
            {
                strSql.Append("sTextEn= null ,");
            }
            if (model.sText2 != null)
            {
                strSql.Append("sText2='" + model.sText2 + "',");
            }
            else
            {
                strSql.Append("sText2= null ,");
            }
            if (model.sText3 != null)
            {
                strSql.Append("sText3='" + model.sText3 + "',");
            }
            else
            {
                strSql.Append("sText3= null ,");
            }
            if (model.sText4 != null)
            {
                strSql.Append("sText4='" + model.sText4 + "',");
            }
            else
            {
                strSql.Append("sText4= null ,");
            }
            if (model.sText5 != null)
            {
                strSql.Append("sText5='" + model.sText5 + "',");
            }
            else
            {
                strSql.Append("sText5= null ,");
            }
            if (model.sRemark != null)
            {
                strSql.Append("sRemark='" + model.sRemark + "',");
            }
            else
            {
                strSql.Append("sRemark= null ,");
            }
            if (model.sRemark2 != null)
            {
                strSql.Append("sRemark2='" + model.sRemark2 + "',");
            }
            else
            {
                strSql.Append("sRemark2= null ,");
            }
            if (model.sRemark3 != null)
            {
                strSql.Append("sRemark3='" + model.sRemark3 + "',");
            }
            else
            {
                strSql.Append("sRemark3= null ,");
            }
            if (model.sRemark4 != null)
            {
                strSql.Append("sRemark4='" + model.sRemark4 + "',");
            }
            else
            {
                strSql.Append("sRemark4= null ,");
            }
            if (model.sRemark5 != null)
            {
                strSql.Append("sRemark5='" + model.sRemark5 + "',");
            }
            else
            {
                strSql.Append("sRemark5= null ,");
            }
            if (model.CreateUid != null)
            {
                strSql.Append("CreateUid='" + model.CreateUid + "',");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
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
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model._BaseDataList DataRowToModel(DataRow row)
        {
            TH.Model._BaseDataList model = new TH.Model._BaseDataList();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["Guid"] != null && row["Guid"].ToString() != "")
                {
                    model.Guid = (byte[])row["Guid"];
                }
                if (row["sType"] != null)
                {
                    model.sType = row["sType"].ToString();
                }
                if (row["sCode"] != null)
                {
                    model.sCode = row["sCode"].ToString();
                }
                if (row["sText"] != null)
                {
                    model.sText = row["sText"].ToString();
                }
                if (row["sTextEn"] != null)
                {
                    model.sTextEn = row["sTextEn"].ToString();
                }
                if (row["sText2"] != null)
                {
                    model.sText2 = row["sText2"].ToString();
                }
                if (row["sText3"] != null)
                {
                    model.sText3 = row["sText3"].ToString();
                }
                if (row["sText4"] != null)
                {
                    model.sText4 = row["sText4"].ToString();
                }
                if (row["sText5"] != null)
                {
                    model.sText5 = row["sText5"].ToString();
                }
                if (row["sRemark"] != null)
                {
                    model.sRemark = row["sRemark"].ToString();
                }
                if (row["sRemark2"] != null)
                {
                    model.sRemark2 = row["sRemark2"].ToString();
                }
                if (row["sRemark3"] != null)
                {
                    model.sRemark3 = row["sRemark3"].ToString();
                }
                if (row["sRemark4"] != null)
                {
                    model.sRemark4 = row["sRemark4"].ToString();
                }
                if (row["sRemark5"] != null)
                {
                    model.sRemark5 = row["sRemark5"].ToString();
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
                if (row["CloseUid"] != null)
                {
                    model.CloseUid = row["CloseUid"].ToString();
                }
                if (row["CloseDate"] != null && row["CloseDate"].ToString() != "")
                {
                    model.CloseDate = DateTime.Parse(row["CloseDate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(long iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _BaseDataList ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();
        }

        #endregion
    }
}

