USE [master]
GO
/****** Object:  Database [HelenSposaDB]    Script Date: 24.12.2021 05:08:46 ******/
CREATE DATABASE [HelenSposaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HelenSposaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HelenSposaDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HelenSposaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HelenSposaDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HelenSposaDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HelenSposaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HelenSposaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HelenSposaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HelenSposaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HelenSposaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HelenSposaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HelenSposaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HelenSposaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HelenSposaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HelenSposaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HelenSposaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HelenSposaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HelenSposaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HelenSposaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HelenSposaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HelenSposaDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HelenSposaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HelenSposaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HelenSposaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HelenSposaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HelenSposaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HelenSposaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HelenSposaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HelenSposaDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HelenSposaDB] SET  MULTI_USER 
GO
ALTER DATABASE [HelenSposaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HelenSposaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HelenSposaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HelenSposaDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HelenSposaDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HelenSposaDB]
GO
/****** Object:  Table [dbo].[BasketDetails]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasketDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BasketId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[Price] [decimal](8, 2) NOT NULL,
	[SaleType] [bit] NULL,
 CONSTRAINT [PK_BasketDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Baskets]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Baskets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DateOfSale] [datetime] NOT NULL,
	[Photo] [image] NULL,
	[IsDone] [bit] NOT NULL,
 CONSTRAINT [PK_Baskets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasketsEvents]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasketsEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BasketId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
 CONSTRAINT [PK_BasketsEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[PhoneCode] [nvarchar](4) NOT NULL,
	[PhoneNumber] [varchar](15) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[No] [char](1) NULL,
	[IsDone] [bit] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 20) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventTypes]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](15) NOT NULL,
 CONSTRAINT [PK_EventTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Amount] [decimal](8, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Description] [varchar](150) NULL,
 CONSTRAINT [PK_Expenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenseTypes]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ExpensesTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incomes]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incomes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BasketId] [int] NOT NULL,
	[Amount] [decimal](8, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Description] [varchar](150) NULL,
 CONSTRAINT [PK_Incomes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24.12.2021 05:08:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BasketDetails] ON 

INSERT [dbo].[BasketDetails] ([Id], [BasketId], [ProductId], [Quantity], [Price], [SaleType]) VALUES (1, 1, 1, 1, CAST(7500.00 AS Decimal(8, 2)), 1)
INSERT [dbo].[BasketDetails] ([Id], [BasketId], [ProductId], [Quantity], [Price], [SaleType]) VALUES (2, 2, 1, 1, CAST(7000.00 AS Decimal(8, 2)), 0)
INSERT [dbo].[BasketDetails] ([Id], [BasketId], [ProductId], [Quantity], [Price], [SaleType]) VALUES (3, 4, 2, 2, CAST(10000.00 AS Decimal(8, 2)), 0)
INSERT [dbo].[BasketDetails] ([Id], [BasketId], [ProductId], [Quantity], [Price], [SaleType]) VALUES (4, 5, 1, 1, CAST(10000.00 AS Decimal(8, 2)), 0)
INSERT [dbo].[BasketDetails] ([Id], [BasketId], [ProductId], [Quantity], [Price], [SaleType]) VALUES (5, 6, 5, 1, CAST(3000.00 AS Decimal(8, 2)), NULL)
INSERT [dbo].[BasketDetails] ([Id], [BasketId], [ProductId], [Quantity], [Price], [SaleType]) VALUES (6, 1, 2, 2, CAST(8000.00 AS Decimal(8, 2)), 0)
INSERT [dbo].[BasketDetails] ([Id], [BasketId], [ProductId], [Quantity], [Price], [SaleType]) VALUES (8, 5, 2, 1, CAST(4000.00 AS Decimal(8, 2)), 1)
INSERT [dbo].[BasketDetails] ([Id], [BasketId], [ProductId], [Quantity], [Price], [SaleType]) VALUES (10, 4, 5, 2, CAST(5000.00 AS Decimal(8, 2)), NULL)
SET IDENTITY_INSERT [dbo].[BasketDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Baskets] ON 

INSERT [dbo].[Baskets] ([Id], [CustomerId], [DateOfSale], [Photo], [IsDone]) VALUES (1, 1, CAST(N'2019-08-18T20:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Baskets] ([Id], [CustomerId], [DateOfSale], [Photo], [IsDone]) VALUES (2, 2, CAST(N'2019-10-25T19:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Baskets] ([Id], [CustomerId], [DateOfSale], [Photo], [IsDone]) VALUES (4, 5, CAST(N'2019-11-20T13:15:08.000' AS DateTime), NULL, 1)
INSERT [dbo].[Baskets] ([Id], [CustomerId], [DateOfSale], [Photo], [IsDone]) VALUES (5, 6, CAST(N'2021-07-15T17:05:01.000' AS DateTime), NULL, 0)
INSERT [dbo].[Baskets] ([Id], [CustomerId], [DateOfSale], [Photo], [IsDone]) VALUES (6, 7, CAST(N'2021-08-16T15:54:05.000' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[Baskets] OFF
GO
SET IDENTITY_INSERT [dbo].[BasketsEvents] ON 

INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (2, 1, 1)
INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (3, 1, 3)
INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (4, 1, 4)
INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (5, 2, 5)
INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (6, 2, 6)
INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (7, 2, 8)
INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (8, 5, 9)
INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (9, 5, 10)
INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (10, 6, 11)
INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (11, 6, 12)
INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (12, 6, 13)
INSERT [dbo].[BasketsEvents] ([Id], [BasketId], [EventId]) VALUES (13, 6, 14)
SET IDENTITY_INSERT [dbo].[BasketsEvents] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [PhoneCode], [PhoneNumber], [IsActive], [IsDeleted]) VALUES (1, N'zeynep', N'kartal', N'+90', N'5339995522', 0, 0)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [PhoneCode], [PhoneNumber], [IsActive], [IsDeleted]) VALUES (2, N'sibel', N'birdal', N'+90', N'5421113322', 0, 0)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [PhoneCode], [PhoneNumber], [IsActive], [IsDeleted]) VALUES (5, N'ayşe', N'johnson', N'+90', N'5553334488', 0, 0)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [PhoneCode], [PhoneNumber], [IsActive], [IsDeleted]) VALUES (6, N'beyza', N'yıldız', N'+90', N'5536667722', 1, 0)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [PhoneCode], [PhoneNumber], [IsActive], [IsDeleted]) VALUES (7, N'sıla', N'ay', N'+90', N'5368889944', 1, 0)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [PhoneCode], [PhoneNumber], [IsActive], [IsDeleted]) VALUES (8, N'meltem', N'sakin', N'+49', N'88887773300', 1, 0)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [PhoneCode], [PhoneNumber], [IsActive], [IsDeleted]) VALUES (9, N'selin', N'gökçe', N'+7', N'3332221100', 1, 0)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [PhoneCode], [PhoneNumber], [IsActive], [IsDeleted]) VALUES (11, N'string', N'string', N'+48', N'123123', 1, 0)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [PhoneCode], [PhoneNumber], [IsActive], [IsDeleted]) VALUES (17, N'st', N'string', N'+90', N'string', 1, 0)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [PhoneCode], [PhoneNumber], [IsActive], [IsDeleted]) VALUES (19, N'string', N'string', N'+90', N'8756', 1, 0)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (1, 1, 1, CAST(N'2019-08-25T20:00:00.000' AS DateTime), N'1', 1)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (3, 1, 1, CAST(N'2019-08-30T20:00:00.000' AS DateTime), N'2', 1)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (4, 1, 2, CAST(N'2019-09-15T20:00:00.000' AS DateTime), N' ', 1)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (5, 2, 1, CAST(N'2019-09-25T10:00:00.000' AS DateTime), N'1', 1)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (6, 2, 1, CAST(N'2019-09-30T20:00:00.000' AS DateTime), N'2', 1)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (8, 2, 2, CAST(N'2019-10-25T20:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (9, 6, 1, CAST(N'2021-07-25T20:00:00.000' AS DateTime), N'1', 1)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (10, 6, 2, CAST(N'2021-12-25T20:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (11, 7, 1, CAST(N'2021-12-18T20:00:00.000' AS DateTime), N'1', 0)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (12, 7, 1, CAST(N'2021-12-20T20:00:00.000' AS DateTime), N'2', 0)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (13, 7, 1, CAST(N'2021-12-23T20:00:00.000' AS DateTime), N'3', 0)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (14, 7, 2, CAST(N'2022-01-18T20:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (15, 8, 3, CAST(N'2021-12-18T20:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Events] ([Id], [CustomerId], [TypeId], [Date], [No], [IsDone]) VALUES (16, 9, 3, CAST(N'2021-12-05T20:00:00.000' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[EventTypes] ON 

INSERT [dbo].[EventTypes] ([Id], [Name]) VALUES (4, N'ödeme')
INSERT [dbo].[EventTypes] ([Id], [Name]) VALUES (1, N'prova')
INSERT [dbo].[EventTypes] ([Id], [Name]) VALUES (3, N'randevu')
INSERT [dbo].[EventTypes] ([Id], [Name]) VALUES (2, N'teslim')
SET IDENTITY_INSERT [dbo].[EventTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Expenses] ON 

INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (1, 1, CAST(1000.00 AS Decimal(8, 2)), CAST(N'2021-01-18T20:00:00.000' AS DateTime), N'Asel')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (2, 2, CAST(500.00 AS Decimal(8, 2)), CAST(N'2021-11-18T20:00:00.000' AS DateTime), N'su')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (3, 3, CAST(3800.00 AS Decimal(8, 2)), CAST(N'2021-10-18T20:00:00.000' AS DateTime), N'09/2021')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (4, 4, CAST(38000.00 AS Decimal(8, 2)), CAST(N'2021-09-18T20:00:00.000' AS DateTime), N'abcnin maaşı')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (5, 1, CAST(2000.00 AS Decimal(8, 2)), CAST(N'2021-07-20T20:00:00.000' AS DateTime), N'hint ipek')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (6, 2, CAST(10.00 AS Decimal(8, 2)), CAST(N'2021-12-10T22:27:09.530' AS DateTime), N'string')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (10, 2, CAST(200.00 AS Decimal(8, 2)), CAST(N'2021-12-12T20:00:00.000' AS DateTime), N'elektrik kasım')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (11, 3, CAST(3000.00 AS Decimal(8, 2)), CAST(N'2021-12-11T20:00:00.000' AS DateTime), N'kira kasım 2021')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (12, 1, CAST(2500.00 AS Decimal(8, 2)), CAST(N'2021-11-14T20:00:00.000' AS DateTime), N'astar-abc firması')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (13, 4, CAST(6000.00 AS Decimal(8, 2)), CAST(N'2021-12-17T13:00:00.000' AS DateTime), N'ert kasım maaş')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (14, 1, CAST(2000.00 AS Decimal(8, 2)), CAST(N'2021-11-01T20:00:00.000' AS DateTime), N'30m kaplama dantel')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (15, 1, CAST(2000.00 AS Decimal(8, 2)), CAST(N'2021-11-18T20:00:00.000' AS DateTime), N'6m beyaz şifon der şirketi')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (16, 4, CAST(2000.00 AS Decimal(8, 2)), CAST(N'2021-12-17T20:00:00.000' AS DateTime), N'qwe aralık maas')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (17, 4, CAST(3000.00 AS Decimal(8, 2)), CAST(N'2021-10-13T20:00:00.000' AS DateTime), N'etm ekim avans')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (18, 3, CAST(3000.00 AS Decimal(8, 2)), CAST(N'2021-10-17T20:00:00.000' AS DateTime), N'ekim 2021')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (20, 3, CAST(3000.00 AS Decimal(8, 2)), CAST(N'2021-09-17T20:00:00.000' AS DateTime), N'eylül 2021')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (21, 2, CAST(190.00 AS Decimal(8, 2)), CAST(N'2021-09-17T20:00:00.000' AS DateTime), N'eylül 2021 su')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (23, 1, CAST(0.00 AS Decimal(8, 2)), CAST(N'2021-12-24T01:08:34.093' AS DateTime), N'string')
INSERT [dbo].[Expenses] ([Id], [TypeId], [Amount], [Date], [Description]) VALUES (24, 1, CAST(452.00 AS Decimal(8, 2)), CAST(N'2021-12-24T01:08:34.093' AS DateTime), N'string')
SET IDENTITY_INSERT [dbo].[Expenses] OFF
GO
SET IDENTITY_INSERT [dbo].[ExpenseTypes] ON 

INSERT [dbo].[ExpenseTypes] ([Id], [Name]) VALUES (2, N'fatura')
INSERT [dbo].[ExpenseTypes] ([Id], [Name]) VALUES (3, N'kira')
INSERT [dbo].[ExpenseTypes] ([Id], [Name]) VALUES (1, N'kumaş')
INSERT [dbo].[ExpenseTypes] ([Id], [Name]) VALUES (4, N'personel')
SET IDENTITY_INSERT [dbo].[ExpenseTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Incomes] ON 

INSERT [dbo].[Incomes] ([Id], [BasketId], [Amount], [Date], [Description]) VALUES (1, 1, CAST(5500.00 AS Decimal(8, 2)), CAST(N'2019-08-25T20:00:00.000' AS DateTime), N'kapora')
INSERT [dbo].[Incomes] ([Id], [BasketId], [Amount], [Date], [Description]) VALUES (2, 1, CAST(10000.00 AS Decimal(8, 2)), CAST(N'2019-09-15T20:00:00.000' AS DateTime), N'kalan')
INSERT [dbo].[Incomes] ([Id], [BasketId], [Amount], [Date], [Description]) VALUES (3, 2, CAST(3000.00 AS Decimal(8, 2)), CAST(N'2019-10-25T19:00:00.000' AS DateTime), N'kapora')
INSERT [dbo].[Incomes] ([Id], [BasketId], [Amount], [Date], [Description]) VALUES (4, 2, CAST(4000.00 AS Decimal(8, 2)), CAST(N'2019-10-25T20:00:00.000' AS DateTime), N'kalan')
INSERT [dbo].[Incomes] ([Id], [BasketId], [Amount], [Date], [Description]) VALUES (5, 4, CAST(15000.00 AS Decimal(8, 2)), CAST(N'2019-11-20T13:15:08.000' AS DateTime), N'tam ödeme')
INSERT [dbo].[Incomes] ([Id], [BasketId], [Amount], [Date], [Description]) VALUES (6, 5, CAST(9000.00 AS Decimal(8, 2)), CAST(N'2021-07-15T17:05:01.000' AS DateTime), N'kapora')
INSERT [dbo].[Incomes] ([Id], [BasketId], [Amount], [Date], [Description]) VALUES (7, 6, CAST(3000.00 AS Decimal(8, 2)), CAST(N'2021-08-16T15:54:05.000' AS DateTime), N'kapora')
SET IDENTITY_INSERT [dbo].[Incomes] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'admin')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name]) VALUES (2, N'abiye')
INSERT [dbo].[Products] ([Id], [Name]) VALUES (1, N'gelinlik')
INSERT [dbo].[Products] ([Id], [Name]) VALUES (5, N'kaftan')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 

INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [IsActive], [PasswordSalt], [PasswordHash]) VALUES (1, N'hakan', N'helen', N'he@gmail.com', 1, 0x1E00311F537BEB3E33FE4F65DE67B391B4672253E1342DDDA72D839A14D9852AB023421AB139AF36E03253E61086A17BF43B397922B8CCE6290624B580B770EAB5134F41D63E5CE26B20C922DD3FEC7F387960448B9E77FDFF60CC17EB79E2AA416C060E6CBDEAFB2929589C61246A15C0547AFEC074431F6479409D7A37E6DE, 0x24FD6AF715629E5743C9DD90C36C0A20C27EE93DF26143DBE97D151D1AE79C02751BBEB6EA0DCA0F2EE0A1DC79690BD1935AC8857551F6AA19C255F7D741C85B)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [UK_BasketDetails_BasketId_ProductId]    Script Date: 24.12.2021 05:08:47 ******/
ALTER TABLE [dbo].[BasketDetails] ADD  CONSTRAINT [UK_BasketDetails_BasketId_ProductId] UNIQUE NONCLUSTERED 
(
	[BasketId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Index [IX_BasketDetails_SaleType]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_BasketDetails_SaleType] ON [dbo].[BasketDetails]
(
	[SaleType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 10) ON [PRIMARY]
GO
/****** Object:  Index [IX_Baskets_DateOfSale]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_Baskets_DateOfSale] ON [dbo].[Baskets]
(
	[DateOfSale] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Index [IX_Baskets_IsDone]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_Baskets_IsDone] ON [dbo].[Baskets]
(
	[IsDone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Index [UK_BasketsEvents_EventId]    Script Date: 24.12.2021 05:08:47 ******/
ALTER TABLE [dbo].[BasketsEvents] ADD  CONSTRAINT [UK_BasketsEvents_EventId] UNIQUE NONCLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 20) ON [PRIMARY]
GO
/****** Object:  Index [IX_BasketsEvents_BasketId]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_BasketsEvents_BasketId] ON [dbo].[BasketsEvents]
(
	[BasketId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 10) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Customers_Phone]    Script Date: 24.12.2021 05:08:47 ******/
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [UK_Customers_Phone] UNIQUE NONCLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Index [IX_Events_CustomerId]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_Events_CustomerId] ON [dbo].[Events]
(
	[CustomerId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 10) ON [PRIMARY]
GO
/****** Object:  Index [IX_Events_Date]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_Events_Date] ON [dbo].[Events]
(
	[Date] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 10) ON [PRIMARY]
GO
/****** Object:  Index [IX_Events_IsDone]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_Events_IsDone] ON [dbo].[Events]
(
	[IsDone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 10) ON [PRIMARY]
GO
/****** Object:  Index [IX_Events_TypeId]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_Events_TypeId] ON [dbo].[Events]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 10) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_EventTypes_Name]    Script Date: 24.12.2021 05:08:47 ******/
ALTER TABLE [dbo].[EventTypes] ADD  CONSTRAINT [UK_EventTypes_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Index [IX_Expenses_Date]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_Expenses_Date] ON [dbo].[Expenses]
(
	[Date] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 10) ON [PRIMARY]
GO
/****** Object:  Index [IX_Expenses_TypeId]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_Expenses_TypeId] ON [dbo].[Expenses]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 10) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_ExpensesTypes_Name]    Script Date: 24.12.2021 05:08:47 ******/
ALTER TABLE [dbo].[ExpenseTypes] ADD  CONSTRAINT [UK_ExpensesTypes_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Index [IX_Incomes_BasketId]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_Incomes_BasketId] ON [dbo].[Incomes]
(
	[BasketId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 10) ON [PRIMARY]
GO
/****** Object:  Index [IX_Incomes_Date]    Script Date: 24.12.2021 05:08:47 ******/
CREATE NONCLUSTERED INDEX [IX_Incomes_Date] ON [dbo].[Incomes]
(
	[Date] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 10) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Products_Name]    Script Date: 24.12.2021 05:08:47 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [UK_Products_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[BasketDetails]  WITH CHECK ADD  CONSTRAINT [FK_BasketDetails_Baskets] FOREIGN KEY([BasketId])
REFERENCES [dbo].[Baskets] ([Id])
GO
ALTER TABLE [dbo].[BasketDetails] CHECK CONSTRAINT [FK_BasketDetails_Baskets]
GO
ALTER TABLE [dbo].[BasketDetails]  WITH CHECK ADD  CONSTRAINT [FK_BasketDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[BasketDetails] CHECK CONSTRAINT [FK_BasketDetails_Products]
GO
ALTER TABLE [dbo].[Baskets]  WITH CHECK ADD  CONSTRAINT [FK_Baskets_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Baskets] CHECK CONSTRAINT [FK_Baskets_Customers]
GO
ALTER TABLE [dbo].[BasketsEvents]  WITH CHECK ADD  CONSTRAINT [FK_BasketsEvents_Baskets] FOREIGN KEY([BasketId])
REFERENCES [dbo].[Baskets] ([Id])
GO
ALTER TABLE [dbo].[BasketsEvents] CHECK CONSTRAINT [FK_BasketsEvents_Baskets]
GO
ALTER TABLE [dbo].[BasketsEvents]  WITH CHECK ADD  CONSTRAINT [FK_BasketsEvents_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([Id])
GO
ALTER TABLE [dbo].[BasketsEvents] CHECK CONSTRAINT [FK_BasketsEvents_Events]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Customers]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[EventTypes] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventTypes]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_ExpensesTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[ExpenseTypes] ([Id])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_ExpensesTypes]
GO
ALTER TABLE [dbo].[Incomes]  WITH CHECK ADD  CONSTRAINT [FK_Incomes_Baskets] FOREIGN KEY([BasketId])
REFERENCES [dbo].[Baskets] ([Id])
GO
ALTER TABLE [dbo].[Incomes] CHECK CONSTRAINT [FK_Incomes_Baskets]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_OperationClaims] FOREIGN KEY([OperationClaimId])
REFERENCES [dbo].[OperationClaims] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_OperationClaims]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_Users]
GO
USE [master]
GO
ALTER DATABASE [HelenSposaDB] SET  READ_WRITE 
GO
