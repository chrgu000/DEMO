using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;
using System.Xml;
using ClsBaseClass;
using System.Data.SqlClient;

namespace TH.DBWebService
{
    /// <summary>
    /// 基于U8V10.1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class DBWebService : System.Web.Services.WebService
    {
        public DBWebService()
        {
            //ClsBaseDataInfo.sConnString = "uid=saa;pwd=;database=SystemDB_GDJ;server=192.168.39.62";
            ClsBaseDataInfo.sConnString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GDJConnectionString"].ToString();
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World:" + ClsBaseDataInfo.sConnString;
        }

        /// <summary>
        /// 向T6中同步客户档案
        /// </summary>
        /// <param name="sXML"></param>
        /// <returns></returns>
        [WebMethod]
        public string InsertCustomer(string sXML)
        {
            string sReturn = "";
            int iCount = 0;

            try
            {
                string sErr = "";

                DataSet ds = ClsBaseClass.Cls序列化.ConvertXMLToDataSet(sXML);
                if (ds == null || ds.Tables.Count != 1)
                {
                    throw new Exception("解析XML失败");
                }

                DataTable dtData = ds.Tables[0];
                if (dtData.TableName.ToLower().Trim() != "customer")
                    throw new Exception("档案类型错误");

                if (dtData == null || dtData.Rows.Count < 1)
                    throw new Exception("没有需要保存的数据");

                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select * from SystemDB_GDJ.dbo.帐套数据库对照表";
                    DataTable dt帐套 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        string s帐套 = dtData.Rows[i]["AccID"].ToString().Trim();
                        DataRow[] dr帐套 = dt帐套.Select("名称 = '" + s帐套 + "'");
                        if (dr帐套.Length != 1)
                            throw new Exception("帐套数据库对照表存在错误");

                        string 数据库 = dr帐套[0]["帐套数据库"].ToString().Trim();

                        string s客户编码 = dtData.Rows[i]["cCusCode"].ToString().Trim();
                        if (s客户编码 == "")
                        {
                            sErr = sErr + "客户编码不能为空\n";
                            continue;
                        }

                        string s客户名称 = dtData.Rows[i]["cCusName"].ToString().Trim();
                        if (s客户名称 == "")
                        {
                            sErr = sErr + "客户名称不能为空\n";
                            continue;
                        }

                        string s客户大类编码 = dtData.Rows[i]["cCCCode"].ToString().Trim();
                        if (s客户大类编码 == "")
                        {
                            sErr = sErr + "客户大类编码不能为空\n";
                            continue;
                        }

                        string s客户大类名称 = dtData.Rows[i]["cCCName"].ToString().Trim();

                        sSQL = "select count(1) from aaa..CustomerClass where cCCCode = '" + s客户大类编码 + "' and isnull(bCCEnd,0) = 1";
                        sSQL = sSQL.Replace("aaa", 数据库);
                        int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou == 0)
                        {
                            sErr = sErr + "客户分类不存在\n";
                            continue;
                        }
                        sSQL = "select count(1) from aaa..Customer where cCusCode = '" + s客户编码 + "'";
                        sSQL = sSQL.Replace("aaa", 数据库);
                        iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou == 0)
                        {
                            sSQL = "insert into aaa..Customer(cCusCode,cCusName,cCusAbbName,cCCCode,dCusDevDate,iCusDisRate,iCusCreLine,iCusCreDate,cCusHeadCode,iARMoney,iLastMoney,iFrequency,iCostGrade,cCreatePerson,cModifyPerson,dModifyDate)" +
                                    "values('" + s客户编码 + "','" + s客户名称 + "','" + s客户名称 + "','" + s客户大类编码 + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',0,0,0,'" + s客户编码 + "',0,0,0,-1,'demo','demo','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";

                            sSQL = sSQL.Replace("aaa", 数据库);
                            iCount = iCount + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }


                    }

                    if (sErr.Trim().Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();

                    sReturn = sGetReturn(1, "OK：新增记录数：" + iCount.ToString());
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                sReturn = sGetReturn(0, ee.Message);
            }

