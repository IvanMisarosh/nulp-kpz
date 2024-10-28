using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_3.Models;

namespace lab_3.Repositories
{
    public class CarModelRepository
    {
        private CarServiceKpzContext _context;

        public CarModelRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public List<CarModel> GetAll()
        {
            return _context.CarModels.ToList();
        }
    }
}
