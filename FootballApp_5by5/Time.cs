using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApp_5by5
{
    internal class Time
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateOnly DataCriacao { get; set; }

        public Time(string n, string a, DateOnly d)
        {
            Nome = n;
            Apelido = a;
            DataCriacao = d;
        }

        public Time() { }

        public void CadastrarTime(SqlConnection conexao)
        {
            try
            {
                conexao.Open();
                SqlCommand comando = new("Cadastrar_Time", conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = Nome;
                comando.Parameters.Add("@Apelido", SqlDbType.VarChar, 20).Value = Apelido;
                comando.Parameters.Add("@DataCriacao", SqlDbType.Date).Value = DataCriacao;
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao cadastrar o time:");
                Console.WriteLine(e);
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            finally
            {
                Console.WriteLine("Time cadastrado com sucesso.");
                conexao.Close();
            }
        }

        public void MostrarTime(SqlConnection conexao)
        {
            conexao.Open();
            SqlCommand comando = new("Mostrar_Times", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            using SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            Console.WriteLine($"A pior defesa do campeonato é do time {reader.GetString(1)}, que levou {reader.GetInt32(8)} gols.");
            conexao.Close();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public int MostrarQtdTimes(SqlConnection conexao)
        {
            conexao.Open();
            SqlCommand comando = new("Mostrar_Times", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();

            int contador = 0;
            using SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                contador++;
            }
            conexao.Close();
            return contador;
        }
    }
}
