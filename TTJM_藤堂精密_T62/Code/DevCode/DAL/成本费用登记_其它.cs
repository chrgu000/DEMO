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
    public partial class 成本费用登记_其它
    {
        public 成本费用登记_其它()
        { }

        _GetBaseData _GetBase = new _GetBaseData();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(int iYear,int iMonth,string strWhere)
        {
            string sSQL = @"
select cast(0 as bit) as bChoose,a.cDepCode, b.iID, b.sType, b.[Year], b.[Month], b.[Money], b.Remark, b.CreateUid, b.CreateDate, b.UpdateUid, b.UpdateDate
from @u8.department a 
	left join dbo.成本费用登记 b on a.cdepcode = b.cDepCode and b.sType = '成本费用登记_其它' and b.[Year] = 111111 and b.[Month] = 222222
where isnull(bDepEnd,0) = 1
order by a.cDepCode
";

            sSQL = sSQL.Replace("111111", iYear.ToString());
            sSQL = sSQL.Replace("222222", iMonth.ToString());
            return DbHelperSQL.Query(sSQL);
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
                            TH.Model.成本费用登记 model = DataRowToModel(dt.Rows[i]);

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
                            string sSQL = Delete(l);
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
        public string Add(TH.Model.成本费用登记 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.sType != null)
            {
                strSql1.Append("sType,");
                strSql2.Append("'" + model.sType + "',");
            }
            if (model.Year != null)
            {
                strSql1.Append("Year,");
                strSql2.Append("" + model.Year + ",");
            }
            if (model.Month != null)
            {
                strSql1.Append("Month,");
                strSql2.Append("" + model.Month + ",");
            }
            if (model.cDepCode != null)
            {
                strSql1.Append("cDepCode,");
                strSql2.Append("'" + model.cDepCode + "',");
            }
            if (model.Money != null)
            {
                strSql1.Append("Money,");
                strSql2.Append("" + model.Money + ",");
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
            strSql.Append("insert into 成本费用登记(");
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
        public string Update(TH.Model.成本费用登记 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 成本费用登记 set ");
            if (model.Money != null)
            {
                strSql.Append("Money=" + model.Money + ",");
            }
            else
            {
                strSql.Append("Money= null ,");
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
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.成本费用登记 DataRowToModel(DataRow row)
        {
            TH.Model.成本费用登记 model = new TH.Model.成本费用登记();
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
                if (row["Year"] != null && row["Year"].ToString() != "")
                {
                    model.Year = int.Parse(row["Year"].ToString());
                }
                if (row["Month"] != null && row["Month"].ToString() != "")
                {
                    model.Month = int.Parse(row["Month"].ToString());
                }
                if (row["cDepCode"] != null)
                {
                    model.cDepCode = row["cDepCode"].ToString();
                }
                if (row["Money"] != null && row["Money"].ToString() != "")
                {
                    model.Money = decimal.Parse(row["Money"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(long iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 成本费用登记 ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();
        }

        #endregion
    }
}

