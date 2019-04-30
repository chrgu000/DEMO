USE [System_DEMO_WZYY]
GO



CREATE TABLE [dbo].[�ͻ�Э��ǼǱ�](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[iYear] [int] NOT NULL,
	[������] [nvarchar](50) NOT NULL,
	[dDate1] [datetime] NOT NULL,
	[dDate2] [datetime] NULL,
	[���㷽ʽ] [nvarchar](50) NULL,
	[Ʒ��] [nvarchar](50) NOT NULL,
	[�׼�] [decimal](18, 6) NULL,
	[Э������] [decimal](18, 6) NULL,
	[��֤��] [decimal](18, 6) NULL,
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
 CONSTRAINT [PK_�ͻ�Э��ǼǱ�] PRIMARY KEY CLUSTERED 
(
	[iYear] ASC,
	[������] ASC,
	[Ʒ��] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[���㷽ʽ](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[cCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_���㷽ʽ] PRIMARY KEY CLUSTERED 
(
	[cCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

go