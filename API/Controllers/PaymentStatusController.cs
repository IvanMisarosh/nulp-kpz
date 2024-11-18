using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using Abstraction.DTOs;
using Abstraction;
using Abstraction.ModelInterfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentStatusController : Controller
    {
        private readonly IService<PaymentStatusDTO> _paymentStatusService;

        public PaymentStatusController(IService<PaymentStatusDTO> paymentStatusService)
        {
            _paymentStatusService = paymentStatusService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IPaymentStatus>))]
        public IActionResult GetPaymentStatuses()
        {
            var paymentStatuses = _paymentStatusService.GetAll();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(paymentStatuses);
        }
    }
}
