use UFMeta_001
go
--�������ϼ��鵥�ű�
delete [AA_CustomerButton] where [cButtonKey] = 'btnQC' and [cVoucherKey] = '24'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
								, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
								, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
								, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnQC','default', 'U8CustDef', '24'
							, '24'	,'tlbCheck', '0', 'IEDIT','interface_test.RdRecord01_btnTHPrint'
							,'����','zh-cn','','����','Ctrl+N'
							,1,'�����б�','tlbCheck','tlbCheck')
							
--������Ʒ���ű�							
delete [AA_CustomerButton] where [cButtonKey] = 'btnQC' and [cVoucherKey] = '0411'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
								, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
								, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
								, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnQC','default', 'U8CustDef', '0411'
							, '0411'	,'tlbCheck', '0', 'IEDIT','interface_test.RdRecord10_btnTHPrint'
							,'����','zh-cn','','����','Ctrl+N'
							,1,'�����б�','tlbCheck','tlbCheck')
							
--�����������ű�							
delete [AA_CustomerButton] where [cButtonKey] = 'btnQC' and [cVoucherKey] = '0411'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
								, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
								, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
								, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnQC','default', 'U8CustDef', '0301'
							, '0301'	,'tlbCheck', '0', 'IEDIT','interface_test.RdRecord08_btnTHPrint'
							,'����','zh-cn','','����','Ctrl+N'
							,1,'�����б�','tlbCheck','tlbCheck')