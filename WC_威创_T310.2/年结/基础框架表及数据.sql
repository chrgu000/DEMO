

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
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'BusinessManage',N'业务处理',N'BusinessManage',N'S',0,0,100000,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmCreateFormMenu',N'创建窗体菜单',N'FrameBaseFunction',N'PprocedureAllocation',0,0,303020,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmRoleInfo',N'角色设置',N'FrameBaseFunction',N'SystemServer',0,0,301020,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmRoleRight',N'权限设置',N'FrameBaseFunction',N'SystemServer',0,0,301030,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmTableCol',N'表列信息',N'FrameBaseFunction',N'PprocedureAllocation',0,0,303010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmUserInfo',N'用户设置',N'FrameBaseFunction',N'SystemServer',0,0,301010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'S',N'系统',N'S',N'0',0,0,0,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'SystemSet',N'基础设置',N'BasicInformation',N'S',0,0,200000,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'基础业务',N'基础业务',N'Base',N'BusinessManage',0,0,100,0,1)

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
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmCreateFormMenu',N'del',N'删除',0,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmCreateFormMenu',N'refresh',N'刷新',0,50)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmCreateFormMenu',N'save',N'保存',0,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmRoleInfo',N'add',N'新增',0,100)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmRoleInfo',N'close',N'关闭',0,800)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmRoleInfo',N'edit',N'修改',0,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmRoleInfo',N'open',N'打开',0,600)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmRoleRight',N'Save',N'保存',0,400)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmTableCol',N'save',N'保存',0,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmUserInfo',N'add',N'新增',0,100)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmUserInfo',N'del',N'删除',0,300)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'FrmUserInfo',N'edit',N'修改',0,200)




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
INSERT [_RoleInfo] ([vchrRoleID],[vchrRoleText],[bClosed],[dtmCreate],[bSystem]) VALUES ( N'administrator',N'系统管理',0,N'2007/1/1 0:00:00',1)


if exists (select * from sysobjects where id = OBJECT_ID('[_RoleRight]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_RoleRight]

CREATE TABLE [_RoleRight] (
[GUID] [uniqueidentifier]  NOT NULL DEFAULT (newid()),
[vchrRoleID] [varchar]  (50) NOT NULL,
[vchrRoleRight] [varchar]  (100) NULL,
[tstamp] [timestamp]  NOT NULL)

ALTER TABLE [_RoleRight] WITH NOCHECK ADD  CONSTRAINT [PK__RoleRight] PRIMARY KEY  NONCLUSTERED ( [GUID] )

if exists (select * from sysobjects where id = OBJECT_ID('[_UserInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_UserInfo]

CREATE TABLE [_UserInfo] (
[vchrUid] [varchar]  (50) NOT NULL,
[vchrName] [varchar]  (100) NULL,
[vchrPwd] [varchar]  (100) NOT NULL,
[vchrPwd2] [nchar]  (50) NULL,
[vchrRemark] [varchar]  (50) NOT NULL,
[dtmCreate] [datetime]  NULL DEFAULT (getdate()),
[dtmClose] [datetime]  NULL DEFAULT (2099-12-31),
[tstamp] [timestamp]  NOT NULL,
[bSystem] [bit]  NULL DEFAULT (0),
[cDepCode] [varchar]  (50) NULL)

ALTER TABLE [_UserInfo] WITH NOCHECK ADD  CONSTRAINT [PK__UserInfo] PRIMARY KEY  NONCLUSTERED ( [vchrUid] )
INSERT [_UserInfo] ([vchrUid],[vchrName],[vchrPwd],[vchrPwd2],[vchrRemark],[dtmCreate],[dtmClose],[bSystem]) VALUES ( N'admin',N'系统管理员',N'FE82F8235ED6F676',N'FE82F8235ED6F676',N'系统管理员',N'2007/10/10 0:00:00',N'2099/12/31 0:00:00',1)


if exists (select * from sysobjects where id = OBJECT_ID('[_UserRoleInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_UserRoleInfo]

CREATE TABLE [_UserRoleInfo] (
[vchrUserID] [varchar]  (50) NOT NULL,
[vchrRoleID] [varchar]  (50) NOT NULL,
[tstamp] [timestamp]  NULL)

ALTER TABLE [_UserRoleInfo] WITH NOCHECK ADD  CONSTRAINT [PK__UserRoleInfo] PRIMARY KEY  NONCLUSTERED ( [vchrUserID],[vchrRoleID] )
INSERT [_UserRoleInfo] ([vchrUserID],[vchrRoleID]) VALUES ( N'admin',N'administrator')