            return sReturn;
        }

        /// <summary>
        /// 向T6中同步供应商档案
        /// </summary>
        /// <param name="sXML"></param>
        /// <returns></returns>
        [WebMethod]
        public string InsertVendor(string sXML)
        {
            string sReturn = "";
            int iCount = 0;
            try
            {
                string sErr = "";

                DataSet ds = ClsBaseClass.Cls序列化.ConvertXMLToDataSet(sXML);
                if (ds == null || ds.Tables.Count != 1)
                {
                    throw new Exception("解析XML失败");
                }

                DataTable dtData = ds.Tables[0];
                if (dtData.TableName.ToLower().Trim() != "vendor")
                    throw new Exception("档案类型错误");

                if (dtData == null || dtData.Rows.Count < 1)
                    throw new Exception("没有需要保存的数据");

                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select * from SystemDB_GDJ.dbo.帐套数据库对照表";
                    DataTable dt帐套 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        string s帐套 = dtData.Rows[i]["AccID"].ToString().Trim();
                        DataRow[] dr帐套 = dt帐套.Select("名称 = '" + s帐套 + "'");
                        if (dr帐套.Length != 1)
                            throw new Exception("帐套数据库对照表存在错误");

                        string 数据库 = dr帐套[0]["帐套数据库"].ToString().Trim();

                        string s供应商编码 = dtData.Rows[i]["cVenCode"].ToString().Trim();
                        if (s供应商编码 == "")
                        {
                            sErr = sErr + "供应商编码不能为空\n";
                            continue;
                        }

                        string s供应商名称 = dtData.Rows[i]["cVenName"].ToString().Trim();
                        if (s供应商名称 == "")
                        {
                            sErr = sErr + "供应商名称不能为空\n";
                            continue;
                        }

                        string s供应商大类编码 = dtData.Rows[i]["cVCCode"].ToString().Trim();
                        if (s供应商大类编码 == "")
                        {
                            sErr = sErr + "供应商大类编码不能为空\n";
                            continue;
                        }

                        string s供应商大类名称 = dtData.Rows[i]["cVCName"].ToString().Trim();

                        sSQL = "select count(1) from aaa..VendorClass where cVCCode = '" + s供应商大类编码 + "' and isnull(bVCEnd,0) = 1";
                        sSQL = sSQL.Replace("aaa", 数据库);
                        int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou == 0)
                        {
                            sErr = sErr + "供应商分类不存在\n";
                            continue;
                        }
                        sSQL = "select count(1) from aaa..Vendor where cVenCode = '" + s供应商编码 + "'";
                        sSQL = sSQL.Replace("aaa", 数据库);
                        iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou == 0)
                        {
                            sSQL = "insert into aaa..vendor(cVenCode,cVenName,cVenAbbName,cVCCode,dVenDevDate,cVenHeadCode)" +
                                    "values('" + s供应商编码 + "','" + s供应商名称 + "','" + s供应商名称 + "','" + s供应商大类编码 + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + s供应商编码 + "')";

                            sSQL = sSQL.Replace("aaa", 数据库);
                            iCount = iCount + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }


                    }

                    if (sErr.Trim().Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();

                    sReturn = sGetReturn(1, "OK：新增记录数：" + iCount.ToString());
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }

            }
            catch (Exception ee)
            {
                sReturn = sGetReturn(0, ee.Message);
            }

            return sReturn;
        }

        /// <summary>
        /// 向T6同步项目信息
        /// </summary>
        /// <param name="sXML"></param>
        /// <returns></returns>
        [WebMethod]
        public string InsertItem(string sXML)
        {
            string sReturn = "";
            int iCount = 0;
            try
            {
                string sErr = "";

                DataSet ds = ClsBaseClass.Cls序列化.ConvertXMLToDataSet(sXML);
                if (ds == null || ds.Tables.Count != 1)
                {
                    throw new Exception("解析XML失败");
                }

                DataTable dtData = ds.Tables[0];
                if (dtData.TableName.ToLower().Trim() != "fitemss")
                    throw new Exception("档案类型错误");


                if (dtData == null || dtData.Rows.Count < 1)
                    throw new Exception("没有需要保存的数据");

                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select * from SystemDB_GDJ.dbo.帐套数据库对照表";
                    DataTable dt帐套 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        string s帐套 = dtData.Rows[i]["AccID"].ToString().Trim();
                        DataRow[] dr帐套 = dt帐套.Select("名称 = '" + s帐套 + "'");
                        if (dr帐套.Length != 1)
                            throw new Exception("帐套数据库对照表存在错误");

                        string 数据库 = dr帐套[0]["帐套数据库"].ToString().Trim();

                        string s工程主键 = dtData.Rows[i]["GCID"].ToString().Trim();
                        if (s工程主键 == "")
                        {
                            sErr = sErr + "工程主键不能为空\n";
                            continue;
                        }

                        string s项目编码 = dtData.Rows[i]["citemcode"].ToString().Trim();
                        if (s项目编码 == "")
                        {
                            sErr = sErr + "项目编码不能为空\n";
                            continue;
                        }

                        string s项目名称 = dtData.Rows[i]["citemname"].ToString().Trim();
                        if (s项目名称 == "")
                        {
                            sErr = sErr + "项目名称不能为空\n";
                            continue;
                        }

                        string s项目大类编码 = dtData.Rows[i]["citemType"].ToString().Trim();
                        if (s项目大类编码 == "")
                        {
                            sErr = sErr + "项目大类编码不能为空\n";
                            continue;
                        }
                        //string s项目大类编码 = "9";
                        //if (s帐套 == "新吴城")
                        //{
                        //    s项目大类编码 = "09";
                        //}

                        //string s项目大类名称 = dtData.Rows[i]["cVCName"].ToString().Trim();

                        sSQL = "select count(1) from aaa..fitemss00class where cItemCcode = '" + s项目大类编码 + "' and isnull(bItemCend,0) = 1";
                        sSQL = sSQL.Replace("aaa", 数据库);
                        int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou == 0)
                        {
                            sErr = sErr + "项目分类不存在\n";
                            continue;
                        }

                        string s项目编号截断 = s项目编码;
                        if (s项目编号截断.Length > 5)
                        {
                            s项目编号截断 = s项目编号截断.Substring(5);
                        }

                        s项目编号截断 = CutStr(s项目编号截断, 20);

                        sSQL = "select count(1) from aaa..fitemss00 where (citemcode = '" + s项目编码 + "' or citemcode = '" + s项目编号截断 + "')";
                        sSQL = sSQL.Replace("aaa", 数据库);
                        iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou == 0)
                        {
                            sSQL = "insert into aaa..fitemss00(citemcode,citemname,bclose,citemccode,实施工程部,工程主键)" +
                                    "values('" + s项目编号截断 + "','" + s项目名称 + "',0,'" + s项目大类编码 + "','" + dtData.Rows[i]["DepName"].ToString().Trim() + "','" + s工程主键 + "')";

                            sSQL = sSQL.Replace("aaa", 数据库);
                            iCount = iCount + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                            sSQL = "insert into SystemDB_GDJ..项目帐套对照表(cItemCode,cItemName,工程主键,帐套)" +
                                    "values('" + s项目编号截断 + "','" + s项目名称 + "','" + s工程主键 + "','" + s帐套 + "')";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (sErr.Trim().Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();

                    sReturn = sGetReturn(1, "OK：新增记录数：" + iCount.ToString());
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }

            }
            catch (Exception ee)
            {
                sReturn = sGetReturn(0, ee.Message);
            }

            return sReturn;
        }

        public string CutStr(string sInString, int iCutLength)
        {
            if (sInString == null || sInString.Length == 0 || iCutLength <= 0) return "";
            int iCount = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(sInString);
            if (iCount > iCutLength)
            {
                int iLength = 0;
                for (int i = 0; i < sInString.Length; i++)
                {
                    int iCharLength = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(new char[] { sInString[i] });
                    iLength += iCharLength;
                    if (iLength == iCutLength)
                    {
                        sInString = sInString.Substring(0, i + 1);
                        break;
                    }
                    else if (iLength > iCutLength)
                    {
                        sInString = sInString.Substring(0, i);
                        break;
                    }
                }
            }
            return sInString;
        }
        
        /// <summary>
        /// 获得收款信息汇总
        /// </summary>
        /// <param name="sXML"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetApCloseBill_IN_All_Inner(string sDate)
        {
            string sReXML = "";
            try
            {
                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TmpGetApCloseBillAll]') AND type in (N'U'))
DROP TABLE [dbo].[TmpGetApCloseBillAll]
	
CREATE TABLE [dbo].[TmpGetApCloseBillAll](
	[项目] varchar(20) NULL,
	[收款] [money] NULL,
	[日期] [datetime] NULL,
	[工程主键] varchar(50) NOT NULL,
	[帐套] varchar(3) NOT NULL)

";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
select distinct a.cAcc_Id,p.iYear 
FROM UFSystem.dbo.UA_Account A 
	inner join UFSystem.dbo.UA_period P on A.cAcc_Id=P.cAcc_Id AND (P.bIsDelete=0 OR P.bIsDelete IS NULL) 
where (a.cAcc_Id = '038' or a.cAcc_Id = '310') and P.iyear >= 2014 and 1=1
";
                    if(sDate.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "P.iyear >= " + Convert.ToDateTime(sDate).Year.ToString().Trim());
                    }
                    DataTable dt帐套 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < dt帐套.Rows.Count; i++)
                    {
                        string sUFName = "UFDATA_" + dt帐套.Rows[i]["cAcc_Id"].ToString().Trim() + "_" + dt帐套.Rows[i]["iYear"].ToString().Trim();

                        sSQL = @"

insert into TmpGetApCloseBillAll 
select 项目,sum(收款) as 收款,max(制单日期) as 日期,工程主键,'22222222' as 帐套
from
(
	select a.*,b.cCusName as 客户名称
	from
	(
	SELECT cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) AS 凭证
		,ccode as 科目,ccus_id as 客户,citem_id as 项目
		,ISNULL(mc,0) - ISNULL(md,0) as 收款
		,cdigest as 摘要,dbill_date as 制单日期
	FROM 11111111..GL_accvouch
	WHERE cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) IN 
	(
		select cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) 
		from 11111111..GL_accvouch
		where 1=1
			and (ccode like '1131%' or ccode like '2131%')
	)
		and 
		cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) IN 
	(
		select cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) 
		from 11111111..GL_accvouch
		where 1=1
			and (ccode like '1001%' or ccode like '1002%')
	)
	)a inner join 11111111..Customer b on a.客户 = b.cCusCode
	where (科目 like '1131%' or 科目 like '2131%') and 2=2
)a inner join SystemDB_GDJ.dbo.项目帐套对照表 b on a.项目 = b.cItemCode
group by 项目,工程主键
";
                        sSQL = sSQL.Replace("2=2", " 制单日期 >= '" + sDate + "'");
                        sSQL = sSQL.Replace("11111111", sUFName);
                        sSQL = sSQL.Replace("22222222", dt帐套.Rows[i]["cAcc_Id"].ToString().Trim());

                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = @"
