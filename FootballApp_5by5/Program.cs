using Microsoft.Data.SqlClient;

namespace FootballApp_5by5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool _TimesCheios = false, _RodadasOk = false;
            int opcao = 0, _ContadorTimes = 0;
            Classificacao classificacao = new();
            Banco conectar = new();
            SqlConnection conexaoSql = new(conectar.Caminho());
            SqlCommand comando;

            void cadastrar()
            {
                _ContadorTimes = new Time().MostrarQtdTimes(conexaoSql);
                int EncerrarCadastro = 0;
                do
                {
                    if (_ContadorTimes < 5)
                    {
                        Console.Clear();
                        string nome, apelido;
                        DateOnly data;

                        Console.WriteLine("");

                        Console.Write("Informe o nome do time:");
                        nome = Console.ReadLine();
                        Console.Write("Informe o apelido do time:");
                        apelido = Console.ReadLine();
                        Console.Write("Informe a data de criação do time:");
                        data = DateOnly.Parse(Console.ReadLine());

                        Time time = new(nome, apelido, data);
                        time.CadastrarTime(conexaoSql);

                        Console.WriteLine("Cadastrar mais times?\n" +
                            "1 - SIM;\n" +
                            "0 - NÃO.");
                        EncerrarCadastro = int.Parse(Console.ReadLine());
                        _ContadorTimes++;
                        if (EncerrarCadastro == 0 && _ContadorTimes < 3)
                        {
                            Console.WriteLine("Cadastrar no mínimo 3 times. Pressione qualquer tecla para continuar...");
                            EncerrarCadastro = 1;
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Limite de times alcançado! Pressione qualquer tecla para continuar...");
                        _TimesCheios = true;
                        EncerrarCadastro = 0;
                        Console.ReadKey();
                    }
                } while (EncerrarCadastro != 0);
            }

            void gerarPartidas()
            {
                _ContadorTimes = new Time().MostrarQtdTimes(conexaoSql);
                Console.WriteLine(_ContadorTimes);
                for (int idCasa = 1; idCasa <= _ContadorTimes; idCasa++)
                {
                    for (int idFora = 1; idFora <= _ContadorTimes; idFora++)
                    {
                        if (idCasa != idFora)
                        {
                            Jogo jogo = new(idCasa, idCasa, new Random().Next(0, 8), idFora, new Random().Next(0, 8));
                            jogo.CadastrarPartida(conexaoSql);
                        }
                    }
                }
                Console.WriteLine("Partidas criadas. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            void resetarCampeonato(bool times)
            {
                conexaoSql.Open();
                if (times) comando = new("Resetar_Campeonato_e_Times", conexaoSql);
                else comando = new("Resetar_Campeonato", conexaoSql);
                comando.ExecuteNonQuery();
                conexaoSql.Close();
            }

            void Menu()
            {
                do
                {
                    Console.Clear();
                    if (!_TimesCheios) Console.WriteLine("1 - Cadastrar times;");
                    if (!_RodadasOk) Console.WriteLine("2 - Realizar partidas | Resetar campeonato com novas partidas;");
                    Console.WriteLine("3 - Ver tabela de classificacao;\n" +
                        "4 - Ver melhor ataque;\n" +
                        "5 - Ver pior defesa;\n" +
                        "6 - Ver jogo com mais gols;\n" +
                        "7 - Ver maior numero numero de gols de cada time em uma partida;\n" +
                        "8 - Resetar times e campeonato completo;\n" +
                        "0 - Finalizar programa.");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            cadastrar();
                            break;
                        case 2:
                            resetarCampeonato(false);
                            gerarPartidas();
                            break;
                        case 3:
                            classificacao.MostrarClassificacao(conexaoSql);
                            break;
                        case 4:
                            classificacao.MostrarMelhorAtaque(conexaoSql);
                            break;
                        case 5:
                            classificacao.MostrarPiorDefesa(conexaoSql);
                            break;
                        case 6:
                            classificacao.MostrarJogoComMaisGols(conexaoSql);
                            break;
                        case 8:
                            resetarCampeonato(true);
                            Console.WriteLine("Resetado com sucesso. Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;
                        default:
                            break;
                    }
                } while (opcao != 0);
            }

            //PROGRAMA
            Menu();
        }
    }
}