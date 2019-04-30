-- 委外材料余额表期初 2018-02
select sum(iOriMoney) 
from
(
	-- 之前月 出库金额 - 之前月 累计核销金额 + 当月核销金额
	select RdRecords.cInvCode,sum(isnull(RdRecords.iQuantity,0) - isnull(RdRecords.iSQuantity,0) + isnull(tempTable1.iMSQuantity,0)) as iOriQuantity,
		sum(isnull(RdRecords.iPrice,0) - isnull(RdRecords.iSMaterialFee,0) + isnull(tempTable1.iMSPrice,0)) as iOriMoney 
	from RdRecord11 RdRecord with(nolock) 
		INNER JOIN RdRecords11 RdRecords with(nolock) ON RdRecord.ID=RdRecords.ID
		left join warehouse on rdrecord.cwhcode=warehouse.cwhcode 
		LEFT JOIN (
					select cVenCode,cInvCode,sum(isnull(iMSQuantity,0)) as iMSQuantity,sum(isnull(iMSPrice,0)) as iMSPrice,OM_MatSettleVouchs.irdsid 
					from OM_MatSettleVouch with(nolock) 
						left join OM_MatSettleVouchs with(nolock) on (OM_MatSettleVouch.MSID = OM_MatSettleVouchs.MSID)
					where cvouchtype=N'11' and OM_MatSettleVouch.dDate >='2018-02-01' and isnull(OM_MatSettleVouch.bbyproduct,0)=0 
					group by OM_MatSettleVouchs.irdsid,OM_MatSettleVouch.cVenCode,OM_MatSettleVouchs.cInvCode
				) as tempTable1 on RdRecords.AutoID = tempTable1.irdsid
	where cBusType in (N'委外发料',N'委外倒冲',N'委外盘点补差') AND cVouchType=N'11' 
		AND ((isnull(RdRecord.bOMFirst,0)=1) or (RdRecord.dDate>=N'2015-01-01' AND RdRecord.dDate<N'2018-02-01') )
	Group by RdRecords.cInvCode
) a
	
-- 本期发出 201802
select sum(Price)
from 
(
	-- 当月出库金额
	select RdRecord.cVenCode, RdRecords.cInvCode,
		sum(IsNULL(RdRecords.iQuantity,0)) AS Quantity, 
		Sum(IsNULL(RdRecords.iPrice,0)) AS Price
	FROM RdRecord11 RdRecord with(nolock) INNER JOIN RdRecords11 RdRecords with(nolock) ON RdRecord.ID = RdRecords.ID
	WHERE cBusType in (N'委外发料',N'委外倒冲',N'委外盘点补差') and (Rdrecord.dDate>=N'2015-01-01' AND RdRecord.cVouchType=N'11') AND (ISNULL(RdRecord.bOMFirst,0)=0) 
		and (dDate between N'2018-02-01' and N'2018-02-28')
	GROUP BY RdRecord.cVenCode,RdRecords.cInvCode
) a 


-- 本期收回 201802
select sum(iMSPrice)
from 
(
	-- 当月核销金额
	select  irdsid,sum(isnull(iMSPrice,0)) as iMSPrice
	from OM_MatSettleVouch with(nolock) 
		inner join OM_MatSettleVouchs with(nolock) on OM_MatSettleVouch.MSID = OM_MatSettleVouchs.MSID
		inner join rdrecords11 rdrecords with(nolock) on OM_MatSettleVouchs.irdsid = rdrecords.AutoID
		inner join rdrecord11 rdrecord with(nolock) on RdRecord.ID=RdRecords.ID 
	where OM_MatSettleVouchs.cvouchtype=N'11' AND ((Rdrecord.dDate>=N'2015-01-01') OR (isnull(RdRecord.bOMFirst,0)=1)) 
		AND (OM_MatSettleVouch.dDate Between N'2018-02-01' and N'2018-02-28') 
	GROUP BY irdsid
) a

--------------------
--------------------
--------------------
--------------------
--------------------

--select cInvCode,sum(iMSPrice) as iMSPrice,sum(imaterialfee) as imaterialfee
--from
--(
--	select  
--		--rdrecords.cInvCode,
--		sum(isnull(OM_MatSettleVouchs.iMSPrice,0)) as iMSPrice,sum(cast(iMSMaterialFee  as decimal(16,6))) as imaterialfee
--	from OM_MatSettleVouch with(nolock) 
--		inner join OM_MatSettleVouchs with(nolock) on OM_MatSettleVouch.MSID = OM_MatSettleVouchs.MSID
--	where OM_MatSettleVouchs.cvouchtype=N'11' 
--		AND (OM_MatSettleVouch.dDate Between N'2018-02-01' and N'2018-03-01') 
--	--GROUP BY rdrecords.cInvCode

--		 union 
	 
--	 select cInvCode   ,null
--		,sum(imaterialfee) as imaterialfee
--	 from IA_Subsidiary
--	 where iyear = 2018 and imonth = 2 and cMaterialHead  = '125101' and cPZdigest = '采购入库单'
--	 group by cInvCode  
-- ) a 
-- group by cInvCode 


-- select cvouchtype,OM_MatSettleVouchs.*
-- from OM_MatSettleVouch with(nolock) 
--		inner join OM_MatSettleVouchs with(nolock) on OM_MatSettleVouch.MSID = OM_MatSettleVouchs.MSID
--where OM_MatSettleVouch.cCode = '0000263094'



--select *
--from 
--(

--	select  
--		OM_MatSettleVouch.cCode,sum(isnull(OM_MatSettleVouchs.iMSPrice,0)) as iMSPrice
--	from OM_MatSettleVouch with(nolock) 
--		inner join OM_MatSettleVouchs with(nolock) on OM_MatSettleVouch.MSID = OM_MatSettleVouchs.MSID
--	where OM_MatSettleVouchs.cvouchtype=N'11' 
--		AND (OM_MatSettleVouch.dDate Between N'2018-02-01' and N'2018-03-01')
--	group by  OM_MatSettleVouch.cCode
--)a
-- left join
--(
--	select  OM_MatSettleVouch.cCode,sum(cast(iMSMaterialFee  as decimal(16,6))) as imaterialfee
--	from OM_MatSettleVouch with(nolock) 
--		inner join OM_MatSettleVouchs with(nolock) on OM_MatSettleVouch.MSID = OM_MatSettleVouchs.MSID
--	where OM_MatSettleVouchs.cvouchtype=N'01' 
--		AND (OM_MatSettleVouch.dDate Between N'2018-02-01' and N'2018-03-01') 
--	group by  OM_MatSettleVouch.cCode
--)b on a.cCode = b.cCode 
--where a.iMSPrice <> b.imaterialfee