using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.DTOs;
using Abstraction;
using Abstraction.ModelInterfaces;
using AutoMapper;

namespace BLL.Services
{
    public class ColorService: IService<ColorDTO>
    {
        private readonly IRepository<IColor> _colorRepository;
        private readonly IMapper _mapper;

        public ColorService(IRepository<IColor> colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public bool Add(ColorDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ColorDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ColorDTO>>(_colorRepository.GetAll());
        }

        public ColorDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ColorDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
