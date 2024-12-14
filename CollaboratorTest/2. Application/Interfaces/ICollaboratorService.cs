using CollaboratorTest.Application.DTO;
using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Application.Interfaces
{
    public interface ICollaboratorService
    {
        Task<List<CollaboratorResponseDto>> GetAllAsync();
        Task<List<CollaboratorResponseDto>> GetAllEnabledAsync();

        Task<CollaboratorResponseDto?> GetByIdAsync(long id);

        Task<Collaborator> AddAsync(CollaboratorRequestDto dto);

        Task<Collaborator> UpdateAsync(long id, CollaboratorRequestDto dto);

        Task DeleteAsync(long id);
    }
}
