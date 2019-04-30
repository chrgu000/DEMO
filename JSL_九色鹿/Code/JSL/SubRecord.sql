USE [XWSystemDB_JSL]
GO

/****** Object:  Table [dbo].[InventoryContrast]    Script Date: 2018/5/8 1:25:26 ******/
SET ANSI_NULLS ON
GO


SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InventoryContrast](
	[iID] [int] NOT NULL,
	[cInvCode] [nvarchar](50) NOT NULL,
	[M1] [nchar](10) NULL,
	[cInvNewCode] [nvarchar](50) NULL,
	[cInvNewName] [nvarchar](50) NULL,
	[M1New] [nvarchar](50) NULL,
	[Remark] [nvarchar](500) NULL,
	[SysCreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_InventoryContrast] PRIMARY KEY CLUSTERED 
(
	[iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SubRecord01]    Script Date: 2018/5/8 1:25:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubRecord01](
	[ID] [int] NOT NULL,
	[cSubCode] [nvarchar](50) NULL,
	[dDate] [datetime] NULL,
	[cPersonCode] [nvarchar](50) NULL,
	[cOperator] [nvarchar](50) NULL,
	[cDepCode] [nvarchar](50) NULL,
	[cWhCode] [nvarchar](50) NULL,
	[cCusCode] [nvarchar](50) NULL,
	[cVenCode] [nvarchar](50) NULL,
	[cMemo] [nvarchar](500) NULL,
	[Flag] [nvarchar](50) NULL,
	[cRSCode] [nvarchar](50) NULL,
	[cRdPersonCode] [nvarchar](50) NULL,
	[dCreatesysPerson] [nvarchar](50) NULL,
	[dCreatesysTime] [datetime] NULL,
	[dVerifysysPerson] [nvarchar](50) NULL,
	[dVerifysysTime] [datetime] NULL,
	[dClosesysPerson] [nvarchar](50) NULL,
	[dClosesysTime] [datetime] NULL,
	[dChangeVerifyPerson] [nvarchar](50) NULL,
	[dChangeVerifyTime] [datetime] NULL,
	[SysCreateDate] [datetime] NULL,
	[cSTCode] [nvarchar](50) NULL,
	[ARiID] [int] NULL,
	[PrintCount] [int] NULL,
	[LastPrintDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_SubRecord01] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SubRecord01History]    Script Date: 2018/5/8 1:25:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubRecord01History](
	[HistoryId] [int] NOT NULL,
	[HistoryTime] [datetime] NULL,
	[HistoryNum] [int] NULL,
	[ID] [int] NULL,
	[cSubCode] [nvarchar](50) NULL,
	[dDate] [datetime] NULL,
	[cPersonCode] [nvarchar](50) NULL,
	[cOperator] [nvarchar](50) NULL,
	[cDepCode] [nvarchar](50) NULL,
	[cWhCode] [nvarchar](50) NULL,
	[cCusCode] [nvarchar](50) NULL,
	[cVenCode] [nvarchar](50) NULL,
	[cMemo] [nvarchar](500) NULL,
	[Flag] [nvarchar](50) NULL,
	[cRSCode] [nvarchar](50) NULL,
	[cRdPersonCode] [nvarchar](50) NULL,
	[dCreatesysPerson] [nvarchar](50) NULL,
	[dCreatesysTime] [datetime] NULL,
	[dVerifysysPerson] [nvarchar](50) NULL,
	[dVerifysysTime] [datetime] NULL,
	[dClosesysPerson] [nvarchar](50) NULL,
	[dClosesysTime] [datetime] NULL,
	[dChangeVerifyPerson] [nvarchar](50) NULL,
	[dChangeVerifyTime] [datetime] NULL,
	[SysCreateDate] [datetime] NULL,
	[PrintCount] [int] NULL,
	[LastPrintDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SubRecord11]    Script Date: 2018/5/8 1:25:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubRecord11](
	[ID] [int] NOT NULL,
	[cSubCode] [nvarchar](50) NULL,
	[dDate] [datetime] NULL,
	[cPersonCode] [nvarchar](50) NULL,
	[cOperator] [nvarchar](50) NULL,
	[cDepCode] [nvarchar](50) NULL,
	[cWhCode] [nvarchar](50) NULL,
	[cCusCode] [nvarchar](50) NULL,
	[cVenCode] [nvarchar](50) NULL,
	[cMemo] [nvarchar](500) NULL,
	[Flag] [nvarchar](50) NULL,
	[cRSCode] [nvarchar](50) NULL,
	[cRdPersonCode] [nvarchar](50) NULL,
	[dCreatesysPerson] [nvarchar](50) NULL,
	[dCreatesysTime] [datetime] NULL,
	[dVerifysysPerson] [nvarchar](50) NULL,
	[dVerifysysTime] [datetime] NULL,
	[dClosesysPerson] [nvarchar](50) NULL,
	[dClosesysTime] [datetime] NULL,
	[dChangeVerifyPerson] [nvarchar](50) NULL,
	[dChangeVerifyTime] [datetime] NULL,
	[SysCreateDate] [datetime] NULL,
	[PrintCount] [int] NULL,
	[LastPrintDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_SubRecord11] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SubRecord11History]    Script Date: 2018/5/8 1:25:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubRecord11History](
	[HistoryId] [int] NOT NULL,
	[HistoryTime] [datetime] NULL,
	[HistoryNum] [int] NULL,
	[ID] [int] NULL,
	[cSubCode] [nvarchar](50) NULL,
	[dDate] [datetime] NULL,
	[cPersonCode] [nvarchar](50) NULL,
	[cOperator] [nvarchar](50) NULL,
	[cDepCode] [nvarchar](50) NULL,
	[cWhCode] [nvarchar](50) NULL,
	[cCusCode] [nvarchar](50) NULL,
	[cVenCode] [nvarchar](50) NULL,
	[cMemo] [nvarchar](500) NULL,
	[Flag] [nvarchar](50) NULL,
	[cRSCode] [nvarchar](50) NULL,
	[cRdPersonCode] [nvarchar](50) NULL,
	[dCreatesysPerson] [nvarchar](50) NULL,
	[dCreatesysTime] [datetime] NULL,
	[dVerifysysPerson] [nvarchar](50) NULL,
	[dVerifysysTime] [datetime] NULL,
	[dClosesysPerson] [nvarchar](50) NULL,
	[dClosesysTime] [datetime] NULL,
	[dChangeVerifyPerson] [nvarchar](50) NULL,
	[dChangeVerifyTime] [datetime] NULL,
	[SysCreateDate] [datetime] NULL,
	[PrintCount] [int] NULL,
	[LastPrintDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SubRecords01]    Script Date: 2018/5/8 1:25:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubRecords01](
	[AutoID] [int] NOT NULL,
	[ID] [int] NULL,
	[iRowNo] [int] NULL,
	[cSubCode] [nvarchar](50) NULL,
	[cInvCode] [nvarchar](50) NOT NULL,
	[M1] [nvarchar](50) NULL,
	[M2] [nvarchar](50) NULL,
	[sBoxNo] [nvarchar](50) NULL,
	[iQty] [decimal](18, 6) NULL,
	[iSubQty] [int] NULL,
	[iUnitQty] [decimal](18, 6) NULL,
	[OutiQty] [decimal](16, 6) NULL,
	[OutiSubQty] [int] NULL,
	[cClosesysPerson] [nvarchar](50) NULL,
	[cClosesysTime] [datetime] NULL,
	[cMemo] [nvarchar](60) NULL,
	[RdAutoID] [int] NULL,
	[SysCreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_SubRecords01] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SubRecords01History]    Script Date: 2018/5/8 1:25:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubRecords01History](
	[HistoryId] [int] NOT NULL,
	[HistoryTime] [datetime] NULL,
	[HistoryNum] [int] NULL,
	[AutoID] [int] NOT NULL,
	[ID] [int] NULL,
	[iRowNo] [int] NULL,
	[cSubCode] [nvarchar](50) NULL,
	[cInvCode] [nvarchar](50) NOT NULL,
	[M1] [nvarchar](50) NULL,
	[M2] [nvarchar](50) NULL,
	[sBoxNo] [nvarchar](50) NULL,
	[iQty] [decimal](18, 6) NULL,
	[iSubQty] [int] NULL,
	[iUnitQty] [decimal](18, 6) NULL,
	[OutiQty] [decimal](16, 6) NULL,
	[OutiSubQty] [int] NULL,
	[cClosesysPerson] [nvarchar](50) NULL,
	[cClosesysTime] [datetime] NULL,
	[cMemo] [nvarchar](60) NULL,
	[RdAutoID] [int] NULL,
	[SysCreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SubRecords11]    Script Date: 2018/5/8 1:25:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubRecords11](
	[AutoID] [int] NOT NULL,
	[ID] [int] NULL,
	[iRowNo] [int] NULL,
	[cSubCode] [nvarchar](50) NULL,
	[cInvCode] [nvarchar](50) NOT NULL,
	[M1] [nvarchar](50) NULL,
	[M2] [nvarchar](50) NULL,
	[sBoxNo] [nvarchar](50) NULL,
	[iQty] [decimal](18, 6) NULL,
	[iSubQty] [int] NULL,
	[iUnitQty] [decimal](18, 6) NULL,
	[iImport] [int] NULL,
	[cClosesysPerson] [nvarchar](50) NULL,
	[cClosesysTime] [datetime] NULL,
	[cMemo] [nvarchar](60) NULL,
	[SubAutoID] [int] NULL,
	[SysCreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_SubRecords11] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SubRecords11History]    Script Date: 2018/5/8 1:25:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubRecords11History](
	[HistoryId] [int] NOT NULL,
	[HistoryTime] [datetime] NULL,
	[HistoryNum] [int] NULL,
	[AutoID] [int] NOT NULL,
	[ID] [int] NULL,
	[iRowNo] [int] NULL,
	[cSubCode] [nvarchar](50) NULL,
	[cInvCode] [nvarchar](50) NOT NULL,
	[M1] [nvarchar](50) NULL,
	[M2] [nvarchar](50) NULL,
	[sBoxNo] [nvarchar](50) NULL,
	[iQty] [decimal](18, 6) NULL,
	[iSubQty] [int] NULL,
	[iUnitQty] [decimal](18, 6) NULL,
	[iImport] [int] NULL,
	[cClosesysPerson] [nvarchar](50) NULL,
	[cClosesysTime] [datetime] NULL,
	[cMemo] [nvarchar](60) NULL,
	[SubAutoID] [int] NULL,
	[SysCreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[InventoryContrast] ADD  CONSTRAINT [DF_InventoryContrast_SysCreateDate]  DEFAULT (getdate()) FOR [SysCreateDate]
GO


