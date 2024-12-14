using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;
using CollaboratorTest.Domain.Models.Entities;
using CollaboratorTest.Infrastructure.Data;

namespace CollaboratorTest.Infrastructure.Repositories.CollaboratorRepositories
{
    public class CollaboratorCommandRepository : ICollaboratorCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CollaboratorCommandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Collaborator collaborator)
        {
            await _dbContext.Collaborator.AddAsync(collaborator);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Collaborator collaborator)
        {
            _dbContext.Collaborator.Update(collaborator);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var collaborator = await _dbContext.Collaborator.FindAsync(id);
            if (collaborator != null)
            {
                collaborator.IsEnabled = false;
                _dbContext.Collaborator.Update(collaborator);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

