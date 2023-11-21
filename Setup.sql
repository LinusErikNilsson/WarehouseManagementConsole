--- Note Database 'master' is used

-- Create Tables and Constraints
CREATE TABLE Material(id int IDENTITY PRIMARY KEY NOT NULL, name VARCHAR(50));

CREATE TABLE MaterialStorage (id int IDENTITY PRIMARY KEY NOT NULL, 
    Aisle int, 
    Shelf int, 
    MaterialId int, 
    Quantity int,
    CONSTRAINT FK_Material_MaterialStorage FOREIGN KEY (MaterialId)
    REFERENCES Material(id) );

CREATE TABLE ProductionQueue (
    id int IDENTITY PRIMARY KEY NOT NULL,
	MaterialId int, 
	Quantity int,
    Priority int,
	CONSTRAINT FK_Material_ProductionQueue FOREIGN KEY (MaterialId)
	REFERENCES Material(id) );

CREATE TABLE Product(
    Id int PRIMARY KEY NOT NULL IDENTITY,
    Name varchar(50));

CREATE TABLE Customer(
    Id int IDENTITY PRIMARY KEY NOT NULL,
    Surname varchar(50),
    LastName varchar(50),
    Address varchar(50),
    Email varchar(50),
    Phonenumber varchar(50));

CREATE TABLE ProductOrder(
    Id int IDENTITY PRIMARY KEY NOT NULL, 
	CustomerId varchar(50), 
	IsPacked bit NOT NULL,
	IsSent bit NOT NULL,
	IsDelivered bit NOT NULL,
    CONSTRAINT FK_Product_ProductOrder FOREIGN KEY (CustomerID)
    REFERENCES Customer(Id) );

CREATE TABLE ProductStorage (
    id int IDENTITY PRIMARY KEY NOT NULL, 
    Aisle int, 
    Shelf int, 
    ProductId int, 
    Quantity int,
    CONSTRAINT FK_Product_ProductStorage FOREIGN KEY (ProductId)
    REFERENCES Product(Id) );

   CREATE TABLE ProductQueueForStorage(
    id int IDENTITY Primary KEY NOT NULL,
    ProductId int,
    Quantity int,
    CONSTRAINT FK_Product_ProductQueueForStorage FOREIGN KEY (ProductId)
    REFERENCES Product(Id) );


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

