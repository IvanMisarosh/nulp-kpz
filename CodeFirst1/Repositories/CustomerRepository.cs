using Abstraction;
using Abstraction.ModelInterfaces;
using CodeFirst1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst1.Repositories
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        private CarServiceKpzContext _context;
        public CustomerRepository(CarServiceKpzContext context) 
        {
            _context = context;
        }
        public IEnumerable<ICustomer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public ICustomer GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        public bool Add(ICustomer customer)
        {
            var result = _context.Customers.Add((Customer)customer);
            return result.State == Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public bool Update(ICustomer customer) {
            var result = _context.Customers.Update((Customer)customer);
            return result.State == Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public bool Delete(ICustomer customer) {
            try 
            {
                _context.Customers.Attach((Customer)customer);
            }
            catch (InvalidOperationException)
            {
                // if the entity is not being tracked by the context
                // we need to find it first
                var existing = _context.Customers.Find(customer.CustomerID);
                if (existing != null)
                {
                    _context.Customers.Remove(existing);
                }
            }
            //TODO: check if the entity is being tracked by the context
            return true;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool DeleteById(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                return true;
            }
            return false;
        }
    }
}
