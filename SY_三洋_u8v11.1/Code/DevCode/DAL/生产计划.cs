using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections;

namespace TH.DAL
{
    public partial class 生产计划
    {
        DAL.GetBaseData BaseData = new GetBaseData();

        public DataTable GetProLine(string sLineNO, string sInvCode)
        {
            string sSQL = @"
select * from dbo.InvLineCycle where [LineNo] = '111111' and cInvCode = '222222'
";
            sSQL = sSQL.Replace("111111", sLineNO);
            sSQL = sSQL.Replace("222222", sInvCode);
            DataTable dt = DbHelperSQL.Query(sSQL);
            return dt;
        }

        public DataTable GetProLine(string sInvCode)
        {
            string sSQL = @"
select cInvCode as 存货编码, [LineNo] as 产线编码, SelfCycle / isnull(SelfCycleB,1) as 单件生产工时
                      , SelfSetupCycle as 生产准备时间, Priority, SelfCapacity as 产线并发数
from InvLineCycle
where cInvCode = '222222'
order by isnull(Priority,0) desc
";
            sSQL = sSQL.Replace("222222", sInvCode);
            DataTable dt = DbHelperSQL.Query(sSQL);
            return dt;
        }

        /// <summary>
        /// 未制单
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public DataTable GetListUn(List<string> sWhere)
        {
            string sSQL = @"
select cast(0 as bit) as 选择, b.GUID as 来源GUID,'评审' as 单据类型,b.销售订单号,b.销售订单行号,b.子件编码 as 存货编码,cast(b.本单需求数量 as decimal(16,2)) as 数量,b.开始日期 as 计划开工日期,b.结束日期 as 计划完工日期
	,b.默认产线 as 产线编码,b.单件默认生产工时 as 单件生产工时,b.生产准备时间,b.默认产线并发生产数 as 产线并发数, case when isnull(b.生产部门编码,'') = '' then c.cDepCode else b.生产部门编码 end as 生产部门编码,cast(null as varchar(50)) as  制单人,cast(null as datetime) as  制单日期
	,cast(null as varchar(50)) as  备注1,cast(null as varchar(50)) as  备注2,cast(null as varchar(50)) as  备注3,cast(null as varchar(50)) as  备注4,cast(null as varchar(50)) as  备注5,a.评审单据号
    ,null as iID,null as guid
    ,cast(null as varchar(50)) as  审核人,cast(null as varchar(50)) as  关闭人 ,cast(null as datetime) as  审核日期,cast(null as datetime) as  关闭日期
     ,d.cCusCode as 客户编码,e.cCusName as 客户
from dbo.订单评审 a inner join dbo.订单评审明细 b on a.guid = b.guidhead
    left join ProductionLine c on c.[LineNo] = b.默认产线
    left join @u8.so_somain d on d.cSOCode = b.销售订单号
    left join @u8.Customer e on e.cCusCode = d.cCusCode
where isnull(a.审核人,'') <> '' and isnull(a.关闭人,'') = '' and b.子件属性 = '自制' and b.供应类型 <> '虚拟件' and 1=1
	and b.GUID not in (select 来源GUID from dbo.生产计划 where 单据类型 = '评审')
order by b.iID
     ";


            for (int i = 0; i < sWhere.Count; i++)
            {
                string[] s = sWhere[i].Split('●');
                sSQL = sSQL.Replace(s[0], s[1]);
            }

            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 已制单
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public DataTable GetListed(List<string> sWhere)
        {
            string sSQL = @"
select cast(0 as bit) as 选择, a.iID, a.GUID, a.来源GUID, a.单据类型, a.评审单据号, a.销售订单号, a.销售订单行号, a.存货编码, cast(a.数量 as decimal(16,2)) as 数量,CONVERT(varchar(100), a.计划开工日期,111) as 计划开工日期, CONVERT(varchar(100), a.计划完工日期,111) as 计划完工日期, a.产线编码, a.单件生产工时 
    ,a.产线并发数, a.生产准备时间, a.生产部门编码, a.制单人, CONVERT(varchar(100),a.制单日期,111) as 制单日期,a.审核人,CONVERT(varchar(100),a.审核日期,111) as 审核日期,a.关闭人,CONVERT(varchar(100),a.关闭日期,111) as 关闭日期, a.备注1, a.备注2, a.备注3, a.备注4, a.备注5
    ,CONVERT(varchar(100),a.制单日期,111) as 单据日期  ,cast(b.完工数量 as decimal(16,2)) as 完工数量
from 生产计划 a
	left join 
	(
        select a.GUID,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,a.数量
            ,sum(c.完工数量) as 完工数量
        from dbo.生产计划 a 
            inner join dbo.生产日计划 b on a.GUID = b.来源GUID
            left join 生产日计划完工登记 c on c.生产日计划iID = b.iID
        group by a.GUID,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,a.数量
	) b on a.guid = b.guid
where  1=1
order by a.iID
     ";


            for (int i = 0; i < sWhere.Count; i++)
            { 
                string[] s = sWhere[i].Split('●');
                sSQL = sSQL.Replace(s[0], s[1]);
            }

            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int Audit(DataTable dt)
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

                    TH.Model.生产计划 Model = new TH.Model.生产计划();
                    Model = DataRowToModel(dt.Rows[i]);
                    string sSQL = "update 生产计划 set 审核人 = '222222',审核日期 = getdate() where GUID = '111111'";
                    sSQL = sSQL.Replace("111111", Model.GUID.ToString());
                    sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUserName);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

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
        /// 弃审
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UnAudit(DataTable dt)
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

                    TH.Model.生产计划 Model = new TH.Model.生产计划();
                    Model = DataRowToModel(dt.Rows[i]);
                    string sSQL = "select * from 生产日计划 where 来源GUID = '111111'";
                    sSQL = sSQL.Replace("111111", Model.GUID.ToString().Trim());
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "已经排产\n";
                        continue;
                    }

