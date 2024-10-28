using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_3.Models;

namespace lab_3.Repositories
{
    public class PaymentStatusRepository
    {
        private CarServiceKpzContext _context;

        public PaymentStatusRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public List<PaymentStatus> GetAll()
        {
            return _context.PaymentStatuses.ToList();
        }
    }
}
