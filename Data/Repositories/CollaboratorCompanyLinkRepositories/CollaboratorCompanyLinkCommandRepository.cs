using CollaboratorTest._3._Domain.Interfaces.CollaboratorCompanyLinkInterfaces;
using CollaboratorTest.Domain.Models.Entities;
using CollaboratorTest.Infrastructure.Data;

namespace CollaboratorTest._4._Infrastructure.Repositories.CollaboratorCompanyLinkRepositories
{
    public class CollaboratorCompanyLinkCommandRepository : ICollaboratorCompanyLinkCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CollaboratorCompanyLinkCommandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(CollaboratorCompanyLink collaboratorCompanyLink)
        {
            await _dbContext.CollaboratorCompanyLink.AddAsync(collaboratorCompanyLink);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CollaboratorCompanyLink collaboratorCompanyLink)
        {
            _dbContext.CollaboratorCompanyLink.Update(collaboratorCompanyLink);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var collaboratorCompanyLink = await _dbContext.CollaboratorCompanyLink.FindAsync(id);

            if (collaboratorCompanyLink != null)
            {
                collaboratorCompanyLink.IsEnabled = false;
                _dbContext.CollaboratorCompanyLink.Update(collaboratorCompanyLink);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}