using lab_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Repositories
{
    public class CustomerRepository
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
            _context.SaveChanges();
        }

        public void Update(Customer customer) {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(Customer customer) {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
