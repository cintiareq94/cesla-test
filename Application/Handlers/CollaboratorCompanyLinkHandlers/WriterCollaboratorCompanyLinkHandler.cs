using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorCompanyLinkHandler;
using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorHandlers;
using CollaboratorTest._2._Application.Interfaces.Handlers.CompanyHandlers;
using CollaboratorTest._3._Domain.Interfaces.CollaboratorCompanyLinkInterfaces;
using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest._2._Application.Handlers.CollaboratorCompanyLinkHandlers
{
    public class WriterCollaboratorCompanyLinkHandler : IWriterCollaboratorCompanyLinkHandler
    {
        private readonly ICollaboratorCompanyLinkCommandRepository _commandRepository;
        private readonly ICollaboratorCompanyLinkQueryRepository _queryRepository;
        private readonly IReaderCollaboratorHandler _readerCollaboratorHandler;
        private readonly IReaderCompanyHandler _readerCompanyHandler;

        public WriterCollaboratorCompanyLinkHandler(
            ICollaboratorCompanyLinkCommandRepository commandRepository,
            ICollaboratorCompanyLinkQueryRepository queryRepository,
            IReaderCollaboratorHandler readerCollaboratorHandler,
            IReaderCompanyHandler readerCompanyHandler)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _readerCollaboratorHandler = readerCollaboratorHandler;
            _readerCompanyHandler = readerCompanyHandler;
        }

        public async Task HandleAddAsync(CollaboratorCompanyLinkRequestDto dto, long collaboratorId)
        {
            var collaboratorCompanyLink = new CollaboratorCompanyLink
            {
                CollaboratorId = collaboratorId,
                CompanyId = dto.CompanyId,
                Role = dto.CollaboratorRole,
                Department = dto.CollaboratorDepartment,
                IsEnabled = dto.IsEnabled,
            };

            var collaborator = await _readerCollaboratorHandler.HandleByIdAsync(collaboratorCompanyLink.CollaboratorId);

            if (collaborator == null)
                throw new Exception($"Collaborator with ID {collaboratorCompanyLink.CollaboratorId} not found.");

            var company = await _readerCompanyHandler.HandleGetByIdAsync(collaboratorCompanyLink.CompanyId);

            if (company == null)
                throw new Exception($"Company with ID {collaboratorCompanyLink.CompanyId} not found.");

            await _commandRepository.AddAsync(collaboratorCompanyLink);
        }

        public async Task HandleUpdateAsync(CollaboratorCompanyLinkRequestDto dto, long collaboratorId)
        {
            var collaboratorCompanyLink = await _queryRepository.GetByCollaboratorAndCompanyIdAsync(collaboratorId, dto.CompanyId);

            if (collaboratorCompanyLink == null)
                throw new Exception($"CollaboratorCompanyLink with CollaboratorID {collaboratorId} and {dto.CompanyId} not found.");

            collaboratorCompanyLink.Role = dto.CollaboratorRole;
            collaboratorCompanyLink.Department = dto.CollaboratorDepartment;
            collaboratorCompanyLink.IsEnabled = dto.IsEnabled;

            await _commandRepository.UpdateAsync(collaboratorCompanyLink);
        }

        public async Task HandleDeleteAsync(long id)
        {
            var collaborator = await _queryRepository.GetByIdAsync(id);

            if (collaborator == null)
                throw new Exception($"Collaborator with ID {id} not found.");

            await _commandRepository.DeleteAsync(id);
        }
    }
}
