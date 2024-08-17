create database Agendamentos

use Agendamentos;

CREATE TABLE Pessoa (
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Celular VARCHAR(20) NULL,
	CPF VARCHAR(11)
)


CREATE TABLE Espaco (
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	Nome VARCHAR(50) not null,
	Descricao VARCHAR(300)
)

CREATE TABLE EspacoConfiguracaoHorarios (
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	IdEspaco Int NOT NULL,
	DiaDaSemana INT,
	HorarioInicial CHAR(5),
	HorarioFinal CHAR(5),
	Duracao CHAR(5),
	IntervaloEntreHorarios CHAR(5)
)
GO

ALTER TABLE EspacoConfiguracaoHorarios
ADD CONSTRAINT FK_IdEspaco FOREIGN KEY (IdEspaco)
REFERENCES Espaco (Id)