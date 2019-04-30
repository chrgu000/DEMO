use UFMeta_012
go			

--	发货单
delete [AA_CustomerButton] where [cButtonKey] = 'ImportDispatchList' and [cVoucherKey] = '01'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
	, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
	, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
	, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'ImportDispatchList','default', 'U8CustDef', '01'
	, '01'	,'Add', '0', 'IEDIT','U8Dll.DispatchList'
	,'导入','zh-cn','','导入','Ctrl+N'
	,1,'导入','Add','Add')

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
	, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
	, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
	, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'ImportDispatchList','default', 'U8CustDef', '01'
	, '01'	,'Add', '0', 'IEDIT','U8Dll.DispatchList'
	,'Import','EN-US','','Import','Ctrl+N'
	,1,'Import','Add','Add')