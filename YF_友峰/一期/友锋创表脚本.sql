
use UFDATA_333_2016
go


IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[材料入库单表体]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table 材料入库单表体

CREATE TABLE [dbo].[材料入库单表体](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[入库单号] [varchar](50) NOT NULL,
	[行号] [int] NOT NULL,
	[存货编码] [varchar](50) NOT NULL,
	[类型] [varchar](50) NOT NULL,
	[存放区域] [varchar](50) NULL,
	[厚度] [decimal](18, 6) NULL,
	[宽度] [decimal](18, 6) NULL,
	[长度] [decimal](18, 6) NULL,
	[材料密度] [decimal](18, 6) NULL,
	[数量] [decimal](18, 6) NULL,
	[数量2] [decimal](18, 6) NULL,
	[备注] [ntext] NULL,
	[描述] [nvarchar](1000) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[材料入库单表体2]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table 材料入库单表体2

CREATE TABLE [dbo].[材料入库单表体2](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[入库单号] [varchar](50) NOT NULL,
	[入库单行号] [int] NOT NULL,
	[存货编码] [varchar](50) NOT NULL,
	[序列号] [int] NOT NULL,
	[类型] [varchar](50) NOT NULL,
	[存放区域] [varchar](50) NULL,
	[厚度] [decimal](18, 6) NULL,
	[宽度] [decimal](18, 6) NULL,
	[长度] [decimal](18, 6) NULL,
	[材料密度] [decimal](18, 6) NULL,
	[数量] [decimal](18, 6) NULL,
	[备注] [ntext] NULL,
	[描述] [nvarchar](1000) NULL,
 CONSTRAINT [PK_材料入库单表体2] PRIMARY KEY CLUSTERED 
(
	[存货编码] ASC,
	[序列号] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]




IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[材料入库单表头]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table 材料入库单表头
	
CREATE TABLE [dbo].[材料入库单表头](
	[入库单号] [varchar](50) NOT NULL,
	[入库日期] [datetime] NULL,
	[制单] [nvarchar](50) NULL,
	[日期] [datetime] NULL,
	[审核] [nvarchar](50) NULL,
	[审核日期] [datetime] NULL,
	[记账] [nvarchar](50) NULL,
	[记账日期] [datetime] NULL,
	[材料类型] [nvarchar](50) NULL,
 CONSTRAINT [PK_材料入库单表头] PRIMARY KEY CLUSTERED 
(
	[入库单号] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[存货单价]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table 存货单价

CREATE TABLE [dbo].[存货单价](
	[存货编码] [varchar](50) NOT NULL,
	[单价] [decimal](18, 6) NULL,
	[备注] [varchar](200) NULL,
	[时间戳] [timestamp] NULL,
 CONSTRAINT [PK_存货单价] PRIMARY KEY CLUSTERED 
(
	[存货编码] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[开料单表体]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table 开料单表体

CREATE TABLE [dbo].[开料单表体](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[开料单号] [varchar](50) NOT NULL,
	[类型] [varchar](50) NULL,
	[存放区域] [varchar](50) NULL,
	[存货编码1] [varchar](50) NULL,
	[序列号1] [int] NULL,
	[厚度1] [decimal](18, 6) NULL,
	[宽度1] [decimal](18, 6) NULL,
	[长度1] [decimal](18, 6) NULL,
	[数量1] [decimal](18, 6) NULL,
	[厚度2] [decimal](18, 6) NULL,
	[宽度2] [decimal](18, 6) NULL,
	[长度2] [decimal](18, 6) NULL,
	[数量2] [decimal](18, 6) NULL,
	[存货编码3] [varchar](50) NULL,
	[序列号3] [int] NULL,
	[厚度3] [decimal](18, 6) NULL,
	[宽度3] [decimal](18, 6) NULL,
	[长度3] [decimal](18, 6) NULL,
	[数量3] [decimal](18, 6) NULL,
	[存放区域3] [varchar](50) NULL,
	[来源iID] [int] NULL,
 CONSTRAINT [PK_开料单表体] PRIMARY KEY CLUSTERED 
(
	[iID] ASC,
	[开料单号] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]





IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[开料单表头]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
	drop table 开料单表头

CREATE TABLE [dbo].[开料单表头](
	[开料单号] [varchar](50) NOT NULL,
	[公司编码] [varchar](50) NULL,
	[交货日期] [datetime] NULL,
	[交货说明] [varchar](200) NULL,
	[密度] [decimal](18, 6) NULL,
	[产品密度] [decimal](18, 6) NULL,
	[合金属性] [varchar](50) NULL,
	[切割员] [varchar](50) NULL,
	[切割日期] [datetime] NULL,
	[算料人] [varchar](50) NULL,
	[算料日期] [datetime] NULL,
	[厚度2] [decimal](18, 6) NULL,
	[宽度2] [decimal](18, 6) NULL,
	[长度2] [decimal](18, 6) NULL,
	[数量2] [decimal](18, 6) NULL,
	[销售订单ID] [int] NULL,
	[存货编码] [nvarchar](50) NULL,
	[审核] [nvarchar](50) NULL,
	[审核日期] [datetime] NULL,
	[大锯床签字] [nvarchar](50) NULL,
	[带锯床签字] [nvarchar](50) NULL,
	[推锯床签字] [nvarchar](50) NULL,
	[厂长签字] [nvarchar](50) NULL,
	[记账] [nvarchar](50) NULL,
	[记账日期] [datetime] NULL,
	[材料类型] [nvarchar](50) NULL,
 CONSTRAINT [PK_开料单表头] PRIMARY KEY CLUSTERED 
(
	[开料单号] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


