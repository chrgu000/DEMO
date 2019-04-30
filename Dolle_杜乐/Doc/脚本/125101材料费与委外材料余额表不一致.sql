


-- 委外到票
select 
		sum(rds.iMaterialFee ),rd.cBusType
from Rdrecord01 rd inner join rdrecords01 rds on rd.id = rds.id
	inner join 
	(
		select b.*
		from PurBillVouch a inner join PurBillVouchs b on a.pbvid = b.pbvid 
		where a.cBusType = '委外加工'
			and a.dPBVDate >= '2017-01-01' and a.dPBVDate < '2017-02-01'
			--and a.dPBVDate < '2017-01-01'
	) c on rds.autoid = c.RdsID
where rd.dDate >= '2017-01-01' and rd.dDate < '2017-02-01'
	and rd.cBusType = '委外加工'
group by rd.cBusType

-- 委外未到票
select 
		sum(rds.iMaterialFee),rd.cBusType
from Rdrecord01 rd inner join rdrecords01 rds on rd.id = rds.id
where rd.dDate >= '2017-01-01' and rd.dDate < '2017-02-01'
	and rd.cBusType = '委外加工'
	and rds.autoid not in
	(
		select RdsID
		from PurBillVouch a inner join PurBillVouchs b on a.pbvid = b.pbvid 
		where a.cBusType = '委外加工'
			and a.dPBVDate < '2017-02-01'
	)
group by rd.cBusType


select 
	cPZdigest ,
	sum(imaterialfee )
from IA_Subsidiary
where iYear = 2017 and iMonth = '01'
	and cBusType = '委外加工'
group by cPZdigest

select  sum(ia.imaterialfee) as imaterialfee,ia.cPZdigest
	,sum(rds.imaterialfee) as rdsimaterialfee
from Rdrecord01 rd inner join rdrecords01 rds on rd.id = rds.id
	left join IA_Subsidiary ia on ia.id = rds.autoid
where  rd.dDate >= '2017-01-01' and rd.dDate < '2017-02-01'
	and rd.cBusType = '委外加工'  
	and ia.iYear = 2017 and ia.iMonth = '01'
	and ia.cBusType = '委外加工'
	--and rds.imaterialfee <> ia.imaterialfee
group by ia.cPZdigest


select sum(imaterialfee) as imaterialfee
from Ia_Subsidiary ia
where ia.iYear = 2017 and ia.iMonth = 1
	and ia.cBusType = '委外加工'

--  select 3084692.11 - 3063331.07 = 21361.04

select iIMoney ,iOMoney ,*
from IA_Summary 
where iyear = 2017 and imonth = 1 and cInvCode = 'WJD0003BARCEL0'
select iAInPrice ,iAOutPrice , *
from Ia_Subsidiary 
where iyear = 2017 and imonth = 1 and cInvCode = 'WJD0003BARCEL0'

select 	
		--a.cPBVCode,c.cCode ,a.dSDate ,a.dPBVDate , b.id,c.autoid ,b.cInvCode
		--	,b.iOriMoney,c.iPrice,ia.iAInPrice
	 	--sum(b.iOriMoney) as iOriMoney
		--,sum(c.iPrice) as iPrice,sum(ia.iAInPrice) as iAInPrice
		--,ia.*
from PurBillVouch a inner join PurBillVouchs b on a.pbvid = b.pbvid 
	inner join 		(
			select b.autoid,iPrice ,a.cCode,b.iQuantity,a.cBusType
			from RdRecord01 a inner join rdrecords01 b on a.id = b.id
			where cBusType = '委外加工'
				and a.dDate >= '2017-01-01' and a.dDate < '2017-02-01'	--	本月到票
				--and a.dDate < '2017-01-01'									--	蓝字回冲
		)c on b.RdsID = c.autoid 
	--left join  (
	--		select * from Ia_Subsidiary ia 
	--		where  ia.iyear = 2017 and ia.imonth = 1 and ia.cBusType = '委外加工' 
	--			--and ia.cPZdigest = '采购本月到票'
	--	) ia on c.autoid = ia.id 
where a.cBusType = '委外加工'
	and a.dPBVDate >= '2017-01-01' and a.dPBVDate < '2017-02-01'

--	select 1255059.26 - 783691.73 - 2279639.34


select sum(rds.iMaterialFee)
from Rdrecord01 rd inner join rdrecords01 rds on rd.id = rds.id
where rd.dDate >= '2017-01-01' and rd.dDate < '2017-02-01'
	and rd.cBusType = '委外加工'