select 项目,sum(收款) as 收款,max(日期) as 日期,工程主键,帐套
from [TmpGetApCloseBillAll]
group by 项目,工程主键,帐套 
";
                    DataTable dt收款汇总 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    tran.Commit();

                    System.Text.StringBuilder sBuild = new System.Text.StringBuilder();
                    sBuild.Append("<?xml version='1.0' encoding='gb2312' standalone='yes'?>");
                    sBuild.Append("<NewDataSet>");
                    if (dt收款汇总 != null && dt收款汇总.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt收款汇总.Rows.Count; i++)
                        {
                            sBuild.Append("<Ap_CloseBill>");
                            sBuild.Append("<项目>" + dt收款汇总.Rows[i]["项目"].ToString().Trim() + "</项目>");
                            sBuild.Append("<收款>" + dt收款汇总.Rows[i]["收款"].ToString().Trim() + "</收款>");
                            sBuild.Append("<日期>" + dt收款汇总.Rows[i]["日期"].ToString().Trim() + "</日期>");
                            sBuild.Append("<工程主键>" + dt收款汇总.Rows[i]["工程主键"].ToString().Trim() + "</工程主键>");
                            sBuild.Append("<帐套>" + dt收款汇总.Rows[i]["帐套"].ToString().Trim() + "</帐套>");
                            sBuild.Append("</Ap_CloseBill>");
                        }
                    }

                    sBuild.Append("</NewDataSet>");
                    sReXML = sBuild.ToString().Trim();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                sReXML = sGetReturn(0, ee.Message);
            }

            return sReXML;
        }

        /// <summary>
        /// 获得收款信息汇总
        /// </summary>
        /// <param name="sXML"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetApCloseBill_IN_All_Left(string sDate)
        {
            string sReXML = "";
            try
            {
                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TmpGetApCloseBillAll]') AND type in (N'U'))
DROP TABLE [dbo].[TmpGetApCloseBillAll]
	
CREATE TABLE [dbo].[TmpGetApCloseBillAll](
	[项目] varchar(20) NULL,
	[收款] [money] NULL,
	[日期] [datetime] NULL,
	[工程主键] varchar(50) NULL,
	[帐套] varchar(3) NOT NULL)

";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
select distinct a.cAcc_Id,p.iYear 
FROM UFSystem.dbo.UA_Account A 
	inner join UFSystem.dbo.UA_period P on A.cAcc_Id=P.cAcc_Id AND (P.bIsDelete=0 OR P.bIsDelete IS NULL) 
where (a.cAcc_Id = '038' or a.cAcc_Id = '310') and P.iyear >= 2014 and 1=1
";
                    if (sDate.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "P.iyear >= " + Convert.ToDateTime(sDate).Year.ToString().Trim());
                    }
                    DataTable dt帐套 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < dt帐套.Rows.Count; i++)
                    {
                        string sUFName = "UFDATA_" + dt帐套.Rows[i]["cAcc_Id"].ToString().Trim() + "_" + dt帐套.Rows[i]["iYear"].ToString().Trim();

                        sSQL = @"

insert into TmpGetApCloseBillAll 
select 项目,sum(收款) as 收款,max(制单日期) as 日期,工程主键,'22222222' as 帐套
from
(
	select a.*,b.cCusName as 客户名称
	from
	(
	SELECT cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) AS 凭证
		,ccode as 科目,ccus_id as 客户,citem_id as 项目
		,ISNULL(mc,0) - ISNULL(md,0) as 收款
		,cdigest as 摘要,dbill_date as 制单日期
	FROM 11111111..GL_accvouch
	WHERE cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) IN 
	(
		select cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) 
		from 11111111..GL_accvouch
		where 1=1
			and (ccode like '1131%' or ccode like '2131%')
	)
		and 
		cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) IN 
	(
		select cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) 
		from 11111111..GL_accvouch
		where 1=1
			and (ccode like '1001%' or ccode like '1002%')
	)
	)a inner join 11111111..Customer b on a.客户 = b.cCusCode
	where (科目 like '1131%' or 科目 like '2131%') and 2=2
)a left join SystemDB_GDJ.dbo.项目帐套对照表 b on a.项目 = b.cItemCode
group by 项目,工程主键
";
                        sSQL = sSQL.Replace("2=2", " 制单日期 >= '" + sDate + "'");
                        sSQL = sSQL.Replace("11111111", sUFName);
                        sSQL = sSQL.Replace("22222222", dt帐套.Rows[i]["cAcc_Id"].ToString().Trim());

                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = @"
