using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace LibraryApp.DAL
{
    public class BookRepository: IRepository<Book>
    {
        private readonly SqlConnectionStringBuilder builder;

        public BookRepository()
        {
            builder = new SqlConnectionStringBuilder
            {
                DataSource = "uzlearning.database.windows.net",
                UserID = "ooops",
                Password = "oooops",
                InitialCatalog = "course_db"
            };
        }

        public List<Book> GetAll()
        {
            var books = new List<Book>();

            const string sqlCommand = "SELECT Id, Title, Author FROM Books";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var book = new Book
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Author = reader.GetString(2)
                            };
                            books.Add(book);
                        }
                    }
                }
            }
            return books;
        }

        public void Create(Book entity)
        {
            const string sqlCommand = "INSERT INTO Books (Title, Author) VALUES (@title, @author)";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    command.Parameters.AddWithValue("@title", entity.Title);
                    command.Parameters.AddWithValue("@author", entity.Author);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
