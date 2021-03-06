USE [ProperQB]
GO
/****** Object:  Table [dbo].[QuestionMeta]    Script Date: 03-02-2021 12:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuestionMeta](
	[Qid] [int] NOT NULL,
	[QType] [varchar](200) NULL,
	[SubCount] [int] NULL,
	[Class] [varchar](200) NULL,
	[Subject] [varchar](200) NULL,
	[Chapter] [varchar](200) NULL,
	[Topic] [varchar](200) NULL,
	[ChoiceCount] [int] NULL,
	[HasRelationship] [bit] NULL,
	[CreatorId] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Qid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
