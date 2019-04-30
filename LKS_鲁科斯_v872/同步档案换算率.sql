select inv.cInvCode,inv.cInvDefine14, com.iChangRate into Inventory20170727
--update inv set inv.cInvDefine14 = com.iChangRate
from Inventory inv inner join ComputationGroup comGroup on comGroup.cGroupCode = inv.cGroupCode
	inner  join ComputationUnit com on com.cGroupCode = comGroup.cGroupCode and  inv.cAssComUnitCode = com.cComunitCode
where isnull(cInvDefine14,0) = 0 and  isnull(inv.cInvDefine14,0) <> isnull(com.iChangRate,0)

