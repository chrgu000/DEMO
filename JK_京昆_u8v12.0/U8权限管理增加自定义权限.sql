





delete  ufsystem.dbo.ua_auth_base where cAuth_Id LIKE 'UA%'
delete  ufsystem.dbo.UA_Auth_lang where cAuth_ID  LIKE 'UA%'
delete  ufsystem.dbo.ua_auth_base where cAuth_Id LIKE 'th%'
delete  ufsystem.dbo.UA_Auth_lang where cAuth_ID  LIKE 'th%'
declare @NewMenuID nvarchar(50)
set @NewMenuID='TH'
declare @cSub_Id varchar(50)
set @cSub_Id = 'UA'
insert  into ufsystem.dbo.ua_auth_base( cAuth_Id ,cSub_Id ,iGrade , cSupAuth_Id ,bEndGrade 
, iOrder , cAcc_Id , cAuthType ,cAllSupAuths , irepnum 
,cRepellent ,cRepellentModule ,cNotRepellent , cRepInDB ,cRepModInDB ,cNotRepInDB )
values  ( @NewMenuID , @cSub_Id , '1' , null , 'False' 
,'10' , null ,null , null , null
,null ,null , null ,null ,null ,null )
insert  into ufsystem.dbo.UA_Auth_lang
( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @NewMenuID, 'UAP���' )
insert  into ufsystem.dbo.UA_Auth_lang
( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @NewMenuID, 'UAP Plug-in' )
DECLARE @cMenuID VARCHAR(50)
DECLARE @cMenuNameCN VARCHAR(50)
SET @cMenuID = 'UA1'
SET @cMenuNameCN = '���鵵��'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
--SET @cMenuID = 'UA2'
--SET @cMenuNameCN = '�������ͳ�Ʋ�ѯ'
--insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
--iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
--cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
--values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
--'10' , null , null ,null , null ,
--null , null , null , null , null , null )
--insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
--values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA3'
SET @cMenuNameCN = '�ɹ����ͳ�Ʋ�ѯ'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA4'
SET @cMenuNameCN = '���۳���ͳ�Ʋ�ѯ'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA5'
SET @cMenuNameCN = '����Ԥ���Ʒ���'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA29'
SET @cMenuNameCN = '������Ŀ'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA25'
SET @cMenuNameCN = '��Ʒ���ͳ�Ʋ�ѯ'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA26'
SET @cMenuNameCN = '���ϳ���ͳ�Ʋ�ѯ'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA27'
SET @cMenuNameCN = '�������ͳ�Ƽ���ѯ'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA19'
SET @cMenuNameCN = 'Ӧ������'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA28'
SET @cMenuNameCN = '�շ�����ܲ�ѯ'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA21'
SET @cMenuNameCN = '��Ʒ����������ѯ'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA22'
SET @cMenuNameCN = '���������ѯ'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA23'
SET @cMenuNameCN = '��Ҫ���ʲɹ���ϸ���ѯ'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
SET @cMenuID = 'UA24'
SET @cMenuNameCN = 'Ӧ������'
insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @NewMenuID , 'True' ,
'10' , null , null ,null , null ,
null , null , null , null , null , null )
insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuNameCN)
