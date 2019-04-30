using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:生产订单产品工序
    /// </summary>
    public partial class 生产订单产品工序
    {
        public 生产订单产品工序()
        { }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(long sIDs)
        {
            DataSet ds = new DataSet();

            string sSQL = "select * from 生产订单产品工序 where WorkDetailsID = 111111";
            sSQL = sSQL.Replace("111111", sIDs.ToString());
            DataTable dtHas =  DbHelperSQL.Query(sSQL);

            if (dtHas == null || dtHas.Rows.Count == 0)
            {
                sSQL = @"
select cast(1 as bit) as bChoose
    ,b.iID,a.[GUID] as GUID工序
	,b.CreateUid,b.CreateDate,b.UpdataUid,b.UpdataDate
	,b.WorkCode,b.WorkDetailsID
	,case when isnull(b.WorkProcessNo,'') = '' then a.WorkProcessNo  else b.WorkProcessNo end as WorkProcessNo
	,case when isnull(b.WorkProcessName,'') = '' then a.WorkProcessName  else b.WorkProcessName end as WorkProcessName
    ,case when isnull(b.WorkProcessNo,'') = '' then a.Remark  else b.Remark end as Remark
    ,case when isnull(b.WorkProcessNo,'') = '' then a.Remark2  else b.Remark2 end as Remark2
    ,case when isnull(b.WorkProcessNo,'') = '' then a.Remark3  else b.Remark3 end as Remark3
    ,case when isnull(b.WorkProcessNo,'') = '' then a.Remark4  else b.Remark4 end as Remark4
    ,case when isnull(b.WorkProcessNo,'') = '' then a.Remark5  else b.Remark5 end as Remark5
    ,case when isnull(b.WorkProcessNo,'') = '' then isnull(a.分包,0)  else isnull(b.分包,0) end as 分包
    ,case when isnull(b.WorkProcessNo,'') = '' then a.分包数  else b.分包数 end as 分包数
    ,case when isnull(b.WorkProcessNo,'') = '' then isnull(a.入库,0)  else isnull(b.入库,0) end as 入库
from dbo.WorkProcess a left join dbo.生产订单产品工序 b on a.WorkProcessNo = b.WorkProcessNo and 2=2
where 1=1
order by a.iID
";
            }
            else
            {
                sSQL = @"
select case isnull(b.WorkProcessNo,'') when '' then cast(0 as bit) else cast(1 as bit) end as bChoose
    ,b.iID,a.[GUID] as GUID工序
	,b.CreateUid,b.CreateDate,b.UpdataUid,b.UpdataDate
	,b.WorkCode,b.WorkDetailsID
	,case when isnull(b.WorkProcessNo,'') = '' then a.WorkProcessNo  else b.WorkProcessNo end as WorkProcessNo
	,case when isnull(b.WorkProcessName,'') = '' then a.WorkProcessName  else b.WorkProcessName end as WorkProcessName
    ,case when isnull(b.WorkProcessNo,'') = '' then a.Remark  else b.Remark end as Remark
    ,case when isnull(b.WorkProcessNo,'') = '' then a.Remark2  else b.Remark2 end as Remark2
    ,case when isnull(b.WorkProcessNo,'') = '' then a.Remark3  else b.Remark3 end as Remark3
    ,case when isnull(b.WorkProcessNo,'') = '' then a.Remark4  else b.Remark4 end as Remark4
    ,case when isnull(b.WorkProcessNo,'') = '' then a.Remark5  else b.Remark5 end as Remark5
    ,case when isnull(b.WorkProcessNo,'') = '' then isnull(a.分包,0)  else isnull(b.分包,0) end as 分包
    ,case when isnull(b.WorkProcessNo,'') = '' then a.分包数  else b.分包数 end as 分包数
    ,case when isnull(b.WorkProcessNo,'') = '' then isnull(a.入库,0)  else isnull(b.入库,0) end as 入库
from dbo.WorkProcess a left join dbo.生产订单产品工序 b on a.WorkProcessNo = b.WorkProcessNo and 2=2
where 1=1
order by a.iID
";
            }
            sSQL = sSQL.Replace("2=2", "2=2 and WorkDetailsID = " + sIDs.ToString());
            DataTable dt = DbHelperSQL.Query(sSQL);
            dt.TableName = "Details";
            ds.Tables.Add(dt.Copy());


            sSQL = @"
select cast(0 as bit) as bChoose,a.cCode,a.dDate,b.cInvCode,i.cInvName,i.cInvStd
	,cast(b.fQuantity as decimal(16,2)) as fQuantity,b.dStartDate,b.dEndDate,cast(b.cDefine26 as int) as cDefine26,a.ID,b.MainId,a.cDepCode,dep.cDepName,a.cPersonCode,per.cPersonName,a.iState
from @u8.PP_ProductPO a inner join @u8.PP_POMain b on a.ID = b.ID
	left join @u8.Inventory I on I.cInvCode = b.cInvCode
    left join @u8.Department dep on dep.cDepCode = a.cDepCode
    left join @u8.Person per on per.cPersonCode = a.cPersonCode
where 1=1 and a.iState = 2
order by b.ID
";
            sSQL = sSQL.Replace("1=1", "1=1 and b.MainId = " + sIDs.ToString().Trim());

            dt = DbHelperSQL.Query(sSQL);
            dt.TableName = "Main";
            ds.Tables.Add(dt.Copy());

            return ds;
        }

        public int Save(DataTable dt,decimal dQty)
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
                DateTime dTimeNow = _GetBaseData.GetDatetimeSer();

                string sSQL = "select *from dbo.BarCodeList where WorkDetailsID = " + dt.Rows[0]["WorkDetailsID"].ToString();
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp.Rows == null || dtTemp.Rows.Count == 0)
                {
                    sSQL = "update @u8.PP_POMain set cDefine26 = " + dQty.ToString().Trim() + " where MainId = " + dt.Rows[0]["WorkDetailsID"].ToString().Trim();
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                else
                {
                    throw new Exception("已经打印不能修改");
                }

                sSQL = "delete  生产订单产品工序 where WorkDetailsID = " + dt.Rows[0]["WorkDetailsID"].ToString().Trim();
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["bChoose"]))
                    {
                        continue;
                    }

                    TH.Model.生产订单产品工序 Model = new TH.Model.生产订单产品工序();
                    Model = DataRowToModel(dt.Rows[i]);
                    Model.装箱数 = dQty;
                    

                    sSQL = "select * from 生产订单产品工序 where WorkProcessNo = '" + Model.WorkProcessNo + "' and WorkDetailsID = " + Model.WorkDetailsID.ToString();
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                    {
                        Model.CreateUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                        Model.CreateDate = dTimeNow;
                        sSQL = Add(Model);
                    }
                    else
                    {
                        Model.UpdataUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                        Model.UpdataDate = dTimeNow;
                        sSQL = Update(Model);
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

                    TH.Model.生产订单产品工序 Model = new TH.Model.生产订单产品工序();
                    Model = DataRowToModel(dt.Rows[i]);

                    sSQL = "select * FROM [ProcessRoute] where [WorkProcessNo] = '" + Model.WorkProcessNo + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        sErr = sErr + "工序" + Model.WorkProcessNo + "已经使用\n";
                        continue;
                    }

                    sSQL = "select * from 生产订单产品工序 where WorkProcessNo = '" + Model.WorkProcessNo + "'";
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int iExistsCou = 0;
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        iExistsCou = BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows.Count);
                        if (dtTemp.Rows[0]["CloseUid"].ToString().Trim() != "")
                        {
                            sErr = sErr + Model.WorkProcessNo + "已经关闭\n";
                            continue;
                        }
                    }
                    //判断未使用的可以删除

                    sSQL = "delete 生产订单产品工序 where WorkProcessNo = '" + Model.WorkProcessNo + "'";
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

        #region  Method

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int iID)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) from 生产订单产品工序");
        //    strSql.Append(" where iID=" + iID + " ");
        //    return DbHelperSQL.Exists(strSql.ToString());
        //}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.生产订单产品工序 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.GUID工序 != null)
            {
                strSql1.Append("GUID工序,");
                strSql2.Append("'" +model.GUID工序 + "',");
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
            if (model.WorkCode != null)
            {
                strSql1.Append("WorkCode,");
                strSql2.Append("'" + model.WorkCode + "',");
            }
            if (model.WorkDetailsID != null)
            {
                strSql1.Append("WorkDetailsID,");
                strSql2.Append("" + model.WorkDetailsID + ",");
            }
            if (model.WorkProcessNo != null)
            {
                strSql1.Append("WorkProcessNo,");
                strSql2.Append("'" + model.WorkProcessNo + "',");
            }
            if (model.WorkProcessName != null)
            {
                strSql1.Append("WorkProcessName,");
                strSql2.Append("'" + model.WorkProcessName + "',");
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
            if (model.分包 != null)
            {
                strSql1.Append("分包,");
                strSql2.Append("" + (model.分包 ? 1 : 0) + ",");
            }
            if (model.分包数 != null)
            {
                strSql1.Append("分包数,");
                strSql2.Append("" + model.分包数 + ",");
            }
            if (model.装箱数 != null)
            {
                strSql1.Append("装箱数,");
                strSql2.Append("" + model.装箱数 + ",");
            }
            if (model.入库 != null)
            {
                strSql1.Append("入库,");
                strSql2.Append("" + (model.入库 ? 1 : 0) + ",");
            }
            strSql.Append("insert into 生产订单产品工序(");
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
        public string Update(TH.Model.生产订单产品工序 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 生产订单产品工序 set ");
            if (model.GUID工序 != null)
            {
                strSql.Append("GUID工序='" + model.GUID工序 + "',");
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
            if (model.WorkCode != null)
            {
                strSql.Append("WorkCode='" + model.WorkCode + "',");
            }
            else
            {
                strSql.Append("WorkCode= null ,");
            }
            if (model.WorkDetailsID != null)
            {
                strSql.Append("WorkDetailsID=" + model.WorkDetailsID + ",");
            }
            if (model.WorkProcessNo != null)
            {
                strSql.Append("WorkProcessNo='" + model.WorkProcessNo + "',");
            }
            if (model.WorkProcessName != null)
            {
                strSql.Append("WorkProcessName='" + model.WorkProcessName + "',");
            }
            else
            {
                strSql.Append("WorkProcessName= null ,");
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
            if (model.分包 != null)
            {
                strSql.Append("分包=" + (model.分包 ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("分包= null ,");
            }
            if (model.分包数 != null)
            {
                strSql.Append("分包数=" + model.分包数 + ",");
            }
            else
            {
                strSql.Append("分包数= null ,");
            }
            if (model.装箱数 != null)
            {
                strSql.Append("装箱数=" + model.装箱数 + ",");
            }
            else
            {
                strSql.Append("装箱数= null ,");
            }
            if (model.入库 != null)
            {
                strSql.Append("入库=" + (model.入库 ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("入库= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return strSql.ToString();
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.生产订单产品工序 DataRowToModel(DataRow row)
        {
            TH.Model.生产订单产品工序 model = new TH.Model.生产订单产品工序();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["GUID工序"] != null && row["GUID工序"].ToString() != "")
                {
                    model.GUID工序 = new Guid(row["GUID工序"].ToString());
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
                if (row["WorkCode"] != null)
                {
                    model.WorkCode = row["WorkCode"].ToString();
                }
                if (row["WorkDetailsID"] != null && row["WorkDetailsID"].ToString() != "")
                {
                    model.WorkDetailsID = int.Parse(row["WorkDetailsID"].ToString());
                }
                if (row["WorkProcessNo"] != null)
                {
                    model.WorkProcessNo = row["WorkProcessNo"].ToString();
                }
                if (row["WorkProcessName"] != null)
                {
                    model.WorkProcessName = row["WorkProcessName"].ToString();
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
                if (row["分包"] != null && row["分包"].ToString() != "")
                {
                    if ((row["分包"].ToString() == "1") || (row["分包"].ToString().ToLower() == "true"))
                    {
                        model.分包 = true;
                    }
                    else
                    {
                        model.分包 = false;
                    }
                }
                if (row["分包数"] != null && row["分包数"].ToString() != "")
                {
                    model.分包数 = decimal.Parse(row["分包数"].ToString());
                }
            
                if (row["入库"] != null && row["入库"].ToString() != "")
                {
                    if ((row["入库"].ToString() == "1") || (row["入库"].ToString().ToLower() == "true"))
                    {
                        model.入库 = true;
                    }
                    else
                    {
                        model.入库 = false;
                    }
                }
            }
            return model;
        }


       

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

