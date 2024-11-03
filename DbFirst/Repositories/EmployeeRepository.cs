using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbFirst.Models;

namespace DbFirst.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private CarServiceKpzContext _context;

        public EmployeeRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
