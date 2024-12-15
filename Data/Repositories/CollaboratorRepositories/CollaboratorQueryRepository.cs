using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;
using CollaboratorTest.Domain.Models.Entities;
using CollaboratorTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CollaboratorTest.Infrastructure.Repositories.CollaboratorRepositories
{
    public class CollaboratorQueryRepository : ICollaboratorQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CollaboratorQueryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Collaborator>> GetAllAsync()
        {
            return await _dbContext.Collaborator
                .AsNoTracking()
                .Include(c => c.CollaboratorCompanyLinks)
                    .ThenInclude(c => c.Company)
                .ToListAsync();
        }


        public async Task<List<Collaborator>> GetAllEnabledAsync()
        {
            return await _dbContext.Collaborator
                .Include(c => c.CollaboratorCompanyLinks.Where(cl => cl.IsEnabled))
                    .ThenInclude(c => c.Company)
                .ToListAsync();
        }

        public async Task<Collaborator?> GetByIdAsync(long id)
        {
            return await _dbContext.Collaborator
                .AsNoTracking()
                .Include(c => c.CollaboratorCompanyLinks)
                    .ThenInclude(c => c.Company)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Collaborator?> GetByDocumentAsync(string document)
        {
            return await _dbContext.Collaborator
                .Where(c => c.Document == document && c.CollaboratorCompanyLinks.Any(cl => cl.IsEnabled))
                .Include(c => c.CollaboratorCompanyLinks.Where(cl => cl.IsEnabled))
                    .ThenInclude(cl => cl.Company)
                .FirstOrDefaultAsync();
        }
    }
}
