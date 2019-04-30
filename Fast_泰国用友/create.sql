if exists (select * from sysobjects where id = OBJECT_ID('[_GiveBackM]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_GiveBackM]

CREATE TABLE [_GiveBackM] (
[GUID] [uniqueidentifier]  NULL,
[iID] [int]  IDENTITY (1, 1)  NOT NULL,
[cCode] [varchar]  (50) NOT NULL,
[dDate] [datetime]  NULL,
[Person] [varchar]  (50) NULL,
[DepCode] [varchar]  (50) NULL,
[Remark] [varchar]  (50) NULL,
[CreateUserName] [varchar]  (50) NULL,
[CreateDate] [datetime]  NULL,
[AuditUserName] [varchar]  (50) NULL,
[AuditDate] [datetime]  NULL)

ALTER TABLE [_GiveBackM] WITH NOCHECK ADD  CONSTRAINT [PK__GiveBackM] PRIMARY KEY  NONCLUSTERED ( [cCode] )
SET IDENTITY_INSERT [_GiveBackM] ON

SET IDENTITY_INSERT [_GiveBackM] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[_GiveBackMs]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_GiveBackMs]

CREATE TABLE [_GiveBackMs] (
[GUIDHead] [uniqueidentifier]  NULL,
[iID] [int]  IDENTITY (1, 1)  NOT NULL,
[cCode] [varchar]  (50) NOT NULL,
[SerialNo] [varchar]  (50) NOT NULL,
[Remark] [varchar]  (200) NULL,
[MaintenancesiID] [int]  NULL,
[Times] [int]  NULL)

ALTER TABLE [_GiveBackMs] WITH NOCHECK ADD  CONSTRAINT [PK__GiveBackMs] PRIMARY KEY  NONCLUSTERED ( [cCode],[SerialNo] )
SET IDENTITY_INSERT [_GiveBackMs] ON

SET IDENTITY_INSERT [_GiveBackMs] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[_LookUpData]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_LookUpData]

CREATE TABLE [_LookUpData] (
[iType] [int]  NOT NULL,
[iID] [int]  NOT NULL,
[iText] [nvarchar]  (50) NULL)

ALTER TABLE [_LookUpData] WITH NOCHECK ADD  CONSTRAINT [PK__LookUpData] PRIMARY KEY  NONCLUSTERED ( [iType],[iID] )
INSERT [_LookUpData] ([iType],[iID],[iText]) VALUES ( 1,1,N'正常')
INSERT [_LookUpData] ([iType],[iID],[iText]) VALUES ( 1,2,N'领用')
INSERT [_LookUpData] ([iType],[iID],[iText]) VALUES ( 1,3,N'维修')
INSERT [_LookUpData] ([iType],[iID],[iText]) VALUES ( 1,4,N'报废')
if exists (select * from sysobjects where id = OBJECT_ID('[_Maintenance]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_Maintenance]

CREATE TABLE [_Maintenance] (
[GUID] [uniqueidentifier]  NULL,
[iID] [int]  IDENTITY (1, 1)  NOT NULL,
[cCode] [varchar]  (50) NOT NULL,
[dDate] [datetime]  NULL,
[Person] [varchar]  (50) NULL,
[DepCode] [varchar]  (50) NULL,
[Remark] [varchar]  (50) NULL,
[CreateUserName] [varchar]  (50) NULL,
[CreateDate] [datetime]  NULL,
[AuditUserName] [varchar]  (50) NULL,
[AuditDate] [datetime]  NULL)

ALTER TABLE [_Maintenance] WITH NOCHECK ADD  CONSTRAINT [PK__Maintenance] PRIMARY KEY  NONCLUSTERED ( [cCode] )
SET IDENTITY_INSERT [_Maintenance] ON


SET IDENTITY_INSERT [_Maintenance] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[_Maintenances]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_Maintenances]

CREATE TABLE [_Maintenances] (
[GUIDHead] [uniqueidentifier]  NULL,
[iID] [int]  IDENTITY (1, 1)  NOT NULL,
[cCode] [varchar]  (50) NOT NULL,
[SerialNo] [varchar]  (50) NOT NULL,
[Remark] [varchar]  (200) NULL)

ALTER TABLE [_Maintenances] WITH NOCHECK ADD  CONSTRAINT [PK__Maintenances] PRIMARY KEY  NONCLUSTERED ( [cCode],[SerialNo] )
SET IDENTITY_INSERT [_Maintenances] ON


SET IDENTITY_INSERT [_Maintenances] OFF
