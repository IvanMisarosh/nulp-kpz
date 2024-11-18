using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Abstraction.DTOs;
using Abstraction;
using Abstraction.ModelInterfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : Controller
    {
        private readonly IService<CarModelDTO> _carModelService;

        public CarModelController(IService<CarModelDTO> carModelService)
        {
            _carModelService = carModelService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ICarModel>))]
        public IActionResult GetCarModels()
        {
            var carModels = _carModelService.GetAll();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carModels);
        }

    }
}