select 项目,sum(收款) as 收款,max(日期) as 日期,工程主键,帐套
from [TmpGetApCloseBillAll]
group by 项目,工程主键,帐套 
";
                    DataTable dt收款汇总 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    tran.Commit();

                    System.Text.StringBuilder sBuild = new System.Text.StringBuilder();
                    sBuild.Append("<?xml version='1.0' encoding='gb2312' standalone='yes'?>");
                    sBuild.Append("<NewDataSet>");
                    if (dt收款汇总 != null && dt收款汇总.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt收款汇总.Rows.Count; i++)
                        {
                            sBuild.Append("<Ap_CloseBill>");
                            sBuild.Append("<项目>" + dt收款汇总.Rows[i]["项目"].ToString().Trim() + "</项目>");
                            sBuild.Append("<收款>" + dt收款汇总.Rows[i]["收款"].ToString().Trim() + "</收款>");
                            sBuild.Append("<日期>" + dt收款汇总.Rows[i]["日期"].ToString().Trim() + "</日期>");
                            sBuild.Append("<工程主键>" + dt收款汇总.Rows[i]["工程主键"].ToString().Trim() + "</工程主键>");
                            sBuild.Append("<帐套>" + dt收款汇总.Rows[i]["帐套"].ToString().Trim() + "</帐套>");
                            sBuild.Append("</Ap_CloseBill>");
                        }
                    }

                    sBuild.Append("</NewDataSet>");
                    sReXML = sBuild.ToString().Trim();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                sReXML = sGetReturn(0, ee.Message);
            }

            return sReXML;
        }

        /// <summary>
        /// 获得收款信息
        /// </summary>
        /// <param name="sXML"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetApCloseBill_IN(string sXML)
        {
            string sReXML = "";
            System.Text.StringBuilder sBuild = new System.Text.StringBuilder();
            try
            {
                DataSet ds = ClsBaseClass.Cls序列化.ConvertXMLToDataSet(sXML);

                string sSQL = "";
                string s项目号 = "";
                string s帐套 = "";
                if (ds != null && ds.Tables.Count == 1 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    string s工程主键 = ds.Tables[0].Rows[0]["GCID"].ToString().Trim();

                    sSQL = "select * from SystemDB_GDJ.dbo.项目帐套对照表 where 工程主键 = '" + s工程主键 + "'";
                    DataTable dtTemp = SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        s项目号 = dtTemp.Rows[0]["cItemCode"].ToString().Trim();
                        s帐套 = dtTemp.Rows[0]["帐套"].ToString().Trim();
                    }
                }

                if (s项目号 == "" || s帐套 == "")
                {
                    throw new Exception("通过工程主键识别项目或帐套失败");
                }

                sSQL = "select * from SystemDB_GDJ.dbo.帐套数据库对照表";
                DataTable dt帐套 = SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];

                DataRow[] dr帐套 = dt帐套.Select("名称 = '" + s帐套 + "'");
                if (dr帐套.Length != 1)
                    throw new Exception("帐套数据库对照表存在错误");

                string 数据库 = dr帐套[0]["帐套数据库"].ToString().Trim();

                sSQL = @"
