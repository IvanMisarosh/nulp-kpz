using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Abstraction.DTOs;
using Abstraction;
using Abstraction.ModelInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColorController : Controller
    {
        private readonly IService<ColorDTO> _colorService;

        public ColorController(IService<ColorDTO> colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IColor>))]
        public IActionResult GetColors()
        {
            var colors = _colorService.GetAll();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(colors);
        }
    }
}
