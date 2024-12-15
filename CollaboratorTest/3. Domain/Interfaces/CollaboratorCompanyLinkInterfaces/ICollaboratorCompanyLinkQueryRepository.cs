using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest._3._Domain.Interfaces.CollaboratorCompanyLinkInterfaces
{
    public interface ICollaboratorCompanyLinkQueryRepository
    {
        Task<List<CollaboratorCompanyLink>> GetAllAsync();
        Task<List<CollaboratorCompanyLink>> GetAllEnabledAsync();
        Task<CollaboratorCompanyLink?> GetByIdAsync(long id);
        Task<CollaboratorCompanyLink?> GetByCollaboratorAndCompanyIdAsync(long collaboratorId, long companyId);
    }
}
