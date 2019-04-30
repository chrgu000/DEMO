
--	以下以004账套安装脚本，如果是其他帐套请修改账套号  比如004  则 use UFMeta_004
use UFMeta_004

delete [AA_CustomerButton] where [cButtonKey] = 'btnTH001' and [cVoucherKey] = '25'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
	, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
	, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
	, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnTH001','default', 'U8CustDef', '25'
	, '25'	,'Cancelconfirm', '0', 'IEDIT','U8Btn_TH_001.TH001'
	,'包装袋出库','zh-cn','','包装袋出库','Ctrl+N'
	,1,'包装袋出库','Cancelconfirm','Cancelconfirm')


INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
	, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
	, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
	, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnTH001','default', 'U8CustDef', '25'
	, '25'	,'Cancelconfirm', '0', 'IEDIT','U8Btn_TH_001.TH001'
	,'Outbound packet','EN-US','','Outbound packet','Ctrl+N'
	,1,'Outbound packet','Cancelconfirm','Cancelconfirm')
							
							
							
							