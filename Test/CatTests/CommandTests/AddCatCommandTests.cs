using Application.Commands.Cats.AddCats;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.Cats.AddCats
{
    [TestFixture]
    public class AddCatCommandTest
    {
        private AddCatCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new AddCatCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ValidCatData_AddsCatToDatabase()
        {
            // Arrange
            var catToAdd = new CatDto
            {
                Name = "Simon",
            };

            var command = new AddCatCommand(catToAdd);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            var addedCat = _mockDatabase.allCats.SingleOrDefault(d => d.Name == catToAdd.Name);
            Assert.NotNull(addedCat);
            Assert.That(addedCat.Name, Is.EqualTo(catToAdd.Name));
        }
    }
}