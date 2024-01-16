using Application.Dtos.Animals;
using Domain.Models;
using MediatR;

namespace Application.Commands.Cats.AddCats
{
    public class AddCatCommand : IRequest<Cat>
    {
        public AddCatCommand(CatDto newCat)
        {
            NewCat = newCat;
        }

        public CatDto NewCat { get; }

    }
}
