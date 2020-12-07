
USE [master]
GO

ALTER DATABASE [HAVIdatabase] SET COMPATIBILITY_LEVEL = 150
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HAVIdatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [HAVIdatabase] SET ANSI_NULL_DEFAULT OFF
GO

ALTER DATABASE [HAVIdatabase] SET ANSI_NULLS OFF
GO

ALTER DATABASE [HAVIdatabase] SET ANSI_PADDING OFF
GO

ALTER DATABASE [HAVIdatabase] SET ANSI_WARNINGS OFF
GO

ALTER DATABASE [HAVIdatabase] SET ARITHABORT OFF
GO

ALTER DATABASE [HAVIdatabase] SET AUTO_CLOSE ON
GO

ALTER DATABASE [HAVIdatabase] SET AUTO_SHRINK OFF
GO

ALTER DATABASE [HAVIdatabase] SET AUTO_UPDATE_STATISTICS ON
GO

ALTER DATABASE [HAVIdatabase] SET CURSOR_CLOSE_ON_COMMIT OFF
GO

ALTER DATABASE [HAVIdatabase] SET CURSOR_DEFAULT  GLOBAL
GO

ALTER DATABASE [HAVIdatabase] SET CONCAT_NULL_YIELDS_NULL OFF
GO

ALTER DATABASE [HAVIdatabase] SET NUMERIC_ROUNDABORT OFF
GO

ALTER DATABASE [HAVIdatabase] SET QUOTED_IDENTIFIER OFF
GO

ALTER DATABASE [HAVIdatabase] SET RECURSIVE_TRIGGERS OFF
GO

ALTER DATABASE [HAVIdatabase] SET  ENABLE_BROKER
GO

