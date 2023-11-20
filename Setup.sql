--- Note Database 'master' is used

-- Create Tables and Constraints
CREATE TABLE Material(id int IDENTITY PRIMARY KEY NOT NULL, name VARCHAR(50));

CREATE TABLE MaterialStorage (id int IDENTITY PRIMARY KEY NOT NULL, Aisle int, Shelf int, MaterialId int, Quantity int,
CONSTRAINT FK_Material_MaterialStorage FOREIGN KEY (MaterialId)
REFERENCES Material(id) );



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