select a.*,b.cCusName as 客户名称
from
(
SELECT cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) AS 凭证
	,ccode as 科目,ccus_id as 客户,citem_id as 项目
	,ISNULL(mc,0) - ISNULL(md,0) as 收款
	,cdigest as 摘要,dbill_date as 制单日期
FROM @u8..GL_accvouch
WHERE cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) IN 
(
	select cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) 
	from @u8..GL_accvouch
	where 1=1
		and (ccode like '1131%' or ccode like '2131%')
)
	and 
	cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) IN 
(
	select cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) 
	from @u8..GL_accvouch
	where 1=1
		and (ccode like '1001%' or ccode like '1002%')
)
)a inner join @u8..Customer b on a.客户 = b.cCusCode
where (科目 like '1131%' or 科目 like '2131%')
    and 项目 = '111111'
order by 凭证
";
                sSQL = sSQL.Replace("@u8", 数据库);
                sSQL = sSQL.Replace("111111", s项目号);

                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];

                sBuild.Append("<?xml version='1.0' encoding='gb2312' standalone='yes'?>");
                sBuild.Append("<NewDataSet>");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sBuild.Append("<Ap_CloseBill>");
                        sBuild.Append("<AccID>" + s帐套 + "</AccID>");
                        sBuild.Append("<ddbill_date>" + dt.Rows[i]["制单日期"].ToString().Trim() + "</ddbill_date>");
                        sBuild.Append("<cdigest>" + dt.Rows[i]["摘要"].ToString().Trim() + "</cdigest>");
                        sBuild.Append("<dMoney>" + dt.Rows[i]["收款"].ToString().Trim() + "</dMoney>");
                        sBuild.Append("<cCusCode>" + dt.Rows[i]["客户"].ToString().Trim() + "</cCusCode>");
                        sBuild.Append("<cCusName>" + dt.Rows[i]["客户名称"].ToString().Trim() + "</cCusName>");
                        sBuild.Append("</Ap_CloseBill>");
                    }
                }

                sBuild.Append("</NewDataSet>");
                sReXML = sBuild.ToString().Trim();
            }
            catch (Exception ee)
            {
                sReXML = sGetReturn(0, ee.Message);
            }

            return sReXML;
        }



        /// <summary>
        /// 获得付款信息
        /// </summary>
        /// <param name="sXML"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetApCloseBill_OUT(string sXML)
        {
            string sReXML = "";
            System.Text.StringBuilder sBuild = new System.Text.StringBuilder();
            try
            {
                DataSet ds = ClsBaseClass.Cls序列化.ConvertXMLToDataSet(sXML);

                string sSQL = "";
                string s项目号 = "";
                string s帐套 = "";
                if (ds != null && ds.Tables.Count == 1 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    string s工程主键 = ds.Tables[0].Rows[0]["GCID"].ToString().Trim();

                    sSQL = "select * from SystemDB_GDJ.dbo.项目帐套对照表 where 工程主键 = '" + s工程主键 + "'";
                    DataTable dtTemp = SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        s项目号 = dtTemp.Rows[0]["cItemCode"].ToString().Trim();
                        s帐套 = dtTemp.Rows[0]["帐套"].ToString().Trim();
                    }
                }

                if (s项目号 == "" || s帐套 == "")
                {
                    throw new Exception("通过工程主键识别项目或帐套失败");
                }

                sSQL = "select * from SystemDB_GDJ.dbo.帐套数据库对照表";
                DataTable dt帐套 = SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];

                DataRow[] dr帐套 = dt帐套.Select("名称 = '" + s帐套 + "'");
                if (dr帐套.Length != 1)
                    throw new Exception("帐套数据库对照表存在错误");

                string 数据库 = dr帐套[0]["帐套数据库"].ToString().Trim();

                sSQL = @"
