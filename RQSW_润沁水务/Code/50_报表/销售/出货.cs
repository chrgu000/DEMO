using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 报表
{
    public static class 出货
    {
        public static DataTable Table(string sdate, string edate)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = GetSql(sdate, edate,"","");
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static DataTable Table(string sdate, string edate,string dept,string per)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = GetSql(sdate, edate,dept,per);
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static string GetSql(string sdate, string edate, string dept, string per)
        {
            string sSQL = @"
select a.* from (
select 0 as Type,1 as Flag,a.ID,null as HistoryID,a.cSOCode,a.cDepCode,a.cPersonCode,a.dDate as dDate,null as sHistoryID,b.cInvCode,b.iQuantity,b.iMoney,b.iSampleQuantity,a.D7 as 业务招待费,a.D3 as 利润,null as 个人利润,null as 收款利润 from SO_SOMain a left join SO_SODetails b on a.ID=b.ID left join 
(select ID,MAX(HistoryID) as HistoryID from SO_SOMainHistory group by ID) c on a.ID=c.ID where c.HistoryID is null and a.dVerifysysTime is not null 
union all
select 1 as Type,1 as Flag,a.ID,null as HistoryID,a.cSOCode,a.cDepCode,a.cPersonCode,convert(varchar(10),a.dDate,120) as dDate,f.HistoryID,b.cInvCode,f.iQuantity as iQuantity,f.iMoney as iMoney,f.iSampleQuantity,f.D7,f.D3,null,null as 收款利润 from SO_SOMain a left join SO_SODetails b on a.ID=b.ID 
left join (select a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120) as HistoryTime,max(a.D3) as D3,max(a.D7) as D7,SUM(b.iQuantity) as iQuantity,SUM(b.iMoney) as iMoney,SUM(b.iSampleQuantity) as iSampleQuantity,SUM(a.D6) AS D6 from SO_SOMainHistory a left join SO_SODetailsHistory b on a.HistoryId=b.HistoryId group by a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120)) f on a.ID=f.ID 
left join (select ID,min(HistoryID) as HistoryID from SO_SOMainHistory group by ID) d on a.ID=d.ID and f.HistoryID=d.HistoryID
where f.HistoryID is not null and d.HistoryID is not null and a.dVerifysysTime is not null 
union all
select 2 as Type,2 as Flag,a.ID,c.HistoryID,a.cSOCode,a.cDepCode,a.cPersonCode,f.HistoryTime,f.HistoryID,b.cInvCode,g.iQuantity-isnull(f.iQuantity,0) as iQuantity,
g.iMoney-isnull(f.iMoney,0) as iMoney,g.iSampleQuantity-isnull(f.iSampleQuantity,0) as iSampleQuantity,g.D7-ISNULL(f.D7,0) as D7,g.D3-ISNULL(f.D3,0) as D3,
case when convert(varchar(10),f.HistoryTime,120)>convert(varchar(10),a.Date1,120) then (g.D3-ISNULL(f.D3,0))*a.D2 end as D6,
case when convert(varchar(10),f.HistoryTime,120)>convert(varchar(10),a.Date1,120) then g.D3-ISNULL(f.D3,0) end as 收款利润 
from SO_SOMain a left join SO_SODetails b on a.ID=b.ID 
left join (
	select ID,HistoryID as HistoryID,
	(select MAX(HistoryID) as PreHistoryID from SO_SOMainHistory b 
	where a.HistoryID>b.HistoryId and a.ID=b.ID
	) as PreHistoryID from SO_SOMainHistory a
) c on a.ID=c.ID 
left join (select ID,MAX(HistoryID) as HistoryID from SO_SOMainHistory group by ID) d on a.ID=d.ID and c.HistoryID=d.HistoryID
left join (select a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120) as HistoryTime,max(a.D3) as D3,max(a.D7) as D7,SUM(b.iQuantity) as iQuantity,SUM(b.iMoney) as iMoney,SUM(b.iSampleQuantity) as iSampleQuantity,SUM(a.D6) AS D6 from SO_SOMainHistory a left join SO_SODetailsHistory b on a.HistoryId=b.HistoryId group by a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120)) f on PreHistoryID=f.HistoryID
left join (select a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120) as HistoryTime,max(a.D3) as D3,max(a.D7) as D7,SUM(b.iQuantity) as iQuantity,SUM(b.iMoney) as iMoney,SUM(b.iSampleQuantity) as iSampleQuantity,SUM(a.D6) AS D6 from SO_SOMainHistory a left join SO_SODetailsHistory b on a.HistoryId=b.HistoryId group by a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120)) g on c.HistoryID=g.HistoryID
where c.HistoryID is not null and f.HistoryID is not null and a.dVerifysysTime is not null 
union all
select 3 as Type,2 as Flag,a.ID,null as HistoryID,a.cSOCode,a.cDepCode,a.cPersonCode,HistoryTime,f.HistoryID,b.cInvCode,b.iQuantity-isnull(f.iQuantity,0) as iQuantity,
b.iMoney-isnull(f.iMoney,0) as iMoney,b.iSampleQuantity-isnull(f.iSampleQuantity,0) as iSampleQuantity,a.D7-ISNULL(f.D7,0) as D7,a.D3-ISNULL(f.D3,0) as D3,
case when convert(varchar(10),HistoryTime,120)>convert(varchar(10),a.Date1,120) then (a.D3-ISNULL(f.D3,0))*a.D2 end as D6,
case when convert(varchar(10),HistoryTime,120)>convert(varchar(10),a.Date1,120) then a.D3-ISNULL(f.D3,0) end as 收款利润 
from SO_SOMain a left join SO_SODetails b on a.ID=b.ID 
left join (
    select a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120) as HistoryTime,max(a.D3) as D3,max(a.D7) as D7,SUM(b.iQuantity) as iQuantity,SUM(b.iMoney) as iMoney,SUM(b.iSampleQuantity) as iSampleQuantity,SUM(a.D6) AS D6 
    from SO_SOMainHistory a left join SO_SODetailsHistory b on a.HistoryId=b.HistoryId 
    where 1=1
    group by a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120)) f on a.ID=f.ID 
