using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_3.Models;

namespace lab_3.Repositories
{
    public class VisitStatusRepository
    {
        private CarServiceKpzContext _context;

        public VisitStatusRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public List<VisitStatus> GetAll()
        {
            return _context.VisitStatuses.ToList();
        }
    }
}
