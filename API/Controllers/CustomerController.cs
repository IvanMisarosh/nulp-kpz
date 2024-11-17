using Abstraction;
using Abstraction.ModelInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using Abstraction.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IService<CustomerDTO> _customerService;

        public CustomerController(IService<CustomerDTO> customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ICustomer>))]
        public IActionResult GetCustomers()
        {
            var customers = _customerService.GetAll();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(customers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICustomer))]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddCustomer([FromBody] CustomerDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _customerService.Add(customer);

            if (!result)
            {
                return BadRequest();
            }



            return CreatedAtAction("GetCustomer", new { id = customer.CustomerID }, customer);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerDTO customer)
        {
            if (id != customer.CustomerID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _customerService.Update(customer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            var result = _customerService.Delete(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
