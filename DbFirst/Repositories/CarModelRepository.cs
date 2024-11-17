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
    public class CarModelRepository : IRepository<ICarModel>
    {
        private readonly CarServiceKpzContext _context;

        public CarModelRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public bool Add(ICarModel entity)
        {
            if (entity is CarModel carModel)
            {
                var result = _context.CarModels.Add(carModel);
                SaveChanges();
                return result.State == Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
        }

        public bool Delete(ICarModel entity)
        {
            if (entity is CarModel carModel)
            {
                _context.CarModels.Remove(carModel);
                SaveChanges();
                return true;
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }

        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICarModel> GetAll()
        {
            return _context.CarModels.ToList();
        }

        public ICarModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool Update(ICarModel entity)
        {
            if (entity is CarModel carModel)
            {
                _context.CarModels.Update(carModel);
                SaveChanges();
                return true;
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
        }
    }
}
