using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest._3._Domain.Interfaces.CollaboratorCompanyLinkInterfaces
{
    public interface ICollaboratorCompanyLinkCommandRepository
    {
        Task AddAsync(CollaboratorCompanyLink collaboratorCompanyLink);

        Task UpdateAsync(CollaboratorCompanyLink collaboratorCompanyLink);

        Task DeleteAsync(long id);
    }
}
