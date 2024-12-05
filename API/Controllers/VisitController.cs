using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using Abstraction.DTOs;
using Abstraction.ModelInterfaces;
using Abstraction;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VisitController : Controller
    {
        private readonly IService<VisitDTO> _VisitService;

        public VisitController(IService<VisitDTO> visitService)
        {
            _VisitService = visitService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IVisit>))]
        public IActionResult GetVisits()
        {
            var visits = _VisitService.GetAll();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(visits);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IVisit))]
        public IActionResult GetVisit(int id)
        {
            var visit = _VisitService.GetById(id);

            if (visit == null)
            {
                return NotFound();
            }

            return Ok(visit);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddVisit([FromBody] VisitDTO visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _VisitService.Add(visit);

            if (!result)
            {
                return BadRequest();
            }

            return Created("GetVisit", visit);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateVisit(int id, [FromBody] VisitDTO visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _VisitService.Update(visit);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(visit);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteVisit(int id)
        {
            var result = _VisitService.Delete(id);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
