USE [master]
GO
/****** Object:  Database [SalesFood]    Script Date: 4/26/2018 10:11:57 PM ******/
CREATE DATABASE [SalesFood]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SalesFood', FILENAME = N'E:\SQLSever\MSSQL12.HAOSV\MSSQL\DATA\SalesFood.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SalesFood_log', FILENAME = N'E:\SQLSever\MSSQL12.HAOSV\MSSQL\DATA\SalesFood_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SalesFood] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SalesFood].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SalesFood] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SalesFood] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SalesFood] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SalesFood] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SalesFood] SET ARITHABORT OFF 
GO
ALTER DATABASE [SalesFood] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SalesFood] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SalesFood] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SalesFood] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SalesFood] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SalesFood] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SalesFood] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SalesFood] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SalesFood] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SalesFood] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SalesFood] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SalesFood] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SalesFood] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SalesFood] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SalesFood] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SalesFood] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SalesFood] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SalesFood] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SalesFood] SET  MULTI_USER 
GO
ALTER DATABASE [SalesFood] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SalesFood] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SalesFood] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SalesFood] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SalesFood] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SalesFood]
GO
/****** Object:  UserDefinedFunction [dbo].[f_NextID]    Script Date: 4/26/2018 10:11:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[f_NextID]() RETURNS INT as
BEGIN
 
 RETURN ISNULL(IDENT_CURRENT('PRODUCTS'),0) + 1
 END

GO
/****** Object:  Table [dbo].[CATEGORY]    Script Date: 4/26/2018 10:11:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORY](
	[Id] [varchar](100) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK__CATEGORY__3214EC07E6A9AC36] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PRODUCTS]    Script Date: 4/26/2018 10:11:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCTS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [money] NOT NULL,
	[Description] [ntext] NULL,
	[Img] [nvarchar](max) NULL,
	[Cate_id] [varchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CATEGORY] ([Id], [Name]) VALUES (N'DR', N'Thức uống')
INSERT [dbo].[CATEGORY] ([Id], [Name]) VALUES (N'DV', N'DỊch vụ thêm')
INSERT [dbo].[CATEGORY] ([Id], [Name]) VALUES (N'FF', N'Thức ăn nhanh')
INSERT [dbo].[CATEGORY] ([Id], [Name]) VALUES (N'JP', N'Đồ ăn Nhật')
INSERT [dbo].[CATEGORY] ([Id], [Name]) VALUES (N'KR', N'Đồ ăn Hàn')
INSERT [dbo].[CATEGORY] ([Id], [Name]) VALUES (N'VN', N'Đồ ăn Việt')
SET IDENTITY_INSERT [dbo].[PRODUCTS] ON 

INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (1, N'Cà phê', 15000.0000, N'Cà phê đen đậm đà', N'img/1caphe.jpg', N'DR')
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (2, N'Chim cút nướng', 30000.0000, N'Ngon bổ rẻ', N'img/2chimcutnuong.jpg', N'VN')
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (3, N'Coca cola', 70000.0000, N'Coca 1 ly', N'img/3coca.png', N'DR')
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (4, N'Ếch xào xả ớt', 50000.0000, N'Ếch xào xả ớt nóng hổi thơm ngon không thể cưỡng lại', N'img/4echxaoxaot.jpg', N'VN')
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (5, N'Gỏi cá', 50000.0000, N'ngon ngon', N'img/5goica.jpg', N'VN')
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (6, N'Kimbap', 2000.0000, N'Nhiều bạn trẻ ưa chuộng', N'img/6kimbap.jpg', N'KR')
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (7, N'Mỳ cay', 35000.0000, N'Cay cay nóng nóng ngon ngon', N'img/7mycay.jpg', N'KR')
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (8, N'Nước lọc', 5000.0000, N'Nước uống lavie', N'img/8nuocloc.jpg', N'DR')
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (9, N'Sushi', 50000.0000, N'Lạ miệng+ hấp dẫn', N'img/9sushi.jpg', N'JP')
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (10, N'Toboki', 40000.0000, N'Bánh gạo cay - món ăn truyền thống xứ Hàn', N'img/10toboki.jpg', N'KR')
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (11, N'Pizza hải sản', 80000.0000, N'abc xyz', N'img/11pizza.jpg', N'JP')
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Price], [Description], [Img], [Cate_id]) VALUES (13, N'Lẩu hải sản', 100000.0000, N'3 người ăn', N'img/13lauhaisan.jpg', N'VN')
SET IDENTITY_INSERT [dbo].[PRODUCTS] OFF
ALTER TABLE [dbo].[PRODUCTS]  WITH CHECK ADD  CONSTRAINT [FK__PRODDUCT__Cate_i__117F9D94] FOREIGN KEY([Cate_id])
REFERENCES [dbo].[CATEGORY] ([Id])
GO
ALTER TABLE [dbo].[PRODUCTS] CHECK CONSTRAINT [FK__PRODDUCT__Cate_i__117F9D94]
GO
USE [master]
GO
ALTER DATABASE [SalesFood] SET  READ_WRITE 
GO
