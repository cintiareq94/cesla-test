using CollaboratorTest.Application.DTO;
using CollaboratorTest.Application.Queries.CollaboratorQueries;
using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;

namespace CollaboratorTest.Application.Handlers.Queries
{
    public class GetEnabledCollaboratorsHandler
    {
        private readonly ICollaboratorQueryRepository _queryRepository;

        public GetEnabledCollaboratorsHandler(ICollaboratorQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<CollaboratorResponseDto>> HandleAsync(GetEnabledCollaboratorsQuery query)
        {
            var collaborators = await _queryRepository.GetAllEnabledAsync();

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
