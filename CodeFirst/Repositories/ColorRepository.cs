using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models;
using Abstraction;

namespace CodeFirst.Repositories
{
    public class ColorRepository: IRepository<Color>
    {
        private CarServiceKpzContext _context;

        public ColorRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public void Add(Color entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Color entity)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _context.Colors.ToList();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
