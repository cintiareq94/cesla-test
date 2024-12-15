using CollaboratorTest.Domain.Interfaces.CompanyInterfaces;
using CollaboratorTest.Domain.Models.Entities;
using CollaboratorTest.Infrastructure.Data;

namespace CollaboratorTest.Infrastructure.Repositories.CompanyRepositories
{
    public class CompanyCommandRepository : ICompanyCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyCommandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Company company)
        {
            await _dbContext.Company.AddAsync(company);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _dbContext.Company.Update(company);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var company = await _dbContext.Company.FindAsync(id);
            if (company != null)
            {
                company.IsEnabled = false;
                _dbContext.Company.Update(company);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

