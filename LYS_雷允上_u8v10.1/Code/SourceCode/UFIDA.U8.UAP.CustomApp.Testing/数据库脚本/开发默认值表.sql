

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[����Ĭ��ֵ��]') AND type in (N'U')) 
	DROP TABLE [dbo].[����Ĭ��ֵ��]

CREATE TABLE [dbo].[����Ĭ��ֵ��](
	[iType] [varchar](50) NOT NULL,
	[s1] [varchar](50) NOT NULL,
	[s2] [varchar](50) NULL,
	[s3] [varchar](50) NULL,
	[s4] [varchar](50) NULL,
	[��ע] [varchar](200) NULL
)

insert into ����Ĭ��ֵ��(iType,s1,��ע) values(1,'����ժҪ','ժҪĬ��')
insert into ����Ĭ��ֵ��(iType,s1,��ע) values(2,'1002010103','��ͷ��ĿĬ��')
insert into ����Ĭ��ֵ��(iType,s1,��ע) values(3,'102901000001','�����ĿĬ��')