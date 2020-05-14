using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReferenceInConstructor
{
    public class Program1
    {
        public static void Main(string[] args)
        {
            string query = File.ReadAllText("Query.sql");

            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "TC",
                UserID = "sa",
                Password = "ezetc"
            }.ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //command.CommandTimeout = _queryTimeout;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
