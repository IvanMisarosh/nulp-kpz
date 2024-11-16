using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using CodeFirst.Models;


namespace CodeFirst.Repositories
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
                .Include("CarModel")   // Use string path instead of lambda
                .Include("Color")      // Use string path instead of lambda
                .Include("Customer")   // Use string path instead of lambda
                .ToList();
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
        }

        public void Update(Car car)
        {
            //_context.Cars.Update(car);
            _context.Entry(car).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Car car)
        {
            try
            {
                _context.Cars.Remove(car);
            }
            catch (Exception e)
            {
                var existing = _context.Cars.Find(car.CarID);
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
