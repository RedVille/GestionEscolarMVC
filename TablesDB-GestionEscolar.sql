CREATE TABLE Alumno (
	IDAlumno int NOT NULL PRIMARY KEY,
	Nombre varchar(max) NOT NULL,
	Apellido varchar(max) NOT NULL,
	Correo varchar(max) NOT NULL
);

CREATE TABLE Maestro (
	IDMaestro int NOT NULL PRIMARY KEY,
	Nombre varchar(max) NOT NULL,
	Apellido varchar(max) NOT NULL,
	Correo varchar(max) NOT NULL
);

CREATE TABLE Materia (
	IDMateria int NOT NULL PRIMARY KEY,
	Nombre varchar(max) NOT NULL,
	Descripcion varchar(max),
	Horario varchar(max)
);

CREATE TABLE DetalleCalif (
	ID int NOT NULL PRIMARY KEY,
	IDMateria int NOT NULL,
	IDAlumno int NOT NULL,
	Calif1 float,
	Calif2 float,
	Calif3 float
);

CREATE TABLE DetalleMaestro (
	ID int NOT NULL PRIMARY KEY,
	IDMateria int NOT NULL,
	IDMaestro int NOT NULL
);

INSERT INTO Alumno values
(1,'Lorelai','Gilmore','lGilmore@gmail.com'),
(2,'Logan','Huntzberger','lHuntzberger@gmail.com'),
(3,'Paris','Geller','pGeller@gmail.com')

INSERT INTO Maestro values
(1,'Max','Medina','mMedina@gmail.com'),
(2,'Asher','Fleming','aFleming@gmail.com'),
(3,'Straub','Hayden','sHayden@gmail.com')

INSERT INTO Materia values
(1,'Historia','Historia','Lunes 8:00-9:00'),
(2,'Literatura','Literatura','Martes 8:00-9:00'),
(3,'Física','Física','Miercoles 8:00-9:00')

INSERT INTO DetalleCalif values
(1,1,1,0,0,0),
(2,1,2,0,0,0),
(3,1,3,0,0,0),
(4,2,1,0,0,0),
(5,2,2,0,0,0),
(6,2,3,0,0,0),
(7,3,1,0,0,0),
(8,3,2,0,0,0),
(9,3,3,0,0,0)

INSERT INTO DetalleMaestro values
(1,1,1),
(2,2,2),
(3,3,3)


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