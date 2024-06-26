USE [Campeonato]
GO
/****** Object:  StoredProcedure [dbo].[Jogo_Com_Mais_Gols]    Script Date: 24/05/2024 18:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROC [dbo].[Jogo_Com_Mais_Gols]
AS
BEGIN
	SELECT TOP 1
	(SELECT Apelido FROM Times WHERE Times.Id = Jogo.IdTimeCasa) AS ApelidoTimeCasa,
	(SELECT Apelido FROM Times WHERE Times.Id = Jogo.IdTimeFora) AS ApelidoTimeFora,
	GolsTimeCasa + GolsTimeFora AS TotalGols
	FROM Jogo 
	ORDER BY GolsTimeCasa + GolsTimeFora DESC
END