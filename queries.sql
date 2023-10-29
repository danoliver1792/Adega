CREATE DATABASE ADEGA;

USE ADEGA;

CREATE TABLE VINHO(
	vinhoId INT PRIMARY KEY IDENTITY(1,1),
	nomeVinho NVARCHAR(255),
	valorGarrafa DECIMAL(10, 2),
	paisOrigem NVARCHAR(255),
	dataFabricacao DATE,
	quantidadeEstoque INT
);