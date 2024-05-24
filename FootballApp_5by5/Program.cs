using Microsoft.Data.SqlClient;

namespace FootballApp_5by5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool _TimesCheios = false, _RodadaIdaOk = false, _RodadaVoltaOk = false;
            int opcao = 0, _ContadorTimes = 0;

            Banco conectar = new();
            SqlConnection conexaoSql = new(conectar.Caminho());

            void Menu()
            {
                if (!_TimesCheios) Console.WriteLine("1 - Cadastrar times;");
                if (!_RodadaIdaOk) Console.WriteLine("2 - Realizar a rodada de ida;");
                if (!_RodadaVoltaOk) Console.WriteLine("3 - Realizar a rodada de volta;");
                Console.WriteLine("4 - Ver tabela de classificacao;\n" +
                    "5 - Ver melhor ataque;\n" +
                    "6 - Ver pior defesa;\n" +
                    "7 - Ver jogo com mais gols;\n" +
                    "8 - Ver maior numero numero de gols de cada time em uma partida.");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        int EncerrarCadastro = 0;
                        do
                        {
                            string nome, apelido;
                            DateOnly data;

                            Console.Write("Informe o nome do time:");
                            nome = Console.ReadLine();
                            Console.Write("Informe o apelido do time:");
                            apelido = Console.ReadLine();
                            Console.Write("Informe a data de criação do time:");
                            data = DateOnly.Parse(Console.ReadLine());

                            Time time = new(nome, apelido, data);
                            time.CadastrarTime(conexaoSql);

                            if (!_TimesCheios) 
                            {
                                Console.WriteLine("Cadastrar mais times?\n" +
                                    "1 - SIM;" +
                                    "0 - NÃO.");
                                EncerrarCadastro = int.Parse(Console.ReadLine());
                            }
                        } while (EncerrarCadastro != 0);
                        break;
                    case 2:

                        break;
                }
            }

            //PROGRAMA
            Menu();
        }
    }
}