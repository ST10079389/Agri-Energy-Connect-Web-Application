create database AgriEnergyWebsiteDB;
use AgriEnergyWebsiteDB;

create table Roles(
RoleID INT IDENTITY (1,1) PRIMARY KEY,
[Role] VARCHAR(30),
);

INSERT INTO Roles (Role)
VALUES ('Employee');

INSERT INTO Roles (Role)
VALUES ('Farmer');

create table Users(
UserID INT IDENTITY (1,1) PRIMARY KEY,
[Name] VARCHAR(30) NOT NULL,
[Password] VARCHAR(50) NOT NULL,
RoleID INT NOT NULL FOREIGN KEY REFERENCES Roles(RoleID)
);

INSERT INTO Users ([Name], [Password], RoleID)
VALUES ('Please Select Farmer', 'audirsq3', 2);

create table Category(
CategoryID INT IDENTITY (1,1) PRIMARY KEY,
[CategoryName] VARCHAR(50),
);

INSERT INTO Category ([CategoryName])
VALUES ('Please Select Category');


INSERT INTO Category ([CategoryName])
VALUES ('Carbohydrates');

INSERT INTO Category ([CategoryName])
VALUES ('Protein');

INSERT INTO Category ([CategoryName])
VALUES ('Dairy Products');

INSERT INTO Category ([CategoryName])
VALUES ('Fruits and Vegetables');

INSERT INTO Category ([CategoryName])
VALUES ('Fats and Sugars');

create table Products(
ProductID INT IDENTITY(1,1) PRIMARY KEY,
Product_Name VARCHAR(25) NOT NULL,
Production_Date DATE NOT NULL,
CategoryID INT NOT NULL FOREIGN KEY REFERENCES Category(CategoryID),
UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID)
);


SELECT * FROM Users

SELECT * FROM Roles

SELECT * FROM Category

SELECT * FROM Products
