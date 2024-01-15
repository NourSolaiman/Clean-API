using Application.Commands.Dogs.AddDog;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos.Animals;
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
        internal readonly DogValidator _dogValidator;
        internal readonly GuidValidator _guidValidator;

        public DogsController(IMediator midiatR, DogValidator dogValidator, GuidValidator guidValidator)
        {
            _midiatR = midiatR;
            _dogValidator = dogValidator;
            _guidValidator = guidValidator;
        }

        // Get all dogs from database
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            try
            {
                return Ok(await _midiatR.Send(new GetAllDogsQuery()));
                // return ok ("get alla dogs")
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        // Get a dog by Id
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            // Validate Guid
            var validatedGuid = _guidValidator.Validate(dogId);
            // Error handling
            if (!validatedGuid.IsValid)
            {
                return BadRequest(validatedGuid.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new GetDogByIdQuery(dogId)));
                // return ok ("get a dog by Id")
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create a new dog
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("addNewDog")]
        [ProducesResponseType(typeof(DogDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            // Validate Dog
            var validatedDog = _dogValidator.Validate(newDog);
            // Error handling
            if (!validatedDog.IsValid)
            {
                return BadRequest(validatedDog.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new AddDogCommand(newDog)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update a specific dog by Id
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            // Validate Guid
            var validatedGuid = _guidValidator.Validate(updatedDogId);
            var validatedDog = _dogValidator.Validate(updatedDog);
            // Error handling
            if (!validatedGuid.IsValid)
            {
                return BadRequest(validatedGuid.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            if (!validatedDog.IsValid)
            {
                return BadRequest(validatedDog.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new UpdateDogByIdCommand(updatedDog, updatedDogId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // Delete a specific dog by Id
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("deleteDog/{deletedDogId}")]

        public async Task<IActionResult> DeleteDog(Guid deletedDogId)
        {
            // Validate Guid
            var validatedGuid = _guidValidator.Validate(deletedDogId);
            // Error handling
            if (!validatedGuid.IsValid)
            {
                return BadRequest(validatedGuid.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new DeleteDogByIdCommand(deletedDogId)));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
