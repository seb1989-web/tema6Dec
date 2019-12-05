using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CrudBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source = .; Initial Catalog = Tema6Dec; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            Insert(connection);
            //Print(connection);
            //Update(connection);
            //Delete(connection);
            //Select(connection);

            Console.ReadLine();
        }
        public static void Insert(SqlConnection connection)
        {
            Console.WriteLine("Insert data:");
            var data = Console.ReadLine();
            SqlParameter param = new SqlParameter("@data", data);
            var query = "insert into Book values " + @data;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(param);
            command.ExecuteNonQuery();

        }
        public static void Print(SqlConnection connection)
        {
            var query = "select BookId from Book where Title = 'Carte10'";
            SqlCommand command = new SqlCommand(query, connection);
            var id = command.ExecuteScalar();
            Console.WriteLine($"The book Carte10 has the id {id}");
        }
        public static void Update(SqlConnection connection)
        {
            Console.Write("Update Title for book with BookId:");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Replacement name:");
            var name = Console.ReadLine();
            SqlParameter param = new SqlParameter("@id", id);
            SqlParameter param2 = new SqlParameter("@name", name);
            var query = "update Book set Title = @name where BookId =@id ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(param);
            command.Parameters.Add(param2);
            command.ExecuteNonQuery();
            
        }
        public static void Delete(SqlConnection connection)
        {
            Console.Write("Delete Book with Title:");
            var title = Console.ReadLine();
            SqlParameter param = new SqlParameter("@title", title);
            var query = "delete from Book where Title = @title";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }
        public static void Select(SqlConnection connection)
        {
            SqlDataReader reader = null;
            Console.Write("Print details for book with Title:");
            var book = Console.ReadLine();
            SqlParameter param = new SqlParameter("@book", book);
            var query = "select * from Book where Title = @book";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(param);
            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
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
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
