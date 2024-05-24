CREATE OR ALTER PROC Cadastrar_Time
	@Nome VARCHAR(50),
	@Apelido VARCHAR(20),
	@DataCriacao DATE
AS
BEGIN 
	DECLARE @IdTime INT;
	
	INSERT INTO Times
	VALUES (@Nome, @Apelido, @DataCriacao);

	SET @IdTime = (SELECT Id FROM Times WHERE Nome = @Nome);

	INSERT INTO Classificacao
	VALUES (@IdTime, @Apelido, 1, 0, 0, 0, 0, 0, 0, 0, 0);

END;
