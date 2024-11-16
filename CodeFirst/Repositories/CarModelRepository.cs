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

        public void Add(ICarModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ICarModel entity)
        {
            throw new NotImplementedException();
        }

        public List<ICarModel> GetAll()
        {
            return _context.CarModels.ToList<ICarModel>();
        }


        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(ICarModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
