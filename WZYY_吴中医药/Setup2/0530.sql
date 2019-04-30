USE [System_DEMO_WZYY]
GO



CREATE TABLE [dbo].[客户协议登记表](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[iYear] [int] NOT NULL,
	[代理商] [nvarchar](50) NOT NULL,
	[dDate1] [datetime] NOT NULL,
	[dDate2] [datetime] NULL,
	[返点方式] [nvarchar](50) NULL,
	[品种] [nvarchar](50) NOT NULL,
	[底价] [decimal](18, 6) NULL,
	[协议销量] [decimal](18, 6) NULL,
	[保证金] [decimal](18, 6) NULL,
	[M1] [decimal](18, 6) NULL,
	[M2] [decimal](18, 6) NULL,
	[M3] [decimal](18, 6) NULL,
	[M4] [decimal](18, 6) NULL,
	[M5] [decimal](18, 6) NULL,
	[M6] [decimal](18, 6) NULL,
	[M7] [decimal](18, 6) NULL,
	[M8] [decimal](18, 6) NULL,
	[M9] [decimal](18, 6) NULL,
	[M10] [decimal](18, 6) NULL,
	[M11] [decimal](18, 6) NULL,
	[M12] [decimal](18, 6) NULL,
	[CreateUid] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[AuditUid] [nvarchar](50) NULL,
	[AuditDate] [datetime] NULL,
 CONSTRAINT [PK_客户协议登记表] PRIMARY KEY CLUSTERED 
(
	[iYear] ASC,
	[代理商] ASC,
	[品种] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[返点方式](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[cCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_返点方式] PRIMARY KEY CLUSTERED 
(
	[cCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

go