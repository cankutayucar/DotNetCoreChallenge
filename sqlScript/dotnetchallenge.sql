USE [master]
GO
/****** Object:  Database [DotNetCoreChallenge]    Script Date: 1/6/2023 11:34:07 AM ******/
CREATE DATABASE [DotNetCoreChallenge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DotNetCoreChallenge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DotNetCoreChallenge.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DotNetCoreChallenge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DotNetCoreChallenge_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DotNetCoreChallenge] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DotNetCoreChallenge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DotNetCoreChallenge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET ARITHABORT OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DotNetCoreChallenge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DotNetCoreChallenge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DotNetCoreChallenge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DotNetCoreChallenge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DotNetCoreChallenge] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DotNetCoreChallenge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DotNetCoreChallenge] SET  MULTI_USER 
GO
ALTER DATABASE [DotNetCoreChallenge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DotNetCoreChallenge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DotNetCoreChallenge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DotNetCoreChallenge] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DotNetCoreChallenge] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DotNetCoreChallenge] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DotNetCoreChallenge] SET QUERY_STORE = OFF
GO
USE [DotNetCoreChallenge]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/6/2023 11:34:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 1/6/2023 11:34:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[IsCompanyConfirmed] [bit] NOT NULL,
	[OrderStartTime] [datetime2](7) NOT NULL,
	[OrderEndTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 1/6/2023 11:34:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameOfPersonPlacingOrder] [nvarchar](max) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 1/6/2023 11:34:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Stock] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230105211019_Initialized', N'7.0.1')
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([Id], [CompanyName], [IsCompanyConfirmed], [OrderStartTime], [OrderEndTime]) VALUES (1, N'Deneme', 1, CAST(N'2023-01-06T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-06T23:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [IsCompanyConfirmed], [OrderStartTime], [OrderEndTime]) VALUES (2, N'Deneme2', 1, CAST(N'2023-01-06T08:00:00.0000000' AS DateTime2), CAST(N'2023-01-06T23:30:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [NameOfPersonPlacingOrder], [OrderDate], [CompanyId], [ProductId]) VALUES (1, N'Can', CAST(N'2023-01-06T00:51:04.3889159' AS DateTime2), 1, 1)
INSERT [dbo].[Orders] ([Id], [NameOfPersonPlacingOrder], [OrderDate], [CompanyId], [ProductId]) VALUES (2, N'cankutay', CAST(N'2023-01-06T11:31:06.0095806' AS DateTime2), 2, 2)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductName], [Stock], [Price], [CompanyId]) VALUES (1, N'DenemeUrun', 10, CAST(120.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Products] ([Id], [ProductName], [Stock], [Price], [CompanyId]) VALUES (2, N'Deneme2Urun', 1000, CAST(5000.00 AS Decimal(18, 2)), 2)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
/****** Object:  Index [IX_Orders_CompanyId]    Script Date: 1/6/2023 11:34:07 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_CompanyId] ON [dbo].[Orders]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_ProductId]    Script Date: 1/6/2023 11:34:07 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_ProductId] ON [dbo].[Orders]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CompanyId]    Script Date: 1/6/2023 11:34:07 AM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CompanyId] ON [dbo].[Products]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Companies_CompanyId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Companies_CompanyId]
GO
USE [master]
GO
ALTER DATABASE [DotNetCoreChallenge] SET  READ_WRITE 
GO
