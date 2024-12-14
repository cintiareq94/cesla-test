using CollaboratorTest.Application.Commands.CollaboratorCommands;
using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;

namespace CollaboratorTest.Application.Handlers.Commands.CollaboratorCommands
{

    public class UpdateCollaboratorHandler
    {
        private readonly ICollaboratorCommandRepository _commandRepository;
        private readonly ICollaboratorQueryRepository _queryRepository;


        public UpdateCollaboratorHandler(
            ICollaboratorCommandRepository commandRepository,
            ICollaboratorQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task HandleAsync(UpdateCollaboratorCommand command)
        {
            var collaborator = await _queryRepository.GetByIdAsync(command.Id);
            if (collaborator == null)
                throw new KeyNotFoundException($"Collaborator with ID {command.Id} not found.");

            collaborator.Name = command.Name;
            collaborator.Address = command.Address;
            collaborator.Email = command.Email;
            collaborator.Department = command.Department;
            collaborator.Role = command.Role;
            collaborator.Phone = command.Phone;

            await _commandRepository.UpdateAsync(collaborator);
        }
    }
}
