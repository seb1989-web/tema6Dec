using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InsertPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source = .; Initial Catalog = Tema6Dec; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //InsertData(connection);
            //ReadName(connection);
            PrintId(connection);
            
            
            
            
            
            Console.ReadLine();
        }

        public static void ReadName(SqlConnection connection)
        {
            SqlDataReader reader = null;
            var query = "select Name from Publisher";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    Console.WriteLine($"Publisher name is {name}");
                }

            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
            }
        }
        
        public static void InsertData(SqlConnection connection)
        {
            Console.WriteLine("Insert Publisher:");
            var data = Console.ReadLine();
            SqlParameter param = new SqlParameter("@data", data);
            var query = "insert into Publisher values " + @data;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(param);
            command.ExecuteNonQuery();

        }
        public static void PrintId(SqlConnection sqlConnection)
        {
            var query = "select PublisherId from Publisher where Name = 'Mioritic'";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            var id = command.ExecuteScalar();
            Console.WriteLine($"The las Publisher id is {id}");
        }
    }
    
}
