using Application.Queries.UserAnimal;
using Application.Queries.UserAnimal.GetAll;
using Domain.Models;
using Infrastructure.Repositories.UserAnimal;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test.UserAnimalTests.QueryTest
{
    [TestFixture]
    public class GetAllUsersWithAnimalsTests
    {
        private Mock<IUserAnimalRepository> _repositoryMock;
        private Mock<ILogger<GetAllUsersWithAnimalsQueryHandler>> _loggerMock;
        private GetAllUsersWithAnimalsQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IUserAnimalRepository>();
            _loggerMock = new Mock<ILogger<GetAllUsersWithAnimalsQueryHandler>>();
            //_handler = new GetAllUsersWithAnimalsQueryHandler(_repositoryMock.Object, _loggerMock.Object);
        }

        //[Test]
        //public async Task GetAllUsersWithAnimals_WhenUsersExist_ReturnsAllUsersWithAnimals()
        //{
        //    // Arrange
        //    var fakeUsers = new List<User>
        //    {
        //        new User
        //        {
        //            Id = Guid.NewGuid(),
        //            Username = "User1",
        //            UserAnimals = new List<UserAnimal>
        //            {
        //                new UserAnimal { Animal = new Dog { Name = "Dog1" } },
        //                new UserAnimal { Animal = new Cat { Name = "Cat1", LikesToPlay = true } },
        //                new UserAnimal { Animal = new Bird { Name = "Bird1", CanFly = true } }
        //            }
        //        },
        //        new User
        //        {
        //            Id = Guid.NewGuid(),
        //            Username = "User2",
        //            UserAnimals = new List<UserAnimal>
        //            {
        //                new UserAnimal { Animal = new Dog { Name = "Dog2" } },
        //                new UserAnimal { Animal = new Cat { Name = "Cat2", LikesToPlay = false } },
        //                new UserAnimal { Animal = new Bird { Name = "Bird2", CanFly = false } }
        //            }
        //        }
        //    };

        //    _repositoryMock.Setup(repo => repo.GetAllUsersWithAnimalsAsync())
        //                   .ReturnsAsync(fakeUsers);

        //    // Act
        //    var query = new GetAllUsersWithAnimalsQuery();
        //    var result = await _handler.Handle(query, CancellationToken.None);

        //    // Assert
        //    Assert.IsNotEmpty(result);
        //    _loggerMock.Verify(logger => logger.Log(
        //        LogLevel.Information,
        //        It.IsAny<EventId>(),
        //        It.Is<It.IsAnyType>((o, t) => true),
        //        It.IsAny<Exception>(),
        //        (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
        //        Times.AtLeastOnce);
        //}

        //[Test]
        //public async Task GetAllUsersWithAnimals_WhenRepositoryThrowsException_ReturnsEmptyListAndLogsError()
        //{
        //    // Arrange
        //    _repositoryMock.Setup(repo => repo.GetAllUsersWithAnimalsAsync())
        //                   .ThrowsAsync(new Exception("Database error"));

        //    // Act
        //    var query = new GetAllUsersWithAnimalsQuery();
        //    var result = await _handler.Handle(query, CancellationToken.None);

        //    // Assert
        //    Assert.IsEmpty(result);
        //    _loggerMock.Verify(logger => logger.Log(
        //        LogLevel.Error,
        //        It.IsAny<EventId>(),
        //        It.Is<It.IsAnyType>((o, t) => true),
        //        It.IsAny<Exception>(),
        //        (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
        //        Times.Once);
        //}
    }
}
