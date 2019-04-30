using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Web.Configuration;
    /// <summary>
    ///Public 的摘要说明
    /// </summary>
public class ReportData : Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL = "";
    string tablename = "Report";
    public string dDate
    {
        get { return WebConfigurationManager.ConnectionStrings["ConnectionStringdDate"].ToString(); }
        set { }
    }
    public ReportData()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataTable Report1(string sDate,string eDate)
    {

        sSQL = @"
--select 1 as iOrder,'进入铝棒' as Flag,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity into #a FROM  viewRec0101 where 1=1
--union all 
--select 2,'外购铝材',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewRec0302 where 1=1
--union all 
--select 3,'发出废料',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewRecBack where 1=1
--union all 
--select 4,'发出成品（实际重量）',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesOut where 1=1
--union all  
--select 5,'退货（实际重量）',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesBack where 1=1
--union all 
--select 6,'进入－发出',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewRec0101 where 1=1
--union all 
--select 6,'进入－发出',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesBack where 1=1
--union all 
--select 6,'进入－发出',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewRec0302 where 1=1
--union all 
--select 6,'进入－发出',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,-convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewRecBack where 1=1
--union all 
--select 6,'进入－发出',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,-convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesOut where 1=1
--union all 
--select 7,'净发货',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesOut where 1=1
--union all 
--select 7,'净发货',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,-convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesBack where 1=1
--union all 
--select 8,'销售订单',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSales where 1


select 1 as iOrder,convert(nvarchar(50),'进入铝棒') as Flag,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity into #a FROM  viewRec0101 where 1=1

insert into #a 
select 2,'外购铝材',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewRec0302 where 1=1
insert into #a 
select 3,'发出废料',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewRecBack where 1=1
insert into #a 
select 4,'发出成品（实际重量）',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesOut where 1=1
insert into #a 
select 5,'退货（实际重量）',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesBack where 1=1
insert into #a 
select 6,'进入－发出',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewRec0101 where 1=1
insert into #a 
select 6,'进入－发出',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesBack where 1=1
insert into #a 
select 6,'进入－发出',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewRec0302 where 1=1
insert into #a 
select 6,'进入－发出',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,-convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewRecBack where 1=1
insert into #a 
select 6,'进入－发出',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,-convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesOut where 1=1
insert into #a 
select 7,'净发货',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesOut where 1=1
insert into #a 
select 7,'净发货',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,-convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSalesBack where 1=1
insert into #a 
select 8,'销售订单',datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 6),iQuantity) as iQuantity FROM  viewSales where 1=1

insert into #a(iYear,iOrder,Flag) values(111111,1,'进入铝棒')
insert into #a(iYear,iOrder,Flag) values(111111,2,'外购铝材')
insert into #a(iYear,iOrder,Flag) values(111111,3,'发出废料')
insert into #a(iYear,iOrder,Flag) values(111111,4,'发出成品（实际重量）')
insert into #a(iYear,iOrder,Flag) values(111111,5,'退货（实际重量）')
insert into #a(iYear,iOrder,Flag) values(111111,6,'进入－发出')
insert into #a(iYear,iOrder,Flag) values(111111,7,'净发货')
insert into #a(iYear,iOrder,Flag) values(111111,8,'销售订单')

