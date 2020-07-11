CREATE  DATABASE  MANAGER
GO
USE manager
create table Addmin
(
ad_ID int identity(1,1),
ad_username nvarchar(50),
ad_password nvarchar(50),
ad_fullname nvarchar(50),
task nvarchar(50),
)


create table Employee
(
em_ID int identity(1,1),
em_username nvarchar(50),
em_password nvarchar(50),
em_fullname nvarchar(50),
task nvarchar(50),
)
