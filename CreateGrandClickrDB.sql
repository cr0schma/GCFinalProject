-- 1.
Create Database GrandClickr
Go

USE [GrandClickr]

-- 2.
Create Table UserName (
		Id int IDENTITY (1,1) Primary Key,
		UserName nvarchar(50),
		Email nvarchar(50)
);

Create Table Secrets (
		UserId int Foreign Key References UserName(Id),
		Password nvarchar(50)
);

-- 3.
Insert Into UserName
Values ('Andrew', 'andrew@doesnot.exist'),
('Amanda', 'amanda@doesnot.exist'),
('Chris', 'chris@doesnot.exist');

Insert Into Secrets
Values (1, 'password1'),
(2, 'password2'),
(3, 'password3');
