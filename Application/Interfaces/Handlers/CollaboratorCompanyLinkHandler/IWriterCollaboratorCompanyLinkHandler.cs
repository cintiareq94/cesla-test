using CollaboratorTest.Application.DTO.Requests;

namespace CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorCompanyLinkHandler
{
    public interface IWriterCollaboratorCompanyLinkHandler
    {
        Task HandleAddAsync(CollaboratorCompanyLinkRequestDto dto, long collaboratorId);

        Task HandleUpdateAsync(CollaboratorCompanyLinkRequestDto dto, long collaboratorId);

        Task HandleDeleteAsync(long id);
    }
}