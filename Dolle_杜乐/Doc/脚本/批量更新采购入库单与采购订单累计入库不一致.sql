update PO_Podetails set PO_Podetails.freceivedqty = a.采购入库单数量
from 
(
	select a.cPOID as 采购订单号,b.id, b.iquantity 订单数量,b.iarrqty as 订单到货数量, b.freceivedqty as 订单合格入库,b.fPorefusequantity as 订单拒收数量
		,c.iQty as 到货单数量,c.iPOsID ,d.iQtyIn as 采购入库单数量
	from PO_Pomain a inner join PO_Podetails b on a.POID = b.poid 
		left join
		(
			select b.iPOsID ,sum(iquantity-isnull(fRefuseQuantity ,0)) as iQty
			from PU_ArrivalVouch a inner join PU_ArrivalVouchs b on a.id = b.id
			group by b.iPOsID
		)c on c.iPOsID = b.ID
		left join
		(
			select iPOsID ,sum(iQuantity) as iQtyIn
			from rdrecords01 
			group by iPOsID
		)d on d.iPOsID = b.id
	where 1=1
		--and a.cPOID = '2016P0124'
		and a.dPODate  >= '2015-1-1'
		and d.iQtyIn <> b.freceivedqty
)a
where a.id = PO_Podetails.id