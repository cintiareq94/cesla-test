using CollaboratorTest.Application.Commands.Collaborator.CollaboratorTest.Application.Commands;
using CollaboratorTest.Domain.Interfaces.CompanyInterfaces;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Application.Handlers.Commands.CompanyCommands
{
    public class AddCompanyHandler
    {
        private readonly ICompanyCommandRepository _companyCommandRepository;


        public AddCompanyHandler(ICompanyCommandRepository companyCommandRepository)
        {
            _companyCommandRepository = companyCommandRepository;
        }


        public async Task<long> HandleAsync(AddCompanyCommand command)
        {
            var company = new Company
            {
                TradeName = command.TradeName,
                Address = command.Address,
                Phone = command.Phone,
                Document = command.Document,
                IsEnabled = command.IsEnabled
            };

            await _companyCommandRepository.AddAsync(company);

            return company.Id;
        }
    }
}
