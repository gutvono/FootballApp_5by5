USE [Campeonato]
GO
/****** Object:  StoredProcedure [dbo].[Resetar_Campeonato]    Script Date: 24/05/2024 18:49:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROC [dbo].[Resetar_Campeonato]
AS
BEGIN
	DELETE FROM Jogo
	UPDATE Classificacao
	SET
		Rodada = 0,
		Pontos = 0,
		Vitorias = 0,
		Derrotas = 0,
		Empates = 0,
		SaldoGols = 0,
		GolsFeitos = 0,
		GolsSofridos = 0,
		PartidaMaisGols = 0
END