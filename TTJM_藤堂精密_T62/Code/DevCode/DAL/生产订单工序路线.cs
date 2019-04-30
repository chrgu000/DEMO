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
    public partial class 生产订单工艺路线
    {
        public 生产订单工艺路线()
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
                DateTime dTimeNow = _GetBaseData.GetDatetimeSer();

                string sSQL = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["choose"]))
                    {
                        continue;
                    }

                    TH.Model.生产订单工艺路线 Model = new TH.Model.生产订单工艺路线();
                    Model = DataRowToModel(dt.Rows[i]);

                    sSQL = "select * from dbo.ProcessRoute where cInvCode = '" + Model.存货编码 + "' and Versions = '" + Model.工艺路线版本 + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp.Rows.Count == 0)
                    {
                        sErr = sErr + "生产订单 " + Model.生产订单号 + " 存货 " + Model.存货编码 + " 工艺路线版本 " + Model.工艺路线版本 + "不存在\n";
                        continue;
                    }

                    sSQL = "select * from dbo.生产日报表 a where a.[生产订单序号] = '" + Model.单据明细ID + " ' and a.工艺路线版本 = '" + Model.工艺路线版本 + "'";
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        sErr = sErr + "生产订单 " + Model.生产订单号 + " 存货 " + Model.存货编码 + " 工艺路线版本 " + Model.工艺路线版本 + "已生产报工不能修改\n";
                        continue;
                    }

                    sSQL = "select * from 生产订单工艺路线 where 单据明细ID = '" + Model.单据明细ID + "'";
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    sSQL = "select * from 生产订单工艺路线 where 单据明细ID = '" + Model.单据明细ID + "'";
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int iExistsCou = 0;
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        iExistsCou = BaseFunction.BaseFunction.ReturnInt(dtTemp.Rows.Count);
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


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.生产订单工艺路线 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.生产订单号 != null)
            {
                strSql1.Append("生产订单号,");
                strSql2.Append("'" + model.生产订单号 + "',");
            }
            if (model.单据ID != null)
            {
                strSql1.Append("单据ID,");
                strSql2.Append("'" + model.单据ID + "',");
            }
            if (model.单据明细ID != null)
            {
                strSql1.Append("单据明细ID,");
                strSql2.Append("" + model.单据明细ID + ",");
            }
            if (model.存货编码 != null)
            {
                strSql1.Append("存货编码,");
                strSql2.Append("'" + model.存货编码 + "',");
            }
            if (model.工艺路线版本 != null)
            {
                strSql1.Append("工艺路线版本,");
                strSql2.Append("'" + model.工艺路线版本 + "',");
            }
            if (model.备注 != null)
            {
                strSql1.Append("备注,");
                strSql2.Append("'" + model.备注 + "',");
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
            strSql.Append("insert into 生产订单工艺路线(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.生产订单工艺路线 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 生产订单工艺路线 set ");
            if (model.生产订单号 != null)
            {
                strSql.Append("生产订单号='" + model.生产订单号 + "',");
            }
            else
            {
                strSql.Append("生产订单号= null ,");
            }
            if (model.单据ID != null)
            {
                strSql.Append("单据ID='" + model.单据ID + "',");
            }
            else
            {
                strSql.Append("单据ID= null ,");
            }
            if (model.存货编码 != null)
            {
                strSql.Append("存货编码='" + model.存货编码 + "',");
            }
            else
            {
                strSql.Append("存货编码= null ,");
            }
            if (model.工艺路线版本 != null)
            {
                strSql.Append("工艺路线版本='" + model.工艺路线版本 + "',");
            }
            else
            {
                strSql.Append("工艺路线版本= null ,");
            }
            if (model.备注 != null)
            {
                strSql.Append("备注='" + model.备注 + "',");
            }
            else
            {
                strSql.Append("备注= null ,");
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
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where 单据明细ID=" + model.单据明细ID + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.生产订单工艺路线 DataRowToModel(DataRow row)
        {
            TH.Model.生产订单工艺路线 model = new TH.Model.生产订单工艺路线();
            if (row != null)
            {
                if (row["生产订单号"] != null)
                {
                    model.生产订单号 = row["生产订单号"].ToString();
                }
                if (row["单据ID"] != null)
                {
                    model.单据ID = row["单据ID"].ToString();
                }
                if (row["单据明细ID"] != null && row["单据明细ID"].ToString() != "")
                {
                    model.单据明细ID = int.Parse(row["单据明细ID"].ToString());
                }
                if (row["存货编码"] != null)
                {
                    model.存货编码 = row["存货编码"].ToString();
                }
                if (row["工艺路线版本"] != null)
                {
                    model.工艺路线版本 = row["工艺路线版本"].ToString();
                }
                if (row["备注"] != null)
                {
                    model.备注 = row["备注"].ToString();
                }
                if (row["UpdataUid"] != null)
                {
                    model.UpdataUid = row["UpdataUid"].ToString();
                }
                if (row["UpdataDate"] != null && row["UpdataDate"].ToString() != "")
                {
                    model.UpdataDate = DateTime.Parse(row["UpdataDate"].ToString());
                }
                if (row["CreateUid"] != null)
                {
                    model.CreateUid = row["CreateUid"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
            }
            return model;
        }

    }
}

