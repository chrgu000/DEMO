if exists (select * from sysobjects where id = OBJECT_ID('[_BtnBaseInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_BtnBaseInfo]

CREATE TABLE [_BtnBaseInfo] (
[btnCode] [varchar]  (50) NOT NULL,
[btnName] [varchar]  (50) NULL,
[iOrder] [int]  NULL,
[bEnable] [int]  NOT NULL DEFAULT (0),
[tstamp] [timestamp]  NOT NULL)

ALTER TABLE [_BtnBaseInfo] WITH NOCHECK ADD  CONSTRAINT [PK__BtnBaseInfo] PRIMARY KEY  NONCLUSTERED ( [btnCode] )
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'add',N'����',130,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'addrow',N'����',110,2)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'alter',N'���',240,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'audit',N'���',200,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'autobuckup',N'�Զ�����',10,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'buckup',N'����',20,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'close',N'�ر�',230,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'del',N'ɾ��',150,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'delrow',N'ɾ��',120,2)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'edit',N'�޸�',140,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'export',N'����',270,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'first',N'��ҳ',70,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'import',N'����',125,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'last',N'ĩҳ',100,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'layout',N'����',30,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'lock',N'����',180,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'next',N'��ҳ',90,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'open',N'��',220,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'prev',N'��ҳ',80,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'print',N'��ӡ',250,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'printset',N'��ӡ����',40,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'refresh',N'ˢ��',50,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'save',N'����',160,2)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'sel',N'��ѯ',60,0)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'unaudit',N'����',210,1)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'undo',N'����',170,2)
INSERT [_BtnBaseInfo] ([btnCode],[btnName],[iOrder],[bEnable]) VALUES ( N'unlock',N'����',190,1)
if exists (select * from sysobjects where id = OBJECT_ID('[_Code]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_Code]

CREATE TABLE [_Code] (
[iID] [int]  IDENTITY (1, 1)  NOT NULL,
[sType] [varchar]  (50) NOT NULL,
[cCode] [varchar]  (50) NOT NULL,
[cText] [varchar]  (50) NOT NULL)

ALTER TABLE [_Code] WITH NOCHECK ADD  CONSTRAINT [PK__Code] PRIMARY KEY  NONCLUSTERED ( [iID] )
SET IDENTITY_INSERT [_Code] ON

INSERT [_Code] ([iID],[sType],[cCode],[cText]) VALUES ( 5,N'sex',N'0',N'�հ�')
INSERT [_Code] ([iID],[sType],[cCode],[cText]) VALUES ( 6,N'sex',N'1',N'��')
INSERT [_Code] ([iID],[sType],[cCode],[cText]) VALUES ( 7,N'sex',N'2',N'Ů')

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
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'BusinessManage',N'ҵ����',N'ImportDLL',N'S',0,0,100000,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmBuckUpDataBase',N'���ݱ���',N'FrameBaseFunction',N'SystemServer',0,0,302010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmCreateFormMenu',N'��������˵�',N'FrameBaseFunction',N'PprocedureAllocation',0,0,303020,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmLookUpData',N'���������ݵ���',N'FrameBaseFunction',N'PprocedureAllocation',0,0,303030,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmLookUpType',N'��������������',N'FrameBaseFunction',N'PprocedureAllocation',0,0,303025,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmRoleInfo',N'��ɫ����',N'FrameBaseFunction',N'SystemServer',0,0,301020,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmRoleRight',N'Ȩ������',N'FrameBaseFunction',N'SystemServer',0,0,301030,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmServerPro',N'�������˳���',N'FrameBaseFunction',N'SystemServer',0,0,309010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmTableCol',N'������Ϣ',N'FrameBaseFunction',N'PprocedureAllocation',0,0,303010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'FrmUserInfo',N'�û�����',N'FrameBaseFunction',N'SystemServer',0,0,301010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'Frm��Ŀ����',N'��Ŀ����',N'ImportDLL',N'BusinessManage',0,0,100020,0,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'Frm�������',N'�������',N'ImportDLL',N'BusinessManage',0,0,100020,0,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'Frmִ�д洢����',N'ִ�д洢����',N'ImportDLL',N'SystemServer',0,0,309010,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'PprocedureAllocation',N'��������',N'FrameBaseFunction',N'SystemServer',0,0,303000,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'S',N'ϵͳ',N'S',N'0',0,0,0,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'SystemServer',N'ϵͳ����',N'S',0,0,300000,1,1)
INSERT [_Form] ([fchrFrmNameID],[fchrFrmText],[fchrNameSpace],[fchrFrmUpName],[fbitHide],[fbitNoUse],[fIntOrderID],[bSystem],[bUse]) VALUES ( N'SystemSet',N'��������',N'ImportDLL',N'S',0,0,200000,1,1)
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
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmBuckUpDataBase',N'AutoBuckUp',N'�Զ�����',1,NULL,210)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmBuckUpDataBase',N'BuckUp',N'����',1,NULL,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmCreateFormMenu',N'del',N'ɾ��',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmCreateFormMenu',N'refresh',N'ˢ��',0,NULL,50)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmCreateFormMenu',N'save',N'����',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'addrow',N'����',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'del',N'ɾ��',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'delrow',N'ɾ��',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'export',N'����',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'import',N'����',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'layout',N'����',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'print',N'��ӡ',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'printset',N'��ӡ����',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'save',N'����',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'sel',N'��ѯ',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours1',N'undo',N'����',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'addrow',N'����',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'del',N'ɾ��',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'delrow',N'ɾ��',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'export',N'����',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'import',N'����',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'layout',N'����',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'print',N'��ӡ',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'printset',N'��ӡ����',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'save',N'����',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'sel',N'��ѯ',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours2',N'undo',N'����',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'addrow',N'����',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'del',N'ɾ��',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'delrow',N'ɾ��',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'export',N'����',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'import',N'����',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'layout',N'����',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'print',N'��ӡ',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'printset',N'��ӡ����',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'save',N'����',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'sel',N'��ѯ',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours3',N'undo',N'����',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'addrow',N'����',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'del',N'ɾ��',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'delrow',N'ɾ��',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'export',N'����',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'import',N'����',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'layout',N'����',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'print',N'��ӡ',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'printset',N'��ӡ����',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'save',N'����',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'sel',N'��ѯ',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours4',N'undo',N'����',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'addrow',N'����',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'del',N'ɾ��',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'delrow',N'ɾ��',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'export',N'����',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'import',N'����',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'layout',N'����',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'print',N'��ӡ',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'printset',N'��ӡ����',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'save',N'����',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'sel',N'��ѯ',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmItemHours5',N'undo',N'����',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'addrow',N'����',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'del',N'ɾ��',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'delrow',N'ɾ��',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'export',N'����',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'layout',N'����',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'print',N'��ӡ',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'printset',N'��ӡ����',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'refresh',N'ˢ��',0,NULL,50)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'save',N'����',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'sel',N'��ѯ',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpData',N'undo',N'����',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'addrow',N'����',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'del',N'ɾ��',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'delrow',N'ɾ��',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'export',N'����',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'layout',N'����',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'print',N'��ӡ',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'printset',N'��ӡ����',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'save',N'����',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'sel',N'��ѯ',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmLookUpType',N'undo',N'����',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmRoleInfo',N'add',N'����',0,NULL,100)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmRoleInfo',N'close',N'�ر�',0,NULL,800)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmRoleInfo',N'edit',N'�޸�',0,NULL,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmRoleInfo',N'open',N'��',0,NULL,600)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmRoleRight',N'Save',N'����',0,NULL,400)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmServerPro',N'close',N'�ر�',0,NULL,230)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmServerPro',N'open',N'��',0,NULL,220)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmTableCol',N'save',N'����',0,NULL,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmUserInfo',N'add',N'����',0,NULL,100)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmUserInfo',N'del',N'ɾ��',0,NULL,300)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmUserInfo',N'edit',N'�޸�',0,NULL,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'addrow',N'����',0,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'del',N'ɾ��',0,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'delrow',N'ɾ��',0,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'export',N'����',0,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'import',N'����',0,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'layout',N'����',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'print',N'��ӡ',0,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'printset',N'��ӡ����',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'save',N'����',0,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'sel',N'��ѯ',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'FrmWorkProcessBase',N'undo',N'����',0,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm��Ŀ����',N'export',N'����',1,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm��Ŀ����',N'sel',N'��ѯ',0,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm����',N'addrow',N'����',2,NULL,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm����',N'del',N'ɾ��',1,NULL,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm����',N'delrow',N'ɾ��',2,NULL,120)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm����',N'export',N'����',1,NULL,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm����',N'import',N'����',1,NULL,125)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm����',N'layout',N'����',0,NULL,30)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm����',N'print',N'��ӡ',1,NULL,250)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm����',N'printset',N'��ӡ����',0,NULL,40)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm����',N'save',N'����',2,NULL,160)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm����',N'sel',N'��ѯ',0,NULL,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[vchrRemark],[intOrder]) VALUES ( N'Frm����',N'undo',N'����',2,NULL,170)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm�������',N'export',N'����',0,270)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frm�������',N'sel',N'��ѯ',0,60)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frmִ�д洢����',N'addrow',N'����',0,110)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frmִ�д洢����',N'audit',N'ִ��',0,200)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frmִ�д洢����',N'del',N'ɾ��',0,150)
INSERT [_FormBtnInfo] ([fchrFrmNameID],[vchrBtnID],[vchrBtnText],[bEnable],[intOrder]) VALUES ( N'Frmִ�д洢����',N'save',N'����',0,160)
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
INSERT [_LookUpType] ([iID],[iType]) VALUES ( N'1',N'�����ڼ�')
INSERT [_LookUpType] ([iID],[iType]) VALUES ( N'2',N'����ERP�汾')
INSERT [_LookUpType] ([iID],[iType]) VALUES ( N'3',N'��ǰ����ERP�汾')
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
INSERT [_RoleInfo] ([vchrRoleID],[vchrRoleText],[bClosed],[dtmCreate],[bSystem]) VALUES ( N'01',N'����Ա',0,N'2013-03-25 0:00:00',0)
INSERT [_RoleInfo] ([vchrRoleID],[vchrRoleText],[bClosed],[dtmCreate],[bSystem]) VALUES ( N'administrator',N'ϵͳ����',0,N'2007-01-01 0:00:00',1)
if exists (select * from sysobjects where id = OBJECT_ID('[_RoleRight]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [_RoleRight]

CREATE TABLE [_RoleRight] (
[GUID] [uniqueidentifier]  NOT NULL DEFAULT (newid()),
[vchrRoleID] [varchar]  (50) NOT NULL,
[vchrRoleRight] [varchar]  (100) NULL,
[tstamp] [timestamp]  NOT NULL)

ALTER TABLE [_RoleRight] WITH NOCHECK ADD  CONSTRAINT [PK__RoleRight] PRIMARY KEY  NONCLUSTERED ( [GUID] )
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'1914230c-9de8-457e-8c1b-293daea13899',N'01',N'SystemSet|Frm��Ա���ձ�')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'd8b9660a-23e7-486f-b8a4-302368de3356',N'01',N'Frmн��ƾ֤����|save')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'4b489df1-71f4-40b6-bb2b-34cc9eeaf267',N'01',N'Frmн��ƾ֤����|edit')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'c8897ccc-c993-4c6c-9189-4b09ba3fee8d',N'01',N'S|SystemSet')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'6941b375-a1e7-492b-99b9-50d808a0a924',N'01',N'Frmн��ƾ֤����|sel')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'9165f9c6-4c75-454d-8d05-66abdc4041e7',N'01',N'BusinessManage|Frmн��ƾ֤����')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'28427618-737a-468f-a078-678fb6b423e5',N'01',N'S|BusinessManage')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'7b701cbb-d9ae-473e-9ec5-6f25d0bb7edf',N'01',N'Frm��Ա���ձ�|sel')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'b941604b-7d54-4c07-a1b0-83b59543cb20',N'01',N'0|S')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'c0c8a501-d4b0-4e3c-bae1-a030a30b50ed',N'01',N'Frm���Ŷ��ձ�|sel')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'19df4416-f4b1-46f6-83ed-a57ff8274e95',N'01',N'SystemSet|Frm��ƿ�Ŀ������Ŀ���ձ�')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'a7e73e71-d592-4732-80c0-d309d200bcad',N'01',N'Frm��ƿ�Ŀ���Ŷ��ձ�|refresh')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'2b954463-80d4-4e80-9477-e301a1b927a2',N'01',N'Frm��ƿ�Ŀ������Ŀ���ձ�|refresh')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'6915bb07-e25a-4a7c-a01b-fa90bdb7455a',N'01',N'SystemSet|Frm���Ŷ��ձ�')
INSERT [_RoleRight] ([GUID],[vchrRoleID],[vchrRoleRight]) VALUES ( N'0413b9c5-89ed-4cb2-86c6-fd98a6857059',N'01',N'SystemSet|Frm��ƿ�Ŀ���Ŷ��ձ�')
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
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[COLUMN_Text],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 124,N'SystemDB_GDJ',N'dbo',N'_LookUpType',N'iID',N'���',2,0,1,1)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[COLUMN_Text],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 125,N'SystemDB_GDJ',N'dbo',N'_LookUpType',N'iType',N'����',2,0,1,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[COLUMN_Text],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 126,N'SystemDB_GDJ',N'dbo',N'_LookUpType',N'Remark',N'��ע',2,0,1,0)
INSERT [_TableColInfo] ([iID],[TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[COLUMN_Text],[DATA_TYPE],[COLLATION_ADD],[bSystem],[bKey]) VALUES ( 127,N'SystemDB_GDJ',N'dbo',N'_LookUpType',N'tstamp',N'ʱ���',0,0,1,0)

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
INSERT [_UserInfo] ([vchrUid],[vchrName],[vchrPwd],[vchrRemark],[dtmCreate],[dtmClose],[bSystem]) VALUES ( N'admin',N'ϵͳ����Ա',N'ADBF8135A642B58A',N'ϵͳ����Ա',N'2007-10-10 0:00:00',N'2099-10-10 0:00:00',1)
INSERT [_UserInfo] ([vchrUid],[vchrName],[vchrPwd],[dtmCreate],[dtmClose],[bSystem]) VALUES ( N'hsy',N'��˼��',N'ADBF8135A642B58A',N'2013-03-25 0:00:00',N'2099-12-31 0:00:00',0)
INSERT [_UserInfo] ([vchrUid],[vchrName],[vchrPwd],[dtmCreate],[dtmClose],[bSystem]) VALUES ( N'sp',N'��ƽ',N'F9632974E9309A33',N'2013-03-25 0:00:00',N'2099-12-31 0:00:00',0)
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
[�ͻ�����] [varchar]  (20) NULL,
[���] [money]  NULL,
[����] [datetime]  NULL)

if exists (select * from sysobjects where id = OBJECT_ID('[�û�Ĭ������]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [�û�Ĭ������]

CREATE TABLE [�û�Ĭ������] (
[�ʺ�] [varchar]  (50) NOT NULL,
[����] [varchar]  (50) NOT NULL)

ALTER TABLE [�û�Ĭ������] WITH NOCHECK ADD  CONSTRAINT [PK_�û�Ĭ������] PRIMARY KEY  NONCLUSTERED ( [�ʺ�],[����] )
INSERT [�û�Ĭ������] ([�ʺ�],[����]) VALUES ( N'admin',N'003')
