USE [master]
GO
/****** Object:  Database [StudentRegisteration]    Script Date: 12/20/2021 10:19:26 PM ******/
CREATE DATABASE [StudentRegisteration]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentRegisteration', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\StudentRegisteration.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentRegisteration_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\StudentRegisteration_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [StudentRegisteration] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentRegisteration].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentRegisteration] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentRegisteration] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentRegisteration] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentRegisteration] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentRegisteration] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentRegisteration] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StudentRegisteration] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentRegisteration] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentRegisteration] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentRegisteration] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentRegisteration] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentRegisteration] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentRegisteration] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentRegisteration] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentRegisteration] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StudentRegisteration] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentRegisteration] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentRegisteration] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentRegisteration] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentRegisteration] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentRegisteration] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentRegisteration] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentRegisteration] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentRegisteration] SET  MULTI_USER 
GO
ALTER DATABASE [StudentRegisteration] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentRegisteration] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentRegisteration] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentRegisteration] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentRegisteration] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentRegisteration] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [StudentRegisteration] SET QUERY_STORE = OFF
GO
USE [StudentRegisteration]
GO
/****** Object:  Table [dbo].[DegreeGroup]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DegreeGroup](
	[GroupID] [int] IDENTITY(1,3) NOT NULL,
	[GroupName] [varchar](20) NULL,
	[GroupFees] [int] NULL,
	[Duration] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[allDegrees]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[allDegrees]
As
select* from DegreeGroup
GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[RegID] [int] NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[MotherName] [varchar](30) NULL,
	[FatherName] [varchar](30) NULL,
	[Gender] [varchar](10) NULL,
	[CurrentAddress] [nvarchar](50) NULL,
	[PermanentAddress] [nvarchar](50) NULL,
	[DOB] [datetime] NULL,
	[FatherCNIC] [int] NULL,
	[FatherNumber] [nvarchar](20) NULL,
	[MotherCNIC] [int] NULL,
	[MotherPhoneNumber] [nvarchar](20) NULL,
	[Age] [int] NULL,
	[Siblings] [int] NULL,
	[GroupID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[FatherNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[MotherPhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectsID] [int] IDENTITY(1,3) NOT NULL,
	[SubjectsList] [varchar](100) NULL,
	[GroupID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[allStudents]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[allStudents]
As
select Student.RegID,Student.FirstName,Student.LastName,Student.FatherName,Student.MotherName,Student.CurrentAddress,Student.DOB,Student.Age,DegreeGroup.GroupName,Subjects.SubjectsList From Student,Subjects,DegreeGroup
Where Student.GroupID=DegreeGroup.GroupID AND DegreeGroup.GroupID=Subjects.GroupID
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(1,3) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([GroupID])
REFERENCES [dbo].[DegreeGroup] ([GroupID])
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD FOREIGN KEY([GroupID])
REFERENCES [dbo].[DegreeGroup] ([GroupID])
GO
/****** Object:  StoredProcedure [dbo].[getDuration]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getDuration]
(@groupid int)
as begin
select Duration from DegreeGroup where GroupID=@groupid
end
GO
/****** Object:  StoredProcedure [dbo].[getFees]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getFees]
(@groupid int)
as begin
select GroupFees from DegreeGroup where GroupID=@groupid
end
GO
/****** Object:  StoredProcedure [dbo].[insertGroup]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertGroup]
(@RegID int, @groupid int
)
as
begin update Student Set GroupID=@groupid where RegID=@RegID
end
GO
/****** Object:  StoredProcedure [dbo].[sp_allDegrees]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_allDegrees]
As
Begin
select* from allDegrees
End
GO
/****** Object:  StoredProcedure [dbo].[sp_allStudents]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_allStudents]
As
Begin 
select* from allStudents 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteStudent]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_deleteStudent]
(@regid int)
as begin
Delete From Student where RegID=@regid
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getSubjects]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_getSubjects]
(@groupid int)
As
begin
select SubjectsList,SubjectsID from Subjects where GroupID=@groupid
end
GO
/****** Object:  StoredProcedure [dbo].[sp_insertStudent]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[sp_insertStudent]
 (@RegID int,@firstname varchar(30),@lastname varchar(30), @mothername varchar(30),@fathername varchar(30),@gender varchar(10),@currentaddress nvarchar(50),@permanentaddress nvarchar(50),@dob datetime,@fCNIC int,@fatherphone nvarchar(20),@mCnic int,@motherphone nvarchar(20),@age int,@siblings int)
As
Begin
Insert Into Student(RegID,FirstName,LastName,MotherName,FatherName,Gender,CurrentAddress,PermanentAddress,DOB,FatherCNIC,FatherNumber,MotherCNIC,MotherPhoneNumber,Age,Siblings) Values (@RegID,@firstname,@lastname, @mothername,@fathername,@gender ,@currentaddress ,@permanentaddress ,@dob ,@fCNIC ,@fatherphone ,@mCnic ,@motherphone,@age,@siblings)
End
GO
/****** Object:  StoredProcedure [dbo].[sp_login]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_login]
 (@UserName varchar(50),@Pass varchar(20))
 As
 BEGIN
 select * from [Admin] where Username=@UserName AND [Password]=@Pass
 END
GO
/****** Object:  StoredProcedure [dbo].[sp_searchStudent]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_searchStudent]
(@regid int)
as 
begin
select * from Student where RegID=@regid
end
GO
/****** Object:  StoredProcedure [dbo].[sp_updateStudent]    Script Date: 12/20/2021 10:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_updateStudent]
(@RegID int,@firstname varchar(30),@lastname varchar(30), @mothername varchar(30),@fathername varchar(30),@gender varchar(10),@currentaddress nvarchar(50),@permanentaddress nvarchar(50),@dob datetime,@fCNIC int,@fatherphone nvarchar(20),@mCnic int,@motherphone nvarchar(20),@age int,@siblings int)
As
Begin
update Student set FirstName=@firstname,LastName=@lastname,MotherName=@mothername,FatherName=@fathername,Gender=@gender,CurrentAddress=@currentaddress,PermanentAddress=@permanentaddress,DOB=@dob,FatherCNIC=@fCNIC,FatherNumber=@fatherphone,MotherCNIC=@mCnic,MotherPhoneNumber=@motherphone,Age=@age,Siblings=@siblings
where RegID=@RegID
End
GO
USE [master]
GO
ALTER DATABASE [StudentRegisteration] SET  READ_WRITE 
GO
