using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DAL
{
    public interface IBookRepository
    {
        List<Book> GetAll();

        void Create(Book book);
    }
}
