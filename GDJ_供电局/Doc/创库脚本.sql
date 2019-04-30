if exists (select * from sysobjects where id = OBJECT_ID('[_BtnBaseInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_BtnBaseInfo]

CREATE TABLE [_BtnBaseInfo] (
[btnCode] [varchar]  (50) NOT NULL,
[btnName] [varchar]  (50) NULL,
[iOrder] [int]  NULL,
[bEnable] [int]  NOT NULL DEFAULT (0),
[tstamp] [timestamp]  NOT NULL)

ALTER TABLE [_BtnBaseInfo] WITH NOCHECK ADD  CONSTRAINT [PK__BtnBaseInfo] PRIMARY KEY  NONCLUSTERED ( [btnCode] )
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'add',N'新增',130,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'addrow',N'增行',110,2)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'alter',N'变更',240,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'audit',N'审核',200,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'autobuckup',N'自动备份',10,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'buckup',N'备份',20,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'close',N'关闭',230,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'del',N'删除',150,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'delrow',N'删行',120,2)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'edit',N'修改',140,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'export',N'导出',270,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'first',N'首页',70,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'import',N'导入',125,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'last',N'末页',100,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'layout',N'布局',30,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'lock',N'锁定',180,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'next',N'下页',90,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'open',N'打开',220,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'prev',N'上页',80,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'print',N'打印',250,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'printset',N'打印设置',40,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'refresh',N'刷新',50,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'save',N'保存',160,2)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'sel',N'查询',60,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'unaudit',N'弃审',210,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'undo',N'撤销',170,2)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'unlock',N'解锁',190,1)
if exists (select * from sysobjects where id = OBJECT_ID('[_Code]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_Code]

CREATE TABLE [_Code] (
[iID] [int]  IDENTITY (1, 1)  NOT NULL,
[sType] [varchar]  (50) NOT NULL,
[cCode] [varchar]  (50) NOT NULL,
[cText] [varchar]  (50) NOT NULL)

ALTER TABLE [_Code] WITH NOCHECK ADD  CONSTRAINT [PK__Code] PRIMARY KEY  NONCLUSTERED ( [iID] )
SET IDENTITY_INSERT [_Code] ON

INSERT [_Code] ([iID],[sType],[cCode],[cText]) VALUES ( 5,N'sex',N'0',N'空白')
INSERT [_Code] ([iID],[sType],[cCode],[cText]) VALUES ( 6,N'sex',N'1',N'男')
INSERT [_Code] ([iID],[sType],[cCode],[cText]) VALUES ( 7,N'sex',N'2',N'女')

SET IDENTITY_INSERT [_Code] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[_Form]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_Form]

CREATE TABLE [_Form] (
[fchrFrmNameID] [varchar]  (50) NOT NULL,
[fchrFrmText] [varchar]  (200) NOT NULL,
[fchrNameSpace] [varchar]  (50) NULL,
[fchrFrmUpName] [varchar]  (255) NULL,
[fbitHide] [bit]  NULL DEFAULT (0),
[fbitNoUse] [bit]  NOT NULL DEFAULT (0),
[fIntOrderID] [int]  NULL,
[fImage] [image]  NULL,
[vchrFormBel] [varchar]  (50) NULL,
[bSystem] [bit]  NOT NULL DEFAULT (0),
[tstamp] [timestamp]  NOT NULL,
[bUse] [bit]  NULL DEFAULT (0))

ALTER TABLE [_Form] WITH NOCHECK ADD  CONSTRAINT [PK__Form] PRIMARY KEY  NONCLUSTERED ( [fchrFrmNameID],[fchrFrmText] )
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'BusinessManage',N'业务处理',N'ImportDLL',N'S',0,0,100000,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmBuckUpDataBase',N'数据备份',N'FrameBaseFunction',N'SystemServer',0,0,302010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmCreateFormMenu',N'创建窗体菜单',N'FrameBaseFunction',N'PprocedureAllocation',0,0,303020,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmLookUpData',N'下拉框数据档案',N'FrameBaseFunction',N'PprocedureAllocation',0,0,303030,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmLookUpType',N'下拉框数据类型',N'FrameBaseFunction',N'PprocedureAllocation',0,0,303025,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmRoleInfo',N'角色设置',N'FrameBaseFunction',N'SystemServer',0,0,301020,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmRoleRight',N'权限设置',N'FrameBaseFunction',N'SystemServer',0,0,301030,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmServerPro',N'服务器端程序',N'FrameBaseFunction',N'SystemServer',0,0,309010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmTableCol',N'表列信息',N'FrameBaseFunction',N'PprocedureAllocation',0,0,303010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmUserInfo',N'用户设置',N'FrameBaseFunction',N'SystemServer',0,0,301010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'Frm科目余额表',N'科目余额表',N'ImportDLL',N'BusinessManage',0,0,100020,0,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'Frm账龄分析',N'账龄分析',N'ImportDLL',N'BusinessManage',0,0,100020,0,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'Frm执行存储过程',N'执行存储过程',N'ImportDLL',N'SystemServer',0,0,309010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'PprocedureAllocation',N'程序配置',N'FrameBaseFunction',N'SystemServer',0,0,303000,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'S',N'系统',N'S',N'0',0,0,0,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'SystemServer',N'系统服务',N'S',0,0,300000,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'SystemSet',N'基础设置',N'ImportDLL',N'S',0,0,200000,1,1)
if exists (select * from sysobjects where id = OBJECT_ID('[_FormBtnInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_FormBtnInfo]

CREATE TABLE [_FormBtnInfo] (
[fchrFrmNameID] [varchar]  (50) NOT NULL,
[vchrBtnID] [varchar]  (50) NOT NULL,
[vchrBtnText] [varchar]  (50) NULL,
[iIcon] [image]  NULL,
[bEnable] [int]  NOT NULL DEFAULT (1),
[vchrRemark] [varchar]  (50) NULL,
[intOrder] [int]  NULL,
[tstamp] [timestamp]  NOT NULL)

ALTER TABLE [_FormBtnInfo] WITH NOCHECK ADD  CONSTRAINT [PK__FormBtnInfo] PRIMARY KEY  NONCLUSTERED ( [fchrFrmNameID],[vchrBtnID] )
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmBuckUpDataBase',N'AutoBuckUp',N'自动备份',1,NULL,210)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmBuckUpDataBase',N'BuckUp',N'备份',1,NULL,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmCreateFormMenu',N'del',N'删除',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmCreateFormMenu',N'refresh',N'刷新',0,NULL,50)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmCreateFormMenu',N'save',N'保存',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'addrow',N'增行',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'del',N'删除',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'delrow',N'删行',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'export',N'导出',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'import',N'导入',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'layout',N'布局',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'print',N'打印',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'printset',N'打印设置',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'save',N'保存',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'sel',N'查询',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'undo',N'撤销',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'addrow',N'增行',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'del',N'删除',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'delrow',N'删行',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'export',N'导出',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'import',N'导入',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'layout',N'布局',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'print',N'打印',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'printset',N'打印设置',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'save',N'保存',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'sel',N'查询',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'undo',N'撤销',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'addrow',N'增行',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'del',N'删除',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'delrow',N'删行',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'export',N'导出',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'import',N'导入',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'layout',N'布局',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'print',N'打印',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'printset',N'打印设置',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'save',N'保存',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'sel',N'查询',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'undo',N'撤销',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'addrow',N'增行',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'del',N'删除',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'delrow',N'删行',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'export',N'导出',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'import',N'导入',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'layout',N'布局',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'print',N'打印',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'printset',N'打印设置',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'save',N'保存',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'sel',N'查询',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'undo',N'撤销',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'addrow',N'增行',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'del',N'删除',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'delrow',N'删行',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'export',N'导出',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'import',N'导入',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'layout',N'布局',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'print',N'打印',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'printset',N'打印设置',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'save',N'保存',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'sel',N'查询',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'undo',N'撤销',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'addrow',N'增行',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'del',N'删除',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'delrow',N'删行',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'export',N'导出',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'layout',N'布局',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'print',N'打印',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'printset',N'打印设置',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'refresh',N'刷新',0,NULL,50)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'save',N'保存',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'sel',N'查询',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'undo',N'撤销',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'addrow',N'增行',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'del',N'删除',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'delrow',N'删行',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'export',N'导出',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'layout',N'布局',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'print',N'打印',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'printset',N'打印设置',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'save',N'保存',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'sel',N'查询',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'undo',N'撤销',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmRoleInfo',N'add',N'新增',0,NULL,100)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmRoleInfo',N'close',N'关闭',0,NULL,800)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmRoleInfo',N'edit',N'修改',0,NULL,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmRoleInfo',N'open',N'打开',0,NULL,600)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmRoleRight',N'Save',N'保存',0,NULL,400)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmServerPro',N'close',N'关闭',0,NULL,230)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmServerPro',N'open',N'打开',0,NULL,220)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmTableCol',N'save',N'保存',0,NULL,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmUserInfo',N'add',N'新增',0,NULL,100)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmUserInfo',N'del',N'删除',0,NULL,300)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmUserInfo',N'edit',N'修改',0,NULL,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'addrow',N'增行',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'del',N'删除',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'delrow',N'删行',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'export',N'导出',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'import',N'导入',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'layout',N'布局',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'print',N'打印',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'printset',N'打印设置',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'save',N'保存',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'sel',N'查询',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'undo',N'撤销',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm科目余额表',N'export',N'导出',1,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm科目余额表',N'sel',N'查询',0,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm物料',N'addrow',N'增行',2,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm物料',N'del',N'删除',1,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm物料',N'delrow',N'删行',2,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm物料',N'export',N'导出',1,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm物料',N'import',N'导入',1,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm物料',N'layout',N'布局',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm物料',N'print',N'打印',1,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm物料',N'printset',N'打印设置',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm物料',N'save',N'保存',2,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm物料',N'sel',N'查询',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm物料',N'undo',N'撤销',2,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm账龄分析',N'export',N'导出',0,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm账龄分析',N'sel',N'查询',0,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm执行存储过程',N'addrow',N'增行',0,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm执行存储过程',N'audit',N'执行',0,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm执行存储过程',N'del',N'删除',0,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm执行存储过程',N'save',N'保存',0,160)
if exists (select * from sysobjects where id = OBJECT_ID('[_LookUpDate]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_LookUpDate]

CREATE TABLE [_LookUpDate] (
[iType] [nvarchar]  (50) NOT NULL,
[iID] [varchar]  (50) NOT NULL,
[iText] [varchar]  (50) NOT NULL,
[Remark] [varchar]  (50) NULL,
[bClose] [int]  NULL DEFAULT (1),
[bSystem] [int]  NULL DEFAULT (2),
[tstamp] [timestamp]  NULL)

ALTER TABLE [_LookUpDate] WITH NOCHECK ADD  CONSTRAINT [PK__LookUpDate] PRIMARY KEY  NONCLUSTERED ( [iType],[iID] )
INSERT [_LookUpDate] ([iType],[iID],[iText],[bClose],[bSystem]) VALUES ( N'1',N'01',N'300',1,1)
INSERT [_LookUpDate] ([iType],[iID],[iText],[bClose],[bSystem]) VALUES ( N'1',N'02',N'600',1,1)
INSERT [_LookUpDate] ([iType],[iID],[iText],[bClose],[bSystem]) VALUES ( N'1',N'03',N'700',1,1)
INSERT [_LookUpDate] ([iType],[iID],[iText],[bClose],[bSystem]) VALUES ( N'1',N'04',N'750',1,1)
INSERT [_LookUpDate] ([iType],[iID],[iText],[bClose],[bSystem]) VALUES ( N'2',N'U851a',N'U851a',1,1)
INSERT [_LookUpDate] ([iType],[iID],[iText],[bClose],[bSystem]) VALUES ( N'2',N'T6V60',N'T6V60',1,1)
INSERT [_LookUpDate] ([iType],[iID],[iText],[bClose],[bSystem]) VALUES ( N'3',N'U851a',N'U851a',1,1)
if exists (select * from sysobjects where id = OBJECT_ID('[_LookUpType]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_LookUpType]

CREATE TABLE [_LookUpType] (
[iID] [varchar]  (50) NOT NULL,
[iType] [varchar]  (50) NOT NULL,
[Remark] [varchar]  (50) NULL,
[tstamp] [timestamp]  NULL)

ALTER TABLE [_LookUpType] WITH NOCHECK ADD  CONSTRAINT [PK__LookUpType] PRIMARY KEY  NONCLUSTERED ( [iID],[iType] )
INSERT [_LookUpType] ([iID],[iType]) VALUES ( N'1',N'账龄期间')
INSERT [_LookUpType] ([iID],[iType]) VALUES ( N'2',N'用友ERP版本')
INSERT [_LookUpType] ([iID],[iType]) VALUES ( N'3',N'当前用友ERP版本')
if exists (select * from sysobjects where id = OBJECT_ID('[_ReportList]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_ReportList]

CREATE TABLE [_ReportList] (
[iID] [int]  IDENTITY (1, 1)  NOT NULL,
[ReportID] [varchar]  (50) NOT NULL,
[ReportClass] [varchar]  (50) NOT NULL,
[Report] [varchar]  (50) NOT NULL,
[Remark] [varchar]  (50) NULL,
[tstamp] [timestamp]  NULL)

ALTER TABLE [_ReportList] WITH NOCHECK ADD  CONSTRAINT [PK__ReportList] PRIMARY KEY  NONCLUSTERED ( [ReportID],[ReportClass] )
SET IDENTITY_INSERT [_ReportList] ON


SET IDENTITY_INSERT [_ReportList] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[_RoleInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_RoleInfo]

CREATE TABLE [_RoleInfo] (
[vchrRoleID] [varchar]  (50) NOT NULL,
[vchrRoleText] [varchar]  (50) NOT NULL,
[vchrRemark] [varchar]  (50) NULL,
[bClosed] [bit]  NOT NULL DEFAULT (0),
[dtmCreate] [datetime]  NULL DEFAULT (getdate()),
[bSystem] [bit]  NULL DEFAULT (0),
[tstamp] [timestamp]  NOT NULL)

ALTER TABLE [_RoleInfo] WITH NOCHECK ADD  CONSTRAINT [PK__RoleInfo] PRIMARY KEY  NONCLUSTERED ( [vchrRoleID] )
INSERT [_RoleInfo] ([vchrRoleID],[vchrRoleText],[bClosed],[dtmCreate],[bSystem]) VALUES ( N'01',N'操作员',0,N'2013-03-25 0:00:00',0)
INSERT [_RoleInfo] ([vchrRoleID],[vchrRoleText],[bClosed],[dtmCreate],[bSystem]) VALUES ( N'administrator',N'系统管理',0,N'2007-01-01 0:00:00',1)
if exists (select * from sysobjects where id = OBJECT_ID('[_RoleRight]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_RoleRight]

CREATE TABLE [_RoleRight] (
[GUID] [uniqueidentifier]  NOT NULL DEFAULT (newid()),
[vchrRoleID] [varchar]  (50) NOT NULL,
[vchrRoleRight] [varchar]  (100) NULL,
[tstamp] [timestamp]  NOT NULL)

ALTER TABLE [_RoleRight] WITH NOCHECK ADD  CONSTRAINT [PK__RoleRight] PRIMARY KEY  NONCLUSTERED ( [GUID] )
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'1914230c-9de8-457e-8c1b-293daea13899',N'01',N'SystemSet|Frm人员对照表')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'd8b9660a-23e7-486f-b8a4-302368de3356',N'01',N'Frm薪资凭证生成|save')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'4b489df1-71f4-40b6-bb2b-34cc9eeaf267',N'01',N'Frm薪资凭证生成|edit')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'c8897ccc-c993-4c6c-9189-4b09ba3fee8d',N'01',N'S|SystemSet')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'6941b375-a1e7-492b-99b9-50d808a0a924',N'01',N'Frm薪资凭证生成|sel')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'9165f9c6-4c75-454d-8d05-66abdc4041e7',N'01',N'BusinessManage|Frm薪资凭证生成')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'28427618-737a-468f-a078-678fb6b423e5',N'01',N'S|BusinessManage')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'7b701cbb-d9ae-473e-9ec5-6f25d0bb7edf',N'01',N'Frm人员对照表|sel')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'b941604b-7d54-4c07-a1b0-83b59543cb20',N'01',N'0|S')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'c0c8a501-d4b0-4e3c-bae1-a030a30b50ed',N'01',N'Frm部门对照表|sel')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'19df4416-f4b1-46f6-83ed-a57ff8274e95',N'01',N'SystemSet|Frm会计科目工资项目对照表')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'a7e73e71-d592-4732-80c0-d309d200bcad',N'01',N'Frm会计科目部门对照表|refresh')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'2b954463-80d4-4e80-9477-e301a1b927a2',N'01',N'Frm会计科目工资项目对照表|refresh')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'6915bb07-e25a-4a7c-a01b-fa90bdb7455a',N'01',N'SystemSet|Frm部门对照表')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'0413b9c5-89ed-4cb2-86c6-fd98a6857059',N'01',N'SystemSet|Frm会计科目部门对照表')
if exists (select * from sysobjects where id = OBJECT_ID('[_TableColInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_TableColInfo]

CREATE TABLE [_TableColInfo] (
[iID] [int]  IDENTITY (1, 1)  NOT NULL,
[TABLE_CATALOG] [nvarchar]  (128) NOT NULL,
[TABLE_SCHEMA] [nvarchar]  (128) NOT NULL,
[TABLE_NAME] [nvarchar]  (20) NOT NULL,
[COLUMN_NAME] [nvarchar]  (20) NOT NULL,
[COLUMN_Text] [nvarchar]  (100) NULL,
[DATA_TYPE] [int]  NULL,
[COLLATION_ADD] [int]  NULL DEFAULT (0),
[bSystem] [bit]  NULL DEFAULT (0),
[tstamp] [timestamp]  NOT NULL,
[bKey] [bit]  NOT NULL DEFAULT (0))

ALTER TABLE [_TableColInfo] WITH NOCHECK ADD  CONSTRAINT [PK__TableColInfo] PRIMARY KEY  NONCLUSTERED ( [TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME] )
SET IDENTITY_INSERT [_TableColInfo] ON

INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 1,N'SystemDB_GDJ',N'dbo',N'_Form',N'bSystem',3,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 2,N'SystemDB_GDJ',N'dbo',N'_Form',N'bUse',3,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 3,N'SystemDB_GDJ',N'dbo',N'_Form',N'fbitHide',3,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 4,N'SystemDB_GDJ',N'dbo',N'_Form',N'fbitNoUse',3,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 5,N'SystemDB_GDJ',N'dbo',N'_Form',N'fchrFrmNameID',2,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 6,N'SystemDB_GDJ',N'dbo',N'_Form',N'fchrFrmText',2,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 7,N'SystemDB_GDJ',N'dbo',N'_Form',N'fchrFrmUpName',2,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 8,N'SystemDB_GDJ',N'dbo',N'_Form',N'fchrNameSpace',2,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 9,N'SystemDB_GDJ',N'dbo',N'_Form',N'fImage',9,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 10,N'SystemDB_GDJ',N'dbo',N'_Form',N'fIntOrderID',1,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 11,N'SystemDB_GDJ',N'dbo',N'_Form',N'tstamp',0,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 12,N'SystemDB_GDJ',N'dbo',N'_Form',N'vchrFormBel',2,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 13,N'SystemDB_GDJ',N'dbo',N'_FormBtnInfo',N'bEnable',1,0,1,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 14,N'SystemDB_GDJ',N'dbo',N'_FormBtnInfo',N'fchrFrmNameID',2,0,1,1)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 15,N'SystemDB_GDJ',N'dbo',N'_FormBtnInfo',N'iIcon',0,0,1,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 16,N'SystemDB_GDJ',N'dbo',N'_FormBtnInfo',N'intOrder',1,0,1,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 17,N'SystemDB_GDJ',N'dbo',N'_FormBtnInfo',N'tstamp',0,0,1,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 18,N'SystemDB_GDJ',N'dbo',N'_FormBtnInfo',N'vchrBtnID',2,0,1,1)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 19,N'SystemDB_GDJ',N'dbo',N'_FormBtnInfo',N'vchrBtnText',2,0,1,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 20,N'SystemDB_GDJ',N'dbo',N'_FormBtnInfo',N'vchrRemark',2,0,1,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 132,N'SystemDB_GDJ',N'dbo',N'_LookUpDate',N'bClose',1,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 133,N'SystemDB_GDJ',N'dbo',N'_LookUpDate',N'bSystem',1,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 129,N'SystemDB_GDJ',N'dbo',N'_LookUpDate',N'iID',2,0,0,1)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 130,N'SystemDB_GDJ',N'dbo',N'_LookUpDate',N'iText',2,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 128,N'SystemDB_GDJ',N'dbo',N'_LookUpDate',N'iType',2,0,0,1)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 131,N'SystemDB_GDJ',N'dbo',N'_LookUpDate',N'Remark',2,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 134,N'SystemDB_GDJ',N'dbo',N'_LookUpDate',N'tstamp',0,0,0,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[COLUMN_Text],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 124,N'SystemDB_GDJ',N'dbo',N'_LookUpType',N'iID',N'编号',2,0,1,1)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[COLUMN_Text],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 125,N'SystemDB_GDJ',N'dbo',N'_LookUpType',N'iType',N'类型',2,0,1,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[COLUMN_Text],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 126,N'SystemDB_GDJ',N'dbo',N'_LookUpType',N'Remark',N'备注',2,0,1,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[COLUMN_Text],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 127,N'SystemDB_GDJ',N'dbo',N'_LookUpType',N'tstamp',N'时间戳',0,0,1,0)

