
CREATE TABLE [dbo].[_��Ʒ������תͳ��](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[�������] [varchar](100) NOT NULL,
	[�ڼ�] [datetime] NOT NULL,
	[�ڳ�����] [decimal](18, 2) NULL,
	[�ڳ����] [decimal](18, 2) NULL,
	[��������] [decimal](18, 2) NULL,
	[���ý��] [decimal](18, 2) NULL,
	[�깤����] [decimal](18, 2) NULL,
	[�깤���] [decimal](18, 2) NULL,
	[��������] [decimal](18, 2) NULL,
	[���ƽ��] [decimal](18, 2) NULL,
 CONSTRAINT [PK__��Ʒ������תͳ��] PRIMARY KEY CLUSTERED 
(
	[�������] ASC,
	[�ڼ�] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]