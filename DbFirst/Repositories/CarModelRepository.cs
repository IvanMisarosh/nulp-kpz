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

        public void Add(ICarModel entity)
        {
            if (entity is CarModel carModel)
            {
                _context.CarModels.Add(carModel);
                SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
        }

        public void Delete(ICarModel entity)
        {
            if (entity is CarModel carModel)
            {
                _context.CarModels.Remove(carModel);
                SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
        }

        public List<ICarModel> GetAll()
        {
            return _context.CarModels.Cast<ICarModel>().ToList();
        }

        public ICarModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(ICarModel entity)
        {
            if (entity is CarModel carModel)
            {
                _context.CarModels.Update(carModel);
                SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
        }
    }
}
