using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_3.Models;

namespace lab_3.Repositories
{
    public class PaymentStatusRepository : IRepository<PaymentStatus>
    {
        private CarServiceKpzContext _context;

        public PaymentStatusRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public void Add(PaymentStatus entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PaymentStatus entity)
        {
            throw new NotImplementedException();
        }

        public List<PaymentStatus> GetAll()
        {
            return _context.PaymentStatuses.ToList();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(PaymentStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
