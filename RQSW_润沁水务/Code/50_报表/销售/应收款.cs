using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 报表
{
    public static class 应收款
    {

        public static DataTable Table(string endtime, string cCusCode, string cPersonCode)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            endtime = DateTime.Parse(endtime).ToString("yyyy-MM-dd");
            string sSQL = GetSql();
            sSQL = sSQL + @"

select cCusCode,cSTCode,cPersonCode,cDepCode,CONVERT(decimal(18, 2),iMoney) as iMoney,记账日期 from #d  where 1=1 
";

            sSQL = sSQL.Replace("5=5", " '" + endtime + "'  ");
            if (cPersonCode != "")
            {
                sSQL = sSQL+" and cPersonCode='" + cPersonCode + "' ";
            }

            if (cCusCode != "")
            {
                sSQL = sSQL + " and cCusCode='" + cCusCode + "' ";
            }

            return clsSQLCommond.ExecQuery(sSQL);
        }

        //账龄
        public static DataTable Table2(string endtime, string cCusCode, string cPersonCode)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            endtime = DateTime.Parse(endtime).ToString("yyyy-MM-dd");
            string sSQL = GetSql();

            sSQL = sSQL + @"
    select (CONVERT(decimal(18, 2),sum(a.iMoney1))) as a1,(CONVERT(decimal(18, 2),sum(a.iMoney2))) as a2,(CONVERT(decimal(18, 2),sum(a.iMoney3))) as a3, (CONVERT(decimal(18, 2),sum(isnull(a.iMoney1,0)) + sum(isnull(a.iMoney2,0)) + sum(isnull(a.iMoney3,0)))) as iMoney
	    ,a.cCusCode,a.cSTCode,per.PersonCode as cPersonCode,per.DeptID as cDepCode
    from
    (
    select cCusCode,cSTCode,cPersonCode,cDepCode
	    ,case when DATEDIFF (day,记账日期 ,  5=5  ) < 90 then (CONVERT(decimal(18, 4),iMoney)) end as iMoney1
	    ,case when DATEDIFF (day,记账日期 ,  5=5  ) < 180 and DATEDIFF (day,记账日期 ,  5=5  ) >= 90 then (CONVERT(decimal(18, 4),iMoney)) end as iMoney2
	    ,case when DATEDIFF (day,isnull(记账日期,'2000-1-1') ,  5=5  ) >= 180 then (CONVERT(decimal(18, 4),iMoney)) end as iMoney3
    from #d  
    where 1=1 
    )a
		left join Customer g on a.cCusCode = g.cCusCode 
		left join Person per on g.cCusPPerson = per.PersonCode
    group by a.cCusCode,a.cSTCode,per.PersonCode,per.DeptID
    having cast(sum(isnull(a.iMoney1,0)) + sum(isnull(a.iMoney2,0)) + sum(isnull(a.iMoney3,0)) as decimal(18,2))  <> 0

";

            sSQL = sSQL.Replace("5=5", " '" + endtime + "'  ");
            if (cPersonCode != "")
            {
                sSQL = sSQL + " and per.PersonCode='" + cPersonCode + "' ";
            }

            if (cCusCode != "")
            {
                sSQL = sSQL + " and a.cCusCode='" + cCusCode + "' ";
            }

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            return dt;
        }
        public static string GetSql()
        {
            return @"

SELECT     1 as type,a.cCusCode,a.cSTCode, CONVERT(decimal(18, 4),b.iMoney) as iMoney,a.dDate,a.dDate as 记账日期,per.PersonCode as 记账销售,per.DeptID as 记账部门 
into #a
FROM   SO_SOMain a left join  SO_SODetails b on a.ID=b.ID 
	left join Customer d on a.cCuscode = d.cCusCode
    left join Person per on d.cCusPPerson = per.PersonCode
where 1=1  and a.dDate<=  5=5    and a.dVerifysysTime is not null 

insert into #a 
select 2 as type,a.cCusCode, cSTCode,CONVERT(decimal(18, 4),b.iMoney),a.dDate,d.dDate as 记账日期,per.PersonCode as 记账销售,per.DeptID as 记账部门
from SO_SOReturn a left join SO_SOReturns b on a.ID=b.ID 
	left join view_SO_SODetails c on b.SoAutoID=c.AutoID 
    left join view_so_somain d on c.ID=d.ID 
	left join Customer e on a.cCusCode = e.cCusCode
    left join Person per on e.cCusPPerson = per.PersonCode
where 1=1 and a.dDate<=  5=5     and a.dVerifysysTime is not null 

insert into #a 
select 4 as type,a.cCusCode,a.cSTCode,CONVERT(decimal(18, 4),-b.iMoney),a.dDate,d.dDate as 记账日期,per.PersonCode as 记账销售,per.DeptID as 记账部门
from RdRecord a left join RdRecords b on a.ID=b.ID 
    left join view_SO_SODetails c on a.SoAutoID=c.AutoID 
    left join view_SO_SOMain d on c.ID=d.ID
    left join RdStyle on a.cRSCode=RdStyle.cRSCode  
	left join Customer e on a.cCusCode = e.cCusCode
    left join Person per on e.cCusPPerson = per.PersonCode
where 1=1 and a.dDate<=   5=5     and RdStyle.B2=1 and RdStyle.S1=2  and a.dVerifysysTime is not null 

insert into #a 
select 5 as type,a.cCusCode,a.cSTCode,CONVERT(decimal(18, 4),-iMoneyNow),a.dDate,c.dDate as 记账日期,per.PersonCode as 记账销售,per.DeptID as 记账部门
from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
	left join view_SO_SOMain c on b.cTypeCode=c.cSOCode 
	left join Customer e on a.cCusCode = e.cCusCode
    left join Person per on e.cCusPPerson = per.PersonCode
where 1=1 and a.dDate<=   5=5     and iType=2  and a.dVerifysysTime is not null

insert into #a 
select 9 as type, a.cCusCode,a.cSTCode,CONVERT(decimal(18, 4),-a.iAmount+ISNULL(b.iMoneyNow,0)) as iMoney,a.dDate,a.dDate as 记账日期, per.PersonCode as 记账销售,per.DeptID as 记账部门 
from SO_CloseBill a 
    left join (select ID,sum(iMoneyNow) as iMoneyNow from SO_CloseBillDetails group by ID) b on a.ID=b.ID 
	left join Customer e on a.cCusCode = e.cCusCode
    left join Person per on e.cCusPPerson = per.PersonCode
where 1=1 and a.dDate<=   5=5   and a.dVerifysysTime is not null 

--期初
insert into #a 
select 6 as type,a.S1 as cCusCode,a.S5 as cSTCode,CONVERT(decimal(18, 4),a.D1) as iMoney,a.Date1 as  dDate ,a.Date1 as  记账日期, per.PersonCode as 记账销售,per.DeptID as 记账部门
from AR_First a
    left join Customer e on a.s1 = e.cCusCode
    left join Person per on e.cCusPPerson = per.PersonCode
where 2=2 and a.Date1 <=    5=5  

insert into #a 
select 7 as type,a.cCusCode,a.cSTCode,CONVERT(decimal(18, 4),-iMoneyNow),a.dDate
    ,d.Date1 as 记账日期
	,per.PersonCode as 记账销售
	,per.DeptID as 记账部门
from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
    Left join SysDB_RQSW_2013_20170617..AR_First d  on b.cTypeCode=d.iid 
    left join Customer e on a.cCusCode = e.cCusCode
    left join Person per on e.cCusPPerson = per.PersonCode
where 1=1 and a.dDate<=    5=5      and iType=1  and a.dVerifysysTime is not null

insert into #a 
select 8 as type,a.cCusCode,a.cSTCode,CONVERT(decimal(18, 4),-b.iMoney),a.dDate,f.Date1 as 记账日期,per.PersonCode as 记账销售,per.DeptID as 记账部门
from RdRecord a left join RdRecords b on a.ID=b.ID
	left join RdStyle on a.cRSCode=RdStyle.cRSCode 
    left join AR_First f on ARiID=f.iid 
    left join Customer g on a.cCusCode = g.cCusCode 
    left join Person per on g.cCusPPerson = per.PersonCode
where 1=1 and a.dDate<=   5=5      and RdStyle.B2=1 and RdStyle.S1=1  and a.dVerifysysTime is not null 


select *,
    case when (select top 1 aIntPPerson from CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<=  5=5 order by aIntAdjustTime desc) IS not null 
		then (select top 1 aIntPPerson from CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<=   5=5    
    order by aIntAdjustTime desc) else 记账销售 end cPersonCode 
into #b 
from #a 

select *,case when (select top 1 aIntDepCode from CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<=   5=5   order by aIntAdjustTime desc) IS not null 
	then (select top 1 aIntDepCode from CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<=   5=5   order by aIntAdjustTime desc) else 记账部门 end cDepCode  
into #c from #b

select type,cCusCode,cSTCode,iMoney,记账日期,cPersonCode
	,case when (select top 1 aIntDepCode from CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<=   5=5   order by aIntAdjustTime desc) IS null 
		and (select top 1 DeptID from PersonAdjust where #c.cPersonCode=PersonAdjust.PersonCode and  aAdjAdjustTime<=   5=5   order by aAdjAdjustTime desc) is not null then
	(select top 1 DeptID from PersonAdjust where #c.cPersonCode=PersonAdjust.PersonCode and  aAdjAdjustTime<=   5=5   order by aAdjAdjustTime desc) else cDepCode end cDepCode 
into #d 
from #c 
where 1=1

";
            
        }

        public static string GetPerson(string endtime, string cCusCode, string cPersonCode)
        {
            return @"case when "+
            "(select top 1 aIntPPerson from CustomersAdjust "+
            "where " + cCusCode + "=aIntCode and  aIntAdjustTime<='" + endtime + "' order by aIntAdjustTime desc) IS not null " +
            "then (select top 1 aIntPPerson from CustomersAdjust " +
            "where " + cCusCode + "=aIntCode and  aIntAdjustTime<='" + endtime + "' order by aIntAdjustTime desc) else " + cPersonCode + " end cPersonCode";
        }

        public static string GetDept(string endtime, string cCusCode, string cDepCode)
        {
            return @"case when " +
            "(select top 1 aIntDepCode from CustomersAdjust " +
            "where " + cCusCode + "=aIntCode and  aIntAdjustTime<='" + endtime + "' order by aIntAdjustTime desc) IS not null " +
            "then (select top 1 aIntDepCode from CustomersAdjust " +
            "where " + cCusCode + "=aIntCode and  aIntAdjustTime<='" + endtime + "' order by aIntAdjustTime desc) else " + cDepCode + " end cDepCode";
        }


        public static DataTable Table(string starttime,string endtime, string cCusCode, string cPersonCode)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = GetSql();
            sSQL = sSQL.Replace(" 1=1 ", " 1=1 and a.dDate>='" + starttime + "' and a.dDate<='" + endtime + "' ");
            sSQL = sSQL.Replace(" 2=2 ", " 2=2 and Date1>='" + starttime + "' and Date1<='" + endtime + "' ");

            sSQL = sSQL.Replace("GetPerson", GetPerson(endtime, "a.cCusCode", "a.cPersonCode"));
            sSQL = sSQL.Replace("Get2Person", GetPerson(endtime, "AR_First.S1", "S3"));
            sSQL = sSQL.Replace("Get3Person", GetPerson(endtime, "a.cCusCode", "c.cPersonCode"));
            sSQL = sSQL.Replace("Get4Person", GetPerson(endtime, "a.cCusCode", "c.S3"));

            sSQL = sSQL.Replace("GetDept", GetDept(endtime, "p.cCusCode", "p.cPersonCode"));


            if (cCusCode != "")
            {
                sSQL = sSQL.Replace(" 4=4 ", " 4=4 and p.cCusCode='" + cCusCode + "' ");
            }
            if (cPersonCode != "")
            {
                sSQL = sSQL.Replace(" 4=4 ", " 4=4 and p.cPersonCode='" + cPersonCode + "' ");
            }
            return clsSQLCommond.ExecQuery(sSQL);
        }


        
        public static DataTable 账龄(string cCusCode, string ddate, string startdate, string enddate)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"

SELECT     1 as type,a.cCusCode, a.cSTCode, b.iMoney,a.dDate  into #a
FROM   SO_SOMain AS a LEFT OUTER JOIN SO_SODetails AS b ON a.ID = b.ID left join SOStatType st on a.cSTTCode=st.cSTTCode 
where 1=1 and a.dVerifysysTime is not null and st.B1=1 
and a.ID not in (select ID from SO_SOMainHistory where convert(nvarchar(10),HistoryTime,120)>5=5) 
    and 6=6
union all 
SELECT     11 as type,ss.cCusCode, ss.cSTCode, b.iMoney,ss.dDate  
FROM   SO_SOMainHistory AS a LEFT OUTER JOIN SO_SODetailsHistory AS b ON a.ID = b.ID and a.HistoryNum=b.HistoryNum 
left join (SELECT  a.ID,HistoryNum FROM SO_SOMain AS a left join 
(select ID,MAX(HistoryNum) as HistoryNum from SO_SOMainHistory where convert(nvarchar(10),HistoryTime,120)<=5=5 group by ID) b on a.ID=b.ID 
where 1=1 and a.dDate<=5=5 and a.dVerifysysTime is not null 
and a.ID in (select ID from SO_SOMainHistory where convert(nvarchar(10),HistoryTime,120)>5=5) and b.HistoryNum is not null) c on a.ID=c.ID and a.HistoryNum=c.HistoryNum 
left join SO_SOMain ss on a.ID=ss.ID 
where c.ID is not null and 6=6
union all 
SELECT     12 as type,a.cCusCode, a.cSTCode, b.iMoney,a.dDate 
FROM   SO_SOMain AS a LEFT OUTER JOIN SO_SODetails AS b ON a.ID = b.ID  where 1=1 and a.dVerifysysTime is not null 
and a.ID in (SELECT  a.ID FROM SO_SOMain AS a left join 
(select ID,MAX(HistoryNum) as HistoryNum from SO_SOMainHistory where convert(nvarchar(10),HistoryTime,120)<=5=5 group by ID) b on a.ID=b.ID 
where 1=1 and a.dDate<=5=5 and a.dVerifysysTime is not null 
and a.ID in (select ID from SO_SOMainHistory where convert(nvarchar(10),HistoryTime,120)>5=5) and b.HistoryNum is null) 
and 6=6
union all 
select 2 as type,a.cCusCode, cSTCode,b.iMoney,a.dDate  
from SO_SOReturn a left join SO_SOReturns b on a.ID=b.ID 
left join SO_SODetails c on b.SoAutoID=c.AutoID left join SO_SOMain d on c.ID=d.ID 
where 1=1 and a.dVerifysysTime is not null and 6=6
union all 
select 3 as type,S1 as cCusCode,S5 as cSTCode,D1 as iMoney,Date1 as  dDate 
from AR_First where 2=2 
union all 
select 4 as type,cCusCode,cSTCode,-iMoney,a.dDate 
from RdRecord a left join RdRecords b on a.ID=b.ID 
where 1=1 and cRSCode in ('05','06','07') and a.dVerifysysTime is not null and 6=6
union all
select 5 as type,a.cCusCode,a.cSTCode,-iMoneyNow,a.dDate 
from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
    left join SO_SOMain c on b.cTypeCode=c.cSOCode 
where 1=1 and iType=2  and a.dVerifysysTime is not null and 6=6
union all
select 6 as type,a.cCusCode,c.S5 as cSTCode,-iMoneyNow,a.dDate 
from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
    left join AR_First c on b.cTypeCode=c.iID 
where 1=1 and iType=1 and a.dVerifysysTime is not null and 6=6
union all
select 7 as type,cCusCode,cSTCode,b.iMoneyNow-a.iAmount,a.dDate 
from SO_CloseBill a left join (select ID,SUM(iMoneyNow) as iMoneyNow from SO_CloseBillDetails group by ID) b on a.ID=b.ID 
where b.iMoneyNow-a.iAmount<>0 and 1=1 and a.dVerifysysTime is not null and a.S1='1'and 6=6


SELECT     1 as type,a.cCusCode, a.cSTCode, b.iMoney,a.dDate into #b
FROM   SO_SOMain AS a LEFT OUTER JOIN SO_SODetails AS b ON a.ID = b.ID left join SOStatType st on a.cSTTCode=st.cSTTCode 
where 3=3 and a.dVerifysysTime is not null and st.B1=1 
and a.ID not in (select ID from SO_SOMainHistory where convert(nvarchar(10),HistoryTime,120)>5=5) and 6=6
union all 
SELECT     11 as type,ss.cCusCode, ss.cSTCode, b.iMoney,ss.dDate  
FROM   SO_SOMainHistory AS a LEFT OUTER JOIN SO_SODetailsHistory AS b ON a.ID = b.ID and a.HistoryNum=b.HistoryNum 
left join (SELECT  a.ID,HistoryNum FROM SO_SOMain AS a left join 
(select ID,MAX(HistoryNum) as HistoryNum from SO_SOMainHistory where convert(nvarchar(10),HistoryTime,120)<=5=5 group by ID) b on a.ID=b.ID 
where 3=3 and a.dDate<=5=5 and a.dVerifysysTime is not null 
and a.ID in (select ID from SO_SOMainHistory where convert(nvarchar(10),HistoryTime,120)>5=5) and b.HistoryNum is not null) c on a.ID=c.ID and a.HistoryNum=c.HistoryNum 
left join SO_SOMain ss on a.ID=ss.ID 
where c.ID is not null and 6=6
union all 
SELECT     12 as type,a.cCusCode, a.cSTCode, b.iMoney,a.dDate 
FROM   SO_SOMain AS a LEFT OUTER JOIN SO_SODetails AS b ON a.ID = b.ID  where 3=3 and a.dVerifysysTime is not null 
and a.ID in (SELECT  a.ID FROM SO_SOMain AS a left join 
(select ID,MAX(HistoryNum) as HistoryNum from SO_SOMainHistory where convert(nvarchar(10),HistoryTime,120)<=5=5 group by ID) b on a.ID=b.ID 
where 3=3 and a.dDate<=5=5 and a.dVerifysysTime is not null 
and a.ID in (select ID from SO_SOMainHistory where convert(nvarchar(10),HistoryTime,120)>5=5) and b.HistoryNum is null) and 6=6
union all 
select 2 as type,a.cCusCode, cSTCode,b.iMoney,a.dDate  
from SO_SOReturn a left join SO_SOReturns b on a.ID=b.ID 
    left join SO_SODetails c on b.SoAutoID=c.AutoID left join SO_SOMain d on c.ID=d.ID 
where 3=3 and a.dVerifysysTime is not null and 6=6
union all 
select 3 as type,S1 as cCusCode,S5 as cSTCode,D1 as iMoney,Date1 as  dDate 
from AR_First 
where 4=4 and 6=6
union all 
select 4 as type,cCusCode,cSTCode,-iMoney,a.dDate 
from RdRecord a left join RdRecords b on a.ID=b.ID 
where 3=3 and cRSCode in ('05','06','07') and a.dVerifysysTime is not null and 6=6
union all
select 5 as type,a.cCusCode,a.cSTCode,-iMoneyNow,a.dDate 
from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
left join SO_SOMain c on b.cTypeCode=c.cSOCode 
where 3=3 and iType=2  and a.dVerifysysTime is not null and 6=6
union all
select 6 as type,a.cCusCode,c.S5 as cSTCode,-iMoneyNow,a.dDate 
from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
    left join AR_First c on b.cTypeCode=c.iID 
where 3=3 and iType=1 and a.dVerifysysTime is not null and 6=6
union all
select 7 as type,cCusCode,cSTCode,b.iMoneyNow-a.iAmount,a.dDate 
from SO_CloseBill a left join (select ID,SUM(iMoneyNow) as iMoneyNow from SO_CloseBillDetails group by ID) b on a.ID=b.ID 
where b.iMoneyNow-a.iAmount<>0 and 3=3 and a.dVerifysysTime is not null and a.S1='1' and 6=6


select a.cCusCode,a.cSTCode,isnull(a.iMoney,0)-isnull(b.iMoney,0) iMoney 
from (select cCusCode,cSTCode,SUM(iMoney) as iMoney from  #a group by cCusCode,cSTCode) a
left join (select cCusCode,cSTCode,SUM(iMoney) as iMoney from  #b group by cCusCode,cSTCode) b  on a.cCusCode=b.cCusCode and a.cSTCode=b.cSTCode

";
            if (startdate != "")
            {
                sSQL = sSQL.Replace(" 3=3 ", " 3=3 and a.dDate>='" + enddate + "' ");
                sSQL = sSQL.Replace(" 4=4 ", " 4=4 and Date1>='" + enddate + "' ");
            }
            if (enddate != "")
            {
                
                sSQL = sSQL.Replace(" 1=1 ", " 1=1 and a.dDate<='" + startdate + "' ");
                sSQL = sSQL.Replace(" 2=2 ", " 2=2 and Date1<='" + startdate + "' ");
            }
            if (ddate != "")
            {
                sSQL = sSQL.Replace("5=5", " '" + ddate + "'  ");
            }
            if (cCusCode != "")
            {
                sSQL = sSQL.Replace(" 1=1 ", " 1=1 and cCusCode='" + cCusCode + "' ");
                sSQL = sSQL.Replace(" 2=2 ", " 2=2 and S1='" + cCusCode + "' ");
                sSQL = sSQL.Replace(" 6=6 ", " 2=2 and a.cCusCode='" + cCusCode + "' ");
            }
            

            //sSQL = sSQL.Replace("GetPerson", GetPerson(ddate, "a.cCusCode", "a.cPersonCode"));
            //sSQL = sSQL.Replace("Get2Person", GetPerson(ddate, "AR_First.S1", "S3"));
            //sSQL = sSQL.Replace("Get3Person", GetPerson(ddate, "a.cCusCode", "c.cPersonCode"));
            //sSQL = sSQL.Replace("Get4Person", GetPerson(ddate, "a.cCusCode", "c.S3"));

            //sSQL = sSQL.Replace("GetDept", GetDept(ddate, "p.cCusCode", "p.cPersonCode"));
            return clsSQLCommond.ExecQuery(sSQL);
        }

        
    }
}
