CREATE TABLE Alumno (
	IDAlumno int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(max) NOT NULL,
	Apellido varchar(max) NOT NULL,
	Correo varchar(max) NOT NULL
);

CREATE TABLE Maestro (
	IDMaestro int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(max) NOT NULL,
	Apellido varchar(max) NOT NULL,
	Correo varchar(max) NOT NULL
);

CREATE TABLE Materia (
	IDMateria int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(max) NOT NULL,
	Descripcion varchar(max),
	Horario varchar(max)
);

CREATE TABLE DetalleCalif (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	IDMateria int NOT NULL,
	IDAlumno int NOT NULL,
	Calif1 float,
	Calif2 float,
	Calif3 float
);

CREATE TABLE DetalleMaestro (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	IDMateria int NOT NULL,
	IDMaestro int NOT NULL
);

INSERT INTO Alumno values
('Lorelai','Gilmore','lGilmore@gmail.com'),
('Logan','Huntzberger','lHuntzberger@gmail.com'),
('Paris','Geller','pGeller@gmail.com')

INSERT INTO Maestro values
('Max','Medina','mMedina@gmail.com'),
('Asher','Fleming','aFleming@gmail.com'),
('Straub','Hayden','sHayden@gmail.com')

INSERT INTO Materia values
('Historia','Historia','Lunes 8:00-9:00'),
('Literatura','Literatura','Martes 8:00-9:00'),
('Física','Física','Miercoles 8:00-9:00')

INSERT INTO DetalleCalif values
(1,1,0,0,0),
(1,2,0,0,0),
(1,3,0,0,0),
(2,1,0,0,0),
(2,2,0,0,0),
(2,3,0,0,0),
(3,1,0,0,0),
(3,2,0,0,0),
(3,3,0,0,0)

INSERT INTO DetalleMaestro values
(1,1),
(2,2),
(3,3)


Select * from Alumno
Select * from Maestro
Select * from Materia
Select * from DetalleCalif
Select * from DetalleMaestro


DROP TABLE Alumno
DROP TABLE Maestro
DROP TABLE Materia
DROP TABLE DetalleCalif
DROP TABLE DetalleMaestro