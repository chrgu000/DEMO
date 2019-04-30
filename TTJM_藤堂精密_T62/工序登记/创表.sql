
CREATE TABLE [dbo].[_产品工序流转统计](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[存货编码] [varchar](100) NOT NULL,
	[期间] [datetime] NOT NULL,
	[期初数量] [decimal](18, 2) NULL,
	[期初金额] [decimal](18, 2) NULL,
	[领用数量] [decimal](18, 2) NULL,
	[领用金额] [decimal](18, 2) NULL,
	[完工数量] [decimal](18, 2) NULL,
	[完工金额] [decimal](18, 2) NULL,
	[在制数量] [decimal](18, 2) NULL,
	[在制金额] [decimal](18, 2) NULL,
 CONSTRAINT [PK__产品工序流转统计] PRIMARY KEY CLUSTERED 
(
	[存货编码] ASC,
	[期间] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]