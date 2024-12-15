using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorHandlers;
using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest._2._Application.Handlers.CollaboratorHandlers
{
    public class WriterCollaboratorHandler : IWriterCollaboratorHandler
    {
        private readonly ICollaboratorCommandRepository _commandRepository;
        private readonly ICollaboratorQueryRepository _queryRepository;

        public WriterCollaboratorHandler(
            ICollaboratorCommandRepository commandRepository,
            ICollaboratorQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<long> HandleAddAsync(CollaboratorCompanyLinkRequestDto dto)
        {
            var collaborator = new Collaborator
            {
                Name = dto.Collaborator.Name,
                Address = dto.Collaborator.Address,
                Email = dto.Collaborator.Email,
                Phone = dto.Collaborator.Phone,
                Document = dto.Collaborator.Document,
                CreationDate = DateTime.Now.ToUniversalTime(),
            };

            await _commandRepository.AddAsync(collaborator);

            return collaborator.Id;
        }

        public async Task HandleUpdateAsync(CollaboratorCompanyLinkRequestDto dto, long collaboratorId)
        {
            var collaborator = await _queryRepository.GetByIdAsync(collaboratorId);

            if (collaborator == null)
                throw new Exception($"Collaborator with ID {collaboratorId} not found.");

            collaborator.Name = dto.Collaborator.Name;
            collaborator.Address = dto.Collaborator.Address;
            collaborator.Email = dto.Collaborator.Email;
            collaborator.Phone = dto.Collaborator.Phone;

            await _commandRepository.UpdateAsync(collaborator);
        }
    }
}