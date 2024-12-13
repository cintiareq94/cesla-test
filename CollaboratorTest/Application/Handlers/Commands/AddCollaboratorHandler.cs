using CollaboratorTest.Application.Commands.Collaborator.CollaboratorTest.Application.Commands;
using CollaboratorTest.Domain.Interfaces;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Application.Handlers.Commands
{
    public class AddCollaboratorHandler
    {
        private readonly ICollaboratorCommandRepository _commandRepository;

     
        public AddCollaboratorHandler(ICollaboratorCommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
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

 
            await _commandRepository.AddAsync(collaborator);

    
            return collaborator.Id;
        }
    }
}
  