using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DAL
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        void Create(T entity);
    }
}
