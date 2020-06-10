using LibraryApp.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.BLL
{
    public class BookService
    {
        private readonly IRepository<Book> _repo;

        public BookService(IRepository<Book> repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Validates book properties and creates a record using related repository
        /// </summary>
        /// <param name="book">Book instance</param>
        public void CreateBook(Book book)
        {
            if(book == null)
            {
                throw new ArgumentNullException("book", "Book is missing");
            }

            if(string.IsNullOrEmpty(book.Title))
            {
                throw new ArgumentNullException("book.Title", "Book Title is missing");
            }

            if (string.IsNullOrEmpty(book.Author))
            {
                throw new ArgumentNullException("book.Author", "Book Author is missing");
            }

            _repo.Create(book);
        }
    }
}
