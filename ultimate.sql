CREATE DATABASE soporte4;
go
use soporte4;
go
CREATE TABLE Rol
(
    idRol int IDENTITY(1,1) NOT NULL,
    Role VARCHAR(50) PRIMARY KEY NOT NULL,
)
go
CREATE TABLE Registro
(
    idRegistro int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Numero VARCHAR(50) NOT NULL,
    Direccion VARCHAR(50) NOT NULL,
    FechaEntrada DATETIME default GETDATE(),
	FechaSalida DATETIME,
    ValorUnidad money,
	ValorTotal money,
    CantidadEquipos int NOT NULL,
    Seriales VARCHAR(100) NOT NULL,
    Correo VARCHAR(50) NOT NULL,
	Datos BIT NOT NULL,
	Descripcion VARCHAR(150) NOT NULL,
	DescripcionRespuesta VARCHAR(150),
	Garantia VARCHAR(50),
	NombreTecnico VARCHAR(50) NOT NULL,
	Marca VARCHAR(50) NOT NULL,
	Modelo VARCHAR(50) NOT NULL,
	Categoria VARCHAR(50) NOT NULL,
	estado BIT default(1) NOT NULL,
    ProfilePicture VARCHAR(100) NOT NULL,
)
go
CREATE TABLE Garantia
(	
	idGarantia int IDENTITY(1,1) NOT NULL,
	Garantia VARCHAR(50) PRIMARY KEY,
)
GO
CREATE TABLE Analista
(
    idAnalista int IDENTITY(1,1) NOT NULL,
    NombreTecnico VARCHAR(50) PRIMARY KEY NOT NULL,
	Rol VARCHAR(50) NOT NULL,
)
go
CREATE TABLE Categoria
(
    idCAtegoria int IDENTITY(1,1) NOT NULL,
    Categoria VARCHAR(50) PRIMARY KEY NOT NULL,
)
go
CREATE TABLE Marca
(
    idMarca int IDENTITY(1,1) NOT NULL,
    Marca VARCHAR(50) PRIMARY KEY NOT NULL,
)
go
CREATE TABLE Modelo
(
    idModelo int IDENTITY(1,1) NOT NULL,
    Modelo VARCHAR(50) PRIMARY KEY NOT NULL,
)
GO
CREATE TABLE Contacto
(
    idCorreo int  PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Correo VARCHAR(50) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Numero VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(150) NOT NULL,
)
GO
ALTER TABLE [dbo].[Registro] ADD  DEFAULT (getdate()) FOR [FechaEntrada]
GO
ALTER TABLE [dbo].[Registro] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_Registro_Analista] FOREIGN KEY([NombreTecnico])
REFERENCES [dbo].[Analista] ([NombreTecnico])
GO
ALTER TABLE [dbo].[Registro] CHECK CONSTRAINT [FK_Registro_Analista]
GO
ALTER TABLE [dbo].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_Registro_Categoria] FOREIGN KEY([Categoria])
REFERENCES [dbo].[Categoria] ([Categoria])
GO
ALTER TABLE [dbo].[Registro] CHECK CONSTRAINT [FK_Registro_Categoria]
GO
ALTER TABLE [dbo].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_Registro_Garantia] FOREIGN KEY([Garantia])
REFERENCES [dbo].[Garantia] ([Garantia])
GO
ALTER TABLE [dbo].[Registro] CHECK CONSTRAINT [FK_Registro_Garantia]
GO
ALTER TABLE [dbo].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_Registro_Marca] FOREIGN KEY([Marca])
REFERENCES [dbo].[Marca] ([Marca])
GO
ALTER TABLE [dbo].[Registro] CHECK CONSTRAINT [FK_Registro_Marca]
GO
ALTER TABLE [dbo].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_Registro_Modelo] FOREIGN KEY([Modelo])
REFERENCES [dbo].[Modelo] ([Modelo])
GO
ALTER TABLE [dbo].[Registro] CHECK CONSTRAINT [FK_Registro_Modelo]
GO
