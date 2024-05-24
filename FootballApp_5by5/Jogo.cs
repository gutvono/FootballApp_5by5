using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void CadastrarPartida(SqlConnection conexao)
        {
            try
            {
                conexao.Open();
                SqlCommand comando = new("Cria_Jogo_e_Atualiza_Classificacao", conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Rodada", SqlDbType.Int).Value = Rodada;
                comando.Parameters.Add("@IdTimeCasa", SqlDbType.Int).Value = IdTimeCasa;
                comando.Parameters.Add("@GolsTimeCasa", SqlDbType.Int).Value = GolsTimeCasa;
                comando.Parameters.Add("@IdTimeFora", SqlDbType.Int).Value = IdTimeFora;
                comando.Parameters.Add("@GolsTimeFora", SqlDbType.Int).Value = GolsTimeFora;
                comando.ExecuteNonQuery();
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao cadastrar a partida:");
                Console.WriteLine(e);
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
