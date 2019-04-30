

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[开发默认值表]') AND type in (N'U')) 
	DROP TABLE [dbo].[开发默认值表]

CREATE TABLE [dbo].[开发默认值表](
	[iType] [varchar](50) NOT NULL,
	[s1] [varchar](50) NOT NULL,
	[s2] [varchar](50) NULL,
	[s3] [varchar](50) NULL,
	[s4] [varchar](50) NULL,
	[备注] [varchar](200) NULL
)

insert into 开发默认值表(iType,s1,备注) values(1,'导出摘要','摘要默认')
insert into 开发默认值表(iType,s1,备注) values(2,'1002010103','表头科目默认')
insert into 开发默认值表(iType,s1,备注) values(3,'102901000001','表体科目默认')