                    sSQL = "update 生产计划 set 审核人 =null,审核日期 = null where GUID = '111111'";
                    sSQL = sSQL.Replace("111111", Model.GUID.ToString());
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

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
        /// 关闭
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
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
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["选择"]))
                    {
                        continue;
                    }

                    TH.Model.生产计划 Model = new TH.Model.生产计划();
                    Model = DataRowToModel(dt.Rows[i]);
                    string sSQL = "update 生产计划 set 关闭人 = '222222',关闭日期 = getdate() where GUID = '111111'";
                    sSQL = sSQL.Replace("111111", Model.GUID.ToString());
                    sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUserName);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

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
        /// 打开
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
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

                    TH.Model.生产计划 Model = new TH.Model.生产计划();
                    Model = DataRowToModel(dt.Rows[i]);
                    string sSQL = "update 生产计划 set 关闭人 =null,关闭日期 = null where GUID = '111111'";
                    sSQL = sSQL.Replace("111111", Model.GUID.ToString());
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

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
        /// 删除
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
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
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["选择"]))
                    {
                        continue;
                    }

                    TH.Model.生产计划 Model = new TH.Model.生产计划();
                    Model = DataRowToModel(dt.Rows[i]);
                    string sSQL = Delete(Model.GUID.ToString());
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

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
        /// 撤销
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UnSave(DataTable dt)
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

                    TH.Model.生产计划 Model = new TH.Model.生产计划();
                    Model = DataRowToModel(dt.Rows[i]);
                    string sSQL = "select * from 生产日计划 where 来源GUID = '111111'";
                    sSQL = sSQL.Replace("111111", Model.GUID.ToString().Trim());
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "已经排产\n";
                        continue;
                    }


                    sSQL = Delete(Model.GUID.ToString());
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        public int Save(DataTable dt,string sType)
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

                    TH.Model.生产计划 Model = new TH.Model.生产计划();
                    Model = DataRowToModel(dt.Rows[i]);

                    if(Model.存货编码 == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "存货编码必须选择\n";
                    }
                    if (Model.计划开工日期 == null || Model.计划开工日期 < DateTime.Today)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "计划开工日期必须不小于今天\n";
                    }
                    if (Model.计划完工日期 == null || Model.计划完工日期 < DateTime.Today || Model.计划完工日期 < Model.计划开工日期)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "计划完工日期必须不小于计划开工日期\n";
                    }

                    if (Model.产线编码 == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "产线必须选择\n";
                    }

                    if (BaseFunction.BaseFunction.ReturnInt(Model.产线并发数) == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "产线人数必须定义\n";
                    }
                    if (BaseFunction.BaseFunction.ReturnDecimal(Model.单件生产工时) == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "产线单件生产工时必须定义\n";
                    }
                    if (Model.生产部门编码 == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "生产部门必须定义\n";
                    }
                    if (BaseFunction.BaseFunction.ReturnDecimal(Model.数量, 0) <= 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "数量必须大于0\n";
                    }
                    if (Model.生产部门编码.Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "生产部门编码不能为空\n";
                    }
                    if(Model.产线编码.Trim() =="")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "产线编码不能为空\n";
                    }
                    if (Model.数量<=0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "数量必须大于0\n";
                    }


                    if (sErr.Trim() != "")
                    {
                        continue;
                    }
                    if (Model.GUID.ToString() == "")
                    {
                        Model.GUID = Guid.NewGuid();
                    }
                    if (sType == "评审")
                    {
                        Model.审核人 = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                        Model.审核日期 = BaseData.GetDatetimeSer();
                    }


                    Model.制单人 = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    Model.制单日期 = BaseData.GetDatetimeSer();
                    Model.单据类型 = sType;

                    string sSQL= Exists(Model.GUID.ToString());
                    DataTable dtTemp =DbHelperSQL.ExecuteDataset(tran,CommandType.Text,sSQL).Tables[0];
                    int iTemp = BaseFunction.BaseFunction.ReturnBoolToInt(dtTemp.Rows[0][0]);

                    if (iTemp >0)
                    {
                        sSQL = Update(Model);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        sSQL = Add(Model);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update dbo.订单评审明细 set 下达人 = '" + Model.制单人 + "',下达日期 = '" + Model.制单日期 + "' where GUID = '" + Model.来源GUID + "'";
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

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
        /// 删除一条数据
        /// </summary>
        public string Delete(string sGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 生产计划 ");
            strSql.Append(" where GUID='" + sGuid + "'");
            return strSql.ToString();
        }	

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private TH.Model.生产计划 DataRowToModel(DataRow row)
        {
            TH.Model.生产计划 model = new TH.Model.生产计划();
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
                if (row["来源GUID"] != null && row["来源GUID"].ToString() != "")
                {
                    model.来源GUID = new Guid(row["来源GUID"].ToString());
                }
                if (row["单据类型"] != null)
                {
                    model.单据类型 = row["单据类型"].ToString();
                }
                if (row["评审单据号"] != null)
                {
                    model.评审单据号 = row["评审单据号"].ToString();
                }
                if (row["销售订单号"] != null)
                {
                    model.销售订单号 = row["销售订单号"].ToString();
                }
                if (row["销售订单行号"] != null)
                {
                    model.销售订单行号 = row["销售订单行号"].ToString();
                }
                if (row["存货编码"] != null)
                {
                    model.存货编码 = row["存货编码"].ToString();
                }
                if (row["数量"] != null && row["数量"].ToString() != "")
                {
                    model.数量 = decimal.Parse(row["数量"].ToString());
                }
                if (row["计划开工日期"] != null && row["计划开工日期"].ToString() != "")
                {
                    model.计划开工日期 = DateTime.Parse(row["计划开工日期"].ToString());
                }
                if (row["计划完工日期"] != null && row["计划完工日期"].ToString() != "")
                {
                    model.计划完工日期 = DateTime.Parse(row["计划完工日期"].ToString());
                }
                if (row["产线编码"] != null)
                {
                    model.产线编码 = row["产线编码"].ToString();
                }
                if (row["单件生产工时"] != null && row["单件生产工时"].ToString() != "")
                {
                    model.单件生产工时 = decimal.Parse(row["单件生产工时"].ToString());
                }
                if (row["产线并发数"] != null && row["产线并发数"].ToString() != "")
                {
                    model.产线并发数 = decimal.Parse(row["产线并发数"].ToString());
                }
                if (row["生产准备时间"] != null && row["生产准备时间"].ToString() != "")
                {
                    model.生产准备时间 = decimal.Parse(row["生产准备时间"].ToString());
                }
                if (row["生产部门编码"] != null)
                {
                    model.生产部门编码 = row["生产部门编码"].ToString();
                }
                if (row["制单人"] != null)
                {
                    model.制单人 = row["制单人"].ToString();
                }
                if (row["制单日期"] != null && row["制单日期"].ToString() != "")
                {
                    model.制单日期 = DateTime.Parse(row["制单日期"].ToString());
                }
                if (row["审核人"] != null)
                {
                    model.审核人 = row["审核人"].ToString();
                }
                if (row["审核日期"] != null && row["审核日期"].ToString() != "")
                {
                    model.审核日期 = DateTime.Parse(row["审核日期"].ToString());
                }
                if (row["关闭人"] != null)
                {
                    model.关闭人 = row["关闭人"].ToString();
                }
                if (row["关闭日期"] != null && row["关闭日期"].ToString() != "")
                {
                    model.关闭日期 = DateTime.Parse(row["关闭日期"].ToString());
                }
                if (row["备注1"] != null)
                {
                    model.备注1 = row["备注1"].ToString();
                }
                if (row["备注2"] != null)
                {
                    model.备注2 = row["备注2"].ToString();
                }
                if (row["备注3"] != null)
                {
                    model.备注3 = row["备注3"].ToString();
                }
                if (row["备注4"] != null)
                {
                    model.备注4 = row["备注4"].ToString();
                }
                if (row["备注5"] != null)
                {
                    model.备注5 = row["备注5"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        private string Add(TH.Model.生产计划 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.来源GUID != null)
            {
                strSql1.Append("来源GUID,");
                strSql2.Append("'" + model.来源GUID.ToString() + "',");
            }
            if (model.单据类型 != null)
            {
                strSql1.Append("单据类型,");
                strSql2.Append("'" + model.单据类型 + "',");
            }
            if (model.评审单据号 != null)
            {
                strSql1.Append("评审单据号,");
                strSql2.Append("'" + model.评审单据号 + "',");
            }
            if (model.销售订单号 != null)
            {
                strSql1.Append("销售订单号,");
                strSql2.Append("'" + model.销售订单号 + "',");
            }
            if (model.销售订单行号 != null)
            {
                strSql1.Append("销售订单行号,");
                strSql2.Append("'" + model.销售订单行号 + "',");
            }
            if (model.存货编码 != null)
            {
                strSql1.Append("存货编码,");
                strSql2.Append("'" + model.存货编码 + "',");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
            }
            if (model.计划开工日期 != null)
            {
                strSql1.Append("计划开工日期,");
                strSql2.Append("'" + model.计划开工日期 + "',");
            }
            if (model.计划完工日期 != null)
            {
                strSql1.Append("计划完工日期,");
                strSql2.Append("'" + model.计划完工日期 + "',");
            }
            if (model.产线编码 != null)
            {
                strSql1.Append("产线编码,");
                strSql2.Append("'" + model.产线编码 + "',");
            }
            if (model.单件生产工时 != null)
            {
                strSql1.Append("单件生产工时,");
                strSql2.Append("" + model.单件生产工时 + ",");
            }
            if (model.产线并发数 != null)
            {
                strSql1.Append("产线并发数,");
                strSql2.Append("" + model.产线并发数 + ",");
            }
            if (model.生产准备时间 != null)
            {
                strSql1.Append("生产准备时间,");
                strSql2.Append("" + model.生产准备时间 + ",");
            }
            if (model.生产部门编码 != null)
            {
                strSql1.Append("生产部门编码,");
                strSql2.Append("'" + model.生产部门编码 + "',");
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
            if (model.关闭人 != null)
            {
                strSql1.Append("关闭人,");
                strSql2.Append("'" + model.关闭人 + "',");
            }
            if (model.关闭日期 != null)
            {
                strSql1.Append("关闭日期,");
                strSql2.Append("'" + model.关闭日期 + "',");
            }

            if (model.备注1 != null)
            {
                strSql1.Append("备注1,");
                strSql2.Append("'" + model.备注1 + "',");
            }
            if (model.备注2 != null)
            {
                strSql1.Append("备注2,");
                strSql2.Append("'" + model.备注2 + "',");
            }
            if (model.备注3 != null)
            {
                strSql1.Append("备注3,");
                strSql2.Append("'" + model.备注3 + "',");
            }
            if (model.备注4 != null)
            {
                strSql1.Append("备注4,");
                strSql2.Append("'" + model.备注4 + "',");
            }
            if (model.备注5 != null)
            {
                strSql1.Append("备注5,");
                strSql2.Append("'" + model.备注5 + "',");
            }
            strSql.Append("insert into 生产计划(");
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
        private string Update(TH.Model.生产计划 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 生产计划 set ");
            if (model.GUID != null)
            {
                strSql.Append("GUID='" + model.GUID + "',");
            }
            if (model.来源GUID != null)
            {
                strSql.Append("来源GUID='" + model.来源GUID + "',");
            }
            if (model.单据类型 != null)
            {
                strSql.Append("单据类型='" + model.单据类型 + "',");
            }
            if (model.评审单据号 != null)
            {
                strSql.Append("评审单据号='" + model.评审单据号 + "',");
            }
            else
            {
                strSql.Append("评审单据号= null ,");
            }
            if (model.销售订单号 != null)
            {
                strSql.Append("销售订单号='" + model.销售订单号 + "',");
            }
            else
            {
                strSql.Append("销售订单号= null ,");
            }
            if (model.销售订单行号 != null)
            {
                strSql.Append("销售订单行号='" + model.销售订单行号 + "',");
            }
            else
            {
                strSql.Append("销售订单行号= null ,");
            }
            if (model.存货编码 != null)
            {
                strSql.Append("存货编码='" + model.存货编码 + "',");
            }
            else
            {
                strSql.Append("存货编码= null ,");
            }
            if (model.数量 != null)
            {
                strSql.Append("数量=" + model.数量 + ",");
            }
            else
            {
                strSql.Append("数量= null ,");
            }
            if (model.计划开工日期 != null)
            {
                strSql.Append("计划开工日期='" + model.计划开工日期 + "',");
            }
            else
            {
                strSql.Append("计划开工日期= null ,");
            }
            if (model.计划完工日期 != null)
            {
                strSql.Append("计划完工日期='" + model.计划完工日期 + "',");
            }
            else
            {
                strSql.Append("计划完工日期= null ,");
            }
            if (model.产线编码 != null)
            {
                strSql.Append("产线编码='" + model.产线编码 + "',");
            }
            else
            {
                strSql.Append("产线编码= null ,");
            }
            if (model.单件生产工时 != null)
            {
                strSql.Append("单件生产工时=" + model.单件生产工时 + ",");
            }
            else
            {
                strSql.Append("单件生产工时= null ,");
            }
            if (model.产线并发数 != null)
            {
                strSql.Append("产线并发数=" + model.产线并发数 + ",");
            }
            else
            {
                strSql.Append("产线并发数= null ,");
            }
            if (model.生产准备时间 != null)
            {
                strSql.Append("生产准备时间=" + model.生产准备时间 + ",");
            }
            else
            {
                strSql.Append("生产准备时间= null ,");
            }
            if (model.生产部门编码 != null)
            {
                strSql.Append("生产部门编码='" + model.生产部门编码 + "',");
            }
            else
            {
                strSql.Append("生产部门编码= null ,");
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
            if (model.关闭人 != null)
            {
                strSql.Append("关闭人='" + model.关闭人 + "',");
            }
            else
            {
                strSql.Append("关闭人= null ,");
            }
            if (model.关闭日期 != null)
            {
                strSql.Append("关闭日期='" + model.关闭日期 + "',");
            }
            else
            {
                strSql.Append("关闭日期= null ,");
            }
            if (model.备注1 != null)
            {
                strSql.Append("备注1='" + model.备注1 + "',");
            }
            else
            {
                strSql.Append("备注1= null ,");
            }
            if (model.备注2 != null)
            {
                strSql.Append("备注2='" + model.备注2 + "',");
            }
            else
            {
                strSql.Append("备注2= null ,");
            }
            if (model.备注3 != null)
            {
                strSql.Append("备注3='" + model.备注3 + "',");
            }
            else
            {
                strSql.Append("备注3= null ,");
            }
            if (model.备注4 != null)
            {
                strSql.Append("备注4='" + model.备注4 + "',");
            }
            else
            {
                strSql.Append("备注4= null ,");
            }
            if (model.备注5 != null)
            {
                strSql.Append("备注5='" + model.备注5 + "',");
            }
            else
            {
                strSql.Append("备注5= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return strSql.ToString();
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        private string Exists(string sGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 生产计划");
            strSql.Append(" where GUID='" + sGuid + "' ");
            return (strSql.ToString());
        }
    }
}
