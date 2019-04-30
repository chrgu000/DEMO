using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:生产日报表
    /// </summary>
    public partial class 生产日报表
    {
        public 生产日报表()
        { }

        public int Audit(TH.Model.生产日报表 model)
        {
            string sErr = "";
            int iCou = 0;

            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                if (sErr.Length > 0)
                    throw new Exception(sErr);

                string sSQL = "select * from 生产日报表 where GUID = '" + model.GUID + "'";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    if (dtTemp.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        throw new Exception("单据已经审核");
                    }
                }

                sSQL = "update 生产日报表 set 审核人 = '" + model.审核人 + "' ,审核日期 = getdate() where GUID = '" + model.GUID + "'";
                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                if (iCou == 0)
                    throw new Exception("单据不存在，审核失败");

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

        public int UnAudit(TH.Model.生产日报表 model)
        {
            string sErr = "";
            int iCou = 0;

            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                if (sErr.Length > 0)
                    throw new Exception(sErr);

                string sSQL = "select * from 生产日报表  where GUID = '" + model.GUID + "'";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    if (dtTemp.Rows[0]["审核人"].ToString().Trim() == "")
                    {
                        throw new Exception("单据未审核");
                    }
                }
                sSQL = "update 生产日报表 set 审核人 = null ,审核日期 = null where GUID = '" + model.GUID + "'";
                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);



                if (iCou == 0)
                    throw new Exception("单据不存在，弃审失败");

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

        public int Save(TH.Model.生产日报表 model, DataTable dt)
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
                    _GetBaseData _GetBaseData = new _GetBaseData();
                    DateTime dTimeNow = _GetBaseData.GetDatetimeSer();

                    string sSQL = "";

                    if (model.iID == 0)
                    {
                        model.制单人 = FrameBaseFunction.ClsBaseDataInfo.sUid;
                        model.制单日期 = dTimeNow;
                        sSQL = Add(model);
                    }
                    else
                    {
                        sSQL = Update(model);
                    }
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "delete 生产日报表明细 where 表头GUID = '" + model.GUID.ToString() + "'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["选择"]))
                        {
                            continue;
                        }

                        TH.Model.生产日报表明细 models = DataRowToModel(dt.Rows[i]);
                        models.表头GUID = model.GUID;
                        sSQL = Add(models);
                       iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    }

                    if (iCou == 0)
                        throw new Exception("没有需要保存的箱号");

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

            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

            return iCou;
        }

        public DataTable Get未报工箱号(string s生产订单序号, string s工艺路线顺序, string s工序)
        {
            string sSQL = @"
select cast(0 as bit) as 选择, 箱号,数量 as 装箱数
from dbo.生产订单中转箱记录 
where 单据明细ID = 111111 and 箱号 not in 
(
	select b.箱号 from dbo.生产日报表 a inner join dbo.生产日报表明细 b on a.GUID = b.表头GUID
	where a.生产订单序号 = '111111' and a.工艺路线顺序 = '222222' and a.工序 = '333333'
) 
";
            sSQL = sSQL.Replace("111111", s生产订单序号);
            sSQL = sSQL.Replace("222222", s工艺路线顺序);
            sSQL = sSQL.Replace("333333", s工序);

            return DbHelperSQL.Query(sSQL);
        }


        public DataTable Get生产报工(string s生产订单序号,string s班次,string s工艺路线顺序,string s工序,DateTime dDate)
        {
            string sSQL = @"
select  b.MainId as 生产订单序号,a.cCode as 生产订单号,a.dDate as 单据日期,cast(b.fQuantity as decimal(16,0)) as 生产订单数量
	,b.cInvCode as 存货编码,c.cInvName as 存货名称,c.cInvStd as 规格型号
	,d.*,e.*
from @u8.PP_ProductPO a
	inner join @u8.pp_pomain b on a.ID = b.ID
	inner join @u8.Inventory c on c.cInvCode = b.cInvCode
	left join dbo.生产日报表 d on d.生产订单序号 = b.MainId and d.班次 = '222222' and d.工艺路线顺序 = '333333' and d.工序 = '444444' and d.日期 = '555555'
	left join dbo.生产日报表明细 e on e.表头GUID = d.GUID
where b.MainId = 111111
            ";

            sSQL = sSQL.Replace("111111", s生产订单序号);
            sSQL = sSQL.Replace("222222", s班次);
            sSQL = sSQL.Replace("333333", s工艺路线顺序);
            sSQL = sSQL.Replace("444444", s工序);
            sSQL = sSQL.Replace("555555", dDate.ToString("yyyy-MM-dd"));

            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 获得生产订单工序信息
        /// </summary>
        public DataTable GetWorkProcess(string sWhere)
        {
            string sSQL = @"
select  b.MainId as 生产订单序号 ,f.WorkSort 工艺路线顺序,a.cCode as 生产订单号,a.dDate as 单据日期,b.cInvCode as 存货编码,c.cInvName as 存货名称,c.cInvStd as 规格型号,e.工艺路线版本 as 工艺路线版本,e.备注
		,cast(b.fQuantity as decimal(16,0)) as 生产订单数量,f.WorkProcessNo as 工序编号,g.WorkProcessName as 工序
        ,h.箱数,i.报工箱数,a.ID as 单据ID
from @u8.PP_ProductPO a
	inner join @u8.pp_pomain b on a.ID = b.ID
	inner join @u8.Inventory c on c.cInvCode = b.cInvCode
	inner join dbo.生产订单工艺路线 e on e.单据明细ID = b.MainId 
	inner join dbo.ProcessRoute f on f.cInvCode = b.cInvCode and f.Versions = e.工艺路线版本
	inner join dbo.WorkProcess g on g.WorkProcessNo = f.WorkProcessNo
	inner join (select 单据明细ID,count(1) as 箱数 from dbo.生产订单中转箱记录 where isnull(CloseUid,'') = '' group by 单据明细ID) h on h.单据明细ID = b.MainId
	left join (		select 生产订单序号,工序,count(1) as 报工箱数,工艺路线顺序
					from dbo.生产日报表 a inner join dbo.生产日报表明细 b on a.GUID = b.表头GUID
					group by 生产订单序号,工序,工艺路线顺序
				)i on i.生产订单序号 = b.MainId and f.WorkProcessNo = i.工序 and i.工艺路线顺序 = f.WorkSort
where 1=1 
order by a.ID,b.MainId,f.WorkSort
";

            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1 ", sWhere);
            }

            return DbHelperSQL.Query(sSQL);
        }
        /// <summary>
        /// 获得生产订单工艺路线
        /// </summary>
        public DataTable GetWorkProcess(string s工序编号,string s生产订单序号)
        {
            string sSQL = @"
select b.WorkSort as 工艺路线顺序
from dbo.生产订单工艺路线 a
	inner join ProcessRoute b on a.工艺路线版本 = b.Versions and a.存货编码 = b.cInvCode
where b.WorkProcessNo = '111111' and a.单据明细ID = 222222
order by b.WorkSort
";

            sSQL = sSQL.Replace("111111", s工序编号);
            sSQL = sSQL.Replace("222222", s生产订单序号);
    

            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  iID, GUID, 日期, 生产订单序号, 工艺路线版本, 工艺路线顺序, 工序, 班次, 机床号, 作业员, 存货编码, 模号, 转速, 良品数, 不良数, 计划停机, 机故, 模故, 换模, 换料, 测量, 吃饭, 休息, 清扫, 换班, 待料, 其它, 备注, 制单人, 制单日期, 审核人, 审核日期");
            strSql.Append(" FROM 生产日报表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1" + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.生产日报表 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("'" + model.GUID + "',");
            }
            if (model.日期 != null)
            {
                strSql1.Append("日期,");
                strSql2.Append("'" + model.日期 + "',");
            }
            if (model.生产订单序号 != null)
            {
                strSql1.Append("生产订单序号,");
                strSql2.Append("" + model.生产订单序号 + ",");
            }
            if (model.工艺路线版本 != null)
            {
                strSql1.Append("工艺路线版本,");
                strSql2.Append("'" + model.工艺路线版本 + "',");
            }
            if (model.工艺路线顺序 != null)
            {
                strSql1.Append("工艺路线顺序,");
                strSql2.Append("'" + model.工艺路线顺序 + "',");
            }
            if (model.工序 != null)
            {
                strSql1.Append("工序,");
                strSql2.Append("'" + model.工序 + "',");
            }
            if (model.班次 != null)
            {
                strSql1.Append("班次,");
                strSql2.Append("'" + model.班次 + "',");
            }
            if (model.机床号 != null)
            {
                strSql1.Append("机床号,");
                strSql2.Append("'" + model.机床号 + "',");
            }
            if (model.作业员 != null)
            {
                strSql1.Append("作业员,");
                strSql2.Append("'" + model.作业员 + "',");
            }
            if (model.存货编码 != null)
            {
                strSql1.Append("存货编码,");
                strSql2.Append("'" + model.存货编码 + "',");
            }
            if (model.模号 != null)
            {
                strSql1.Append("模号,");
                strSql2.Append("'" + model.模号 + "',");
            }
            if (model.转速 != null)
            {
                strSql1.Append("转速,");
                strSql2.Append("'" + model.转速 + "',");
            }
            if (model.良品数 != null)
            {
                strSql1.Append("良品数,");
                strSql2.Append("" + model.良品数 + ",");
            }
            if (model.不良数 != null)
            {
                strSql1.Append("不良数,");
                strSql2.Append("" + model.不良数 + ",");
            }
            if (model.计划停机 != null)
            {
                strSql1.Append("计划停机,");
                strSql2.Append("" + model.计划停机 + ",");
            }
            if (model.机故 != null)
            {
                strSql1.Append("机故,");
                strSql2.Append("" + model.机故 + ",");
            }
            if (model.模故 != null)
            {
                strSql1.Append("模故,");
                strSql2.Append("" + model.模故 + ",");
            }
            if (model.换模 != null)
            {
                strSql1.Append("换模,");
                strSql2.Append("" + model.换模 + ",");
            }
            if (model.换料 != null)
            {
                strSql1.Append("换料,");
                strSql2.Append("" + model.换料 + ",");
            }
            if (model.测量 != null)
            {
                strSql1.Append("测量,");
                strSql2.Append("" + model.测量 + ",");
            }
            if (model.吃饭 != null)
            {
                strSql1.Append("吃饭,");
                strSql2.Append("" + model.吃饭 + ",");
            }
            if (model.休息 != null)
            {
                strSql1.Append("休息,");
                strSql2.Append("" + model.休息 + ",");
            }
            if (model.清扫 != null)
            {
                strSql1.Append("清扫,");
                strSql2.Append("" + model.清扫 + ",");
            }
            if (model.换班 != null)
            {
                strSql1.Append("换班,");
                strSql2.Append("" + model.换班 + ",");
            }
            if (model.待料 != null)
            {
                strSql1.Append("待料,");
                strSql2.Append("" + model.待料 + ",");
            }
            if (model.其它 != null)
            {
                strSql1.Append("其它,");
                strSql2.Append("" + model.其它 + ",");
            }
            if (model.备注 != null)
            {
                strSql1.Append("备注,");
                strSql2.Append("'" + model.备注 + "',");
            }
            if (model.制单人 != null)
            {
                strSql1.Append("制单人,");
                strSql2.Append("'" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql1.Append("制单日期,");
                strSql2.Append("'" + model.制单日期 + "',");
            }
            if (model.审核人 != null)
            {
                strSql1.Append("审核人,");
                strSql2.Append("'" + model.审核人 + "',");
            }
            if (model.审核日期 != null)
            {
                strSql1.Append("审核日期,");
                strSql2.Append("'" + model.审核日期 + "',");
            }
            strSql.Append("insert into 生产日报表(");
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
        public string Update(TH.Model.生产日报表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 生产日报表 set ");
            if (model.GUID != null)
            {
                strSql.Append("GUID='" + model.GUID + "',");
            }
            else
            {
                strSql.Append("GUID= null ,");
            }
            if (model.工艺路线版本 != null)
            {
                strSql.Append("工艺路线版本='" + model.工艺路线版本 + "',");
            }
            else
            {
                strSql.Append("工艺路线版本= null ,");
            }
            if (model.机床号 != null)
            {
                strSql.Append("机床号='" + model.机床号 + "',");
            }
            else
            {
                strSql.Append("机床号= null ,");
            }
            if (model.作业员 != null)
            {
                strSql.Append("作业员='" + model.作业员 + "',");
            }
            else
            {
                strSql.Append("作业员= null ,");
            }
            if (model.存货编码 != null)
            {
                strSql.Append("存货编码='" + model.存货编码 + "',");
            }
            if (model.模号 != null)
            {
                strSql.Append("模号='" + model.模号 + "',");
            }
            else
            {
                strSql.Append("模号= null ,");
            }
            if (model.转速 != null)
            {
                strSql.Append("转速='" + model.转速 + "',");
            }
            else
            {
                strSql.Append("转速= null ,");
            }
            if (model.良品数 != null)
            {
                strSql.Append("良品数=" + model.良品数 + ",");
            }
            else
            {
                strSql.Append("良品数= null ,");
            }
            if (model.不良数 != null)
            {
                strSql.Append("不良数=" + model.不良数 + ",");
            }
            else
            {
                strSql.Append("不良数= null ,");
            }
            if (model.计划停机 != null)
            {
                strSql.Append("计划停机=" + model.计划停机 + ",");
            }
            else
            {
                strSql.Append("计划停机= null ,");
            }
            if (model.机故 != null)
            {
                strSql.Append("机故=" + model.机故 + ",");
            }
            else
            {
                strSql.Append("机故= null ,");
            }
            if (model.模故 != null)
            {
                strSql.Append("模故=" + model.模故 + ",");
            }
            else
            {
                strSql.Append("模故= null ,");
            }
            if (model.换模 != null)
            {
                strSql.Append("换模=" + model.换模 + ",");
            }
            else
            {
                strSql.Append("换模= null ,");
            }
            if (model.换料 != null)
            {
                strSql.Append("换料=" + model.换料 + ",");
            }
            else
            {
                strSql.Append("换料= null ,");
            }
            if (model.测量 != null)
            {
                strSql.Append("测量=" + model.测量 + ",");
            }
            else
            {
                strSql.Append("测量= null ,");
            }
            if (model.吃饭 != null)
            {
                strSql.Append("吃饭=" + model.吃饭 + ",");
            }
            else
            {
                strSql.Append("吃饭= null ,");
            }
            if (model.休息 != null)
            {
                strSql.Append("休息=" + model.休息 + ",");
            }
            else
            {
                strSql.Append("休息= null ,");
            }
            if (model.清扫 != null)
            {
                strSql.Append("清扫=" + model.清扫 + ",");
            }
            else
            {
                strSql.Append("清扫= null ,");
            }
            if (model.换班 != null)
            {
                strSql.Append("换班=" + model.换班 + ",");
            }
            else
            {
                strSql.Append("换班= null ,");
            }
            if (model.待料 != null)
            {
                strSql.Append("待料=" + model.待料 + ",");
            }
            else
            {
                strSql.Append("待料= null ,");
            }
            if (model.其它 != null)
            {
                strSql.Append("其它=" + model.其它 + ",");
            }
            else
            {
                strSql.Append("其它= null ,");
            }
            if (model.备注 != null)
            {
                strSql.Append("备注='" + model.备注 + "',");
            }
            else
            {
                strSql.Append("备注= null ,");
            }
            if (model.制单人 != null)
            {
                strSql.Append("制单人='" + model.制单人 + "',");
            }
            else
            {
                strSql.Append("制单人= null ,");
            }
            if (model.制单日期 != null)
            {
                strSql.Append("制单日期='" + model.制单日期 + "',");
            }
            else
            {
                strSql.Append("制单日期= null ,");
            }
            if (model.审核人 != null)
            {
                strSql.Append("审核人='" + model.审核人 + "',");
            }
            else
            {
                strSql.Append("审核人= null ,");
            }
            if (model.审核日期 != null)
            {
                strSql.Append("审核日期='" + model.审核日期 + "',");
            }
            else
            {
                strSql.Append("审核日期= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());

        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.生产日报表明细 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.表头GUID != null)
            {
                strSql1.Append("表头GUID,");
                strSql2.Append("'" + model.表头GUID+ "',");
            }
            if (model.箱号 != null)
            {
                strSql1.Append("箱号,");
                strSql2.Append("'" + model.箱号 + "',");
            }
            if (model.装箱数 != null)
            {
                strSql1.Append("装箱数,");
                strSql2.Append("" + model.装箱数 + ",");
            }
            strSql.Append("insert into 生产日报表明细(");
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
        public string Update(TH.Model.生产日报表明细 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 生产日报表明细 set ");
            if (model.表头GUID != null)
            {
                strSql.Append("表头GUID='" + model.表头GUID + "',");
            }
            else
            {
                strSql.Append("表头GUID= null ,");
            }
            if (model.箱号 != null)
            {
                strSql.Append("箱号='" + model.箱号 + "',");
            }
            else
            {
                strSql.Append("箱号= null ,");
            }
            if (model.装箱数 != null)
            {
                strSql.Append("装箱数=" + model.装箱数 + ",");
            }
            else
            {
                strSql.Append("装箱数= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.生产日报表明细 DataRowToModel(DataRow row)
        {
            TH.Model.生产日报表明细 model = new TH.Model.生产日报表明细();
            if (row != null)
            {
                if (row["箱号"] != null)
                {
                    model.箱号 = row["箱号"].ToString();
                }
                if (row["装箱数"] != null && row["装箱数"].ToString() != "")
                {
                    model.装箱数 = decimal.Parse(row["装箱数"].ToString());
                }
            }
            return model;
        }
    }
}

