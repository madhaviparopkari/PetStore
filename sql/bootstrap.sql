create database PetstoreDB;
create table Category(
             id int NOT NULL PRIMARY KEY, 
             name nvarchar(64) UNIQUE
             );
create table Pet (
             id int NOT NULL PRIMARY KEY , 
             name nvarchar(64), status nvarchar(32), 
             category_id int FOREIGN KEY REFERENCES Category(id)
             );
--DROP table [dbo].[Pet];
create table Tag(
             id int NOT NULL PRIMARY KEY, 
             name nvarchar(64) UNIQUE
             );
create table Pet_Tag_Mapping(
             id int NOT NULL PRIMARY KEY, 
             pet_id int FOREIGN KEY REFERENCES Pet(id) NOT NULL, 
             tag_id int FOREIGN KEY REFERENCES Tag(id) NOT NULL
             );
create table Customer(
             id int NOT NULL PRIMARY KEY, 
             username nvarchar(64) UNIQUE NOT NULL,
             password nvarchar(64) UNIQUE NOT NULL,
             firstname  nvarchar(64),
             lastname nvarchar(64),
             email nvarchar(128) UNIQUE NOT NULL, 
             phone nvarchar(16) UNIQUE NOT NULL,
             status int
             );
create table Invoice_Status(
            id int PRIMARY KEY NOT NULL,
            name nvarchar(64) UNIQUE NOT NULL
            );
create table Invoice(
            id int PRIMARY KEY NOT NULL, 
            invoice_date DATETIME NOT NULL, 
            status_id int FOREIGN KEY REFERENCES Invoice_Status(id) NOT NULL,
            customer_id int FOREIGN KEY REFERENCES Customer(id) NOT NULL, 
            ship_date DATETIME NOT NULL, 
            delivery_date DATETIME NOT NULL, 
            shipping_address nvarchar(250) NOT NULL,
            );
-- This table is no longer needed since pet to invoice is one to many mapping.
-- i.e. One pet can be only on one invoice but one invoice can have many pets.            
-- create table Pet_Invoice_Mapping(
--             id int NOT NULL PRIMARY KEY, 
--             pet_id int FOREIGN KEY REFERENCES Pet(id) NOT NULL,
--             invoice_id int FOREIGN KEY REFERENCES Invoice(id) NOT NULL
--             );
DROP TABLE IF EXISTS [dbo].[Pet_Invoice_Mapping];

ALTER TABLE [dbo].[Pet]
ADD invoice_id int FOREIGN KEY REFERENCES [dbo].[Invoice](id); 


