using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class ClsReport
    {
        string sSQL = "";
        protected ClsGetSQL clsGetSQL = ClsGetSQL.Instance();
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public string dtReportSecurity(DateTime dDate1, DateTime dDate2, DateTime dDate3, DateTime dDate4, string cPCCode, string cDCCode, string PersonCode, string cSCode, string cECode)
        {
            string s = "";

            try
            {
                sSQL = @"select a.cPCCode,a.cDCCode,a.cECode,b.cSCode,b.PersonCaptainDept,sum(b.iCount) as iCount,sum(b.iScore) as iScore 
from Project a left join ProjectSecurity b on a.iID=b.iID 
where b.iID is not null";
                if (dDate1 != DateTime.MinValue)
                {
                    sSQL = sSQL + " and convert(varchar(10),a.dDate,120)>='" + dDate1.ToString("yyyy-MM-dd") + "'";
                }
                if (dDate2 != DateTime.MinValue)
                {
                    sSQL = sSQL + " and convert(varchar(10),a.dDate,120)<='" + dDate2.ToString("yyyy-MM-dd") + "'";
                }
                if (dDate3 != DateTime.MinValue)
                {
                    sSQL = sSQL + " and convert(varchar(10),b.dDate,120)>='" + dDate3.ToString("yyyy-MM-dd") + "'";
                }
                if (dDate4 != DateTime.MinValue)
                {
                    sSQL = sSQL + " and convert(varchar(10),b.dDate,120)<='" + dDate4.ToString("yyyy-MM-dd") + "'";
                }
                if (cPCCode != "")
                {
                    sSQL = sSQL + " and isnull(a.cPCCode,'')='" + cPCCode + "'";
                }
                if (cDCCode != "")
                {
                    sSQL = sSQL + " and isnull(a.cDCCode,'')='" + cDCCode + "'";
                }
                if (cECode != "")
                {
                    sSQL = sSQL + " and isnull(a.cECode,'')='" + cECode + "'";
                }
                if (PersonCode != "")
                {
                    sSQL = sSQL + " and isnull(b.PersonCode,'')='" + PersonCode + "'";
                }
                if (cSCode != "")
                {
                    sSQL = sSQL + " and isnull(b.cSCode,'')='" + cSCode + "'";
                }
                
                sSQL = sSQL + " group by a.cPCCode,a.cDCCode,a.cECode,b.cSCode,b.PersonCaptainDept";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dtReportQuality(DateTime dDate1, DateTime dDate2, DateTime dDate3, DateTime dDate4, string cPCCode, string cDCCode, string PersonCode, string cQCode, string cECode)
        {
            string s = "";

            try
            {
                sSQL = @"select a.cPCCode,a.cDCCode,a.cECode,b.PersonCaptainDept, count(*) as 项目总数,null as 符合项目数量 into #a 
from Project a left join ProjectQuality b on a.iID=b.iID 
where b.iID is not null and 1=1 group by a.cPCCode,a.cDCCode,a.cECode,b.PersonCaptainDept
union all 
select a.cPCCode,a.cDCCode,a.cECode,b.PersonCaptainDept, null ,  count(*)
from Project a left join ProjectQuality b on a.iID=b.iID 
where b.iID is not null and 1=1 and 2=2 group by a.cPCCode,a.cDCCode,a.cECode,b.PersonCaptainDept

select cPCCode,cDCCode,cECode,PersonCaptainDept,sum(项目总数) as 项目总数,sum(符合项目数量) as 符合项目数量,convert(decimal(18, 2),sum(符合项目数量)*100/sum(项目总数)) 比率 from #a group by cPCCode,cDCCode,cECode,PersonCaptainDept
";
                if (dDate1 != DateTime.MinValue)
                {
                    sSQL = sSQL.Replace("1=1","1=1 and convert(varchar(10),a.dDate,120)>='" + dDate1.ToString("yyyy-MM-dd") + "'");
                }
                if (dDate2 != DateTime.MinValue)
                {
                    sSQL = sSQL.Replace("1=1","1=1 and convert(varchar(10),a.dDate,120)<='" + dDate2.ToString("yyyy-MM-dd") + "'");
                }
                if (dDate3 != DateTime.MinValue)
                {
                    sSQL = sSQL.Replace("1=1","1=1 and convert(varchar(10),b.dDate,120)>='" + dDate3.ToString("yyyy-MM-dd") + "'");
                }
                if (dDate4 != DateTime.MinValue)
                {
                    sSQL = sSQL.Replace("1=1","1=1 and convert(varchar(10),b.dDate,120)<='" + dDate4.ToString("yyyy-MM-dd") + "'");
                }
                if (cPCCode != "")
                {
                    sSQL = sSQL.Replace("1=1","1=1 and isnull(a.cPCCode,'')='" + cPCCode + "'");
                }
                if (cDCCode != "")
                {
                    sSQL = sSQL.Replace("1=1","1=1 and isnull(a.cDCCode,'')='" + cDCCode + "'");
                }
                if (cECode != "")
                {
                    sSQL = sSQL.Replace("1=1","1=1 and isnull(a.cECode,'')='" + cECode + "'");
                }
                if (PersonCode != "")
                {
                    sSQL = sSQL.Replace("1=1","1=1 and isnull(b.PersonCode,'')='" + PersonCode + "'");
                }
                if (cQCode != "")
                {
                    sSQL = sSQL.Replace("2=2", "2=2 and b.cQCode in (" + cQCode + ")");
                }
                else
                {
                    sSQL = sSQL.Replace("2=2", "1=-1");
                }

                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dtReportCheck(DateTime dDate1, DateTime dDate2, DateTime dDate3, DateTime dDate4, string cPCCode, string cDCCode, string PersonCode, string cECode)
        {
            string s = "";

            try
            {
                sSQL = @"select a.cPCCode,a.cDCCode,a.cECode,a.CheckPerson,p.cDepCode,count(case when a.IsCheck is null then 1 end) iEmpty,
count(*) as iCount,count(case when a.IsCheck=1 then 1 end) as iTrue,sum(case when a.IsCheck=0 then 1 end) as iFalse,
case when  isnull(count(*),0)<>0 then convert(decimal(16, 2),sum(case when a.IsCheck=1 then 1.00 end)*100/count(*)) else 0 end Per
from Project a left join Person p on a.CheckPerson=p.PersonCode where 1=1 
";
                if (dDate1 != DateTime.MinValue)
                {
                    sSQL = sSQL + " and convert(varchar(10),a.dDate,120)>='" + dDate1.ToString("yyyy-MM-dd") + "'";
                }
                if (dDate2 != DateTime.MinValue)
                {
                    sSQL = sSQL + " and convert(varchar(10),a.dDate,120)<='" + dDate2.ToString("yyyy-MM-dd") + "'";
                }
                if (dDate3 != DateTime.MinValue)
                {
                    sSQL = sSQL + " and convert(varchar(10),a.CheckTime,120)>='" + dDate3.ToString("yyyy-MM-dd") + "'";
                }
                if (dDate4 != DateTime.MinValue)
                {
                    sSQL = sSQL + " and convert(varchar(10),a.CheckTime,120)<='" + dDate4.ToString("yyyy-MM-dd") + "'";
                }
                if (cPCCode != "")
                {
                    sSQL = sSQL + " and isnull(a.cPCCode,'')='" + cPCCode + "'";
                }
                if (cDCCode != "")
                {
                    sSQL = sSQL + " and isnull(a.cDCCode,'')='" + cDCCode + "'";
                }
                if (cECode != "")
                {
                    sSQL = sSQL + " and isnull(a.cECode,'')='" + cECode + "'";
                }
                if (PersonCode != "")
                {
                    sSQL = sSQL + " and isnull(a.CheckPerson,'')='" + PersonCode + "'";
                }
                sSQL = sSQL + " group by a.cPCCode,a.cDCCode,a.cECode,a.CheckPerson,p.cDepCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dtReportNow()
        {
            string s = "";

            try
            {
                sSQL = @"declare @iID as nvarchar(10)
declare @ddate as nvarchar(10)
select top 1 @iID=iID,@ddate=convert(nvarchar(10),dDate,120) from MonthRdRecord where isnull(dVerifyPerson,'')<>'' order by dDate desc,iID desc


select b.cInvCode,b.iQuantity into #a from MonthRdRecord a left join MonthRdRecords b on a.iID=b.iID where a.iID=@iID
union all
select b.cInvCode,b.InQty from Project a left join ProjectRecord b on a.iID=b.iID where convert(nvarchar(10),a.dDate,120)>=@ddate
union all 
select b.cInvCode,case when cRSCode='02' then iQuantity when cRSCode='11' then iQuantity end from RdRecord a left join RdRecords b on a.iID=b.iID where convert(nvarchar(10),a.dDate,120)>=@ddate

select cInvCode,sum(iQuantity) as iQuantity from #a group by cInvCode
";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }
    }
}
