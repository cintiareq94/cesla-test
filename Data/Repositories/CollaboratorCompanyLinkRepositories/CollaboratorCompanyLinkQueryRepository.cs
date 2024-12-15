using CollaboratorTest._3._Domain.Interfaces.CollaboratorCompanyLinkInterfaces;
using CollaboratorTest.Domain.Models.Entities;
using CollaboratorTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CollaboratorTest._4._Infrastructure.Repositories.CollaboratorCompanyLinkRepositories
{
    public class CollaboratorCompanyLinkQueryRepository : ICollaboratorCompanyLinkQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CollaboratorCompanyLinkQueryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CollaboratorCompanyLink>> GetAllAsync()
        {
            return await _dbContext.CollaboratorCompanyLink
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<CollaboratorCompanyLink>> GetAllEnabledAsync()
        {
            return await _dbContext.CollaboratorCompanyLink
                .AsNoTracking()
                .Where(c => c.IsEnabled)
                .ToListAsync();
        }

        public async Task<CollaboratorCompanyLink?> GetByIdAsync(long id)
        {
            return await _dbContext.CollaboratorCompanyLink
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CollaboratorCompanyLink>?> GetByCollaboratorIdAsync(long collaboratorId)
        {
            return await _dbContext.CollaboratorCompanyLink
                .Where(c => c.CollaboratorId == collaboratorId)
                .ToListAsync();
        }

        public async Task<List<CollaboratorCompanyLink>?> GetByCompanyIdAsync(long companyId)
        {
            return await _dbContext.CollaboratorCompanyLink
                .Where(c => c.CompanyId == companyId)
                .ToListAsync();
        }

        public async Task<CollaboratorCompanyLink?> GetByCollaboratorAndCompanyIdAsync(long collaboratorId, long companyId)
        {
            return await _dbContext.CollaboratorCompanyLink
                .Where(c => c.CollaboratorId == collaboratorId && c.CompanyId == companyId)
                .FirstOrDefaultAsync();
        }
    }
}