IF NOT EXISTS(SELECT * FROM sys.databases WHERE name='persona_db')
BEGIN
CREATE DATABASE [persona_db]
END

GO
	USE [persona_db]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='persona')
BEGIN
	CREATE TABLE persona (
		cc INT NOT NULL,
		nombre VARCHAR(45) NOT NULL,
		apellido VARCHAR(45) NOT NULL,
		genero CHAR(1) NOT NULL CHECK (genero IN('M', 'F')),
		edad INT NOT NULL,
		PRIMARY KEY (cc)
	)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='profesion')
BEGIN
	CREATE TABLE profesion (
		id INT NOT NULL,
		nom VARCHAR(90) NOT NULL,
		des TEXT NOT NULL,
		PRIMARY KEY (id)
	)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='estudios')
BEGIN
	CREATE TABLE estudios (
		id_prof INT NOT NULL,
		cc_per INT NOT NULL,
		fecha DATE NOT NULL,
		univer VARCHAR(50) NOT NULL,
		PRIMARY KEY (id_prof, cc_per),
		CONSTRAINT FK_estudio_persona FOREIGN KEY (cc_per) REFERENCES dbo.persona (cc),
		CONSTRAINT FK_estudio_profesion FOREIGN KEY (id_prof) REFERENCES dbo.profesion (id)
	)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='telefono')
BEGIN
	CREATE TABLE telefono (
		num VARCHAR(50) NOT NULL,
		oper VARCHAR(50) NOT NULL,
		duenio INT NOT NULL,
		PRIMARY KEY (num),
		CONSTRAINT FK_telefono_persona FOREIGN KEY (duenio) REFERENCES dbo.persona (cc)
	)
END
