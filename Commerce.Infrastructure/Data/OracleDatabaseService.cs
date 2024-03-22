using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Infrastructure.Data
{
    public class OracleDatabaseService
    {
        private readonly string _connectionString;

        public OracleDatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ConnectToDatabase()
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conectado ao Oracle Autonomous Database.");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Erro ao conectar em Oracle Autonomous Database: {ex.Message}");
                }
            }
        }
    }
}