select iOrder,Flag
,convert(decimal(18, 1),SUM(case when iMonth=1 then iQuantity end)) as S1 
,convert(decimal(18, 1),SUM(case when iMonth=2 then iQuantity end)) as S2 
,convert(decimal(18, 1),SUM(case when iMonth=3 then iQuantity end)) as S3 
,convert(decimal(18, 1),SUM(case when iMonth=4 then iQuantity end)) as S4 
,convert(decimal(18, 1),SUM(case when iMonth=5 then iQuantity end)) as S5 
,convert(decimal(18, 1),SUM(case when iMonth=6 then iQuantity end)) as S6 
,convert(decimal(18, 1),SUM(case when iMonth=7 then iQuantity end)) as S7 
,convert(decimal(18, 1),SUM(case when iMonth=8 then iQuantity end)) as S8 
,convert(decimal(18, 1),SUM(case when iMonth=9 then iQuantity end)) as S9 
,convert(decimal(18, 1),SUM(case when iMonth=10 then iQuantity end)) as S10 
,convert(decimal(18, 1),SUM(case when iMonth=11 then iQuantity end)) as S11 
,convert(decimal(18, 1),SUM(case when iMonth=12 then iQuantity end)) as S12 
,convert(decimal(18, 1),SUM(iQuantity)) as 合计 
from #a a GROUP BY iOrder,Flag order by iOrder,Flag
";
        if (sDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate>='" + sDate + "'");
            sSQL = sSQL.Replace("111111", "'" + DateTime.Parse(sDate).Year + "'");
        }
        if (eDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate<='" + eDate + "'");
        }
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        return dt;
    }

    public DataTable Report2(string sDate, string eDate)
    {
        sSQL = @"select datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,sum(iQuantity) as iQuantity from viewRec0101 where 1=1  
        group by datepart(yyyy,BusinessDate),datepart(MM,BusinessDate) order by datepart(MM,BusinessDate)";
        if (sDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate>='" + sDate + "'");
        }
        if (eDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate<='" + eDate + "'");
        }
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        return dt;
    }

    public DataTable Report3(string Year,int i)
    {
        if(i==1)
        {
            sSQL = @"select datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,sum(iQuantity) as iQuantity
from viewSalesBack  where 1=1 group by datepart(yyyy,BusinessDate),datepart(MM,BusinessDate) ";
        }
        else if(i==2)
        {
            sSQL = @"select datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,sum(iQuantity) as iQuantity
from viewSalesOut  where 1=1 group by datepart(yyyy,BusinessDate),datepart(MM,BusinessDate) ";
        }
        else 
        {
            sSQL = @"select datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,sum(iQuantity) as iQuantity
from viewSales  where 1=1 group by datepart(yyyy,BusinessDate),datepart(MM,BusinessDate) ";
        }

        sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,BusinessDate)='" + Year + "' ");
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        return dt;
    }

    public DataTable Report4(string cCusName, string cInvCName, string sDate, string eDate)
    {
        sSQL = @"
select cInvCCode,cInvCName,cCusCode,cCusName,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 2),iQuantity) as iQuantity into #a from viewSalesOut2 where 1=1 
insert into #a
select cInvCCode,cInvCName,cCusCode,cCusName,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,-convert(decimal(18, 2),iQuantity) as iQuantity from viewSalesBack2 where 1=1 

select iYear,SUM(case when iMonth=1 then iQuantity end) as S1 
,SUM(case when iMonth=2 then iQuantity end) as S2 
,SUM(case when iMonth=3 then iQuantity end) as S3 
,SUM(case when iMonth=4 then iQuantity end) as S4 
,SUM(case when iMonth=5 then iQuantity end) as S5 
,SUM(case when iMonth=6 then iQuantity end) as S6 
,SUM(case when iMonth=7 then iQuantity end) as S7 
,SUM(case when iMonth=8 then iQuantity end) as S8 
,SUM(case when iMonth=9 then iQuantity end) as S9 
,SUM(case when iMonth=10 then iQuantity end) as S10 
,SUM(case when iMonth=11 then iQuantity end) as S11 
,SUM(case when iMonth=12 then iQuantity end) as S12 from  #a as a group by iYear";
        if (sDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate>='" + sDate + "'");
        }
        if (eDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate<='" + eDate + "'");
        }
        if (cCusName != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and (cCusCode like '%" + cCusName + "%' or cCusName like '%" + cCusName + "%')");
        }
        if (cInvCName != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and (cInvCCode like '%" + cInvCName + "%' or cInvCName like '%" + cInvCName + "%')");
        }
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        return dt;
    }

    public DataTable Report4_1(string cCusName, string cInvCName, string sDate, string eDate,string iYear)
    {
        sSQL = @"
select cInvCCode,cInvCName,cCusCode,cCusName,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 2),iQuantity) as iQuantity into #a from viewSalesOut2 where 1=1 
insert into #a 
select cInvCCode,cInvCName,cCusCode,cCusName,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,-convert(decimal(18, 2),iQuantity) as iQuantity from viewSalesBack2 where 1=1 

