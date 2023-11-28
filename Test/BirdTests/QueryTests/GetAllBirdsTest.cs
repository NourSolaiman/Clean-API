using Application.Queries.Birds.GetAllBirds;
using Infrastructure.Database;

namespace Test.BirdsTests.QueryTest
{
    [TestFixture]
    public class GetAllBirdsTests
    {
        private GetAllBirdsQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetAllBirdsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ReturnsListOfBirds()
        {
            // Arrange - In this case, since GetAllBirdss does not require any parameters, there's no need to set up specific data.

            var query = new GetAllBirdsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<List<Domain.Models.Bird>>(result); // Adjust this assertion based on the actual return type.
            Assert.That(result.Count, Is.GreaterThan(0));
        }

    }
}
