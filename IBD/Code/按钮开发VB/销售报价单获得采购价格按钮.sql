
delete [AA_CustomerButton] where [cButtonKey] = 'btntest2' and [cVoucherKey] = '16'

INSERT [AA_CustomerButton] ([cButtonID],[cButtonKey],[cButtonType],[cProjectNO],[cFormKey]
	,[cVoucherKey],[cKeyBefore],[iOrder],[cGroup],[cCustomerObjectName]
	,[cCaption],[cLocaleID],[cToolTip],[cHotKey]
	,[bInneralCommand],[cVariant],[cVisibleAsKey],[cEnableAsKey]) 
VALUES ( newid(),N'btntest2',N'default',N'U8CustDef',N'16'
	,N'16',N'refervouch',N'0',N'IEDIT',N'U8Btn_TH_002.TH002'
	,N'��ȡ�ɹ��۸�',N'zh-cn',N'��ȡ�ɹ��۸�',N'Ctrl+A'
	,1,N'��ȡ�ɹ��۸�',N'refervouch',N'refervouch')	


INSERT [AA_CustomerButton] ([cButtonID],[cButtonKey],[cButtonType],[cProjectNO],[cFormKey]
	,[cVoucherKey],[cKeyBefore],[iOrder],[cGroup],[cCustomerObjectName]
	,[cCaption],[cLocaleID],[cToolTip],[cHotKey]
	,[bInneralCommand],[cVariant],[cVisibleAsKey],[cEnableAsKey]) 
VALUES ( newid(),N'btntest2',N'default',N'U8CustDef',N'16'
	,N'16',N'refervouch',N'0',N'IEDIT',N'U8Btn_TH_002.TH002'
	,N'Acquisition price',N'EN-US',N'Acquisition price',N'Ctrl+A'
	,1,N'Acquisition price',N'refervouch',N'refervouch')	


	
