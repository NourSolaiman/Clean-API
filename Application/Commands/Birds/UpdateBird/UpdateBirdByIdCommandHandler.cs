using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Birds.UpdateBird
{
    public class UpdateBirdByIdCommandHandler : IRequestHandler<UpdateBirdByIdCommand, Bird>
    {
        private readonly caDBContext _caDBContext;
        public UpdateBirdByIdCommandHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<Bird> Handle(UpdateBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToUpdate = _caDBContext.Birds.FirstOrDefault(bird => bird.Id == request.Id)!;

            if (birdToUpdate != null)
            {
                if (string.IsNullOrWhiteSpace(request.UpdatedBird.Name) || request.UpdatedBird.Name == "string")
                {
                    return Task.FromResult<Bird>(null!);
                }
                else
                {
                    birdToUpdate.Name = request.UpdatedBird.Name;

                    return Task.FromResult(birdToUpdate);
                }

            }
            return Task.FromResult(birdToUpdate)!;
        }
    }
}
