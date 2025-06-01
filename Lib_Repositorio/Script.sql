CREATE DATABASE db_SegundaEntregaCinema;
GO

USE db_SegundaEntregaCinema;
GO

CREATE TABLE [Peliculas](
[Id] INT NOT NULL IDENTITY (1,1)PRIMARY KEY,
[Nombre] NVARCHAR (150) NOT NULL, 
[Tipo] NVARCHAR (150) NOT NULL
);
INSERT INTO [Peliculas]([Nombre],[Tipo]) VALUES ('Interestelar', 'Sci-fi');
INSERT INTO [Peliculas]([Nombre],[Tipo]) VALUES ('Rey león', 'Infantil');
INSERT INTO [Peliculas]([Nombre],[Tipo]) VALUES ('La sustancia', 'Terror corporal');
INSERT INTO [Peliculas]([Nombre],[Tipo]) VALUES ('Capitán America', 'Superheroes');
INSERT INTO [Peliculas]([Nombre],[Tipo]) VALUES ('Moana', 'Infantil');
SELECT * FROM [Peliculas];


CREATE TABLE [Sedes](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Nombre] NVARCHAR (150) NOT NULL
);
INSERT INTO [Sedes]([Nombre]) VALUES ('Fabricato');
INSERT INTO [Sedes]([Nombre]) VALUES ('El Tesoro');
INSERT INTO [Sedes]([Nombre]) VALUES ('La Central');
INSERT INTO [Sedes]([Nombre]) VALUES ('Florida');
INSERT INTO [Sedes]([Nombre]) VALUES ('Arkadia');
SELECT * FROM [Sedes];

CREATE TABLE [Salas](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Numero] INT NOT NULL,
[Asiento]NVARCHAR (150) NOT NULL
);
INSERT INTO [Salas]([Numero],[Asiento]) VALUES (15, 'G1');
INSERT INTO [Salas]([Numero],[Asiento]) VALUES (3, 'H3');
INSERT INTO [Salas]([Numero],[Asiento]) VALUES (3, 'H4');
INSERT INTO [Salas]([Numero],[Asiento]) VALUES (11, 'I2');
INSERT INTO [Salas]([Numero],[Asiento]) VALUES (6, 'J4');
INSERT INTO [Salas]([Numero],[Asiento]) VALUES (12, 'K7');
INSERT INTO [Salas]([Numero],[Asiento]) VALUES (12, 'K8');
SELECT * FROM [Salas];

CREATE TABLE [Empleados](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Carnet] NVARCHAR (150) NOT NULL,
[Nombre] NVARCHAR (150) NOT NULL
);
INSERT INTO [Empleados]([Carnet],[Nombre]) VALUES ('EMP1', 'EMILY');
INSERT INTO [Empleados]([Carnet],[Nombre]) VALUES ('EMP2', 'CARLOS');
INSERT INTO [Empleados]([Carnet],[Nombre]) VALUES ('EMP3', 'SOFIA');
INSERT INTO [Empleados]([Carnet],[Nombre]) VALUES ('EMP4', 'ANDRES');
INSERT INTO [Empleados]([Carnet],[Nombre]) VALUES ('EMP5', 'CRISTIAN');
INSERT INTO [Empleados]([Carnet],[Nombre]) VALUES ('EMP6', 'SARA');
SELECT * FROM [Empleados];

CREATE TABLE [Planes](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Nombre] NVARCHAR (150) NOT NULL,
[Detalles] INT NOT NULL
);
INSERT INTO [Planes]([Nombre],[Detalles]) VALUES ('Premium', 50);
INSERT INTO [Planes]([Nombre],[Detalles]) VALUES ('Basic', 15);
INSERT INTO [Planes]([Nombre],[Detalles]) VALUES ('Preferencial', 30);
SELECT * FROM [Planes];

