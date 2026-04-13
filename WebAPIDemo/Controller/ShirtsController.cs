using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Filters;
using WebAPIDemo.Filters.ActionFilter;
using WebAPIDemo.Filters.ExceptionFilter;
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
            return Ok(ShirtRepository.GetAllShirts());
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {       
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtById), new { id = shirt.ShirtId }, shirt);    
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
           
            return Ok($"Deleting the shirt with id {id}");
        }

        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExpectionFilter]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            ShirtRepository.UpdateShirt(shirt);
            
            return NoContent();
        }
    }
}
