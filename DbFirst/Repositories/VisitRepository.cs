using Abstraction;
using DbFirst.Models;
using Microsoft.EntityFrameworkCore;
using Abstraction.ModelInterfaces;

namespace DbFirst.Repositories
{
    public class VisitRepository: IRepository<IVisit>
    {
        private CarServiceKpzContext _context;
        public VisitRepository(CarServiceKpzContext context)
        {
            _context = context;
        }
        public IEnumerable<IVisit> GetAll()
        {
            //return _context.Visits.ToList();
            return _context.Visits.
                Include(v => v.Car).
                Include(v => v.Employee).
                Include(v => v.PaymentStatus).
                Include(v => v.VisitStatus).ToList();
        }

        public bool Add(IVisit visit)
        {
            var result = _context.Visits.Add((Visit)visit);
            return result.State == EntityState.Added;
        }

        public bool Update(IVisit visit)
        {
            var result = _context.Visits.Update((Visit)visit);
            return result.State == EntityState.Modified;
        }

        public bool Delete(IVisit visit)
        {
            try
            {
                var result = _context.Visits.Remove((Visit)visit);
                return result.State == EntityState.Deleted;
            }
            catch (Exception e)
            {
                var existing = _context.Visits.Find(visit.VisitID);
                if (existing != null)
                {
                    _context.Visits.Remove(existing);
                    return true;
                }
            }
            return false;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IVisit GetById(int id)
        {
            return _context.Visits
                .Include(v => v.Car)
                .Include(v => v.Employee)
                .Include(v => v.PaymentStatus)
                .Include(v => v.VisitStatus)
                .FirstOrDefault(v => v.VisitID == id);
        }

        public bool DeleteById(int id)
        {
            var visit = _context.Visits.Find(id);
            if (visit != null)
            {
                _context.Visits.Remove(visit);
                return true;
            }
            return false;
        }
    }
}
