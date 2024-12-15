using CollaboratorTest._2._Application.Interfaces.Handlers.CompanyHandlers;
using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Domain.Interfaces.CompanyInterfaces;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest._2._Application.Handlers.CompanyHandlers
{
    public class WriterCompanyHandler : IWriterCompanyHandler
    {
        private readonly ICompanyCommandRepository _companyCommandRepository;
        private readonly ICompanyQueryRepository _companyQueryRepository;

        public WriterCompanyHandler(
            ICompanyCommandRepository companyCommandRepository,
            ICompanyQueryRepository companyQueryRepository)
        {
            _companyCommandRepository = companyCommandRepository;
            _companyQueryRepository = companyQueryRepository;
        }

        public async Task<long> HandleAddAsync(CompanyRequestDto dto)
        {
            var company = new Company
            {
                TradeName = dto.TradeName,
                Address = dto.Address,
                Phone = dto.Phone,
                Document = dto.Document,
                IsEnabled = dto.IsEnabled
            };

            await _companyCommandRepository.AddAsync(company);

            return company.Id;
        }

        public async Task HandleUpdateAsync(long companyId, CompanyRequestDto dto)
        {
            var company = await _companyQueryRepository.GetByIdAsync(companyId);

            if (company == null)
                throw new Exception($"Company with ID {companyId} not found.");

            company.TradeName = dto.TradeName;
            company.Address = dto.Address;
            company.Phone = dto.Phone;

            await _companyCommandRepository.UpdateAsync(company);
        }

        public async Task HandleDeleteAsync(long companyId)
        {
            var company = await _companyQueryRepository.GetByIdAsync(companyId);

            if (company == null)
                throw new Exception($"Company with ID {companyId} not found.");

            await _companyCommandRepository.DeleteAsync(companyId);
        }
    }
}
