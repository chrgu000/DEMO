use UFMeta_100
go

--�������ϼ��鵥�ű�
delete [AA_CustomerButton] where [cButtonKey] = 'btnQC' and [cVoucherKey] = '24'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
								, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
								, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
								, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnQC','default', 'U8CustDef', '24'
							, '24'	,'Print', '0', 'IEDIT','interface_test.RdRecord01_btnTHPrint'
							,'����','zh-cn','','����','Ctrl+N'
							,1,'�����б�','Print','Print')
							

--����Key=24
--��ť����:����,��ťTooltip:����,��ťKey:FilterSet;
--��ť����:��������,��ťTooltip:,��ťKey:PayApply;
--��ť����:�ָ�,��ťTooltip:�ָ�,��ťKey:Payment;
--��ť����:Ԥ��,��ťTooltip:Ԥ��,��ťKey:Preview;
--��ť����:ȷ��,��ťTooltip:ȷ��,��ťKey:OK;
--��ť����:��,��ťTooltip:��(Alt+O),��ťKey:Open;
--��ť����:����,��ťTooltip:����,��ťKey:QT;
--��ť����:����,��ťTooltip:����,��ťKey:Query;
--��ť����:����,��ťTooltip:����(Ctrl+K),��ťKey:QueryConfirm;
--��ť����:��λ,��ťTooltip:��λ,��ťKey:Locate;
--��ť����:����,��ťTooltip:����(Ctrl+L),��ťKey:Lock;
--��ť����:�ʼ�,��ťTooltip:�ʼ�,��ťKey:Mail;
--��ť����:ƥ��,��ťTooltip:ƥ��,��ťKey:Match;
--��ť����:�ͷ�,��ťTooltip:�ͷ�,��ťKey:Release;
--��ť����:����,��ťTooltip:����(ALT+L),��ťKey:removelock;
--��ť����:����,��ťTooltip:����,��ťKey:ReportCheck;
--��ť����:�����ύ,��ťTooltip:�����ύ(Ctrl+J),��ťKey:ReSubmit;
--��ť����:����,��ťTooltip:����(ALT+J),��ťKey:Return;
--��ť����:ȫѡ,��ťTooltip:ȫѡ,��ťKey:SelectAll;
--��ť����:����,��ťTooltip:����,��ťKey:Setting;
--��ť����:����,��ťTooltip:����,��ťKey:Settle;
--��ť����:ȡ��,��ťTooltip:ȡ��,��ťKey:Getcost;
--��ť����:����,��ťTooltip:����,��ťKey:Help;
--��ť����:�ύ,��ťTooltip:�ύ(Ctrl+J),��ťKey:Submit;
--��ť����:ģ��,��ťTooltip:ģ��,��ťKey:Template;
--��ť����:ȫ��,��ťTooltip:ȫ��,��ťKey:UnSelectAll;
--��ť����:�鿴��־,��ťTooltip:�鿴��־,��ťKey:ViewLog;
--��ť����:ת��,��ťTooltip:ת��,��ťKey:ChangeTo;
--��ť����:�ر�,��ťTooltip:�ر�(Alt+C),��ťKey:Close;
--��ť����:��Ŀ,��ťTooltip:��Ŀ,��ťKey:ColumnSet;
--��ť����:���,��ťTooltip:���(Ctrl+U),��ťKey:Confirm;
--��ť����:��ִͬ��,��ťTooltip:��ִͬ��,��ťKey:contractexec;
--��ť����:��ͬ����,��ťTooltip:��ͬ����,��ťKey:contractsettle;
--��ť����:����,��ťTooltip:����,��ťKey:CopyCreating;
--��ť����:����,��ťTooltip:����,��ťKey:CreateVouch;
--��ť����:�˳�,��ťTooltip:�˳�,��ťKey:Exit;
--��ť����:��ѯ,��ťTooltip:��ѯ,��ťKey:Filter;
--��ť����:����,��ťTooltip:����,��ťKey:CancelPayment;
--��ť����:����,��ťTooltip:����(ALT+U),��ťKey:Cancelconfirm;
--��ť����:���,��ťTooltip:���,��ťKey:AlterPO;
--��ť����:����,��ťTooltip:����,��ťKey:Aggregate;
--��ť����:����,��ťTooltip:����,��ťKey:Adjust;
--��ť����:��ӡ,��ťTooltip:��ӡ(Ctrl+P),��ťKey:Print;
--��ť����:���,��ťTooltip:���(ALT+E),��ťKey:Output;
--��ť����:����,��ťTooltip:����(F5),��ťKey:Add;
--��ť����:����,��ťTooltip:����(Ctrl+F5),��ťKey:Copy;
--��ť����:�ݸ�,��ťTooltip:�ݸ�,��ťKey:Draft;
--��ť����:�޸�,��ťTooltip:�޸�(F8),��ťKey:Modify;
--��ť����:ɾ��,��ťTooltip:ɾ��(Del),��ťKey:Delete;
--��ť����:����,��ťTooltip:����,��ťKey:Accessories;
--��ť����:����,��ťTooltip:����(Ctrl+Z),��ťKey:Discard;
--��ť����:����,��ťTooltip:����(F6),��ťKey:Save;
--��ť����:����,��ťTooltip:����,��ťKey:BatchBV;
--��ť����:��ע,��ťTooltip:��ע,��ťKey:Comment;
--��ť����:����,��ťTooltip:����,��ťKey:Discuss;
--��ť����:֪ͨ,��ťTooltip:֪ͨ,��ťKey:Notify;
--��ť����:�ϲ�,��ťTooltip:�ϲ�,��ťKey:QueryUp;
--��ť����:�²�,��ťTooltip:�²�,��ťKey:QueryDown;
--��ť����:��ʽ����,��ťTooltip:��ʽ����,��ťKey:VoucherDesign;
--��ť����:�����ʽ,��ťTooltip:�����ʽ,��ťKey:SaveTemplate;
--��ť����:��ʾģ��,��ťTooltip:��ʾģ��,��ťKey:ShowTemplate;
--��ť����:��ӡģ��,��ťTooltip:��ӡģ��,��ťKey:PrintTemplate;
--��ť����:ˢ��,��ťTooltip:ˢ��(Ctrl+R),��ťKey:Refresh;
--��ť����:����,��ťTooltip:����,��ťKey:First;
--��ť����:����,��ťTooltip:����,��ťKey:Previous;
--��ť����:����,��ťTooltip:����,��ťKey:Next;
--��ť����:ĩ��,��ťTooltip:ĩ��,��ťKey:Last;
--��ť����:�߼�,��ťTooltip:�߼�,��ťKey:advanced;
--��ť����:����,��ťTooltip:����,��ťKey:AddRecord;
--��ť����:����Դ,��ťTooltip:����Դ,��ťKey:DemandSrc;
--��ť����:����,��ťTooltip:����,��ťKey:InsertRow;
--��ť����:����,��ťTooltip:����,��ťKey:MulModify;
--��ť����:�۸�,��ťTooltip:�۸�,��ťKey:Price;
--��ť����:�ر�,��ťTooltip:�ر�,��ťKey:mnuCloseItem;
--��ť����:������,��ťTooltip:�и���,��ťKey:mnuCopyItem;
--��ť����:ȡ��,��ťTooltip:ȡ��,��ťKey:mnuGetCost;
--��ť����:��λ��¼,��ťTooltip:��λ��¼,��ťKey:mnuLocateRow;
--��ť����:��,��ťTooltip:��,��ťKey:mnuOpenItem;
--��ť����:�����,��ťTooltip:�в��,��ťKey:mnuSpiltItem;
--��ť����:�鿴�ִ���,��ťTooltip:�鿴�ִ���,��ťKey:mnuViewCurStock;
--��ť����:�ִ�����ѯ,��ťTooltip:�ִ�����ѯ,��ťKey:mnuViewStock;
--��ť����:��������,��ťTooltip:��������,��ťKey:mnuVouchRef;
--��ť����:�����б�,��ťTooltip:�����б�,��ťKey:mnuWindowList;
--��ť����:ȡ����,��ťTooltip:ȡ����,��ťKey:Getbatnum;
--��ť����:�ϲ���ʾ,��ťTooltip:�ϲ���ʾ,��ťKey:mnuAggrShow;
--��ť����:����,��ťTooltip:����,��ťKey:mnuBatchModify;
--��ť����:PTOѡ��,��ťTooltip:PTOѡ��,��ťKey:PTOmatch;
--��ť����:ɾ��,��ťTooltip:ɾ��,��ťKey:DeleteRecord;
--��ť����:-,��ťTooltip:-,��ťKey:bSeparator1;
--��ť����:����,��ťTooltip:����,��ťKey:CurStock;
--��ť����:��������,��ťTooltip:��������,��ťKey:RefVoucher;
--��ť����:-,��ťTooltip:-,��ťKey:bSeparator2;
--��ť����:����λ,��ťTooltip:����λ,��ťKey:Sort;
--��ť����:��ʾ��ʽ,��ťTooltip:��ʾ��ʽ,��ťKey:Showformat;