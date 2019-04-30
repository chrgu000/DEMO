--UA_Menu表开始
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_DT_01' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName,cMenuType) Values (N'TH_DT_01',N'质量管理',N'4',NULL,'1',N'MO','1','','90000400.0000000000','1','',NULL,NULL,NULL,NULL,NULL)
GO
--UA_Menu表结束

--UFMenu_Business_Lang表开始
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_DT_01' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_DT_01',N'质量管理',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_DT_01' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_DT_01','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_DT_01' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_DT_01','',N'EN-US')
GO
--UFMenu_Business_Lang表结束

--UFSystem..UA_Idt表开始
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_DT_01' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_DT_01',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt表结束


------------------------------------------------------


CREATE TABLE [dbo].[_TH_ChkValue01](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[WONo] [nvarchar](100) NOT NULL,
	[WORow] [int] NULL,
	[MODid] [int] NOT NULL,
	[WorkGroup] [nvarchar](100) NULL,
	[WOBatch] [nvarchar](100) NULL,
	[WOMould] [nvarchar](100) NULL,
	[WODate] [datetime] NULL,
	[cInvCode] [nvarchar](100) NULL,
	[cInvName] [nvarchar](100) NULL,
	[cInvStd] [nvarchar](100) NULL,
	[cInvPerformance] [nvarchar](100) NULL,
	[cInvDraw] [nvarchar](100) NULL,
	[Weigth] [decimal](18, 4) NULL,
	[Weigths] [decimal](18, 4) NULL,
	[WeigthRB] [decimal](18, 4) NULL,
	[WeigthsRB] [decimal](18, 4) NULL,
	[QtyDZ1_li] [decimal](18, 4) NULL,
	[QtyG1_li] [decimal](18, 4) NULL,
	[QtyWJ1_li] [decimal](18, 4) NULL,
	[QtyDZ2_li] [decimal](18, 4) NULL,
	[QtyG2_li] [decimal](18, 4) NULL,
	[QtyWJ2_li] [decimal](18, 4) NULL,
	[QtyDZ3_li] [decimal](18, 4) NULL,
	[QtyG3_li] [decimal](18, 4) NULL,
	[QtyWJ3_li] [decimal](18, 4) NULL,
	[QtyGFS_li] [decimal](18, 4) NULL,
	[QtyTXG_li] [decimal](18, 4) NULL,
	[QtyTXD_li] [decimal](18, 4) NULL,
	[QtyTXPK_li] [decimal](18, 4) NULL,
	[QtyGH_li] [decimal](18, 4) NULL,
	[QtyWGH_li] [decimal](18, 4) NULL,
	[QtyHF_li] [decimal](18, 4) NULL,
	[QtyDZ1_lu] [decimal](18, 4) NULL,
	[QtyG1_lu] [decimal](18, 4) NULL,
	[QtyWJ1_lu] [decimal](18, 4) NULL,
	[QtyDZ2_lu] [decimal](18, 4) NULL,
	[QtyG2_lu] [decimal](18, 4) NULL,
	[QtyWJ2_lu] [decimal](18, 4) NULL,
	[QtyDZ3_lu] [decimal](18, 4) NULL,
	[QtyG3_lu] [decimal](18, 4) NULL,
	[QtyWJ3_lu] [decimal](18, 4) NULL,
	[QtyGFS_lu] [decimal](18, 4) NULL,
	[QtyTXG_lu] [decimal](18, 4) NULL,
	[QtyTXD_lu] [decimal](18, 4) NULL,
	[QtyTXPK_lu] [decimal](18, 4) NULL,
	[QtyGH_lu] [decimal](18, 4) NULL,
	[QtyWGH_lu] [decimal](18, 4) NULL,
	[QtyHF_lu] [decimal](18, 4) NULL,
	[CreatUid] [nvarchar](100) NULL,
	[dtmCreate] [datetime] NULL,
	[AuditUid] [nvarchar](100) NULL,
	[dtmAudit] [datetime] NULL,
 CONSTRAINT [PK__TH_Check] PRIMARY KEY CLUSTERED 
(
	[MODid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'_TH_ChkValue01', @level2type=N'COLUMN',@level2name=N'QtyDZ1_li'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'共重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'_TH_ChkValue01', @level2type=N'COLUMN',@level2name=N'QtyG1_li'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'万件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'_TH_ChkValue01', @level2type=N'COLUMN',@level2name=N'QtyWJ1_li'
GO


------


CREATE TABLE [dbo].[_TH_ChkValues01](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[WONo] [nvarchar](100) NULL,
	[MODid] [int] NOT NULL,
	[chkItemCode] [nvarchar](100) NOT NULL,
	[chkItemName] [nvarchar](100) NULL,
	[chkStd] [nvarchar](100) NULL,
	[chkMax] [decimal](18, 4) NULL,
	[chkMin] [decimal](18, 4) NULL,
	[chkValue01] [decimal](18, 4) NULL,
	[chkValue02] [decimal](18, 4) NULL,
	[chkValue03] [decimal](18, 4) NULL,
	[chkValue04] [decimal](18, 4) NULL,
	[chkValue05] [decimal](18, 4) NULL,
	[chkValue06] [decimal](18, 4) NULL,
	[chkValue07] [decimal](18, 4) NULL,
	[chkValue08] [decimal](18, 4) NULL,
	[chkValue09] [decimal](18, 4) NULL,
	[chkValue10] [decimal](18, 4) NULL,
	[chkValue11] [decimal](18, 4) NULL,
	[chkValue12] [decimal](18, 4) NULL,
	[chkValue13] [decimal](18, 4) NULL,
	[chkValue14] [decimal](18, 4) NULL,
	[chkValue15] [decimal](18, 4) NULL,
	[chkValue16] [decimal](18, 4) NULL,
	[chkValue17] [decimal](18, 4) NULL,
	[chkValue18] [decimal](18, 4) NULL,
	[chkValue19] [decimal](18, 4) NULL,
	[chkValue20] [decimal](18, 4) NULL,
	[chkValue21] [decimal](18, 4) NULL,
	[chkValue22] [decimal](18, 4) NULL,
	[chkValue23] [decimal](18, 4) NULL,
	[chkValue24] [decimal](18, 4) NULL,
	[chkValue25] [decimal](18, 4) NULL,
	[chkValue26] [decimal](18, 4) NULL,
	[chkValue27] [decimal](18, 4) NULL,
	[chkValue28] [decimal](18, 4) NULL,
	[chkValue29] [decimal](18, 4) NULL,
	[chkValue30] [decimal](18, 4) NULL,
	[PassOrNG] [bit] NULL,
 CONSTRAINT [PK__TH_ChkValues] PRIMARY KEY CLUSTERED 
(
	[MODid] ASC,
	[chkItemCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




