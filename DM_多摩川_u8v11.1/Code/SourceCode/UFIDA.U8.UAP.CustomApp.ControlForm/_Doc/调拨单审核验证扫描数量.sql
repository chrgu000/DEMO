

----------------------------------------------------------
------唐辉
------2014-9-4
------当调拨单数量与采集器扫描数量不一致时不允许审核
----------------------------------------------------------


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[CheckdTransVouchAudit]'))
DROP TRIGGER [dbo].[CheckdTransVouchAudit]
GO



create trigger [dbo].[CheckdTransVouchAudit] on [dbo].TransVouch
for update
as

set nocount on

declare @iCou int
set @iCou = 0

select @iCou = count(1)
from inserted a inner join TransVouchs b on a.ID = b.ID 
where ISNULL(a.cVerifyPerson,'') <> '' and isnull(b.iTVQuantity,0) <> isnull(cDefine29,0)

if(@iCou > 0)
begin
	RAISERROR ('扫描数量与单据数量不符,不能审核' , 16, 1) WITH NOWAIT
end

