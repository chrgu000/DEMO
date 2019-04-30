select * from DispatchList where cDLCode='DN-201701390' order by dDate desc

select * from DispatchLists where DLID=1000001647  order by DLID desc

select cast(0 as bit) as choose,b.cDefine29 as item,a.DLID,a.cDLCode,a.cDepCode,a.cPersonCode,a.cSOCode,a.cexch_name
,b.iTaxRate,a.iExchRate,b.iInvExchRate,b.cUnitID,b.cinvcode,i.cInvName,c.cCusName,b.cWhCode
,sum(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0))  as UniQty,sum(isnull(b.iNum,0) - isnull(iSettleNum,0))  as UniNum
,SUM(b.iSum*(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0))) as iSum
,CONVERT(decimal(16,6),null) as NewQty
,a.cDefine1,a.cDefine2,a.cDefine3,a.cDefine4,a.cDefine5,a.cDefine6,a.cDefine7,a.cDefine8,a.cDefine9,a.cDefine10
,a.cDefine11,a.cDefine12,a.cDefine13,a.cDefine14,a.cDefine15,a.cDefine16
--,b.cDefine22,b.cDefine23,b.cDefine24,b.cDefine25,b.cDefine26,b.cDefine27,b.cDefine28,b.cDefine30
--,b.cDefine31,b.cDefine32,b.cDefine33,b.cDefine34,b.cDefine35,b.cDefine36,b.cDefine37  
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
left join Inventory i on b.cInvCode=i.cInvCode
LEFT JOIN Person P ON a.cPersonCode=p.cPersonCode
left join Customer c on a.cCusCode=c.cCusCode
where 1=1 and isnull(b.cDefine29,'')<>'' and isnull(b.cSCloser,'') = '' and isnull(a.cCloser,'') = ''  and isnull(a.cVerifier,'') <> '' 
--and a.cDLCode='DN-201701390' --and b.cInvCode='80000015'
group by a.DLID,a.cDLCode,a.cDepCode,a.cPersonCode,a.cSOCode,a.cexch_name
,b.iTaxRate,a.iExchRate,b.iInvExchRate,b.cUnitID,b.cinvcode,i.cInvName,c.cCusName,b.cWhCode
,a.cDefine1,a.cDefine2,a.cDefine3,a.cDefine4,a.cDefine5,a.cDefine6,a.cDefine7,a.cDefine8,a.cDefine9,a.cDefine10
,a.cDefine11,a.cDefine12,a.cDefine13,a.cDefine14,a.cDefine15,a.cDefine16
,b.cDefine29
--,b.cDefine22,b.cDefine23,b.cDefine24,b.cDefine25,b.cDefine26,b.cDefine27,b.cDefine28,b.cDefine29,b.cDefine30
--,b.cDefine31,b.cDefine32,b.cDefine33,b.cDefine34,b.cDefine35,b.cDefine36,b.cDefine37
having sum(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0)) >0 --and SUM(b.iSum*(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0)))>0
order by a.cDLCode,a.DLID

--select * From VoucherHistory  with (NOLOCK) Where  CardNumber='13' and cContent='单据日期' and cSeed='2014'

select cCusName,* from SaleBillVouch where SBVID=1000001094 order by SBVID desc
select * from SaleBillVouchs  order by SBVID desc

--SELECT iFatherId,iChildId FROM UFSystem..UA_Identity WHERE cAcc_Id = 101 AND cVouchType = 'BILLVOUCH'