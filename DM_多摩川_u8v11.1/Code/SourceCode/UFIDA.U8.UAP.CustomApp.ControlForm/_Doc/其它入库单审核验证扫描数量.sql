

----------------------------------------------------------
------唐辉
------2014-9-20
------当其他入库单数量与采集器扫描数量不一致时不允许审核
----------------------------------------------------------


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[CheckdRecord08Audit]'))
DROP TRIGGER [dbo].[CheckdRecord08Audit]
GO



create trigger [dbo].[CheckdRecord08Audit] on [dbo].[RdRecord08]
for update
as

set nocount on

declare @iCou int
set @iCou = 0

select @iCou = count(1)
from inserted a inner join RdRecords08 b on a.ID = b.ID 
where ISNULL(a.cHandler ,'') <> '' and isnull(b.iQuantity,0) <> isnull(cDefine29,0)
	and isnull(a.cDefine1,'') = '是' 

if(@iCou > 0)
begin
	RAISERROR ('扫描数量与单据数量不符,不能审核' , 16, 1) WITH NOWAIT
end
