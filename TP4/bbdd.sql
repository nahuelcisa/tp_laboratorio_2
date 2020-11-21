USE [master]
GO
/****** Object:  Database [Cisa.Nahuel.2A.TP4]    Script Date: 20/11/2020 21:52:37 ******/
CREATE DATABASE [Cisa.Nahuel.2A.TP4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cisa.Nahuel.2A.TP4', FILENAME = N'C:\Cisa.Nahuel.2A.TP4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cisa.Nahuel.2A.TP4_log', FILENAME = N'C:\Cisa.Nahuel.2A.TP4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cisa.Nahuel.2A.TP4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET  MULTI_USER 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET QUERY_STORE = OFF
GO
USE [Cisa.Nahuel.2A.TP4]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 20/11/2020 21:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto] [varchar](50) NULL,
	[marca] [varchar](50) NULL,
	[modelo] [varchar](50) NULL,
	[precio] [float] NULL,
	[cantidad_de_stock] [int] NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[productos] ON 

INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (11, N'Gabinete', N'Corsair', N'A70', 2500, 54)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (12, N'Procesador', N'Sentey', N'400', 34.5, 32)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (13, N'PlacaDeVideo', N'Nvidia', N'2060', 95000, 45)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (14, N'Procesador', N'Intel', N'I5 6400', 32000, 17)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (15, N'Gabinete', N'Cougar', N'ENG', 10500, 11)
INSERT [dbo].[productos] ([id], [producto], [marca], [modelo], [precio], [cantidad_de_stock]) VALUES (16, N'PlacaDeVideo', N'AMD', N'RX580', 19990.990234375, 51)
SET IDENTITY_INSERT [dbo].[productos] OFF
GO
USE [master]
GO
ALTER DATABASE [Cisa.Nahuel.2A.TP4] SET  READ_WRITE 
GO
