using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Abstraction.ModelInterfaces;
using Abstraction.DTOs;

namespace BLL.Services
{
    public class VisitService : IService<VisitDTO>
    {
        private readonly IRepository<IVisit> _visitRepository;
        private readonly IMapper _mapper;

        public VisitService(IRepository<IVisit> visitRepository, IMapper mapper)
        {
            _visitRepository = visitRepository;
            _mapper = mapper;
        }

        public bool Add(VisitDTO entity)
        {
            var visit = _mapper.Map<IVisit>(entity);
            var result = _visitRepository.Add(visit);
            if (result)
            {
                _visitRepository.SaveChanges();
            }
            return result;
        }

        public IEnumerable<VisitDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<VisitDTO>>(_visitRepository.GetAll());
        }

        public VisitDTO GetById(int id)
        {
            return _mapper.Map<VisitDTO>(_visitRepository.GetById(id));
        }

        public bool Update(VisitDTO entity)
        {
            var result = _visitRepository.Update(_mapper.Map<IVisit>(entity));
            if (result)
            {
                _visitRepository.SaveChanges();
            }
            return result;
        }

        public bool Delete(int id)
        {
            var result = _visitRepository.DeleteById(id);
            if (result)
            {
                _visitRepository.SaveChanges();
            }
            return result;
        }
    }
}