CREATE TABLE [Snacks](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Nombre_Snacks] NVARCHAR (150) NOT NULL,
[Precio] INT NOT NULL
);
INSERT INTO [Snacks]([Nombre_Snacks],[Precio]) VALUES ('Combo Clasico', 30.000);
INSERT INTO [Snacks]([Nombre_Snacks],[Precio]) VALUES ('Combo Duo', 60.000);
INSERT INTO [Snacks]([Nombre_Snacks],[Precio]) VALUES ('Crispetas Medianas', 15.000);
INSERT INTO [Snacks]([Nombre_Snacks],[Precio]) VALUES ('Combo Capitan America', 65.000);
INSERT INTO [Snacks]([Nombre_Snacks],[Precio]) VALUES ('Ice-Crispetas Pequeñas', 20.000);
INSERT INTO [Snacks]([Nombre_Snacks],[Precio]) VALUES ('Dogger', 11.000);
SELECT * FROM [Snacks];

CREATE TABLE [Clientes](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[DNI] NVARCHAR (150) NOT NULL,
[Nombre] NVARCHAR (150) NOT NULL
);
INSERT INTO [Clientes]([DNI],[Nombre]) VALUES ('AZ', 'CAMILO');
INSERT INTO [Clientes]([DNI],[Nombre]) VALUES ('BY', 'JUAN');
INSERT INTO [Clientes]([DNI],[Nombre]) VALUES ('CX', 'SANTIAGO');
INSERT INTO [Clientes]([DNI],[Nombre]) VALUES ('DW', 'SEBASTIAN');
INSERT INTO [Clientes]([DNI],[Nombre]) VALUES ('EV', 'ANDREA');
INSERT INTO [Clientes]([DNI],[Nombre]) VALUES ('FU', 'ESTELLA');
SELECT * FROM [Clientes];



CREATE TABLE [Salas_Sedes] (
    [Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
    [Id_Sede] INT NOT NULL,
    [Id_Sala] INT NOT NULL,
    CONSTRAINT fk_Sedes FOREIGN KEY ([Id_Sede]) REFERENCES [Sedes]([Id]),
    CONSTRAINT fk_Salas FOREIGN KEY ([Id_Sala]) REFERENCES [Salas]([Id])
);
INSERT INTO [Salas_Sedes] ([Id_Sede], [Id_Sala]) VALUES (1,1);
INSERT INTO [Salas_Sedes] ([Id_Sede], [Id_Sala]) VALUES (2,2);
INSERT INTO [Salas_Sedes] ([Id_Sede], [Id_Sala]) VALUES (2,3);
INSERT INTO [Salas_Sedes] ([Id_Sede], [Id_Sala]) VALUES (3,4);
INSERT INTO [Salas_Sedes] ([Id_Sede], [Id_Sala]) VALUES (4,5);
INSERT INTO [Salas_Sedes] ([Id_Sede], [Id_Sala]) VALUES (5,6);
INSERT INTO [Salas_Sedes] ([Id_Sede], [Id_Sala]) VALUES (5,7);
SELECT * FROM [Salas_Sedes];


CREATE TABLE [CodigoCompras](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Codigo] NVARCHAR (150) NOT NULL,
[Id_Empleado] INT NOT NULL,
[Id_Plan] INT NULL,
[Id_Cliente] INT NOT NULL,
CONSTRAINT fk_Empleados FOREIGN KEY ([Id_Empleado]) REFERENCES [Empleados]([Id]),
CONSTRAINT fk_Planes FOREIGN KEY ([Id_Plan]) REFERENCES [Planes]([Id]),
CONSTRAINT fk_Clientes FOREIGN KEY ([Id_Cliente]) REFERENCES [Clientes]([Id])
);
INSERT INTO [CodigoCompras]([Codigo],[Id_Empleado],[Id_Plan],[Id_Cliente]) VALUES ('C001',1,NULL,1);
INSERT INTO [CodigoCompras]([Codigo],[Id_Empleado],[Id_Plan],[Id_Cliente]) VALUES ('C002',2,1,2);
INSERT INTO [CodigoCompras]([Codigo],[Id_Empleado],[Id_Plan],[Id_Cliente]) VALUES ('C003',3,2,3);
INSERT INTO [CodigoCompras]([Codigo],[Id_Empleado],[Id_Plan],[Id_Cliente]) VALUES ('C004',4,NULL,4);
INSERT INTO [CodigoCompras]([Codigo],[Id_Empleado],[Id_Plan],[Id_Cliente]) VALUES ('C005',5,3,5);
INSERT INTO [CodigoCompras]([Codigo],[Id_Empleado],[Id_Plan],[Id_Cliente]) VALUES ('C006',6,3,6);
SELECT * FROM [CodigoCompras];

