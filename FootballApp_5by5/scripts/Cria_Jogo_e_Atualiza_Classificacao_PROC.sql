CREATE OR ALTER PROC Cria_Jogo_e_Atualiza_Classificacao
	@Rodada INT,
	@IdTimeCasa INT,
	@GolsTimeCasa INT,
	@IdTimeFora INT,
	@GolsTimeFora INT
AS
BEGIN
	
	INSERT INTO Jogo
	VALUES (@Rodada, @IdTimeCasa, @GolsTimeCasa, @IdTimeFora, @GolsTimeFora);

	IF (@GolsTimeCasa > @GolsTimeFora)
		BEGIN
			UPDATE Classificacao
			SET 
				Pontos = Pontos + 3,
				Vitorias = Vitorias + 1,
				SaldoGols = SaldoGols + (@GolsTimeCasa - @GolsTimeFora),
				GolsFeitos = GolsFeitos + @GolsTimeCasa,
				GolsSofridos = GolsSofridos + @GolsTimeFora
			WHERE IdTime = @IdTimeCasa;

			UPDATE Classificacao
			SET 
				Derrotas = Derrotas + 1,
				SaldoGols = SaldoGols + (@GolsTimeFora - @GolsTimeCasa),
				GolsFeitos = GolsFeitos + @GolsTimeFora,
				GolsSofridos = GolsSofridos + @GolsTimeCasa
			WHERE IdTime = @IdTimeFora
		END
	ELSE IF (@GolsTimeCasa < @GolsTimeFora)
		BEGIN
			UPDATE Classificacao
			SET 
				Pontos = Pontos + 5,
				Vitorias = Vitorias + 1,
				SaldoGols = SaldoGols + (@GolsTimeFora - @GolsTimeCasa),
				GolsFeitos = GolsFeitos + @GolsTimeFora,
				GolsSofridos = GolsSofridos + @GolsTimeCasa
			WHERE IdTime = @IdTimeFora;

			UPDATE Classificacao
			SET 
				Derrotas = Derrotas + 1,
				SaldoGols = SaldoGols + (@GolsTimeCasa - @GolsTimeFora),
				GolsFeitos = GolsFeitos + @GolsTimeCasa,
				GolsSofridos = GolsSofridos + @GolsTimeFora
			WHERE IdTime = @IdTimeCasa
		END
	ELSE
		BEGIN
			UPDATE Classificacao
			SET 
				Pontos = Pontos + 1,
				Empates = Empates + 1,
				SaldoGols = SaldoGols + (@GolsTimeCasa - @GolsTimeFora),
				GolsFeitos = GolsFeitos + @GolsTimeCasa,
				GolsSofridos = GolsSofridos + @GolsTimeFora
			WHERE IdTime = @IdTimeCasa;

			UPDATE Classificacao
			SET 
				Pontos = Pontos + 1,
				Empates = Empates + 1,
				SaldoGols = SaldoGols + (@GolsTimeFora - @GolsTimeCasa),
				GolsFeitos = GolsFeitos + @GolsTimeFora,
				GolsSofridos = GolsSofridos + @GolsTimeCasa
			WHERE IdTime = @IdTimeFora;
		END


	SELECT * FROM Classificacao
	ORDER BY Pontos DESC;
END