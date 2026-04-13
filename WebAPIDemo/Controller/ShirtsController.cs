using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Filters;
using WebAPIDemo.Model;
using WebAPIDemo.Model.Repositories;

namespace WebAPIDemo.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok("Reading all the shirts");
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {
            return Ok("Creating a new shirt");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"Deleting the shirt with id {id}");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShirt(int id)
        {
            return Ok($"Updating the shirt with id {id}");
        }
    }
}
