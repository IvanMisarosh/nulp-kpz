using lab_3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab_3.Repositories
{
    public class VisitRepository: IRepository<Visit>
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
        }

        public void Update(Visit visit)
        {
            _context.Visits.Update(visit);
        }

        public void Delete(Visit visit)
        {
            try
            {
                _context.Visits.Remove(visit);
            }
            catch (Exception e)
            {
                var existing = _context.Visits.Find(visit.VisitId);
                if (existing != null)
                {
                    _context.Visits.Remove(existing);
                }
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
