
using CollaboratorTest._2._Application.Interfaces.Handlers.CompanyHandlers;
using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Application.DTO.Responses;
using CollaboratorTest.Application.Interfaces;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IWriterCompanyHandler _writerCompanyHandler;
        private readonly IReaderCompanyHandler _readerCompanyHandler;

        public CompanyService(IWriterCompanyHandler writerCompanyHandler, IReaderCompanyHandler readerCompanyHandler)
        {
            _writerCompanyHandler = writerCompanyHandler;
            _readerCompanyHandler = readerCompanyHandler;
        }

        public async Task<List<CompanyResponseDto>> GetAllAsync()
        {
            var companies = await _readerCompanyHandler.HandleGetAllAsync();
            return companies.Select(c => new CompanyResponseDto
            {
                Id = c.Id,
                TradeName = c.TradeName,
                Address = c.Address,
                Document = c.Document,
                IsEnabled = c.IsEnabled,
                Phone = c.Phone
            }).OrderBy(c => c.TradeName).ToList();
        }

        public async Task<List<CompanyResponseDto>> GetAllEnabledAsync()
        {
            var companies = await _readerCompanyHandler.HandleGetAllEnabledAsync();
            return companies.Select(c => new CompanyResponseDto
            {
                Id = c.Id,
                TradeName = c.TradeName,
                Address = c.Address,
                Phone = c.Phone,
                Document = c.Document,
                IsEnabled = c.IsEnabled
            }).OrderBy(c => c.TradeName).ToList();
        }


        public async Task<CompanyResponseDto?> GetByIdAsync(long id)
        {
            var company = await _readerCompanyHandler.HandleGetByIdAsync(id);
            if (company == null) return null;

            return new CompanyResponseDto
            {
                Id = company.Id,
                TradeName = company.TradeName,
                Address = company.Address,
                Document = company.Document,
                IsEnabled = company.IsEnabled,
                Phone = company.Phone
            };
        }

        public async Task<long> AddAsync(CompanyRequestDto dto)
        {
            var companyId = await _writerCompanyHandler.HandleAddAsync(dto);

            return companyId;
        }


        public async Task UpdateAsync(long id, CompanyRequestDto dto)
        {
            var company = await _readerCompanyHandler.HandleGetByIdAsync(id);

            if (company == null) throw new KeyNotFoundException();

            await _writerCompanyHandler.HandleUpdateAsync(id, dto);
        }

        public async Task DeleteAsync(long companyId)
        { 
            await _writerCompanyHandler.HandleDeleteAsync(companyId);
        }
    }
}
