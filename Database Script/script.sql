USE [master]
GO
/****** Object:  Database [MyCarDb]    Script Date: 26-03-2021 11:03:20 PM ******/
CREATE DATABASE [MyCarDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyCarDb', FILENAME = N'D:\MyCarDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyCarDb_log', FILENAME = N'D:\MyCarDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyCarDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyCarDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyCarDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyCarDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyCarDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyCarDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyCarDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyCarDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyCarDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyCarDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyCarDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyCarDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyCarDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyCarDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyCarDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyCarDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyCarDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyCarDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyCarDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyCarDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyCarDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyCarDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyCarDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyCarDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyCarDb] SET  MULTI_USER 
GO
ALTER DATABASE [MyCarDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyCarDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyCarDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyCarDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyCarDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MyCarDb]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [uniqueidentifier] NOT NULL,
	[LocalAddress] [nvarchar](100) NOT NULL,
	[PincodeId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_PurchaseAddresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Passowrd] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Contact] [varchar](15) NOT NULL,
	[Role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banks](
	[BankId] [uniqueidentifier] NOT NULL,
	[BankName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Banks] PRIMARY KEY CLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarCategories]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarCategories](
	[Category] [nvarchar](50) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifyAt] [datetime] NOT NULL,
	[CreaatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[Status] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_CarCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarCategoryMapper]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarCategoryMapper](
	[Id] [uniqueidentifier] NOT NULL,
	[CarId] [uniqueidentifier] NOT NULL,
	[CarCategoryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CarCategoryMapper] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarPurchases]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarPurchases](
	[CarPurchaseId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[DealerId] [uniqueidentifier] NOT NULL,
	[CarVarientId] [uniqueidentifier] NOT NULL,
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[PaymentMethodId] [uniqueidentifier] NOT NULL,
	[PromoId] [uniqueidentifier] NULL,
	[EmiId] [uniqueidentifier] NULL,
	[IsFullPayment] [bit] NOT NULL,
	[CurrencyId] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](12, 3) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddressId] [uniqueidentifier] NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_CarPurchases] PRIMARY KEY CLUSTERED 
