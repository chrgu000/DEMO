

----------------------------------------------------------
------�ƻ�
------2014-9-4
------�����ϳ��ⵥ������ɼ���ɨ��������һ��ʱ���������
----------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[CheckdRecord11Audit]'))
DROP TRIGGER [dbo].[CheckdRecord11Audit]
GO

CREATE trigger [dbo].[CheckdRecord11Audit] on [dbo].[rdrecord11]
for update
as

set nocount on

declare @iCou int
set @iCou = 0

select @iCou = count(1)
from inserted a inner join RdRecords11 b on a.ID = b.ID 
where ISNULL(a.cHandler ,'') <> '' and isnull(b.iQuantity,0) <> isnull(cDefine29,0)

if(@iCou > 0)
begin
	RAISERROR ('ɨ�������뵥����������,�������' , 16, 1) WITH NOWAIT
end

