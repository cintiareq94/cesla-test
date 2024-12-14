
using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Application.DTO.Responses;
using CollaboratorTest.Application.Interfaces;
using CollaboratorTest.Domain.Interfaces.CompanyInterfaces;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CompanyResponseDto>> GetAllAsync()
        {
            var companies = await _repository.GetAllAsync();
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
            var companies = await _repository.GetAllAsync();
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
            var company = await _repository.GetByIdAsync(id);
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
        public async Task<Company> AddAsync(CompanyRequestDto dto)
        {
            var company = new Company
            {
                TradeName = dto.TradeName,
                Address = dto.Address,
                Phone = dto.Phone,
                Document = dto.Document,
                IsEnabled = dto.IsEnabled
            };

            await _repository.AddAsync(company);

            return company;
        }


        public async Task<Company> UpdateAsync(long id, CompanyRequestDto dto)
        {
            var company = await _repository.GetByIdAsync(id);
            if (company == null) throw new KeyNotFoundException();

            //lançar exception customizada

            company.TradeName = dto.TradeName;
            company.Address = dto.Address;
            company.Phone = dto.Phone;
            company.Document = dto.Document;

            await _repository.UpdateAsync(company);

            return company;
        }

        public async Task DeleteAsync(long id)
        { 
            await _repository.DeleteAsync(id);
        }
    }
}
