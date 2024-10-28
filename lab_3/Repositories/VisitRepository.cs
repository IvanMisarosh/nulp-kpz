using lab_3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab_3.Repositories
{
    public class VisitRepository
    {
        private CarServiceKpzContext _context;
        public VisitRepository(CarServiceKpzContext context)
        {
            _context = context;
        }
        public List<Visit> GetAll()
        {
            //return _context.Visits.ToList();
            return _context.Visits.
                Include(v => v.Car).
                Include(v => v.Employee).
                Include(v => v.PaymentStatus).
                Include(v => v.VisitStatus).ToList();
        }

        public void Add(Visit visit)
        {
            _context.Visits.Add(visit);
            _context.SaveChanges();
        }

        public void Update(Visit visit)
        {
            _context.Visits.Update(visit);
            _context.SaveChanges();
        }

        public void Delete(Visit visit)
        {
            _context.Visits.Remove(visit);
            _context.SaveChanges();
        }
    }
}
