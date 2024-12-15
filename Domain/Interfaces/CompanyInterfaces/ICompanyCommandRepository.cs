using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Domain.Interfaces.CompanyInterfaces
{
    public interface ICompanyCommandRepository
    {
        Task AddAsync(Company company);

        Task UpdateAsync(Company company);

        Task DeleteAsync(long id);
    }
}