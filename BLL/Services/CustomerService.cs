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
    public class CustomerService: IService<CustomerDTO>
    {
        private readonly IRepository<ICustomer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<ICustomer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public bool Add(CustomerDTO entity)
        {
            var customer = _mapper.Map<ICustomer>(entity);
            var result = _customerRepository.Add(customer);
            if (result)
            {
                _customerRepository.SaveChanges();
            }
            return result;
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerDTO>>(_customerRepository.GetAll());
        }

        public CustomerDTO GetById(int id)
        {
            return _mapper.Map<CustomerDTO>(_customerRepository.GetById(id));
        }

        public bool Update(CustomerDTO entity)
        {
            var result = _customerRepository.Update(_mapper.Map<ICustomer>(entity));
            if (result)
            {
                _customerRepository.SaveChanges();
            }
            return result;
        }

        public bool Delete(int id)
        {
            var result = _customerRepository.DeleteById(id);
            if (result)
            {
                _customerRepository.SaveChanges();
            }
            return result;
        }
    }
}
