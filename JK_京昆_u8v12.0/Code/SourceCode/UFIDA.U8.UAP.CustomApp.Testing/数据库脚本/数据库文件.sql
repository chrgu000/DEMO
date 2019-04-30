USE [UFDATA_100_2015]
GO

/****** Object:  Table [dbo].[_QC]    Script Date: 2015-05-06 13:29:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[_QC](
	[QCCode] [nvarchar](50) NOT NULL,
	[QCName] [nvarchar](50) NULL,
	[Remark] [nvarchar](500) NULL,
	[CreateUid] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUid] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK__QC] PRIMARY KEY CLUSTERED 
(
	[QCCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[_QCConclusion]    Script Date: 2015-05-06 13:29:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[_QCConclusion](
	[ID] [int] NOT NULL,
	[AutoID] [int] NOT NULL,
	[Conclusion] [int] NULL,
	[CreateUid] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUid] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[_QCResult]    Script Date: 2015-05-06 13:29:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[_QCResult](
	[ID] [int] NOT NULL,
	[AutoID] [int] NOT NULL,
	[QCCode] [nvarchar](50) NOT NULL,
	[Result] [nvarchar](500) NULL,
	[CreateUid] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUid] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK__QCResult] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[AutoID] ASC,
	[QCCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


