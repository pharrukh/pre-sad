using System;
using System.Data.SqlClient;

namespace LibraryApp.UI
{
    class Program
    {
        static SqlConnectionStringBuilder builder;

        static void Main(string[] args)
        {
            builder = new SqlConnectionStringBuilder();

            builder.DataSource = "uzlearning.database.windows.net";
            builder.UserID = "ooops";
            builder.Password = "oooops";
            builder.InitialCatalog = "course_db";

            Console.WriteLine("WELCOME TO LIBRARY APPLICATION. TYPE COMMAND:");

            var shouldWork = true;
            while (shouldWork)
            {
                var input = Console.ReadKey();
                if(input.KeyChar == 'e')
                {
                    Console.Write(" - Exiting...");
                    shouldWork = false;
                }
                else if (input.KeyChar == 'l')
                {
                    Console.Write(" - Preparing list of books... \n");
                    ShowBookList();
                    Console.WriteLine("Done! Type a command");
                }
                else if(input.KeyChar == 'c')
                {
                    Console.Write(" - Type book title:");
                    var book = new Book();
                    book.Title = Console.ReadLine();
                    Console.Write("Type book author:");
                    book.Author = Console.ReadLine();
                    Console.WriteLine("Saving book...");
                    CreateBook(book);
                    Console.WriteLine("Done! Type a command");
                }
                else
                {
                    Console.Write(" - Wrong command... Try again \n");
                }
            }
        }

        private static void CreateBook(Book book)
        {
            var sqlCommand = "INSERT INTO Books (Title, Author) VALUES (@title, @author)";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    command.Parameters.AddWithValue("@title", book.Title);
                    command.Parameters.AddWithValue("@author", book.Author);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void ShowBookList()
        {
            var sqlCommand = "SELECT Id, Title, Author FROM Books";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("ID: {0}, Title: {1}, Author: {2}",
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2));
                        }
                    }
                }
            }
        }
    }
}
