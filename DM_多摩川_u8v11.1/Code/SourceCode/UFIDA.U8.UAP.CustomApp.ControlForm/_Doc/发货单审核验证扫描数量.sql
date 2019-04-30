





----------------------------------------------------------
------唐辉
------2014-9-4
------当销售发货单数量与采集器扫描数量不一致时不允许审核
----------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[CheckdDispatchListAudit]'))
DROP TRIGGER [dbo].[CheckdDispatchListAudit]
GO



create trigger [dbo].[CheckdDispatchListAudit] on [dbo].[DispatchList]
for update
as

set nocount on

declare @iCou int
set @iCou = 0

select @iCou = count(1)
from inserted a inner join [DispatchLists] b on a.DLID = b.DLID 
where ISNULL(a.cVerifier ,'') <> '' and isnull(b.iQuantity,0) <> isnull(cDefine31,0)

if(@iCou > 0)
begin
	RAISERROR ('扫描数量与单据数量不符,不能审核' , 16, 1) WITH NOWAIT
end






