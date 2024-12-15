using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest._3._Domain.Interfaces.CollaboratorCompanyLinkInterfaces
{
    public interface ICollaboratorCompanyLinkQueryRepository
    {
        Task<List<CollaboratorCompanyLink>> GetAllAsync();

        Task<List<CollaboratorCompanyLink>> GetAllEnabledAsync();

        Task<CollaboratorCompanyLink?> GetByIdAsync(long id);

        Task<List<CollaboratorCompanyLink>?> GetByCollaboratorIdAsync(long collaboratorId);

        Task<List<CollaboratorCompanyLink>?> GetByCompanyIdAsync(long companyId);

        Task<CollaboratorCompanyLink?> GetByCollaboratorAndCompanyIdAsync(long collaboratorId, long companyId);
    }
}