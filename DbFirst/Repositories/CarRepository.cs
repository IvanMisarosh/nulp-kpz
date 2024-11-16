using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using DbFirst.Models;
using Abstraction.ModelInterfaces;
using Microsoft.EntityFrameworkCore;

namespace DbFirst.Repositories
{

    public class CarRepository : IRepository<ICar>
    {
        private readonly CarServiceKpzContext _context;

        public CarRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public List<ICar> GetAll()
        {
            return _context.Cars
                .Include(car => car.CarModel)
                .Include(car => car.Color)
                .Include(car => car.Customer)
                .ToList<ICar>();
        }

        public void Add(ICar entity)
        {
            _context.Cars.Add((Car)entity);
        }

        public void Update(ICar entity)
        {
            _context.Cars.Update((Car)entity);
        }

        public void Delete(ICar entity)
        {
            _context.Cars.Remove((Car)entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public ICar GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
