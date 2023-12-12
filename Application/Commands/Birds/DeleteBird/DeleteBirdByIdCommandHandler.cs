using Application.Commands.Birds.DeleteBird;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Birds.DeleteBird.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {
        private readonly caDBContext _caDBContext;
        public DeleteBirdByIdCommandHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }

        public Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToDelete = _caDBContext.Birds.FirstOrDefault(bird => bird.Id == request.DeletedBirdId)!;

            if (birdToDelete != null)
            {
                _caDBContext.Birds.Remove(birdToDelete);
                return Task.FromResult(birdToDelete);
            }
            // Bird not found
            return Task.FromResult(birdToDelete)!;
        }
    }
}
