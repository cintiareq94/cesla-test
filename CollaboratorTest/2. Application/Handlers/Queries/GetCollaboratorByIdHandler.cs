using CollaboratorTest.Application.DTO;
using CollaboratorTest.Application.Queries.CollaboratorQueries;
using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;

namespace CollaboratorTest.Application.Handlers.Queries
{
    public class GetCollaboratorByIdHandler
    {
        private readonly ICollaboratorQueryRepository _queryRepository;

        public GetCollaboratorByIdHandler(ICollaboratorQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<CollaboratorResponseDto?> HandleAsync(GetCollaboratorByIdQuery query)
        {
            var collaborator = await _queryRepository.GetByIdAsync(query.Id);
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
    }
}

