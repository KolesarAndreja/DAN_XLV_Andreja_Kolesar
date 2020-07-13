IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'dbWarehouse')
CREATE DATABASE dbWarehouse;
GO
USE dbWarehouse
--dropping tables
IF OBJECT_ID('tblStoredProducts') IS NOT NULL 
DROP TABLE tblStoredProducts;
IF OBJECT_ID('tblProducts') IS NOT NULL 
DROP TABLE tblProduct;

IF OBJECT_ID('vwStoredProducts') IS NOT NULL
DROP VIEW vwStoredProducts;


CREATE TABLE tblProducts(
	productId INT PRIMARY KEY IDENTITY(1,1),
	productName VARCHAR(30) NOT NULL,
	code INT NOT NULL,
	quantity INT NOT NULL,
	price INT NOT NULL,
	stored BIT NOT NULL
	);
CREATE TABLE tblStoredProducts(
	storedId INT PRIMARY KEY IDENTITY(1,1),
	productId INT FOREIGN KEY REFERENCES tblProducts(productId)
);


GO
CREATE VIEW vwStoredProducts
as
select s.storedId, s.productId, p.productName, p.code, p.price, p.quantity
from tblProducts p
inner join tblStoredProducts s
on p.productId = s.productId

--GO
--INSERT INTO tblDishes(dishName, price)
--VALUES ('Capricciosa', 700), ('Hawai',750),('Spinaci',790),('Vegetariana',580),('Napolitana',730),('Siciliana',770),('Vesuivo',750);