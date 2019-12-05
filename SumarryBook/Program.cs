using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace SummaryBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source = .; Initial Catalog = Tema6Dec; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //Books2010(connection);
            //MaxYear(connection);
            Top10(connection);


            Console.ReadLine();
        }
        public static void Books2010(SqlConnection connection)
        {
            SqlDataReader reader = null;
            var query = "select * from Book where Year = 2010";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["BookId"];
                    string title = (string)reader["Title"];
                    int publisher = (int)reader["PublisherId"];
                    int year = (int)reader["Year"];
                    decimal price = (decimal)reader["Price"];
                    Console.WriteLine($"BookId:{id} Title:{title} Publisher:{publisher} Year:{year} Price:{price}");
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

        public static void MaxYear(SqlConnection connection)
        {
            SqlDataReader reader = null;
            var query = "select * from Book where Year = (select max(Year) from Book)";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["BookId"];
                    string title = (string)reader["Title"];
                    int publisher = (int)reader["PublisherId"];
                    int year = (int)reader["Year"];
                    decimal price = (decimal)reader["Price"];
                    Console.WriteLine($"BookId:{id} Title:{title} Publisher:{publisher} Year:{year} Price:{price}");

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
        public static void Top10(SqlConnection connection)
        {
            SqlDataReader reader = null;
            var query = "select Title,Year,Price from Book where BookId between 1 and 10";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string title = (string)reader["Title"];
                    int year = (int)reader["Year"];
                    decimal price = (decimal)reader["Price"];
                    Console.WriteLine($"Title {title} Year {year} Price {price}");
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
    }
}
