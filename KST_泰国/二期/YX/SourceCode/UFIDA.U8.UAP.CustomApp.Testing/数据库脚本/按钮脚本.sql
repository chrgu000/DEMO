use UFMeta_001
go
--创建来料检验单脚本
delete [AA_CustomerButton] where [cButtonKey] = 'btnQC' and [cVoucherKey] = '24'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
								, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
								, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
								, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnQC','default', 'U8CustDef', '24'
							, '24'	,'tlbCheck', '0', 'IEDIT','interface_test.RdRecord01_btnTHPrint'
							,'检验','zh-cn','','检验','Ctrl+N'
							,1,'检验列表','tlbCheck','tlbCheck')
							
--创建产品入库脚本							
delete [AA_CustomerButton] where [cButtonKey] = 'btnQC' and [cVoucherKey] = '0411'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
								, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
								, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
								, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnQC','default', 'U8CustDef', '0411'
							, '0411'	,'tlbCheck', '0', 'IEDIT','interface_test.RdRecord10_btnTHPrint'
							,'检验','zh-cn','','检验','Ctrl+N'
							,1,'检验列表','tlbCheck','tlbCheck')
							
--创建其他入库脚本							
delete [AA_CustomerButton] where [cButtonKey] = 'btnQC' and [cVoucherKey] = '0411'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
								, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
								, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
								, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnQC','default', 'U8CustDef', '0301'
							, '0301'	,'tlbCheck', '0', 'IEDIT','interface_test.RdRecord08_btnTHPrint'
							,'检验','zh-cn','','检验','Ctrl+N'
							,1,'检验列表','tlbCheck','tlbCheck')