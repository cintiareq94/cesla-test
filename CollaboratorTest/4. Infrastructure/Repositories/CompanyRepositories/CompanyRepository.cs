using CollaboratorTest.Domain.Interfaces.CompanyInterfaces;
using CollaboratorTest.Domain.Models.Entities;
using CollaboratorTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CollaboratorTest.Infrastructure.Repositories.CompanyRepositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _dbContext.Company.ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(long id)
        {
            return await _dbContext.Company.FindAsync(id);
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
            var company = await GetByIdAsync(id);
            if (company != null)
            {
                company.IsEnabled = false;
                _dbContext.Company.Update(company);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
