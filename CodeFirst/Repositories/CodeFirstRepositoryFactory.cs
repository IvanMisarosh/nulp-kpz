using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Abstraction.ModelInterfaces;
using CodeFirst1.Models;

namespace CodeFirst1.Repositories
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
            return new Visit();
        }

        public ICar CreateCar()
        {
            return new Car();
        }

        public ICustomer CreateCustomer()
        {
            return new Customer();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (typeof(T) == typeof(ICar))
                return (IRepository<T>)new CarRepository(_context);

            if (typeof(T) == typeof(ICarModel))
                return (IRepository<T>)new CarModelRepository(_context);

            if (typeof(T) == typeof(ICustomer))
                return (IRepository<T>)new CustomerRepository(_context);

            if (typeof(T) == typeof(IEmployee))
                return (IRepository<T>)new EmployeeRepository(_context);

            if (typeof(T) == typeof(IPaymentStatus))
                return (IRepository<T>)new PaymentStatusRepository(_context);

            if (typeof(T) == typeof(IVisit))
                return (IRepository<T>)new VisitRepository(_context);

            if (typeof(T) == typeof(IVisitStatus))
                return (IRepository<T>)new VisitStatusRepository(_context);

            if (typeof(T) == typeof(IColor))
                return (IRepository<T>)new ColorRepository(_context);

            throw new NotSupportedException($"No repository found for type {typeof(T).Name}");
        }
    }
}
