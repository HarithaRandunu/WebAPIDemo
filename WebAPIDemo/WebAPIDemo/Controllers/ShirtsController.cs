using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Filters.ActionFilters;
using WebAPIDemo.Filters.ExceptionFilters;
using WebAPIDemo.Models;
using WebAPIDemo.Models.Repositories;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {



        [HttpGet]
        //[Route("/shirts")]    This will not be used due to "[Route("[controller]")]" 
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());
        }




        [HttpGet("{id}")]       // Due to not using [Route("/shirts/{id}")], we have change this command with inserting the relevent input or ID
        [Shirt_ValidateShirtIdFilter]
        //[Route("/shirts/{id}")]
        public IActionResult GetShirtById(int id)   // IActionResult is used when there will be some different return type.
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }



        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        //[Route("/shirts")]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
        }



        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdatesExceptionsFilter]
        //[Route("/shirts/{id}")]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            ShirtRepository.UpdateShirt(shirt);
            return NoContent();
        }



        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        //[Route("/shirts/{id}")]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);

            return Ok($"Deleting a shirt with ID: {id}");
        }


    }
}
