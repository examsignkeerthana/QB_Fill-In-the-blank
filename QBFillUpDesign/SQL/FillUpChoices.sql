USE [ProperQB]
GO
/****** Object:  Table [dbo].[FillUpChoices]    Script Date: 03-02-2021 12:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FillUpChoices](
	[Qid] [int] NOT NULL,
	[AnsId] [int] NOT NULL,
	[AnsType] [varchar](1) NULL,
	[Answer] [varchar](1) NULL,
	[HasMedia] [bit] NULL,
	[MediaId] [int] NULL,
	[Position] [int] NULL,
	[Precision] [decimal](18, 0) NULL,
	[AlternateAnswer] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[Qid] ASC,
	[AnsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
