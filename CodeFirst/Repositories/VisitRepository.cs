using Abstraction;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst.Repositories
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
                Include("Car").
                Include("Employee").
                Include("PaymentStatus").
                Include("VisitStatus").
                ToList();
        }

        public void Add(Visit visit)
        {
            _context.Visits.Add(visit);
        }

        public void Update(Visit visit)
        {
            //_context.Visits.Update(visit);
            _context.Entry(visit).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Visit visit)
        {
            try
            {
                _context.Visits.Remove(visit);
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
