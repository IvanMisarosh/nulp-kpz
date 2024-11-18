using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.DTOs;
using Abstraction;
using Abstraction.ModelInterfaces;

namespace BLL.Services
{
    public class CarModelService : IService<CarModelDTO>
    {
        private readonly IRepository<ICarModel> _carModelRepository;
        private readonly IMapper _mapper;

        public CarModelService(IRepository<ICarModel> carModelRepository, IMapper mapper)
        {
            _carModelRepository = carModelRepository;
            _mapper = mapper;
        }

        public bool Add(CarModelDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarModelDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<CarModelDTO>>(_carModelRepository.GetAll());
        }

        public CarModelDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(CarModelDTO entity)
        {
            throw new NotImplementedException();
        }
    }

}
