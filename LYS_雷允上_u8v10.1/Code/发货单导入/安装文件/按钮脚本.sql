use UFMeta_012
go			

--	������
delete [AA_CustomerButton] where [cButtonKey] = 'ImportDispatchList' and [cVoucherKey] = '01'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
	, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
	, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
	, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'ImportDispatchList','default', 'U8CustDef', '01'
	, '01'	,'Add', '0', 'IEDIT','U8Dll.DispatchList'
	,'����','zh-cn','','����','Ctrl+N'
	,1,'����','Add','Add')

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
	, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
	, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
	, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'ImportDispatchList','default', 'U8CustDef', '01'
	, '01'	,'Add', '0', 'IEDIT','U8Dll.DispatchList'
	,'Import','EN-US','','Import','Ctrl+N'
	,1,'Import','Add','Add')