left join (select ID,MAX(HistoryID) as HistoryID from SO_SOMainHistory group by ID) d on a.ID=d.ID and f.HistoryID=d.HistoryID
where f.HistoryID is not null and d.HistoryID is not null and a.dVerifysysTime is not null 
union all 
select 4 as type,1 as Flag,a.ID,null as HistoryID,a.cReCode,a.cDepCode,a.cPersonCode,a.dDate,null,b.cInvCode,b.iQuantity,b.iMoney,null as iSampleQuantity,null,null,null as 个人利润,null as 收款利润 from SO_SOReturn a left join SO_SOReturns b on a.ID=b.ID 
where a.dVerifysysTime is not null 
union all 
--B1 影响应收款 B2 影响出货量 B3 影响利润 B4 影响退回率 B5 影响样品率 B6 增加利润
select 5 as type,1 as Flag,a.ID,null as HistoryID,a.cRSCode,a.cDepCode,a.cPersonCode,a.dDate,null,b.cInvCode,
case when r.B2=1 then -b.iQuantity end iQuantity,case when B1=1 then -b.iMoney end as iMoney,null as iSampleQuantity,null,
case when B3=1 then -F5  when B6=1 then F5 end as 利润 ,
case when convert(varchar(10),a.dDate,120)>convert(varchar(10),p.Date1,120) then case when B3=1 then -F5*F4 when B3=1 then F5*F4 end end 个人利润,
case when convert(varchar(10),a.dDate,120)>convert(varchar(10),p.Date1,120) then case when B3=1 then -F5 when B3=1 then F5 end end as 收款利润  
from RdRecord a left join RdRecords b on a.ID=b.ID 
left join SO_SODetails s on a.SoAutoID=s.AutoID left join SO_SOMain p on s.ID=p.ID 
left join RdStyle r on a.cRSCode=r.cRSCode where 1=1 and 收发标志=0 and a.dVerifysysTime is not null
) a  left join Inventory i on a.cInvCode=i.cInvCode  
where  i.cInvClassCode not in ('0102','0104','03') and 2=2 

