USE [Campeonato]
GO
/****** Object:  StoredProcedure [dbo].[Resetar_Campeonato_e_Times]    Script Date: 24/05/2024 18:55:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROC [dbo].[Resetar_Campeonato_e_Times]
AS
BEGIN
	DELETE FROM Jogo
	DELETE FROM Classificacao
	DELETE FROM Times
	DBCC CHECKIDENT ('[Times]', RESEED, 0);
END