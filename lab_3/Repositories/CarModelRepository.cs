using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_3.Models;

namespace lab_3.Repositories
{
    public class CarModelRepository: IRepository<CarModel>
    {
        private CarServiceKpzContext _context;

        public CarModelRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public void Add(CarModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CarModel entity)
        {
            throw new NotImplementedException();
        }

        public List<CarModel> GetAll()
        {
            return _context.CarModels.ToList();
        }


        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(CarModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
