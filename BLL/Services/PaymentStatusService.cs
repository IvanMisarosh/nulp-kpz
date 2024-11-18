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
    public class PaymentStatusService : IService<PaymentStatusDTO>
    {
        private readonly IRepository<IPaymentStatus> _paymentStatusRepository;
        private readonly IMapper _mapper;

        public PaymentStatusService(IRepository<IPaymentStatus> paymentStatusRepository, IMapper mapper)
        {
            _paymentStatusRepository = paymentStatusRepository;
            _mapper = mapper;
        }

        public bool Add(PaymentStatusDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentStatusDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<PaymentStatusDTO>>(_paymentStatusRepository.GetAll());
        }

        public PaymentStatusDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(PaymentStatusDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
