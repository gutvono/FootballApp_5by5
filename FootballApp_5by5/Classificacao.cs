using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApp_5by5
{
    internal class Classificacao
    {
        public int? IdTime { get; set; }
        public string Apelido { get; set; }
        public int Rodada { get; set; }
        public int Pontos { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public int SaldoGols { get; set; }
        public int GolsFeitos {  get; set; }
        public int GolsSofridos { get; set; }

        public Classificacao(int? idTime, string apelido, int rodada, int pontos, int vitorias, int derrotas, int empates, int saldoGols, int golsFeitos, int golsSofridos)
        {
            IdTime = idTime;
            Apelido = apelido;
            Rodada = rodada;
            Pontos = pontos;
            Vitorias = vitorias;
            Derrotas = derrotas;
            Empates = empates;
            SaldoGols = saldoGols;
            GolsFeitos = golsFeitos;
            GolsSofridos = golsSofridos;
        }
    }
}
