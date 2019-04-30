using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class ClsProject
    {
        string tablename = "Project";
        string tablenameRecord = "ProjectRecord";
        string tablenameQuality = "ProjectQuality";
        string tablenameSecurity = "ProjectSecurity";
        string tablenameProgress = "ProjectProgress";
        string tablenameAtt = "ProjectAtt";
        string tableid = "iID";
        string Code = "cCode";
        string Name = "cName";
        string CodeTitle = "工程编码";
        string NameTitle = "工程名称";
        string sSQL = "";
        protected ClsGetSQL clsGetSQL = ClsGetSQL.Instance();
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();

        private string dtName(int type)
        {
            string s = "";
            switch (type)
            {
                case 0:
                    s = "表头";
                    break;
                case 1:
                    s = "材料登记";
                    break;
                case 4:
                    s = "工程质量登记";
                    break;
                case 5:
                    s = "安全登记";
                    break;
                case 6:
                    s = "供电公司工程进度";
                    break;
                case 7:
                    s = "供电公司工程进度2";
                    break;
                case 8:
                    s = "附件";
                    break;
                case 9:
                    s = "用户工程进度";
                    break;
            }
            return s;
        }


        public string dtList(string sWhere, string cPCCode)
        {
            string s = "";
            try
            {
                string sSQL2 = "";
                if (cPCCode == "1")
                {
                    sSQL2 = @"
,max(case when PID='200' then b.dDate end)  ProgressdDate200
,max(case when PID='205' then b.dDate end)  ProgressdDate205
,max(case when PID='210' then b.dDate end)  ProgressdDate210
,max(case when PID='215' then b.dDate end)  ProgressdDate215
,max(case when PID='220' then b.dDate end)  ProgressdDate220
,max(case when PID='225' then b.dDate end)  ProgressdDate225
,max(case when PID='230' then b.dDate end)  ProgressdDate230
";
                }
                else if (cPCCode == "2")
                {
                    sSQL2 = @"
,max(case when PID='100' then b.dDate end)  ProgressdDate100
,max(case when PID='105' then b.dDate end)  ProgressdDate105
,max(case when PID='110' then b.dDate end)  ProgressdDate110
,max(case when PID='115' then b.dDate end)  ProgressdDate115
,max(case when PID='120' then b.dDate end)  ProgressdDate120
,max(case when PID='125' then b.dDate end)  ProgressdDate125
,max(case when PID='130' then b.dDate end)  ProgressdDate130
,max(case when PID='135' then b.dDate end)  ProgressdDate135
,max(case when PID='140' then b.dDate end)  ProgressdDate140

,max(case when PID='1' then b.dDate end)  ProgressdDate1
,max(case when PID='5' then b.dDate end)  ProgressdDate5
,max(case when PID='10' then b.dDate end)  ProgressdDate10
,max(case when PID='15' then b.dDate end)  ProgressdDate15
,max(case when PID='20' then b.dDate end)  ProgressdDate20
,max(case when PID='25' then b.dDate end)  ProgressdDate25
,max(case when PID='30' then b.dDate end)  ProgressdDate30
,max(case when PID='35' then b.dDate end)  ProgressdDate35
,max(case when PID='40' then b.dDate end)  ProgressdDate40
,max(case when PID='45' then b.dDate end)  ProgressdDate45
,max(case when PID='50' then b.dDate end)  ProgressdDate50
,max(case when PID='55' then b.dDate end)  ProgressdDate55
,max(case when PID='60' then b.dDate end)  ProgressdDate60
,max(case when PID='65' then b.dDate end)  ProgressdDate65
,max(case when PID='70' then b.dDate end)  ProgressdDate70
,max(case when PID='75' then b.dDate end)  ProgressdDate75
,max(case when PID='80' then b.dDate end)  ProgressdDate80
,max(case when PID='85' then b.dDate end)  ProgressdDate85
,max(case when PID='90' then b.dDate end)  ProgressdDate90";
                }
                sSQL = @"select a.iID 111111 into #a 
from Project a left join ProjectProgress b on a.iID=b.iID where 1=1 group by a.iID


select a.iID, cCode, cName, a.cECode, a.cDCCode, a.cPCCode, LineName, Progress, Quantities, InvoiceState, IsInvoice, IsInvoicePer, IsInvoiceTime, EndState, convert(varchar(10),dDate,120) as dDate,
                      iQuantity, IsCheck, CheckPerson, CheckTime, CheckRemark, Remark, dCreatePerson, dCreateTime, dModifyPerson, dModifyTime, dVerifyPerson, dVerifyTime, 
                      dVerifyPerson1, dVerifyTime1, SysCreateDate, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, D1, D2, D3, D4, D5, D6, D7, D8, D9
,convert(varchar(10),Date1,120) as Date1,convert(varchar(10),Date2,120) as Date2,convert(varchar(10),Date3,120) as Date3,convert(varchar(10),Date4,120) as Date4,convert(varchar(10),Date5,120) as Date5
,convert(varchar(10),Date6,120) as Date6,convert(varchar(10),Date7,120) as Date7,convert(varchar(10),Date8,120) as Date8,convert(varchar(10),Date9,120) as Date9,convert(varchar(10),Date10,120) as Date10

,case when convert(varchar(10),Date1,120) is not null and convert(varchar(10),sDate2,120) is not null and convert(varchar(10),Date1,120)<convert(varchar(10),sDate2,120) then '延期'
when convert(varchar(10),Date1,120) is not null and convert(varchar(10),sDate2,120) is null and convert(varchar(10),Date1,120)<convert(varchar(10),getdate(),120) then '延期' end 决算资料提交是否延期

,case when convert(varchar(10),Date3,120) is not null and convert(varchar(10),sDate4,120) is not null and convert(varchar(10),Date3,120)<convert(varchar(10),sDate4,120) then '延期'
when convert(varchar(10),Date3,120) is not null and convert(varchar(10),sDate4,120) is null and convert(varchar(10),Date3,120)<convert(varchar(10),getdate(),120) then '延期' end 竣工资料上报是否延期

,case when convert(varchar(10),Date5,120) is not null and convert(varchar(10),sDate6,120) is not null and convert(varchar(10),Date5,120)<convert(varchar(10),sDate6,120) then '延期'
when convert(varchar(10),Date5,120) is not null and convert(varchar(10),sDate6,120) is null and convert(varchar(10),Date5,120)<convert(varchar(10),getdate(),120) then '延期'  end 竣工是否延期

,'edit' as iSave,e.cEName,(select top 1 d.iText from ProjectProgress c left join ProjectProgressClass d on c.PID=d.PID where iID=a.iID order by dDate desc)  as 进度,convert(bit,0) as iChk  
from Project a left join (select cECode,cEName from Engineering) e on a.cECode=e.cECode 
left join (select iID,dDate as sDate2 from ProjectProgress where PID in (45,230)) s1 on a.iID=s1.iID 
left join (select iID,dDate as sDate4 from ProjectProgress where PID in (65,225)) s2 on a.iID=s2.iID 
left join (select iID,dDate as sDate6 from ProjectProgress where PID in (80,235)) s3 on a.iID=s3.iID 
left join #a as p on a.iID=p.iID 

where 1=1 ";
                sSQL = sSQL.Replace("111111", sSQL2);
                if (sWhere != "")
                {
                    sSQL = sSQL + sWhere;
                }
                if (cPCCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cPCCode = '" + cPCCode + "'");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (cPCCode != "")
                {
                    string sSQL3 = " where cPCCode=" + cPCCode;
                    if (cPCCode == "2")
                    {
                        sSQL3 = " where cPCCode in(2,3)";
                    }

                    DataTable dttitle = clsSQLCommond.ExecQuery("select * from ProjectProgressClass  " + sSQL3);
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (dt.Columns[i].ColumnName.IndexOf("ProgressdDate") >= 0)
                        {
                            DataRow[] dw = dttitle.Select("PID='" + dt.Columns[i].ColumnName.Replace("ProgressdDate", "") + "'");
                            if (dw.Length > 0)
                            {
                                dt.Columns[i].ColumnName = "ProgressdDate_" + dw[0]["cPCCode"] + "_" + dw[0]["iText"];
                            }
                        }
                    }
                }
                dt.TableName = dtName(0);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt(int type,string iID)
        {
            string s = "";

            try
            {
                switch (type)
                {
                    case 0:
                        sSQL = @"select *, 'edit' as iSave,'' as sState,e.cEName,(select top 1 d.iText from ProjectProgress c left join ProjectProgressClass d on c.PID=d.PID where iID=a.iID order by dDate desc)  as 进度,convert(bit,0) as iChk  
                        from " + tablename + " a left join (select cECode,cEName from Engineering) e on a.cECode=e.cECode where a.iID='" + iID + "'";
                        break;
                    case 1:
                        sSQL = @"select a.cInvCode,b.AutoID, b.iID, b.dDate,  b.BQty, b.InQty,  d.RQty,b.cRsCode,c.OutQty,
case when isnull(b.InQty,0)-isnull(c.OutQty,0)+isnull(d.RQty,0)<>0 then isnull(b.InQty,0)-isnull(c.OutQty,0)+isnull(d.RQty,0) end as EndQty,  b.Remark, b.dCreatePerson, b.dCreateTime, b.dModifyPerson, b.dModifyTime, b.SysCreateDate
,case when b.iID is not null then 'edit' else '' end iSave from Inventory a 
left join (select * from " + tablenameRecord + " where iID='" + iID + "') b on a.cInvCode=b.cInvCode "+
" left join (select b.cInvCode,sum(b.iQuantity) as OutQty from RdRecord a left join RdRecords b on a.iID=b.iID left join Project p on a.PCode=p.cCode where p.iID='" + iID + "' and cRSCode='11' and isnull(a.dVerifyPerson,'')<>'' group by b.cInvCode) c on a.cInvCode=c.cInvCode" +
" left join (select b.cInvCode,sum(b.iQuantity) as RQty from RdRecord a left join RdRecords b on a.iID=b.iID left join Project p on a.PCode=p.cCode where p.iID='" + iID + "' and cRSCode='02'  and isnull(a.dVerifyPerson,'')<>'' group by b.cInvCode) d on a.cInvCode=d.cInvCode";
                        break;
                    case 4:
                        sSQL = "select *, 'edit' as iSave from " + tablenameQuality + " where iID='" + iID + "'";
                        break;
                    case 5:
                        sSQL = @"select a.cSCode,b.AutoID, b.iID, b.cSCode, b.dDate, b.PersonCode,  b.Remark, b.dCreatePerson, b.dCreateTime, b.dModifyPerson, b.dModifyTime, b.SysCreateDate
,b.PersonCaptain,b.PersonCaptainDept,b.PersonCheck,b.PersonAssign,b.PersonViolation,a.Score,b.iScore,b.iCount,0 as 增加扣分,0 as 减少扣分
,case when b.iID is not null then 'edit' else '' end iSave from Security a left join 
(select * from " + tablenameSecurity + " where iID='" + iID + "') b on a.cSCode=b.cSCode";
                        break;
                    case 6:
                        sSQL = @"select a.*,AutoID,b.iID,dDate, b.PersonCode,p.vchrName as PersonName,convert(nvarchar(50),null) as Checked, 'edit' as iSave from ProjectProgressClass a 
left join (select * from ProjectProgress where iID='" + iID + "') b on a.cPCCode=b.cPCCode and a.PID=b.PID left join _UserInfo p on b.PersonCode=p.vchrUid ";
                        break;
                    case 8:
                        sSQL = "select *,'点击上传' as AttBtn, 'edit' as iSave from " + tablenameAtt + " where iID='" + iID + "'";
                        break;
                }
                
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                dt.TableName = dtName(type);
                
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dtnew(int type)
        {
            string s = "";

            try
            {
                switch (type)
                {
                    case 0:
                        sSQL = "select *, 'edit' as iSave,'' as sState from " + tablename + " where 1=-1";
                        break;
                    case 1:
                        sSQL = @"select a.cInvCode,b.AutoID, b.iID,b.dDate,   b.BQty, b.RQty,b.InQty, b.cRsCode, b.OutQty, b.EndQty,  b.Remark, b.dCreatePerson, b.dCreateTime, b.dModifyPerson, b.dModifyTime, b.SysCreateDate
,case when b.iID is not null then 'edit' else '' end iSave from Inventory a left join 
(select * from " + tablenameRecord + " where 1=-1) b on a.cInvCode=b.cInvCode";
                        break;
                    case 4:
                        sSQL = "select *, 'edit' as iSave from " + tablenameQuality + " where 1=-1";
                        break;
                    case 5:
                        sSQL = @"select a.cSCode,b.AutoID, b.iID, b.cSCode, b.dDate, b.PersonCode,  b.Remark, b.dCreatePerson, b.dCreateTime, b.dModifyPerson, b.dModifyTime, b.SysCreateDate
,b.PersonCaptain,b.PersonCaptainDept,b.PersonCheck,b.PersonAssign,b.PersonViolation,a.Score,b.iScore,b.iCount,0 as 增加扣分,0 as 减少扣分
,case when b.iID is not null then 'edit' else '' end iSave from Security a left join 
(select * from " + tablenameSecurity + " where 1=-1) b on a.cSCode=b.cSCode";
                        break;
                    case 6:
                        sSQL = @"select *,convert(int,null) as AutoID,convert(int,null) as iID,convert(datetime,null) as dDate,convert(nvarchar(50),null) as PersonCode,convert(nvarchar(50),null) as PersonName,convert(nvarchar(50),null) as Checked, 'edit' as iSave from ProjectProgressClass  where cPCCode=1";
                        break;
                    case 7:
                        sSQL = @"select *,convert(int,null) as AutoID,convert(int,null) as iID,convert(datetime,null) as dDate,convert(nvarchar(50),null) as PersonCode,convert(nvarchar(50),null) as PersonName,convert(nvarchar(50),null) as Checked, 'edit' as iSave from ProjectProgressClass  where cPCCode=2";
                        break;
                    case 8:
                        sSQL = "select *, 'edit' as iSave from " + tablenameAtt + " where 1=-1";
                        break;
                    case 9:
                        sSQL = @"select *,convert(int,null) as AutoID,convert(int,null) as iID,convert(datetime,null) as dDate,convert(nvarchar(50),null) as PersonCode,convert(nvarchar(50),null) as PersonName,convert(nvarchar(50),null) as Checked, 'edit' as iSave from ProjectProgressClass  where cPCCode=3";
                        break;
                }
                
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                dt.TableName = dtName(type);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string siID(int type, string iID)
        {
            string s = "";

            try
            {
                if (type == 1)
                {
                    sSQL = "select min(" + tableid + ") as iID from " + tablename + " where 1=1 ";
                }
                else if (type == 2)
                {
                    sSQL = "select " + tableid + " from " + tablename + " where " + tableid + "<'" + iID + "' order by " + tableid + " desc";
                }
                else if (type == 3)
                {
                    sSQL = "select " + tableid + " from " + tablename + " where " + tableid + ">'" + iID + "'  order by " + tableid + " ";
                }
                else if (type == 4)
                {
                    sSQL = "select max(" + tableid + ") as iID from " + tablename + " where 1=1 ";
                }
                s = clsSQLCommond.ExecGetScalar(sSQL).ToString();
            }
            catch (Exception ee)
            {
                s = "-1";
            }
            return s;
        }

        public string save(string uid, DataTable dtHead, DataTable dtGridRecord, DataTable dtGridQuality, DataTable dtGridSecurity, DataTable dtGridAtt
            , string delRecord, string delQuality, string delSecurity, string delAtt)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                long iID;
                #region 生成表头
                sSQL = "select * from " + tablename + " where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                string  chk="";

                sSQL = "select count(*) from Project where cCode='" + dtHead.Rows[0][Code] + "'";
                if (dtHead.Rows[0]["iID"].ToString().Trim() != "")
                {
                    sSQL = sSQL + " and iID<>'" + dtHead.Rows[0]["iID"] + "'";
                }
                int r = Convert.ToInt16(clsSQLCommond.ExecGetScalar(sSQL));
                if (r > 0)
                {
                    throw new Exception("工程编号重复");
                }

                DataRow dr = dtHead.NewRow();
                if (dtHead.Rows[0]["iID"].ToString().Trim() != "")
                {
                    dr["iID"] = dtHead.Rows[0]["iID"];
                    iID =long.Parse(dtHead.Rows[0]["iID"].ToString());
                    dr["dModifyTime"] = DateTime.Now.ToString();
                    dr["dModifyPerson"] = uid;
                    dr["dCreateTime"] = dtHead.Rows[0]["dCreateTime"].ToString().Trim();
                    dr["dCreatePerson"] = dtHead.Rows[0]["dCreatePerson"].ToString().Trim();
                    sSQL = "select IsCheck from " + tablename + " where iID='" + dtHead.Rows[0]["iID"] + "'";
                    if (clsSQLCommond.ExecGetScalar(sSQL) != null)
                    {
                        chk = clsSQLCommond.ExecGetScalar(sSQL).ToString();
                    }
                }
                else
                {
                    
                    sSQL = "select isnull(max(iID)+1,1) as iID from " + tablename;
                    iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                    dr["iID"] = iID;
                    dr["dCreateTime"] = DateTime.Now.ToString();
                    dr["dCreatePerson"] = uid;
                    string sState = dtHead.Rows[0]["sState"].ToString().Trim();
                    int iRe = CheState(iID.ToString());
                    if (iRe == -1)
                    {
                        throw new Exception("检查单据状态出错");
                    }
                    if (iRe == 0 && (sState == "edit" || sState == "alter"))
                    {
                        throw new Exception("单据不存在");
                    }
                    if (iRe == 1 && sState == "alter")
                    {
                        throw new Exception("单据未审核");
                    }
                    if (iRe == 2 && sState == "edit")
                    {
                        throw new Exception("单据已审核");
                    }
                    //if (iRe == 3)
                    //{
                    //    throw new Exception("单据已关闭");
                    //}
                }
                dr[Code] = dtHead.Rows[0][Code];
                dr[Name] = dtHead.Rows[0][Name];
                dr["InvoiceState"] = dtHead.Rows[0]["InvoiceState"];
                dr["LineName"] = dtHead.Rows[0]["LineName"];

                dr["cDCCode"] = dtHead.Rows[0]["cDCCode"];
                dr["Progress"] = dtHead.Rows[0]["Progress"];
                dr["cECode"] = dtHead.Rows[0]["cECode"];
                dr["cPCCode"] = dtHead.Rows[0]["cPCCode"];
                dr["iQuantity"] = dtHead.Rows[0]["iQuantity"];
                dr["EndState"] = dtHead.Rows[0]["EndState"];
                dr["IsInvoice"] = dtHead.Rows[0]["IsInvoice"];

                dr["dDate"] = dtHead.Rows[0]["dDate"];
                dr["Date1"] = dtHead.Rows[0]["Date1"];
                dr["Date2"] = dtHead.Rows[0]["Date2"];
                dr["Date3"] = dtHead.Rows[0]["Date3"];
                dr["Date4"] = dtHead.Rows[0]["Date4"];
                dr["Date5"] = dtHead.Rows[0]["Date5"];
                dr["Date6"] = dtHead.Rows[0]["Date6"];

                dr["IsCheck"] = dtHead.Rows[0]["IsCheck"];

                sSQL = "select * from " + tablename + " where iID='" + iID + "'";
                DataTable dtinv = clsSQLCommond.ExecQuery(sSQL);
                if (dtinv.Rows.Count > 0)
                {
                    if (dtHead.Rows[0]["cPCCode"].ToString() == "1")
                    {
                        dr["IsInvoice"] = dtinv.Rows[0]["IsInvoice"];
                        dr["IsInvoicePer"] = dtinv.Rows[0]["IsInvoicePer"];
                        dr["IsInvoiceTime"] = dtinv.Rows[0]["IsInvoiceTime"];
                    }
                    else
                    {
                        if (dtHead.Rows[0]["IsInvoice"].ToString() == "True" && (dtinv.Rows[0]["IsInvoice"].ToString() == "False" || dtinv.Rows[0]["IsInvoice"].ToString() == ""))
                        {
                            dr["IsInvoicePer"] = uid;
                            dr["IsInvoiceTime"] = DateTime.Now.ToString();
                        }
                        else if (dtHead.Rows[0]["IsInvoice"].ToString() == "True" && dtinv.Rows[0]["IsInvoice"].ToString() == "True")
                        {
                            dr["IsInvoicePer"] = dtinv.Rows[0]["IsInvoicePer"];
                            dr["IsInvoiceTime"] = dtinv.Rows[0]["IsInvoiceTime"];
                        }
                        else if (dtHead.Rows[0]["IsInvoice"].ToString() == "False")
                        {
                        }
                    }
                }
                else
                {
                    if (dtHead.Rows[0]["IsInvoice"].ToString() == "True")
                    {
                        dr["IsInvoicePer"] = uid;
                        dr["IsInvoiceTime"] = DateTime.Now.ToString();
                    }
                }

                if (dtHead.Rows[0]["IsCheck"].ToString() != "" && (dtHead.Rows[0]["CheckTime"].ToString().Trim() == "" || dtHead.Rows[0]["IsCheck"].ToString() != chk))
                {
                    dr["CheckTime"] = DateTime.Now.ToString();
                    dr["CheckPerson"] = uid;
                }
                else
                {
                    dr["CheckTime"] = dtHead.Rows[0]["CheckTime"];
                    dr["CheckPerson"] = dtHead.Rows[0]["CheckPerson"];
                }
                dr["CheckRemark"] = dtHead.Rows[0]["CheckRemark"];


                dr["Remark"] = dtHead.Rows[0]["Remark"];

                dtHead.Rows.Add(dr);
                if (dtHead.Rows[0]["iSave"].ToString().Trim() == "update")
                {
                    sSQL = clsGetSQL.GetUpdateSQL(ClsBaseDataInfo.sDataBaseName, tablename, dtHead, dtHead.Rows.Count - 1);
                    aList.Add(sSQL);
                }
                if (dtHead.Rows[0]["iSave"].ToString().Trim() == "add")
                {
                    sSQL = clsGetSQL.GetInsertSQL(ClsBaseDataInfo.sDataBaseName, tablename, dtHead, dtHead.Rows.Count - 1);
                    aList.Add(sSQL);
                }
                
                #endregion

                #region dtGridRecord
                string[] strdelRecord = delRecord.Trim().Split(',');
                for (int i = 0; i < strdelRecord.Length; i++)
                {
                    if (strdelRecord[i].Trim() != "")
                    {
                        sSQL = "delete  from " + tablenameRecord + " where AutoID ='" + strdelRecord[i] + "'";
                        aList.Add(sSQL);
                    }
                }
                sSQL = "select * from " + tablenameRecord + " where 1=-1";
                DataTable dtRecord = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenameRecord;
                long AutoIDRecord = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                for (int i = 0; i < dtGridRecord.Rows.Count; i++)
                {
                    if (dtGridRecord.Rows[i].RowState != DataRowState.Deleted && (dtGridRecord.Rows[i]["iSave"].ToString().Trim() == "update" || dtGridRecord.Rows[i]["iSave"].ToString().Trim() == "add"))
                    {
                        #region 判断
                        if (dtGridRecord.Rows[i]["cInvCode"].ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (dtGridRecord.Rows[i]["cInvCode"].ToString().Trim() == "")
                        {
                            sErr = sErr + dtGridRecord.TableName + "行" + (i + 1) + "存货编码不能为空\n";
                            continue;
                        }

                        if (dtGridRecord.Rows[i]["InQty"].ToString().Trim() != "" && dtGridRecord.Rows[i]["cRsCode"].ToString().Trim() == "")
                        {
                            sErr = sErr + dtGridRecord.TableName + "行" + (i + 1) + "入库数量不为空时请输入入库类型\n";
                            continue;
                        }
                        if (dtGridRecord.Rows[i]["dDate"].ToString().Trim() == "")
                        {
                            sErr = sErr + dtGridRecord.TableName + "行" + (i + 1) + "登记日期不能为空\n";
                            continue;
                        }
                        if (dtGridRecord.Rows[i]["cRsCode"].ToString().Trim() != "" && dtGridRecord.Rows[i]["InQty"].ToString().Trim() == "")
                        {
                            sErr = sErr + dtGridRecord.TableName + "行" + (i + 1) + "入库类型不为空时请输入入库数量\n";
                            continue;
                        }
                        #endregion

                        #region 生成table
                        DataRow dw = dtRecord.NewRow();
                        if (dtGridRecord.Rows[i]["iID"].ToString().Trim() != "")
                        {
                            dw["iID"] = dtGridRecord.Rows[i]["iID"].ToString().Trim();
                            dw["AutoID"] = dtGridRecord.Rows[i]["AutoID"];
                            dw["dModifyTime"] = DateTime.Now.ToString();
                            dw["dModifyPerson"] = uid;
                            dr["dCreateTime"] = dtGridRecord.Rows[i]["dCreateTime"];
                            dr["dCreatePerson"] = dtGridRecord.Rows[i]["dCreatePerson"];
                        }
                        else
                        {
                            dw["iID"] = iID;
                            dw["AutoID"] = AutoIDRecord;
                            dw["dCreateTime"] = DateTime.Now.ToString();
                            dw["dCreatePerson"] = uid;
                            AutoIDRecord = AutoIDRecord + 1;
                        }
                        dw["cInvCode"] = dtGridRecord.Rows[i]["cInvCode"];
                        dw["dDate"] = dtGridRecord.Rows[i]["dDate"];
                        dw["BQty"] = dtGridRecord.Rows[i]["BQty"];
                        dw["InQty"] = dtGridRecord.Rows[i]["InQty"];
                        dw["RQty"] = dtGridRecord.Rows[i]["RQty"];
                        dw["cRsCode"] = dtGridRecord.Rows[i]["cRsCode"];
                        dw["OutQty"] = dtGridRecord.Rows[i]["OutQty"];
                        dw["EndQty"] = dtGridRecord.Rows[i]["EndQty"];

                        dw["Remark"] = dtGridRecord.Rows[i]["Remark"];

                        dtRecord.Rows.Add(dw);
                        #endregion

                        if (dtGridRecord.Rows[i]["iSave"].ToString().Trim() == "update")
                        {
                            sSQL = clsGetSQL.GetUpdateSQL(ClsBaseDataInfo.sDataBaseName, tablenameRecord, dtRecord, dtRecord.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                        if (dtGridRecord.Rows[i]["iSave"].ToString().Trim() == "add")
                        {
                            sSQL = clsGetSQL.GetInsertSQL(ClsBaseDataInfo.sDataBaseName, tablenameRecord, dtRecord, dtRecord.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                    }
                }
                #endregion

                #region dtGridQuality
                string[] strdelQuality = delQuality.Trim().Split(',');
                for (int i = 0; i < strdelQuality.Length; i++)
                {
                    if (strdelQuality[i].Trim() != "")
                    {
                        sSQL = "delete  from " + tablenameQuality + " where AutoID ='" + strdelQuality[i] + "'";
                        aList.Add(sSQL);
                    }
                }
                sSQL = "select * from " + tablenameQuality + " where 1=-1";
                DataTable dtQuality = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenameQuality;
                long AutoIDQuality = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                for (int i = 0; i < dtGridQuality.Rows.Count; i++)
                {
                    if (dtGridQuality.Rows[i].RowState != DataRowState.Deleted && (dtGridQuality.Rows[i]["iSave"].ToString().Trim() == "update" || dtGridQuality.Rows[i]["iSave"].ToString().Trim() == "add"))
                    {
                        #region 判断
                        if (dtGridQuality.Rows[i]["dDate"].ToString().Trim() == "" && dtGridQuality.Rows[i]["cQCode"].ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (dtGridQuality.Rows[i]["dDate"].ToString().Trim() == "")
                        {
                            sErr = sErr + dtGridQuality.TableName + "行" + (i + 1) + "登记日期不能为空\n";
                            continue;
                        }
                        if (dtGridQuality.Rows[i]["cQCode"].ToString().Trim() == "")
                        {
                            sErr = sErr + dtGridQuality.TableName + "行" + (i + 1) + "质量类型不能为空\n";
                            continue;
                        }
                        #endregion

                        #region 生成table
                        DataRow dw = dtQuality.NewRow();
                        if (dtGridQuality.Rows[i]["iID"].ToString().Trim() != "")
                        {
                            dw["iID"] = dtGridQuality.Rows[i]["iID"].ToString().Trim();
                            dw["AutoID"] = dtGridQuality.Rows[i]["AutoID"].ToString().Trim();
                            dw["dModifyTime"] = DateTime.Now.ToString();
                            dw["dModifyPerson"] = uid;
                            dr["dCreateTime"] = dtGridQuality.Rows[i]["dCreateTime"];
                            dr["dCreatePerson"] = dtGridQuality.Rows[i]["dCreatePerson"];
                            dw["PersonCode"] = dtGridQuality.Rows[i]["PersonCode"];
                        }
                        else
                        {
                            dw["iID"] = iID;
                            dw["AutoID"] = AutoIDQuality;
                            dw["dCreateTime"] = DateTime.Now.ToString();
                            dw["dCreatePerson"] = uid;
                            dw["PersonCode"] = uid;
                            AutoIDQuality = AutoIDQuality + 1;
                        }
                        dw["dDate"] = dtGridQuality.Rows[i]["dDate"];
                        dw["cQCode"] = dtGridQuality.Rows[i]["cQCode"];
                        

                        dw["PersonCaptain"] = dtGridQuality.Rows[i]["PersonCaptain"];
                        dw["PersonCaptainDept"] = dtGridQuality.Rows[i]["PersonCaptainDept"];
                        dw["PersonCheck"] = dtGridQuality.Rows[i]["PersonCheck"];
                        dw["PersonAssign"] = dtGridQuality.Rows[i]["PersonAssign"];

                        dw["Remark"] = dtGridQuality.Rows[i]["Remark"];

                        dtQuality.Rows.Add(dw);
                        #endregion

                        if (dtGridQuality.Rows[i]["iSave"].ToString().Trim() == "update")
                        {
                            sSQL = clsGetSQL.GetUpdateSQL(ClsBaseDataInfo.sDataBaseName, tablenameQuality, dtQuality, dtQuality.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                        if (dtGridQuality.Rows[i]["iSave"].ToString().Trim() == "add")
                        {
                            sSQL = clsGetSQL.GetInsertSQL(ClsBaseDataInfo.sDataBaseName, tablenameQuality, dtQuality, dtQuality.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                    }
                }
                #endregion

                #region dtGridSecurity
                string[] strdelSecurity = delSecurity.Trim().Split(',');
                for (int i = 0; i < strdelSecurity.Length; i++)
                {
                    if (strdelSecurity[i].Trim() != "")
                    {
                        sSQL = "delete  from " + tablenameSecurity + " where AutoID ='" + strdelSecurity[i] + "'";
                        aList.Add(sSQL);
                    }
                }
                sSQL = "select * from " + tablenameSecurity + " where 1=-1";
                DataTable dtSecurity = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenameSecurity;
                long AutoIDSecurity = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                for (int i = 0; i < dtGridSecurity.Rows.Count; i++)
                {
                    if (dtGridSecurity.Rows[i].RowState != DataRowState.Deleted && (dtGridSecurity.Rows[i]["iSave"].ToString().Trim() == "update" || dtGridSecurity.Rows[i]["iSave"].ToString().Trim() == "add"))
                    {
                        #region 判断
                        if (dtGridSecurity.Rows[i]["dDate"].ToString().Trim() == "" && dtGridSecurity.Rows[i]["cSCode"].ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (dtGridSecurity.Rows[i]["dDate"].ToString().Trim() == "")
                        {
                            sErr = sErr + dtGridSecurity.TableName + "行" + (i + 1) + "登记日期不能为空\n";
                            continue;
                        }
                        if (dtGridSecurity.Rows[i]["cSCode"].ToString().Trim() == "")
                        {
                            sErr = sErr + dtGridSecurity.TableName + "行" + (i + 1) + "安全类型不能为空\n";
                            continue;
                        }
                        #endregion


                        #region 生成table
                        DataRow dw = dtSecurity.NewRow();
                        if (dtGridSecurity.Rows[i]["iID"].ToString().Trim() != "")
                        {
                            dw["iID"] = dtGridSecurity.Rows[i]["iID"].ToString().Trim();
                            dw["AutoID"] = dtGridSecurity.Rows[i]["AutoID"].ToString().Trim();
                            dw["dModifyTime"] = DateTime.Now.ToString();
                            dw["dModifyPerson"] = uid;
                            dr["dCreateTime"] = dtGridSecurity.Rows[i]["dCreateTime"];
                            dr["dCreatePerson"] = dtGridSecurity.Rows[i]["dCreatePerson"];
                            dw["PersonCode"] = dtGridSecurity.Rows[i]["PersonCode"];
                        }
                        else
                        {
                            dw["iID"] = iID;
                            dw["AutoID"] = AutoIDSecurity;
                            dw["dCreateTime"] = DateTime.Now.ToString();
                            dw["dCreatePerson"] = uid;
                            dw["PersonCode"] = uid;
                            AutoIDSecurity = AutoIDSecurity + 1;
                        }
                        dw["dDate"] = dtGridSecurity.Rows[i]["dDate"];
                        dw["cSCode"] = dtGridSecurity.Rows[i]["cSCode"];
                        

                        dw["PersonCaptain"] = dtGridSecurity.Rows[i]["PersonCaptain"];
                        dw["PersonCaptainDept"] = dtGridSecurity.Rows[i]["PersonCaptainDept"];
                        dw["PersonCheck"] = dtGridSecurity.Rows[i]["PersonCheck"];
                        dw["PersonAssign"] = dtGridSecurity.Rows[i]["PersonAssign"];
                        dw["PersonViolation"] = dtGridSecurity.Rows[i]["PersonViolation"];
                        dw["iCount"] = dtGridSecurity.Rows[i]["iCount"];
                        dw["iScore"] = dtGridSecurity.Rows[i]["iScore"];
                        dw["Remark"] = dtGridSecurity.Rows[i]["Remark"];

                        dtSecurity.Rows.Add(dw);
                        #endregion

                        if (dtGridSecurity.Rows[i]["iSave"].ToString().Trim() == "update")
                        {
                            sSQL = clsGetSQL.GetUpdateSQL(ClsBaseDataInfo.sDataBaseName, tablenameSecurity, dtSecurity, dtSecurity.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                        if (dtGridSecurity.Rows[i]["iSave"].ToString().Trim() == "add")
                        {
                            sSQL = clsGetSQL.GetInsertSQL(ClsBaseDataInfo.sDataBaseName, tablenameSecurity, dtSecurity, dtSecurity.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                    }
                }
                #endregion

                #region dtGridAtt
                string[] strdelAtt = delAtt.Trim().Split(',');
                for (int i = 0; i < strdelAtt.Length; i++)
                {
                    if (strdelAtt[i].Trim() != "")
                    {
                        sSQL = "delete  from " + tablenameAtt + " where AutoID ='" + strdelAtt[i] + "'";
                        aList.Add(sSQL);
                    }
                }
                sSQL = "select * from " + tablenameAtt + " where 1=-1";
                DataTable dtAtt = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenameAtt;
                long AutoIDAtt = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                for (int i = 0; i < dtGridAtt.Rows.Count; i++)
                {
                    if (dtGridAtt.Rows[i].RowState != DataRowState.Deleted && (dtGridAtt.Rows[i]["iSave"].ToString().Trim() == "update" || dtGridAtt.Rows[i]["iSave"].ToString().Trim() == "add"))
                    {
                        #region 判断

                        if (dtGridAtt.Rows[i]["Att"].ToString().Trim() == "" || dtGridAtt.Rows[i]["AttName"].ToString().Trim() == "")
                        {
                            sErr = sErr + dtGridAtt.TableName + "行" + (i + 1) + "上传附件及附件名称不能为空\n";
                            continue;
                        }
                        #endregion

                        #region 生成table
                        DataRow dw = dtAtt.NewRow();
                        if (dtGridAtt.Rows[i]["iID"].ToString().Trim() != "")
                        {
                            dw["iID"] = dtGridAtt.Rows[i]["iID"].ToString().Trim();
                            dw["AutoID"] = dtGridAtt.Rows[i]["AutoID"].ToString().Trim();
                            dw["dModifyTime"] = DateTime.Now.ToString();
                            dw["dModifyPerson"] = uid;
                            dr["dCreateTime"] = dtGridAtt.Rows[i]["dCreateTime"];
                            dr["dCreatePerson"] = dtGridAtt.Rows[i]["dCreatePerson"];
                            dw["PersonCode"] = dtGridAtt.Rows[i]["PersonCode"];
                        }
                        else
                        {
                            dw["iID"] = iID;
                            dw["AutoID"] = AutoIDAtt;
                            dw["dCreateTime"] = DateTime.Now.ToString();
                            dw["dCreatePerson"] = uid;
                            dw["PersonCode"] = uid;
                            AutoIDAtt = AutoIDAtt + 1;
                        }
                        dw["AttName"] = dtGridAtt.Rows[i]["AttName"];
                        dw["Att"] = dtGridAtt.Rows[i]["Att"];

                        dw["Remark"] = dtGridAtt.Rows[i]["Remark"];

                        dtAtt.Rows.Add(dw);
                        #endregion

                        if (dtGridAtt.Rows[i]["iSave"].ToString().Trim() == "update")
                        {
                            sSQL = clsGetSQL.GetUpdateSQL(ClsBaseDataInfo.sDataBaseName, tablenameAtt, dtAtt, dtAtt.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                        if (dtGridAtt.Rows[i]["iSave"].ToString().Trim() == "add")
                        {
                            sSQL = clsGetSQL.GetInsertSQL(ClsBaseDataInfo.sDataBaseName, tablenameAtt, dtAtt, dtAtt.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                    }
                }
                #endregion

                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
            }
            catch(Exception ee)
            {
                sErr = ee.Message;
            }
            if (sErr == "")
            {
                return "ok";
            }
            else
            {
                return sErr;
            }
        }

        public string saveProgress(string PID, bool b, string uid, string iID)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                if (b == true)
                {
                    sSQL = @"select a.*,AutoID,b.iID,dDate, b.PersonCode,p.vchrName as PersonName from ProjectProgressClass a 
left join (select * from ProjectProgress where iID='" + iID + "') b on a.cPCCode=b.cPCCode and a.PID=b.PID left join _UserInfo p on b.PersonCode=p.vchrUid where a.PID='" + PID + "'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows[0]["AutoID"].ToString() != "")
                    {
                        sSQL = "update ProjectProgress set dDate=getdate(), PersonCode='" + uid + "' where AutoID='" + dt.Rows[0]["AutoID"].ToString() + "'";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "select isnull(max(AutoID)+1,1) as AutoID from ProjectProgress";
                        long AutoID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                        sSQL = "insert into ProjectProgress(AutoID, iID, cPCCode, PID, dDate, PersonCode) values('" + AutoID + "','" + iID + "','" + dt.Rows[0]["cPCCode"].ToString() + "','" + PID + "',getdate(),'" + uid + "')";
                        aList.Add(sSQL);
                        //sSQL = "delete from ProjectProgress where cPCCode not in (select cPCCode from ProjectProgressClass where PID='" + PID + "') and iID='" + iID + "'";
                        //aList.Add(sSQL);
                        if (PID == "235")
                        {
                            sSQL = "update Project set IsInvoice='1',IsInvoicePer='" + uid + "',IsInvoiceTime=getdate() where iID='" + iID + "'";
                            aList.Add(sSQL);
                        }
                    }
                }
                else
                {
                    sSQL = "delete ProjectProgress where PID='" + PID + "' and iID='" + iID + "'";
                    aList.Add(sSQL);
                    sSQL = "update Project set IsInvoice=null,IsInvoicePer=null,IsInvoiceTime=null where iID='" + iID + "'";
                    aList.Add(sSQL);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            if (sErr == "")
            {
                return "ok";
            }
            else
            {
                return sErr;
            }
        }

        public string del(string iID)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                if (iID == "")
                {
                    throw new Exception("请选择需删除的单据");
                }

                int iRe = CheState(iID);
                if (iRe == -1)
                {
                    throw new Exception("检查单据状态出错");
                }
                if (iRe == 0)
                {
                    throw new Exception("单据不存在");
                }
                //if (iRe == 1)
                //{
                //    throw new Exception("单据已保存");
                //} 
                if (iRe == 2)
                {
                    throw new Exception("单据已审核");
                }
                //if (iRe == 3)
                //{
                //    throw new Exception("单据已关闭");
                //}
                sSQL = "select isnull(count(*),0) from RdRecord b left join  " + tablename + " a  on a.cCode=b.PCode where a." + tableid + "=" + iID + "";
                long count = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                if (count > 0)
                {
                    throw new Exception("已有出库单或退料单引用此项目，不可删除");
                }
                sSQL = "delete " + tablename + " where iID = '" + iID + "' ";
                aList.Add(sSQL);
                sSQL = "delete " + tablenameRecord + " where iID = '" + iID + "' ";
                aList.Add(sSQL);
                sSQL = "delete " + tablenameQuality + " where iID = '" + iID + "' ";
                aList.Add(sSQL);
                sSQL = "delete " + tablenameSecurity + " where iID = '" + iID + "' ";
                aList.Add(sSQL);
                sSQL = "delete " + tablenameProgress + " where iID = '" + iID + "' ";
                aList.Add(sSQL);
                sSQL = "delete " + tablenameAtt + " where iID = '" + iID + "' ";
                aList.Add(sSQL);
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
            }
            catch (Exception ee)
            {
                sErr = sErr + ee.Message;
            }
            if (sErr == "")
            {
                return "ok";
            }
            else
            {
                return sErr;
            }
        }

        public string edit(string iID)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                if (iID == "")
                {
                    throw new Exception("请选择需要修改的单据");
                }

                int iRe = CheState(iID);
                if (iRe == -1)
                {
                    throw new Exception("检查单据状态出错");
                }
                if (iRe == 0)
                {
                    throw new Exception("单据不存在");
                }
                //if (iRe == 1)
                //{
                //    throw new Exception("单据已保存");
                //} 
                if (iRe == 2)
                {
                    throw new Exception("单据已审核");
                }
                //if (iRe == 3)
                //{
                //    throw new Exception("单据已关闭");
                //}
                return sErr;
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }

        public string audit(string iID,string uid)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                if (iID == "")
                {
                    throw new Exception("请选择需要审核的单据");
                }

                int iRe = CheState(iID);
                if (iRe == -1)
                {
                    throw new Exception("检查单据状态出错");
                }
                if (iRe == 0)
                {
                    throw new Exception("单据不存在");
                }
                //if (iRe == 1)
                //{
                //    throw new Exception("单据已保存");
                //} 
                if (iRe == 2)
                {
                    throw new Exception("单据已审核");
                }
                //if (iRe == 3)
                //{
                //    throw new Exception("单据已关闭");
                //}
                sSQL = "update " + tablename + " set dVerifyTime=getdate(),dVerifyPerson='" + uid + "' where " + tableid + "=" + iID + "";
                aList.Add(sSQL);
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
                return sErr;
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }

        public string unAudit(string iID)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                if (iID == "")
                {
                    throw new Exception("请选择需要弃审的单据");
                }

                int iRe = CheState(iID);
                if (iRe == -1)
                {
                    throw new Exception("检查单据状态出错");
                }
                if (iRe == 0)
                {
                    throw new Exception("单据不存在");
                }
                if (iRe == 1)
                {
                    throw new Exception("单据未审核");
                }
                //if (iRe == 2)
                //{
                //    throw new Exception("单据已审核");
                //}
                //if (iRe == 3)
                //{
                //    throw new Exception("单据已关闭");
                //}
                
                sSQL = "update " + tablename + " set dVerifyTime=null,dVerifyPerson=null where " + tableid + "=" + iID + "";
                aList.Add(sSQL);
                
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
                return sErr;
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }

        public string open(string uid, DataTable dtGrid)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                #region dtGrid
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    if (dtGrid.Rows[i]["iChk"].ToString().Trim() == "True" || dtGrid.Rows[i]["iChk"].ToString().Trim() == "true")
                    {
                        string iID = dtGrid.Rows[i]["iID"].ToString();
                        int iRe = CheState2(iID);
                        if (iRe == -1)
                        {
                            sErr = sErr + "行" + (i + 1) + "检查单据状态出错\n";
                        }
                        else if (iRe == 0)
                        {
                            sErr = sErr + "行" + (i + 1) + "单据不存在\n";
                        }
                        else if (iRe == 2)
                        {
                            sErr = sErr + "行" + (i + 1) + "单据已审批\n";
                        }
                        else
                        {
                            sSQL = "update " + tablename + " set dVerifyTime1=getdate(),dVerifyPerson1='" + uid + "' where " + tableid + "=" + iID + "";
                            aList.Add(sSQL);
                        }
                    }
                }
                #endregion
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            if (sErr == "")
            {
                return "ok";
            }
            else
            {
                return sErr;
            }
        }

        public string close(string uid, DataTable dtGrid)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                #region dtGrid
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    if (dtGrid.Rows[i].RowState != DataRowState.Deleted && (dtGrid.Rows[i]["iChk"].ToString().Trim() == "True" || dtGrid.Rows[i]["iChk"].ToString().Trim() == "true"))
                    {
                        if (dtGrid.Rows[i]["iChk"].ToString().Trim() == "True" || dtGrid.Rows[i]["iChk"].ToString().Trim() == "true")
                        {
                            string iID = dtGrid.Rows[i]["iID"].ToString();
                            int iRe = CheState2(iID);
                            if (iRe == -1)
                            {
                                sErr = sErr + "行" + (i + 1) + "检查单据状态出错\n";
                            }
                            else if (iRe == 0)
                            {
                                sErr = sErr + "行" + (i + 1) + "单据不存在\n";
                            }
                            else if (iRe == 1)
                            {
                                sErr = sErr + "行" + (i + 1) + "单据未审批\n";
                            }
                            else
                            {
                                sSQL = "update " + tablename + " set dVerifyTime1=null,dVerifyPerson1=null where " + tableid + "=" + iID + "";
                                aList.Add(sSQL);
                            }
                        }
                    }
                }
                #endregion
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            if (sErr == "")
            {
                return "ok";
            }
            else
            {
                return sErr;
            }
        }

        /// <summary>
        /// 判断单据状态
        /// </summary>
        /// <param name="sCode">单据号</param>
        /// <returns>-1：出错</returns>
        /// <returns>0 ：不存在单据</returns>
        /// <returns>1 ：已保存</returns>
        /// <returns>2 ：已审核</returns>
        /// <returns>3 ：已关闭</returns>
        private int CheState(string iID)
        {
            int iReturn = -1;
            try
            {
                sSQL = "select  isnull(dCreatePerson,'') as 制单人,isnull(dVerifyPerson,'') as 审核人 from " + tablename + " where " + tableid + " = '" + iID + "'";
                DataTable dtTable = clsSQLCommond.ExecQuery(sSQL);
                if (dtTable == null || dtTable.Rows.Count < 1)
                    iReturn = 0;
                else
                {
                    if (dtTable.Rows[0]["制单人"].ToString().Trim() != "")
                    {
                        iReturn = 1;
                    }
                    if (dtTable.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        iReturn = 2;
                    }
                }
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        /// <summary>
        /// 判断单据状态
        /// </summary>
        /// <param name="sCode">单据号</param>
        /// <returns>-1：出错</returns>
        /// <returns>0 ：不存在单据</returns>
        /// <returns>1 ：已保存</returns>
        /// <returns>2 ：已审核</returns>
        /// <returns>3 ：已关闭</returns>
        private int CheState2(string iID)
        {
            int iReturn = -1;
            try
            {
                sSQL = "select  isnull(dCreatePerson,'') as 制单人,isnull(dVerifyPerson1,'') as 审批人 from " + tablename + " where " + tableid + " = '" + iID + "'";
                DataTable dtTable = clsSQLCommond.ExecQuery(sSQL);
                if (dtTable == null || dtTable.Rows.Count < 1)
                    iReturn = 0;
                else
                {
                    if (dtTable.Rows[0]["制单人"].ToString().Trim() != "")
                    {
                        iReturn = 1;
                    }
                    if (dtTable.Rows[0]["审批人"].ToString().Trim() != "")
                    {
                        iReturn = 2;
                    }
                }
            }
            catch (Exception ee)
            { }
            return iReturn;
        }
    }
}
