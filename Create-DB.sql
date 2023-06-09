USE [UserManagement]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2023-06-05 4:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2023-06-05 4:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AliasName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Gender] [char](1) NULL,
	[HiringDate] [date] NULL,
	[BirthDay] [date] NULL,
	[Address] [nvarchar](50) NULL,
	[JobTitle] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreateDate] [date] NULL,
	[LastLoginDate] [date] NULL,
	[LastUploadDate] [date] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Role]    Script Date: 2023-06-05 4:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Role](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Dummy] [int] NULL,
 CONSTRAINT [PK_User_Role] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'admin')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'user')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (5, N'danh2410', N'202CB962AC59075B964B07152D234B70', N'Danh', N'Nguyen', N'Danh', N'nguyencongdanh2410@gmail.com', N'0838705527', N'm', NULL, NULL, N'CA', NULL, 1, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (7, N'danh', N'202CB962AC59075B964B07152D234B70', N'Danh', N'Nguyen Cong', NULL, N'nguyencongdanh2410@gmail.com.vn', N'0838705527', NULL, NULL, NULL, N'CA', NULL, 1, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (10, N'user', N'202CB962AC59075B964B07152D234B70', N'user', N'danh', NULL, N'user@yahoo.com', NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-06-02' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (11, N'Danh2', N'202CB962AC59075B964B07152D234B70', N'Danh', N'Nguyen', NULL, N'nguyencongdanh@gmail.com.vn', N'0838705527', N'm', NULL, NULL, N'CA', NULL, 1, CAST(N'2023-06-02' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (15, N'danh878787', N'202CB962AC59075B964B07152D234B70', N'Danh', N'danh', NULL, N'd@c', N'0838705527', NULL, NULL, NULL, N'CA', NULL, 1, CAST(N'2023-06-02' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (17, N'123', N'202CB962AC59075B964B07152D234B70', N'123', N'123', NULL, N'123@1234', NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-06-02' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (19, N'danh87876', N'202CB962AC59075B964B07152D234B70', N'123', N'123', NULL, N'123@1231', NULL, NULL, NULL, NULL, NULL, N'123', 1, CAST(N'2023-06-02' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (22, N'Danh22', N'202CB962AC59075B964B07152D234B70', N'123', N'danh', NULL, N'a@b', NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-06-02' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (24, N'danh8787', N'202CB962AC59075B964B07152D234B70', N'Danh', N'Nguyen', NULL, N'a@bcd', N'0838705527', NULL, NULL, NULL, N'CA', NULL, 1, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (25, N'danh87871', N'202CB962AC59075B964B07152D234B70', N'123', N'Nguyen', NULL, N'123@456', NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (28, N'danh87878', N'202CB962AC59075B964B07152D234B70', N'Danh', N'danh', NULL, N'123@13', NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-06-02' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (30, N'danh8787123', N'202CB962AC59075B964B07152D234B70', N'Danh', N'Nguyen', NULL, N'123456@1', NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-06-02' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (32, N'Danh21', N'202CB962AC59075B964B07152D234B70', N'Danh', N'Nguyen', N'Danh', N'danh@danh', NULL, N'm', NULL, NULL, NULL, N'job title', 1, CAST(N'2023-06-02' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (34, N'danh241', N'202CB962AC59075B964B07152D234B70', N'Danh', N'danh', N'Danh', N'nguyencongdanh2410@gmail.comf', N'0838705527', NULL, NULL, NULL, N'CA', NULL, 1, CAST(N'2023-06-02' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (37, N'testcreate', N'202CB962AC59075B964B07152D234B70', N'DanhTestCreate', N'Nguyen Cong', NULL, N'danh8787@yahoo.com', N'0838705527', NULL, NULL, NULL, N'CA', NULL, 1, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (38, N'isactivefalse', N'202CB962AC59075B964B07152D234B70', N'danh', N'danh', NULL, N'danh@gmail', NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (41, N'danh8787fgh', N'202CB962AC59075B964B07152D234B70', N'Danh', N'danh', NULL, N'nguyencongdanh2410@gmail.com123', N'0838705527', NULL, NULL, NULL, N'CA', NULL, 1, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (44, N'danh8787123123', N'202CB962AC59075B964B07152D234B70', N'Danh', N'Nguyen', NULL, N'nguyencongdanh2410@gmail', N'0838705527', NULL, NULL, NULL, N'CA', NULL, 0, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (47, N'danh8787333', N'202CB962AC59075B964B07152D234B70', N'Danh', N'Nguyen', NULL, N'nguyencongdanh2410@gmail.vn', N'0838705527', NULL, NULL, NULL, N'CA', NULL, 1, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (49, N'danh878711', N'202CB962AC59075B964B07152D234B70', N'123', N'Nguyen', NULL, N'123@45678', NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (50, N'testcreate1', N'202CB962AC59075B964B07152D234B70', N'danh', N'Nguyen', NULL, N'nguyencongdanh@gmail.com', N'0838705527', NULL, NULL, NULL, N'CA', NULL, 1, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [FirstName], [LastName], [AliasName], [Email], [Phone], [Gender], [HiringDate], [BirthDay], [Address], [JobTitle], [IsActive], [CreateDate], [LastLoginDate], [LastUploadDate], [IsDeleted]) VALUES (54, N'danh123', N'202CB962AC59075B964B07152D234B70', N'Danh', N'Nguyen Cong', NULL, N'123@123123', NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-06-05' AS Date), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (5, 1, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (5, 2, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (7, 1, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (7, 2, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (10, 2, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (11, 1, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (15, 1, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (17, 2, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (19, 1, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (19, 2, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (22, 2, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (24, 1, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (38, 2, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (47, 2, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (50, 1, NULL)
INSERT [dbo].[User_Role] ([UserId], [RoleId], [Dummy]) VALUES (54, 2, NULL)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Person]    Script Date: 2023-06-05 4:53:31 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UC_Person] UNIQUE NONCLUSTERED 
(
	[UserName] ASC,
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [df_IsActive]  DEFAULT ('True') FOR [IsActive]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [df_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [df_IsDeleted]  DEFAULT ('False') FOR [IsDeleted]
GO
ALTER TABLE [dbo].[User_Role]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User_Role] CHECK CONSTRAINT [FK_User_Role_Role]
GO
ALTER TABLE [dbo].[User_Role]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_User_Role] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[User_Role] CHECK CONSTRAINT [FK_User_Role_User_Role]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [CK_User] CHECK  (([Gender]='M' OR [Gender]='F'))
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [CK_User]
GO
