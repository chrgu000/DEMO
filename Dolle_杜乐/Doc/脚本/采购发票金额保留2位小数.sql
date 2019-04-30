


declare @PBVID int

select @PBVID = PBVID
from [dbo].[PurBillVouch]
where cPBVCode = '30220043/4'

select iOriMoney,iMoney,iOriSum ,iSum ,iOriTaxPrice ,iTaxPrice 
	,*
from [dbo].[PurBillVouchs]
WHERE   (PBVID = @PBVID)
	and  iOriSum <> iSum

-- 更新发票小数位
update [PurBillVouchs] set iOriMoney = cast(iOriMoney as decimal(16,2)) ,iMoney = cast(iMoney as decimal(16,2)) 
	,iOriSum = cast(iOriSum as decimal(16,2)) ,iSum = cast(iSum as decimal(16,2)) 
	,iOriTaxPrice =  cast(iOriSum as decimal(16,2))-cast(iOriMoney as decimal(16,2)) , iTaxPrice = cast(iSum as decimal(16,2)) - cast(iMoney as decimal(16,2)) 
where (PBVID = @PBVID)





