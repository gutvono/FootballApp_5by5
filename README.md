# Exerc�cio de Modelagem e Implementa��o de Banco de Dados para Times de Futebol

Neste projeto, voc� dever� criar um banco de dados para controlar o cadastro de times de futebol de um campeonato amador. Cada time ter� as seguintes informa��es em seu cadastro:

- **Nome**
- **Apelido**
- **Data de Cria��o**

O campeonato inicialmente contar� com 3 equipes, mas poder�o ser cadastrados at� 5 times. Os jogos acontecer�o em formato de IDA e VOLTA, totalizando at� 20 partidas (5x5 - 5, pois cada time n�o joga contra si mesmo).

## Tabela de Pontua��o

- **EMPATE**: 1 ponto para cada time
- **VIT�RIA FORA DE CASA (COMO TIME VISITANTE)**: 5 pontos para o vencedor
- **VIT�RIA EM CASA (COMO TIME MANDANTE)**: 3 pontos para o vencedor

### Perguntas a serem respondidas pelo banco/aplica��o:

1. **Quem � o campe�o no final do campeonato?**
2. **Como verificar os 5 primeiros times do campeonato?**
3. **Como calcular a pontua��o dos times de acordo com os jogos que aconteceram?**
4. **Como implementar isso usando triggers ou stored procedures?**
5. **Qual time fez mais gols no campeonato?**
6. **Qual time sofreu mais gols no campeonato?**
7. **Qual foi o jogo com mais gols?**
8. **Qual foi o maior n�mero de gols que cada time fez em uma �nica partida?**