using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models;
using Abstraction;
using Abstraction.ModelInterfaces;

namespace CodeFirst.Repositories
{
    public class ColorRepository: IRepository<IColor>
    {
        private CarServiceKpzContext _context;

        public ColorRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public void Add(IColor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IColor entity)
        {
            throw new NotImplementedException();
        }

        public List<IColor> GetAll()
        {
            return _context.Colors.ToList<IColor>();
        }

        public IColor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(IColor entity)
        {
            throw new NotImplementedException();
        }
    }
}
