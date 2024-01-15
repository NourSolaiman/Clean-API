using Application.Commands.Birds.AddBirds;
using Application.Commands.Birds.DeleteBird;
using Application.Commands.Birds.UpdateBird;
using Application.Dtos.Animals;
using Application.Queries.Birds.GetAllBirds;
using Application.Queries.Birds.GetBirdsById;
using Application.Validators.Bird;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.BirdsController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        internal readonly IMediator _midiatR;
        internal readonly BirdValidator _birdValidator;
        internal readonly GuidValidator _guidValidator;
        public BirdsController(IMediator midiatR, BirdValidator birdValidator, GuidValidator guidValidator)
        {
            _midiatR = midiatR;
            _birdValidator = birdValidator;
            _guidValidator = guidValidator;
        }

        // Get all birds from database
        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            try
            {
                return Ok(await _midiatR.Send(new GetAllBirdsQuery()));
                // return ok ("get alla birds")
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get a bird by Id
        [HttpGet]
        [Route("getBirdById/{birdId}")]
        public async Task<IActionResult> GetBirdById(Guid birdId)
        {
            // Validate Guid
            var validatedGuid = _guidValidator.Validate(birdId);
            // Error handling
            if (!validatedGuid.IsValid)
            {
                return BadRequest(validatedGuid.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new GetBirdByIdQuery(birdId)));
                // return ok ("get a bird by Id")
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create a new bird
        //[Authorize]
        [HttpPost]
        [Route("addNewBird")]
        [ProducesResponseType(typeof(BirdDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            // Validate Bird
            var validatedBird = _birdValidator.Validate(newBird);
            // Error handling
            if (!validatedBird.IsValid)
            {
                return BadRequest(validatedBird.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new AddBirdCommand(newBird)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update a specific bird by Id
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("updateBird/{updatedBirdId}")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
        {
            // Validate Guid and Bird
            var validatedGuid = _guidValidator.Validate(updatedBirdId);
            var validatedBird = _birdValidator.Validate(updatedBird);
            // Error handling
            if (!validatedGuid.IsValid)
            {
                return BadRequest(validatedGuid.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            if (!validatedBird.IsValid)
            {
                return BadRequest(validatedBird.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new UpdateBirdByIdCommand(updatedBird, updatedBirdId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete a specific bird by Id
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("deleteBird/{deletedBirdId}")]
        public async Task<IActionResult> DeleteBird(Guid deletedBirdId)
        {
            // Validate Guid
            var validatedGuid = _guidValidator.Validate(deletedBirdId);
            // Error handling
            if (!validatedGuid.IsValid)
            {
                return BadRequest(validatedGuid.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new DeleteBirdByIdCommand(deletedBirdId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
