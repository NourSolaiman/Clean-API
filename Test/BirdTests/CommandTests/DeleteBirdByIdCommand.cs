using Application.Birds.DeleteBird.DeleteBird;
using Application.Commands.Birds.DeleteBird;
using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Test.Birds.DeleteBird
{
	[TestFixture]
    public class DeleteBirdByIdCommandTest
    {
        private DeleteBirdByIdCommandHandler _handler;
		private Mock<caDBContext> _dbMockContext;

		[SetUp]
		public void SetUp()
		{
			// Initialize the handler and mock database before each test
			_dbMockContext = new Mock<caDBContext>();
			_handler = new DeleteBirdByIdCommandHandler(_dbMockContext.Object);
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
        public async Task Handle_ValidId_RemovesBirdFromDatabase()
        {
			// Arrange
			var birdId = new Guid("59d8fc74-3c94-4ed8-9a38-36b0b6b1074a");
			var bird = new List<Bird>
			{
				new Bird
				{
					Id = birdId
				}
			};
			SetupMockDbContext(bird);

			var command = new DeleteBirdByIdCommand(birdId);

			// Act
			var result = await _handler.Handle(command, CancellationToken.None);

			// Assert
			Assert.NotNull(result);
			Assert.That(result.Id, Is.EqualTo(birdId));
		}

		[Test]
		public async Task Handle_InvalidId_DoesNothing()
		{
			// Arrange
			var invalidBirdId = Guid.NewGuid();
			var bird = new List<Bird>();
			SetupMockDbContext(bird);

			var command = new DeleteBirdByIdCommand(invalidBirdId);

			// Act
			var result = await _handler.Handle(command, CancellationToken.None);

			// Assert
			Assert.IsNull(result);
		}

	}
}
