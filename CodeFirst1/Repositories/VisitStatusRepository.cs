using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Abstraction.ModelInterfaces;
using CodeFirst1.Models;

namespace CodeFirst1.Repositories
{
    public class VisitStatusRepository : IRepository<IVisitStatus>
    {
        private CarServiceKpzContext _context;

        public VisitStatusRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public bool Add(IVisitStatus entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IVisitStatus entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVisitStatus> GetAll()
        {
            return _context.VisitStatuses.ToList();
        }

        public IVisitStatus GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool Update(IVisitStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
