using CollaboratorTest.Application.DTO.Requests;

namespace CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorHandlers
{
    public interface IWriterCollaboratorHandler
    {
        Task<long> HandleAddAsync(CollaboratorCompanyLinkRequestDto dto);

        Task HandleUpdateAsync(CollaboratorCompanyLinkRequestDto dto, long collaboratorId);
    }
}