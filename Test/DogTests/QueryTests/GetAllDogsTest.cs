using Application.Queries.Dogs.GetAllDogs;
using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetAllDogsTests
    {
        private GetAllDogsQueryHandler _handler;
        private Mock<caDBContext> _dbMockContext;
        private GetAllDogsQuery _request;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _dbMockContext = new Mock<caDBContext>();
            _handler = new GetAllDogsQueryHandler(_dbMockContext.Object);
        }

        protected void SetupMockDbContext(List<Dog> dogs)
        {
            var mockDbSet = new Mock<DbSet<Dog>>();
            mockDbSet.As<IQueryable<Dog>>().Setup(m => m.Provider).Returns(dogs.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Dog>>().Setup(m => m.Expression).Returns(dogs.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Dog>>().Setup(m => m.ElementType).Returns(dogs.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Dog>>().Setup(m => m.GetEnumerator()).Returns(dogs.GetEnumerator());

            _dbMockContext.Setup(d => d.Dogs).Returns(mockDbSet.Object);
        }

        [Test]
        public async Task Handle_Valid_ReturnsAllDogs()
        {
            // Arrange
            var dogsList = new List<Dog>
            {
                new Dog { Id = Guid.NewGuid(), Name = "PeppeLeDog" },
                new Dog { Id = Guid.NewGuid(), Name = "Fofi" }
            };

            SetupMockDbContext(dogsList);

            // Act
            var result = await _handler.Handle(_request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(dogsList.Count));
        }

        [Test]
        public async Task Handle_InvalidDatabase_ReturnsNullOrEmptyList()
        {
            // Arrange
            var emptyDogsList = new List<Dog>();
            SetupMockDbContext(emptyDogsList);

            // Act
            var result = await _handler.Handle(_request, CancellationToken.None);

            // Assert
            Assert.IsEmpty(result);
        }

    }
}
