CREATE DATABASE DbCupcakeErp;
GO

USE DbCupcakeErp;
GO

CREATE TABLE tb_insumo (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    QtdStock FLOAT NOT NULL,
    QtdMinima FLOAT NOT NULL,
    UnidadeMedida NVARCHAR(20) NOT NULL
);

INSERT INTO tb_insumo (Nome, QtdStock, QtdMinima, UnidadeMedida) 
VALUES ('Cobertura de Chocolate', 10.0, 2.0, 'KG'),
       ('Farinha de Trigo', 15.0, 3.0, 'KG'),
       ('Granulado Colorido', 5.0, 1.0, 'KG');