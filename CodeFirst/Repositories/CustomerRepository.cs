using Abstraction;
using Abstraction.ModelInterfaces;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeFirst.Repositories
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        private CarServiceKpzContext _context;
        public CustomerRepository(CarServiceKpzContext context) 
        {
            _context = context;
        }
        public List<ICustomer> GetAll()
        {
            return _context.Customers.ToList<ICustomer>();
        }

        public void Add(ICustomer customer)
        {
            _context.Customers.Add((Customer)customer);
        }

        public void Update(ICustomer customer) {
            //_context.Customers.Update(customer);
            _context.Entry((Customer)customer).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(ICustomer customer) {
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
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
