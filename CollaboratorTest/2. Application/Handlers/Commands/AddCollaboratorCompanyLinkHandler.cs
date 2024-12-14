using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Application.Handlers.Commands
{
    public class AddCollaboratorCompanyLinkHandler
    {
        private readonly ICollaboratorCompanyLinkRepository _repository;

        public AddCollaboratorCompanyLinkHandler(ICollaboratorCompanyLinkRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(CollaboratorCompanyLink command)
        {
            if (!await _repository.CollaboratorExistsAsync(command.CollaboratorId))
                throw new KeyNotFoundException($"Collaborator with ID {command.CollaboratorId} not found.");


            if (!await _repository.CompanyExistsAsync(command.CompanyId))
                throw new KeyNotFoundException($"Company with ID {command.CompanyId} not found.");

            await _repository.AddLinkAsync(command.CollaboratorId, command.CompanyId, command.IsEnabled);
        }
    }
}
