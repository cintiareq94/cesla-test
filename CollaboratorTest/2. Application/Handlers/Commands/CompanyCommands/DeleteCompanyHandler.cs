using CollaboratorTest.Application.Commands.CollaboratorCommands;
using CollaboratorTest.Application.Commands.CompanyCommands;
using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;
using CollaboratorTest.Domain.Interfaces.CompanyInterfaces;

namespace CollaboratorTest.Application.Handlers.Commands.CompanyCommands
{

    public class DeleteCompanyHandler
    {
        private readonly ICompanyCommandRepository _companyCommandRepository;
        private readonly ICompanyQueryRepository _companyQueryRepository;


        public DeleteCompanyHandler(
            ICompanyCommandRepository companyCommandRepository,
            ICompanyQueryRepository companyQueryRepository)
        {
            _companyCommandRepository = companyCommandRepository;
            _companyQueryRepository = companyQueryRepository;
        }

        public async Task HandleAsync(DeleteCompanyCommand command)
        {
            var collaborator = await _companyQueryRepository.GetByIdAsync(command.Id);

            if (collaborator == null)
                throw new KeyNotFoundException($"Collaborator with ID {command.Id} not found.");

            await _companyCommandRepository.DeleteAsync(command.Id);
        }
    }
}
