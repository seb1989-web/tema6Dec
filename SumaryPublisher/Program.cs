using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SummaryPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source = .; Initial Catalog = Tema6Dec; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            
            //Count(connection);
            ReadTop10(connection);
            //BooksPerPublisher(connection);
            //TotalPrice(connection);


            Console.ReadLine();
        }
        

        public static void Count(SqlConnection connection)
        {
            var query = "select count(PublisherId) from Publisher";
            SqlCommand command = new SqlCommand(query,connection);
            var count = command.ExecuteScalar();
            Console.WriteLine($"Nr of rows from Publisher is {count}");
        }

        public static void ReadTop10(SqlConnection connection)
        {
            SqlDataReader reader = null;
            var query = "select PublisherId, Name from Publisher where PublisherId between 1 and 10";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["PublisherId"];
                    string name = (string)reader["Name"];
                    Console.WriteLine($"Id {id} and name {name}");
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

        }
        public static void BooksPerPublisher(SqlConnection connection)
        {
            SqlDataReader reader = null;
            var query = "select Name, BookId from Publisher p join Book b on p.PublisherId = b.PublisherId ";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    int id = (int)reader["BookId"];
                    Console.WriteLine($"The publisher {name} wrote {id} books.");
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        public static void TotalPrice(SqlConnection connection)
        {
            var query = "select Price * BookId from Publisher p join Book b on p.PublisherId = b.BookId where p.Name = 'Caraiman'";
            SqlCommand command = new SqlCommand(query, connection);
            var Total = command.ExecuteScalar();
            Console.WriteLine($" The total price of books writen by publisher Caraiman is {Total}");
        }
    }
}
