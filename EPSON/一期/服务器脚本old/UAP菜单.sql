

--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_3' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_3',N'�ɹ���Ʊ����',N'4',NULL,'2',N'PUM0306','1','','90001520.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_3' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_3',N'�ɹ���Ʊ����',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_3' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_3','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_3' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_3',N'Export invoice',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_3' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_3',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����



--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_2' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_2',N'���۷�Ʊ����',N'4',NULL,'2',N'SAM0304','1','','90001500.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_2' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_2',N'���۷�Ʊ����',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_2' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_2','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_2' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_2',N'Export invoice',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_2' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_2',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����

--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_1' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_1',N'ϵͳ����',N'4',NULL,'1',N'AA6','1','','90000280.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_1' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_1',N'ϵͳ����',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_1' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_1','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_1' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_1',N'SystemSet',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_1' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_1',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����


--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'BarCode' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'BarCode',N'��������',N'-1',N'UA','1',N'SCMG','0','','90000920.0000000000','1','',NULL,NULL,NULL,NULL)
GO
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_4' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_4',N'��������',N'4',NULL,'2',N'BarCode','1','','90000000.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'BarCode' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'BarCode',N'��������',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'BarCode' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'BarCode','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'BarCode' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'BarCode',N'Production management',N'EN-US')
GO
--UFMenu_Business_Lang�����



--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_6' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_6',N'�����������ձ�',N'4',NULL,'1',N'AA5','1','','90000003.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_6' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_6',N'�����������ձ�',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_6' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_6','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_6' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_6',N'Payment Term',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_6' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_6',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����

--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_7' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_7',N'�������۶���',N'4',NULL,'2',N'SAM0302','1','','90001500.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_7' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_7',N'�������۶���',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_7' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_7','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_7' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_7',N'Import SaleOrder',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_7' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_7',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����

--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_8' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_8',N'���ղ���',N'4',NULL,'2',N'BarCode','1','','90000020.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_8' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_8',N'���ղ���',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_8' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_8','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_8' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_8',N'Routing Info',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_8' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_8',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����


--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_9' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_9',N'�ͻ����ö�Ȳ�ѯ',N'4',NULL,'3',N'SAM0402','1','','90002110.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_9' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_9',N'�ͻ����ö�Ȳ�ѯ',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_9' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_9','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_9' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_9',N'Credit Line',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_9' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_9',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����



---ProcessList
--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_10' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_10',N'�����б�',N'4',NULL,'2',N'BarCode','1','','90000030.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_10' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_10',N'�����б�',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_10' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_10','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_10' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_10',N'ProcessList',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_10' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_10',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����


--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_11' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_11',N'�ӹ�����',N'4',NULL,'2',N'BarCode','1','','90000040.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_11' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_11',N'�ӹ�����',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_11' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_11','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_11' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_11',N'PlatingProcess',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_11' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_11',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����


--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_12' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_12',N'��ӡ������',N'4',NULL,'2',N'BarCode','1','','90000050.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_12' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_12',N'��ӡ������',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_12' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_12','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_12' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_12',N'PrintBarLabel',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_12' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_12',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����

--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_13' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_13',N'��ӡ����',N'4',NULL,'2',N'BarCode','1','','90000060.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_13' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_13',N'��ӡ����',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_13' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_13','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_13' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_13',N'PrintFlowCard',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_13' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_13',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����

--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_14' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_14',N'����ת��',N'4',NULL,'2',N'BarCode','1','','90000070.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_14' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_14',N'����ת��',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_14' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_14','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_14' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_14',N'Transfer',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_14' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_14',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����

--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_15' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_15',N'����ֲ�',N'4',NULL,'2',N'BarCode','1','','90000080.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_15' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_15',N'����ֲ�',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_15' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_15','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_15' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_15',N'Separate',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_15' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_15',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����



--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_16' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_16',N'��������',N'4',NULL,'2',N'BarCode','1','','90000090.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_16' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_16',N'��������',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_16' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_16','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_16' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_16',N'BarClose',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_16' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_16',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����



--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_17' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_17',N'��Ʒ����۸�',N'4',NULL,'2',N'BarCode','1','','90000100.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_17' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_17',N'��Ʒ����۸�',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_17' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_17',N'ItemNo process price',N'EN-US')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_17' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_17','',N'ZH-TW')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_17' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_17',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����




--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_18' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_18',N'�����뷢��',N'4',NULL,'2',N'BarCode','1','','90000110.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_18' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_18',N'�����뷢��',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_18' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_18','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_18' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_18',N'Scan Sales Shipment',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_18' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_18',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����


--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_19' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_19',N'������',N'4',NULL,'2',N'BarCode','1','','90000120.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_19' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_19',N'������',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_19' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_19','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_19' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_19',N'ProLine',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_19' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_19',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����


--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_20' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_20',N'��������',N'4',NULL,'2',N'SAM02','1','','90001280.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_20' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_20',N'��������',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_20' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_20','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_20' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_20',N'Sales set',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_20' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_20',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����




--UA_Menu��ʼ
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_21' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName) Values (N'TH_21',N'��������������',N'4',NULL,'2',N'BarCode','1','','90000130.0000000000','1','',NULL,NULL,NULL,NULL)
GO
--UA_Menu�����

--UFMenu_Business_Lang��ʼ
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_21' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_21',N'��������������',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_21' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_21','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_21' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_21',N'BarCode Adjust',N'EN-US')
GO
--UFMenu_Business_Lang�����

--UFSystem..UA_Idt��ʼ
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_21' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_21',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt�����

