CREATE DATABASE [iVolunteer]

USE [iVolunteer]
GO
/****** Object:  Table [dbo].[SQL_AcAc_Relation]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_AcAc_Relation](
	[UserID] [varchar](24) NOT NULL,
	[FriendID] [varchar](24) NOT NULL,
	[Relation] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_SQL_Friendship] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[FriendID] ASC,
	[Relation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_AcAl_Relation]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_AcAl_Relation](
	[AlbumID] [varchar](24) NOT NULL,
	[UserID] [varchar](24) NOT NULL,
	[Relation] [int] NOT NULL,
 CONSTRAINT [PK_SQL_AcAl_Relation] PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_Account]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_Account](
	[UserID] [varchar](24) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IndentifyID] [varchar](20) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[DateOfChange] [datetime] NULL,
	[IsAdmin] [bit] NOT NULL,
	[IsActivate] [bit] NOT NULL,
	[IsConfirm] [bit] NOT NULL,
 CONSTRAINT [PK_Account_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_AcGr_Relation]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_AcGr_Relation](
	[UserID] [varchar](24) NOT NULL,
	[GroupID] [varchar](24) NOT NULL,
	[Relation] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_SQL_AcGr_Relation_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[GroupID] ASC,
	[Relation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_AcIm_Relation]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_AcIm_Relation](
	[ImageID] [varchar](24) NOT NULL,
	[UserID] [varchar](24) NOT NULL,
	[Relation] [int] NOT NULL,
 CONSTRAINT [PK_SQL_AcIm_Relation] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC,
	[UserID] ASC,
	[Relation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_AcPo_Relation]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_AcPo_Relation](
	[PostID] [varchar](24) NOT NULL,
	[UserID] [varchar](24) NOT NULL,
	[Relation] [int] NOT NULL,
 CONSTRAINT [PK_SQL_AcPo_Relation] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC,
	[UserID] ASC,
	[Relation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_AcPr_Relation]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_AcPr_Relation](
	[UserID] [varchar](24) NOT NULL,
	[ProjectID] [varchar](24) NOT NULL,
	[Relation] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_SQL_AcPr_Relation] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[ProjectID] ASC,
	[Relation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_Album]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_Album](
	[AlbumID] [varchar](24) NOT NULL,
	[ProjectID] [varchar](24) NULL,
	[GroupID] [varchar](24) NULL,
	[IsPublic] [bit] NOT NULL,
 CONSTRAINT [PK_AlbumSD] PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_Group]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_Group](
	[GroupID] [varchar](24) NOT NULL,
	[IsActivate] [bit] NOT NULL,
 CONSTRAINT [PK_GroupSD] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_GrPr_Relation]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_GrPr_Relation](
	[GroupID] [varchar](24) NOT NULL,
	[ProjectID] [varchar](24) NOT NULL,
	[Relation] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_SQL_GrPr_Relation] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC,
	[ProjectID] ASC,
	[Relation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_HubConnection]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_HubConnection](
	[UserID] [varchar](24) NOT NULL,
	[ConnectionID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SQL_HubConnection] PRIMARY KEY CLUSTERED 
(
	[ConnectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_Image]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_Image](
	[ImageID] [varchar](24) NOT NULL,
	[AlbumID] [varchar](24) NOT NULL,
 CONSTRAINT [PK_SQL_Image_1] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_Message]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_Message](
	[MessageID] [varchar](24) NOT NULL,
	[UserID] [varchar](24) NOT NULL,
 CONSTRAINT [PK_SQL_Message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_Plan]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_Plan](
	[PlanID] [varchar](24) NOT NULL,
	[ProjectID] [varchar](24) NOT NULL,
 CONSTRAINT [PK_SQL_Plan] PRIMARY KEY CLUSTERED 
(
	[PlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_Post]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_Post](
	[PostID] [varchar](24) NOT NULL,
	[DateCreate] [datetime] NOT NULL,
	[DateLastActivity] [datetime] NOT NULL,
	[ProjectID] [varchar](24) NULL,
	[GroupID] [varchar](24) NULL,
	[IsPinned] [bit] NULL,
	[IsPublic] [bit] NOT NULL,
 CONSTRAINT [PK_PostSD] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SQL_Project]    Script Date: 7/27/2016 8:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SQL_Project](
	[ProjectID] [varchar](24) NOT NULL,
	[InProgress] [bit] NOT NULL,
	[IsActivate] [bit] NOT NULL,
 CONSTRAINT [PK_ProjectSD] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[SQL_AcAc_Relation]  WITH CHECK ADD  CONSTRAINT [FK_User_Friend_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[SQL_Account] ([UserID])
GO
ALTER TABLE [dbo].[SQL_AcAc_Relation] CHECK CONSTRAINT [FK_User_Friend_Account]
GO
ALTER TABLE [dbo].[SQL_AcAc_Relation]  WITH CHECK ADD  CONSTRAINT [FK_User_Friend_Account1] FOREIGN KEY([FriendID])
REFERENCES [dbo].[SQL_Account] ([UserID])
GO
ALTER TABLE [dbo].[SQL_AcAc_Relation] CHECK CONSTRAINT [FK_User_Friend_Account1]
GO
ALTER TABLE [dbo].[SQL_AcAl_Relation]  WITH CHECK ADD  CONSTRAINT [FK_SQL_AcAl_Relation_SQL_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[SQL_Account] ([UserID])
GO
ALTER TABLE [dbo].[SQL_AcAl_Relation] CHECK CONSTRAINT [FK_SQL_AcAl_Relation_SQL_Account]
GO
ALTER TABLE [dbo].[SQL_AcAl_Relation]  WITH CHECK ADD  CONSTRAINT [FK_SQL_AcAl_Relation_SQL_Album] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[SQL_Album] ([AlbumID])
GO
ALTER TABLE [dbo].[SQL_AcAl_Relation] CHECK CONSTRAINT [FK_SQL_AcAl_Relation_SQL_Album]
GO
ALTER TABLE [dbo].[SQL_AcGr_Relation]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[SQL_Account] ([UserID])
GO
ALTER TABLE [dbo].[SQL_AcGr_Relation] CHECK CONSTRAINT [FK_User_Group_Account]
GO
ALTER TABLE [dbo].[SQL_AcGr_Relation]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_GroupSD] FOREIGN KEY([GroupID])
REFERENCES [dbo].[SQL_Group] ([GroupID])
GO
ALTER TABLE [dbo].[SQL_AcGr_Relation] CHECK CONSTRAINT [FK_User_Group_GroupSD]
GO
ALTER TABLE [dbo].[SQL_AcIm_Relation]  WITH CHECK ADD  CONSTRAINT [FK_SQL_AcIm_Relation_SQL_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[SQL_Account] ([UserID])
GO
ALTER TABLE [dbo].[SQL_AcIm_Relation] CHECK CONSTRAINT [FK_SQL_AcIm_Relation_SQL_Account]
GO
ALTER TABLE [dbo].[SQL_AcIm_Relation]  WITH CHECK ADD  CONSTRAINT [FK_SQL_AcIm_Relation_SQL_Image] FOREIGN KEY([ImageID])
REFERENCES [dbo].[SQL_Image] ([ImageID])
GO
ALTER TABLE [dbo].[SQL_AcIm_Relation] CHECK CONSTRAINT [FK_SQL_AcIm_Relation_SQL_Image]
GO
ALTER TABLE [dbo].[SQL_AcPo_Relation]  WITH CHECK ADD  CONSTRAINT [FK_SQL_AcPo_Relation_SQL_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[SQL_Account] ([UserID])
GO
ALTER TABLE [dbo].[SQL_AcPo_Relation] CHECK CONSTRAINT [FK_SQL_AcPo_Relation_SQL_Account]
GO
ALTER TABLE [dbo].[SQL_AcPo_Relation]  WITH CHECK ADD  CONSTRAINT [FK_SQL_AcPo_Relation_SQL_Post] FOREIGN KEY([PostID])
REFERENCES [dbo].[SQL_Post] ([PostID])
GO
ALTER TABLE [dbo].[SQL_AcPo_Relation] CHECK CONSTRAINT [FK_SQL_AcPo_Relation_SQL_Post]
GO
ALTER TABLE [dbo].[SQL_AcPr_Relation]  WITH CHECK ADD  CONSTRAINT [FK_User_Project_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[SQL_Account] ([UserID])
GO
ALTER TABLE [dbo].[SQL_AcPr_Relation] CHECK CONSTRAINT [FK_User_Project_Account]
GO
ALTER TABLE [dbo].[SQL_AcPr_Relation]  WITH CHECK ADD  CONSTRAINT [FK_User_Project_ProjectSD] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[SQL_Project] ([ProjectID])
GO
ALTER TABLE [dbo].[SQL_AcPr_Relation] CHECK CONSTRAINT [FK_User_Project_ProjectSD]
GO
ALTER TABLE [dbo].[SQL_Album]  WITH CHECK ADD  CONSTRAINT [FK_AlbumSD_GroupSD] FOREIGN KEY([GroupID])
REFERENCES [dbo].[SQL_Group] ([GroupID])
GO
ALTER TABLE [dbo].[SQL_Album] CHECK CONSTRAINT [FK_AlbumSD_GroupSD]
GO
ALTER TABLE [dbo].[SQL_Album]  WITH CHECK ADD  CONSTRAINT [FK_AlbumSD_ProjectSD] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[SQL_Project] ([ProjectID])
GO
ALTER TABLE [dbo].[SQL_Album] CHECK CONSTRAINT [FK_AlbumSD_ProjectSD]
GO
ALTER TABLE [dbo].[SQL_GrPr_Relation]  WITH CHECK ADD  CONSTRAINT [FK_SQL_GrPr_Relation_SQL_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[SQL_Group] ([GroupID])
GO
ALTER TABLE [dbo].[SQL_GrPr_Relation] CHECK CONSTRAINT [FK_SQL_GrPr_Relation_SQL_Group]
GO
ALTER TABLE [dbo].[SQL_GrPr_Relation]  WITH CHECK ADD  CONSTRAINT [FK_SQL_GrPr_Relation_SQL_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[SQL_Project] ([ProjectID])
GO
ALTER TABLE [dbo].[SQL_GrPr_Relation] CHECK CONSTRAINT [FK_SQL_GrPr_Relation_SQL_Project]
GO
ALTER TABLE [dbo].[SQL_HubConnection]  WITH CHECK ADD  CONSTRAINT [FK_SQL_HubConnection_SQL_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[SQL_Account] ([UserID])
GO
ALTER TABLE [dbo].[SQL_HubConnection] CHECK CONSTRAINT [FK_SQL_HubConnection_SQL_Account]
GO
ALTER TABLE [dbo].[SQL_Image]  WITH CHECK ADD  CONSTRAINT [FK_SQL_Image_SQL_Album] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[SQL_Album] ([AlbumID])
GO
ALTER TABLE [dbo].[SQL_Image] CHECK CONSTRAINT [FK_SQL_Image_SQL_Album]
GO
ALTER TABLE [dbo].[SQL_Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[SQL_Account] ([UserID])
GO
ALTER TABLE [dbo].[SQL_Message] CHECK CONSTRAINT [FK_Message_Account]
GO
ALTER TABLE [dbo].[SQL_Plan]  WITH CHECK ADD  CONSTRAINT [FK_Plan_ProjectSD] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[SQL_Project] ([ProjectID])
GO
ALTER TABLE [dbo].[SQL_Plan] CHECK CONSTRAINT [FK_Plan_ProjectSD]
GO
ALTER TABLE [dbo].[SQL_Post]  WITH CHECK ADD  CONSTRAINT [FK_PostSD_GroupSD] FOREIGN KEY([GroupID])
REFERENCES [dbo].[SQL_Group] ([GroupID])
GO
ALTER TABLE [dbo].[SQL_Post] CHECK CONSTRAINT [FK_PostSD_GroupSD]
GO
ALTER TABLE [dbo].[SQL_Post]  WITH CHECK ADD  CONSTRAINT [FK_PostSD_ProjectSD] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[SQL_Project] ([ProjectID])
GO
ALTER TABLE [dbo].[SQL_Post] CHECK CONSTRAINT [FK_PostSD_ProjectSD]
GO
/****** CREATE ADMIN ACCOUNT ******/
INSERT INTO [SQL_Account] VALUES ('admin','admin@iVolunteer.com','iVolunteer2016','admin','Admin','2016-01-01',1, 1, 1)
