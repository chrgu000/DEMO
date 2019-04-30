
-- 1201 采购到票 
select 		
		--a.cPBVCode,c.cCode ,a.dSDate ,a.dPBVDate , b.id,c.autoid ,b.cInvCode
		--	,b.iOriMoney,c.iPrice,ia.iAInPrice
	 	sum(b.iOriMoney) as iOriMoney,sum(c.iPrice) as iPrice,sum(ia.iAInPrice) as iAInPrice
		--,ia.*
from PurBillVouch a inner join PurBillVouchs b on a.pbvid = b.pbvid 
	inner join 		(
			select b.autoid,iPrice ,a.cCode,b.iQuantity
			from RdRecord01 a inner join rdrecords01 b on a.id = b.id
			where cBusType = '普通采购'
				--and a.dDate >= '2017-01-01' and a.dDate < '2017-02-01'	--	本月到票
				and a.dDate < '2017-01-01'									--	蓝字回冲
		)c on b.RdsID = c.autoid 
	left join  (
			select * from Ia_Subsidiary ia 
			where  ia.iyear = 2017 and ia.imonth = 1 and ia.cBusType = '普通采购' 
				--and ia.cPZdigest = '采购本月到票'
		) ia on c.autoid = ia.id 
where a.cBusType = '普通采购'
	and a.dPBVDate >= '2017-01-01' and a.dPBVDate < '2017-02-01'
	--and b.iOriMoney <> isnull(ia.iAInPrice,0)

	and a.cPBVCode in ('00037069/70','PSI170100004','00381629')


select (a.iAInPrice) as iAInPrice,(rds.iPrice) as iPrice
from Ia_Subsidiary a
	left join rdrecords01 rds on a.id = rds.autoid
where a.iyear = 2017 and a.imonth = 1
	and a.cBusType = '普通采购'
	and a.cPZdigest = '蓝字回冲单'
	and a.iAInPrice <> rds.iPrice

select ID
from PurBillVouch a inner join PurBillVouchs b on a.pbvid = b.pbvid 




