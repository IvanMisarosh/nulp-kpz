﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Abstraction.ModelInterfaces;
using DbFirst.Models;

namespace DbFirst.Repositories
{
    public class DbFirstRepositoryFactory : IRepositoryFactory
    {
        private readonly CarServiceKpzContext _context;

        public DbFirstRepositoryFactory(CarServiceKpzContext context)
        {
            _context = context;
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

        public ICar CreateCar()
        {
            return new Car(); // Повертаємо конкретну реалізацію
        }

        public ICustomer CreateCustomer()
        {
            return new Customer(); // Повертаємо конкретну реалізацію
        }

        public IVisit CreateVisit()
        {
            return new Visit(); // Повертаємо конкретну реалізацію

        }
    }
}
