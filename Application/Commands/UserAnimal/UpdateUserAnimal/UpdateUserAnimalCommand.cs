using MediatR;

namespace Application.Commands.UserAnimal.UpdateUserAnimal
{
    public class UpdateUserAnimalCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid CurrentAnimalModelId { get; set; }
        public Guid NewAnimalModelId { get; set; }

        public UpdateUserAnimalCommand(Guid userId, Guid currentAnimalModelId, Guid newAnimalModelId)
        {
            UserId = userId;
            CurrentAnimalModelId = currentAnimalModelId;
            NewAnimalModelId = newAnimalModelId;
        }
    }
}
