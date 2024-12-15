using CollaboratorTest._2._Application.DTO.Responses;
using CollaboratorTest.Application.DTO.Requests;

namespace CollaboratorTest.Application.Interfaces
{
    public interface ICollaboratorService
    {
        Task<List<CollaboratorCompanyLinkResponseDto>> GetAll();

        Task<List<CollaboratorCompanyLinkResponseDto>> GetAllEnabled();

        Task<List<CollaboratorCompanyLinkResponseDto>?> GetCollaboratorById(long id);

        Task<long> AddCollaborator(CollaboratorCompanyLinkRequestDto dto);

        Task UpdateCollaborator(long collaboratorId, CollaboratorCompanyLinkRequestDto dto);
    }
}