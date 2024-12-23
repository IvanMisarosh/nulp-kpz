﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Abstraction.ModelInterfaces;
using CodeFirst1.Models;

namespace CodeFirst1.Repositories
{
    public class EmployeeRepository : IRepository<IEmployee>
    {
        private CarServiceKpzContext _context;

        public EmployeeRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public bool Add(IEmployee entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IEmployee entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEmployee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public IEmployee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool Update(IEmployee entity)
        {
            throw new NotImplementedException();
        }
    }
}
