using CollaboratorTest.Application.DTO;
using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Application.Interfaces;
using CollaboratorTest.Domain.Interfaces;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Application.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _repository;

        public CollaboratorService(ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CollaboratorResponseDto>> GetAllAsync()
        {
            var collaborators = await _repository.GetAllAsync();
            return collaborators.Select(c => new CollaboratorResponseDto {
              Id = c.Id,
              Name = c.Name,
              Address = c.Address,
              Email = c.Email,
              Department = c.Department,
              Role = c.Role,
              Phone = c.Phone,
              Document = c.Document,
              IsEnabled = c.IsEnabled
            }).OrderBy(c => c.Name).ToList();
        }
        public async Task<List<CollaboratorResponseDto>> GetAllEnabledAsync()
        {
            var collaborators = await _repository.GetAllAsync();
            return collaborators.Select(c => new CollaboratorResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Email = c.Email,
                Department = c.Department,
                Role = c.Role,
                Phone = c.Phone,
                Document = c.Document,
                IsEnabled = c.IsEnabled
            }).OrderBy(c => c.Name).ToList();
        }

        public async Task<CollaboratorResponseDto?> GetByIdAsync(long id)
        {
            var collaborator = await _repository.GetByIdAsync(id);
            if (collaborator == null) return null;

            return new CollaboratorResponseDto
            {
                Id = collaborator.Id,
                Name = collaborator.Name,
                Address = collaborator.Address,
                Email = collaborator.Email,
                Department = collaborator.Department,
                Role = collaborator.Role,
                Phone = collaborator.Phone,
                Document = collaborator.Document,
                IsEnabled = collaborator.IsEnabled
            };
        }


        public async Task<Collaborator> AddAsync(CollaboratorRequestDto dto)
        {
            var collaborator = new Collaborator
            {
                Name = dto.Name,
                Address = dto.Address,
                Email = dto.Email,
                Department = dto.Department,
                Role = dto.Role,
                Phone = dto.Phone,
                Document = dto.Document,
                IsEnabled = dto.IsEnabled
            };

            await _repository.AddAsync(collaborator);

            return collaborator;
        }

        public async Task<Collaborator> UpdateAsync(long id, CollaboratorRequestDto dto)
        {
            var collaborator = await _repository.GetByIdAsync(id);
            if (collaborator == null) throw new KeyNotFoundException();

            collaborator.Name = dto.Name;
            collaborator.Address = dto.Address;
            collaborator.Email = dto.Email;
            collaborator.Department = dto.Department;
            collaborator.Role = dto.Role;
            collaborator.Phone = dto.Phone;

            await _repository.UpdateAsync(collaborator);

            return collaborator;
        }

        public async Task DeleteAsync(long id)
        {

            await _repository.DeleteAsync(id);
        }

    }
}
