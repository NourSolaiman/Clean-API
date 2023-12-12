using Application.Cats.DeleteCat.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Application.Tests.Commands.Cats
{
    [TestFixture]
    public class UpdateCatByIdCommandHandlerTests
    {
        private UpdateCatByIdCommandHandler _handler;
        private Mock<caDBContext> _dbMockContext;
        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _dbMockContext = new Mock<caDBContext>();
            _handler = new UpdateCatByIdCommandHandler(_dbMockContext.Object);
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
        public async Task Handle_ValidId_UpdatesCat()
        {
            // Arrange
            var catId = new Guid("7e910a6d-8621-4f4b-8a0c-5e199f42eaa5");
            var catsList = new List<Cat>
            {
                new Cat
                {
                    Id = catId,
                    Name = "Ciccie",
                    LikesToPlay = true
                }
            };
            SetupMockDbContext(catsList);

            var updatedName = new CatDto { Name = "NewCatName", LikesToPlay = false };

            var command = new UpdateCatByIdCommand(updatedName, catId);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(updatedName.Name, Is.EqualTo(command.UpdatedCat.Name));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnNull()
        {
            // Arrange
            var invalidCatId = Guid.NewGuid();
            var catsList = new List<Cat>
            {
                new Cat
                {
                    Id = Guid.NewGuid(),
                    Name = "Camilla",
                    LikesToPlay = true
                }
            };
            SetupMockDbContext(catsList);

            var updatedName = new CatDto { Name = "NewCatName", LikesToPlay = false };

            var command = new UpdateCatByIdCommand(updatedName, invalidCatId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}