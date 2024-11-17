using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Abstraction.ModelInterfaces;
using Abstraction.DTOs;
using AutoMapper;

namespace BLL.Services
{
    public class CarService : IService<CarDTO>
    {
        private readonly IRepository<ICar> _carRepository;
        private readonly IMapper _mapper;

        public CarService(IRepository<ICar> carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public bool Add(CarDTO entity)
        {
            var car = _mapper.Map<ICar>(entity);
            var result = _carRepository.Add(car);
            if (result)
            {
                _carRepository.SaveChanges();
            }
            return result;
        }

        public bool Delete(int id)
        {
            var result = _carRepository.Delete(_carRepository.GetById(id));
            if (result)
            {
                _carRepository.SaveChanges();
            }
            return result;
        }

        public IEnumerable<CarDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<CarDTO>>(_carRepository.GetAll());
        }

        public CarDTO GetById(int id)
        {
            return _mapper.Map<CarDTO>(_carRepository.GetById(id));
        }

        public bool Update(CarDTO entity)
        {
            var result = _carRepository.Update(_mapper.Map<ICar>(entity));
            if (result)
            {
                _carRepository.SaveChanges();
            }
            return result;
        }
    }
}
