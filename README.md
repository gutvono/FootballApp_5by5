# Exercício de Modelagem e Implementação de Banco de Dados para Times de Futebol

Neste projeto, você deverá criar um banco de dados para controlar o cadastro de times de futebol de um campeonato amador. Cada time terá as seguintes informações em seu cadastro:

- **Nome**
- **Apelido**
- **Data de Criação**

O campeonato inicialmente contará com 3 equipes, mas poderão ser cadastrados até 5 times. Os jogos acontecerão em formato de IDA e VOLTA, totalizando até 20 partidas (5x5 - 5, pois cada time não joga contra si mesmo).

## Tabela de Pontuação

- **EMPATE**: 1 ponto para cada time
- **VITÓRIA FORA DE CASA (COMO TIME VISITANTE)**: 5 pontos para o vencedor
- **VITÓRIA EM CASA (COMO TIME MANDANTE)**: 3 pontos para o vencedor

### Perguntas a serem respondidas pelo banco/aplicação:

1. **Quem é o campeão no final do campeonato?**
2. **Como verificar os 5 primeiros times do campeonato?**
3. **Como calcular a pontuação dos times de acordo com os jogos que aconteceram?**
4. **Como implementar isso usando triggers ou stored procedures?**
5. **Qual time fez mais gols no campeonato?**
6. **Qual time sofreu mais gols no campeonato?**
7. **Qual foi o jogo com mais gols?**
8. **Qual foi o maior número de gols que cada time fez em uma única partida?**