using CollaboratorTest._2._Application.DTO.Responses;
using CollaboratorTest.Application.DTO.Requests;

namespace CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorCompanyLinkHandler
{
    public interface IReaderCollaboratorCompanyLinkHandler
    {
        Task<List<CollaboratorCompanyLinkResponse>> HandleGetAll(CollaboratorCompanyLinkRequestDto dto, long collaboratorId);

        Task<List<CollaboratorCompanyLinkResponse>> HandleGetAllEnabled(CollaboratorCompanyLinkRequestDto dto, long collaboratorId);


    }
}
