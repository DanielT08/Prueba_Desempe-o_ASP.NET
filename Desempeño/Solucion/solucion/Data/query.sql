CREATE TABLE Owners(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(50),
    LastNames VARCHAR(50),
    Email VARCHAR(100) UNIQUE,
    Address VARCHAR(125),
    Phone VARCHAR(25)
);

CREATE TABLE Vets(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(120),
    Phone VARCHAR(25),
    Email VARCHAR(100) UNIQUE,
    Address VARCHAR(30)
);

CREATE TABLE Pets(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(25),
    Specie ENUM('Perro','Gato'),
    Race ENUM('Pitbull','Chiguagua','Criollo','Japones'),
    DateBirth DATE,
    OwnerId INT,
    FOREIGN KEY (OwnerId) REFERENCES Owners(Id),
    Photo TEXT
);

CREATE TABLE Quotes(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    PetId INT,
    VetId INT,
    Date DATETIME,
    FOREIGN KEY (PetId) REFERENCES Pets(Id),
    FOREIGN KEY (VetId) REFERENCES Vets(Id),
    Description TEXT
);

ALTER TABLE ``CHANGE Description Descripcion TEXT;


INSERT INTO Owners (Names, LastNames, Email, Address ,Phone ) VALUES
('Carlos', 'Gomez',  'carlos.gomez@mail.com', 'Calle 123','555-2345'),
('Ana', 'Martinez', 'ana.martinez@mail.com', 'Calle 456', '555-3456'),
('Luis', 'Hernandez',  'luis.hernandez@mail.com', 'Calle 789', '555-4567'),
('Laura', 'Lopez',  'laura.lopez@mail.com', 'Calle 101', '555-5678'),
('Pedro', 'Diaz',  'pedro.diaz@mail.com', 'Calle 102', '555-6789'),
('Marta', 'Perez',  'marta.perez@mail.com', 'Calle 103', '555-7890'),
('Andres', 'Jimenez',  'andres.jimenez@mail.com', 'Calle 104', '555-8901'),
('Lucia', 'Ramirez',  'lucia.ramirez@mail.com', 'Calle 105', '555-9012'),
('Miguel', 'Sanchez',  'miguel.sanchez@mail.com', 'Calle 106', '555-0123'),
('Sara', 'Fernandez',  'sara.fernandez@mail.com', 'Calle 107', '555-1234');

INSERT INTO Vets (Name, Phone, Email, Address) VALUES
('Dr. Juan', '955-5678','juan@gmail.com', 'Calle 109'),
('Dr. Lucho', '455-3452','lucho@gmail.com', 'Calle 110'),
('Dr. Cristian', '326-1614','cristian@gmail.com', 'Calle 111');

INSERT INTO Pets (Names, Specie, Race, DateBirth, OwnerId, Phono ) VALUES
('Toby', 'Perro', 'Chiguagua', '2024-05-13', 1,NULL),
('Rayo', 'Gato', 'Criollo', '2022-06-14', 2,NULL),
('Tumor', 'Perro', 'Pitbull', '2023-07-15', 3,NULL),
('Lana', 'Gato', 'Japones', '2021-08-16', 4,NULL),
('Pecas', 'Perro', 'Chiguagua', '2019-09-17', 5,NULL),
('Ximena', 'Gato', 'Criollo', '2020-10-18', 6,NULL),
('Negra', 'Perro', 'Pitbull', '2018-11-19', 7,NULL),
('Lulu', 'Gato', 'Japones', '2017-12-20', 8,NULL),
('Rocky', 'Perro', 'Chiguagua', '2016-01-21', 9,NULL),
('Bichota', 'Gato', 'Criollo', '2015-02-22', 10,NULL);

INSERT INTO Quotes (Date, PetId, VetId, Description) VALUES
(1, 1,'2023-06-01 10:00:00' , 'periodic review'  ),
(2, 3,'2023-06-02 11:00:00' , 'bathroom'  ),
(3, 2,'2023-06-03 12:00:00' , 'dewormer'  ),
(4, 4,'2023-06-04 13:00:00' , 'periodic review'  ),
(5, 1,'2023-06-05 14:00:00' , 'periodic review'  ),
(6, 2,'2023-06-06 15:00:00' , 'dewormer'  ),
(7, 3,'2023-06-07 16:00:00' , 'bathroom'  ), 
(8, 4,'2023-06-08 17:00:00' , 'periodic review'  ),
(9, 1,'2023-06-09 18:00:00' , 'dewormer'  ),
(10, 2,'2023-06-10 19:00:00' , 'bathroom'  );

