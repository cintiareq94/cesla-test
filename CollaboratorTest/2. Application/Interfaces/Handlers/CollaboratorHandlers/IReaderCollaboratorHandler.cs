using CollaboratorTest._2._Application.DTO.Responses;

namespace CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorHandlers
{
    public interface IReaderCollaboratorHandler
    {
        Task<List<CollaboratorCompanyLinkResponseDto>> HandleByIdAsync(long id);

        Task<List<CollaboratorCompanyLinkResponseDto>> HandleGetAllAsync();

        Task<List<CollaboratorCompanyLinkResponseDto>> HandleGetAllEnabledAsync();
    }
}
