using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