CREATE TABLE [Boletas](
    [Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
    [FechaYHora] DATETIME NOT NULL DEFAULT GETDATE(),
    [Precio] DECIMAL(10,2) NOT NULL,
    [Id_CodigoCompra] INT NOT NULL,
    [Id_Salas_Sede] INT NOT NULL,
    [Id_Pelicula] INT NOT NULL,
    CONSTRAINT fk_CodigoCompras FOREIGN KEY ([Id_CodigoCompra]) REFERENCES [CodigoCompras]([Id]),
    CONSTRAINT fk_Salas_Sedes FOREIGN KEY ([Id_Salas_Sede]) REFERENCES [Salas_Sedes]([Id]),
    CONSTRAINT fk_Peliculas FOREIGN KEY ([Id_Pelicula]) REFERENCES [Peliculas]([Id])
);
INSERT INTO [Boletas]([FechaYHora],[Precio],[Id_CodigoCompra],[Id_Salas_Sede],[Id_Pelicula]) VALUES ('2025-06-06 15:00:00', 18.50,1,1,1);
INSERT INTO [Boletas]([FechaYHora],[Precio],[Id_CodigoCompra],[Id_Salas_Sede],[Id_Pelicula]) VALUES ('2025-02-25 10:00:00', 9.20,2,2,2);
INSERT INTO [Boletas]([FechaYHora],[Precio],[Id_CodigoCompra],[Id_Salas_Sede],[Id_Pelicula]) VALUES ('2025-02-25 10:00:00', 9.20,2,3,2);
INSERT INTO [Boletas]([FechaYHora],[Precio],[Id_CodigoCompra],[Id_Salas_Sede],[Id_Pelicula]) VALUES ('2025-03-02 19:29:00', 15.70,3,4,3);
INSERT INTO [Boletas]([FechaYHora],[Precio],[Id_CodigoCompra],[Id_Salas_Sede],[Id_Pelicula]) VALUES ('2025-03-15 12:00:00', 18.50,4,5,4);
INSERT INTO [Boletas]([FechaYHora],[Precio],[Id_CodigoCompra],[Id_Salas_Sede],[Id_Pelicula]) VALUES ('2025-03-17 14:00:00', 12.90,5,6,5);
INSERT INTO [Boletas]([FechaYHora],[Precio],[Id_CodigoCompra],[Id_Salas_Sede],[Id_Pelicula]) VALUES ('2025-03-17 14:00:00', 12.90,6,7,5);
SELECT * FROM [Boletas];


--DROP TABLE IF EXISTS [Detalles_Snacks];
--ALTER TABLE [Detalles_Snacks] DROP CONSTRAINT fk_CodigoCompra;

CREATE TABLE [Detalles_Snacks](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Id_CodigoCompra] INT NOT NULL,
[Id_Snack] INT NULL,
CONSTRAINT fk_CodigoCompra FOREIGN KEY ([Id_CodigoCompra]) REFERENCES [CodigoCompras]([Id]),
CONSTRAINT fk_Snack FOREIGN KEY ([Id_Snack]) REFERENCES [Snacks]([Id])
);
INSERT INTO [Detalles_Snacks]([Id_CodigoCompra], [Id_Snack]) VALUES (1,1);
INSERT INTO [Detalles_Snacks]([Id_CodigoCompra], [Id_Snack]) VALUES (2,2);
INSERT INTO [Detalles_Snacks]([Id_CodigoCompra], [Id_Snack]) VALUES (2,NULL);
INSERT INTO [Detalles_Snacks]([Id_CodigoCompra], [Id_Snack]) VALUES (3,3);
INSERT INTO [Detalles_Snacks]([Id_CodigoCompra], [Id_Snack]) VALUES (4,4);
INSERT INTO [Detalles_Snacks]([Id_CodigoCompra], [Id_Snack]) VALUES (5,5);
INSERT INTO [Detalles_Snacks]([Id_CodigoCompra], [Id_Snack]) VALUES (6,6);
SELECT * FROM [Detalles_Snacks];