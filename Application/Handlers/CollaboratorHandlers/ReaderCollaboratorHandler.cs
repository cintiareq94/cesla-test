using CollaboratorTest._2._Application.DTO.Responses;
using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorHandlers;
using CollaboratorTest._4._Infrastructure.Helpers;
using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;

namespace CollaboratorTest._2._Application.Handlers.CollaboratorHandlers
{
    public class ReaderCollaboratorHandler : IReaderCollaboratorHandler
    {
        private readonly ICollaboratorQueryRepository _queryRepository;

        public ReaderCollaboratorHandler(ICollaboratorQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<CollaboratorCompanyLinkResponseDto>> HandleByIdAsync(long id)
        {
            var collaborator = await _queryRepository.GetByIdAsync(id);

            if (collaborator == null) throw new Exception($"Collaborator with {id} not found");

            return CollaboratorCompanyLinkHelper.MapCollaboratorToResponseDtos(collaborator);
        }

        public async Task<CollaboratorCompanyLinkResponseDto> HandleByDocumentAsync(string document)
        {
            var collaborator = await _queryRepository.GetByDocumentAsync(document);

            if (collaborator == null || !collaborator.CollaboratorCompanyLinks.Any()) 
                return new CollaboratorCompanyLinkResponseDto();

            return CollaboratorCompanyLinkHelper.MapCollaboratorToResponseDtos(collaborator).First();
        }

        public async Task<List<CollaboratorCompanyLinkResponseDto>> HandleGetAllAsync()
        {
            var collaborators = await _queryRepository.GetAllAsync();

            var response = CollaboratorCompanyLinkHelper.MapToResponseDtos(collaborators);

            return response;
        }

        public async Task<List<CollaboratorCompanyLinkResponseDto>> HandleGetAllEnabledAsync()
        {
            var collaborators = await _queryRepository.GetAllEnabledAsync();

            var response = CollaboratorCompanyLinkHelper.MapToResponseDtos(collaborators);

            return response;
        }
    }
}
