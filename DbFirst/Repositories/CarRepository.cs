using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirst.Repositories
{

    public class CarRepository: IRepository<Car>
    {
        private CarServiceKpzContext _context;

        public CarRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public List<Car> GetAll()
        {
            //return _context.Cars.ToList();
            return _context.Cars
            .Include(car => car.CarModel)  // Include CarModel
            .Include(car => car.Color)      // Include Color
            .Include(car => car.Customer)   // Include Customer
            .ToList();
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
        }

        public void Update(Car car)
        {
            _context.Cars.Update(car);
        }

        public void Delete(Car car)
        {
            try
            {
                _context.Cars.Remove(car);
            }
            catch (Exception e)
            {
                var existing = _context.Cars.Find(car.CarId);
                if (existing != null)
                {
                    _context.Cars.Remove(existing);
                }
            }

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
