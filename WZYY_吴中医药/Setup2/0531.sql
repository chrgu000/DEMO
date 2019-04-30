USE [System_DEMO_WZYY]
GO

/****** Object:  Table [dbo].[�ͻ�Э��ǼǱ�]    Script Date: 2017/5/31 20:04:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[�ͻ�Э��ǼǱ�](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[GUID] [uniqueidentifier] NULL,
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

IF NOT EXISTS (   SELECT 1 FROM SYSOBJECTS T1   INNER JOIN SYSCOLUMNS T2 ON T1.ID=T2.ID  WHERE T1.NAME='�ͻ�Э��ǼǱ�' AND T2.NAME='GUID'   )
	alter table [dbo].[�ͻ�Э��ǼǱ�] add [GUID] uniqueidentifier
go



create view [dbo].[U8Person]
as 
select * 
from [192.168.150.121].[ufdata_200_2015].dbo.Person



