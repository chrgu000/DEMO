
exec sp_configure 'show advanced options',1
 RECONFIGURE WITH OVERRIDE  
 go
 exec sp_configure 'database mail xps',1 
 RECONFIGURE WITH OVERRIDE  
 go
 
--2.�����ʼ��ʻ���Ϣ 
EXEC  msdb..sysmail_add_account_sp 
      @ACCOUNT_NAME ='TH',      -- �ʼ��ʻ�����    --
      @EMAIL_ADDRESS ='121921624@qq.com' ,    -- �������ʼ���ַ     --
      @DISPLAY_NAME ='TH',            -- ����������  --
      @REPLYTO_ADDRESS =NULL,    
      @DESCRIPTION = NULL,     
      @MAILSERVER_NAME = 'SMTP.qq.COM',       -- �ʼ���������ַ    --
      @MAILSERVER_TYPE = 'SMTP',               -- �ʼ�Э��      --
      @PORT =25,                              -- �ʼ��������˿�  --
      @USERNAME = '121921624@qq.com',          -- �û���  --
      @PASSWORD = 'yx220581',               -- ����   --
      @USE_DEFAULT_CREDENTIALS =0,     
      @ENABLE_SSL =0,       
      @ACCOUNT_ID = NULL
      GO
      
      --3.���ݿ������ļ�
    if exists(select name from msdb..sysmail_profile where name=N'MailSet')
    begin
     exec msdb..sysmail_delete_profile_sp
     @profile_name='MailSet'
     end
     exec msdb..sysmail_add_profile_sp
      @profile_name = 'MailSet',   -- profile ����  
      @description = '���ݿ��ʼ������ļ�',   -- profile ����    
      @profile_id = null
         go
         
         
         
         --4.�û����ʼ������ļ������
 exec msdb..sysmail_add_profileaccount_sp 
         @profile_name = 'MailSet',  -- profile ����   
         @account_name    = 'TH',    -- account ����     --���ʼ��˻�����һ��
         @sequence_number = 1    -- account �� profile ��˳��
         
--         --5.�����ı������ʼ�
--         exec msdb..sp_send_dbmail
--          @profile_name='MailSet',
--          @recipients='13912610900@139.com',  --�ռ���
--          @subject='Test title this is test ',
--          @body=N'z�����ʼ�����  �����ʼ�����'
--          go

----6�鿴���ݿ��ʼ���־
--use msdb
--Go
--Select * From dbo.sysmail_log order by log_id desc
--GO  