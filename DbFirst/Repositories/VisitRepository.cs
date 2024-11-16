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
        public List<IVisit> GetAll()
        {
            //return _context.Visits.ToList();
            return _context.Visits.
                Include(v => v.Car).
                Include(v => v.Employee).
                Include(v => v.PaymentStatus).
                Include(v => v.VisitStatus).ToList<IVisit>();
        }

        public void Add(IVisit visit)
        {
            _context.Visits.Add((Visit)visit);
        }

        public void Update(IVisit visit)
        {
            _context.Visits.Update((Visit)visit);
        }

        public void Delete(IVisit visit)
        {
            try
            {
                _context.Visits.Remove((Visit)visit);
            }
            catch (Exception e)
            {
                var existing = _context.Visits.Find(visit.VisitID);
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
