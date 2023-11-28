using Application.Commands.Dogs.AddDog;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Application.Queries.Dogs.GetAllDogs;
using Application.Queries.Dogs.GetDogById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            return Ok(await _midiatR.Send(new AddDogCommand(newDog)));
        }

        // Update a specific dog by Id
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            return Ok(await _midiatR.Send(new UpdateDogByIdCommand(updatedDog, updatedDogId)));
        }
        // Delete a specific dog by Id
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("deleteDog/{deletedDogId}")]
        public async Task<IActionResult> DeleteDog(Guid deletedDogId)
        {
            return Ok(await _midiatR.Send(new DeleteDogByIdCommand(deletedDogId)));
        }

    }
}
