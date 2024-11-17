﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using CodeFirst.Models;
using Abstraction.ModelInterfaces;

namespace CodeFirst.Repositories
{
    public class PaymentStatusRepository : IRepository<IPaymentStatus>
    {
        private CarServiceKpzContext _context;

        public PaymentStatusRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public bool Add(IPaymentStatus entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IPaymentStatus entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPaymentStatus> GetAll()
        {
            //return _context.PaymentStatuses.ToList();
            return _context.PaymentStatus.ToList();
        }

        public IPaymentStatus GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool Update(IPaymentStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
