using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:生产订单中转箱记录
    /// </summary>
    public partial class 生产订单中转箱记录
    {
        public 生产订单中转箱记录()
        { }


        public DataTable GetListAll(string strWhere)
        {
            string sSQL = @"
select a.cCode as 生产订单号,a.ID as 单据ID,a.dDate,b.cInvCode as 存货编码,c.cInvName,c.cInvStd, b.MainId as 单据明细ID,e.工艺路线版本 as 工艺路线版本,e.备注, b.MainId as 生产订单序号
        ,e.[CreateUid],e.[CreateDate] ,e.[UpdataUid] ,e.[UpdataDate],b.fQuantity as 生产订单数量
from @u8.PP_ProductPO a
	left join @u8.pp_pomain b on a.ID = b.ID
	left join @u8.Inventory c on c.cInvCode = b.cInvCode
	left join dbo.生产订单工艺路线 e on e.单据明细ID = b.MainId 
where 1=1
order by a.ID,b.MainId
";
            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }
            return DbHelperSQL.Query(sSQL);
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
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["选择"]))
                    {
                        continue;
                    }

                    string sSQL = "select * from 生产订单中转箱记录 where  单据明细ID = '" + dt.Rows[i]["单据明细ID"].ToString().Trim() + "' and 箱号 = '" + dt.Rows[i]["箱号"].ToString().Trim() + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int iExistsCou = 0;
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        iExistsCou = BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows.Count);
                        if (dtTemp.Rows[0]["CloseUid"].ToString().Trim() != "")
                        {
                            sErr = sErr + dt.Rows[i]["箱号"].ToString().Trim() + "已经未关闭\n";
                            continue;
                        }
                    }

                    sSQL = "update 生产订单中转箱记录 set CloseUid = null,CloseDate = null where  单据明细ID = '" + dt.Rows[i]["单据明细ID"].ToString().Trim() + "' and 箱号 = '" + dt.Rows[i]["箱号"].ToString().Trim() + "'";
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
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["选择"]))
                    {
                        continue;
                    }

                    sSQL = "select b.* from dbo.生产日报表 a inner join dbo.生产日报表明细 b on a.GUID = b.表头GUID where a.生产订单序号 = '" + dt.Rows[i]["单据明细ID"].ToString().Trim() + "' and b.箱号 = '" + dt.Rows[i]["箱号"].ToString().Trim() + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        sErr = sErr + dt.Rows[i]["箱号"].ToString().Trim() + "已经生产报工\n";
                        continue;
                    }
                     

                    sSQL = "select * from 生产订单中转箱记录 where  单据明细ID = '" + dt.Rows[i]["单据明细ID"].ToString().Trim() + "' and 箱号 = '" + dt.Rows[i]["箱号"].ToString().Trim() + "'";
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int iExistsCou = 0;
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        iExistsCou = BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows.Count);
                        if (dtTemp.Rows[0]["CloseUid"].ToString().Trim() != "")
                        {
                            sErr = sErr + dt.Rows[i]["箱号"].ToString().Trim() + "已经关闭\n";
                            continue;
                        }
                    }



                    sSQL = "update 生产订单中转箱记录 set CloseUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',CloseDate = getdate() where  单据明细ID = '" + dt.Rows[i]["单据明细ID"].ToString().Trim() + "' and 箱号 = '" + dt.Rows[i]["箱号"].ToString().Trim() + "'";
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



        public int Save(long lID,long lIDDetails,DataTable dt)
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

                string sSQL = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Model.生产订单中转箱记录 model = new TH.Model.生产订单中转箱记录();
                    model.单据ID = lID;
                    model.单据明细ID = lIDDetails;
                    model.数量 = BaseFunction.BaseFunction.ReturnLong(dt.Rows[i]["数量"]);
                    model.箱号 = dt.Rows[i]["箱号"].ToString().Trim();


                    sSQL = "select b.* from dbo.生产日报表 a inner join dbo.生产日报表明细 b on a.GUID = b.表头GUID where a.生产订单序号 = '" + lIDDetails + "' and b.箱号 = '" + model.箱号 + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        sErr = sErr + dt.Rows[i]["箱号"].ToString().Trim() + "已经生产报工\n";
                        continue;
                    }
                     

                    if (Exists(lID, lIDDetails, model.箱号))
                    {
                        model.CreateUid = dt.Rows[i]["制单人"].ToString().Trim();
                        model.CreateDate = BaseFunction.BaseFunction.ReturnDate(dt.Rows[i]["制单日期"]);
                        model.UpdataUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                        model.UpdataDate = dTimeNow;

                        sSQL = Update(model);
                    }
                    else
                    {
                        model.CreateUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                        model.CreateDate = dTimeNow;

                        sSQL = Add(model);
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


        public DataTable GetList(string 单据明细ID)
        {
            string sSQL = @"
SELECT cast(0 as bit) as 选择,  单据ID, 单据明细ID, 箱号, 数量, UpdataUid as 修改人, UpdataDate as 修改日期, CreateUid 制单人, CreateDate as 制单日期, CloseUid as 关闭人, CloseDate as 关闭日期
      ,[数量] as 装箱数
  FROM [SystemDB_TTJM].[dbo].[生产订单中转箱记录]
where 1=1 
";
            if (单据明细ID.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 单据明细ID = " + 单据明细ID);
            }
            return DbHelperSQL.Query(sSQL);
        }



        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long 单据ID, long 单据明细ID, string 箱号)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 生产订单中转箱记录");
            strSql.Append(" where 单据ID=" + 单据ID + " and 单据明细ID=" + 单据明细ID + " and 箱号='" + 箱号 + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.生产订单中转箱记录 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.单据ID != null)
            {
                strSql1.Append("单据ID,");
                strSql2.Append("" + model.单据ID + ",");
            }
            if (model.单据明细ID != null)
            {
                strSql1.Append("单据明细ID,");
                strSql2.Append("" + model.单据明细ID + ",");
            }
            if (model.箱号 != null)
            {
                strSql1.Append("箱号,");
                strSql2.Append("'" + model.箱号 + "',");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
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
            strSql.Append("insert into 生产订单中转箱记录(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.生产订单中转箱记录 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 生产订单中转箱记录 set ");
            if (model.数量 != null)
            {
                strSql.Append("数量=" + model.数量 + ",");
            }
            else
            {
                strSql.Append("数量= null ,");
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
            strSql.Append(" where 单据ID=" + model.单据ID + " and 单据明细ID=" + model.单据明细ID + " and 箱号='" + model.箱号 + "' ");
            return (strSql.ToString());
        }
    }
}

