USE Campeonato;

CREATE TABLE Times
(
	Id INT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Apelido VARCHAR(20) NOT NULL,
	DataCriacao DATE NOT NULL,

	CONSTRAINT PkTimes PRIMARY KEY (Id)
);

CREATE TABLE Jogo
(
	Rodada INT NOT NULL,
	IdTimeCasa INT NOT NULL,
	GolsTimeCasa INT,
	IdTimeFora INT NOT NULL,
	GolsTimeFora INT,

	CONSTRAINT PkJogo PRIMARY KEY (IdTimeCasa, IdTimeFora),
	CONSTRAINT FkTimeCasa FOREIGN KEY (IdTimeCasa) REFERENCES Times(Id),
	CONSTRAINT FkTimeFora FOREIGN KEY (IdTimeFora) REFERENCES Times(Id)
);

CREATE TABLE Classificacao
(
	IdTime INT NOT NULL,
	Apelido VARCHAR(20) NOT NULL,
	Rodada INT NOT NULL,
	Pontos INT NOT NULL,
	Vitorias INT NOT NULL,
	Derrotas INT NOT NULL,
	Empates INT NOT NULL,
	SaldoGols INT NOT NULL,
	GolsFeitos INT NOT NULL,
	GolsSofridos INT NOT NULL,
	PartidaMaisGols INT NOT NULL,

	CONSTRAINT PkClassificacao PRIMARY KEY (IdTime),
	CONSTRAINT FkTime FOREIGN KEY (IdTime) REFERENCES Times(Id)
);
