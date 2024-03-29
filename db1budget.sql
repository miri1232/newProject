USE [master]
GO
/****** Object:  Database [dbBudget]    Script Date: 29/01/2023 17:17:46 ******/
CREATE DATABASE [dbBudget]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbBudget', FILENAME = N'C:\אמא\פרוייקט סיכום\dbBudget.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbBudget_log', FILENAME = N'C:\אמא\פרוייקט סיכום\dbBudget.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbBudget] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbBudget].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbBudget] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [dbBudget] SET ANSI_NULLS ON 
GO
ALTER DATABASE [dbBudget] SET ANSI_PADDING ON 
GO
ALTER DATABASE [dbBudget] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [dbBudget] SET ARITHABORT ON 
GO
ALTER DATABASE [dbBudget] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbBudget] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbBudget] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbBudget] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbBudget] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [dbBudget] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [dbBudget] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbBudget] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [dbBudget] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbBudget] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbBudget] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbBudget] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbBudget] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbBudget] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbBudget] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbBudget] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbBudget] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbBudget] SET RECOVERY FULL 
GO
ALTER DATABASE [dbBudget] SET  MULTI_USER 
GO
ALTER DATABASE [dbBudget] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbBudget] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbBudget] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbBudget] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbBudget] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbBudget] SET QUERY_STORE = OFF
GO
USE [dbBudget]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [dbBudget]
GO
/****** Object:  Table [dbo].[bank]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bank](
	[Id] [int] NOT NULL,
	[name_bank] [nvarchar](20) NOT NULL,
	[link] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__bank__3214EC07B88EF05B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bank_of_budget]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank_of_budget](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBudget] [int] NOT NULL,
	[idBank] [int] NOT NULL,
 CONSTRAINT [PK_Bank_of_budget] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Budget]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Budget](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name_budget] [nvarchar](20) NOT NULL,
	[type] [int] NOT NULL,
	[manager] [varchar](9) NOT NULL,
 CONSTRAINT [PK__Budget__3214EC07E30A2511] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[detail] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category_income]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_income](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[detail] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Category_income] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expense]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expense](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idBudget] [int] NOT NULL,
	[date] [date] NOT NULL,
	[sum] [float] NOT NULL,
	[category] [int] NOT NULL,
	[subcategory] [int] NOT NULL,
	[detail] [nvarchar](50) NOT NULL,
	[payment_method] [int] NOT NULL,
	[frequency] [bit] NOT NULL,
	[number_of_payments] [int] NOT NULL,
	[status] [int] NOT NULL,
	[document] [image] NULL,
 CONSTRAINT [PK__Expenses__3214EC0733D330E8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Income]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Income](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idBudget] [int] NOT NULL,
	[date] [date] NOT NULL,
	[sum] [float] NOT NULL,
	[category_income] [int] NOT NULL,
	[source_of_income] [int] NOT NULL,
	[detail] [nvarchar](10) NOT NULL,
	[payment_method] [int] NOT NULL,
	[status] [int] NOT NULL,
	[document] [image] NULL,
 CONSTRAINT [PK__Incomes__3214EC07B4B7A014] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[subject] [nvarchar](15) NOT NULL,
	[details] [nvarchar](150) NOT NULL,
	[category] [nvarchar](15) NOT NULL,
	[idBank] [int] NULL,
	[eligibility_age] [date] NULL,
 CONSTRAINT [PK__Messages__3214EC07A4553A1F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages_for_user]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages_for_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [varchar](9) NOT NULL,
	[idMessages] [int] NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_Messages_for_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Number_payments]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Number_payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idExpenses] [int] NOT NULL,
	[date] [date] NOT NULL,
	[sum] [float] NOT NULL,
	[status] [nvarchar](10) NOT NULL,
	[detail] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK__Number_p__3214EC073E2143A7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_method]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_method](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[detail] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Payment_method] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [varchar](9) NOT NULL,
	[idBudget] [int] NOT NULL,
	[permission_level] [int] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionLevel]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_PermissionLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Source_of_income]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Source_of_income](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[category_income] [int] NOT NULL,
	[detail] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Source_of_income] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[detail] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subcategory]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subcategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[category] [int] NOT NULL,
	[detail] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Subcategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_budget]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_budget](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[detail] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 29/01/2023 17:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [varchar](9) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[password] [varchar](8) NOT NULL,
	[email] [varchar](30) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[date_birth] [date] NOT NULL,
 CONSTRAINT [PK__Users__3214EC0728838673] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Messages_for_user] ADD  CONSTRAINT [DF__Messages___statu__4D94879B]  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Bank_of_budget]  WITH CHECK ADD  CONSTRAINT [FK__Bank_of_b__idBan__30F848ED] FOREIGN KEY([idBank])
REFERENCES [dbo].[bank] ([Id])
GO
ALTER TABLE [dbo].[Bank_of_budget] CHECK CONSTRAINT [FK__Bank_of_b__idBan__30F848ED]
GO
ALTER TABLE [dbo].[Bank_of_budget]  WITH CHECK ADD  CONSTRAINT [FK__Bank_of_b__idBud__31EC6D26] FOREIGN KEY([idBudget])
REFERENCES [dbo].[Budget] ([Id])
GO
ALTER TABLE [dbo].[Bank_of_budget] CHECK CONSTRAINT [FK__Bank_of_b__idBud__31EC6D26]
GO
ALTER TABLE [dbo].[Budget]  WITH CHECK ADD  CONSTRAINT [FK_Budget_Type] FOREIGN KEY([type])
REFERENCES [dbo].[Type_budget] ([Id])
GO
ALTER TABLE [dbo].[Budget] CHECK CONSTRAINT [FK_Budget_Type]
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_Category] FOREIGN KEY([category])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_Category]
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_Payment_method] FOREIGN KEY([payment_method])
REFERENCES [dbo].[Payment_method] ([Id])
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_Payment_method]
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_Status] FOREIGN KEY([status])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_Status]
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_Subcategory] FOREIGN KEY([subcategory])
REFERENCES [dbo].[Subcategory] ([Id])
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_Subcategory]
GO
ALTER TABLE [dbo].[Income]  WITH CHECK ADD  CONSTRAINT [FK__Incomes__idBudge__37A5467C] FOREIGN KEY([idBudget])
REFERENCES [dbo].[Budget] ([Id])
GO
ALTER TABLE [dbo].[Income] CHECK CONSTRAINT [FK__Incomes__idBudge__37A5467C]
GO
ALTER TABLE [dbo].[Income]  WITH CHECK ADD  CONSTRAINT [FK_Income_Category_income] FOREIGN KEY([category_income])
REFERENCES [dbo].[Category_income] ([Id])
GO
ALTER TABLE [dbo].[Income] CHECK CONSTRAINT [FK_Income_Category_income]
GO
ALTER TABLE [dbo].[Income]  WITH CHECK ADD  CONSTRAINT [FK_Income_Payment_method] FOREIGN KEY([payment_method])
REFERENCES [dbo].[Payment_method] ([Id])
GO
ALTER TABLE [dbo].[Income] CHECK CONSTRAINT [FK_Income_Payment_method]
GO
ALTER TABLE [dbo].[Income]  WITH CHECK ADD  CONSTRAINT [FK_Income_Source_of_income] FOREIGN KEY([source_of_income])
REFERENCES [dbo].[Source_of_income] ([Id])
GO
ALTER TABLE [dbo].[Income] CHECK CONSTRAINT [FK_Income_Source_of_income]
GO
ALTER TABLE [dbo].[Income]  WITH CHECK ADD  CONSTRAINT [FK_Income_Status] FOREIGN KEY([status])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Income] CHECK CONSTRAINT [FK_Income_Status]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK__Messages__idBank__4AB81AF0] FOREIGN KEY([idBank])
REFERENCES [dbo].[bank] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK__Messages__idBank__4AB81AF0]
GO
ALTER TABLE [dbo].[Messages_for_user]  WITH CHECK ADD  CONSTRAINT [FK__Messages___idMes__4F7CD00D] FOREIGN KEY([idMessages])
REFERENCES [dbo].[Message] ([Id])
GO
ALTER TABLE [dbo].[Messages_for_user] CHECK CONSTRAINT [FK__Messages___idMes__4F7CD00D]
GO
ALTER TABLE [dbo].[Messages_for_user]  WITH CHECK ADD  CONSTRAINT [FK__Messages___idUse__4E88ABD4] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Messages_for_user] CHECK CONSTRAINT [FK__Messages___idUse__4E88ABD4]
GO
ALTER TABLE [dbo].[Number_payments]  WITH CHECK ADD  CONSTRAINT [FK__Number_pa__idExp__3E52440B] FOREIGN KEY([idExpenses])
REFERENCES [dbo].[Expense] ([Id])
GO
ALTER TABLE [dbo].[Number_payments] CHECK CONSTRAINT [FK__Number_pa__idExp__3E52440B]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK__Permissio__idUse__300424B4] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK__Permissio__idUse__300424B4]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Budget] FOREIGN KEY([idBudget])
REFERENCES [dbo].[Budget] ([Id])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Budget]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_PermissionLevel1] FOREIGN KEY([permission_level])
REFERENCES [dbo].[PermissionLevel] ([Id])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_PermissionLevel1]
GO
ALTER TABLE [dbo].[Source_of_income]  WITH CHECK ADD  CONSTRAINT [FK_Source_of_income_Category_income] FOREIGN KEY([category_income])
REFERENCES [dbo].[Category_income] ([Id])
GO
ALTER TABLE [dbo].[Source_of_income] CHECK CONSTRAINT [FK_Source_of_income_Category_income]
GO
ALTER TABLE [dbo].[Subcategory]  WITH CHECK ADD  CONSTRAINT [FK_Subcategory_Category] FOREIGN KEY([category])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Subcategory] CHECK CONSTRAINT [FK_Subcategory_Category]
GO
USE [master]
GO
ALTER DATABASE [dbBudget] SET  READ_WRITE 
GO
