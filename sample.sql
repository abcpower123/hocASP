USE [master]
GO
/****** Object:  Database [Sample]    Script Date: 5/11/2018 1:59:33 AM ******/
CREATE DATABASE [Sample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sample', FILENAME = N'E:\SQLSever\MSSQL12.HAOSV\MSSQL\DATA\Sample.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Sample_log', FILENAME = N'E:\SQLSever\MSSQL12.HAOSV\MSSQL\DATA\Sample_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Sample] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sample] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sample] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sample] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sample] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sample] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sample] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sample] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sample] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sample] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sample] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sample] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Sample] SET  MULTI_USER 
GO
ALTER DATABASE [Sample] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sample] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sample] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sample] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Sample] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Sample]
GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 5/11/2018 1:59:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[ID] [int] NOT NULL,
	[ten] [nvarchar](50) NULL,
	[maTheLoai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 5/11/2018 1:59:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[maTheLoai] [int] NOT NULL,
	[tenTheLoai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[HangHoa] ([ID], [ten], [maTheLoai]) VALUES (1, N'PC gaming III', 1)
INSERT [dbo].[HangHoa] ([ID], [ten], [maTheLoai]) VALUES (2, N'Pc văn phòng', 1)
INSERT [dbo].[HangHoa] ([ID], [ten], [maTheLoai]) VALUES (3, N'Asus K555L', 2)
INSERT [dbo].[HangHoa] ([ID], [ten], [maTheLoai]) VALUES (4, N'Xiaomi redmi note 4x', 3)
INSERT [dbo].[HangHoa] ([ID], [ten], [maTheLoai]) VALUES (5, N'hao', 2)
INSERT [dbo].[HangHoa] ([ID], [ten], [maTheLoai]) VALUES (6, N'Iphone X', 3)
INSERT [dbo].[HangHoa] ([ID], [ten], [maTheLoai]) VALUES (7, N'Redmi note 5 Pro', 3)
INSERT [dbo].[TheLoai] ([maTheLoai], [tenTheLoai]) VALUES (1, N'PC')
INSERT [dbo].[TheLoai] ([maTheLoai], [tenTheLoai]) VALUES (2, N'Laptop')
INSERT [dbo].[TheLoai] ([maTheLoai], [tenTheLoai]) VALUES (3, N'Smartphone')
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [fk] FOREIGN KEY([maTheLoai])
REFERENCES [dbo].[TheLoai] ([maTheLoai])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [fk]
GO
USE [master]
GO
ALTER DATABASE [Sample] SET  READ_WRITE 
GO
