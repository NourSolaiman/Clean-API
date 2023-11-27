using Application.Queries.Birds.GetAllBirds;
using Application.Queries.Birds.GetBirdsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class BirdsController : ControllerBase
	{
		internal readonly IMediator _midiatR;

		public BirdsController(IMediator midiatR)
		{
			_midiatR = midiatR;
		}

		// Get all birds from database
		[HttpGet]
		[Route("getAllBirds")]
		public async Task<IActionResult> GetAllBirds()
		{
			return Ok(await _midiatR.Send(new GetAllBirdsQuery()));
			// return ok ("get alla birds")
		}

		// Get a bird by Id
		[HttpGet]
		[Route("getBirdById/{birdId}")]
		public async Task<IActionResult> GetBirdById(Guid birdId)
		{
			return Ok(await _midiatR.Send(new GetBirdByIdQuery(birdId)));
			// return ok ("get a bird by Id")
		}

		//// Create a new bird
		//// [Authorize(Roles = "Admin")]
		//[HttpPost]
		//[Route("addNewBird")]
		//public async Task<IActionResult> AddBird([FromBody] DogDto newBird)
		//{
		//	return Ok(await _midiatR.Send(new AddBirdCommand(newBird)));
		//}

		//// Update a specific bird by Id
		//[HttpPut]
		//[Route("updateBird/{updatedBirdId}")]
		//public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
		//{
		//	return Ok(await _midiatR.Send(new UpdateBirdByIdCommand(updatedBird, updatedBirdId)));
		//}
		//// Delete a specific bird by Id
		//[HttpDelete]
		//[Route("deleteBird/{deletedBirdId}")]
		//public async Task<IActionResult> DeleteBird(Guid deletedBirdId)
		//{
		//	return Ok(await _midiatR.Send(new DeleteBirdByIdCommand(deletedBirdId)));
		//}

	}
}
