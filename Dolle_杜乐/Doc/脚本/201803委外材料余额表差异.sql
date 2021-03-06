
	-- 当月出库金额

select autoid,sum(Price) as Price,sum(iAoutPrice) as iAoutPrice
from
(
	select autoid
			,Sum(IsNULL(cast(RdRecords.iPrice as decimal(16,6)),0)) AS Price
			,cast(0 as decimal(16,6)) as iaoutprice
	FROM RdRecord11 RdRecord with(nolock) INNER JOIN RdRecords11 RdRecords with(nolock) ON RdRecord.ID = RdRecords.ID
	WHERE cBusType in (N'委外发料',N'委外倒冲',N'委外盘点补差') and (Rdrecord.dDate>=N'2015-01-01' AND RdRecord.cVouchType=N'11') AND (ISNULL(RdRecord.bOMFirst,0)=0) 
		and (dDate between N'2018-03-01' and N'2018-03-31') 
	GROUP BY autoid

	union all

	select id,0,sum(isnull(cast(iaoutprice as decimal(16,6)) ,0)) 
	from IA_Subsidiary
	where iyear = 2018 and imonth = 3 and cBusType = '委外发料' and cPZdigest = '材料出库单'
	group by id
) a
group by autoid
having sum(Price) <> sum(iAoutPrice)



select autoid,RdRecord.CCODE,ddate,dbKeepDate ,iprice
	,*
FROM RdRecord11 RdRecord with(nolock) INNER JOIN RdRecords11 RdRecords with(nolock) ON RdRecord.ID = RdRecords.ID
where autoid in (1004003885,1004003934)


select *
from IA_Subsidiary
where iyear = 2018 and imonth = 3 and cBusType = '委外发料' and cPZdigest = '材料出库单'
	and id in (1004003885,1004003934)



select rd.ccode, dbKeepDate,ddate
FROM RdRecord11 rd with(nolock) INNER JOIN RdRecords11 rds with(nolock) ON rd.ID = rds.ID
where ddate< '2018-04-01' and ddate >= '2015-01-01' and ( year(dbKeepDate) <> year(ddate) or  month(dbKeepDate) <> month(ddate))
order by ddate
	




