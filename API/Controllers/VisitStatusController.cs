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
    public class VisitStatusController : Controller
    {
        private readonly IService<VisitStatusDTO> _visitStatusService;

        public VisitStatusController(IService<VisitStatusDTO> visitStatusService)
        {
            _visitStatusService = visitStatusService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IVisitStatus>))]
        public IActionResult GetVisitStatuses()
        {
            var visitStatuses = _visitStatusService.GetAll();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(visitStatuses);
        }
    }
}
