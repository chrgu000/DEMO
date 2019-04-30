use [SysDB_RQSW]
go

set nocount on 

-- �����Ҫ�޸ĸ�����
update [dbo].[_TableColInfo] set TABLE_CATALOG = 'SysDB_RQSW' where TABLE_CATALOG = 'SysDB_RQSW_2013'

--  ��Ҫ������ͼ
--	Ӧ�տ���ϸ��,ͨ�����˽ű�ID�Բ��ϣ�SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID left join AR_First c on b.cTypeCode=c.iid
/*
Ӧ�տ���ϸ����Ҫ������������� AR_First

select 7 as type,a.cCusCode,a.cSTCode,-iMoneyNow,a.dDate
	,case when c.Date1 is null then d.Date1 else c.Date1 end as ��������
	,case when c.S3 is null then d.s3 else c.s3 end as ��������
	,case when c.S4 is null then d.S4 else c.s3 end as ���˲���
from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
	left join AR_First c on b.cTypeCode=c.iid 
	left join [SysDB_RQSW_2013_20170617]..AR_First d on b.cTypeCode=d.iid 
where 1=1 and a.dDate<=   '2017-06-18'    and iType=1  and a.dVerifysysTime is not null
	and cCusCode = '00016'
*/
/*�����


*/

if object_id(N'_Year',N'U') is not null drop table _Year
go

