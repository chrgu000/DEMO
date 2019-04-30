if not exists ( select *  from  sysobjects where name = '_GL_accvouch_FromERP' and type = 'U')
begin
	
	CREATE TABLE [dbo].[_GL_accvouch_FromERP](
		[iID] [int] IDENTITY(1,1) NOT NULL,
		[dDate] [datetime] NULL,
		[csign] [nvarchar](8) NULL,
		[ino_id] [int] NULL,
		[cdigest] [nvarchar](120) NULL,
		[ccode] [nvarchar](50) NULL,
		[ccode_equal] [nvarchar](50) NULL,
		[money] [money] NULL,
		[cexch_name] [nvarchar](50) NULL,
		[nfrat] [float] NULL,
		[Qty] [float] NULL,
		[cItem_id] [nvarchar](50) NULL,
		[cDepCode] [nvarchar](50) NULL,
		[cPersonCode] [nvarchar](50) NULL,
		[cCusCode] [nvarchar](50) NULL,
		[cVenCode] [nvarchar](50) NULL,
		[dtmCreate] [datetime] NULL,
		[sStatus] [int] NULL,
		[User_Load] [nvarchar](50) NULL,
		[dDate_Load] [datetime] NULL,
		[GL_accvouch_ino_id] [int] NULL,
		[GL_accvouch_csign] [nvarchar](8) NULL,
	 CONSTRAINT [PK__GL_accvouch_FromERP] PRIMARY KEY CLUSTERED 
	(
		[iID] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]



	ALTER TABLE [dbo].[_GL_accvouch_FromERP] ADD  CONSTRAINT [DF__GL_accvouch_FromERP_dtmCreate]  DEFAULT (getdate()) FOR [dtmCreate]
end 
go
-------------------
IF EXISTS(SELECT 1 FROM sys.views WHERE name='View_Customer')
	drop view View_Customer
go

create view View_Customer
as
	select cCusCode,cCusName from Customer 
go
--------------------------
IF EXISTS(SELECT 1 FROM sys.views WHERE name='View_Vendor')
	drop view View_Vendor
go
create view View_Vendor
as

select cVenCode,cVenName from Vendor 

go


--------------------------
IF EXISTS(SELECT 1 FROM sys.views WHERE name='View_Department')
	drop view View_Department
go
create view View_Department
as

select cDepCode,cDepName from Department 

go


--------------------------
IF EXISTS(SELECT 1 FROM sys.views WHERE name='View_code')
	drop view View_code
go
create view View_code
as

select ccode,ccode_name,bitem,bperson,bcus,bsup,bdept,bcash from code 

go


--------------------------
IF EXISTS(SELECT 1 FROM sys.views WHERE name='View_Pserson')
	drop view View_Pserson
go
create view View_Pserson
as

select cPersonCode,cPersonName from Person 

go

--------------------------
IF EXISTS(SELECT 1 FROM sys.views WHERE name='View_Foreigncurrency')
	drop view View_Foreigncurrency
go
create view View_Foreigncurrency
as

select cexch_code,cexch_name from Foreigncurrency 

go



