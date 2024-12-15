using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Domain.Interfaces.CompanyInterfaces
{
    public interface ICompanyQueryRepository
    {
        Task<List<Company>> GetAllAsync();
        Task<List<Company>> GetAllEnabledAsync();
        Task<Company?> GetByIdAsync(long id);
        Task<Company?> GetByDocumentAsync(string document);
    }
}

