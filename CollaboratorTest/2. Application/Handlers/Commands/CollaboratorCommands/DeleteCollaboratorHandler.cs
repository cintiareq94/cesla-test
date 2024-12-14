using CollaboratorTest.Application.Commands.CollaboratorCommands;
using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;

namespace CollaboratorTest.Application.Handlers.Commands.CollaboratorCommands
{

    public class DeleteCompanyHandler
    {
        private readonly ICollaboratorCommandRepository _commandRepository;
        private readonly ICollaboratorQueryRepository _queryRepository;


        public DeleteCompanyHandler(
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
