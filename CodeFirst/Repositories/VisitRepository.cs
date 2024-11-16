using Abstraction;
using Abstraction.ModelInterfaces;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst.Repositories
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
                Include("Car").
                Include("Employee").
                Include("PaymentStatus").
                Include("VisitStatus").
                ToList<IVisit>();
        }

        public void Add(IVisit visit)
        {
            _context.Visits.Add((Visit)visit);
        }

        public void Update(IVisit visit)
        {
            //_context.Visits.Update(visit);
            _context.Entry((Visit)visit).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
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

        public IVisit GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