ALTER DATABASE [HAVIdatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO

ALTER DATABASE [HAVIdatabase] SET DATE_CORRELATION_OPTIMIZATION OFF
GO

ALTER DATABASE [HAVIdatabase] SET TRUSTWORTHY OFF
GO

ALTER DATABASE [HAVIdatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO

ALTER DATABASE [HAVIdatabase] SET PARAMETERIZATION SIMPLE
GO

ALTER DATABASE [HAVIdatabase] SET READ_COMMITTED_SNAPSHOT ON
GO

ALTER DATABASE [HAVIdatabase] SET HONOR_BROKER_PRIORITY OFF
GO

ALTER DATABASE [HAVIdatabase] SET RECOVERY SIMPLE
GO

ALTER DATABASE [HAVIdatabase] SET  MULTI_USER
GO

ALTER DATABASE [HAVIdatabase] SET PAGE_VERIFY CHECKSUM
GO

ALTER DATABASE [HAVIdatabase] SET DB_CHAINING OFF
GO

ALTER DATABASE [HAVIdatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO

ALTER DATABASE [HAVIdatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS
GO

ALTER DATABASE [HAVIdatabase] SET DELAYED_DURABILITY = DISABLED
GO

ALTER DATABASE [HAVIdatabase] SET QUERY_STORE = OFF
GO

USE [HAVIdatabase]
GO

/****** Object:  Table [dbo].[Article]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[ArticleInformation]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Bundle]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[CompanyCode]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Country]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[CreationCode]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[DepartmentId]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[FreightResponsibility]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[ILOSCategory]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[ILOSOrderpickgroup]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[ILOSSortGroup]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[InformCostType]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[InternalArticleInformation]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Location]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[OtherCostsForArticle]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[PackagingGroup]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[PrimaryDCILOSCode]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Profile]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Purchaser]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QIP]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QIPNumber]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[SalesUnit]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[SAPPlant]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[SetCurrency]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Supplier]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[SupplierDeliveryUnit]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[VailedForCustomer]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[VatTaxCode]    Script Date: 07-12-2020 10:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [master]
GO

ALTER DATABASE [HAVIdatabase] SET  READ_WRITE
GO

/****** Object:  Database [HAVIdatabase]    Script Date: 07-12-2020 10:15:28 ******/
CREATE DATABASE [HAVIdatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HAVIdatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HAVIdatabase.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HAVIdatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HAVIdatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT

GO

--Syntax Error: Expected DEFAULT_FULLTEXT_LANGUAGE but encountered CATALOG_COLLATION instead.
--/****** Object:  Database [HAVIdatabase]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE DATABASE [HAVIdatabase]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'HAVIdatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HAVIdatabase.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'HAVIdatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HAVIdatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
-- WITH CATALOG_COLLATION = DATABASE_DEFAULT

GO

ALTER DATABASE [HAVIdatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  

GO

--Syntax Error: Incorrect syntax near ACCELERATED_DATABASE_RECOVERY.
--ALTER DATABASE [HAVIdatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  

GO

CREATE TABLE [dbo].[Article](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaserID] [int] NOT NULL,
	[SupplierID] [int] NOT NULL,
	[CountryID] [int] NOT NULL,
	[ArticleInformationID] [int] NOT NULL,
	[InternalArticleInformationID] [int] NOT NULL,
	[VailedForCustomer] [text] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ArticleInformationCompleted] [int] NOT NULL,
	[InternalArticalInformationCompleted] [int] NOT NULL,
	[ArticleState] [int] NOT NULL,
	[ErrorReported] [int] NOT NULL,
	[ErrorField] [text] NULL,
	[ErrorMessage] [text] NULL,
	[ErrorOwner] [text] NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[Article](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[PurchaserID] [int] NOT NULL,
--	[SupplierID] [int] NOT NULL,
--	[CountryID] [int] NOT NULL,
--	[ArticleInformationID] [int] NOT NULL,
--	[InternalArticleInformationID] [int] NOT NULL,
--	[VailedForCustomer] [text] NOT NULL,
--	[DateCreated] [datetime] NOT NULL,
--	[ArticleInformationCompleted] [int] NOT NULL,
--	[InternalArticalInformationCompleted] [int] NOT NULL,
--	[ArticleState] [int] NOT NULL,
--	[ErrorReported] [int] NOT NULL,
--	[ErrorField] [text] NULL,
--	[ErrorMessage] [text] NULL,
--	[ErrorOwner] [text] NULL,
-- CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[ArticleInformation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [text] NOT NULL,
	[CompanyLocation] [text] NOT NULL,
	[Email] [text] NOT NULL,
	[PalletExchange] [int] NOT NULL,
	[FreightResponsibility] [text] NOT NULL,
	[SpecialInformation] [text] NULL,
	[TransportBooking] [int] NOT NULL,
	[TransitTime] [int] NOT NULL,
	[DangerousGoods] [int] NOT NULL,
	[Class] [text] NULL,
	[ClassificationCode] [text] NULL,
	[ArticleName] [text] NULL,
	[Salesunit] [text] NULL,
	[ArticlesPerSalesunit] [int] NOT NULL,
	[SupplierArticleName] [text] NULL,
	[GTINNumber] [nvarchar](max) NULL,
	[Shelflife] [int] NOT NULL,
	[MinimumShelflife] [int] NOT NULL,
	[OrganicArticle] [int] NOT NULL,
	[LengthPrSalesunit] [float] NOT NULL,
	[WidthPrSalesunit] [float] NOT NULL,
	[HeightPrSalesunit] [float] NOT NULL,
	[NetWeightPrSalesunit] [float] NOT NULL,
	[GrossWeightPrSalesunit] [float] NOT NULL,
	[CartonsPerPallet] [int] NOT NULL,
	[CartonsPerLayer] [int] NOT NULL,
	[CountryOfOrigin] [text] NULL,
	[ImportedFrom] [text] NULL,
	[TollTarifNumber] [text] NULL,
	[MinimumOrderQuantity] [int] NOT NULL,
	[TemperatureTransportationMin] [float] NOT NULL,
	[TemperatureTransportationMax] [float] NOT NULL,
	[TemperatureStorageMin] [float] NOT NULL,
	[TemperatureStorageMax] [float] NOT NULL,
	[LeadTime] [int] NOT NULL,
	[SetCurrency] [text] NULL,
	[PurchasePrice] [float] NOT NULL,
	[OtherCosts] [int] NOT NULL,
 CONSTRAINT [PK_ArticleInformation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[ArticleInformation](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[CompanyName] [text] NOT NULL,
--	[CompanyLocation] [text] NOT NULL,
--	[Email] [text] NOT NULL,
--	[PalletExchange] [int] NOT NULL,
--	[FreightResponsibility] [text] NOT NULL,
--	[SpecialInformation] [text] NULL,
--	[TransportBooking] [int] NOT NULL,
--	[TransitTime] [int] NOT NULL,
--	[DangerousGoods] [int] NOT NULL,
--	[Class] [text] NULL,
--	[ClassificationCode] [text] NULL,
--	[ArticleName] [text] NULL,
--	[Salesunit] [text] NULL,
--	[ArticlesPerSalesunit] [int] NOT NULL,
--	[SupplierArticleName] [text] NULL,
--	[GTINNumber] [nvarchar](max) NULL,
--	[Shelflife] [int] NOT NULL,
--	[MinimumShelflife] [int] NOT NULL,
--	[OrganicArticle] [int] NOT NULL,
--	[LengthPrSalesunit] [float] NOT NULL,
--	[WidthPrSalesunit] [float] NOT NULL,
--	[HeightPrSalesunit] [float] NOT NULL,
--	[NetWeightPrSalesunit] [float] NOT NULL,
--	[GrossWeightPrSalesunit] [float] NOT NULL,
--	[CartonsPerPallet] [int] NOT NULL,
--	[CartonsPerLayer] [int] NOT NULL,
--	[CountryOfOrigin] [text] NULL,
--	[ImportedFrom] [text] NULL,
--	[TollTarifNumber] [text] NULL,
--	[MinimumOrderQuantity] [int] NOT NULL,
--	[TemperatureTransportationMin] [float] NOT NULL,
--	[TemperatureTransportationMax] [float] NOT NULL,
--	[TemperatureStorageMin] [float] NOT NULL,
--	[TemperatureStorageMax] [float] NOT NULL,
--	[LeadTime] [int] NOT NULL,
--	[SetCurrency] [text] NULL,
--	[PurchasePrice] [float] NOT NULL,
--	[OtherCosts] [int] NOT NULL,
-- CONSTRAINT [PK_ArticleInformation] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[Bundle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InternalArticleInformationID] [int] NOT NULL,
	[ArticleBundle] [text] NULL,
	[ArticleBundleQuantity] [int] NOT NULL,
 CONSTRAINT [PK_Bundle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[Bundle](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[InternalArticleInformationID] [int] NOT NULL,
--	[ArticleBundle] [text] NULL,
--	[ArticleBundleQuantity] [int] NOT NULL,
-- CONSTRAINT [PK_Bundle] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[CompanyCode](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [text] NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_CompanyCode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[CompanyCode](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Code] [text] NULL,
--	[CountryID] [int] NOT NULL,
-- CONSTRAINT [PK_CompanyCode] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[Country](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProfileID] [int] NOT NULL,
	[CountryName] [text] NOT NULL,
	[CountryCode] [text] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[Country](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[ProfileID] [int] NOT NULL,
--	[CountryName] [text] NOT NULL,
--	[CountryCode] [text] NOT NULL,
-- CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[CreationCode](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [text] NOT NULL,
	[Active] [int] NOT NULL,
 CONSTRAINT [PK_CreationCode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[CreationCode](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Code] [text] NOT NULL,
--	[Active] [int] NOT NULL,
-- CONSTRAINT [PK_CreationCode] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[DepartmentId](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Department] [text] NULL,
 CONSTRAINT [PK_DepartmentId] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[DepartmentId](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Department] [text] NULL,
-- CONSTRAINT [PK_DepartmentId] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[FreightResponsibility](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Responsibility] [text] NULL,
 CONSTRAINT [PK_FreightResponsibility] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[FreightResponsibility](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Responsibility] [text] NULL,
-- CONSTRAINT [PK_FreightResponsibility] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[ILOSCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [text] NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_ILOSCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[ILOSCategory](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Category] [text] NULL,
--	[CountryID] [int] NOT NULL,
-- CONSTRAINT [PK_ILOSCategory] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[ILOSOrderpickgroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Orderpickgroup] [text] NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_ILOSOrderpickgroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[ILOSOrderpickgroup](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Orderpickgroup] [text] NULL,
--	[CountryID] [int] NOT NULL,
-- CONSTRAINT [PK_ILOSOrderpickgroup] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[ILOSSortGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SortGroup] [text] NULL,
 CONSTRAINT [PK_ILOSSortGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[ILOSSortGroup](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[SortGroup] [text] NULL,
-- CONSTRAINT [PK_ILOSSortGroup] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[InformCostType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CostType] [text] NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_InformCostType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[InformCostType](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[CostType] [text] NULL,
--	[CountryID] [int] NOT NULL,
-- CONSTRAINT [PK_InformCostType] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[InternalArticleInformation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID_ILOS] [int] NOT NULL,
	[CompanyCode] [int] NOT NULL,
	[SupplierDeliveryUnit] [text] NULL,
	[RemainShelfStore] [int] NOT NULL,
	[ILOSOrderPickGroup] [text] NULL,
	[ILOSSortGroup] [text] NULL,
	[NewILOSArticleNumber] [text] NULL,
	[ReferenceILOSNumber] [text] NULL,
	[ReferenceSAPMaterial] [int] NOT NULL,
	[ILOSCategory] [text] NULL,
	[VAT_TAXCode] [text] NULL,
	[DepartmentID] [text] NULL,
	[InnerPackingILOS] [text] NULL,
	[CurrencyRate] [float] NOT NULL,
	[PriceInCountryCurrency] [float] NOT NULL,
	[TextPurchaseNumber] [int] NOT NULL,
	[RegisterShelfLife] [int] NOT NULL,
	[ClassificationCode] [text] NULL,
	[PackagingGroup] [text] NULL,
	[Insert_EAN_SAP] [int] NOT NULL,
	[Insert_GRIN_SAP] [int] NOT NULL,
	[Insert_BOS_SAP] [int] NOT NULL,
	[EANNumber] [nvarchar](max) NULL,
	[GRINNumber] [nvarchar](max) NULL,
	[BOSNumber] [nvarchar](max) NULL,
	[GTINNumber] [nvarchar](max) NULL,
	[LRINNumber] [nvarchar](max) NULL,
	[SPRNNumber] [nvarchar](max) NULL,
	[CARLANumber] [nvarchar](max) NULL,
	[PrimaryDC_ILOSCode] [int] NOT NULL,
	[TransitTimeForHAVI] [int] NOT NULL,
	[AmountInForeignCurrency] [float] NOT NULL,
 CONSTRAINT [PK_InternalArticleInformation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[InternalArticleInformation](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[SupplierID_ILOS] [int] NOT NULL,
--	[CompanyCode] [int] NOT NULL,
--	[SupplierDeliveryUnit] [text] NULL,
--	[RemainShelfStore] [int] NOT NULL,
--	[ILOSOrderPickGroup] [text] NULL,
--	[ILOSSortGroup] [text] NULL,
--	[NewILOSArticleNumber] [text] NULL,
--	[ReferenceILOSNumber] [text] NULL,
--	[ReferenceSAPMaterial] [int] NOT NULL,
--	[ILOSCategory] [text] NULL,
--	[VAT_TAXCode] [text] NULL,
--	[DepartmentID] [text] NULL,
--	[InnerPackingILOS] [text] NULL,
--	[CurrencyRate] [float] NOT NULL,
--	[PriceInCountryCurrency] [float] NOT NULL,
--	[TextPurchaseNumber] [int] NOT NULL,
--	[RegisterShelfLife] [int] NOT NULL,
--	[ClassificationCode] [text] NULL,
--	[PackagingGroup] [text] NULL,
--	[Insert_EAN_SAP] [int] NOT NULL,
--	[Insert_GRIN_SAP] [int] NOT NULL,
--	[Insert_BOS_SAP] [int] NOT NULL,
--	[EANNumber] [nvarchar](max) NULL,
--	[GRINNumber] [nvarchar](max) NULL,
--	[BOSNumber] [nvarchar](max) NULL,
--	[GTINNumber] [nvarchar](max) NULL,
--	[LRINNumber] [nvarchar](max) NULL,
--	[SPRNNumber] [nvarchar](max) NULL,
--	[CARLANumber] [nvarchar](max) NULL,
--	[PrimaryDC_ILOSCode] [int] NOT NULL,
--	[TransitTimeForHAVI] [int] NOT NULL,
--	[AmountInForeignCurrency] [float] NOT NULL,
-- CONSTRAINT [PK_InternalArticleInformation] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[Location](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Country] [text] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[Location](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Country] [text] NULL,
-- CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[OtherCostsForArticle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ArticleInformationID] [int] NOT NULL,
	[InformCostType] [text] NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_OtherCostsForArticle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[OtherCostsForArticle](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[ArticleInformationID] [int] NOT NULL,
--	[InformCostType] [text] NULL,
--	[Amount] [float] NOT NULL,
-- CONSTRAINT [PK_OtherCostsForArticle] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[PackagingGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Group] [text] NULL,
 CONSTRAINT [PK_PackagingGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[PackagingGroup](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Group] [text] NULL,
-- CONSTRAINT [PK_PackagingGroup] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[PrimaryDCILOSCode](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PrimaryCode] [text] NULL,
	[SAPPlant] [text] NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_PrimaryDCILOSCode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[PrimaryDCILOSCode](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[PrimaryCode] [text] NULL,
--	[SAPPlant] [text] NULL,
--	[CountryID] [int] NOT NULL,
-- CONSTRAINT [PK_PrimaryDCILOSCode] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[Profile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [text] NOT NULL,
	[Password] [text] NOT NULL,
	[Usertype] [int] NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[Profile](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Username] [text] NOT NULL,
--	[Password] [text] NOT NULL,
--	[Usertype] [int] NOT NULL,
-- CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[Purchaser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProfileID] [int] NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Purchaser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[Purchaser](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[ProfileID] [int] NOT NULL,
--	[CountryID] [int] NOT NULL,
-- CONSTRAINT [PK_Purchaser] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]

GO

CREATE TABLE [dbo].[QIP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InternalArticleInformationID] [int] NOT NULL,
	[QIPNameNumber] [text] NULL,
	[QIPDescription] [text] NULL,
	[QIPAnswerOptions] [text] NULL,
	[QIPSetAnswer] [text] NULL,
	[QIPOKValue] [text] NOT NULL,
	[QIPLowBoundary] [text] NOT NULL,
	[QIPHighBoundary] [text] NOT NULL,
	[QIPFrequencyType] [text] NOT NULL,
	[QIPFrequency] [text] NOT NULL,
 CONSTRAINT [PK_QIP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[QIP](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[InternalArticleInformationID] [int] NOT NULL,
--	[QIPNameNumber] [text] NULL,
--	[QIPDescription] [text] NULL,
--	[QIPAnswerOptions] [text] NULL,
--	[QIPSetAnswer] [text] NULL,
--	[QIPOKValue] [text] NOT NULL,
--	[QIPLowBoundary] [text] NOT NULL,
--	[QIPHighBoundary] [text] NOT NULL,
--	[QIPFrequencyType] [text] NOT NULL,
--	[QIPFrequency] [text] NOT NULL,
-- CONSTRAINT [PK_QIP] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[QIPNumber](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QIPNumberName] [text] NULL,
	[QIPDescription] [text] NULL,
	[AnswerOptions] [text] NULL,
	[SetAnswer] [int] NOT NULL,
	[OKValue] [int] NOT NULL,
	[LowBoundary] [int] NOT NULL,
	[HighBoundary] [int] NOT NULL,
	[FrequencyType] [int] NOT NULL,
	[Frequency] [int] NOT NULL,
 CONSTRAINT [PK_QIPNumber] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[QIPNumber](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[QIPNumberName] [text] NULL,
--	[QIPDescription] [text] NULL,
--	[AnswerOptions] [text] NULL,
--	[SetAnswer] [int] NOT NULL,
--	[OKValue] [int] NOT NULL,
--	[LowBoundary] [int] NOT NULL,
--	[HighBoundary] [int] NOT NULL,
--	[FrequencyType] [int] NOT NULL,
--	[Frequency] [int] NOT NULL,
-- CONSTRAINT [PK_QIPNumber] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[SalesUnit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Unit] [text] NULL,
 CONSTRAINT [PK_SalesUnit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[SalesUnit](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Unit] [text] NULL,
-- CONSTRAINT [PK_SalesUnit] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[SAPPlant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InternalArticleInformationID] [int] NOT NULL,
	[SAPPlantName] [text] NULL,
	[SAPPlantValue] [int] NOT NULL,
 CONSTRAINT [PK_SAPPlant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[SAPPlant](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[InternalArticleInformationID] [int] NOT NULL,
--	[SAPPlantName] [text] NULL,
--	[SAPPlantValue] [int] NOT NULL,
-- CONSTRAINT [PK_SAPPlant] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[SetCurrency](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyName] [text] NOT NULL,
 CONSTRAINT [PK_SetCurrency] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[SetCurrency](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[CurrencyName] [text] NOT NULL,
-- CONSTRAINT [PK_SetCurrency] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[Supplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProfileID] [int] NOT NULL,
	[CompanyName] [text] NOT NULL,
	[CompanyLocation] [text] NOT NULL,
	[PalletExchange] [int] NOT NULL,
	[FreightResponsibility] [text] NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[Supplier](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[ProfileID] [int] NOT NULL,
--	[CompanyName] [text] NOT NULL,
--	[CompanyLocation] [text] NOT NULL,
--	[PalletExchange] [int] NOT NULL,
--	[FreightResponsibility] [text] NOT NULL,
-- CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[SupplierDeliveryUnit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Unit] [text] NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_SupplierDeliveryUnit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[SupplierDeliveryUnit](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Unit] [text] NULL,
--	[CountryID] [int] NOT NULL,
-- CONSTRAINT [PK_SupplierDeliveryUnit] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[VailedForCustomer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer] [text] NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_VailedForCustomer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[VailedForCustomer](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Customer] [text] NULL,
--	[CountryID] [int] NOT NULL,
-- CONSTRAINT [PK_VailedForCustomer] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[VatTaxCode](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [text] NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_VatTaxCode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--CREATE TABLE [dbo].[VatTaxCode](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[Code] [text] NULL,
--	[CountryID] [int] NOT NULL,
-- CONSTRAINT [PK_VatTaxCode] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_Article_ArticleInformationID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Article_ArticleInformationID] ON [dbo].[Article]
(
	[ArticleInformationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_Article_ArticleInformationID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE UNIQUE NONCLUSTERED INDEX [IX_Article_ArticleInformationID] ON [dbo].[Article]
--(
--	[ArticleInformationID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_Article_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE NONCLUSTERED INDEX [IX_Article_CountryID] ON [dbo].[Article]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_Article_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE NONCLUSTERED INDEX [IX_Article_CountryID] ON [dbo].[Article]
--(
--	[CountryID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_Article_InternalArticleInformationID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Article_InternalArticleInformationID] ON [dbo].[Article]
(
	[InternalArticleInformationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_Article_InternalArticleInformationID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE UNIQUE NONCLUSTERED INDEX [IX_Article_InternalArticleInformationID] ON [dbo].[Article]
--(
--	[InternalArticleInformationID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_Article_PurchaserID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE NONCLUSTERED INDEX [IX_Article_PurchaserID] ON [dbo].[Article]
(
	[PurchaserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_Article_PurchaserID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE NONCLUSTERED INDEX [IX_Article_PurchaserID] ON [dbo].[Article]
--(
--	[PurchaserID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_Article_SupplierID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE NONCLUSTERED INDEX [IX_Article_SupplierID] ON [dbo].[Article]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_Article_SupplierID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE NONCLUSTERED INDEX [IX_Article_SupplierID] ON [dbo].[Article]
--(
--	[SupplierID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_Bundle_InternalArticleInformationID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE NONCLUSTERED INDEX [IX_Bundle_InternalArticleInformationID] ON [dbo].[Bundle]
(
	[InternalArticleInformationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_Bundle_InternalArticleInformationID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE NONCLUSTERED INDEX [IX_Bundle_InternalArticleInformationID] ON [dbo].[Bundle]
--(
--	[InternalArticleInformationID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_CompanyCode_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE NONCLUSTERED INDEX [IX_CompanyCode_CountryID] ON [dbo].[CompanyCode]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_CompanyCode_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE NONCLUSTERED INDEX [IX_CompanyCode_CountryID] ON [dbo].[CompanyCode]
--(
--	[CountryID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_Country_ProfileID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE NONCLUSTERED INDEX [IX_Country_ProfileID] ON [dbo].[Country]
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_Country_ProfileID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE NONCLUSTERED INDEX [IX_Country_ProfileID] ON [dbo].[Country]
--(
--	[ProfileID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [UQ__Country__25112020]    Script Date: 07-12-2020 10:15:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Country__25112020] ON [dbo].[Country]
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [UQ__Country__25112020]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE UNIQUE NONCLUSTERED INDEX [UQ__Country__25112020] ON [dbo].[Country]
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_ILOSCategory_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE NONCLUSTERED INDEX [IX_ILOSCategory_CountryID] ON [dbo].[ILOSCategory]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_ILOSCategory_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE NONCLUSTERED INDEX [IX_ILOSCategory_CountryID] ON [dbo].[ILOSCategory]
--(
--	[CountryID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_ILOSOrderpickgroup_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE NONCLUSTERED INDEX [IX_ILOSOrderpickgroup_CountryID] ON [dbo].[ILOSOrderpickgroup]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_ILOSOrderpickgroup_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE NONCLUSTERED INDEX [IX_ILOSOrderpickgroup_CountryID] ON [dbo].[ILOSOrderpickgroup]
--(
--	[CountryID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_InformCostType_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE NONCLUSTERED INDEX [IX_InformCostType_CountryID] ON [dbo].[InformCostType]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_InformCostType_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE NONCLUSTERED INDEX [IX_InformCostType_CountryID] ON [dbo].[InformCostType]
--(
--	[CountryID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_OtherCostsForArticle_ArticleInformationID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE NONCLUSTERED INDEX [IX_OtherCostsForArticle_ArticleInformationID] ON [dbo].[OtherCostsForArticle]
(
	[ArticleInformationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_OtherCostsForArticle_ArticleInformationID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE NONCLUSTERED INDEX [IX_OtherCostsForArticle_ArticleInformationID] ON [dbo].[OtherCostsForArticle]
--(
--	[ArticleInformationID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_PrimaryDCILOSCode_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
CREATE NONCLUSTERED INDEX [IX_PrimaryDCILOSCode_CountryID] ON [dbo].[PrimaryDCILOSCode]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_PrimaryDCILOSCode_CountryID]    Script Date: 07-12-2020 10:15:28 ******/
--CREATE NONCLUSTERED INDEX [IX_PrimaryDCILOSCode_CountryID] ON [dbo].[PrimaryDCILOSCode]
--(
--	[CountryID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_Purchaser_CountryID]    Script Date: 07-12-2020 10:15:29 ******/
CREATE NONCLUSTERED INDEX [IX_Purchaser_CountryID] ON [dbo].[Purchaser]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_Purchaser_CountryID]    Script Date: 07-12-2020 10:15:29 ******/
--CREATE NONCLUSTERED INDEX [IX_Purchaser_CountryID] ON [dbo].[Purchaser]
--(
--	[CountryID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_Purchaser_ProfileID]    Script Date: 07-12-2020 10:15:29 ******/
CREATE NONCLUSTERED INDEX [IX_Purchaser_ProfileID] ON [dbo].[Purchaser]
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_Purchaser_ProfileID]    Script Date: 07-12-2020 10:15:29 ******/
--CREATE NONCLUSTERED INDEX [IX_Purchaser_ProfileID] ON [dbo].[Purchaser]
--(
--	[ProfileID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_QIP_InternalArticleInformationID]    Script Date: 07-12-2020 10:15:29 ******/
CREATE NONCLUSTERED INDEX [IX_QIP_InternalArticleInformationID] ON [dbo].[QIP]
(
	[InternalArticleInformationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_QIP_InternalArticleInformationID]    Script Date: 07-12-2020 10:15:29 ******/
--CREATE NONCLUSTERED INDEX [IX_QIP_InternalArticleInformationID] ON [dbo].[QIP]
--(
--	[InternalArticleInformationID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_SAPPlant_InternalArticleInformationID]    Script Date: 07-12-2020 10:15:29 ******/
CREATE NONCLUSTERED INDEX [IX_SAPPlant_InternalArticleInformationID] ON [dbo].[SAPPlant]
(
	[InternalArticleInformationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_SAPPlant_InternalArticleInformationID]    Script Date: 07-12-2020 10:15:29 ******/
--CREATE NONCLUSTERED INDEX [IX_SAPPlant_InternalArticleInformationID] ON [dbo].[SAPPlant]
--(
--	[InternalArticleInformationID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_Supplier_ProfileID]    Script Date: 07-12-2020 10:15:29 ******/
CREATE NONCLUSTERED INDEX [IX_Supplier_ProfileID] ON [dbo].[Supplier]
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_Supplier_ProfileID]    Script Date: 07-12-2020 10:15:29 ******/
--CREATE NONCLUSTERED INDEX [IX_Supplier_ProfileID] ON [dbo].[Supplier]
--(
--	[ProfileID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_SupplierDeliveryUnit_CountryID]    Script Date: 07-12-2020 10:15:29 ******/
CREATE NONCLUSTERED INDEX [IX_SupplierDeliveryUnit_CountryID] ON [dbo].[SupplierDeliveryUnit]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_SupplierDeliveryUnit_CountryID]    Script Date: 07-12-2020 10:15:29 ******/
--CREATE NONCLUSTERED INDEX [IX_SupplierDeliveryUnit_CountryID] ON [dbo].[SupplierDeliveryUnit]
--(
--	[CountryID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_VailedForCustomer_CountryID]    Script Date: 07-12-2020 10:15:29 ******/
CREATE NONCLUSTERED INDEX [IX_VailedForCustomer_CountryID] ON [dbo].[VailedForCustomer]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_VailedForCustomer_CountryID]    Script Date: 07-12-2020 10:15:29 ******/
--CREATE NONCLUSTERED INDEX [IX_VailedForCustomer_CountryID] ON [dbo].[VailedForCustomer]
--(
--	[CountryID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

/****** Object:  Index [IX_VatTaxCode_CountryID]    Script Date: 07-12-2020 10:15:29 ******/
CREATE NONCLUSTERED INDEX [IX_VatTaxCode_CountryID] ON [dbo].[VatTaxCode]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

GO

--Syntax Error: Incorrect syntax near OPTIMIZE_FOR_SEQUENTIAL_KEY.
--/****** Object:  Index [IX_VatTaxCode_CountryID]    Script Date: 07-12-2020 10:15:29 ******/
--CREATE NONCLUSTERED INDEX [IX_VatTaxCode_CountryID] ON [dbo].[VatTaxCode]
--(
--	[CountryID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]



GO
