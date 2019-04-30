
--UA_Menu表开始
DELETE FROM UA_Menu WHERE  cMenu_Id=N'TH_1' 
INSERT INTO UA_Menu (cMenu_Id,cMenu_Name,cMenu_Eng,cSub_Id,IGrade,cSupMenu_Id,bEndGrade,cAuth_Id,iOrder,iImgIndex,Paramters,Depends,Flag,IsWebFlag,cImageName,cMenuType) Values (N'TH_1',N'报价单-开发',N'4',NULL,'2',N'SAM0301','1','','1310.0000000000','1','',NULL,NULL,NULL,NULL,NULL)
GO
--UA_Menu表结束

--UFMenu_Business_Lang表开始
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_1' AND LocaleId=N'ZH-CN' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_1',N'报价单-开发',N'ZH-CN')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_1' AND LocaleId=N'ZH-TW' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_1','',N'ZH-TW')
GO
DELETE FROM UFMenu_Business_Lang WHERE  MenuId=N'TH_1' AND LocaleId=N'EN-US' 
INSERT INTO UFMenu_Business_Lang (MenuId,Caption,LocaleId) Values (N'TH_1',N'报价单-开发',N'EN-US')
GO
--UFMenu_Business_Lang表结束

--UFSystem..UA_Idt表开始
DELETE FROM UFSystem..UA_Idt WHERE  id=N'TH_1' 
INSERT INTO UFSystem..UA_Idt (id,assembly,catalogtype,type,class,entrypoint,parameter,reserved) Values (N'TH_1',N'.\UAP\Runtime\UFIDA.U8.UAP.CustomApp.Entrance.dll','0','2',N'UFIDA.U8.UAP.CustomApp.Entrance.Entrance',NULL,NULL,NULL)
GO
--UFSystem..UA_Idt表结束

