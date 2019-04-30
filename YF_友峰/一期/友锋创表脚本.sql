
use UFDATA_333_2016
go


IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[������ⵥ����]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table ������ⵥ����

CREATE TABLE [dbo].[������ⵥ����](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[��ⵥ��] [varchar](50) NOT NULL,
	[�к�] [int] NOT NULL,
	[�������] [varchar](50) NOT NULL,
	[����] [varchar](50) NOT NULL,
	[�������] [varchar](50) NULL,
	[���] [decimal](18, 6) NULL,
	[���] [decimal](18, 6) NULL,
	[����] [decimal](18, 6) NULL,
	[�����ܶ�] [decimal](18, 6) NULL,
	[����] [decimal](18, 6) NULL,
	[����2] [decimal](18, 6) NULL,
	[��ע] [ntext] NULL,
	[����] [nvarchar](1000) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[������ⵥ����2]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table ������ⵥ����2

CREATE TABLE [dbo].[������ⵥ����2](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[��ⵥ��] [varchar](50) NOT NULL,
	[��ⵥ�к�] [int] NOT NULL,
	[�������] [varchar](50) NOT NULL,
	[���к�] [int] NOT NULL,
	[����] [varchar](50) NOT NULL,
	[�������] [varchar](50) NULL,
	[���] [decimal](18, 6) NULL,
	[���] [decimal](18, 6) NULL,
	[����] [decimal](18, 6) NULL,
	[�����ܶ�] [decimal](18, 6) NULL,
	[����] [decimal](18, 6) NULL,
	[��ע] [ntext] NULL,
	[����] [nvarchar](1000) NULL,
 CONSTRAINT [PK_������ⵥ����2] PRIMARY KEY CLUSTERED 
(
	[�������] ASC,
	[���к�] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]




IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[������ⵥ��ͷ]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table ������ⵥ��ͷ
	
CREATE TABLE [dbo].[������ⵥ��ͷ](
	[��ⵥ��] [varchar](50) NOT NULL,
	[�������] [datetime] NULL,
	[�Ƶ�] [nvarchar](50) NULL,
	[����] [datetime] NULL,
	[���] [nvarchar](50) NULL,
	[�������] [datetime] NULL,
	[����] [nvarchar](50) NULL,
	[��������] [datetime] NULL,
	[��������] [nvarchar](50) NULL,
 CONSTRAINT [PK_������ⵥ��ͷ] PRIMARY KEY CLUSTERED 
(
	[��ⵥ��] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[�������]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table �������

CREATE TABLE [dbo].[�������](
	[�������] [varchar](50) NOT NULL,
	[����] [decimal](18, 6) NULL,
	[��ע] [varchar](200) NULL,
	[ʱ���] [timestamp] NULL,
 CONSTRAINT [PK_�������] PRIMARY KEY CLUSTERED 
(
	[�������] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[���ϵ�����]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table ���ϵ�����

CREATE TABLE [dbo].[���ϵ�����](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[���ϵ���] [varchar](50) NOT NULL,
	[����] [varchar](50) NULL,
	[�������] [varchar](50) NULL,
	[�������1] [varchar](50) NULL,
	[���к�1] [int] NULL,
	[���1] [decimal](18, 6) NULL,
	[���1] [decimal](18, 6) NULL,
	[����1] [decimal](18, 6) NULL,
	[����1] [decimal](18, 6) NULL,
	[���2] [decimal](18, 6) NULL,
	[���2] [decimal](18, 6) NULL,
	[����2] [decimal](18, 6) NULL,
	[����2] [decimal](18, 6) NULL,
	[�������3] [varchar](50) NULL,
	[���к�3] [int] NULL,
	[���3] [decimal](18, 6) NULL,
	[���3] [decimal](18, 6) NULL,
	[����3] [decimal](18, 6) NULL,
	[����3] [decimal](18, 6) NULL,
	[�������3] [varchar](50) NULL,
	[��ԴiID] [int] NULL,
 CONSTRAINT [PK_���ϵ�����] PRIMARY KEY CLUSTERED 
(
	[iID] ASC,
	[���ϵ���] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]





IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[���ϵ���ͷ]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table ���ϵ���ͷ

CREATE TABLE [dbo].[���ϵ���ͷ](
	[���ϵ���] [varchar](50) NOT NULL,
	[��˾����] [varchar](50) NULL,
	[��������] [datetime] NULL,
	[����˵��] [varchar](200) NULL,
	[�ܶ�] [decimal](18, 6) NULL,
	[��Ʒ�ܶ�] [decimal](18, 6) NULL,
	[�Ͻ�����] [varchar](50) NULL,
	[�и�Ա] [varchar](50) NULL,
	[�и�����] [datetime] NULL,
	[������] [varchar](50) NULL,
	[��������] [datetime] NULL,
	[���2] [decimal](18, 6) NULL,
	[���2] [decimal](18, 6) NULL,
	[����2] [decimal](18, 6) NULL,
	[����2] [decimal](18, 6) NULL,
	[���۶���ID] [int] NULL,
	[�������] [nvarchar](50) NULL,
	[���] [nvarchar](50) NULL,
	[�������] [datetime] NULL,
	[��ⴲǩ��] [nvarchar](50) NULL,
	[���ⴲǩ��] [nvarchar](50) NULL,
	[�ƾⴲǩ��] [nvarchar](50) NULL,
	[����ǩ��] [nvarchar](50) NULL,
	[����] [nvarchar](50) NULL,
	[��������] [datetime] NULL,
	[��������] [nvarchar](50) NULL,
 CONSTRAINT [PK_���ϵ���ͷ] PRIMARY KEY CLUSTERED 
(
	[���ϵ���] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


