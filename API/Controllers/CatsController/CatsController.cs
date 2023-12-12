using Application.Cats.GetAllCats.GetCatsById;
using Application.Commands.Cats.AddCats;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Application.Queries.Cats.GetAllCats;
using Application.Validators.Cat;
using Application.Validators.GuidValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.CatsController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        internal readonly IMediator _midiatR;
        internal readonly CatValidator _catValidator;
        internal readonly GuidValidator _guidValidator;

        public CatsController(IMediator midiatR, CatValidator catValidator, GuidValidator guidValidator)
        {
            _midiatR = midiatR;
            _catValidator = catValidator;
            _guidValidator = guidValidator;
        }

        // Get all cats from database
        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            try
            {
                return Ok(await _midiatR.Send(new GetAllCatsQuery()));
                // return ok ("get alla cats")
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        // Get a cat by Id
        [HttpGet]
        [Route("getCatById/{catId}")]
        public async Task<IActionResult> GetCatById(Guid catId)
        {
            // Validate Guid
            var validatedGuid = _guidValidator.Validate(catId);
            // Error handling
            if (!validatedGuid.IsValid)
            {
                return BadRequest(validatedGuid.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new GetCatByIdQuery(catId)));
                // return ok ("get a cat by Id")
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create a new cat
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("addNewCat")]
        [ProducesResponseType(typeof(CatDto), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            // Validate Cat
            var validatedCat = _catValidator.Validate(newCat);
            // Error handling
            if (!validatedCat.IsValid)
            {
                return BadRequest(validatedCat.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new AddCatCommand(newCat)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update a specific cat by Id
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("updateCat/{updatedCatId}")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        {
            // Validate Guid
            var validatedGuid = _guidValidator.Validate(updatedCatId);
            var validatedCat = _catValidator.Validate(updatedCat);
            // Error handling
            if (!validatedGuid.IsValid)
            {
                return BadRequest(validatedGuid.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            if (!validatedCat.IsValid)
            {
                return BadRequest(validatedCat.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new UpdateCatByIdCommand(updatedCat, updatedCatId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete a specific cat by Id
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("deleteCat/{deletedCatId}")]
        public async Task<IActionResult> DeleteCat(Guid deletedCatId)
        {
            // Validate Guid
            var validatedGuid = _guidValidator.Validate(deletedCatId);
            // Error handling
            if (!validatedGuid.IsValid)
            {
                return BadRequest(validatedGuid.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _midiatR.Send(new DeleteCatByIdCommand(deletedCatId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
