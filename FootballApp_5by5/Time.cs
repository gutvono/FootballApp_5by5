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

        public void CadastrarTime(SqlConnection conexao)
        {
            using (conexao)
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
                } catch (Exception e)
                {
                    Console.WriteLine("Ocorreu um erro ao cadastrar o time:");
                    Console.WriteLine(e);
                }
                finally
                {
                    Console.WriteLine("Time cadastrado com sucesso.");
                    conexao.Close();
                }
            }
        }
    }
}
