

update sabills set sabills.cDefine27 = b.iPrice
from SaleBillVouch sabill inner join SaleBillVouchs sabills on sabill.SBVID = sabills.SBVID
	inner join
	(
		select b.SaleBillsID, sum(ia.iAInPrice) as iPrice
		from DispatchList dis inner join DispatchLists diss on dis.DLID = diss.DLID
			inner join IA_EnSubsidiary ia on diss.iDLsID = ia.idlsid  and dis.DLID = ia.cDLCode
			inner join [_DispatchLists_SaleBillVouchs] b on b.DLsID = diss.iDLsID
		and diss.iDLsID not in (select DLsid from [dbo].[_DispatchLists_SaleBillVouchs])
		group by b.SaleBillsID
	) b on sabills.AutoID = b.SaleBillsID
where sabill.dDate >= '2017-07-01' and sabill.dDate < '2017-08-01'


update sabills set sabills.cDefine27 = b.iPrice
from SaleBillVouch sabill inner join SaleBillVouchs sabills on sabill.SBVID = sabills.SBVID
	inner join
	(
		select diss.iDLsID, sum(ia.iAInPrice) as iPrice
		from DispatchList dis inner join DispatchLists diss on dis.DLID = diss.DLID
			inner join IA_EnSubsidiary ia on diss.iDLsID = ia.idlsid  and dis.DLID = ia.cDLCode
		and diss.iDLsID not in (select DLsid from [dbo].[_DispatchLists_SaleBillVouchs])
		group by diss.iDLsID
	) b on sabills.iDLsID = b.iDLsID
where sabill.dDate >= '2017-07-01' and sabill.dDate < '2017-08-01'
