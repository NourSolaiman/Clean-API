using Application.Cats.DeleteCat.DeleteCat;
using Application.Commands.Cats.DeleteCat;
using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Test.Cats.DeleteCat
{
    [TestFixture]
    public class DeleteCatByIdCommandTest
    {
        private DeleteCatByIdCommandHandler _handler;
        private Mock<caDBContext> _dbMockContext;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _dbMockContext = new Mock<caDBContext>();
            _handler = new DeleteCatByIdCommandHandler(_dbMockContext.Object);
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
        public async Task Handle_ValidId_DeletesCat()
        {
            // Arrange
            var catId = new Guid("7e910a6d-8621-4f4b-8a0c-5e199f42eaa5");
            var cat = new List<Cat>
            {
                new Cat
                {
                    Id = catId
                }
            };
            SetupMockDbContext(cat);

            var command = new DeleteCatByIdCommand(catId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(catId));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnNull()
        {
            // Arrange
            var invalidCatId = Guid.NewGuid();
            var cat = new List<Cat>();
            SetupMockDbContext(cat);

            var command = new DeleteCatByIdCommand(invalidCatId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }

    }
}
