delete  ufsystem.dbo.ua_auth_base
where   cAuth_Id like 'TH%'


delete  ufsystem.dbo.UA_Auth_lang
where   cAuth_ID like 'TH%'


insert  into ufsystem.dbo.ua_auth_base( cAuth_Id , cSub_Id ,iGrade , cSupAuth_Id , bEndGrade , iOrder ,cAcc_Id , cAuthType ,cAllSupAuths , irepnum , cRepellent , cRepellentModule , cNotRepellent ,cRepInDB ,  cRepModInDB , cNotRepInDB )
values  ( 'TH' , 'UA' , '1' , null , 'False' , '10' , null , null , null , null , null , null ,  null , null ,  null , null  )


insert  into ufsystem.dbo.UA_Auth_lang  ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', 'TH', '生产管理' )

insert  into ufsystem.dbo.UA_Auth_lang  ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', 'TH', 'Production Management' )

declare @MenuID varchar(50)
declare @MenuCN varchar(50)
declare @MenuEN varchar(50)
set @MenuID = 'TH_1'
set @MenuCN = '系统配置'
set @MenuEN = 'System Set'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_4'
set @MenuCN = '工步档案'
set @MenuEN = 'Process'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_5'
set @MenuCN = '存货工步对照表'
set @MenuEN = 'ItemCodeProcess'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )


set @MenuID = 'TH_8'
set @MenuCN = '工艺步骤'
set @MenuEN = 'Routing Info'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_10'
set @MenuCN = '工艺列表'
set @MenuEN = 'ProcessList'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_11'
set @MenuCN = '加工顺序'
set @MenuEN = 'PlatingProcess'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_12'
set @MenuCN = '打印条形码'
set @MenuEN = 'PrintBarLabel'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_13'
set @MenuCN = '打印工卡'
set @MenuEN = 'PrintFlowCard'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_14'
set @MenuCN = '工序转移'
set @MenuEN = 'Transfer'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_15'
set @MenuCN = '工序分拆'
set @MenuEN = 'Separate'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_16'
set @MenuCN = '条码作废'
set @MenuEN = 'BarClose'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_17'
set @MenuCN = '产品工序价格'
set @MenuEN = 'ItemNO Process Price'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_18'
set @MenuCN = '条形码发货'
set @MenuEN = 'Scan Sales Shipment'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )

set @MenuID = 'TH_20'
set @MenuCN = '销售设置'
set @MenuEN = 'Sales set'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )



set @MenuID = 'TH_21'
set @MenuCN = '条形码数量调整'
set @MenuEN = 'BarCode Adjust'
insert  into ufsystem.dbo.ua_auth_base ( cAuth_Id , cSub_Id , iGrade , cSupAuth_Id , bEndGrade , iOrder , cAcc_Id , cAuthType ,  cAllSupAuths ,irepnum ,cRepellent , cRepellentModule , cNotRepellent , cRepInDB ,cRepModInDB , cNotRepInDB  )
values  ( @MenuID , 'UA' , '2' ,'TH' , 'False' , '10' , null , null ,  null , null , null ,null , null , null , null , null  )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'zh-CN', @MenuID, @MenuCN )
insert  into ufsystem.dbo.UA_Auth_lang ( localeid, cAuth_Id, cAuth_Name )
values  ( 'en-US', @MenuID, @MenuEN )