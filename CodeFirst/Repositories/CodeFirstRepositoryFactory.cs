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
    public class CodeFirstRepositoryFactory : IRepositoryFactory
    {
        private readonly CarServiceKpzContext _context;

        public CodeFirstRepositoryFactory(CarServiceKpzContext context)
        {
            _context = context;
        }

        public IVisit CreateVisit()
        {
            throw new NotImplementedException();
        }

        public ICar CreateCar()
        {
            throw new NotImplementedException();
        }

        public ICustomer CreateCustomer()
        {
            throw new NotImplementedException();
        }

        public T CreateNew<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (typeof(T) == typeof(Car))
                return (IRepository<T>)new CarRepository(_context);

            if (typeof(T) == typeof(CarModel))
                return (IRepository<T>)new CarModelRepository(_context);

            if (typeof(T) == typeof(Customer))
                return (IRepository<T>)new CustomerRepository(_context);

            if (typeof(T) == typeof(Employee))
                return (IRepository<T>)new EmployeeRepository(_context);

            if (typeof(T) == typeof(PaymentStatus))
                return (IRepository<T>)new PaymentStatusRepository(_context);

            if (typeof(T) == typeof(Visit))
                return (IRepository<T>)new VisitRepository(_context);

            if (typeof(T) == typeof(VisitStatus))
                return (IRepository<T>)new VisitStatusRepository(_context);

            throw new NotSupportedException($"No repository found for type {typeof(T).Name}");
        }
    }
}
