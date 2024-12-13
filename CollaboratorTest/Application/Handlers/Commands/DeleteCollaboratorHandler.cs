using CollaboratorTest.Application.Commands.Collaborator;
using CollaboratorTest.Domain.Interfaces;

namespace CollaboratorTest.Application.Handlers.Commands
{

    public class DeleteCollaboratorHandler
    {
        private readonly ICollaboratorCommandRepository _commandRepository;
        private readonly ICollaboratorQueryRepository _queryRepository;

 
        public DeleteCollaboratorHandler(
            ICollaboratorCommandRepository commandRepository,
            ICollaboratorQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task HandleAsync(DeleteCollaboratorCommand command)
        {
            var collaborator = await _queryRepository.GetByIdAsync(command.Id);
            if (collaborator == null)
                throw new KeyNotFoundException($"Collaborator with ID {command.Id} not found.");

            await _commandRepository.DeleteAsync(command.Id);
        }
    }
}