SET IDENTITY_INSERT [_TableColInfo] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[_UserInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_UserInfo]

CREATE TABLE [_UserInfo] (
[vchrUid] [varchar]  (50) NOT NULL,
[vchrName] [varchar]  (50) NULL,
[vchrPwd] [varchar]  (50) NOT NULL,
[vchrRemark] [varchar]  (50) NULL,
[dtmCreate] [datetime]  NULL DEFAULT (getdate()),
[dtmClose] [datetime]  NULL DEFAULT (2099 - 12 - 31),
[tstamp] [timestamp]  NOT NULL,
[bSystem] [bit]  NULL DEFAULT (0))

ALTER TABLE [_UserInfo] WITH NOCHECK ADD  CONSTRAINT [PK__UserInfo] PRIMARY KEY  NONCLUSTERED ( [vchrUid] )
INSERT [_UserInfo] ([vchrUid],[vchrName],[vchrPwd],[vchrRemark],[dtmCreate],[dtmClose],[bSystem]) VALUES ( N'admin',N'系统管理员',N'ADBF8135A642B58A',N'系统管理员',N'2007-10-10 0:00:00',N'2099-10-10 0:00:00',1)
INSERT [_UserInfo] ([vchrUid],[vchrName],[vchrPwd],[dtmCreate],[dtmClose],[bSystem]) VALUES ( N'hsy',N'华思雨',N'ADBF8135A642B58A',N'2013-03-25 0:00:00',N'2099-12-31 0:00:00',0)
INSERT [_UserInfo] ([vchrUid],[vchrName],[vchrPwd],[dtmCreate],[dtmClose],[bSystem]) VALUES ( N'sp',N'沈平',N'F9632974E9309A33',N'2013-03-25 0:00:00',N'2099-12-31 0:00:00',0)
if exists (select * from sysobjects where id = OBJECT_ID('[_UserRoleInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_UserRoleInfo]

CREATE TABLE [_UserRoleInfo] (
[vchrUserID] [varchar]  (50) NOT NULL,
[vchrRoleID] [varchar]  (50) NOT NULL,
[tstamp] [timestamp]  NULL)

ALTER TABLE [_UserRoleInfo] WITH NOCHECK ADD  CONSTRAINT [PK__UserRoleInfo] PRIMARY KEY  NONCLUSTERED ( [vchrUserID],[vchrRoleID] )
INSERT [_UserRoleInfo] ([vchrUserID],[vchrRoleID]) VALUES ( N'admin',N'administrator')
INSERT [_UserRoleInfo] ([vchrUserID],[vchrRoleID]) VALUES ( N'hsy',N'01')
INSERT [_UserRoleInfo] ([vchrUserID],[vchrRoleID]) VALUES ( N'sp',N'01')
if exists (select * from sysobjects where id = OBJECT_ID('[RepGLadmin]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [RepGLadmin]

CREATE TABLE [RepGLadmin] (
[客户编码] [varchar]  (20) NULL,
[金额] [money]  NULL,
[日期] [datetime]  NULL)

if exists (select * from sysobjects where id = OBJECT_ID('[用户默认帐套]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [用户默认帐套]

CREATE TABLE [用户默认帐套] (
[帐号] [varchar]  (50) NOT NULL,
[帐套] [varchar]  (50) NOT NULL)

ALTER TABLE [用户默认帐套] WITH NOCHECK ADD  CONSTRAINT [PK_用户默认帐套] PRIMARY KEY  NONCLUSTERED ( [帐号],[帐套] )
INSERT [用户默认帐套] ([帐号],[帐套]) VALUES ( N'admin',N'003')
