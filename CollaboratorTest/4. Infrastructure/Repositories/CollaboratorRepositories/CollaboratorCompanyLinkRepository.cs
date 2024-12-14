using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;
using CollaboratorTest.Domain.Models.Entities;
using CollaboratorTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CollaboratorTest.Infrastructure.Repositories.CollaboratorRepositories
{

    public class CollaboratorCompanyLinkRepository : ICollaboratorCompanyLinkRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CollaboratorCompanyLinkRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddLinkAsync(long collaboratorId, long companyId, bool isEnabled)
        {
            var link = new CollaboratorCompanyLink
            {
                CollaboratorId = collaboratorId,
                CompanyId = companyId,
                IsEnabled = isEnabled
            };

            await _dbContext.CollaboratorCompanyLink.AddAsync(link);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CollaboratorExistsAsync(long collaboratorId)
        {
            return await _dbContext.Collaborator.AnyAsync(c => c.Id == collaboratorId);
        }

        public async Task<bool> CompanyExistsAsync(long companyId)
        {
            return await _dbContext.Company.AnyAsync(c => c.Id == companyId);
        }
    }
}
