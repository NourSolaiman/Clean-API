using Application.Queries.Cats.GetAllCats;
using Infrastructure.Database;

namespace Test.CatTests.QueryTests
{
	[TestFixture]
	public class GetAllCatsTests
	{
		private GetAllCatsQueryHandler _handler;
		private MockDatabase _mockDatabase;

		[SetUp]
		public void SetUp()
		{
			// Initialize the handler and mock database before each test
			_mockDatabase = new MockDatabase();
			_handler = new GetAllCatsQueryHandler(_mockDatabase);
		}

		[Test]
		public async Task Handle_ReturnsListOfCats()
		{
			// Arrange - In this case, since GetAllCats does not require any parameters, there's no need to set up specific data.

			var query = new GetAllCatsQuery();

			// Act
			var result = await _handler.Handle(query, CancellationToken.None);

			// Assert
			Assert.NotNull(result);
			Assert.IsInstanceOf<List<Domain.Models.Cat>>(result); // Adjust this assertion based on the actual return type.
			Assert.That(result.Count, Is.GreaterThan(0));
		}

	}
}
