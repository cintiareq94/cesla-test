using CollaboratorTest.Domain.Interfaces.CompanyInterfaces;
using CollaboratorTest.Domain.Models.Entities;
using CollaboratorTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CollaboratorTest.Infrastructure.Repositories.CompanyRepositories
{
    public class CompanyQueryRepository : ICompanyQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyQueryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Company>> GetAllAsync()
        {
            return await _dbContext.Company
                .AsNoTracking()
                .Include(c => c.CollaboratorCompanyLinks)
                .ToListAsync();
        }


        public async Task<List<Company>> GetAllEnabledAsync()
        {
            return await _dbContext.Company
                .AsNoTracking()
                .Where(c => c.IsEnabled)
                .Include(c => c.CollaboratorCompanyLinks)
                .ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(long id)
        {
            return await _dbContext.Company
                .AsNoTracking()
                .Include(c => c.CollaboratorCompanyLinks)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
