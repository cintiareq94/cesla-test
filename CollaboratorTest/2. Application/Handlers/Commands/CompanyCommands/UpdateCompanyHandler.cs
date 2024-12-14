using CollaboratorTest.Application.Commands.CompanyCommands;
using CollaboratorTest.Domain.Interfaces.CompanyInterfaces;

namespace CollaboratorTest.Application.Handlers.Commands.CompanyCommands
{

    public class UpdateCompanyHandler
    {
        private readonly ICompanyCommandRepository _companyCommandRepository;
        private readonly ICompanyQueryRepository _companyQueryRepository;


        public UpdateCompanyHandler(
            ICompanyCommandRepository companyCommandRepository,
            ICompanyQueryRepository companyQueryRepository)
        {
            _companyCommandRepository = companyCommandRepository;
            _companyQueryRepository = companyQueryRepository;
        }

        public async Task HandleAsync(UpdateCompanyCommand command)
        {
            var company = await _companyQueryRepository.GetByIdAsync(command.Id);

            if (company == null)
                throw new KeyNotFoundException($"Company with ID {command.Id} not found.");

            company.TradeName = command.TradeName;
            company.Address = command.Address;
            company.Document = command.Document;
            company.Phone = command.Phone;

            await _companyCommandRepository.UpdateAsync(company);
        }
    }
}
