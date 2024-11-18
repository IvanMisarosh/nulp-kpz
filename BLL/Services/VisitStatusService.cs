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
    public class VisitStatusService: IService<VisitStatusDTO>
    {
        private readonly IRepository<IVisitStatus> _visitStatusRepository;
        private readonly IMapper _mapper;

        public VisitStatusService(IRepository<IVisitStatus> visitStatusRepository, IMapper mapper)
        {
            _visitStatusRepository = visitStatusRepository;
            _mapper = mapper;
        }

        public bool Add(VisitStatusDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VisitStatusDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<VisitStatusDTO>>(_visitStatusRepository.GetAll());
        }

        public VisitStatusDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(VisitStatusDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
