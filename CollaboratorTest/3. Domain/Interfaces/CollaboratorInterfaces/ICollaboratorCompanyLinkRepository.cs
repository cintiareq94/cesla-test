using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces
{
    public interface ICollaboratorCompanyLinkRepository

    {
        Task AddLinkAsync(long collaboratorId, long companyId, bool isEnabled);
        Task<bool> CollaboratorExistsAsync(long collaboratorId);
        Task<bool> CompanyExistsAsync(long companyId);
    }
}

