CREATE OR ALTER PROC Melhor_Ataque
AS
BEGIN
	SELECT TOP 1 * FROM Classificacao ORDER BY GolsFeitos DESC
END