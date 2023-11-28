using Application.Queries.Dogs.GetAllDogs;
using Infrastructure.Database;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetAllDogsTests
    {
        private GetAllDogsQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetAllDogsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ReturnsListOfDogs()
        {
            // Arrange - In this case, since GetAllDogs does not require any parameters, there's no need to set up specific data.

            var query = new GetAllDogsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<List<Domain.Models.Dog>>(result); // Adjust this assertion based on the actual return type.
            Assert.That(result.Count, Is.GreaterThan(0));
        }

    }
}
