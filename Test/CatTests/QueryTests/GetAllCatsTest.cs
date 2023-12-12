using Application.Queries.Cats.GetAllCats;
using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Test.CatTests.QueryTests
{
    [TestFixture]
    public class GetAllCatsTests
    {
        private GetAllCatsQueryHandler _handler;
        private GetAllCatsQuery _request;
        private Mock<caDBContext> _dbMockContext;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _dbMockContext = new Mock<caDBContext>();
            _handler = new GetAllCatsQueryHandler(_dbMockContext.Object);
        }

        protected void SetupMockDbContext(List<Cat> cats)
        {
            var mockDbSet = new Mock<DbSet<Cat>>();
            mockDbSet.As<IQueryable<Cat>>().Setup(m => m.Provider).Returns(cats.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Cat>>().Setup(m => m.Expression).Returns(cats.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Cat>>().Setup(m => m.ElementType).Returns(cats.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Cat>>().Setup(m => m.GetEnumerator()).Returns(cats.GetEnumerator());

            _dbMockContext.Setup(c => c.Cats).Returns(mockDbSet.Object);
        }

        [Test]
        public async Task Handle_Valid_ReturnsAllCats()
        {
            // Arrange
            var cats = new List<Cat>
            {
                new Cat { Id = Guid.NewGuid(), Name = "Liam" },
                new Cat { Id = Guid.NewGuid(), Name = "Nick" }
            };

            SetupMockDbContext(cats);

            // Act
            var result = await _handler.Handle(_request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(cats.Count));
        }

        [Test]
        public async Task Handle_InvalidDatabase_ReturnsNullOrEmptyList()
        {
            // Arrange
            var emptyCatsList = new List<Cat>();
            SetupMockDbContext(emptyCatsList);

            // Act
            var result = await _handler.Handle(_request, CancellationToken.None);

            // Assert
            Assert.IsEmpty(result);
        }

    }
}