select iYear,iMonth,sum(iQuantity) as iQuantity FROM #a as a group by iYear,iMonth";
        if (sDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate>='" + sDate + "'");
        }
        if (eDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate<='" + eDate + "'");
        }
        if (iYear != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,BusinessDate)='" + iYear + "'");
        }
        if (cCusName != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and cCusName='" + cCusName + "'");
        }
        if (cInvCName != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and (cInvCCode like '%" + cInvCName + "%' or cInvCName like '%" + cInvCName + "%')");
        }
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        return dt;
    }

    public DataTable Report5_1()
    {
        sSQL = @"
select cInvCName FROM  viewSalesOut group by cInvCName order by cInvCName ";
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        return dt;
    }

    public DataTable Report5(string Year1, string Year2, string cInvCName, int Month1, int Month2)
    {
        string month1 = Month1.ToString();
        if (month1.Length == 1)
        {
            month1 = "0" + month1;
        }
        string month2 = Month2.ToString();
        if (month2.Length == 1)
        {
            month2 = "0" + month2;
        }
        sSQL = @"
select cInvCCode,cInvCName,cCusCode,cCusName,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 2),iQuantity) as iQuantity into #a from viewSalesOut2 where 1=1 
insert into #a 
select cInvCCode,cInvCName,cCusCode,cCusName,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,-convert(decimal(18, 2),iQuantity) as iQuantity from viewSalesBack2 where 1=1 

select cInvCName FROM #a as a where isnull(cInvCName,'')<>'' group by cInvCName order by cInvCName ";
        DataTable dtg = clsSQLCommond.ExecQueryWithoutSession(sSQL);

        sSQL = @"
select cInvCCode,cInvCName,cCusCode,cCusName,BusinessDate,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,convert(decimal(18, 2),iQuantity) as iQuantity into #a from viewSalesOut2 where 1=1 
insert into #a 
select cInvCCode,cInvCName,cCusCode,cCusName,BusinessDate,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,-convert(decimal(18, 2),iQuantity) as iQuantity from viewSalesBack2 where 1=1 
select convert(varchar(7),BusinessDate,120) as iMonth2";
        for (int i = 0; i < dtg.Rows.Count; i++)
        {
            sSQL = sSQL + ",convert(decimal(18, 2),SUM(case when cInvCName='" + dtg.Rows[i]["cInvCName"].ToString() + "' then iQuantity end)) as [" + dtg.Rows[i]["cInvCName"].ToString() + "] ";
        }
        sSQL = sSQL + @",convert(decimal(18, 2),sum(iQuantity)) as 合计 FROM #a as a
