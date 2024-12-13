using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Application.DTO.Responses;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<List<CompanyResponseDto>> GetAllAsync();
        Task<List<CompanyResponseDto>> GetAllEnabledAsync();

        Task<CompanyResponseDto?> GetByIdAsync(long id);

        Task<Company> AddAsync(CompanyRequestDto dto);

        Task<Company> UpdateAsync(long id, CompanyRequestDto dto);

        Task DeleteAsync(long id);
    }
}
