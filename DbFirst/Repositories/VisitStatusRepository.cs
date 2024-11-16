using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using DbFirst.Models;

namespace DbFirst.Repositories
{
    public class VisitStatusRepository : IRepository<VisitStatus>
    {
        private CarServiceKpzContext _context;

        public VisitStatusRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public void Add(VisitStatus entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(VisitStatus entity)
        {
            throw new NotImplementedException();
        }

        public List<VisitStatus> GetAll()
        {
            return _context.VisitStatuses.ToList();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(VisitStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
