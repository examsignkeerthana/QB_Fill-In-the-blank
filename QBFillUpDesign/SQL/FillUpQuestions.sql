USE [ProperQB]
GO
/****** Object:  Table [dbo].[FillUpQuestions]    Script Date: 03-02-2021 12:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FillUpQuestions](
	[Qid] [int] NOT NULL,
	[MajorVersion] [int] NULL,
	[MinorVersion] [decimal](5, 2) NULL,
	[Question] [varchar](1) NULL,
	[HasMedia] [bit] NULL,
	[MediaId] [int] NULL,
	[IsCurrent] [bit] NULL,
	[uploadedBy] [int] NULL,
	[UploadedDateTime] [datetime] NULL,
	[IsApproved] [bit] NULL,
	[ApproverId] [int] NULL,
	[ApprovedDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Qid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
