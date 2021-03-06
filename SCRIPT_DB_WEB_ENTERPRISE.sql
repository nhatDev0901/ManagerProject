CREATE DATABASE [DB_WEB_Enterprise]
GO
/****** Object:  Table [dbo].[COMMENTS]    Script Date: 14/04/2021 1:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMMENTS](
	[Com_ID] [int] IDENTITY(1,1) NOT NULL,
	[Com_Name] [nvarchar](max) NULL,
	[User_ID] [int] NULL,
	[Sub_ID] [int] NULL,
	[Created_Date] [datetime] NULL,
	[Created_By] [nvarchar](50) NULL,
 CONSTRAINT [PK_COMMENTS] PRIMARY KEY CLUSTERED 
(
	[Com_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DEADLINE]    Script Date: 14/04/2021 1:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DEADLINE](
	[DeadLine_ID] [int] IDENTITY(1,1) NOT NULL,
	[DeadLine_Start] [datetime] NULL,
	[DeadLine_End] [datetime] NULL,
	[Created_Date] [datetime] NULL,
	[DeadLine_Content] [nvarchar](200) NULL,
 CONSTRAINT [PK_DEADLINE] PRIMARY KEY CLUSTERED 
(
	[DeadLine_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DEPARTMENTS]    Script Date: 14/04/2021 1:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DEPARTMENTS](
	[Dep_ID] [int] IDENTITY(1,1) NOT NULL,
	[Dep_Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_DEPARTMENTS] PRIMARY KEY CLUSTERED 
(
	[Dep_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FILES]    Script Date: 14/04/2021 1:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FILES](
	[File_ID] [int] IDENTITY(1,1) NOT NULL,
	[File_Name] [nvarchar](500) NULL,
	[File_Path] [nvarchar](500) NULL,
	[Sub_Code] [nvarchar](50) NULL,
	[Sub_ID] [int] NULL,
 CONSTRAINT [PK_FILES] PRIMARY KEY CLUSTERED 
(
	[File_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROLES]    Script Date: 14/04/2021 1:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLES](
	[Role_ID] [int] IDENTITY(1,1) NOT NULL,
	[Role_Name] [varchar](50) NULL,
 CONSTRAINT [PK_ROLES] PRIMARY KEY CLUSTERED 
(
	[Role_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUBMITTIONS]    Script Date: 14/04/2021 1:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUBMITTIONS](
	[Sub_ID] [int] IDENTITY(1,1) NOT NULL,
	[Sub_Code] [nvarchar](50) NULL,
	[Sub_Title] [nvarchar](200) NULL,
	[Sub_Description] [nvarchar](max) NULL,
	[Created_Date] [datetime] NULL,
	[Created_By] [int] NULL,
	[Updated_Date] [datetime] NULL,
	[Updated_By] [int] NULL,
	[IsPublic] [int] NULL,
	[DeadLine_ID] [int] NULL,
 CONSTRAINT [PK_SUBMITTIONS] PRIMARY KEY CLUSTERED 
(
	[Sub_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 14/04/2021 1:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Dep_ID] [int] NULL,
	[Role_ID] [int] NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[COMMENTS] ON 

INSERT [dbo].[COMMENTS] ([Com_ID], [Com_Name], [User_ID], [Sub_ID], [Created_Date], [Created_By]) VALUES (1, N'Hello', 12, 5, CAST(N'2021-03-31T10:23:53.000' AS DateTime), N'QuangBinh')
INSERT [dbo].[COMMENTS] ([Com_ID], [Com_Name], [User_ID], [Sub_ID], [Created_Date], [Created_By]) VALUES (2, N'Hi', 12, 5, CAST(N'2021-03-31T10:24:04.960' AS DateTime), N'QuangBinh')
INSERT [dbo].[COMMENTS] ([Com_ID], [Com_Name], [User_ID], [Sub_ID], [Created_Date], [Created_By]) VALUES (3, N'haha', 2, 5, CAST(N'2021-03-31T10:32:13.270' AS DateTime), N'Coordinator2')
INSERT [dbo].[COMMENTS] ([Com_ID], [Com_Name], [User_ID], [Sub_ID], [Created_Date], [Created_By]) VALUES (4, N'How are you?', 2, 5, CAST(N'2021-03-31T10:32:32.423' AS DateTime), N'Coordinator2')
INSERT [dbo].[COMMENTS] ([Com_ID], [Com_Name], [User_ID], [Sub_ID], [Created_Date], [Created_By]) VALUES (5, N'Good, i will public your submission.', 2, 25, CAST(N'2021-03-31T11:13:26.683' AS DateTime), N'Coordinator2')
SET IDENTITY_INSERT [dbo].[COMMENTS] OFF
GO
SET IDENTITY_INSERT [dbo].[DEADLINE] ON 

INSERT [dbo].[DEADLINE] ([DeadLine_ID], [DeadLine_Start], [DeadLine_End], [Created_Date], [DeadLine_Content]) VALUES (2, CAST(N'2021-03-01T00:00:00.000' AS DateTime), CAST(N'2021-04-17T00:00:00.000' AS DateTime), CAST(N'2021-03-26T10:51:51.823' AS DateTime), N'SUMMER TERM')
SET IDENTITY_INSERT [dbo].[DEADLINE] OFF
GO
SET IDENTITY_INSERT [dbo].[DEPARTMENTS] ON 

INSERT [dbo].[DEPARTMENTS] ([Dep_ID], [Dep_Name]) VALUES (1, N'IT')
INSERT [dbo].[DEPARTMENTS] ([Dep_ID], [Dep_Name]) VALUES (2, N'Business')
INSERT [dbo].[DEPARTMENTS] ([Dep_ID], [Dep_Name]) VALUES (3, N'Graphic design')
INSERT [dbo].[DEPARTMENTS] ([Dep_ID], [Dep_Name]) VALUES (4, N'Management Event')
INSERT [dbo].[DEPARTMENTS] ([Dep_ID], [Dep_Name]) VALUES (5, N'Business administration')
INSERT [dbo].[DEPARTMENTS] ([Dep_ID], [Dep_Name]) VALUES (6, N'English')
SET IDENTITY_INSERT [dbo].[DEPARTMENTS] OFF
GO
SET IDENTITY_INSERT [dbo].[FILES] ON 

INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (1, N'45528.jpg', N'DucNhat_SM1_637523540891034315.jpg', N'SM1', 1)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (2, N'168336.jpg', N'DucNhat_SM1_637523540891513032.jpg', N'SM1', 1)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (3, N'525408.jpg', N'DucNhat_SM1_637523540891652671.jpg', N'SM1', 1)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (4, N'agile scrum.png', N'QuangBinh_SM2_637523604805986076.png', N'SM2', 2)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (5, N'angular.png', N'QuangBinh_SM3_637523605312566330.png', N'SM3', 3)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (6, N'c logo.png', N'QuangBinh_SM4_637523605948276353.png', N'SM4', 4)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (7, N'c++ logo.png', N'QuangBinh_SM5_637523606369937907.png', N'SM5', 5)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (8, N'C# logo.png', N'HungDung_SM6_637523607137012973.png', N'SM6', 6)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (9, N'Java-Logo.png', N'HungDung_SM7_637523607724092423.png', N'SM7', 7)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (10, N'my sql logo.png', N'HungDung_SM8_637523609291396476.png', N'SM8', 8)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (11, N'php logo.png', N'HungDung_SM9_637523609624446854.png', N'SM9', 9)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (17, N'html logo.png', N'QuangHai_SM10_637523613592172830.png', N'SM10', 10)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (18, N'css logo.png', N'QuangHai_SM11_637523613800608922.png', N'SM11', 11)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (19, N'js logo.png', N'QuangHai_SM12_637523614027242472.png', N'SM12', 12)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (20, N'jquery logo.png', N'QuangHai_SM13_637523614240601799.png', N'SM13', 13)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (21, N'oracle logo.png', N'DuyManh_SM14_637523615542782981.png', N'SM14', 14)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (22, N'power apps.png', N'DuyManh_SM15_637523615791506606.png', N'SM15', 15)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (23, N'power-bi-logo.png', N'DuyManh_SM16_637523615962964383.png', N'SM16', 16)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (24, N'python logo.png', N'DuyManh_SM17_637523616305942405.png', N'SM17', 17)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (25, N'R logo.png', N'VanLam_SM18_637523617021815797.png', N'SM18', 18)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (26, N'Rad.png', N'VanLam_SM19_637523617354738157.png', N'SM19', 19)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (27, N'react.png', N'VanLam_SM20_637523617632604423.png', N'SM20', 20)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (28, N'Ruby logo.png', N'VanLam_SM21_637523617892893318.png', N'SM21', 21)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (29, N'sql server logo.png', N'DangKhoa_SM22_637523618327864300.png', N'SM22', 22)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (30, N'swift logo.png', N'DangKhoa_SM23_637523618519426109.png', N'SM23', 23)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (31, N'vuejs.png', N'DangKhoa_SM24_637523618708627614.png', N'SM24', 24)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (32, N'waterfall.png', N'DangKhoa_SM25_637523619018491415.png', N'SM25', 25)
INSERT [dbo].[FILES] ([File_ID], [File_Name], [File_Path], [Sub_Code], [Sub_ID]) VALUES (34, N'image_184530.jpg', N'QuangBinh_SM28_637535554418612732.jpg', N'SM28', 28)
SET IDENTITY_INSERT [dbo].[FILES] OFF
GO
SET IDENTITY_INSERT [dbo].[ROLES] ON 

INSERT [dbo].[ROLES] ([Role_ID], [Role_Name]) VALUES (1, N'Student')
INSERT [dbo].[ROLES] ([Role_ID], [Role_Name]) VALUES (2, N'Coordinator')
INSERT [dbo].[ROLES] ([Role_ID], [Role_Name]) VALUES (3, N'Manager')
INSERT [dbo].[ROLES] ([Role_ID], [Role_Name]) VALUES (4, N'Guest')
SET IDENTITY_INSERT [dbo].[ROLES] OFF
GO
SET IDENTITY_INSERT [dbo].[SUBMITTIONS] ON 

INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (1, N'SM1', N'Submission 1 - Lorremm1', N'Lorem Ipsum  is simply dummy text of the printing and 
typesetting industry. Lorem Ipsum has been the industry''s standard dummy
 text ever since the 1500s,', CAST(N'2021-03-26T11:14:49.057' AS DateTime), 7, CAST(N'2021-03-29T10:18:38.540' AS DateTime), 1, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (2, N'SM2', N'Agile - Scrum', N'Introduce about Agile Scrum', CAST(N'2021-03-26T13:01:20.400' AS DateTime), 12, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (3, N'SM3', N'Angular', N'Introduce Angular', CAST(N'2021-03-26T13:02:11.250' AS DateTime), 12, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (4, N'SM4', N'C language', N'Introduce Objective-C', CAST(N'2021-03-26T13:03:14.820' AS DateTime), 12, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (5, N'SM5', N'C++ language', N'Introduce C++ language', CAST(N'2021-03-26T13:03:56.987' AS DateTime), 12, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (6, N'SM6', N'C# language', N'Introduce about C# language', CAST(N'2021-03-26T13:05:13.640' AS DateTime), 13, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (7, N'SM7', N'Java language', N'Introduce about Java language', CAST(N'2021-03-26T13:06:12.400' AS DateTime), 13, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (8, N'SM8', N'MySQL', N'Introduce about MySQL', CAST(N'2021-03-26T13:08:49.133' AS DateTime), 13, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (9, N'SM9', N'PHP language', N'Introduce about PHP language', CAST(N'2021-03-26T13:09:22.437' AS DateTime), 13, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (10, N'SM10', N'Html', N'Introduce Html', CAST(N'2021-03-26T13:09:57.427' AS DateTime), 14, CAST(N'2021-03-26T13:15:59.207' AS DateTime), 14, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (11, N'SM11', N'Css', N'Introduce about Css', CAST(N'2021-03-26T13:10:25.950' AS DateTime), 14, CAST(N'2021-03-26T13:16:20.053' AS DateTime), 14, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (12, N'SM12', N'Js', N'Introduce about Javascript', CAST(N'2021-03-26T13:16:42.717' AS DateTime), 14, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (13, N'SM13', N'Jquery', N'Introduce about Jquery', CAST(N'2021-03-26T13:17:04.050' AS DateTime), 14, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (14, N'SM14', N'Oracle', N'Introduce about Oracle Database', CAST(N'2021-03-26T13:19:14.270' AS DateTime), 15, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (15, N'SM15', N'Power Apps', N'Introduce about Power Apps', CAST(N'2021-03-26T13:19:39.147' AS DateTime), 15, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (16, N'SM16', N'Power BI', N'Introduce about Power BI', CAST(N'2021-03-26T13:19:56.293' AS DateTime), 15, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (17, N'SM17', N'Python language', N'Introduce about Python language', CAST(N'2021-03-26T13:20:30.587' AS DateTime), 15, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (18, N'SM18', N'R language', N'Introduce about R language', CAST(N'2021-03-26T13:21:42.173' AS DateTime), 16, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (19, N'SM19', N'RAD methology', N'Introduce RAD methology in software life cycle', CAST(N'2021-03-26T13:22:15.470' AS DateTime), 16, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (20, N'SM20', N'React JS', N'Introduce about React JS', CAST(N'2021-03-26T13:22:43.253' AS DateTime), 16, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (21, N'SM21', N'Ruby language', N'Introduce about Ruby language', CAST(N'2021-03-26T13:23:09.283' AS DateTime), 16, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (22, N'SM22', N'SQL Server', N'Introduce about SQL Server Database', CAST(N'2021-03-26T13:23:52.777' AS DateTime), 17, NULL, NULL, 0, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (23, N'SM23', N'Swift language', N'Introduce about Swift language', CAST(N'2021-03-26T13:24:11.937' AS DateTime), 17, NULL, NULL, 1, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (24, N'SM24', N'Vue JS', N'Introduce about Vue JS', CAST(N'2021-03-26T13:24:30.857' AS DateTime), 17, NULL, NULL, 1, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (25, N'SM25', N'Waterfall', N'Introduce about waterfall in software life cycle', CAST(N'2021-03-26T13:25:01.840' AS DateTime), 17, NULL, NULL, 1, NULL)
INSERT [dbo].[SUBMITTIONS] ([Sub_ID], [Sub_Code], [Sub_Title], [Sub_Description], [Created_Date], [Created_By], [Updated_Date], [Updated_By], [IsPublic], [DeadLine_ID]) VALUES (28, N'SM28', N'Requirement Management', N'This contribution writing about What is the Requirement and How to manage them?', CAST(N'2021-04-09T08:57:21.533' AS DateTime), 12, NULL, NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[SUBMITTIONS] OFF
GO
SET IDENTITY_INSERT [dbo].[USERS] ON 

INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (1, N'Coordinator1', N'e10adc3949ba59abbe56e057f20f883e', 1, 2, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (2, N'Coordinator2', N'e10adc3949ba59abbe56e057f20f883e', 2, 2, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (3, N'Coordinator3', N'e10adc3949ba59abbe56e057f20f883e', 3, 2, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (4, N'Coordinator4', N'e10adc3949ba59abbe56e057f20f883e', 4, 2, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (5, N'Coordinator5', N'e10adc3949ba59abbe56e057f20f883e', 5, 2, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (6, N'Coordinator6', N'e10adc3949ba59abbe56e057f20f883e', 6, 2, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (7, N'DucNhat', N'e10adc3949ba59abbe56e057f20f883e', 1, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (8, N'NhuKhanh', N'e10adc3949ba59abbe56e057f20f883e', 1, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (9, N'QuangPhung', N'e10adc3949ba59abbe56e057f20f883e', 1, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (10, N'VuDung', N'e10adc3949ba59abbe56e057f20f883e', 1, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (11, N'TrieuDuong', N'e10adc3949ba59abbe56e057f20f883e', 1, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (12, N'QuangBinh', N'e10adc3949ba59abbe56e057f20f883e', 2, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (13, N'HungDung', N'e10adc3949ba59abbe56e057f20f883e', 2, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (14, N'QuangHai', N'e10adc3949ba59abbe56e057f20f883e', 2, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (15, N'DuyManh', N'e10adc3949ba59abbe56e057f20f883e', 2, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (16, N'VanLam', N'e10adc3949ba59abbe56e057f20f883e', 2, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (17, N'DangKhoa', N'e10adc3949ba59abbe56e057f20f883e', 2, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (18, N'VuKhanh', N'e10adc3949ba59abbe56e057f20f883e', 3, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (19, N'LinhPham', N'e10adc3949ba59abbe56e057f20f883e', 3, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (20, N'ThaiHai', N'e10adc3949ba59abbe56e057f20f883e', 3, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (21, N'TrungNam', N'e10adc3949ba59abbe56e057f20f883e', 3, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (22, N'HongNhi', N'e10adc3949ba59abbe56e057f20f883e', 4, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (23, N'QuangTran', N'e10adc3949ba59abbe56e057f20f883e', 4, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (24, N'Thanhtu', N'e10adc3949ba59abbe56e057f20f883e', 4, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (25, N'TrongCanh', N'e10adc3949ba59abbe56e057f20f883e', 4, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (26, N'NguyenDuyen', N'e10adc3949ba59abbe56e057f20f883e', 4, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (27, N'Tristanna', N'e10adc3949ba59abbe56e057f20f883e', 5, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (28, N'HongNhung', N'e10adc3949ba59abbe56e057f20f883e', 5, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (29, N'QuangDai', N'e10adc3949ba59abbe56e057f20f883e', 5, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (30, N'ThanhNhan', N'e10adc3949ba59abbe56e057f20f883e', 5, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (31, N'MichelJason', N'e10adc3949ba59abbe56e057f20f883e', 6, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (32, N'NhuTruc', N'e10adc3949ba59abbe56e057f20f883e', 6, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (33, N'NgocNguyen', N'e10adc3949ba59abbe56e057f20f883e', 6, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (34, N'HoaNguyen', N'e10adc3949ba59abbe56e057f20f883e', 6, 1, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (35, N'Manager1', N'e10adc3949ba59abbe56e057f20f883e', 1, 3, N'nguyw461@gmail.com')
INSERT [dbo].[USERS] ([User_ID], [Username], [Password], [Dep_ID], [Role_ID], [Email]) VALUES (36, N'Guest1', N'e10adc3949ba59abbe56e057f20f883e', 1, 4, N'nguyw461@gmail.com')
SET IDENTITY_INSERT [dbo].[USERS] OFF
GO
ALTER TABLE [dbo].[COMMENTS]  WITH CHECK ADD  CONSTRAINT [FK_COMMENTS_SUBMITTIONS] FOREIGN KEY([Sub_ID])
REFERENCES [dbo].[SUBMITTIONS] ([Sub_ID])
GO
ALTER TABLE [dbo].[COMMENTS] CHECK CONSTRAINT [FK_COMMENTS_SUBMITTIONS]
GO
ALTER TABLE [dbo].[COMMENTS]  WITH CHECK ADD  CONSTRAINT [FK_COMMENTS_USERS] FOREIGN KEY([User_ID])
REFERENCES [dbo].[USERS] ([User_ID])
GO
ALTER TABLE [dbo].[COMMENTS] CHECK CONSTRAINT [FK_COMMENTS_USERS]
GO
ALTER TABLE [dbo].[FILES]  WITH CHECK ADD  CONSTRAINT [FK_FILES_SUBMITTIONS] FOREIGN KEY([Sub_ID])
REFERENCES [dbo].[SUBMITTIONS] ([Sub_ID])
GO
ALTER TABLE [dbo].[FILES] CHECK CONSTRAINT [FK_FILES_SUBMITTIONS]
GO
ALTER TABLE [dbo].[SUBMITTIONS]  WITH CHECK ADD  CONSTRAINT [FK_SUBMITTIONS_DEADLINE] FOREIGN KEY([DeadLine_ID])
REFERENCES [dbo].[DEADLINE] ([DeadLine_ID])
GO
ALTER TABLE [dbo].[SUBMITTIONS] CHECK CONSTRAINT [FK_SUBMITTIONS_DEADLINE]
GO
ALTER TABLE [dbo].[SUBMITTIONS]  WITH CHECK ADD  CONSTRAINT [FK_SUBMITTIONS_USERS] FOREIGN KEY([Created_By])
REFERENCES [dbo].[USERS] ([User_ID])
GO
ALTER TABLE [dbo].[SUBMITTIONS] CHECK CONSTRAINT [FK_SUBMITTIONS_USERS]
GO
ALTER TABLE [dbo].[SUBMITTIONS]  WITH CHECK ADD  CONSTRAINT [FK_SUBMITTIONS_USERS1] FOREIGN KEY([Updated_By])
REFERENCES [dbo].[USERS] ([User_ID])
GO
ALTER TABLE [dbo].[SUBMITTIONS] CHECK CONSTRAINT [FK_SUBMITTIONS_USERS1]
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD  CONSTRAINT [FK_USERS_DEPARTMENTS] FOREIGN KEY([Dep_ID])
REFERENCES [dbo].[DEPARTMENTS] ([Dep_ID])
GO
ALTER TABLE [dbo].[USERS] CHECK CONSTRAINT [FK_USERS_DEPARTMENTS]
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD  CONSTRAINT [FK_USERS_ROLES] FOREIGN KEY([Role_ID])
REFERENCES [dbo].[ROLES] ([Role_ID])
GO
ALTER TABLE [dbo].[USERS] CHECK CONSTRAINT [FK_USERS_ROLES]
GO
