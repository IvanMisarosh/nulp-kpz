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
    public class CarModelRepository: IRepository<ICarModel>
    {
        private CarServiceKpzContext _context;

        public CarModelRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public bool Add(ICarModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ICarModel entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Update(ICarModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
