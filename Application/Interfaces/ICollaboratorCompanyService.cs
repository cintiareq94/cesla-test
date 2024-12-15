using CollaboratorTest._2._Application.DTO.Responses;

namespace CollaboratorTest._2._Application.Interfaces
{
    public interface ICollaboratorCompanyService
    {
        Task<List<CollaboratorCompanyLinkResponse>> GetAll();

        Task<List<CollaboratorCompanyLinkResponse>> GetAllEnabled();

        Task<CollaboratorCompanyLinkResponse> GetLinkById(long id);

        Task DeleteCollaboratorCompanyLink(long id);
    }
}