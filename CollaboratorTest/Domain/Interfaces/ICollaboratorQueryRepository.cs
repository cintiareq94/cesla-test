using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Domain.Interfaces
{
    public interface ICollaboratorQueryRepository
    {
        Task<List<Collaborator>> GetAllAsync();
        Task<List<Collaborator>> GetAllEnabledAsync();
        Task<Collaborator?> GetByIdAsync(long id);
    }
}

