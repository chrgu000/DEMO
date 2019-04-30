
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgr_rdrecords01]'))
DROP TRIGGER [dbo].[tgr_rdrecords01]
GO

create trigger [dbo].[tgr_rdrecords01]
on [dbo].[rdrecords01]
for insert,update
as 
	declare @cDefine27 decimal(18, 6)
	declare @AutoID nvarchar(50)
	select @cDefine27=isnull(cDefine27,0),@AutoID=AutoID from inserted  
	if @cDefine27 <> 0 
	begin
		update rdrecords01 set iQuantity=@cDefine27 where AutoID=@AutoID
	end
GO

IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgr_rdrecords08]'))
DROP TRIGGER [dbo].[tgr_rdrecords08]
GO

create trigger [dbo].[tgr_rdrecords08]
on [dbo].[rdrecords08]
for insert,update
as 
	declare @cDefine27 decimal(18, 6)
	declare @AutoID nvarchar(50)
	select @cDefine27=isnull(cDefine27,0),@AutoID=AutoID from inserted  
	if @cDefine27 <> 0 
	begin
		update rdrecords08 set iQuantity=@cDefine27 where AutoID=@AutoID
	end
GO

IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgr_rdrecords09]'))
DROP TRIGGER [dbo].[tgr_rdrecords09]
GO

create trigger [dbo].[tgr_rdrecords09]
on [dbo].[rdrecords09]
for insert,update
as 
	declare @cDefine27 decimal(18, 6)
	declare @AutoID nvarchar(50)
	select @cDefine27=isnull(cDefine27,0),@AutoID=AutoID from inserted  
	if @cDefine27 <> 0 
	begin
		update rdrecords09 set iQuantity=@cDefine27 where AutoID=@AutoID
	end

GO


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgr_rdrecords11]'))
DROP TRIGGER [dbo].[tgr_rdrecords11]
go

create trigger [dbo].[tgr_rdrecords11]
on [dbo].[rdrecords11]
for insert,update
as 
	declare @cDefine27 decimal(18, 6)
	declare @AutoID nvarchar(50)
	select @cDefine27=isnull(cDefine27,0),@AutoID=AutoID from inserted  
	if @cDefine27 <> 0 
	begin
		update rdrecords11 set iQuantity=@cDefine27 where AutoID=@AutoID
	end

GO
