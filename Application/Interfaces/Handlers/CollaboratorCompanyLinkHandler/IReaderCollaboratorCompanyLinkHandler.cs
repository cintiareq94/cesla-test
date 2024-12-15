using CollaboratorTest._2._Application.DTO.Responses;
using CollaboratorTest.Application.DTO.Requests;

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
