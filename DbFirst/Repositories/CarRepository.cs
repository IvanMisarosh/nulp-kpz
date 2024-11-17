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

        public IEnumerable<ICar> GetAll()
        {
            return _context.Cars
                .Include(car => car.CarModel)
                .Include(car => car.Color)
                .Include(car => car.Customer)
                .ToList();
        }

        public bool Add(ICar entity)
        {
            var result = _context.Cars.Add((Car)entity);
            return result.State == Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public bool Update(ICar entity)
        {
            var result = _context.Cars.Update((Car)entity);
            return result.State == Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public bool Delete(ICar entity)
        {
            var result = _context.Cars.Remove((Car)entity);
            return result.State == Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public ICar GetById(int id)
        {
            return _context.Cars
                .Include(car => car.CarModel)
                .Include(car => car.Color)
                .Include(car => car.Customer)
                .FirstOrDefault(car => car.CarID == id);
        }

        public bool DeleteById(int id)
        {
            var car = GetById(id);
            if (car != null)
            {
                var result = _context.Cars.Remove((Car)car);
                return result.State == Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            else
            {
                return false;
            }
        }
    }
}
