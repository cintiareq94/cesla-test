using CollaboratorTest._2._Application.DTO.Responses;

namespace CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorCompanyLinkHandler
{
    public interface IReaderCollaboratorCompanyLinkHandler
    {
        Task<List<CollaboratorCompanyLinkResponse>> HandleGetAll();

        Task<List<CollaboratorCompanyLinkResponse>> HandleGetAllEnabled();

        Task<CollaboratorCompanyLinkResponse> HandleGetLinkById(long id);

        Task<List<CollaboratorCompanyLinkResponse>> HandleGetLinkByCollaboratorId(long id);

        Task<List<CollaboratorCompanyLinkResponse>> HandleGetLinkByCompanyId(long id);
    }
}