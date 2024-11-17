using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Abstraction.ModelInterfaces;
using CodeFirst.Models;


namespace CodeFirst.Repositories
{

    public class CarRepository: IRepository<ICar>
    {
        private CarServiceKpzContext _context;

        public CarRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public IEnumerable<ICar> GetAll()
        {
            //return _context.Cars.ToList();
            return _context.Cars
                .Include("CarModel")   // Use string path instead of lambda
                .Include("Color")      // Use string path instead of lambda
                .Include("Customer")   // Use string path instead of lambda
                .ToList();
        }

        public bool Add(ICar car)
        {
            var result = _context.Cars.Add((Car)car);
            //return result.State == System.Data.Entity.EntityState.Added;
            return true;
        }

        public bool Update(ICar car)
        {
            //_context.Cars.Update(car);
            _context.Entry((Car)car).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            //TODO: check if the entity was updated
            return true;
        }

        public bool Delete(ICar car)
        {
            try
            {
                _context.Cars.Remove((Car)car);
            }
            catch (Exception e)
            {
                var existing = _context.Cars.Find(car.CarID);
                if (existing != null)
                {
                    _context.Cars.Remove(existing);
                }
            }
            //TODO: check if the entity was deleted
            return true;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public ICar GetById(int id)
        {
            return _context.Cars
                .Include("CarModel")   // Use string path instead of lambda
                .Include("Color")      // Use string path instead of lambda
                .Include("Customer")   // Use string path instead of lambda
                .FirstOrDefault(car => car.CarID == id);
        }

        public bool DeleteById(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                return true;
            }
            return false;
        }
    }
}
