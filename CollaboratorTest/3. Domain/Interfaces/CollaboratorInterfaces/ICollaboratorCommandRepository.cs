using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces
{
    public interface ICollaboratorCommandRepository
    {
        Task AddAsync(Collaborator collaborator);
        Task UpdateAsync(Collaborator collaborator);
    }
}