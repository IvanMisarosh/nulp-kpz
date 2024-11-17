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
    public class ColorRepository : IRepository<IColor>
    {
        private readonly CarServiceKpzContext _context;

        public ColorRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public bool Add(IColor entity)
        {
            bool result = false;
            if (entity is Color color)
            {
                var res = _context.Colors.Add(color);
                result = res.State == Microsoft.EntityFrameworkCore.EntityState.Added;
                SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
            return result;
        }

        public bool Delete(IColor entity)
        {
            if (entity is Color color)
            {
                _context.Colors.Remove(color);
                SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
            //TODO: check if the entity is being tracked by the context
            return true;
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
            _context.SaveChanges();
        }

        public bool Update(IColor entity)
        {
            if (entity is Color color)
            {
                _context.Colors.Update(color);
                SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
            //TODO: check if the entity was updated
            return true;
        }
    }
}
