


select b.cInvCode as 货号,cast(b.iQuantity as decimal(16,2)) as 数量, isnull(com.cComUnitName,'') as 计量单位,isnull(inv.cAddress,'') as 原产国  ,isnull(inv.cInvDefine13,'') as 重量 ,isnull(b.ioriSum,'') as 货值,isnull(cExch_Name,'') as 币制, CONVERT(char(10),b.dVDate, 120)  as [保质截止日（yyyy-mm-dd）],isnull(b.cbMemo,'') as 货物备注 
from rdrecord01 a inner join rdrecords01 b on a.id = b.id
	inner join Inventory inv on b.cInvCode = inv.cInvCode
	inner join ComputationUnit com on com.cComunitCode = inv.cComunitCode 
where a.cCode = 'IP16110006'
order by b.autoid
