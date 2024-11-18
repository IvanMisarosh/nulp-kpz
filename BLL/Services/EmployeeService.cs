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
    public class EmployeeService : IService<EmployeeDTO>
    {
        private readonly IRepository<IEmployee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<IEmployee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public bool Add(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeDTO>>(_employeeRepository.GetAll());
        }

        public EmployeeDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
