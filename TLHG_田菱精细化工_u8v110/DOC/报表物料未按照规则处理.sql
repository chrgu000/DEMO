

select cInvDefine10,b.cidefine1
	,a.* 
from inventory a
	left join Inventory_extradefine b on a.cInvCode = b.cInvCode
where a.cinvcode like '9%' and cInvCCode <> '999'
	and (ISNULL(cInvDefine10,'') = '' or ISNULL(b.cidefine1,'') = '')
	
	
select * from UFDATA_102_2014..inventory where cinvcode not in (select cInvCode from UFDATA_101_2013..inventory where cinvcode like '9%' and cInvCCode <> '999')
	and cinvcode like '9%' and cInvCCode <> '999'


select * from UFDATA_103_2014..inventory where cinvcode not in (select cInvCode from UFDATA_101_2013..inventory where cinvcode like '9%' and cInvCCode <> '999')
	and cinvcode like '9%' and cInvCCode <> '999'

select * from UFDATA_104_2014..inventory where cinvcode not in (select cInvCode from UFDATA_101_2013..inventory where cinvcode like '9%' and cInvCCode <> '999')
	and cinvcode like '9%' and cInvCCode <> '999'
	

select * from UFDATA_201_2014..inventory where cinvcode not in (select cInvCode from UFDATA_101_2013..inventory where cinvcode like '9%' and cInvCCode <> '999')
	and cinvcode like '9%' and cInvCCode <> '999'