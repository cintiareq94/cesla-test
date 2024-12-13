using CollaboratorTest.Application.DTO;
using CollaboratorTest.Application.Queries.Collaborator;
using CollaboratorTest.Domain.Interfaces;

namespace CollaboratorTest.Application.Handlers.Queries
{

    public class GetCollaboratorsHandler
    {
        private readonly ICollaboratorQueryRepository _queryRepository;

 
        public GetCollaboratorsHandler(ICollaboratorQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

    
        public async Task<List<CollaboratorResponseDto>> HandleAsync(GetCollaboratorsQuery query)
        {
     
            var collaborators = await _queryRepository.GetAllAsync();

    
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
            })
            .OrderBy(c => c.Name)
            .ToList();
        }
    }
}
