using Application.Cats.GetAllCats.GetCatsById;
using Application.Queries.Cats.GetAllCats;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.CatsController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        internal readonly IMediator _midiatR;

        public CatsController(IMediator midiatR)
        {
            _midiatR = midiatR;
        }

        // Get all cats from database
        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            return Ok(await _midiatR.Send(new GetAllCatsQuery()));
            // return ok ("get alla cats")
        }

        // Get a cat by Id
        [HttpGet]
        [Route("getCatById/{catId}")]
        public async Task<IActionResult> GetCatById(Guid catId)
        {
            return Ok(await _midiatR.Send(new GetCatByIdQuery(catId)));
            // return ok ("get a cat by Id")
        }

        //// Create a new cat
        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //[Route("addNewCat")]
        //public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        //{
        //	return Ok(await _midiatR.Send(new AddCatCommand(newCat)));
        //}

        //// Update a specific cat by Id
        //[Authorize(Roles = "Admin")]
        //[HttpPut]
        //[Route("updateCat/{updatedCatId}")]
        //public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        //{
        //	return Ok(await _midiatR.Send(new UpdateCatByIdCommand(updatedCat, updatedCatId)));
        //}

        //// Delete a specific cat by Id
        //[Authorize(Roles = "Admin")]
        //[HttpDelete]
        //[Route("deleteCat/{deletedCatId}")]
        //public async Task<IActionResult> DeleteCat(Guid deletedCatId)
        //{
        //	return Ok(await _midiatR.Send(new DeleteCatByIdCommand(deletedCatId)));
        //}

    }
}
