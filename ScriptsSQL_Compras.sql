--Criação de tabelas
CREATE TABLE [dbo].[TBUsuarios]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(100) NOT NULL, 
    [Login] VARCHAR(20) NOT NULL, 
    [Senha] VARCHAR(8) NOT NULL
)

CREATE TABLE [dbo].[TBProdutos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(500) NOT NULL, 
    [Valor] DECIMAL(18, 3) NOT NULL, 
    [Detalhes] VARCHAR(500) NULL
)

CREATE TABLE [dbo].[TBComanda]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdUsuario] INT NOT NULL, 
    [IdProduto] INT NOT NULL, 
    [Quantidade] INT NOT NULL, 
    CONSTRAINT [FK_TBComanda_TBUsuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [TBUsuarios]([Id]), 
    CONSTRAINT [FK_TBComanda_TBProdutos] FOREIGN KEY ([IdProduto]) REFERENCES [TBProdutos]([Id])
)

--Popular tabelas
INSERT INTO TBUsuarios (Nome, Login, Senha) VALUES ('Fernando Albuquerque', 'Fernando', '123456')

INSERT INTO TBProdutos (Nome, Valor, Detalhes) VALUES ('TV SAMSUNG', 2.000, '42 Polegadas')
INSERT INTO TBProdutos (Nome, Valor, Detalhes) VALUES ('SAMSUNG GALAXY A10', 2.300, 'Câmera 12px')
INSERT INTO TBProdutos (Nome, Valor, Detalhes) VALUES ('SOFÁ', 5.000, '3 Lugar | Cor: Branco')
INSERT INTO TBProdutos (Nome, Valor, Detalhes) VALUES ('XBOX ONE', 1.100, '1 TB ARMAZENAMENTO')
INSERT INTO TBProdutos (Nome, Valor, Detalhes) VALUES ('BOX BLU-RAY GAME OF THRONES', 99, 'Acompanha poster da série')
INSERT INTO TBProdutos (Nome, Valor, Detalhes) VALUES ('LIQUIDIFICADOR', 87, '4 Velocidades')
INSERT INTO TBProdutos (Nome, Valor, Detalhes) VALUES ('MESA', 500, '4 Lugares')
