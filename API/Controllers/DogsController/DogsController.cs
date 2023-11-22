using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.Dogs;
using Application.Queries.Dogs.GetDogById;
using Application.Queries.Dogs.GetAllDogs;
using Application.Commands.Dogs.AddDog;
using Application.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _midiatR;

        public DogsController(IMediator midiatR)
        {
            _midiatR = midiatR;
        }

        // Get all dogs from database
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            return Ok(await _midiatR.Send(new GetAllDogsQuery()));
            // return ok ("get alla dogs")
        }

        // Get a dog by Id
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            return Ok(await _midiatR.Send(new GetDogByIdQuery(dogId)));
            // return ok ("get a dog by Id")
        }


        // Create a new dog
        [HttpPost]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            return Ok(await _midiatR.Send(new AddDogCommand(newDog)));
        }

        //// PUT api/<DogsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DogsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