union all

    select a.* from (
select 10 as Type,1 as Flag,a.ID,null as HistoryID,a.cSOCode,a.cDepCode,a.cPersonCode,a.dDate as dDate,null as sHistoryID,b.cInvCode,null as iQuantity,null as iMoney,null as iSampleQuantity,null as 业务招待费,a.D3 as 利润,null as 个人利润,null as 收款利润 from SO_SOMain a left join SO_SODetails b on a.ID=b.ID left join 
(select ID,MAX(HistoryID) as HistoryID from SO_SOMainHistory group by ID) c on a.ID=c.ID where c.HistoryID is null and a.dVerifysysTime is not null 
union all
select 11 as Type,1 as Flag,a.ID,null as HistoryID,a.cSOCode,a.cDepCode,a.cPersonCode,convert(varchar(10),a.dDate,120) as dDate,f.HistoryID,b.cInvCode,null as iQuantity,null as iMoney,null as iSampleQuantity,null as 业务招待费,f.D3,null,null as 收款利润 from SO_SOMain a left join SO_SODetails b on a.ID=b.ID 
left join (select a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120) as HistoryTime,max(a.D3) as D3,max(a.D7) as D7,SUM(b.iQuantity) as iQuantity,SUM(b.iMoney) as iMoney,SUM(b.iSampleQuantity) as iSampleQuantity,SUM(a.D6) AS D6 from SO_SOMainHistory a left join SO_SODetailsHistory b on a.HistoryId=b.HistoryId group by a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120)) f on a.ID=f.ID 
left join (select ID,min(HistoryID) as HistoryID from SO_SOMainHistory group by ID) d on a.ID=d.ID and f.HistoryID=d.HistoryID
where f.HistoryID is not null and d.HistoryID is not null and a.dVerifysysTime is not null 
union all
select 12 as Type,2 as Flag,a.ID,c.HistoryID,a.cSOCode,a.cDepCode,a.cPersonCode,f.HistoryTime,f.HistoryID,b.cInvCode,null as iQuantity,null as iMoney,null as iSampleQuantity,null as 业务招待费,g.D3-ISNULL(f.D3,0) as D3,
case when convert(varchar(10),f.HistoryTime,120)>convert(varchar(10),a.Date1,120) then (g.D3-ISNULL(f.D3,0))*a.D2 end as D6,
case when convert(varchar(10),f.HistoryTime,120)>convert(varchar(10),a.Date1,120) then g.D3-ISNULL(f.D3,0) end as 收款利润 
from SO_SOMain a left join SO_SODetails b on a.ID=b.ID 
left join (
	select ID,HistoryID as HistoryID,
	(select MAX(HistoryID) as PreHistoryID from SO_SOMainHistory b 
	where a.HistoryID>b.HistoryId and a.ID=b.ID
	) as PreHistoryID from SO_SOMainHistory a
) c on a.ID=c.ID 
left join (select ID,MAX(HistoryID) as HistoryID from SO_SOMainHistory group by ID) d on a.ID=d.ID and c.HistoryID=d.HistoryID
left join (select a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120) as HistoryTime,max(a.D3) as D3,max(a.D7) as D7,SUM(b.iQuantity) as iQuantity,SUM(b.iMoney) as iMoney,SUM(b.iSampleQuantity) as iSampleQuantity,SUM(a.D6) AS D6 from SO_SOMainHistory a left join SO_SODetailsHistory b on a.HistoryId=b.HistoryId group by a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120)) f on PreHistoryID=f.HistoryID
left join (select a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120) as HistoryTime,max(a.D3) as D3,max(a.D7) as D7,SUM(b.iQuantity) as iQuantity,SUM(b.iMoney) as iMoney,SUM(b.iSampleQuantity) as iSampleQuantity,SUM(a.D6) AS D6 from SO_SOMainHistory a left join SO_SODetailsHistory b on a.HistoryId=b.HistoryId group by a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120)) g on c.HistoryID=g.HistoryID
where c.HistoryID is not null and f.HistoryID is not null and a.dVerifysysTime is not null 
union all
select 13 as Type,2 as Flag,a.ID,null as HistoryID,a.cSOCode,a.cDepCode,a.cPersonCode,HistoryTime,f.HistoryID,b.cInvCode,null as iQuantity,null as iMoney,null as iSampleQuantity,null as 业务招待费,a.D3-ISNULL(f.D3,0) as D3,
case when convert(varchar(10),HistoryTime,120)>convert(varchar(10),a.Date1,120) then (a.D3-ISNULL(f.D3,0))*a.D2 end as D6,
case when convert(varchar(10),HistoryTime,120)>convert(varchar(10),a.Date1,120) then a.D3-ISNULL(f.D3,0) end as 收款利润 
from SO_SOMain a left join SO_SODetails b on a.ID=b.ID 
left join (select a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120) as HistoryTime,max(a.D3) as D3,max(a.D7) as D7,SUM(b.iQuantity) as iQuantity,SUM(b.iMoney) as iMoney,SUM(b.iSampleQuantity) as iSampleQuantity,SUM(a.D6) AS D6 from SO_SOMainHistory a left join SO_SODetailsHistory b on a.HistoryId=b.HistoryId group by a.ID,a.HistoryID,convert(varchar(10),a.HistoryTime,120)) f on a.ID=f.ID 
left join (select ID,MAX(HistoryID) as HistoryID from SO_SOMainHistory group by ID) d on a.ID=d.ID and f.HistoryID=d.HistoryID
where f.HistoryID is not null and d.HistoryID is not null and a.dVerifysysTime is not null 
union all 
--B1 影响应收款 B2 影响出货量 B3 影响利润 B4 影响退回率 B5 影响样品率 B6 增加利润
select 5 as type,1 as Flag,a.ID,null as HistoryID,a.cRSCode,a.cDepCode,a.cPersonCode,a.dDate,null,b.cInvCode,
case when r.B2=1 then -b.iQuantity end iQuantity,case when B1=1 then -b.iMoney end as iMoney,null as iSampleQuantity,null,
case when B3=1 then -F5  when B6=1 then F5 end as 利润 ,
case when convert(varchar(10),a.dDate,120)>convert(varchar(10),p.Date1,120) then case when B3=1 then -F5*F4 when B3=1 then F5*F4 end end 个人利润,
case when convert(varchar(10),a.dDate,120)>convert(varchar(10),p.Date1,120) then case when B3=1 then -F5 when B3=1 then F5 end end as 收款利润  
from RdRecord a left join RdRecords b on a.ID=b.ID 
left join RdStyle r on a.cRSCode=r.cRSCode 
left join SO_SODetails s on a.SoAutoID=s.AutoID left join SO_SOMain p on s.ID=p.ID 
where 1=1 and 收发标志=0 and a.dVerifysysTime is not null
) a  left join Inventory i on a.cInvCode=i.cInvCode  
where  i.cInvClassCode in ('0102','0104','03') and 2=2 

