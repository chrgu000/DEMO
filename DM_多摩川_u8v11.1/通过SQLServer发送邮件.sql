
exec sp_configure 'show advanced options',1
 RECONFIGURE WITH OVERRIDE  
 go
 exec sp_configure 'database mail xps',1 
 RECONFIGURE WITH OVERRIDE  
 go
 
--2.创建邮件帐户信息 
EXEC  msdb..sysmail_add_account_sp 
      @ACCOUNT_NAME ='TH',      -- 邮件帐户名称    --
      @EMAIL_ADDRESS ='121921624@qq.com' ,    -- 发件人邮件地址     --
      @DISPLAY_NAME ='TH',            -- 发件人姓名  --
      @REPLYTO_ADDRESS =NULL,    
      @DESCRIPTION = NULL,     
      @MAILSERVER_NAME = 'SMTP.qq.COM',       -- 邮件服务器地址    --
      @MAILSERVER_TYPE = 'SMTP',               -- 邮件协议      --
      @PORT =25,                              -- 邮件服务器端口  --
      @USERNAME = '121921624@qq.com',          -- 用户名  --
      @PASSWORD = 'yx220581',               -- 密码   --
      @USE_DEFAULT_CREDENTIALS =0,     
      @ENABLE_SSL =0,       
      @ACCOUNT_ID = NULL
      GO
      
      --3.数据库配置文件
    if exists(select name from msdb..sysmail_profile where name=N'MailSet')
    begin
     exec msdb..sysmail_delete_profile_sp
     @profile_name='MailSet'
     end
     exec msdb..sysmail_add_profile_sp
      @profile_name = 'MailSet',   -- profile 名称  
      @description = '数据库邮件配置文件',   -- profile 描述    
      @profile_id = null
         go
         
         
         
         --4.用户和邮件配置文件相关联
 exec msdb..sysmail_add_profileaccount_sp 
         @profile_name = 'MailSet',  -- profile 名称   
         @account_name    = 'TH',    -- account 名称     --与邮件账户名称一致
         @sequence_number = 1    -- account 在 profile 中顺序
         
--         --5.发送文本测试邮件
--         exec msdb..sp_send_dbmail
--          @profile_name='MailSet',
--          @recipients='13912610900@139.com',  --收件人
--          @subject='Test title this is test ',
--          @body=N'z中文邮件内容  中文邮件内容'
--          go

----6查看数据库邮件日志
--use msdb
--Go
--Select * From dbo.sysmail_log order by log_id desc
--GO  