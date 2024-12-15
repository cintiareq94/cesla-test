using CollaboratorTest._2._Application.Interfaces.Handlers.CompanyHandlers;
using CollaboratorTest.Application.DTO.Responses;
using CollaboratorTest.Domain.Interfaces.CompanyInterfaces;

namespace CollaboratorTest._2._Application.Handlers.CompanyHandlers
{
    public class ReaderCompanyHandler : IReaderCompanyHandler
    {
        private readonly ICompanyQueryRepository _queryRepository;

        public ReaderCompanyHandler(ICompanyQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<CompanyResponseDto>> HandleGetAllAsync()
        {
            var companies = await _queryRepository.GetAllAsync();

            var response = new List<CompanyResponseDto>();

            foreach (var company in companies)
            {
                var newDto = new CompanyResponseDto
                {
                    Id = company.Id,
                    TradeName = company.TradeName,
                    Document = company.Document,
                    Phone = company.Phone,
                    Address = company.Address,
                    IsEnabled = company.IsEnabled
                };

                response.Add(newDto);
            }

            return response;
        }

        public async Task<List<CompanyResponseDto>> HandleGetAllEnabledAsync()
        {
            var companies = await _queryRepository.GetAllEnabledAsync();

            var response = new List<CompanyResponseDto>();

            foreach (var company in companies)
            {
                var newDto = new CompanyResponseDto
                {
                    Id = company.Id,
                    TradeName = company.TradeName,
                    Document = company.Document,
                    Phone = company.Phone,
                    Address = company.Address,
                    IsEnabled = company.IsEnabled
                };

                response.Add(newDto);
            }

            return response;
        }

        public async Task<CompanyResponseDto> HandleGetByIdAsync(long id)
        {
            var company = await _queryRepository.GetByIdAsync(id);

            if (company == null)
                throw new Exception($"Company with ID {id} not found.");

            var response = new CompanyResponseDto
            {
                Id = company.Id,
                TradeName = company.TradeName,
                Document = company.Document,
                Phone = company.Phone,
                Address = company.Address,
                IsEnabled = company.IsEnabled
            };

            return response;
        }

        public async Task<CompanyResponseDto> HandleGetByDocumentAsync(string document)
        {
            var company = await _queryRepository.GetByDocumentAsync(document);

            if (company == null) return new CompanyResponseDto();

            var response = new CompanyResponseDto
            {
                Id = company.Id,
                TradeName = company.TradeName,
                Document = company.Document,
                Phone = company.Phone,
                Address = company.Address,
                IsEnabled = company.IsEnabled
            };

            return response;
        }
    }
}