(
	[CarPurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarRents]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarRents](
	[CarRentId] [uniqueidentifier] NOT NULL,
	[CarVarientId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CurrencyId] [uniqueidentifier] NOT NULL,
	[BookingDate] [datetime] NOT NULL,
	[PickupPoint] [uniqueidentifier] NOT NULL,
	[ReturningDate] [datetime] NOT NULL,
	[DropPoint] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[IsPaymentDone] [bit] NOT NULL,
	[PaymentMethodId] [uniqueidentifier] NOT NULL,
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_CarRents] PRIMARY KEY CLUSTERED 
(
	[CarRentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Name] [nvarchar](50) NOT NULL,
	[ShortDescription] [nvarchar](100) NOT NULL,
	[LongDescription] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[ModifyAt] [datetime] NULL,
	[CreaatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[Status] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CarCategoryId] [uniqueidentifier] NULL,
	[Brand] [nvarchar](30) NOT NULL,
	[Image] [varchar](4000) NULL,
	[AddressId] [uniqueidentifier] NULL,
	[Kilometers] [decimal](8, 2) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarVarients]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarVarients](
	[Id] [uniqueidentifier] NOT NULL,
	[carId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[Status] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Price] [money] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Image] [varchar](4000) NULL,
 CONSTRAINT [PK_CarVarients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityId] [uniqueidentifier] NOT NULL,
	[StateId] [uniqueidentifier] NOT NULL,
	[CityName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](320) NOT NULL,
	[Query] [varchar](500) NOT NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [uniqueidentifier] NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[CurrencyId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](15) NOT NULL,
	[CountryId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dealers]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dealers](
	[DealerId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[AddressId] [uniqueidentifier] NULL,
	[ContactNo] [varchar](15) NOT NULL,
	[IsVerified] [bit] NOT NULL,
	[VerifiedBy] [uniqueidentifier] NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Dealers] PRIMARY KEY CLUSTERED 
(
	[DealerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMIs]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMIs](
	[EmiId] [uniqueidentifier] NOT NULL,
	[BankId] [uniqueidentifier] NOT NULL,
	[CardType] [nvarchar](15) NOT NULL,
	[Period] [int] NOT NULL,
	[Interest] [decimal](7, 4) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[Isdeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_EMIs] PRIMARY KEY CLUSTERED 
(
	[EmiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAQs]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQs](
	[FaqId] [uniqueidentifier] NOT NULL,
	[Question] [nvarchar](100) NOT NULL,
	[Answer] [nvarchar](500) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_FAQs] PRIMARY KEY CLUSTERED 
(
	[FaqId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CategoryId] [uniqueidentifier] NULL,
	[Description] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackCategory]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackCategory](
	[Id] [uniqueidentifier] NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FeedbackCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[TranscationId] [nvarchar](50) NOT NULL,
	[Frequency] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offers]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[OfferId] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Details] [nvarchar](20) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[OfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[PaymentMethodId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[PaymentMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pincodes]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pincodes](
	[PincodeId] [uniqueidentifier] NOT NULL,
	[CityId] [uniqueidentifier] NOT NULL,
	[Pincode] [int] NOT NULL,
 CONSTRAINT [PK_Pincodes] PRIMARY KEY CLUSTERED 
(
	[PincodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promo]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promo](
	[PromoId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[PromoCode] [varchar](40) NOT NULL,
	[Details] [nvarchar](200) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[Isdeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Promo] PRIMARY KEY CLUSTERED 
(
	[PromoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ReviewId] [uniqueidentifier] NOT NULL,
	[CarId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Rating] [int] NOT NULL,
	[Discription] [nvarchar](200) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [nchar](10) NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateId] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 26-03-2021 11:03:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[Email] [varchar](320) NOT NULL,
	[HashPassword] [binary](32) NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ContactNo] [varchar](15) NOT NULL,
	[AddressId] [uniqueidentifier] NULL,
	[IdProof] [varchar](4000) NULL,
	[Points] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
	[Image] [varchar](4000) NULL,
	[PasswordSalt] [binary](32) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'2d71d103-a549-476f-a771-00b82a4026f7', N'Satyam nagar', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'0b084bed-9fe2-41c3-b85a-042404d782ff', N'Satyam nagar', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'fb5b5662-d003-466f-9e27-0bb247986bef', N'Bodakdev', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'00ed814f-b457-4827-a000-10b61f80e441', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'd2adc3b7-bef1-46e6-8829-18c7752c39fb', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'a5cfd70d-1417-4349-ada5-1d44195d97d8', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'3eb38dcf-c761-4fda-95a3-23fd40f3fa05', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'8fbe308d-f21b-4021-89e2-28cae6db892f', N'vadodara', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'7df17ead-5639-4a72-bbf1-36a7c97432cb', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'4e492c52-d9fb-4d90-ae7c-3da8761dd51c', N'Maninagar', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'8ea0b8ef-2e5d-4634-8e50-404f18401548', N'b-38', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'4e3fbeaf-4a3e-492c-a235-44c8c60d3021', N'Maninagar', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'e9940bd9-ad31-4092-924b-455b7a3baf26', N'navsari', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'be577c07-c111-474e-9ca1-52fea3d2399a', N'b-38', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'18e80f66-fc72-4e0f-9b3e-555fe6b3542b', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'63f1cd33-cced-44ab-91d7-5a98b9869357', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'db1ced32-d312-4506-87de-5c7dd49689cf', N'Charu Circle', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'5e2fdad1-e019-4c62-902f-64f67ce4fab1', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'dcaf0a09-badc-4966-9e9b-6b9a97da0baf', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'860acbf9-52a2-4644-affe-70e1a57163ca', N'B38,India Colony', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'ca07aa9f-a429-4eb7-b023-7811a23be81f', N'Satyam nagar', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'c2eceba8-f417-422d-84ca-7fff8517f9f9', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'd4542d4d-f4a9-4576-912c-a2b064986514', N'vadodara', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'46801006-bfd0-45db-a1c7-a33f29941ea5', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'd85b58ff-f482-43fe-9d9f-a6676a6dbc80', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'2d869dc5-80d8-4b3e-9983-b0ac7b6b2773', N'Navrangpura', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'eb53730d-ba07-41b1-9787-be724cb40160', N'b-38', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'4cd420a4-fc11-4afc-978b-cf450ceb8bdb', N'Maninagar', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'14acaef5-5726-465e-ad05-d25b53414ee5', N'b-38', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'd4fd5ee3-62a5-4503-a592-d27d8debbd1f', N'Satyam nagar', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'e012ab22-e861-458f-abe7-d2a815fab636', N'b-38', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'd37f4919-b89c-441a-a837-d63e2bb57d42', N'Someshvar', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'2fc1c655-c7af-4926-9659-dc389264a3e8', N'Iscon', N'6ec4327c-e483-4970-884c-c8b99bb178c9', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'69365eec-82bc-48c7-9ac9-e2976146a02f', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'bc8a9d91-98bf-41a6-a777-e50f42b5484a', N'Ahemdabad', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'3386e477-ecf0-4a4c-88df-f962c2bc0eda', N'string', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
GO
INSERT [dbo].[Admin] ([Id], [Email], [Passowrd], [Name], [Contact], [Role]) VALUES (N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'ram@gmail.com', N'123456', N'Ram', N'9621221615', N'Owner')
GO
INSERT [dbo].[CarCategories] ([Category], [Id], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Status], [IsDeleted]) VALUES (N'Used', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', 0, 0)
INSERT [dbo].[CarCategories] ([Category], [Id], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Status], [IsDeleted]) VALUES (N'Rent', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99d', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0)
INSERT [dbo].[CarCategories] ([Category], [Id], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Status], [IsDeleted]) VALUES (N'New', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', 0, 0)
GO
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'a9559d4d-cfca-4dad-bb12-0f2e692b4c58', N'aa79767d-a78c-4847-a935-3f5ed925355c', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'12518bb2-b27f-49c9-9d57-3f4beccc71c9', N'70ee45ae-b86f-4b4e-8193-2c977d4d818c', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(350000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-14T13:51:33.007' AS DateTime), NULL, CAST(N'2021-03-14T13:51:33.007' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'0f6092b7-dd67-4406-b91a-1aec62467ec8', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'c6d77de5-aa75-4011-8eb7-eaa2040c2495', N'23c2b3bb-8624-4009-a801-f09689e15e0a', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(1000000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-12T13:52:57.153' AS DateTime), NULL, CAST(N'2021-03-12T13:52:57.347' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'49de1d2f-d7f7-4727-a607-24f52134557e', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'b503f227-544c-41b0-8d7c-7a593cbd9231', N'a08c1950-8141-413e-ba25-deb77d5318a7', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(600000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-10T17:06:45.933' AS DateTime), NULL, CAST(N'2021-03-10T17:06:45.933' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'2f2f9165-8b5d-4c0e-8ddb-2693a308028c', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'c3ab966f-b80b-40e4-9207-ae127c5ff11a', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(500000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'67cd1138-dd37-4d5c-80b8-362cdb04aa6e', N'c35d71ee-e229-44f6-b6f7-7de13435e32a', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'715b74f9-a479-4394-b309-1061796b42f8', N'ccb616bd-6064-488f-84ba-69cc62f7e704', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(900000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-12T13:25:10.090' AS DateTime), NULL, CAST(N'2021-03-12T13:25:10.090' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'b905cbe7-6d95-4367-a6b1-3a31076e8dbc', N'59716c6d-0f20-48b6-b79d-1c8cfad99f24', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'892f7047-860d-40a7-b053-bce3dc8e6ba0', N'7ec0f597-81ab-4083-aa48-49b55e71108a', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(600000.000 AS Decimal(12, 3)), 0, N'0b084bed-9fe2-41c3-b85a-042404d782ff', CAST(N'2021-03-26T21:55:58.217' AS DateTime), NULL, CAST(N'2021-03-26T21:55:58.217' AS DateTime), NULL, 1)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'5f9afe46-9c23-402d-9fa8-4fed95417b1f', N'59716c6d-0f20-48b6-b79d-1c8cfad99f24', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'a4892b2d-b73e-48bc-8c20-ed1df8e80d9a', N'72f76ee5-45db-40de-8eb3-90e3ce12c242', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(1000000.000 AS Decimal(12, 3)), 0, N'fb5b5662-d003-466f-9e27-0bb247986bef', CAST(N'2021-03-26T16:05:28.183' AS DateTime), NULL, CAST(N'2021-03-26T16:05:28.183' AS DateTime), NULL, 1)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'0a9e9400-49aa-4674-bd99-59612bbe13a8', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'db45dc5c-239b-44eb-bb49-c6eaba053768', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(500000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'5a1a74da-30f3-4aa8-8bf8-88b235be31ff', N'205e6213-3577-4b64-bee9-d1f7ad749804', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'e66eef78-5623-4658-b8be-dea36d89456c', N'4b490c00-ec89-428b-be9b-4d740a96a36c', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(1000000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-12T13:46:22.437' AS DateTime), NULL, CAST(N'2021-03-12T13:46:22.563' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'68385690-6b1c-40ea-8b1f-892bf568b401', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'c8c01071-2e9f-48a4-9b8c-e5e297f9069c', N'015f3c99-1df9-46e5-b23b-b3216e54006e', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(300000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-06T23:59:49.543' AS DateTime), NULL, CAST(N'2021-03-06T23:59:49.543' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'78e85b89-fbe2-4d6d-bc9c-8baace026102', N'59716c6d-0f20-48b6-b79d-1c8cfad99f24', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'a4892b2d-b73e-48bc-8c20-ed1df8e80d9a', N'02db47a1-996d-4e01-831a-d90ac7bcd73c', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(1000000.000 AS Decimal(12, 3)), 0, N'ca07aa9f-a429-4eb7-b023-7811a23be81f', CAST(N'2021-03-26T21:03:58.477' AS DateTime), NULL, CAST(N'2021-03-26T21:03:58.477' AS DateTime), NULL, 1)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'678be637-097e-47e0-ba0b-8c9f2ab5b63f', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'28874872-1565-477f-9b8b-8b73385cf485', N'd2309e5f-8dbf-4519-a32e-508951557087', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(100000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-06T13:43:05.960' AS DateTime), NULL, CAST(N'2021-03-06T13:43:05.960' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'5fc26a0d-8549-41d1-b167-ac6eb2af996b', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'b503f227-544c-41b0-8d7c-7a593cbd9231', N'74f6c930-c2b7-4d90-b106-c4d825fbb439', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(600000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-08T10:28:52.903' AS DateTime), NULL, CAST(N'2021-03-08T10:28:52.903' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'ad83da9c-99a4-42eb-9180-ace11a9a3ca3', N'59716c6d-0f20-48b6-b79d-1c8cfad99f24', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'f05c3cd3-ae32-494f-abb5-e29f5463ecd9', N'384c32bb-0919-469b-918b-1a350dc20720', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(456000.000 AS Decimal(12, 3)), 0, N'4e3fbeaf-4a3e-492c-a235-44c8c60d3021', CAST(N'2021-03-26T16:16:57.143' AS DateTime), NULL, CAST(N'2021-03-26T16:16:57.143' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'8146edc1-3c97-44fa-bb0d-b31409a89563', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'01799a80-3804-4299-98cf-9f0ac0b11293', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(500000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'ae6f627f-9649-4585-8154-b8ece092b84f', N'1f0326c4-e62e-42ef-8dd2-869af2ac9a46', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'a4892b2d-b73e-48bc-8c20-ed1df8e80d9a', N'64849395-33d2-4147-8995-0097de71f5df', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(10000000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-14T13:05:33.550' AS DateTime), NULL, CAST(N'2021-03-14T13:05:33.550' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'73d2019c-f3bc-4d33-a17f-cd82dd06106f', N'59716c6d-0f20-48b6-b79d-1c8cfad99f24', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'a4892b2d-b73e-48bc-8c20-ed1df8e80d9a', N'748d3040-9147-4b96-9701-83ad8b754ea5', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(1000000.000 AS Decimal(12, 3)), 1, N'd4fd5ee3-62a5-4503-a592-d27d8debbd1f', CAST(N'2021-03-26T21:04:18.053' AS DateTime), NULL, CAST(N'2021-03-26T21:04:18.053' AS DateTime), NULL, 1)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'7bdad3b1-3042-4554-b986-e8d0df585c50', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'e66eef78-5623-4658-b8be-dea36d89456c', N'b0ebffc7-5ec0-402c-bacd-6f6f2dbae806', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(1000000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-12T13:50:36.787' AS DateTime), NULL, CAST(N'2021-03-12T13:50:36.877' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'a91cae56-6c62-47cb-8e49-ee0b428443fe', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'b503f227-544c-41b0-8d7c-7a593cbd9231', N'f5523023-f952-4e83-8194-da0cde750826', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(600000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-10T14:26:41.633' AS DateTime), NULL, CAST(N'2021-03-10T14:26:41.633' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'bc0f4f7c-8d40-4ac3-9944-f8a251b6797d', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'715b74f9-a479-4394-b309-1061796b42f8', N'5b9190cd-d722-4242-9d97-dcbf2adfa652', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(900000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-08T18:02:35.283' AS DateTime), NULL, CAST(N'2021-03-08T18:02:35.283' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'31a37247-a992-480e-958a-fc8846b0f114', N'c35d71ee-e229-44f6-b6f7-7de13435e32a', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'b503f227-544c-41b0-8d7c-7a593cbd9231', N'6680e0da-8597-4729-a516-4ba49408e44b', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(600000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-12T13:24:34.350' AS DateTime), NULL, CAST(N'2021-03-12T13:24:34.350' AS DateTime), NULL, 0)
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'05b951a8-57c0-4667-ae3f-fec72c6c78b4', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'90c25f61-fd5c-4434-a907-61f29fae3513', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(500000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, NULL, NULL, 0)
GO
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'8bf64316-553d-42e4-a5fd-3481c5f6d4b1', N'0f9a70c0-0822-4ca2-a5b3-4a595ba83c94', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-03T13:53:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-22T13:53:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(3800000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'ba0f148b-3a59-49dd-a807-8b0aa1130bdd', CAST(N'2021-03-12T13:54:00.080' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-12T13:54:00.080' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'44521b76-2815-47c6-a95f-417911cb5cf6', N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'59716c6d-0f20-48b6-b79d-1c8cfad99f24', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-26T00:00:00.000' AS DateTime), N'2d71d103-a549-476f-a771-00b82a4026f7', CAST(N'2021-03-31T00:00:00.000' AS DateTime), N'2d71d103-a549-476f-a771-00b82a4026f7', CAST(27500.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'7a27b87c-d8c3-49a4-8a17-aea87b3025d3', CAST(N'2021-03-26T21:52:11.547' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-26T21:52:11.547' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'92902763-3ed4-490b-b1a8-63e1caccca45', N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-05T11:38:36.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-05T11:38:36.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(500000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'8afd8ba9-1005-4f27-9023-11cbd37d3f12', CAST(N'2021-03-05T17:30:32.847' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-05T17:30:33.327' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'018b327f-e1ec-4ca1-b59d-8b87d8eb04db', N'f906a818-510a-41b6-b104-a33f6994ca64', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-15T17:14:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-26T17:14:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(4400000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'fd09d1de-b969-46e7-9947-6445e7fa619d', CAST(N'2021-03-10T17:15:11.680' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-10T17:15:11.680' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'aa6451d6-17b8-43a1-8c81-8ce276a1856b', N'0f9a70c0-0822-4ca2-a5b3-4a595ba83c94', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-24T14:41:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-31T14:41:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(1400000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'7d71a574-9607-4dee-9abc-be81a42925f4', CAST(N'2021-03-12T14:42:17.980' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-12T14:42:17.980' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'59deb7e6-9257-4950-9ade-8e68ea7933f8', N'0f9a70c0-0822-4ca2-a5b3-4a595ba83c94', N'59716c6d-0f20-48b6-b79d-1c8cfad99f24', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-26T00:00:00.000' AS DateTime), N'4e492c52-d9fb-4d90-ae7c-3da8761dd51c', CAST(N'2021-03-27T00:00:00.000' AS DateTime), N'4e492c52-d9fb-4d90-ae7c-3da8761dd51c', CAST(2500.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'4aec2bac-46f6-44ec-a681-f082eae088cd', CAST(N'2021-03-26T18:08:04.153' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-26T18:08:04.153' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'3fa4c941-9028-4a96-af67-9905b8ca5a52', N'30e528fd-0789-487c-9312-5ea1eff03a3b', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-10T10:55:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-25T10:55:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(30000000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'0166782c-5156-43da-9389-da92815901d5', CAST(N'2021-03-08T10:55:59.647' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-08T10:55:59.647' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'd5a4da1c-7f3f-4bc0-8013-9a9b05b50a06', N'0f9a70c0-0822-4ca2-a5b3-4a595ba83c94', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-04-14T00:00:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-05-20T00:00:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(7200000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'15537207-7002-490e-8aad-dc10e5a270ae', CAST(N'2021-03-14T10:12:07.187' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-14T10:12:07.187' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'cddc117a-a5d5-42fd-8929-c162b7816032', N'0e423027-c45c-486f-86f5-fcb482c71d45', N'aa79767d-a78c-4847-a935-3f5ed925355c', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-19T00:00:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-30T00:00:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(7700000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'8ecea72d-8665-4d41-bd47-58852dfb0746', CAST(N'2021-03-14T13:50:59.677' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-14T13:50:59.677' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'3728c64c-33e2-4bd9-bc4f-c764f64af14d', N'f906a818-510a-41b6-b104-a33f6994ca64', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-07T11:05:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-19T11:05:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(4800000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'fea3d470-5292-4342-b322-427aaafacfd7', CAST(N'2021-03-08T11:06:44.233' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-08T11:06:44.633' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'88ea7100-b040-413e-96fe-cabf968e9dd1', N'0f9a70c0-0822-4ca2-a5b3-4a595ba83c94', N'c35d71ee-e229-44f6-b6f7-7de13435e32a', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-23T13:21:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-25T13:21:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(400000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'dbb5656b-f63d-4a90-8e6a-263f9badb85e', CAST(N'2021-03-12T13:22:49.537' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-12T13:22:49.537' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'f7ef12fd-6414-4743-9072-cde369b8e21c', N'0f9a70c0-0822-4ca2-a5b3-4a595ba83c94', N'1f0326c4-e62e-42ef-8dd2-869af2ac9a46', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-16T00:00:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-31T00:00:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(3000000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'720adb01-4485-41b7-9956-aa2238143e7b', CAST(N'2021-03-14T13:06:43.893' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-14T13:06:43.893' AS DateTime), NULL, 0, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'2590a379-42cb-41f8-8703-daf8936b1cb3', N'0e423027-c45c-486f-86f5-fcb482c71d45', N'59716c6d-0f20-48b6-b79d-1c8cfad99f24', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-31T00:00:00.000' AS DateTime), N'4cd420a4-fc11-4afc-978b-cf450ceb8bdb', CAST(N'2021-04-08T00:00:00.000' AS DateTime), N'4cd420a4-fc11-4afc-978b-cf450ceb8bdb', CAST(56000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'290ca72b-c965-45a1-ae64-ca4961503b5e', CAST(N'2021-03-26T16:06:42.260' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-26T16:06:42.260' AS DateTime), NULL, 1, 0)
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'07d1a0fc-5802-4e74-9485-f5f4e968447d', N'0f9a70c0-0822-4ca2-a5b3-4a595ba83c94', N'205e6213-3577-4b64-bee9-d1f7ad749804', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-15T13:17:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-22T13:17:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(1400000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'c0d515d2-bf9c-4144-acdb-271cff3e1edc', CAST(N'2021-03-12T13:18:09.847' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-12T13:18:09.847' AS DateTime), NULL, 0, 0)
GO
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW 7 Series', N'Luxury midsize car. ', N'BMW 5 Series is a great luxury midsize car. It costs more than other cars in the class, but this BMW provides the appeal that justifies that cost.', CAST(N'2021-03-26T11:15:19.117' AS DateTime), CAST(N'2021-03-26T11:15:19.117' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'554937a2-5c1e-4c18-be08-0f723e08fe2d', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'BMW', N'Car3262021 111519 AM.jpg', N'd85b58ff-f482-43fe-9d9f-a6676a6dbc80', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'
BMW 7 Series', N'BMW Z', N'BMW offers 17 new car models and 7 upcoming models in India. The most popular SUV car of BMW is X1', CAST(N'2021-03-13T12:26:55.743' AS DateTime), CAST(N'2021-03-13T12:26:55.743' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'8df20ac3-76ee-45a4-ad65-187bd272b1b6', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'BMW', N'Car3132021 122655 PM.jpg', N'e9940bd9-ad31-4092-924b-455b7a3baf26', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi RS7', N'Sportback Key Specifications', N'Feature highlights of the 2020 Audi RS7 Sportback include a five-seat configuration (offered for the first time), RS adaptive air suspension, flared wheel arches, 21-inch alloy wheels, single-frame grille with honeycomb mesh, rear bumper with integrated diffuser and oval exhaust pipes, panoramic sunroof and LED matrix headlamps.', CAST(N'2021-02-23T19:22:45.867' AS DateTime), CAST(N'2021-02-23T19:34:51.700' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'1a6f5293-f600-4cd0-81a4-1b751c82010f', 0, 1, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'Audi', N'audi RS7.jpg', N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW 8 Series', N'BMW Y', N'BMW offers 17 new car models and 7 upcoming models in India. The most popular SUV car of BMW is', CAST(N'2021-03-13T13:10:18.080' AS DateTime), CAST(N'2021-03-13T13:10:18.080' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'1bf034bb-1ec1-482b-8d5c-1bd9e6a0c53a', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'BMW', N'Car3132021 11018 PM.jpg', N'c2eceba8-f417-422d-84ca-7fff8517f9f9', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW 3 Series', N'Modern day features ', N'BMW took wraps off the new-gen 3 Series at the 2018 Paris Motor Show. The G20 3 Series takes its inspiration from the resurrected 8 and comes with many modern day features while retaining its characteristic driving dynamics. And the new 3 Series is a lot better looking compared to the F30 model it replaces.', CAST(N'2021-02-22T22:49:04.890' AS DateTime), CAST(N'2021-02-22T22:49:04.890' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'a5a7865d-3a29-4e30-87e7-28b896bb28e4', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'BMW', N'bmw-3-series.jpg', N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(1500.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'AUDI Rs', N'Comes with new features', N'This German luxury brand is known for technology and style as much as its performance, well-crafted interiors, and its trademark Quattro all-wheel-drive system. Nearly every model is a solid performer with a high-grade interior. Ride and handling are accomplished and the cabin is quiet.', CAST(N'2021-03-26T11:30:25.950' AS DateTime), CAST(N'2021-03-26T11:30:25.950' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'def8b94e-44e4-4af4-a931-3cbcd3d746ce', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'Audi', N'Car3262021 113025 AM.jpg', N'd2adc3b7-bef1-46e6-8829-18c7752c39fb', CAST(2500.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi RSQ8', N'Best in market', N'Audi has expanded its high performance range in India with the arrival of the RSQ8. It''s the first performance SUV', CAST(N'2021-03-10T12:26:24.260' AS DateTime), CAST(N'2021-03-10T12:26:24.260' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'0977967f-71b6-4e53-958a-4cbf0e76b688', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'Audi', N'Car3102021 122624 PM.jpg', N'd37f4919-b89c-441a-a837-d63e2bb57d42', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW X5 Series', N'Engine: 2.4-litre V6', N'Its powerful 2998cc engine performs amazingly and makes drive comfortable and enjoyable. The ground clearance of X5 is really good that it can go on bad roads without any damage.', CAST(N'2021-02-22T01:27:09.743' AS DateTime), CAST(N'2021-02-22T14:50:14.027' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'9355c897-7671-4ab8-885e-5341d4abe5ca', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99d', N'BMW', N'bmw-x5.jpg', N'3386e477-ecf0-4a4c-88df-f962c2bc0eda', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW S8', N'Luxury midsize car. ', N'Matte Black Audi R8 Pictures, Photos, Wallpapers. @ Top Speed. matte black audi r8 media gallery. featuring 6 matte black high-resolution photos.', CAST(N'2021-03-26T12:12:50.937' AS DateTime), CAST(N'2021-03-26T12:12:50.937' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bb35f9d4-6773-4370-af00-5bbcfe6a218c', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99d', N'BMW', N'Car3262021 121250 PM.jpg', N'db1ced32-d312-4506-87de-5c7dd49689cf', CAST(2500.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi A6', N'Automatic (Dual Clutch)', N'Audi has launched the eight generation A6 in India with fresh set of cosmetic and feature updates. The premium sedan is available in two trims – Premium Plus and Technology. The new model is underpinned by the parent company Volkswagen’s MLB platform.', CAST(N'2021-03-12T13:28:47.390' AS DateTime), CAST(N'2021-03-12T13:28:47.390' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'29904657-7e2f-4f7d-944e-600e9e1955a2', 0, 1, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'Audi', N'Car3122021 12847 PM.jpg', N'be577c07-c111-474e-9ca1-52fea3d2399a', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW 6 Series', N' Luxury car', N'The BMW 6 Series is a range of grand tourers produced by BMW since 1976. It is the successor to the E9 Coupé and is currently in its fourth generation. ', CAST(N'2021-03-26T11:19:33.980' AS DateTime), CAST(N'2021-03-26T11:19:33.980' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'7f8655d9-4775-4fb5-ae25-60acaffb7fba', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'BMW', N'Car3262021 111933 AM.jpg', N'5e2fdad1-e019-4c62-902f-64f67ce4fab1', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW M', N'Feature updates', N'The BMW X1 features large kidney grilles which are flanked by sleek LED headlamps. The bumper design has have been revised and it now features slim LED fog lamps and large airdams.', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2021-02-21T21:28:50.593' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99d', N'BMW', N'bmw-x1.jpg', N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW VNO', N'Best car', N'Bayerische Motoren Werke Aktiengesellschaft', CAST(N'2021-03-26T13:39:51.043' AS DateTime), CAST(N'2021-03-26T13:39:51.043' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'e3d47688-2a85-42de-aecc-92c1c6cb1d51', 0, 1, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'BMW', N'Car3262021 13951 PM.jpg', N'7df17ead-5639-4a72-bbf1-36a7c97432cb', CAST(2500.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW 5 Series', N'Comes with depreciation', N'BMW 5 Series is a 5 seater Sedan. It costs more than other cars in the class, but this BMW provides the appeal that justifies that cost. ', CAST(N'2021-03-26T11:23:20.447' AS DateTime), CAST(N'2021-03-26T11:23:20.447' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'1421bcf6-c007-4d23-bad8-9c396843b164', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'BMW', N'Car3262021 112320 AM.jpg', N'2d869dc5-80d8-4b3e-9983-b0ac7b6b2773', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'AUDI S9', N'Latest features', N' It costs more than other cars in the class, but this AUDI provides the appeal that justifies that cost. ', CAST(N'2021-03-26T11:47:19.960' AS DateTime), CAST(N'2021-03-26T11:47:19.960' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'c7080e3b-1a08-4b90-9187-9caae6241daa', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'Audi', N'Car3262021 114719 AM.jpg', N'd4542d4d-f4a9-4576-912c-a2b064986514', CAST(900.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW 2s Series', N'Best car', N' It costs more than other cars in the class, but this BMW provides the appeal that justifies that cost. ', CAST(N'2021-03-26T11:38:34.470' AS DateTime), CAST(N'2021-03-26T11:38:34.470' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'cc7e9adf-5eaf-4a8c-ab14-a314940d8753', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'BMW', N'Car3262021 113834 AM.jpg', N'bc8a9d91-98bf-41a6-a777-e50f42b5484a', CAST(2300.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi RS7', N'With the introduction of the A4 facelift', N'The new Audi A4 facelift is based on the B9 generation model that was unveiled back in 2016. Changes to the exterior design include an updated single-frame grille, refreshed front and rear bumpers, new matrix LED headlamps, and reworked tail lights.', CAST(N'2021-02-23T16:42:33.350' AS DateTime), CAST(N'2021-02-23T16:42:33.350' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'4a4c8651-1237-4444-b541-a8ddf2e39e7f', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'Audi', N'Audi A4.jpeg', N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi Q2', N'Smallest SUV', N'Smallest SUV yet at the Geneva Motor Show. Built on Volkswagen’s MQB platform, the Q2 will sit under the Q3 in the German manufacturer’s SUV portfolio', CAST(N'2021-02-22T21:43:40.790' AS DateTime), CAST(N'2021-02-22T21:43:40.790' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'0d87bbf7-bd3e-404e-b64f-be2a2829a990', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'Audi', N'Audi Q2.jpg', N'69365eec-82bc-48c7-9ac9-e2976146a02f', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi S5', N'Elegant design, sumptuous quality', N'Underpinned by the MQB platform which makes the car slightly bigger but lighter than the existing model. Edgier design, in-line with the company’s new design philosophy, make it look more sculpted than before. The all-LED headlamps and taillamps add to the futuristic look of the SUV. ', CAST(N'2021-02-22T01:16:54.230' AS DateTime), CAST(N'2021-02-22T01:16:54.793' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'dceca9a3-0d69-40eb-b2fd-c887f33f7fbf', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'Audi', N'Audi X10.jpg', N'3eb38dcf-c761-4fda-95a3-23fd40f3fa05', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'A8L', N'Audi SINO', N'Very Comfertable', CAST(N'2021-03-14T13:15:25.913' AS DateTime), CAST(N'2021-03-14T13:15:25.913' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'd338e525-44bb-4ac8-84cd-c89869829d12', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'Audi', N'Car14032021 011525 PM.jpg', N'860acbf9-52a2-4644-affe-70e1a57163ca', CAST(10000.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW 5 Series', N'Automatic', N'Speak of convertible and the BMW Z4 Roadster immediately gets a mention. The German luxury car manufacturer, BMW has introduced the Z4 Roadster in India in two engine options - the sDrive20i and the BMW M Performance model, the M40i. The globally popular two-seat convertible available as a Completely Built-Up Unit (CBU).', CAST(N'2021-03-05T13:27:43.233' AS DateTime), CAST(N'2021-03-05T13:27:43.233' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'832f8ddb-7ec4-4fd7-98ee-d10650409d04', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99d', N'BMW', N'BMW-Z4.jpg', N'8ea0b8ef-2e5d-4634-8e50-404f18401548', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi A4', N'Lightweight construction ', N'Abundance of high-end gadgets exemplify Audi’s flagship offering – the A8L. It is the most luxurious offering in Audi’s portfolio and from 2018, Audi will gradually be taking piloted driving functions such as parking pilot, garage pilot and traffic jam pilot into production.', CAST(N'2021-03-12T13:51:14.497' AS DateTime), CAST(N'2021-03-12T13:51:14.497' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'8150fea8-4404-424a-bfc0-e5ba98a894f0', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'Audi', N'Car3122021 15114 PM.jpg', N'46801006-bfd0-45db-a1c7-a33f29941ea5', CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'BMW 8 Series', N'Best car', N' It costs more than other cars in the class, but this BMW provides the appeal that justifies that cost. ', CAST(N'2021-03-26T11:40:47.587' AS DateTime), CAST(N'2021-03-26T11:40:47.587' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'cf38309a-c21a-426d-b1c3-e97da37227e2', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'BMW', N'Car3262021 114047 AM.jpg', N'a5cfd70d-1417-4349-ada5-1d44195d97d8', CAST(7800.00 AS Decimal(8, 2)))
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi RS Q8', N'High performance range', N'It’s the first performance SUV from the German automaker, and is powered by a 4.0-litre TFSI twin-turbo V8 engine producing 600bhp/800Nm.', CAST(N'2021-02-22T15:45:29.163' AS DateTime), CAST(N'2021-02-22T15:45:29.163' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bb4e1630-d89d-4433-b379-f82653b720e0', 0, 1, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'Audi', N'Audi RS Q8.jpg', N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(0.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'c0bd03c8-bf32-40aa-a875-07ded387e75e', N'1a6f5293-f600-4cd0-81a4-1b751c82010f', CAST(N'2021-02-22T15:46:17.513' AS DateTime), CAST(N'2021-02-22T15:46:17.513' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 300000.0000, N'Top Model', N'Car3102021 120509 PM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'715b74f9-a479-4394-b309-1061796b42f8', N'a5a7865d-3a29-4e30-87e7-28b896bb28e4', CAST(N'2021-02-22T14:43:46.513' AS DateTime), CAST(N'2021-02-22T14:43:46.513' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 900000.0000, N'3 Series 330i Sport', N'car1.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'e82f6333-be2f-4cab-a154-2060b511b2ae', N'bb35f9d4-6773-4370-af00-5bbcfe6a218c', CAST(N'2021-03-26T12:22:42.903' AS DateTime), CAST(N'2021-03-26T12:22:42.903' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 400000.0000, N'S8 X', N'Car3262021 122242 PM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'aaf4fdba-dcdc-4c8d-a4a2-2dc7620d3921', N'0d87bbf7-bd3e-404e-b64f-be2a2829a990', CAST(N'2021-03-26T11:28:59.070' AS DateTime), CAST(N'2021-03-26T11:28:59.070' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 1250000.0000, N'AUDI Q2 iz', N'Car3262021 112859 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'7991cfdc-1344-47f7-b04a-34503e95250e', N'cf38309a-c21a-426d-b1c3-e97da37227e2', CAST(N'2021-03-26T11:41:39.997' AS DateTime), CAST(N'2021-03-26T11:41:39.997' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 4000000.0000, N'BMw 8ultra', N'Car3262021 114139 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'12518bb2-b27f-49c9-9d57-3f4beccc71c9', N'd338e525-44bb-4ac8-84cd-c89869829d12', CAST(N'2021-03-14T13:16:37.083' AS DateTime), CAST(N'2021-03-14T13:16:37.083' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 350000.0000, N'A4 Premium Plus x', N'Car14032021 011637 PM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'504ab8a4-c514-4410-820e-420cd31d552f', N'cc7e9adf-5eaf-4a8c-ab14-a314940d8753', CAST(N'2021-03-26T11:39:40.830' AS DateTime), CAST(N'2021-03-26T11:39:40.830' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 1680000.0000, N'BMw 2s Xi', N'Car3262021 113940 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'b29a06ba-f5c5-4ba6-ac2d-4944b5caefc7', N'e3d47688-2a85-42de-aecc-92c1c6cb1d51', CAST(N'2021-03-26T13:40:43.197' AS DateTime), CAST(N'2021-03-26T13:40:43.197' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 400000.0000, N'VNO iy', N'Car3262021 14043 PM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'9355c897-7671-4ab8-885e-5341d4abe5ca', CAST(N'2021-02-23T19:47:59.313' AS DateTime), CAST(N'2021-02-23T19:47:59.313' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 5500.0000, N'X5 xDrive 30d Sport', N'car2.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'0f9a70c0-0822-4ca2-a5b3-4a595ba83c94', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', CAST(N'2021-02-22T14:44:58.920' AS DateTime), CAST(N'2021-02-22T14:44:58.920' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 2500.0000, N'M Series M3 Sedan', N'car3.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'076c8629-3c5b-46d9-91fd-54d8a0b05bc6', N'554937a2-5c1e-4c18-be08-0f723e08fe2d', CAST(N'2021-03-26T12:10:55.927' AS DateTime), CAST(N'2021-03-26T12:10:55.927' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 450000.0000, N'BMW 7 X', N'Car3262021 121055 PM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'44714170-9212-49d3-a61e-57d24c8b2d4f', N'c7080e3b-1a08-4b90-9187-9caae6241daa', CAST(N'2021-03-26T11:54:03.963' AS DateTime), CAST(N'2021-03-26T11:54:03.963' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 480000.0000, N'AUDI S9 fusion', N'Car3262021 115403 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'30e528fd-0789-487c-9312-5ea1eff03a3b', N'832f8ddb-7ec4-4fd7-98ee-d10650409d04', CAST(N'2021-03-05T13:28:19.737' AS DateTime), CAST(N'2021-03-05T13:28:19.737' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 2000.0000, N'5 Series 530i Sport', N'car4.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'32c37714-934c-4af9-ad65-610fa59e04d6', N'def8b94e-44e4-4af4-a931-3cbcd3d746ce', CAST(N'2021-03-26T11:31:11.333' AS DateTime), CAST(N'2021-03-26T11:31:11.333' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 1400000.0000, N'AUDI RSX', N'Car3262021 113111 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'5b16d276-1946-4ea5-a904-63ad4319a544', N'8df20ac3-76ee-45a4-ad65-187bd272b1b6', CAST(N'2021-03-14T10:47:35.590' AS DateTime), CAST(N'2021-03-14T10:47:35.590' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 600000.0000, N'7 Series 730Ld DPE Signature', N'Car14032021 104735 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'fbb43ac6-90da-4397-8ef0-6d70be8edbb7', N'7f8655d9-4775-4fb5-ae25-60acaffb7fba', CAST(N'2021-03-26T11:20:30.003' AS DateTime), CAST(N'2021-03-26T11:20:30.003' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 2980000.0000, N'6 Series GT 630d M Sport', N'Car3262021 112029 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'b503f227-544c-41b0-8d7c-7a593cbd9231', N'4a4c8651-1237-4444-b541-a8ddf2e39e7f', CAST(N'2021-02-22T22:49:19.513' AS DateTime), CAST(N'2021-02-22T22:49:19.513' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 600000.0000, N'RS7 4.0 TFSI', N'Model D.jpeg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'541cadf9-9ba0-42d2-8806-7c565d48fa4f', N'1bf034bb-1ec1-482b-8d5c-1bd9e6a0c53a', CAST(N'2021-03-13T13:11:36.863' AS DateTime), CAST(N'2021-03-13T13:11:36.863' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 800000.0000, N'840i Gran Coupe', N'Car3132021 11136 PM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'df15b2bf-8432-40e0-8fcd-8832bc971525', N'1421bcf6-c007-4d23-bad8-9c396843b164', CAST(N'2021-03-26T11:24:39.760' AS DateTime), CAST(N'2021-03-26T11:24:39.760' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 4590000.0000, N'BMW 5s8', N'Car3262021 112439 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'28874872-1565-477f-9b8b-8b73385cf485', N'0d87bbf7-bd3e-404e-b64f-be2a2829a990', CAST(N'2021-02-22T14:44:38.573' AS DateTime), CAST(N'2021-02-22T14:44:38.573' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 1890000.0000, N'Q2 Standard', N'Audi RS Q8.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'8f360f2b-9cec-4ae2-9c43-8bb02000d0f6', N'0d87bbf7-bd3e-404e-b64f-be2a2829a990', CAST(N'2021-03-26T10:58:44.470' AS DateTime), CAST(N'2021-03-26T10:58:44.470' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 2989000.0000, N'AUDI Q2 x', N'Car3262021 105844 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'bd4725b3-cab7-4a4d-a391-8fef46a1a99c', N'dceca9a3-0d69-40eb-b2fd-c887f33f7fbf', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 500000.0000, N'S5 3.0 TFSIq Tiptronic', N'audi RS7.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'f906a818-510a-41b6-b104-a33f6994ca64', N'832f8ddb-7ec4-4fd7-98ee-d10650409d04', CAST(N'2021-02-23T16:42:51.557' AS DateTime), CAST(N'2021-02-23T16:42:51.557' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 4000.0000, N'5 Series 530i M Sport', N'car5.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'677ed82e-816d-483c-8527-a5cff17c2465', N'0977967f-71b6-4e53-958a-4cbf0e76b688', CAST(N'2021-03-26T10:55:21.373' AS DateTime), CAST(N'2021-03-26T10:55:21.373' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 1290000.0000, N'AUDI RSQ8 i', N'Car3262021 105521 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'16eec8b7-032a-4eae-8f58-aad67d87887b', N'bb4e1630-d89d-4433-b379-f82653b720e0', CAST(N'2021-02-23T19:34:18.670' AS DateTime), CAST(N'2021-02-23T19:34:14.843' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 5000000.0000, N'Model A2', N'Car3102021 120509 PM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'fb42d76b-3def-4ce6-a956-af8db4d15c4b', N'8df20ac3-76ee-45a4-ad65-187bd272b1b6', CAST(N'2021-03-13T12:27:42.257' AS DateTime), CAST(N'2021-03-13T12:27:42.257' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 400000.0000, N'Z4 M40i', N'Car3132021 122742 PM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'892f7047-860d-40a7-b053-bce3dc8e6ba0', N'dceca9a3-0d69-40eb-b2fd-c887f33f7fbf', CAST(N'2021-02-22T21:43:55.540' AS DateTime), CAST(N'2021-02-22T21:43:55.540' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 600000.0000, N'S5 3.2TFSIq Tiptronic', N'Audi X10.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'3acaff9e-343a-411c-814d-c4703617d4b6', N'c7080e3b-1a08-4b90-9187-9caae6241daa', CAST(N'2021-03-26T11:49:47.587' AS DateTime), CAST(N'2021-03-26T11:49:47.587' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 450000.0000, N'AUDI S9 fusion', N'Car3262021 114947 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'e66eef78-5623-4658-b8be-dea36d89456c', N'29904657-7e2f-4f7d-944e-600e9e1955a2', CAST(N'2021-03-12T13:29:16.413' AS DateTime), CAST(N'2021-03-12T13:29:16.413' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 1000000.0000, N'Audi x2', N'Car3122021 12916 PM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'f05c3cd3-ae32-494f-abb5-e29f5463ecd9', N'8150fea8-4404-424a-bfc0-e5ba98a894f0', CAST(N'2021-03-26T10:50:05.153' AS DateTime), CAST(N'2021-03-26T10:50:05.153' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 456000.0000, N'A4 Technology i', N'Car3262021 105005 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'7f53be5a-bd36-4749-b5bc-e2dbc96fbe8f', N'a5a7865d-3a29-4e30-87e7-28b896bb28e4', CAST(N'2021-03-10T12:05:55.837' AS DateTime), CAST(N'2021-03-10T12:05:54.617' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 10000000.0000, N'3 Series M340i Xdrive', N'car6.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'c8c01071-2e9f-48a4-9b8c-e5e297f9069c', N'832f8ddb-7ec4-4fd7-98ee-d10650409d04', CAST(N'2021-02-22T14:45:08.207' AS DateTime), CAST(N'2021-02-22T14:45:08.207' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 3000.0000, N'5 Series 530d M Sport', N'car7.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'c6d77de5-aa75-4011-8eb7-eaa2040c2495', N'8150fea8-4404-424a-bfc0-e5ba98a894f0', CAST(N'2021-03-12T13:51:48.700' AS DateTime), CAST(N'2021-03-12T13:51:48.700' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0, 460000.0000, N'A4 Premium Plus', N'Car3122021 15148 PM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'a4892b2d-b73e-48bc-8c20-ed1df8e80d9a', N'0977967f-71b6-4e53-958a-4cbf0e76b688', CAST(N'2021-03-10T12:27:53.290' AS DateTime), CAST(N'2021-03-10T12:27:53.290' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 1000000.0000, N'RSQ8 4.0 TFSI Quattro', N'Car3102021 122750 PM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'd2801221-cef4-4fcc-935a-f6b0065a3360', N'554937a2-5c1e-4c18-be08-0f723e08fe2d', CAST(N'2021-03-26T11:16:05.917' AS DateTime), CAST(N'2021-03-26T11:16:05.917' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 1270000.0000, N'7 Series 730Ld DPE Signature', N'Car3262021 111605 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'88614145-a77f-4d75-8602-f7528f60c1de', N'dceca9a3-0d69-40eb-b2fd-c887f33f7fbf', CAST(N'2021-03-26T11:01:37.427' AS DateTime), CAST(N'2021-03-26T11:01:37.427' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 3240000.0000, N'AUDI S5 x', N'Car3262021 110137 AM.jpg')
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name], [Image]) VALUES (N'0e423027-c45c-486f-86f5-fcb482c71d45', N'9355c897-7671-4ab8-885e-5341d4abe5ca', CAST(N'2021-02-22T14:42:09.880' AS DateTime), CAST(N'2021-02-22T14:42:09.547' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 7000.0000, N'X5 xDrive 30d xLine', N'car8.jpg')
GO
INSERT [dbo].[Cities] ([CityId], [StateId], [CityName]) VALUES (N'4840c530-7f97-4455-930a-002b30e8c13b', N'35b70a61-714a-449d-a520-2678b88296db', N'Vadodara')
INSERT [dbo].[Cities] ([CityId], [StateId], [CityName]) VALUES (N'02a68be8-fb5b-4dc7-8fa2-9ae9b9c92560', N'35b70a61-714a-449d-a520-2678b88296db', N'Ahmedabad')
INSERT [dbo].[Cities] ([CityId], [StateId], [CityName]) VALUES (N'7601ac0d-4010-47cf-8f86-d2754cdeed41', N'35b70a61-714a-449d-a520-2678b88296db', N'Gandhinagar')
GO
INSERT [dbo].[ContactUs] ([Id], [Name], [Email], [Query]) VALUES (N'92fc8b28-7a0c-474b-8f7a-2a0c04e9305f', N'Saurabh singh', N'ss520553@gmail.com', N'Best')
INSERT [dbo].[ContactUs] ([Id], [Name], [Email], [Query]) VALUES (N'd5a43c9a-2e54-45da-8a8a-362f0fd85025', N'Saurabh singh', N'ss520553@gmail.com', N'why the problem occurs')
INSERT [dbo].[ContactUs] ([Id], [Name], [Email], [Query]) VALUES (N'c7995745-9127-4bc9-8330-ac09d608b5ec', N'Viren nanda', N'ss520553@gmail.com', N'why the problem occurs')
INSERT [dbo].[ContactUs] ([Id], [Name], [Email], [Query]) VALUES (N'456808c3-68d9-4fba-93cc-df3c03a426d5', N'amit', N'saurabh.singh@thegatewaycorp.co.in', N'Where to buy new cars?')
INSERT [dbo].[ContactUs] ([Id], [Name], [Email], [Query]) VALUES (N'0d3b071c-9a57-4515-aa54-e722b3a54200', N'Saurabh singh', N'ss520553@gmail.com', N'Best')
GO
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (N'bb300cee-8c5f-4a52-b5ba-304f094f9e15', N'India')
GO
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [CountryId]) VALUES (N'f210d047-9a6e-4e32-8430-ae7abce4bea1', N'INR', N'bb300cee-8c5f-4a52-b5ba-304f094f9e15')
GO
INSERT [dbo].[Dealers] ([DealerId], [Name], [AddressId], [ContactNo], [IsVerified], [VerifiedBy], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'Darshit', N'2fc1c655-c7af-4926-9659-dc389264a3e8', N'132456789', 1, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', NULL, NULL, NULL, NULL, 0, 0)
GO
INSERT [dbo].[FAQs] ([FaqId], [Question], [Answer], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'869cc59c-881b-42f7-8ad1-0da3cfcd7ea4', N'How many checks are carried out?', N'Our professionally trained and qualified engineers carry out 217 checks on each car & certify cars which meet or are refurbished to our certification criteria. We also check all owner details and documents to ensure genuineness.Sample Condition Report', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'869cc59c-881b-42f7-8ad1-0da3cfcd7ea4', NULL, NULL, 0, 0)
INSERT [dbo].[FAQs] ([FaqId], [Question], [Answer], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'4438ebb3-7471-429a-b0fd-6c5ba0dd7c53', N'Are the cars accident free?', N'Yes, only accident free cars are Trustmark certified. A car is termed as accidental when during a crash, the main structure of the car (chassis, - front door pillar, central pillar, rear pillar, floor pan or front cross) gets damaged.', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bdcf4eb9-4ee0-4291-aee8-d28e165ae4c6', NULL, NULL, 0, 0)
INSERT [dbo].[FAQs] ([FaqId], [Question], [Answer], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'35d9a99e-2e8c-4af8-9b89-df65bea5a638', N'Do you give a guarantee on odometer?', N'We don''t offer any guarantee on the odometer. Our Engineers check odometer for tampering if any and verify vehicle service history records as well and only upon satisfaction the TrustMark certification is given.', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'07adb1cc-9bb5-430c-85cb-66818f9fed7e', NULL, NULL, 0, 0)
INSERT [dbo].[FAQs] ([FaqId], [Question], [Answer], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'f66488cc-bbb6-4e4e-9954-dfbcad3c0010', N'Where should I go if I have a problem?', N'In the event of a problem please call our Helpline number at 1800 103 9088.', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'35d9a99e-2e8c-4af8-9b89-df65bea5a638', NULL, NULL, 0, 0)
GO
INSERT [dbo].[Feedback] ([FeedbackId], [Name], [CategoryId], [Description]) VALUES (N'44e3404c-7f6e-4723-bbc1-3610ca471885', N'ramana', N'31acae95-e9cd-4b03-8ff4-e1bb7007ad65', N'best one')
INSERT [dbo].[Feedback] ([FeedbackId], [Name], [CategoryId], [Description]) VALUES (N'0e97bf9d-b4d1-4e46-ac91-44819fe2678e', N'Raj Rana', N'fd06527b-6ad0-4b09-8a3c-2acb3bf2c819', N'FeedBack Testing')
INSERT [dbo].[Feedback] ([FeedbackId], [Name], [CategoryId], [Description]) VALUES (N'9e4e1ca0-0bfb-4a82-a655-95856e010e22', N'Viren nanda', N'31acae95-e9cd-4b03-8ff4-e1bb7007ad65', N'best one')
INSERT [dbo].[Feedback] ([FeedbackId], [Name], [CategoryId], [Description]) VALUES (N'4fd3a534-95b6-4e12-a5b3-97e2b06667a3', N'Saurabh singh', N'31acae95-e9cd-4b03-8ff4-e1bb7007ad65', N'best one')
INSERT [dbo].[Feedback] ([FeedbackId], [Name], [CategoryId], [Description]) VALUES (N'4a130944-02fa-4df9-9a86-c042f2cd1c23', N'amit', N'553666af-7988-490d-9d78-ef597937897f', N'Very good')
GO
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'fd06527b-6ad0-4b09-8a3c-2acb3bf2c819', N'Renting')
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'ce5b19bd-b3a1-4a46-93a0-5da37305c341', N'Subscribing')
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'b932f5e1-d0e5-49c1-80a2-75c05f6153f3', N'Website')
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'43c2d7cf-5c22-4bda-b623-ca428a6b8174', N'Service')
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'f9bfaae6-4c20-4a0b-a1b2-d38f47e04614', N'Others')
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'31acae95-e9cd-4b03-8ff4-e1bb7007ad65', N'Buy a new car')
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'553666af-7988-490d-9d78-ef597937897f', N'Buy a used car')
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'64849395-33d2-4147-8995-0097de71f5df', N'tok_1IUoU4LfHfDp45guT0bbFQNm', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'8afd8ba9-1005-4f27-9023-11cbd37d3f12', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'384c32bb-0919-469b-918b-1a350dc20720', N'tok_1IZDBoLfHfDp45guskfdUvAM', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'bda21923-3068-4123-8ab4-1d6d6a2aa4fb', N'tok_1IU60HLfHfDp45guobGIY3cF', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'39e99942-55f9-4a20-a167-223252143717', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'dbb5656b-f63d-4a90-8e6a-263f9badb85e', N'tok_1IU5ndLfHfDp45guwGPni3Vd', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'c0d515d2-bf9c-4144-acdb-271cff3e1edc', N'tok_1IU5j7LfHfDp45gus5h7pLfm', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'c9f9ee91-5b08-4889-bde7-2c474bea66ee', N'tok_1IU5ycLfHfDp45gulHTmQ25W', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'70ee45ae-b86f-4b4e-8193-2c977d4d818c', N'tok_1IUpCaLfHfDp45guGvqeZnNr', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'2e5ebb63-7b2c-44c2-afba-2e1908dfb463', N'tok_1IU5zWLfHfDp45guHvTIJHtp', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'f8607529-42eb-4b05-b61c-2fb5d01875af', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'cbaa08cf-0488-4f20-a477-30ea19b74424', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'08d82ed4-b9a6-41bb-a6d8-34e639fad5dd', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'01396586-3e13-42e3-8e15-3a82251c0722', N'tok_1IU60HLfHfDp45guobGIY3cF', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'e1960970-beb3-4e2b-83a1-3eb591e8082a', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'fea3d470-5292-4342-b322-427aaafacfd7', N'tok_1ISbkxLfHfDp45gu6AoMUnpc', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'7ec0f597-81ab-4083-aa48-49b55e71108a', N'tok_1IZIR6LfHfDp45guRkRM6oFM', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'6680e0da-8597-4729-a516-4ba49408e44b', N'tok_1IU5pKLfHfDp45guzTbzn4g9', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'4b490c00-ec89-428b-be9b-4d740a96a36c', N'tok_1IU69gLfHfDp45guZ9XND5pM', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'd2309e5f-8dbf-4519-a32e-508951557087', N'tok_1IRvFwLfHfDp45guTybFngxN', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'34bf2706-79c8-4964-b80f-51162052ad48', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'8ecea72d-8665-4d41-bd47-58852dfb0746', N'tok_1IUpC2LfHfDp45guEOOgB2cc', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'90c25f61-fd5c-4434-a907-61f29fae3513', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'fd09d1de-b969-46e7-9947-6445e7fa619d', N'tok_1ITQTPLfHfDp45gu37cglKQ0', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'3ffe5f6d-0dbe-4fdd-b623-691536d6c289', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'ccb616bd-6064-488f-84ba-69cc62f7e704', N'tok_1IU5puLfHfDp45guZxONEta8', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'b0ebffc7-5ec0-402c-bacd-6f6f2dbae806', N'tok_1IU6DyLfHfDp45gu9havO62z', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'b2bc1c85-ab81-43f6-a0cf-7d140007f696', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'748d3040-9147-4b96-9701-83ad8b754ea5', N'tok_1IZHfyLfHfDp45gu5SSWdzgS', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'5a7989e4-58b9-4179-86f2-8a4d317d2563', N'tok_1IU5v1LfHfDp45gulCFEj1Nr', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'24694217-d3d9-4fc5-9eab-8a9b8e50d4de', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'ba0f148b-3a59-49dd-a807-8b0aa1130bdd', N'tok_1IU6HoLfHfDp45guPD3oJZan', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'72f76ee5-45db-40de-8eb3-90e3ce12c242', N'tok_1IZD0hLfHfDp45guqdGjFiUt', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'17ba9edc-6442-49ab-918b-9b9b288fb340', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'01799a80-3804-4299-98cf-9f0ac0b11293', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'7ad638ce-4ddf-4b60-b084-a3b758785fcc', N'tok_1IU5uPLfHfDp45gu1y7N5jDK', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'720adb01-4485-41b7-9956-aa2238143e7b', N'tok_1IUoVDLfHfDp45gu7CYgJNxS', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'c3ab966f-b80b-40e4-9207-ae127c5ff11a', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'4400192e-5b62-4d16-893d-ae5dec0689c8', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'7a27b87c-d8c3-49a4-8a17-aea87b3025d3', N'tok_1IZIPoLfHfDp45gulXDfGfm3', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'015f3c99-1df9-46e5-b23b-b3216e54006e', N'tok_1IS4smLfHfDp45gu8nu41tqM', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'7d71a574-9607-4dee-9abc-be81a42925f4', N'tok_1IU72XLfHfDp45gumrq7pSHn', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'74f6c930-c2b7-4d90-b106-c4d825fbb439', N'tok_1ISbB5LfHfDp45guoqsOKQBE', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'db45dc5c-239b-44eb-bb49-c6eaba053768', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'c0a904cb-f65a-4100-b7b1-c947703ef558', N'tok_1IU60HLfHfDp45guobGIY3cF', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'290ca72b-c965-45a1-ae64-ca4961503b5e', N'tok_1IZD1vLfHfDp45guBUBd2i0e', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'02db47a1-996d-4e01-831a-d90ac7bcd73c', N'tok_1IZHfdLfHfDp45guK9BJMQxN', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'f5523023-f952-4e83-8194-da0cde750826', N'tok_1ITNqKLfHfDp45guXiguYTUO', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'0166782c-5156-43da-9389-da92815901d5', N'tok_1ISbbLLfHfDp45guFunDkE0n', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'15537207-7002-490e-8aad-dc10e5a270ae', N'tok_1IUlmCLfHfDp45gu7ZlaoOup', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'5b9190cd-d722-4242-9d97-dcbf2adfa652', N'tok_1ISiG9LfHfDp45guIGDUTHyP', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'dcb30be8-d4e7-4ede-9fad-ddf36ae22d4f', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'a08c1950-8141-413e-ba25-deb77d5318a7', N'tok_1ITQLFLfHfDp45guaT1PFVXR', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'86d77fb5-16de-406e-99ce-ef93e8a2c3b1', N'tok_1IU65sLfHfDp45guRWeruZAO', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'4aec2bac-46f6-44ec-a681-f082eae088cd', N'tok_1IZEvMLfHfDp45gu0zKfuQCk', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'23c2b3bb-8624-4009-a801-f09689e15e0a', N'tok_1IU6GVLfHfDp45guyjXuvFf0', 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'b9a6a0bc-ba62-43be-a1a6-f5ac00cc1097', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[PaymentMethods] ([PaymentMethodId], [Name]) VALUES (N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'Card')
GO
INSERT [dbo].[Pincodes] ([PincodeId], [CityId], [Pincode]) VALUES (N'6ec4327c-e483-4970-884c-c8b99bb178c9', N'02a68be8-fb5b-4dc7-8fa2-9ae9b9c92560', 380004)
GO
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'bcfbf4d9-f57f-46c0-8e12-01b71f7885b1', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', NULL, N'nice', 4, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'88775c5e-1183-4dd8-a694-0be9f3ea3a25', N'0977967f-71b6-4e53-958a-4cbf0e76b688', NULL, N'Best', 5, N'Very Well Done', CAST(N'2021-03-14T10:28:35.223' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'a1bac6e7-9c7a-4ccb-bea7-1447db262aa3', N'0977967f-71b6-4e53-958a-4cbf0e76b688', NULL, N'Best', 4, N'Very Well Done', CAST(N'2021-03-14T13:04:35.177' AS DateTime), N'1f0326c4-e62e-42ef-8dd2-869af2ac9a46', N'12-12-2020', N'1f0326c4-e62e-42ef-8dd2-869af2ac9a46', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'a65df331-cec0-44fd-a4a5-1b9829032b18', N'8df20ac3-76ee-45a4-ad65-187bd272b1b6', NULL, N'good', 4, N'Very Well Done', CAST(N'2021-03-14T00:52:22.800' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'b0d654ff-7fb7-45f5-bcf9-1bc4cc1c0e34', N'8150fea8-4404-424a-bfc0-e5ba98a894f0', NULL, N'Best', 5, N'Very Well Done', CAST(N'2021-03-14T10:27:56.027' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'3cdb4b11-faf7-4345-b485-1d2582f33948', N'832f8ddb-7ec4-4fd7-98ee-d10650409d04', NULL, N'Best Car', 5, N'Very Well Done', CAST(N'2021-03-14T01:09:06.587' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'4a1d0bf8-3a35-4928-92e1-1ef894361862', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', NULL, N'nice', 5, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'862def36-63df-4dd2-abec-2205702681ab', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', NULL, N'good', 3, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'9417b2f6-e05a-4feb-8d3c-4628018b24fd', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', NULL, N'good', 5, N'Very Well Done', CAST(N'2021-03-14T13:05:59.573' AS DateTime), N'1f0326c4-e62e-42ef-8dd2-869af2ac9a46', N'12-12-2020', N'1f0326c4-e62e-42ef-8dd2-869af2ac9a46', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'539bcda6-b584-41f9-9291-4701d140450f', N'a5a7865d-3a29-4e30-87e7-28b896bb28e4', NULL, N'good', 4, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'31d3a0d6-8eed-404f-a283-529cbf986e70', N'9355c897-7671-4ab8-885e-5341d4abe5ca', NULL, N'Best Car', 5, N'Very Well Done', CAST(N'2021-03-14T13:50:26.713' AS DateTime), N'aa79767d-a78c-4847-a935-3f5ed925355c', N'12-12-2020', N'aa79767d-a78c-4847-a935-3f5ed925355c', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'659e4530-41f7-4e59-9096-56584593afd2', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', NULL, N'Best', 5, N'Very Well Done', CAST(N'2021-03-14T10:08:08.393' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'8baf44ce-028a-49e0-a849-6951a6914194', N'1bf034bb-1ec1-482b-8d5c-1bd9e6a0c53a', NULL, N'Best', 4, N'Very Well Done', CAST(N'2021-03-14T10:30:23.223' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'607adb7f-dfdf-4453-8286-719368c79f27', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', NULL, N'Wrost', 1, N'very bad', CAST(N'2021-03-14T10:12:51.670' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'9fc8e036-aa69-4892-afe6-76de14af9f48', N'd338e525-44bb-4ac8-84cd-c89869829d12', NULL, N'Best', 4, N'Very Well Done', CAST(N'2021-03-14T13:16:51.903' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'12-12-2020', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'7b5b5542-4b00-414e-9977-8e4c0adfc687', N'a5a7865d-3a29-4e30-87e7-28b896bb28e4', NULL, N'good', 2, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'bf7859e3-fa2c-47df-bc6d-9197bc26cacc', N'a5a7865d-3a29-4e30-87e7-28b896bb28e4', NULL, N'nice', 3, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'23717566-5938-49e8-8bc2-9e50826de2e1', N'1bf034bb-1ec1-482b-8d5c-1bd9e6a0c53a', NULL, N'best one', 4, N'good job', CAST(N'2021-03-26T17:04:42.430' AS DateTime), N'59716c6d-0f20-48b6-b79d-1c8cfad99f24', N'12-12-2020', N'59716c6d-0f20-48b6-b79d-1c8cfad99f24', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'228f2aee-f936-41c4-a4b4-a1e74af75780', N'832f8ddb-7ec4-4fd7-98ee-d10650409d04', NULL, N'Best', 4, N'Very Well Done', CAST(N'2021-03-14T01:10:38.907' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'b3516cba-e9f6-4602-890a-a218138b4428', N'8150fea8-4404-424a-bfc0-e5ba98a894f0', NULL, N'Best', 4, N'Very Well Done', CAST(N'2021-03-14T10:26:08.937' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'7467c76a-1ae1-42d6-a77d-a275980ed53a', N'8df20ac3-76ee-45a4-ad65-187bd272b1b6', NULL, N'good', 4, N'Very Well Done', CAST(N'2021-03-14T00:51:08.480' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'2fc66bbb-fed5-4297-bb07-bb3439a471e5', N'8150fea8-4404-424a-bfc0-e5ba98a894f0', NULL, N'Best', 5, N'Very Well Done', CAST(N'2021-03-14T10:26:39.113' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'553d8a79-d665-4a1b-8ef2-c191fffdd269', N'1bf034bb-1ec1-482b-8d5c-1bd9e6a0c53a', NULL, N'Best', 4, N'Very Well Done', CAST(N'2021-03-14T10:15:03.627' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'48d948d2-02ca-41c0-bd76-cd17463f6596', N'8df20ac3-76ee-45a4-ad65-187bd272b1b6', NULL, N'good', 4, N'Very Well Done', CAST(N'2021-03-14T01:14:27.413' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'adf2ebf6-43de-449a-b76c-d6675bf5988b', N'8df20ac3-76ee-45a4-ad65-187bd272b1b6', NULL, N'bad', 2, N'very bad', CAST(N'2021-03-14T01:08:02.213' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'12b20106-ce5e-4d38-87b0-e29f3b3209f7', N'1bf034bb-1ec1-482b-8d5c-1bd9e6a0c53a', NULL, N'Best', 5, N'very bad', CAST(N'2021-03-14T10:19:16.807' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'4b9e3dfa-32c6-420c-bc04-efd661051f4d', N'9355c897-7671-4ab8-885e-5341d4abe5ca', NULL, N'nice', 5, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'1c678058-2d1c-4f2a-8f22-f6cf3b53878d', N'8df20ac3-76ee-45a4-ad65-187bd272b1b6', NULL, N'bad', 3, N'very bad', CAST(N'2021-03-14T00:57:36.260' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'12-12-2020', N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0)
GO
INSERT [dbo].[States] ([StateId], [CountryId], [StateName]) VALUES (N'35b70a61-714a-449d-a520-2678b88296db', N'bb300cee-8c5f-4a52-b5ba-304f094f9e15', N'Gujarat')
GO
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'1b021dd1-24e9-4f6d-ada5-0a7c8e8d8ee7', N'Saloni@gmail.com', 0xB089CCAD0C458E9C57955A7AADDF1E0EAC11142350B3155AF8F3C037928BDB27, N'Saloni', N'9090909090', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-25T12:15:23.583' AS DateTime), NULL, NULL, NULL, 0, 0, N'User3252021 121523 PM.jpg', 0x3DD125A9247D295926757DE9D4C53EB544EB85134060503321BBD07A1B6B9B3C)
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'59716c6d-0f20-48b6-b79d-1c8cfad99f24', N'saurabh.singh@thegatewaycorp.co.in', 0xEC0F52F8617557CA97D85061194D3E2AF825B13898B2CC79CDC282AFB583C9A0, N'saurabh singh', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-26T16:03:59.000' AS DateTime), NULL, NULL, NULL, 0, 0, N'User3262021 40358 PM.jpg', 0x8A17B3F2507B10953B63D5A295F2F4FC41B8DEABB50E92D29081A55330D7899A)
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'8a4e40e4-1159-44e4-9707-2ea14b352d5c', N'ss520553@gmail.com', 0x3132333435360000000000000000000000000000000000000000000000000000, N'Saurabh singh', N'+919621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-07T00:57:29.693' AS DateTime), NULL, NULL, NULL, 0, 0, N'User07032021 125729 AM.jpg', NULL)
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'5309fb2f-a419-498f-994e-3604857d4ce6', N'ram@gmail.com', 0x3132333435360000000000000000000000000000000000000000000000000000, N'ram', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-04T15:54:54.707' AS DateTime), NULL, NULL, NULL, 0, 0, N'User342021 35454 PM.jpg', NULL)
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'aa79767d-a78c-4847-a935-3f5ed925355c', N'viren.nanda.01@gmail.com', 0xD2E1B82CF17D3CAA5165B1B10CC5162C32E9F9021DB6F7B23753701932719432, N'Viren Bhanushali', N'09621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-14T13:48:01.927' AS DateTime), NULL, NULL, NULL, 0, 0, N'User14032021 014801 PM.jpg', 0x9CAB01D703709E6BF6F380C653D5B305502E3E2A301CFF8F8AA5CBEE3D4ECAED)
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'b5fa32bd-e53f-45a3-8557-6a3729199f99', N'raju@gmail.com', 0x0D5820B56F1185738CD889525EEA696DC32580995B4A91AE8FE7D69461B2908A, N'raju singh', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-12T13:47:07.337' AS DateTime), NULL, CAST(N'2021-03-13T19:38:53.013' AS DateTime), N'b5fa32bd-e53f-45a3-8557-6a3729199f99', 0, 0, N'User13032021 073851 PM.jpg', 0xE4495AFE95A2425D87D7EB8B8549A164203DE7ADBB2700DF6DEFD00574C10D8B)
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'c2d94db4-081c-4c2d-bc71-6e3a94d32c8e', N'ram23@gmail.com', 0x3132333435360000000000000000000000000000000000000000000000000000, N'ram', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-04T15:54:54.707' AS DateTime), NULL, NULL, NULL, 0, 0, N'User342021 35454 PM.jpg', NULL)
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'c35d71ee-e229-44f6-b6f7-7de13435e32a', N'amit@gmail.com', 0xD414761EBAF885BE78E06FEDCA06F4F3E623B12822781A394516FAD66EC9200D, N'amit', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-12T13:20:09.320' AS DateTime), NULL, NULL, NULL, 0, 0, N'User3122021 12009 PM.jpg', 0x4E1EDA33285EB71C4BB3C682F5E77DF5F7129176C28AFEB150A7CDA59CA1F2AF)
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'1f0326c4-e62e-42ef-8dd2-869af2ac9a46', N'viren@gmail.com', 0xEF73E11CA34B3A9635D956E04646B46BAEF883B06AA36F6B8F13756DB01F973F, N'Viren Bhanushali', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-14T13:00:57.827' AS DateTime), NULL, CAST(N'2021-03-14T13:01:26.740' AS DateTime), N'1f0326c4-e62e-42ef-8dd2-869af2ac9a46', 0, 0, N'User14032021 010126 PM.jpg', 0x3B0AC69E248234995BC8783A86FE6AFCE5484BCB56FE7111EF7934243A08093B)
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'saurabh@gmail.com', 0x3132333435360000000000000000000000000000000000000000000000000000, N'Saurabh', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, NULL, NULL)
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'205e6213-3577-4b64-bee9-d1f7ad749804', N'raman@gmail.com', 0x52EA233550482FB4D618ADE6B10647401CA938840EBBA71B8920E6CB0DC001BE, N'raman', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-12T13:15:35.637' AS DateTime), NULL, NULL, NULL, 0, 0, N'User3122021 11535 PM.jpg', 0xD82C071BA04051D36331EA98702D9A40A58CD72C0E8BBC6B18011D6B73F69910)
INSERT [dbo].[Users] ([UserId], [Email], [HashPassword], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image], [PasswordSalt]) VALUES (N'2d39e7c0-97ad-4eda-be20-e75e2572d239', N'rutvikoop1@gmail.com', 0x3132333435360000000000000000000000000000000000000000000000000000, N'bharat', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-04T15:54:54.707' AS DateTime), NULL, NULL, NULL, 1, 0, N'User342021 35454 PM.jpg', NULL)
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_Addresses_AddressId]  DEFAULT (newid()) FOR [AddressId]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_PurchaseAddresses_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_Addresses_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Admin_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[CarPurchases] ADD  CONSTRAINT [DF_CarPurchases_CarPurchaseId]  DEFAULT (newid()) FOR [CarPurchaseId]
GO
ALTER TABLE [dbo].[CarPurchases] ADD  CONSTRAINT [DF_CarPurchases_IsFullPayment]  DEFAULT ((0)) FOR [IsFullPayment]
GO
ALTER TABLE [dbo].[CarPurchases] ADD  CONSTRAINT [DF_CarPurchases_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[CarPurchases] ADD  CONSTRAINT [DF_CarPurchases_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[CarRents] ADD  CONSTRAINT [DF_CarRents_IsPaymentDone]  DEFAULT ((0)) FOR [IsPaymentDone]
GO
ALTER TABLE [dbo].[CarRents] ADD  CONSTRAINT [DF_CarRents_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[CarRents] ADD  CONSTRAINT [DF_CarRents_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [DF_Cars_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [DF_Cars_ModifyAt]  DEFAULT (getdate()) FOR [ModifyAt]
GO
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [DF_Cars_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Cities] ADD  CONSTRAINT [DF_Cities_CityId]  DEFAULT (newid()) FOR [CityId]
GO
ALTER TABLE [dbo].[ContactUs] ADD  CONSTRAINT [DF_ContactUs_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Countries] ADD  CONSTRAINT [DF_Countries_CountryId]  DEFAULT (newid()) FOR [CountryId]
GO
ALTER TABLE [dbo].[Currencies] ADD  CONSTRAINT [DF_Currencies_CurrencyId]  DEFAULT (newid()) FOR [CurrencyId]
GO
ALTER TABLE [dbo].[Dealers] ADD  CONSTRAINT [DF_Dealers_DealerId]  DEFAULT (newid()) FOR [DealerId]
GO
ALTER TABLE [dbo].[Dealers] ADD  CONSTRAINT [DF_Dealers_IsVerified]  DEFAULT ((0)) FOR [IsVerified]
GO
ALTER TABLE [dbo].[Dealers] ADD  CONSTRAINT [DF_Dealers_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Dealers] ADD  CONSTRAINT [DF_Dealers_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[EMIs] ADD  CONSTRAINT [DF_EMIs_Isdeleted]  DEFAULT ((0)) FOR [Isdeleted]
GO
ALTER TABLE [dbo].[EMIs] ADD  CONSTRAINT [DF_EMIs_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[FAQs] ADD  CONSTRAINT [DF_FAQs_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[FAQs] ADD  CONSTRAINT [DF_FAQs_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Invoices] ADD  CONSTRAINT [DF_Invoices_Frequency]  DEFAULT ((0)) FOR [Frequency]
GO
ALTER TABLE [dbo].[Invoices] ADD  CONSTRAINT [DF_Invoices_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Offers] ADD  CONSTRAINT [DF_Offers_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Offers] ADD  CONSTRAINT [DF_Offers_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[PaymentMethods] ADD  CONSTRAINT [DF_PaymentMethods_PaymentMethodId]  DEFAULT (newid()) FOR [PaymentMethodId]
GO
ALTER TABLE [dbo].[Pincodes] ADD  CONSTRAINT [DF_Pincodes_PincodeId]  DEFAULT (newid()) FOR [PincodeId]
GO
ALTER TABLE [dbo].[Promo] ADD  CONSTRAINT [DF_Promo_Isdeleted]  DEFAULT ((0)) FOR [Isdeleted]
GO
ALTER TABLE [dbo].[Promo] ADD  CONSTRAINT [DF_Promo_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_ReviewId]  DEFAULT (newid()) FOR [ReviewId]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[States] ADD  CONSTRAINT [DF_States_StateId]  DEFAULT (newid()) FOR [StateId]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Points]  DEFAULT ((0)) FOR [Points]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Pincodes] FOREIGN KEY([PincodeId])
REFERENCES [dbo].[Pincodes] ([PincodeId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Pincodes]
GO
ALTER TABLE [dbo].[CarCategoryMapper]  WITH CHECK ADD  CONSTRAINT [FK_CarCategoryMapper_CarCategories] FOREIGN KEY([CarCategoryId])
REFERENCES [dbo].[CarCategories] ([Id])
GO
ALTER TABLE [dbo].[CarCategoryMapper] CHECK CONSTRAINT [FK_CarCategoryMapper_CarCategories]
GO
ALTER TABLE [dbo].[CarCategoryMapper]  WITH CHECK ADD  CONSTRAINT [FK_CarCategoryMapper_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[CarCategoryMapper] CHECK CONSTRAINT [FK_CarCategoryMapper_Cars]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Addresses]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_CarVarients] FOREIGN KEY([CarVarientId])
REFERENCES [dbo].[CarVarients] ([Id])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_CarVarients]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Currencies] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([CurrencyId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Currencies]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Dealers] FOREIGN KEY([DealerId])
REFERENCES [dbo].[Dealers] ([DealerId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Dealers]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_EMIs] FOREIGN KEY([EmiId])
REFERENCES [dbo].[EMIs] ([EmiId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_EMIs]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Invoices] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([InvoiceId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Invoices]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_PaymentMethods] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethods] ([PaymentMethodId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_PaymentMethods]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Promo] FOREIGN KEY([PromoId])
REFERENCES [dbo].[Promo] ([PromoId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Promo]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Users]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_Addresses] FOREIGN KEY([PickupPoint])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_Addresses]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_Addresses1] FOREIGN KEY([DropPoint])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_Addresses1]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_CarVarients] FOREIGN KEY([CarVarientId])
REFERENCES [dbo].[CarVarients] ([Id])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_CarVarients]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_Currencies] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([CurrencyId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_Currencies]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_Invoices] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([InvoiceId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_Invoices]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_PaymentMethods] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethods] ([PaymentMethodId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_PaymentMethods]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_Users]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Addresses]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_CarCategories] FOREIGN KEY([CarCategoryId])
REFERENCES [dbo].[CarCategories] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_CarCategories]
GO
ALTER TABLE [dbo].[CarVarients]  WITH CHECK ADD  CONSTRAINT [FK_CarVarients_Cars] FOREIGN KEY([carId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[CarVarients] CHECK CONSTRAINT [FK_CarVarients_Cars]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_States] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([StateId])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_States]
GO
ALTER TABLE [dbo].[Currencies]  WITH CHECK ADD  CONSTRAINT [FK_Currencies_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Currencies] CHECK CONSTRAINT [FK_Currencies_Countries]
GO
ALTER TABLE [dbo].[Dealers]  WITH CHECK ADD  CONSTRAINT [FK_Dealers_Addresses1] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Dealers] CHECK CONSTRAINT [FK_Dealers_Addresses1]
GO
ALTER TABLE [dbo].[Dealers]  WITH CHECK ADD  CONSTRAINT [FK_Dealers_Admin] FOREIGN KEY([VerifiedBy])
REFERENCES [dbo].[Admin] ([Id])
GO
ALTER TABLE [dbo].[Dealers] CHECK CONSTRAINT [FK_Dealers_Admin]
GO
ALTER TABLE [dbo].[EMIs]  WITH CHECK ADD  CONSTRAINT [FK_EMIs_Banks] FOREIGN KEY([BankId])
REFERENCES [dbo].[Banks] ([BankId])
GO
ALTER TABLE [dbo].[EMIs] CHECK CONSTRAINT [FK_EMIs_Banks]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_FeedbackCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[FeedbackCategory] ([Id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_FeedbackCategory]
GO
ALTER TABLE [dbo].[Pincodes]  WITH CHECK ADD  CONSTRAINT [FK_Pincodes_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
GO
ALTER TABLE [dbo].[Pincodes] CHECK CONSTRAINT [FK_Pincodes_Cities]
GO
ALTER TABLE [dbo].[Promo]  WITH CHECK ADD  CONSTRAINT [FK_Promo_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Promo] CHECK CONSTRAINT [FK_Promo_Users]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Cars]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Users]
GO
ALTER TABLE [dbo].[States]  WITH CHECK ADD  CONSTRAINT [FK_States_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[States] CHECK CONSTRAINT [FK_States_Countries]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Addresses]
GO
USE [master]
GO
ALTER DATABASE [MyCarDb] SET  READ_WRITE 
GO