select a.*,b.cVenName as 供应商名称
from
(
SELECT cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) AS 凭证
	,ccode as 科目,csup_id as 供应商,citem_id as 项目
	,ISNULL(md,0) -ISNULL(mc,0) as 金额
	,cdigest as 摘要,dbill_date as 制单日期
FROM @u8..GL_accvouch
WHERE cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) IN 
(
	select cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) 
	from @u8..GL_accvouch
	where 1=1
		and (ccode like '2121%' or ccode like '1151%')
)
	and 
	cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) IN 
(
	select cast(isnull(iperiod,0) as varchar(2)) + isnull(csign,'')  +  right('0000' + cast(ino_id as varchar(4)),4) 
	from @u8..GL_accvouch
	where 1=1
		and (ccode like '1001%' or ccode like '1002%')
)
)a inner join @u8..Vendor b on a.供应商 = b.cVenCode
where (科目 like '2121%' or 科目 like '1151%')
    and 项目 = '111111'
order by 凭证
";
                sSQL = sSQL.Replace("@u8", 数据库);
                sSQL = sSQL.Replace("111111", s项目号);

                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];

                sBuild.Append("<?xml version='1.0' encoding='gb2312' standalone='yes'?>");
                sBuild.Append("<NewDataSet>");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sBuild.Append("<Ap_CloseBill>");
                        sBuild.Append("<AccID>" + s帐套 + "</AccID>");
                        sBuild.Append("<ddbill_date>" + dt.Rows[i]["制单日期"].ToString().Trim() + "</ddbill_date>");
                        sBuild.Append("<cdigest>" + dt.Rows[i]["摘要"].ToString().Trim() + "</cdigest>");
                        sBuild.Append("<dMoney>" + dt.Rows[i]["金额"].ToString().Trim() + "</dMoney>");
                        sBuild.Append("<cVCCode>" + dt.Rows[i]["供应商"].ToString().Trim() + "</cVCCode>");
                        sBuild.Append("<cVCName>" + dt.Rows[i]["供应商名称"].ToString().Trim() + "</cVCName>");
                        sBuild.Append("</Ap_CloseBill>");
                    }
                }

                sBuild.Append("</NewDataSet>");
                sReXML = sBuild.ToString().Trim();
            }
            catch (Exception ee)
            {
                sReXML = sGetReturn(0, ee.Message);
            }

            return sReXML;
        }

        /// <summary>
        /// 获得工程成本信息
        /// </summary>
        /// <param name="sXML"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetProCost(string sXML)
        {
            string sReXML = "";
            System.Text.StringBuilder sBuild = new System.Text.StringBuilder();
            try
            {
                DataSet ds = ClsBaseClass.Cls序列化.ConvertXMLToDataSet(sXML);

                string sSQL = "";
                string s项目号 = "";
                string s帐套 = "";
                string s工程主键 = "";
                if (ds != null && ds.Tables.Count == 1 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    s工程主键 = ds.Tables[0].Rows[0]["GCID"].ToString().Trim();

                    sSQL = "select * from SystemDB_GDJ.dbo.项目帐套对照表 where 工程主键 = '" + s工程主键 + "'";
                    DataTable dtTemp = SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        s项目号 = dtTemp.Rows[0]["cItemCode"].ToString().Trim();
                        s帐套 = dtTemp.Rows[0]["帐套"].ToString().Trim();
                    }
                }

                if (s项目号 == "" || s帐套 == "")
                {
                    throw new Exception("通过工程主键识别项目或帐套失败");
                }

                sSQL = "select * from SystemDB_GDJ.dbo.帐套数据库对照表";
                DataTable dt帐套 = SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];

                DataRow[] dr帐套 = dt帐套.Select("名称 = '" + s帐套 + "'");
                if (dr帐套.Length != 1)
                    throw new Exception("帐套数据库对照表存在错误");

                string 数据库 = dr帐套[0]["帐套数据库"].ToString().Trim();

                sSQL = @"
