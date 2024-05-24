using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApp_5by5
{
    internal class Banco
    {
        string datasource = "127.0.0.1", database = "Campeonato", username = "sa", password = "SqlServer2019!";

        public Banco() { }

        public string Caminho() { return $"Data Source = {datasource}; Initial Catalog={database}; User Id={username}; Password={password}; TrustServerCertificate=True"; }
    }
}
