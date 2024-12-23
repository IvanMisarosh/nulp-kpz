﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool DeleteById(int id);
        void SaveChanges();
    }
}
