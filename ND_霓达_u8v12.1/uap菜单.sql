

declare @cMenuID varchar(50)
set @cMenuID =  'TH_1'

declare @cMenuName varchar(200)
set @cMenuName = '�����˻ص�(������ⵥ)'

--	�˵��ҽ�λ��
declare @cMenuPath varchar(200)
set @cMenuPath = 'ST0A12'

DELETE UFSystem..ua_idt WHERE ID = @cMenuID
DELETE UFSystem..ua_menu WHERE cMenu_Id = @cMenuID
DELETE UFSystem..ufmenu_business_lang WHERE MenuId = @cMenuID

insert into UFSystem..ua_idt(id,type,assembly,class,catalogtype) 
values( @cMenuID,2,'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','UFIDA.U8.UAP.CustomApp.Entrance.Entrance',0);

insert into UFSystem..ua_menu(cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,Paramters) 
values( @cMenuID,@cMenuName,'4',null,2,@cMenuPath,1,'',90000000,''); 

insert into UFSystem..ufmenu_business_lang values(@cMenuID,@cMenuName,'ZH-CN'); 
insert into UFSystem..ufmenu_business_lang values(@cMenuID,'','ZH-TW'); 
insert into UFSystem..ufmenu_business_lang values(@cMenuID,'','EN-US');


declare @newmenuid nvarchar(50)
set @newmenuid='TH_ND'

declare @cSub_Id varchar(50)
set @cSub_Id = 'UA'

delete  ufsystem.dbo.ua_auth_base where cAuth_Id =  @cMenuID
delete  ufsystem.dbo.UA_Auth_lang where cAuth_ID  =  @cMenuID

insert  into ufsystem.dbo.ua_auth_base(cAuth_Id , cSub_Id , iGrade ,  cSupAuth_Id , bEndGrade ,
          iOrder , cAcc_Id , cAuthType , cAllSupAuths ,irepnum ,
          cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @cMenuID ,@cSub_Id , '2' , @newmenuid , 'True' ,
          '10' , null , null ,null , null ,
          null , null , null , null , null , null )

insert  into ufsystem.dbo.UA_Auth_lang(localeid, cAuth_Id, cAuth_Name)
values  ( 'zh-CN', @cMenuID, @cMenuName)





--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'����ҵ����' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName,cMenuType) Values (N'����ҵ����',N'����ҵ����',N'-1',N'UA','1',N'SCMG','0','','90000900.0000000000','1','',NULL,NULL,NULL,NULL,NULL)
GO
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_2' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName,cMenuType) Values (N'TH_2',N'XML�ļ�ת��',N'4',NULL,'2',N'����ҵ����','1','','90000000.0000000000','1','',NULL,NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'����ҵ����' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'����ҵ����',N'����ҵ����',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'����ҵ����' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'����ҵ����','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'����ҵ����' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'����ҵ����','',N'EN-US')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_2' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_2',N'XML�ļ�ת��',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_2' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_2','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_2' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_2','',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_2' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_2',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����


--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_3' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName,cMenuType) Values (N'TH_3',N'�ɹ���⣨UAP��',N'4',NULL,'2',N'ST0A01','1','','90000207.0000000000','1','',NULL,NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_3' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_3',N'�ɹ���⣨UAP��',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_3' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_3','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_3' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_3','',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_3' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_3',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����

