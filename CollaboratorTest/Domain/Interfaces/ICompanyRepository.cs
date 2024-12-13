using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Domain.Interfaces
{
    public interface ICompanyRepository

    {
        Task<List<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(long id);
        Task AddAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(long id);
    }
}
