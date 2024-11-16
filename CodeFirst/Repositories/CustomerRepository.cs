using Abstraction;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private CarServiceKpzContext _context;
        public CustomerRepository(CarServiceKpzContext context) 
        {
            _context = context;
        }
        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer) {
            //_context.Customers.Update(customer);
            _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Customer customer) {
            try 
            {
                _context.Customers.Attach(customer);
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
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
