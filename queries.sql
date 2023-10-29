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

-- procedure para inserir dados na tabela
CREATE PROCEDURE InserirVinho
@nomeVinho NVARCHAR(255),
@valorGarrafa DECIMAL(10, 2),
@paisOrigem NVARCHAR(255),
@dataFabricacao DATE,
@quantidadeEstoque INT
AS
INSERT INTO VINHO (nomeVinho, valorGarrafa, paisOrigem, dataFabricacao, quantidadeEstoque)
VALUES (@nomeVinho, @valorGarrafa, @paisOrigem, @dataFabricacao, @quantidadeEstoque);

-- procedure para atualizar informacoes do valor e quantidade em estoque
CREATE PROCEDURE AtualizarVinho
@vinhoId INT,
@novoValorGarrafa DECIMAL(10, 2),
@NovaQuantidadeEstoque INT
AS
UPDATE VINHO
SET valorGarrafa = @novoValorGarrafa,
	quantidadeEstoque = @NovaQuantidadeEstoque
WHERE vinhoId = @vinhoId;

-- procedure para retornar informacoes do vinho pelo ID
CREATE PROCEDURE ObterVinho
@vinhoId INT
AS
SELECT * FROM VINHO WHERE vinhoId = @vinhoId;

-- procedure para listar os vinhos
CREATE PROCEDURE ListarVinhos
AS
SELECT * FROM VINHO;

--procedure para excluir vinho por ID
CREATE PROCEDURE ExcluirVinho
@vinhoId
AS
DELETE FROM VINHO
WHERE vinhoId = @vinhoId;
