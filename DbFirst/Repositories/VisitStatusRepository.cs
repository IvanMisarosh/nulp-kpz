using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Abstraction.ModelInterfaces;
using DbFirst.Models;

namespace DbFirst.Repositories
{
    public class VisitStatusRepository : IRepository<IVisitStatus>
    {
        private CarServiceKpzContext _context;

        public VisitStatusRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public void Add(IVisitStatus entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IVisitStatus entity)
        {
            throw new NotImplementedException();
        }

        public List<IVisitStatus> GetAll()
        {
            return _context.VisitStatuses.ToList<IVisitStatus>();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(IVisitStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
