/****** Object:  Table [dbo].[_DeptDuty]    Script Date: 2016-01-24 17:39:53 ******/
DROP TABLE [dbo].[_DeptDuty]
GO

/****** Object:  Table [dbo].[_DeptDuty]    Script Date: 2016-01-24 17:39:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[_DeptDuty](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[cDept_num] [nvarchar](50) NULL,
	[cDutyCode] [nvarchar](50) NULL,
 CONSTRAINT [PK__DeptDuty] PRIMARY KEY CLUSTERED 
(
	[iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


