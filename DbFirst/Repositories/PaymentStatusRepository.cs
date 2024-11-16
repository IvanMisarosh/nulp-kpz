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
    public class PaymentStatusRepository : IRepository<IPaymentStatus>
    {
        private CarServiceKpzContext _context;

        public PaymentStatusRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public void Add(IPaymentStatus entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IPaymentStatus entity)
        {
            throw new NotImplementedException();
        }

        public List<IPaymentStatus> GetAll()
        {
            return _context.PaymentStatuses.ToList<IPaymentStatus>();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(IPaymentStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
