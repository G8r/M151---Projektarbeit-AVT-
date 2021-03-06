USE [master]
GO
/****** Object:  Database [AbsenzenDB]    Script Date: 20.05.2018 16:43:25 ******/
CREATE DATABASE [AbsenzenDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Person', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Person.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Person_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Person_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AbsenzenDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AbsenzenDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AbsenzenDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AbsenzenDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AbsenzenDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AbsenzenDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AbsenzenDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AbsenzenDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AbsenzenDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AbsenzenDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AbsenzenDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AbsenzenDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AbsenzenDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AbsenzenDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AbsenzenDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AbsenzenDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AbsenzenDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AbsenzenDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AbsenzenDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AbsenzenDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AbsenzenDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AbsenzenDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AbsenzenDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AbsenzenDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AbsenzenDB] SET RECOVERY FULL 
GO
ALTER DATABASE [AbsenzenDB] SET  MULTI_USER 
GO
ALTER DATABASE [AbsenzenDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AbsenzenDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AbsenzenDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AbsenzenDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AbsenzenDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AbsenzenDB', N'ON'
GO
ALTER DATABASE [AbsenzenDB] SET QUERY_STORE = OFF
GO
USE [AbsenzenDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [AbsenzenDB]
GO
/****** Object:  Table [dbo].[Absenz]    Script Date: 20.05.2018 16:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absenz](
	[absenz_id] [int] NOT NULL,
	[Datum] [date] NOT NULL,
	[Lektionen] [float] NOT NULL,
	[modul_id] [int] NOT NULL,
	[schueler_id] [int] NOT NULL,
 CONSTRAINT [PK_Absenz] PRIMARY KEY CLUSTERED 
(
	[absenz_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klasse]    Script Date: 20.05.2018 16:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klasse](
	[klasse_id] [int] NOT NULL,
	[Bezeichnung] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Klasse] PRIMARY KEY CLUSTERED 
(
	[klasse_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klasse_Lehrer]    Script Date: 20.05.2018 16:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klasse_Lehrer](
	[lehrer_id] [int] NOT NULL,
	[klasse_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lehrer]    Script Date: 20.05.2018 16:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lehrer](
	[lehrer_id] [int] NOT NULL,
	[Vorname] [nvarchar](max) NOT NULL,
	[Nachname] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Lehrer] PRIMARY KEY CLUSTERED 
(
	[lehrer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modul]    Script Date: 20.05.2018 16:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modul](
	[modul_id] [int] NOT NULL,
	[Bezeichnung] [nvarchar](max) NOT NULL,
	[lehrer_id] [int] NOT NULL,
 CONSTRAINT [PK_Modul] PRIMARY KEY CLUSTERED 
(
	[modul_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schueler]    Script Date: 20.05.2018 16:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schueler](
	[schueler_id] [int] NOT NULL,
	[Vorname] [nvarchar](max) NOT NULL,
	[Nachname] [nvarchar](max) NOT NULL,
	[klasse_id] [int] NOT NULL,
 CONSTRAINT [PK_Schueler] PRIMARY KEY CLUSTERED 
(
	[schueler_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Klasse] ([klasse_id], [Bezeichnung]) VALUES (1, N'INF15a    ')
INSERT [dbo].[Klasse] ([klasse_id], [Bezeichnung]) VALUES (2, N'INF15b    ')
INSERT [dbo].[Lehrer] ([lehrer_id], [Vorname], [Nachname]) VALUES (1, N'Patrick', N'Joller')
INSERT [dbo].[Lehrer] ([lehrer_id], [Vorname], [Nachname]) VALUES (2, N'Roland', N'Bucher')
INSERT [dbo].[Lehrer] ([lehrer_id], [Vorname], [Nachname]) VALUES (3, N'Reto', N'Faden')
INSERT [dbo].[Lehrer] ([lehrer_id], [Vorname], [Nachname]) VALUES (4, N'Steve', N'Richmond')
INSERT [dbo].[Lehrer] ([lehrer_id], [Vorname], [Nachname]) VALUES (5, N'Peter', N'Nyffenegger')
INSERT [dbo].[Lehrer] ([lehrer_id], [Vorname], [Nachname]) VALUES (6, N'Heinz', N'Roth')
INSERT [dbo].[Lehrer] ([lehrer_id], [Vorname], [Nachname]) VALUES (7, N'Patrick', N'Soder')
INSERT [dbo].[Lehrer] ([lehrer_id], [Vorname], [Nachname]) VALUES (8, N'Nadia', N'Stutz')
INSERT [dbo].[Modul] ([modul_id], [Bezeichnung], [lehrer_id]) VALUES (1, N'M151', 1)
INSERT [dbo].[Modul] ([modul_id], [Bezeichnung], [lehrer_id]) VALUES (2, N'ENG', 4)
INSERT [dbo].[Modul] ([modul_id], [Bezeichnung], [lehrer_id]) VALUES (3, N'SPO', 3)
INSERT [dbo].[Modul] ([modul_id], [Bezeichnung], [lehrer_id]) VALUES (4, N'M153', 5)
INSERT [dbo].[Modul] ([modul_id], [Bezeichnung], [lehrer_id]) VALUES (5, N'NWS', 6)
INSERT [dbo].[Schueler] ([schueler_id], [Vorname], [Nachname], [klasse_id]) VALUES (1, N'Simon', N'Baumeler', 1)
INSERT [dbo].[Schueler] ([schueler_id], [Vorname], [Nachname], [klasse_id]) VALUES (2, N'Luc', N'Bucher', 1)
INSERT [dbo].[Schueler] ([schueler_id], [Vorname], [Nachname], [klasse_id]) VALUES (3, N'Marco', N'Frautschi', 1)
INSERT [dbo].[Schueler] ([schueler_id], [Vorname], [Nachname], [klasse_id]) VALUES (4, N'Micha', N'Frei', 1)
INSERT [dbo].[Schueler] ([schueler_id], [Vorname], [Nachname], [klasse_id]) VALUES (5, N'Simon', N'Gander', 1)
INSERT [dbo].[Schueler] ([schueler_id], [Vorname], [Nachname], [klasse_id]) VALUES (6, N'Thomas', N'Gassmann', 1)
INSERT [dbo].[Schueler] ([schueler_id], [Vorname], [Nachname], [klasse_id]) VALUES (7, N'Raphael', N'Hochmut', 1)
INSERT [dbo].[Schueler] ([schueler_id], [Vorname], [Nachname], [klasse_id]) VALUES (8, N'Till', N'Kottmann', 1)
INSERT [dbo].[Schueler] ([schueler_id], [Vorname], [Nachname], [klasse_id]) VALUES (9, N'Mauro', N'Küpfer', 1)
INSERT [dbo].[Schueler] ([schueler_id], [Vorname], [Nachname], [klasse_id]) VALUES (10, N'Michael', N'Ottiger', 1)
INSERT [dbo].[Schueler] ([schueler_id], [Vorname], [Nachname], [klasse_id]) VALUES (11, N'Tim', N'Merz', 1)
ALTER TABLE [dbo].[Absenz]  WITH CHECK ADD  CONSTRAINT [FK_Absenz_Modul] FOREIGN KEY([modul_id])
REFERENCES [dbo].[Modul] ([modul_id])
GO
ALTER TABLE [dbo].[Absenz] CHECK CONSTRAINT [FK_Absenz_Modul]
GO
ALTER TABLE [dbo].[Absenz]  WITH CHECK ADD  CONSTRAINT [FK_Absenz_Schueler] FOREIGN KEY([schueler_id])
REFERENCES [dbo].[Schueler] ([schueler_id])
GO
ALTER TABLE [dbo].[Absenz] CHECK CONSTRAINT [FK_Absenz_Schueler]
GO
ALTER TABLE [dbo].[Klasse_Lehrer]  WITH CHECK ADD  CONSTRAINT [FK_Klasse] FOREIGN KEY([klasse_id])
REFERENCES [dbo].[Klasse] ([klasse_id])
GO
ALTER TABLE [dbo].[Klasse_Lehrer] CHECK CONSTRAINT [FK_Klasse]
GO
ALTER TABLE [dbo].[Klasse_Lehrer]  WITH CHECK ADD  CONSTRAINT [FK_Lehrer] FOREIGN KEY([lehrer_id])
REFERENCES [dbo].[Lehrer] ([lehrer_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Klasse_Lehrer] CHECK CONSTRAINT [FK_Lehrer]
GO
ALTER TABLE [dbo].[Modul]  WITH CHECK ADD  CONSTRAINT [FK_Modul_Lehrer] FOREIGN KEY([lehrer_id])
REFERENCES [dbo].[Lehrer] ([lehrer_id])
GO
ALTER TABLE [dbo].[Modul] CHECK CONSTRAINT [FK_Modul_Lehrer]
GO
ALTER TABLE [dbo].[Schueler]  WITH CHECK ADD  CONSTRAINT [FK_Schueler_Klasse] FOREIGN KEY([klasse_id])
REFERENCES [dbo].[Klasse] ([klasse_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Schueler] CHECK CONSTRAINT [FK_Schueler_Klasse]
GO
USE [master]
GO
ALTER DATABASE [AbsenzenDB] SET  READ_WRITE 
GO
