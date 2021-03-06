USE [FillesDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddFiles]    Script Date: 06/10/2020 6:58:14 PM ******/
DROP PROCEDURE [dbo].[sp_AddFiles]
GO
/****** Object:  Table [dbo].[tblFiles]    Script Date: 06/10/2020 6:58:14 PM ******/
DROP TABLE [dbo].[tblFiles]
GO
/****** Object:  Table [dbo].[tblFiles]    Script Date: 06/10/2020 6:58:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileN] [nvarchar](50) NULL,
	[FilePath] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblFiles] ON 

INSERT [dbo].[tblFiles] ([Id], [FileN], [FilePath]) VALUES (1, N'Usama Text File', N'06102020151034usama.txt')
INSERT [dbo].[tblFiles] ([Id], [FileN], [FilePath]) VALUES (2, N'Tayyab Text File', N'06102020151053uuuuu.txt')
INSERT [dbo].[tblFiles] ([Id], [FileN], [FilePath]) VALUES (3, N'ghjk', N'06102020151033Test.txt')
INSERT [dbo].[tblFiles] ([Id], [FileN], [FilePath]) VALUES (1002, N'New', N'06102020151019Test.txt')
INSERT [dbo].[tblFiles] ([Id], [FileN], [FilePath]) VALUES (1003, N'Excel File', N'06102020151053New Microsoft Office Excel Worksheet.xlsx')
INSERT [dbo].[tblFiles] ([Id], [FileN], [FilePath]) VALUES (1004, N'Excel File', N'06102020161002New Microsoft Office Excel Worksheet.xlsx')
INSERT [dbo].[tblFiles] ([Id], [FileN], [FilePath]) VALUES (1005, N'Excel File', N'06102020161004New Microsoft Office Excel Worksheet.xlsx')
SET IDENTITY_INSERT [dbo].[tblFiles] OFF
/****** Object:  StoredProcedure [dbo].[sp_AddFiles]    Script Date: 06/10/2020 6:58:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_AddFiles]
(
@FileN nvarchar(50),@FilePath nvarchar(max)
)
as begin
Insert into tblFiles (FileN,FilePath) values (@FileN,@FilePath)
end
-------------------------------
GO