group by convert(varchar(7),BusinessDate,120) order by convert(varchar(7),BusinessDate,120)
";
        sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(7),BusinessDate,120)>='" + Year1 + "-" + month1 + "'");
        sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(7),BusinessDate,120)<='" + Year2 + "-" + month2 + "'");
        //if (cCusCode != "")
        //{
        //    sSQL = sSQL.Replace("1=1", "1=1 and cCusCode='" + cCusCode + "'");
        //}
        if (cInvCName != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and (cInvCCode like '%" + cInvCName + "%' or cInvCName like '%" + cInvCName + "%')");
        }
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        //decimal sum = DataType.DecimalParse(dt.Compute("sum(合计)", ""));
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    dt.Rows[i]["百分比"] = DataType.DecimalParse(DataType.DecimalParse(dt.Rows[i]["合计"])*100 / sum,2);
        //}
        return dt;
    }

    public DataTable Report6(string sDate, string eDate, string cInvCName)
    {
        sSQL = @"
select cInvCCode,cInvCName,BusinessDate,iQuantity,convert(decimal(18, 2),0)  as iQuantity1,iQuantity as iQuantity2,convert(decimal(18, 2),0)  as iQuantity3 into #a from viewScrapSales where 1=1
insert into #a 
select cInvCCode,cInvCName,BusinessDate,-iQuantity,0 as iQuantity1,-iQuantity as iQuantity2,0 as iQuantity3 from viewInvDoc where 1=1
insert into #a 
select cInvCCode,cInvCName,BusinessDate,iQuantity,iQuantity as iQuantity1,0 as iQuantity2,0 as iQuantity3 from viewScrapMO where 1=1
insert into #a 
select cInvCCode,cInvCName,BusinessDate,iQuantity,0 as iQuantity1,0 as iQuantity2,iQuantity as iQuantity3 from viewScrapPM where 1=1 

select s.cInvCCode,s.cInvCName,convert(decimal(18, 2),iQuantity) as iQuantity,convert(decimal(18, 2),iQuantity1) as iQuantity1,convert(decimal(18, 2),iQuantity2) as iQuantity2,convert(decimal(18, 2),iQuantity3) as iQuantity3,convert(decimal(18, 2),iQuantityLL) as outiQuantity
,convert(decimal(18, 2),case when convert(decimal(18, 2),iQuantityLL)<>0 then iQuantity*100/iQuantityLL end) as Per,cInvCType.Per as Per2 from (

select cInvCCode,cInvCName,sum(iQuantity) as iQuantity,sum(iQuantity1) as iQuantity1,sum(iQuantity2) as iQuantity2,sum(iQuantity3) as iQuantity3 from #a as a group by cInvCCode,cInvCName) s 

left join (select cInvCCode,cInvCName,sum(iQuantityLL) as iQuantityLL from viewSalesOut2 where 1=1  group by cInvCCode,cInvCName) b
on s.cInvCName=b.cInvCName 
left join cInvCType on s.cInvCCode=cInvCType.cInvCCode
";
        if (sDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate>='" + sDate + "'");
        }
        if (eDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate<='" + eDate + "'");
        }
        if (cInvCName != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and (cInvCCode like '%" + cInvCName + "%' or cInvCName like '%" + cInvCName + "%')");
        }
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        return dt;
    }

    public DataTable Report7(string sDate, string eDate, string cCusCode)
    {
        sSQL = @"
select cCusCode,cCusName,BusinessDate,iQuantity,convert(decimal(18, 2),0)  as iQuantity1,iQuantity as iQuantity2,convert(decimal(18, 2),0)  as iQuantity3 into #a from viewScrapSales2 where 1=1
insert into #a 
select cCusCode,cCusName,BusinessDate,-iQuantity,0 as iQuantity1,-iQuantity as iQuantity2,0 as iQuantity3 from viewInvDoc where 1=1
insert into #a 
select cCusCode,cCusName,BusinessDate,iQuantity,iQuantity as iQuantity1,0 as iQuantity2,0 as iQuantity3 from viewScrapMO2 where 1=1
insert into #a 
select cCusCode,cCusName,BusinessDate,iQuantity,0 as iQuantity1,0 as iQuantity2,iQuantity as iQuantity3 from viewScrapPM2 where 1=1 

select s.cCusCode,s.cCusName,convert(decimal(18, 2),iQuantity) as iQuantity,convert(decimal(18, 2),iQuantity1) as iQuantity1,convert(decimal(18, 2),iQuantity2) as iQuantity2,convert(decimal(18, 2),iQuantity3) as iQuantity3,convert(decimal(18, 2),iQuantityLL) as outiQuantity
,convert(decimal(18, 2),case when convert(decimal(18, 2),iQuantityLL)<>0 then iQuantity*100/iQuantityLL end) as Per from (

select cCusCode,cCusName,sum(iQuantity) as iQuantity,sum(iQuantity1) as iQuantity1,sum(iQuantity2) as iQuantity2,sum(iQuantity3) as iQuantity3 from #a as a group by cCusCode,cCusName) s 

left join (select cCusCode,cCusName,sum(iQuantityLL) as iQuantityLL from viewSalesOut2 where 1=1  group by cCusCode,cCusName) b

on s.cCusName=b.cCusName order by iQuantity desc
";
        if (sDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate>='" + sDate + "'");
        }
        if (eDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate<='" + eDate + "'");
        }
        if (cCusCode != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and (cCusCode like '%" + cCusCode + "%' or cCusName like '%" + cCusCode + "%')");
        }
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        return dt;
    }

    public DataTable Report8(string sDate, string eDate)
    {
        sSQL = @"
select cCusCode,cCusName,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,iQuantity,iMoney,Symbol into #a from viewSalesOut2 where 1=1
insert into #a 
select cCusCode,cCusName,datepart(yyyy,BusinessDate) as iYear,datepart(MM,BusinessDate) as iMonth,-iQuantity,-iMoney,Symbol from viewSalesBack2 where 1=1 

select cCusName,Symbol,convert(decimal(18, 2),sum(iQuantity)) as iQuantity,convert(decimal(18, 2),sum(iMoney)) as iMoney from #a as a  group by cCusName,Symbol order by sum(iQuantity) desc
";
        if (sDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate>='" + sDate + "'");
        }
        if (eDate != "")
        {
            sSQL = sSQL.Replace("1=1", "1=1 and BusinessDate<='" + eDate + "'");
        }
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        return dt;
    }
}
