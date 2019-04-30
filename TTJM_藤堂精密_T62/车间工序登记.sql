

use [SystemDB_TTJM]
GO

if object_id(N'_车间工序日报',N'U') is not null
DROP TABLE [dbo].[_车间工序日报]
GO

CREATE TABLE [dbo].[_车间工序日报](
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
 CONSTRAINT [PK__车间工序日报] PRIMARY KEY CLUSTERED 
(
	[MainID] ASC,
	[dtm] ASC,
	[BoxNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

if object_id(N'_生产订单工序记录',N'U') is not null
DROP TABLE [dbo].[_生产订单工序记录]
GO


CREATE TABLE [dbo].[_生产订单工序记录](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[MainID] [int] NULL,
	[cindex] [nchar](10) NULL,
	[opcode] [nchar](10) NULL,
	[opname] [nchar](10) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK__生产订单工序记录] PRIMARY KEY CLUSTERED 
(
	[iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) 
VALUES ( N'Frm车间工序日报',N'车间工序日报',N'ImportDLL',N'BusinessManage',0,0,0,1,1)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm车间工序日报',N'车间工序日报',N'close',N'关闭',0,230)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm车间工序日报',N'车间工序日报',N'del',N'删除',0,150)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm车间工序日报',N'车间工序日报',N'export',N'导出',0,270)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm车间工序日报',N'车间工序日报',N'open',N'打开',0,220)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm车间工序日报',N'车间工序日报',N'refresh',N'刷新',0,50)

INSERT [_FormBtnInfo] ([fchrFrmNameID],[fchrFrmText],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) 
VALUES ( N'Frm车间工序日报',N'车间工序日报',N'save',N'保存',0,160)



INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[列锁定],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'bChoose',N'选择',0,1,1,40,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[列锁定],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'BoxNO',N'箱号',1,1,1,80,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'cInvCode',N'产品编码',61,0,80,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'cInvName',N'产品名称',62,0,80,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'cInvStd',N'规格型号',63,0,80,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'CloseDate',N'完工登记日期',210,1,80,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'CloseUid',N'完工登记人',200,1,80,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'CreateDate',N'制单日期',82,1,110,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'CreateUid',N'制单人',81,1,110,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'dtm',N'单据日期',100,0,80,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX1',N'工序1',1,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX10',N'GX10',10,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX11',N'GX11',11,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX12',N'GX12',12,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX13',N'GX13',13,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX14',N'GX14',14,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX15',N'GX15',15,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX16',N'GX16',16,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX17',N'GX17',17,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX18',N'GX18',18,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX19',N'GX19',19,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX2',N'工序2',2,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX20',N'GX20',20,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX3',N'工序3',3,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX4',N'GX4',4,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX5',N'GX5',5,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX6',N'GX6',6,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX7',N'GX7',7,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX8',N'GX8',8,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'GX9',N'GX9',9,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'iID',N'iID',50,0,80,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'MainID',N'生产订单IDs',51,0,80,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'MoCode',N'生产订单号',52,0,80,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'Remark',N'备注',21,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'Remark10',N'Remark10',30,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'Remark2',N'Remark2',22,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'Remark3',N'Remark3',23,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'Remark4',N'Remark4',24,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'Remark5',N'Remark5',25,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'Remark6',N'Remark6',26,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'Remark7',N'Remark7',27,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'Remark8',N'Remark8',28,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'Remark9',N'Remark9',29,0,80,1,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'UpdateDate',N'更新日期',83,0,80,0,0)
INSERT [列表设置] ([库名],[表名],[列名],[列标题],[排序],[可见],[宽度],[可编辑],[必输]) VALUES ( N'.',N'车间工序日报',N'UpdateUid',N'更新人',84,0,80,0,0)


