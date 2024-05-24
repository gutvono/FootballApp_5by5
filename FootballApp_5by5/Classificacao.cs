using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        public int GolsFeitos { get; set; }
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

        public Classificacao() { }

        public void MostrarClassificacao(SqlConnection conexao)
        {
            conexao.Open();
            SqlCommand comando = new("Classificacao_Geral", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();

            int contador = 1;
            using SqlDataReader reader = comando.ExecuteReader();
            Console.WriteLine("+-----+----------------------+------+-----+-----+-----+------+");
            Console.WriteLine("| Pos | Time                 | Ptos |  V  |  D  |  E  |  SG  |");
            Console.WriteLine("+-----+----------------------+------+-----+-----+-----+------+");
            while (reader.Read())
            {
                Console.Write($"| {contador}".PadRight(6));
                Console.Write($"| {reader.GetString(1)}".PadRight(23));
                Console.Write($"| {reader.GetInt32(3)}".PadRight(7));
                Console.Write($"| {reader.GetInt32(4)}".PadRight(6));
                Console.Write($"| {reader.GetInt32(5)}".PadRight(6));
                Console.Write($"| {reader.GetInt32(6)}".PadRight(6));
                Console.Write($"| {reader.GetInt32(7)}".PadRight(7) + "|");
                Console.Write("\n");
                contador++;
            }
            Console.Write($"+-----+----------------------+------+-----+-----+-----+------+\n");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            conexao.Close();
        }

        public void MostrarMelhorAtaque(SqlConnection conexao)
        {
            conexao.Open();
            SqlCommand comando = new("Melhor_Ataque", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            using SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            Console.WriteLine($"O melhor ataque do campeonato é do time {reader.GetString(1)}, com {reader.GetInt32(8)} gols.");
            conexao.Close();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void MostrarPiorDefesa(SqlConnection conexao)
        {
            conexao.Open();
            SqlCommand comando = new("Pior_Defesa", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            using SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            Console.WriteLine($"A pior defesa do campeonato é do time {reader.GetString(1)}, que levou {reader.GetInt32(8)} gols.");
            conexao.Close();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void MostrarJogoComMaisGols(SqlConnection conexao)
        {
            conexao.Open();
            SqlCommand comando = new("Jogo_Com_Mais_Gols", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            using SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            Console.WriteLine($"O jogo que teve mais gols foi {reader.GetString(0)} contra {reader.GetString(1)} com {reader.GetInt32(2).ToString()} gols.");
            conexao.Close();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
