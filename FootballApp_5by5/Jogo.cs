using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApp_5by5
{
    internal class Jogo
    {
        public int Rodada {  get; set; }
        public int IdTimeCasa { get; set; }
        public int GolsTimeCasa { get; set; }
        public int IdTimeFora { get; set; }
        public int GolsTimeFora { get; set; }

        public Jogo(int rodada, int idTimeCasa, int golsTimeCasa, int idTimeFora, int golsTimeFora)
        {
            Rodada = rodada;
            IdTimeCasa = idTimeCasa;
            GolsTimeCasa = golsTimeCasa;
            IdTimeFora = idTimeFora;
            GolsTimeFora = golsTimeFora;
        }
    }
}
