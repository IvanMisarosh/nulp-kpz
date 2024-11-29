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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddCar([FromBody] CarDTO car)
        {
            if (!ModelState.IsValid)
            {
                // Return detailed validation errors
                return BadRequest(new
                {
                    Message = "Validation failed for the request.",
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                });
            }

            try
            {
                var result = _carService.Add(car);

                if (!result)
                {
                    // Return a custom error message if the service fails
                    return BadRequest(new
                    {
                        Message = "Unable to add the car. Please verify the data and try again.",
                        Hint = "Ensure that the car details, such as VIN or model, are unique and valid."
                    });
                }

                // Return success with the created resource URI
                return CreatedAtAction("GetCar", new { id = car.CarID }, car);
            }
            catch (Exception ex)
            {
                // Return detailed information about unexpected errors
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Error = ex.Message,
                    StackTrace = ex.StackTrace // Avoid exposing this in production
                });
            }
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
