﻿CREATE TABLE Users (
    Id int NOT NULL IDENTITY PRIMARY KEY,
    Email varchar(255) NOT NULL,
    Password varchar(255) NOT NULL,
    RegistrationDate date DEFAULT GETDATE()
);

CREATE TABLE Roles (
    Id int NOT NULL IDENTITY PRIMARY KEY,
    RoleName varchar(255) NOT NULL,
);

CREATE TABLE UserRoles (
    UserId int,
    RoleId int,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (RoleId) REFERENCES Roles(Id),
    CONSTRAINT PK_UserRoles PRIMARY KEY (UserId, RoleId)
);

CREATE TABLE Products (
    Id int NOT NULL IDENTITY PRIMARY KEY,
    Name varchar(255) NOT NULL,
    Description varchar(255),
    Price decimal NOT NULL
);



CREATE TABLE ShoppingCart (
    UserId int,
    ProductId int,
    Quantity int DEFAULT 1,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    CONSTRAINT PK_ShoppingCart PRIMARY KEY (UserId, ProductId)
);

INSERT INTO Users (Email, Password, RegistrationDate) VALUES ('oda@gmail.com', 'OdasPass123', '2020-1-20');
INSERT INTO Users (Email, Password, RegistrationDate) VALUES ('afton@gmail.com', 'AftonsPass123', '2020-1-20');
INSERT INTO Users (Email, Password, RegistrationDate) VALUES ('bibi@gmail.com', 'BibisPass123', '2017-4-6');
INSERT INTO Users (Email, Password, RegistrationDate) VALUES ('janett@gmail.com', 'JanettsPass123', '2015-10-15');
INSERT INTO Users (Email, Password, RegistrationDate) VALUES ('gary@gmail.com', 'GarysPass123', '2012-10-15');


INSERT INTO Roles (RoleName) VALUES ('Customer');
INSERT INTO Roles (RoleName) VALUES ('Employee');
INSERT INTO Roles (RoleName) VALUES ('Admin');

INSERT INTO UserRoles (UserId, RoleId) VALUES ((SELECT Id FROM Users WHERE Email = 'oda@gmail.com'), (SELECT Id FROM Roles WHERE RoleName = 'Customer'));
INSERT INTO UserRoles (UserId, RoleId) VALUES ((SELECT Id FROM Users WHERE Email = 'afton@gmail.com'), (SELECT Id FROM Roles WHERE RoleName = 'Customer'));
INSERT INTO UserRoles (UserId, RoleId) VALUES ((SELECT Id FROM Users WHERE Email = 'bibi@gmail.com'), (SELECT Id FROM Roles WHERE RoleName = 'Employee'));
INSERT INTO UserRoles (UserId, RoleId) VALUES ((SELECT Id FROM Users WHERE Email = 'janett@gmail.com'), (SELECT Id FROM Roles WHERE RoleName = 'Employee'));
INSERT INTO UserRoles (UserId, RoleId) VALUES ((SELECT Id FROM Users WHERE Email = 'gary@gmail.com'), (SELECT Id FROM Roles WHERE RoleName = 'Admin'));


INSERT INTO Products (Name, Description, Price) VALUES ('Gazelle 22272 T4 Pop-Up', ' A 90 second set-up and packs up into a 67.5 inch duffle bag. Spaciously sleep up to four people, standing 78 in tall.', 279.99);
INSERT INTO Products (Name, Description, Price) VALUES ('Freedom from the Known - Jiddu Krishnamurti', 'Krishnamurti shows how people can free themselves radically and immediately from the tyranny of the expected, no matter what their ageopening the door to transforming society and their relationships.', 14.99);
INSERT INTO Products (Name, Description, Price) VALUES ('Ball Mason Jar-32 oz.', 'CLASSIC BRAND: Ball Wide Mouth (32 oz.) Jars with Lid and Band', 8.85);
INSERT INTO Products (Name, Description, Price) VALUES ('Stellar Basic Flute Key of G - Native American Style Flute', 'The Basic G flute is our most popular key. It is small enough that most people can comfortably play it.', 127.50);
INSERT INTO Products (Name, Description, Price) VALUES ('Catan The Board Game', 'The incredibly popular, multi award winning civilization building board game of harvesting and trading resources', 43.67);
INSERT INTO Products (Name, Description, Price) VALUES ('Apple Watch Series 3', 'Fitness Tracker, Sleep Monitor, GPS, Pedometer, Heart Rate Monitor', 169.00);
INSERT INTO Products (Name, Description, Price) VALUES ('Nintendo Switch', 'Get the gaming system that lets you play the games you want, wherever you are, however you like.', 299.00);

INSERT INTO ShoppingCart (UserId, ProductId) VALUES ((SELECT Id FROM Users WHERE Email = 'oda@gmail.com'), 1);
INSERT INTO ShoppingCart (UserId, ProductId) VALUES ((SELECT Id FROM Users WHERE Email = 'oda@gmail.com'), 3);
INSERT INTO ShoppingCart (UserId, ProductId) VALUES ((SELECT Id FROM Users WHERE Email = 'oda@gmail.com'), 4);
INSERT INTO ShoppingCart (UserId, ProductId) VALUES ((SELECT Id FROM Users WHERE Email = 'oda@gmail.com'), 7);
INSERT INTO ShoppingCart (UserId, ProductId) VALUES ((SELECT Id FROM Users WHERE Email = 'afton@gmail.com'), 7);
INSERT INTO ShoppingCart (UserId, ProductId) VALUES ((SELECT Id FROM Users WHERE Email = 'afton@gmail.com'), 2);
INSERT INTO ShoppingCart (UserId, ProductId, Quantity) VALUES ((SELECT Id FROM Users WHERE Email = 'afton@gmail.com'), 3, 10);
INSERT INTO ShoppingCart (UserId, ProductId) VALUES ((SELECT Id FROM Users WHERE Email = 'afton@gmail.com'), 5);
INSERT INTO ShoppingCart (UserId, ProductId) VALUES ((SELECT Id FROM Users WHERE Email = 'janett@gmail.com'), 2);
INSERT INTO ShoppingCart (UserId, ProductId) VALUES ((SELECT Id FROM Users WHERE Email = 'janett@gmail.com'), 5);
INSERT INTO ShoppingCart (UserId, ProductId, Quantity) VALUES ((SELECT Id FROM Users WHERE Email = 'bibi@gmail.com'), 6, 5);