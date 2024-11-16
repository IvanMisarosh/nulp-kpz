using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Abstraction.ModelInterfaces;
using CodeFirst.Models;

namespace CodeFirst.Repositories
{
    public class EmployeeRepository : IRepository<IEmployee>
    {
        private CarServiceKpzContext _context;

        public EmployeeRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public void Add(IEmployee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEmployee entity)
        {
            throw new NotImplementedException();
        }

        public List<IEmployee> GetAll()
        {
            return _context.Employees.ToList<IEmployee>();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(IEmployee entity)
        {
            throw new NotImplementedException();
        }
    }
}
