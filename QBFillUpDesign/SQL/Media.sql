USE [ProperQB]
GO
/****** Object:  Table [dbo].[Media]    Script Date: 03-02-2021 12:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Media](
	[MediaId] [int] NOT NULL,
	[class] [int] NULL,
	[Subject] [varchar](1) NULL,
	[FileName] [varchar](1) NULL,
	[FileContent] [nvarchar](max) NULL,
	[UploaderId] [int] NULL,
	[UploadedDateTime] [datetime] NULL,
	[UsingCount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MediaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
