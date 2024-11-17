using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Abstraction;
using Abstraction.DTOs;
using Abstraction.ModelInterfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly IService<CarDTO> _carService;

        public CarController(IService<CarDTO> carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ICar>))]
        public IActionResult GetCars()
        {
            var cars = _carService.GetAll();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(cars);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICar))]
        public IActionResult GetCar(int id)
        {
            var car = _carService.GetById(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddCar([FromBody] CarDTO car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _carService.Add(car);

            if (!result)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetCar", new { id = car.CarID }, car);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateCar(int id, [FromBody] CarDTO car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.CarID)
            {
                return BadRequest();
            }

            var result = _carService.Update(car);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteCar(int id)
        {
            var result = _carService.Delete(id);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
