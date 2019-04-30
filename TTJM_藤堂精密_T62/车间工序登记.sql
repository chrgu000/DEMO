

use [SystemDB_TTJM]
GO

if object_id(N'_���乤���ձ�',N'U') is not null
DROP TABLE [dbo].[_���乤���ձ�]
GO

CREATE TABLE [dbo].[_���乤���ձ�](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[MainID] [int] NOT NULL,
	[MoCode] [varchar](50) NULL,
	[dtm] [datetime] NOT NULL,
	[BoxNO] [int] NOT NULL,
	[cInvCode] [varchar](50) NULL,
	[cInvName] [varchar](50) NULL,
	[cInvStd] [varchar](50) NULL,
	[CreateUid] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUid] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[CloseUid] [varchar](50) NULL,
	[CloseDate] [datetime] NULL,
	[Remark] [varchar](50) NULL,
	[Remark2] [varchar](50) NULL,
	[Remark3] [varchar](50) NULL,
	[Remark4] [varchar](50) NULL,
	[Remark5] [varchar](50) NULL,
	[Remark6] [varchar](50) NULL,
	[Remark7] [varchar](50) NULL,
	[Remark8] [varchar](50) NULL,
	[Remark9] [varchar](50) NULL,
	[Remark10] [varchar](50) NULL,
	[GX1] [decimal](18, 0) NULL,
	[GX2] [decimal](18, 0) NULL,
	[GX3] [decimal](18, 0) NULL,
	[GX4] [decimal](18, 0) NULL,
	[GX5] [decimal](18, 0) NULL,
	[GX6] [decimal](18, 0) NULL,
	[GX7] [decimal](18, 0) NULL,
	[GX8] [decimal](18, 0) NULL,
	[GX9] [decimal](18, 0) NULL,
	[GX10] [decimal](18, 0) NULL,
	[GX11] [decimal](18, 0) NULL,
	[GX12] [decimal](18, 0) NULL,
	[GX13] [decimal](18, 0) NULL,
	[GX14] [decimal](18, 0) NULL,
	[GX15] [decimal](18, 0) NULL,
	[GX16] [decimal](18, 0) NULL,
	[GX17] [decimal](18, 0) NULL,
	[GX18] [decimal](18, 0) NULL,
	[GX19] [decimal](18, 0) NULL,
	[GX20] [decimal](18, 0) NULL,
 CONSTRAINT [PK__���乤���ձ�] PRIMARY KEY CLUSTERED 
(
	[MainID] ASC,
	[dtm] ASC,
	[BoxNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

if object_id(N'_�������������¼',N'U') is not null
DROP TABLE [dbo].[_�������������¼]
GO


CREATE TABLE [dbo].[_�������������¼](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[MainID] [int] NULL,
	[cindex] [nchar](10) NULL,
	[opcode] [nchar](10) NULL,
	[opname] [nchar](10) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK__�������������¼] PRIMARY KEY CLUSTERED 
(
	[iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) 
VALUES ( N'Frm���乤���ձ�',N'���乤���ձ�',N'ImportDLL',N'BusinessManage',0,0,0,1,1)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm���乤���ձ�',N'���乤���ձ�',N'close',N'�ر�',0,230)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm���乤���ձ�',N'���乤���ձ�',N'del',N'ɾ��',0,150)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm���乤���ձ�',N'���乤���ձ�',N'export',N'����',0,270)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm���乤���ձ�',N'���乤���ձ�',N'open',N'��',0,220)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm���乤���ձ�',N'���乤���ձ�',N'refresh',N'ˢ��',0,50)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm���乤���ձ�',N'���乤���ձ�',N'save',N'����',0,160)



INSERT [�б�����] ([����],[����],[����],[�б���],[����],[������],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'bChoose',N'ѡ��',0,1,1,40,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[������],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'BoxNO',N'���',1,1,1,80,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'cInvCode',N'��Ʒ����',61,0,80,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'cInvName',N'��Ʒ����',62,0,80,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'cInvStd',N'����ͺ�',63,0,80,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'CloseDate',N'�깤�Ǽ�����',210,1,80,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'CloseUid',N'�깤�Ǽ���',200,1,80,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'CreateDate',N'�Ƶ�����',82,1,110,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'CreateUid',N'�Ƶ���',81,1,110,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'dtm',N'��������',100,0,80,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX1',N'����1',1,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX10',N'GX10',10,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX11',N'GX11',11,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX12',N'GX12',12,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX13',N'GX13',13,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX14',N'GX14',14,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX15',N'GX15',15,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX16',N'GX16',16,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX17',N'GX17',17,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX18',N'GX18',18,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX19',N'GX19',19,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX2',N'����2',2,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX20',N'GX20',20,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX3',N'����3',3,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX4',N'GX4',4,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX5',N'GX5',5,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX6',N'GX6',6,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX7',N'GX7',7,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX8',N'GX8',8,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'GX9',N'GX9',9,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'iID',N'iID',50,0,80,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'MainID',N'��������IDs',51,0,80,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'MoCode',N'����������',52,0,80,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'Remark',N'��ע',21,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'Remark10',N'Remark10',30,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'Remark2',N'Remark2',22,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'Remark3',N'Remark3',23,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'Remark4',N'Remark4',24,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'Remark5',N'Remark5',25,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'Remark6',N'Remark6',26,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'Remark7',N'Remark7',27,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'Remark8',N'Remark8',28,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'Remark9',N'Remark9',29,0,80,1,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'UpdateDate',N'��������',83,0,80,0,0)
INSERT [�б�����] ([����],[����],[����],[�б���],[����],[�ɼ�],[���],[�ɱ༭],[����]) VALUES ( N'.',N'���乤���ձ�',N'UpdateUid',N'������',84,0,80,0,0)


