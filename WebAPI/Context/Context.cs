using System.Data;
using MySql.Data.MySqlClient;

namespace WebAPI.Context
{
    public class Context
    {
        private const string Server = "localhost";
        private const string Database = "DB_Cliente";
        private const string User = "root";
        private const string Password = "";
        public MySqlConnection Connection { get; }

        private readonly string _connectionString = $"Server ={Server};Database={Database};User={User};Password={Password};Sslmode=none;";

        public Context()
        {
            Connection = new MySqlConnection(_connectionString);
            Connection.Open();
        }

        public void ExecutarComandoSql(string sql)
        {
            var command = new MySqlCommand(sql, Connection);
            command.ExecuteNonQuery();
        }

        public DataTable RetornarDataTable(string sql)
        {
            var command = new MySqlCommand(sql, Connection);
            var dataAdapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
