USE [master]
GO
/****** Object:  Database [SrNet]    Script Date: 4/26/2018 7:19:00 AM ******/
CREATE DATABASE [SrNet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SrNet', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SrNet.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SrNet_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SrNet_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SrNet] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SrNet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SrNet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SrNet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SrNet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SrNet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SrNet] SET ARITHABORT OFF 
GO
ALTER DATABASE [SrNet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SrNet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SrNet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SrNet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SrNet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SrNet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SrNet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SrNet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SrNet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SrNet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SrNet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SrNet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SrNet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SrNet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SrNet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SrNet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SrNet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SrNet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SrNet] SET  MULTI_USER 
GO
ALTER DATABASE [SrNet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SrNet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SrNet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SrNet] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SrNet] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SrNet]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/26/2018 7:19:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[gender] [nvarchar](max) NOT NULL,
	[dob] [datetime] NOT NULL,
	[mobile] [nvarchar](max) NOT NULL,
	[ResumeUrl] [nvarchar](max) NULL,
	[isPhysicallyChallenged] [bit] NULL,
	[country] [nvarchar](max) NULL,
	[city] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserCredentials]    Script Date: 4/26/2018 7:19:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserCredentials](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](250) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeId], [name], [email], [password], [gender], [dob], [mobile], [ResumeUrl], [isPhysicallyChallenged], [country], [city], [address]) VALUES (8, N'Ankit Sahay', N'ankitshay1990@gmail.com', N'123456', N'Male', CAST(N'1990-02-19 00:00:00.000' AS DateTime), N'9415151212', N'\images\426201813505AMFullStackDotNetDeveloperWithTechPerProject-1.jpg', 0, N'India', N'Lucknow', N'507 Vibhuti khand, Gomtinagar, Lucknow-226010')
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[UserCredentials] ON 

INSERT [dbo].[UserCredentials] ([UserId], [userName], [Password]) VALUES (1, N'Ankit', N'Ankit')
INSERT [dbo].[UserCredentials] ([UserId], [userName], [Password]) VALUES (2, N'Admin', N'Admin')
SET IDENTITY_INSERT [dbo].[UserCredentials] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_UserLogin]    Script Date: 4/26/2018 7:19:00 AM ******/
ALTER TABLE [dbo].[UserCredentials] ADD  CONSTRAINT [UK_UserLogin] UNIQUE NONCLUSTERED 
(
	[userName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [SrNet] SET  READ_WRITE 
GO
