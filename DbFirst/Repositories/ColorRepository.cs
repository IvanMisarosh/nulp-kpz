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

        public void Add(IColor entity)
        {
            if (entity is Color color)
            {
                _context.Colors.Add(color);
                SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
        }

        public void Delete(IColor entity)
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
        }

        public List<IColor> GetAll()
        {
            return _context.Colors.Cast<IColor>().ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(IColor entity)
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
        }
    }
}