SELECT a.citem_id as 项目
	,sum(case when a.ccode = '410402' then iSNULL(md,0) end) as 设备 
	,sum(case when a.ccode = '410403' then ISNULL(md,0) end) as 材料
	,sum(case when a.ccode = '410404' then ISNULL(md,0) end) as 费用
	,sum(case when a.ccode = '410405' then ISNULL(md,0) end) as 外包工程款
FROM @u8..GL_accvouch a 
where (ccode = '410402' or ccode = '410403' or ccode = '410404' or ccode = '410405')
	and a.citem_id = '111111' 
group by a.citem_id
";
                sSQL = sSQL.Replace("@u8", 数据库);
                sSQL = sSQL.Replace("111111", s项目号);

                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];

                sBuild.Append("<?xml version='1.0' encoding='gb2312' standalone='yes'?>");
                sBuild.Append("<NewDataSet>");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sBuild.Append("<ProCost>");
                        sBuild.Append("<AccID>" + s帐套 + "</AccID>");
                        sBuild.Append("<GCID>" + s工程主键 + "</GCID>");
                        sBuild.Append("<equipment>" + ReturnDecimal(dt.Rows[i]["设备"]).ToString().Trim() + "</equipment>");
                        sBuild.Append("<material>" + ReturnDecimal(dt.Rows[i]["材料"]).ToString().Trim() + "</material>");
                        sBuild.Append("<cost>" + ReturnDecimal(dt.Rows[i]["费用"]).ToString().Trim() + "</cost>");
                        sBuild.Append("<Outsourcing>" + ReturnDecimal(dt.Rows[i]["外包工程款"]).ToString().Trim() + "</Outsourcing>");
                        sBuild.Append("</ProCost>");
                    }
                }

                sBuild.Append("</NewDataSet>");
                sReXML = sBuild.ToString().Trim();
            }
            catch (Exception ee)
            {
                sReXML = sGetReturn(0, ee.Message);
            }
            
            return sReXML;
        }

        private decimal ReturnDecimal(object o)
        {
            decimal d = 0;
            try
            {
                d = Convert.ToDecimal(o);
            }
            catch { }
            return d;
        }


        private string sGetReturn(int i, string sRet)
        {
            string S = @"<?xml version='1.0' encoding='gb2312' standalone='yes'?>
<NewDataSet>
  <ReturnString>
    <Success>111111</Success>
    <sReturn>222222</sReturn>
  </ProjectList>
</NewDataSet>
";
            S = S.Replace("111111", i.ToString());
            S = S.Replace("222222", sRet);

            return S;
        }
    }
}
