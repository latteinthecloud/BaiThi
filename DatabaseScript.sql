CREATE DATABASE QuanLySanPham;
GO

USE QuanLySanPham;
GO


CREATE TABLE Account (
    username NVARCHAR(50) PRIMARY KEY,
    password NVARCHAR(50) NOT NULL,
    role INT DEFAULT 1
);


CREATE TABLE Catalog (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CatalogCode NVARCHAR(50) NOT NULL,
    CatalogName NVARCHAR(100) NOT NULL
);


CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CatalogId INT FOREIGN KEY REFERENCES Catalog(Id),
    ProductCode NVARCHAR(50) NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    Picture NVARCHAR(255),
    UnitPrice DECIMAL(18, 2) NOT NULL
);

INSERT INTO Catalog (CatalogCode, CatalogName)
VALUES ('DM01', N'Điện Thoại'),
       ('DM02', N'Máy Tính'),
       ('DM03', N'Thời Trang'),
       ('DM04', N'Gia Dụng'),
       ('CAT113', N'Hàng Cháy Nổ');
INSERT INTO Product (CatalogId, ProductCode, ProductName, Picture, UnitPrice) VALUES
(1, 'PRO01', 'Samsung J7 Prime', 'PRO01.PNG', 10000000),
(1, 'PRO02', 'Iphone XI', 'PRO02.PNG', 3000000),
(2, 'PRO03', 'Dell Inspiron N3552', 'PRO03.PNG', 12000000),
(2, 'PRO04', 'Dell Inspiron N3467', 'PRO04.PNG', 13000000),
(2, 'PRO05', 'Acer AS A315-31-C8GB', 'PRO05.PNG', 9000000),
(3, 'PRO06', 'Áo dài', 'PRO06.PNG', 500000),
(3, 'PRO07', 'Xường Xám', 'PRO07.PNG', 420000),
(4, 'PRO08', 'Bàn', 'PRO08.PNG', 120000),
(4, 'PRO09', 'Ghế', 'PRO09.PNG', 65000),
(5, 'PRO10', 'Bình chữa cháy', 'PRO10.PNG', 90000),
(3, 'PRO11', 'Áo hầu gái', 'PRO11.PNG', 200000),
(4, 'PRO56', 'TEST12 - GIGACHAD', 'GIGACHAD.PNG', 156515),
(5, 'PRO69', 'TESTPRO - SIGMA', 'SIGMA.PNG', 6942000);
