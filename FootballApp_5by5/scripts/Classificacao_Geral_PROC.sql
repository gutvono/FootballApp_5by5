CREATE OR ALTER PROC Classificacao_Geral
AS
BEGIN
	SELECT * FROM Classificacao ORDER BY Pontos
END