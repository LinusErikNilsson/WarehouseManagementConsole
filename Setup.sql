--- Note Database 'master' is used

-- Create Tables and Constraints
CREATE TABLE Material(id int IDENTITY PRIMARY KEY NOT NULL, name VARCHAR(50));

CREATE TABLE MaterialStorage (id int IDENTITY PRIMARY KEY NOT NULL, Aisle int, Shelf int, MaterialId int, Quantity int,
CONSTRAINT FK_Material_MaterialStorage FOREIGN KEY (MaterialId)
REFERENCES Material(id) );

CREATE TABLE Product(Id int PRIMARY KEY NOT NULL IDENTITY, Name varchar(50));

CREATE TABLE ProductOrder(Id int IDENTITY PRIMARY KEY NOT NULL, 
	CustomerId varchar(50), 
	IsPacked bit NOT NULL,
	IsSent bit NOT NULL,
	IsDelivered bit NOT NULL);

CREATE TABLE ProductStorage(Id int PRIMARY KEY NOT NULL IDENTITY,
	Aisle VARCHAR(50),
	Shelf varchar(50),
	ProductName varchar(50),
	Quantity int);



-- Kopplingstabell MaterialToProduct
CREATE TABLE MaterialToProduct (
    ProductID int,
     MaterialID int,
     PRIMARY KEY (ProductId, MaterialID),
     FOREIGN KEY (ProductId) REFERENCES Product(Id),
     FOREIGN KEY (MaterialId) REFERENCES Material(Id));

---Kopplingstabell ProductToOrder
CREATE TABLE ProductToOrder(
    ProductId int,
    OrderId int,
    PRIMARY KEY (ProductId, OrderId),
    FOREIGN KEY (ProductId) REFERENCES Product(Id),
    FOREIGN KEY (OrderId) REFERENCES ProductOrder(Id));







--- Insert Data to tables
--Material
INSERT INTO Material(name)
VALUES('Stainless Steel');
INSERT INTO Material(name)
VALUES('Iron');
INSERT INTO Material(name)
VALUES('Copper');

--MaterialStorage
INSERT INTO MaterialStorage (Aisle, Shelf, MaterialId, Quantity)
VALUES(1,1,1,0);

--Product
INSERT INTO Product(Name)
VALUES('Stainless Nut');

