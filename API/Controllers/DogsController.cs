using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.Dogs;
using Application.Queries.Dogs.GetDogById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
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

		// Detta är API endpoint där vi hämtar alla hundar från MockDatabase
		// url är api/v1/Dogs/getAllDogs
		[HttpGet]
		[Route("getAllDogs")]
		public async Task<IActionResult> GetAllDogs()
		{
			// Använda MediatR föra att ta emot requests
			// MediatR ska ta emot requests och dela dem på Commands eller Queries
			// Detta är en GET då blir det en Query
			// Return IActionsResult
			return Ok(await _midiatR.Send(new GetAllDogsQuery()));
		}







		// GET api/<DogsController>/5
		[HttpGet]
		[Route("getDogById/{dogId}")]
		public async Task<IActionResult> GetDogById(Guid dogId)
		{
			return Ok(await _midiatR.Send(new GetDogByIdQuery(dogId)));
		}

		//// POST api/<DogsController>
		//[HttpPost]
		//public void Post([FromBody] string value)
		//{
		//}

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
