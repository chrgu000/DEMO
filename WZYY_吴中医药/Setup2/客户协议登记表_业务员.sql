USE [System_DEMO_WZYY]
GO

/****** Object:  Table [dbo].[客户协议登记表_业务员]    Script Date: 06/01/2017 11:03:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[客户协议登记表_业务员](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[cPersonCode] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NULL,
	[ENDDate] [date] NULL,
	[Remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_客户协议登记表_业务员] PRIMARY KEY CLUSTERED 
(
	[iID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


