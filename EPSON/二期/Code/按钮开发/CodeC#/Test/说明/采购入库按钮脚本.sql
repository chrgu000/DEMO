use UFMeta_100
go

--创建来料检验单脚本
delete [AA_CustomerButton] where [cButtonKey] = 'btnQC' and [cVoucherKey] = '24'

INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO]	, [cFormKey]
								, [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], [cCustomerObjectName]
								, [cCaption], [cLocaleID], [cImage], [cToolTip]	, [cHotKey]
								, [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'btnQC','default', 'U8CustDef', '24'
							, '24'	,'Print', '0', 'IEDIT','interface_test.RdRecord01_btnTHPrint'
							,'检验','zh-cn','','测试','Ctrl+N'
							,1,'检验列表','Print','Print')
							

--单据Key=24
--按钮标题:滤设,按钮Tooltip:滤设,按钮Key:FilterSet;
--按钮标题:付款申请,按钮Tooltip:,按钮Key:PayApply;
--按钮标题:现付,按钮Tooltip:现付,按钮Key:Payment;
--按钮标题:预览,按钮Tooltip:预览,按钮Key:Preview;
--按钮标题:确定,按钮Tooltip:确定,按钮Key:OK;
--按钮标题:打开,按钮Tooltip:打开(Alt+O),按钮Key:Open;
--按钮标题:齐套,按钮Tooltip:齐套,按钮Key:QT;
--按钮标题:参照,按钮Tooltip:参照,按钮Key:Query;
--按钮标题:查审,按钮Tooltip:查审(Ctrl+K),按钮Key:QueryConfirm;
--按钮标题:定位,按钮Tooltip:定位,按钮Key:Locate;
--按钮标题:锁定,按钮Tooltip:锁定(Ctrl+L),按钮Key:Lock;
--按钮标题:邮件,按钮Tooltip:邮件,按钮Key:Mail;
--按钮标题:匹配,按钮Tooltip:匹配,按钮Key:Match;
--按钮标题:释放,按钮Tooltip:释放,按钮Key:Release;
--按钮标题:解锁,按钮Tooltip:解锁(ALT+L),按钮Key:removelock;
--按钮标题:报检,按钮Tooltip:报检,按钮Key:ReportCheck;
--按钮标题:重新提交,按钮Tooltip:重新提交(Ctrl+J),按钮Key:ReSubmit;
--按钮标题:撤销,按钮Tooltip:撤销(ALT+J),按钮Key:Return;
--按钮标题:全选,按钮Tooltip:全选,按钮Key:SelectAll;
--按钮标题:设置,按钮Tooltip:设置,按钮Key:Setting;
--按钮标题:结算,按钮Tooltip:结算,按钮Key:Settle;
--按钮标题:取价,按钮Tooltip:取价,按钮Key:Getcost;
--按钮标题:帮助,按钮Tooltip:帮助,按钮Key:Help;
--按钮标题:提交,按钮Tooltip:提交(Ctrl+J),按钮Key:Submit;
--按钮标题:模板,按钮Tooltip:模板,按钮Key:Template;
--按钮标题:全消,按钮Tooltip:全消,按钮Key:UnSelectAll;
--按钮标题:查看日志,按钮Tooltip:查看日志,按钮Key:ViewLog;
--按钮标题:转入,按钮Tooltip:转入,按钮Key:ChangeTo;
--按钮标题:关闭,按钮Tooltip:关闭(Alt+C),按钮Key:Close;
--按钮标题:栏目,按钮Tooltip:栏目,按钮Key:ColumnSet;
--按钮标题:审核,按钮Tooltip:审核(Ctrl+U),按钮Key:Confirm;
--按钮标题:合同执行,按钮Tooltip:合同执行,按钮Key:contractexec;
--按钮标题:合同结算,按钮Tooltip:合同结算,按钮Key:contractsettle;
--按钮标题:生单,按钮Tooltip:生单,按钮Key:CopyCreating;
--按钮标题:生单,按钮Tooltip:生单,按钮Key:CreateVouch;
--按钮标题:退出,按钮Tooltip:退出,按钮Key:Exit;
--按钮标题:查询,按钮Tooltip:查询,按钮Key:Filter;
--按钮标题:弃付,按钮Tooltip:弃付,按钮Key:CancelPayment;
--按钮标题:弃审,按钮Tooltip:弃审(ALT+U),按钮Key:Cancelconfirm;
--按钮标题:变更,按钮Tooltip:变更,按钮Key:AlterPO;
--按钮标题:汇总,按钮Tooltip:汇总,按钮Key:Aggregate;
--按钮标题:调价,按钮Tooltip:调价,按钮Key:Adjust;
--按钮标题:打印,按钮Tooltip:打印(Ctrl+P),按钮Key:Print;
--按钮标题:输出,按钮Tooltip:输出(ALT+E),按钮Key:Output;
--按钮标题:增加,按钮Tooltip:增加(F5),按钮Key:Add;
--按钮标题:复制,按钮Tooltip:复制(Ctrl+F5),按钮Key:Copy;
--按钮标题:草稿,按钮Tooltip:草稿,按钮Key:Draft;
--按钮标题:修改,按钮Tooltip:修改(F8),按钮Key:Modify;
--按钮标题:删除,按钮Tooltip:删除(Del),按钮Key:Delete;
--按钮标题:附件,按钮Tooltip:附件,按钮Key:Accessories;
--按钮标题:放弃,按钮Tooltip:放弃(Ctrl+Z),按钮Key:Discard;
--按钮标题:保存,按钮Tooltip:保存(F6),按钮Key:Save;
--按钮标题:生成,按钮Tooltip:生成,按钮Key:BatchBV;
--按钮标题:批注,按钮Tooltip:批注,按钮Key:Comment;
--按钮标题:讨论,按钮Tooltip:讨论,按钮Key:Discuss;
--按钮标题:通知,按钮Tooltip:通知,按钮Key:Notify;
--按钮标题:上查,按钮Tooltip:上查,按钮Key:QueryUp;
--按钮标题:下查,按钮Tooltip:下查,按钮Key:QueryDown;
--按钮标题:格式设置,按钮Tooltip:格式设置,按钮Key:VoucherDesign;
--按钮标题:保存格式,按钮Tooltip:保存格式,按钮Key:SaveTemplate;
--按钮标题:显示模板,按钮Tooltip:显示模板,按钮Key:ShowTemplate;
--按钮标题:打印模板,按钮Tooltip:打印模板,按钮Key:PrintTemplate;
--按钮标题:刷新,按钮Tooltip:刷新(Ctrl+R),按钮Key:Refresh;
--按钮标题:首张,按钮Tooltip:首张,按钮Key:First;
--按钮标题:上张,按钮Tooltip:上张,按钮Key:Previous;
--按钮标题:下张,按钮Tooltip:下张,按钮Key:Next;
--按钮标题:末张,按钮Tooltip:末张,按钮Key:Last;
--按钮标题:高级,按钮Tooltip:高级,按钮Key:advanced;
--按钮标题:增行,按钮Tooltip:增行,按钮Key:AddRecord;
--按钮标题:需求源,按钮Tooltip:需求源,按钮Key:DemandSrc;
--按钮标题:插行,按钮Tooltip:插行,按钮Key:InsertRow;
--按钮标题:批改,按钮Tooltip:批改,按钮Key:MulModify;
--按钮标题:价格,按钮Tooltip:价格,按钮Key:Price;
--按钮标题:关闭,按钮Tooltip:关闭,按钮Key:mnuCloseItem;
--按钮标题:复制行,按钮Tooltip:行复制,按钮Key:mnuCopyItem;
--按钮标题:取价,按钮Tooltip:取价,按钮Key:mnuGetCost;
--按钮标题:定位记录,按钮Tooltip:定位记录,按钮Key:mnuLocateRow;
--按钮标题:打开,按钮Tooltip:打开,按钮Key:mnuOpenItem;
--按钮标题:拆分行,按钮Tooltip:行拆分,按钮Key:mnuSpiltItem;
--按钮标题:查看现存量,按钮Tooltip:查看现存量,按钮Key:mnuViewCurStock;
--按钮标题:现存量查询,按钮Tooltip:现存量查询,按钮Key:mnuViewStock;
--按钮标题:单据联查,按钮Tooltip:单据联查,按钮Key:mnuVouchRef;
--按钮标题:窗口列表,按钮Tooltip:窗口列表,按钮Key:mnuWindowList;
--按钮标题:取批号,按钮Tooltip:取批号,按钮Key:Getbatnum;
--按钮标题:合并显示,按钮Tooltip:合并显示,按钮Key:mnuAggrShow;
--按钮标题:批改,按钮Tooltip:批改,按钮Key:mnuBatchModify;
--按钮标题:PTO选配,按钮Tooltip:PTO选配,按钮Key:PTOmatch;
--按钮标题:删行,按钮Tooltip:删行,按钮Key:DeleteRecord;
--按钮标题:-,按钮Tooltip:-,按钮Key:bSeparator1;
--按钮标题:存量,按钮Tooltip:存量,按钮Key:CurStock;
--按钮标题:关联单据,按钮Tooltip:关联单据,按钮Key:RefVoucher;
--按钮标题:-,按钮Tooltip:-,按钮Key:bSeparator2;
--按钮标题:排序定位,按钮Tooltip:排序定位,按钮Key:Sort;
--按钮标题:显示格式,按钮Tooltip:显示格式,按钮Key:Showformat;