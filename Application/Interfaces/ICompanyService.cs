using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Application.DTO.Responses;

namespace CollaboratorTest.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<List<CompanyResponseDto>> GetAllAsync();

        Task<List<CompanyResponseDto>> GetAllEnabledAsync();

        Task<CompanyResponseDto?> GetByIdAsync(long id);

        Task<long> AddAsync(CompanyRequestDto dto);

        Task UpdateAsync(long id, CompanyRequestDto dto);

        Task DeleteAsync(long id);
    }
}