CREATE TABLE [dbo].[_Year](
	[iID] [int] NULL,
	[Year] [varchar](50) NOT NULL,
	[DataBasename] [varchar](50) NULL,
 CONSTRAINT [PK__Year] PRIMARY KEY CLUSTERED 
(
	[Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

go

Insert into _Year(iID,Year,DataBasename)
values(1,'��ǰ','SysDB_RQSW')
go

--	���ű�
--	Ĭ�ϱ����������ݣ�ÿ�����һ��
--	

declare @iYear int
set @iYear = '2015'
declare @dDate datetime
set @dDate = '2015-01-01'
declare @dDate2 datetime
set @dDate2 = '2014-12-31'

--���±� [dbo].[_Year] ���ӱ��������Ϣ

--������Ѿ���ɵ�����

--1. �ճ̵Ǽǣ�δ����
--	select * from [dbo].[�ճ̰���]

--2. �������룬δ����
--	select * from Employer

--3. ʵ�����룬δ����
--	select * from ExperimentApplications

--4. ����Ǽ� δ���ֱ������õط�
--	select * from Travel a inner join [Travels] b on a.iCode = b.iCodeHead 
delete Travels where iCodeHead in (select iCode from Travel where year(dDate) < @iYear)
delete Travel where year(dDate) < @iYear

--5. �����Կͻ��Ǽǣ�ҵ���ϱ���3����
--	select * from CustomersIntentionality where year(dDate) < @iYear
delete CustomersIntentionality where year(cIntRegDate) < @iYear

--6. �ͻ�����������˺�����ͻ�����
--	select * from CustomersAdjust
delete CustomersAdjust where year(dDate) < @iYear

--7. ��Ա����������˺������Ա����
--	select * from PersonAdjust
delete PersonAdjust where year(dDate) < @iYear

--8. ��ͬ�Ǽǣ�һ��û���٣�û����ᣩ
--	select * from Contract

--9. Ӧ���ڳ�����Ҫ�ص������
--drop table #c

SELECT     1 as type,cCusCode,cSTCode, iMoney,dDate,dDate as ��������,cPersonCode as ��������,cDepCode as ���˲��� 
into #a
FROM   SO_SOMain a left join  SO_SODetails b on a.ID=b.ID 
where 1=1  and a.dDate<  '2015-01-01'    and a.dVerifysysTime is not null 
 
insert into #a
select 2 as type,a.cCusCode, cSTCode,b.iMoney,a.dDate,d.dDate as ��������,d.cPersonCode as ��������,d.cDepCode as ���˲���
from SO_SOReturn a left join SO_SOReturns b on a.ID=b.ID 
	left join SO_SODetails c on b.SoAutoID=c.AutoID left join SO_SOMain d on c.ID=d.ID 
where 1=1 and a.dDate<  '2015-01-01'     
		and a.dVerifysysTime is not null 

insert into #a
select 4 as type,a.cCusCode,a.cSTCode,-b.iMoney,a.dDate,d.dDate as ��������,d.cPersonCode as ��������,d.cDepCode as ���˲���
from RdRecord a left join RdRecords b on a.ID=b.ID left join SO_SODetails c on a.SoAutoID=c.AutoID left join SO_SOMain d on c.ID=d.ID
    left join RdStyle on a.cRSCode=RdStyle.cRSCode  
where 1=1 and a.dDate<   '2015-01-01'     and RdStyle.B2=1 and RdStyle.S1=2  and a.dVerifysysTime is not null 
    
insert into #a
select 5 as type,a.cCusCode,a.cSTCode,-iMoneyNow,a.dDate,c.dDate as ��������,c.cPersonCode as ��������,c.cDepCode as ���˲���
from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
    left join SO_SOMain c on b.cTypeCode=c.cSOCode 
where 1=1 and a.dDate<   '2015-01-01'     and iType=2  and a.dVerifysysTime is not null 

insert into #a
select 9 as type, a.cCusCode,a.cSTCode,-a.iAmount+ISNULL(b.iMoneyNow,0) as iMoney,a.dDate,a.dDate as ��������,a.cPersonCode as ��������,a.cDepCode as ���˲��� 
from SO_CloseBill a left join (select ID,sum(iMoneyNow) as iMoneyNow from SO_CloseBillDetails group by ID) b on a.ID=b.ID 
where 1=1 and a.dDate<   '2015-01-01'   and a.dVerifysysTime is not null 


insert into #a
select 6 as type,S1 as cCusCode,S5 as cSTCode,D1 as iMoney,Date1 as  dDate ,Date1 as  ��������,S3 as ��������,S4 as ���˲���
from AR_First where 2=2 and Date1 <    '2015-01-01'  

insert into #a
select 7 as type,a.cCusCode,a.cSTCode,-iMoneyNow,a.dDate,c.Date1 as ��������,c.S3 as ��������,c.S4 as ���˲���
from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
left join AR_First c on b.cTypeCode=c.iid where 1=1 and a.dDate<    '2015-01-01'      and iType=1  and a.dVerifysysTime is not null

insert into #a
select 8 as type,a.cCusCode,a.cSTCode,-b.iMoney,a.dDate,f.Date1 as ��������,f.S3 as ��������,f.S4 as ���˲���
from RdRecord a left join RdRecords b on a.ID=b.ID
    left join RdStyle on a.cRSCode=RdStyle.cRSCode left join AR_First f on ARiID=f.iid   
where 1=1 and a.dDate<   '2015-01-01'      and RdStyle.B2=1 and RdStyle.S1=1  and a.dVerifysysTime is not null 

select *,case when (select top 1 aIntPPerson from CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<  '2015-01-01'    order by aIntAdjustTime desc) IS not null 
    then (select top 1 aIntPPerson from CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<   '2015-01-01'    order by aIntAdjustTime desc) 
    else �������� end cPersonCode 
into #b 
from #a 

select *
    ,case when (select top 1 aIntDepCode from CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<   '2015-01-01'   order by aIntAdjustTime desc) IS not null 
        then (select top 1 aIntDepCode from CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<   '2015-01-01'   order by aIntAdjustTime desc) 
        else ���˲��� end cDepCode  
into #c 
from #b

truncate table AR_First

insert into AR_First(s1,s3,s4,s5,d1,Date1,SysCreateDate)
select cCusCode,cPersonCode	,b.DeptID,cSTCode,CONVERT(decimal(18, 2),sum(iMoney)) as iMoney ,'2015-01-01','2015-01-01'
from #c left join person b on #c.cPersonCode = b.PersonCode
where 1=1   
group by cCusCode,cSTCode,cPersonCode ,b.DeptID
having CONVERT(decimal(18, 2),sum(iMoney))<>0




--10. �˻���
delete SO_SOReturns where ID in (
	select a.ID
	from SO_SOReturn a left join SO_SOReturns b on a.ID=b.ID 
		left join SO_SODetails c on b.SoAutoID=c.AutoID left join SO_SOMain d on c.ID=d.ID 
	where 1=1 and a.dDate<  '2015-01-01'     
		and a.dVerifysysTime is not null 
	)
delete SO_SOReturn where id not in (select id from SO_SOReturns)

--11. ���۳���
delete RdRecord where id in (
		select a.id
		from RdRecord a left join RdRecords b on a.ID=b.ID left join SO_SODetails c on a.SoAutoID=c.AutoID left join SO_SOMain d on c.ID=d.ID
			left join RdStyle on a.cRSCode=RdStyle.cRSCode  
		where 1=1 and a.dDate<   '2015-01-01'     and RdStyle.B2=1 and RdStyle.S1=2  and a.dVerifysysTime is not null 
	)
delete RdRecords where id not in (select id from RdRecord)

--12. �����տ
delete SO_CloseBillDetails where id in (
		select a.id
		from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
			left join SO_SOMain c on b.cTypeCode=c.cSOCode 
		where 1=1 and a.dDate<   '2015-01-01'     and iType=2  and a.dVerifysysTime is not null 
	)
delete SO_CloseBillDetails where id in (
		select a.id
		from SO_CloseBill a left join (select ID,sum(iMoneyNow) as iMoneyNow from SO_CloseBillDetails group by ID) b on a.ID=b.ID 
		where 1=1 and a.dDate<   '2015-01-01'   and a.dVerifysysTime is not null 
	)
delete SO_CloseBillDetails where id in (
		select a.id
		from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
		left join AR_First c on b.cTypeCode=c.iid where 1=1 and a.dDate<    '2015-01-01'      and iType=1  and a.dVerifysysTime is not null
	)
delete SO_CloseBill where id not in (select id from SO_CloseBillDetails)

-- 13. ����?
delete RdRecord where id in (
		select a.id
		from RdRecord a left join RdRecords b on a.ID=b.ID
			left join RdStyle on a.cRSCode=RdStyle.cRSCode left join AR_First f on ARiID=f.iid   
		where 1=1 and a.dDate<   '2015-01-01'      and RdStyle.B2=1 and RdStyle.S1=1  and a.dVerifysysTime is not null 
	)
delete RdRecords where id not in (select id from RdRecord)


-- 14. ���۶���
delete SO_SODetails where id in (select id from SO_SOMain where  dDate < '2015-01-01')
delete SO_SOMain where  dDate < '2015-01-01'


-- 15. ������
delete SaleVerifications where id in (select id from SaleVerification where dDate < '2015-01-01')
delete SaleVerification where dDate < '2015-01-01'



-- 16. ���۷�Ʊ
delete SaleBillVouchs where id in (select id from SaleBillVouch where dDate < '2015-01-01')
delete SaleBillVouch where dDate < '2015-01-01'

-- 17. ҵ���д�������(Ӷ������)
delete Commissions where id in (select id from Commission where dDate < '2015-01-01')
delete Commission where dDate < '2015-01-01'

-- 18. ҵ��������б�
delete OperationalCostsDetails where id in (select id from OperationalCosts where dDate < '2015-01-01')
delete OperationalCosts where dDate < '2015-01-01'

-- 19. ���۳��ⵥ
delete SO_SOOutDetails where id in (select id from SO_SOOutMain where dDate < '2015-01-01')
delete SO_SOOutSublist where id in (select id from SO_SOOutMain where dDate < '2015-01-01')
delete SO_SOOutMain where dDate < '2015-01-01'

-- 20. Ӧ���ڳ�
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#AP')) 
	drop table #AP

select p.cVenCode,p.cVenCode as cVenCode2,sum(isnull(p.iMoney,0)) as iMoney ,sum(iMoney2) as iMoney2 ,'2014-12-31' as date1,'2014-12-31' as syscreatedate
into #AP
from 
(
	SELECT    a.cVenCode,b.iMoney,a.dDate ,null as iMoney2
	FROM   PurBillVouch AS a LEFT OUTER JOIN PurBillVouchs AS b ON a.ID = b.ID  
	where 1=1 and a.dDate<='2014-12-31'  and a.dVerifysysTime is not null 
union all 
	select S1 as cVenCode,D1 as iMoney,Date1 as  dDate ,D2 as iMoney2
	from AP_First 
	where 2=2 and Date1 < '2015-01-01'  
union all 
	select cVenCode,-iAmount,dDate,-iAmount as iMoney2 
	from PO_CloseBill a 
	where 1=1 and a.dDate < '2015-01-01'   and dVerifysysTime is not null 
union all
	select d.cVenCode,null as imoney ,a.dDate, b.iMoney
	from dbo.RdRecord a inner join dbo.RdRecords b on a.id = b.id and a.cRdCode = b.cRDCode
		inner join dbo.PO_PODetails c on c.AutoID = b.POAutoID 
		inner join PO_POMain d on d.ID = c.ID
	where a.cRSCode = '01'
		and d.dDate < '2015-01-01'
) p where 4=4 
group by p.cVenCode 
having 1=1
	and (sum(isnull(p.iMoney,0))<>0 or sum(iMoney2) <> 0)
order by p.cVenCode

truncate table AP_First

insert into AP_First(s1,s2,d1,d2,date1,syscreatedate)
select * from #AP

-- 21. �ɹ����
delete RdRecords where autoid in 
(
	select b.autoid
	from dbo.RdRecord a inner join dbo.RdRecords b on a.id = b.id and a.cRdCode = b.cRDCode
		left join dbo.PO_PODetails c on c.AutoID = b.POAutoID 
		left join PO_POMain d on d.ID = c.ID
	where a.cRSCode = '01' and a.dDate < '2015-01-01'
)

delete RdRecord where id not in (select id from RdRecords)

-- 22. �ɹ���Ʊ
delete PurBillVouchs where id in (select id from PurBillVouch where  dDate < '2015-01-01')
delete PurBillVouch where  dDate < '2015-01-01'

-- 22. �ɹ�����
delete PO_CloseBillDetails where id in (select id from PO_CloseBill where  dDate < '2015-01-01')
delete PO_CloseBill where  dDate < '2015-01-01'

-- 23. �ɹ�����
delete [dbo].[PO_PODetails] where id in (select id from [dbo].[PO_POMain] where  dDate < '2015-01-01')
delete [dbo].[PO_POMain] where  dDate < '2015-01-01'

-- 24. ������ⵥ

delete rdrecord where dDate < '2015-1-1' and cRSCode<>'01'
delete rdrecords where id not in (select id from rdrecord)