union all 

select 6 as Type,1 as Flag,a.ID,null,a.cSOCode,a.cDepCode,a.cPersonCode,a.Date1,null,b.cInvCode,null as iQuantity,null as iMoney,null as iSampleQuantity,null as 业务招待费,null as D3,a.D4*a.D2 as D6,a.D4 as 收款利润  
from SO_SOMain a left join SO_SODetails b on a.ID=b.ID  where 1=1 and dVerifysysTime is not null and a.D4 <>0 and 3=3
";
            if (sdate != "")
            {
                sSQL = sSQL.Replace("2=2", "2=2 and dDate>= '" + DateTime.Parse(sdate).ToString("yyyy-MM-dd") + "'");
                sSQL = sSQL.Replace("3=3", "3=3 and a.Date1>= '" + DateTime.Parse(sdate).ToString("yyyy-MM-dd") + "'");
            }
            if (edate != "")
            {
                sSQL = sSQL.Replace("2=2", "2=2  and dDate<= '" + DateTime.Parse(edate).ToString("yyyy-MM-dd") + "'");
                sSQL = sSQL.Replace("3=3", "3=3  and a.Date1<= '" + DateTime.Parse(edate).ToString("yyyy-MM-dd") + "'");
            }
            if (dept != "")
            {
                sSQL = sSQL.Replace("2=2", "2=2 and cDepCode= '" + dept + "'");
                sSQL = sSQL.Replace("3=3", "3=3 and cDepCode= '" + dept + "'");
            }
            if (dept != "")
            {
                sSQL = sSQL.Replace("2=2", "2=2 and cPersonCode= '" + per + "'");
                sSQL = sSQL.Replace("3=3", "3=3 and cPersonCode= '" + per + "'");
            }
            sSQL = sSQL + " order by dDate";
            return sSQL;
        }


        public static DataTable Table出货利润(string sdate, string edate)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = GetSql出货利润(sdate, edate,"");
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static string GetSql出货利润(string sdate, string edate, string type)
        {    
            string sSQL = @"select cDepCode,cPersonCode,D3 as 出货利润 from SO_SOMain  where 1=1 and dVerifysysTime is not null";
            sSQL = sSQL.Replace("1=1", "1=1 and dDate>='" + sdate + "' and dDate<='" + edate + "'  ");
            if (type == "1")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and CusType='1' ");
            }
            return sSQL;
        }

        public static DataTable Table收款利润(string sdate, string edate)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cDepCode,cPersonCode,D4 as 收款利润,D6 as 个人利润 from SO_SOMain 
             where 1=1 and dVerifysysTime is not null";

            sSQL = sSQL.Replace("1=1", "1=1 and Date1>='" + sdate + "' and Date1<='" + edate + "'  ");
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static string GetSql出货变更(string sdate, string edate)
        {
            string sSQL = @"
select a.cDepCode,cPersonCode,a.cSOCode, c.iQuantity-ISNULL(b.iQuantity,0) as iQuantity, c.iMoney-ISNULL(b.iMoney,0) as iMoney  from SO_SOMainHistory a left join SO_SODetailsHistory b on a.ID = b.ID and a.HistoryNum=b.HistoryNum left join SO_SODetails c on b.AutoID=c.AutoID
where a.HistoryId in (
select MIN(HistoryId) as HistoryId from (
select HistoryId,ID from SO_SOMainHistory where 1=1 and ID not in (select ID from SO_SOMainHistory where 2=2) 
) a group by ID
) and c.iQuantity-ISNULL(b.iQuantity,0)<>0";

            sSQL = sSQL.Replace("1=1", "HistoryTime between '" + sdate + "' and '" + edate + "'");
            sSQL = sSQL.Replace("2=2", "HistoryTime>'" + edate + "'");
            
            return sSQL;
        }

        public static DataTable Table出货变更(string sdate, string edate)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = GetSql出货变更(sdate, edate);
            return clsSQLCommond.ExecQuery(sSQL);
        }

    }
}
