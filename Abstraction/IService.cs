using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        //void SaveChanges();
    }
}
