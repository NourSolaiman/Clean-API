using Domain.Models;
using MediatR;

namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommand : IRequest<Cat>
    {
        public DeleteCatByIdCommand(Guid deletedCatId)
        {
            DeletedCatId = deletedCatId;
        }

        public Guid DeletedCatId { get; }
    }
}
