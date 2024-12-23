﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.ModelInterfaces;


namespace Abstraction
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : class;

        ICar CreateCar();
        ICustomer CreateCustomer();

        IVisit CreateVisit();
    }
}
