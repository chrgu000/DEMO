
--	������004���װ�װ�ű�������������������޸����׺�  ����004  �� use UFMeta_004
use UFMeta_004

delete [AA_CustomerButton] where [cButtonKey] = 'btnTH001' and [cVoucherKey] = '25'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
	, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
	, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
	, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnTH001','default', 'U8CustDef', '25'
	, '25'	,'Cancelconfirm', '0', 'IEDIT','U8Btn_TH_001.TH001'
	,'��װ������','zh-cn','','��װ������','Ctrl+N'
	,1,'��װ������','Cancelconfirm','Cancelconfirm')


INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
	, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
	, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
	, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnTH001','default', 'U8CustDef', '25'
	, '25'	,'Cancelconfirm', '0', 'IEDIT','U8Btn_TH_001.TH001'
	,'Outbound packet','EN-US','','Outbound packet','Ctrl+N'
	,1,'Outbound packet','Cancelconfirm','Cancelconfirm')
							
							
							
							