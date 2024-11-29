using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst1.Models;
using Abstraction;
using Abstraction.ModelInterfaces;

namespace CodeFirst1.Repositories
{
    public class ColorRepository: IRepository<IColor>
    {
        private CarServiceKpzContext _context;

        public ColorRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public bool Add(IColor entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IColor entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IColor> GetAll()
        {
            return _context.Colors.ToList();
        }

        public IColor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool Update(IColor entity)
        {
            throw new NotImplementedException();
        }


    }
}
