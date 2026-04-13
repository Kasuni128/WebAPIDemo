using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetShirtById(int id)
        {
            if(id <= 0)
                return BadRequest("Invalid shirt id. Id must be greater than 0.");
            
            var shirt = ShirtRepository.GetShirtById(id);
            if(shirt == null)
                return NotFound();
            return Ok(shirt);
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
