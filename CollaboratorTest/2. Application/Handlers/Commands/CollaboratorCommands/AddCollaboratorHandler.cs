using CollaboratorTest.Application.Commands.CollaboratorCommands.CollaboratorTest.Application.Commands;
using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Application.Handlers.Commands.CollaboratorCommands
{
    public class AddCollaboratorHandler
    {
        private readonly ICollaboratorCommandRepository _collaboratorCommandRepository;


        public AddCollaboratorHandler(ICollaboratorCommandRepository commandRepository)
        {
            _collaboratorCommandRepository = commandRepository;
        }


        public async Task<long> HandleAsync(AddCollaboratorCommand command)
        {
            var collaborator = new Collaborator
            {
                Name = command.Name,
                Address = command.Address,
                Email = command.Email,
                Department = command.Department,
                Role = command.Role,
                Phone = command.Phone,
                Document = command.Document,
                IsEnabled = command.IsEnabled
            };

            await _collaboratorCommandRepository.AddAsync(collaborator);

            return collaborator.Id;
        }
    }
}
