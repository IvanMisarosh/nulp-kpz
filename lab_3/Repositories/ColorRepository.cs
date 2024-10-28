using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_3.Models;

namespace lab_3.Repositories
{
    public class ColorRepository
    {
        private CarServiceKpzContext _context;

        public ColorRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public List<Color> GetAll()
        {
            return _context.Colors.ToList();
        }
    }
}
