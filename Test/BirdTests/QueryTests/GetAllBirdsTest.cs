using Application.Queries.Birds.GetAllBirds;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Test.BirdsTests.QueryTest
{
    [TestFixture]
    public class GetAllBirdsTests
    {
        private GetAllBirdsQueryHandler _handler;
        private Mock<caDBContext> _dbMockContext;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _dbMockContext = new Mock<caDBContext>();
            _handler = new GetAllBirdsQueryHandler(_dbMockContext.Object);
        }

        protected void SetupMockDbContext(List<Bird> birds)
        {
            var mockDbSet = new Mock<DbSet<Bird>>();
            mockDbSet.As<IQueryable<Bird>>().Setup(m => m.Provider).Returns(birds.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Bird>>().Setup(m => m.Expression).Returns(birds.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Bird>>().Setup(m => m.ElementType).Returns(birds.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Bird>>().Setup(m => m.GetEnumerator()).Returns(birds.GetEnumerator());

            _dbMockContext.Setup(b => b.Birds).Returns(mockDbSet.Object);
        }

        [Test]
        public async Task Handle_ReturnsListOfBirds()
        {
            // Arrange
            var birds = new List<Bird>
            {
                new Bird { Id = Guid.NewGuid(), Name = "Alex" },

                new Bird { Id = Guid.NewGuid(), Name = "Max" }
            };

            SetupMockDbContext(birds);

            var query = new GetAllBirdsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(birds.Count));
        }

    }
}
