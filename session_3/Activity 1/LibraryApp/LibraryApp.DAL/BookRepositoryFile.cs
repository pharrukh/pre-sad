using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DAL
{
    public class BookRepositoryFile : IBookRepository
    {
        public void Create(Book book)
        {
            //here hould be code to add new book to file
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            //here should be code to get all books from file
            throw new NotImplementedException();
        }
    }
}
