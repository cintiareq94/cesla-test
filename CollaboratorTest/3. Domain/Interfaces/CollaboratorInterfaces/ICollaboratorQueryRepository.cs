using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces
{
    public interface ICollaboratorQueryRepository
    {
        Task<List<Collaborator>> GetAllAsync();
        Task<List<Collaborator>> GetAllEnabledAsync();
        Task<Collaborator?> GetByIdAsync(long id);
        Task<Collaborator> GetByDocumentAsync(string document);
    }
}

