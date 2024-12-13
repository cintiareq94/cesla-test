using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Domain.Interfaces
{
    public interface ICollaboratorCommandRepository
    {
        Task AddAsync(Collaborator collaborator);
        Task UpdateAsync(Collaborator collaborator);
        Task DeleteAsync(long id);
    }
}