using CollaboratorTest._2._Application.DTO.Responses;
using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorCompanyLinkHandler;
using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorHandlers;
using CollaboratorTest._2._Application.Interfaces.Handlers.CompanyHandlers;
using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Application.Interfaces;

namespace CollaboratorTest.Application.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly IWriterCollaboratorCompanyLinkHandler _writerCollaboratorCompanyLinkHandler;
        private readonly IReaderCollaboratorHandler _readerCollaboratorHandler;
        private readonly IWriterCollaboratorHandler _writerCollaboratorHandler;
        private readonly IReaderCompanyHandler _readerCompanyHandler;

        public CollaboratorService(
            IWriterCollaboratorCompanyLinkHandler writerCollaboratorCompanyLinkHandler,
            IReaderCollaboratorHandler readerCollaboratorHandler,
            IWriterCollaboratorHandler writerCollaboratorHandler,
            IReaderCompanyHandler readerCompanyHandler)
        {
            _writerCollaboratorCompanyLinkHandler = writerCollaboratorCompanyLinkHandler;
            _readerCollaboratorHandler = readerCollaboratorHandler;
            _writerCollaboratorHandler = writerCollaboratorHandler;
            _readerCompanyHandler = readerCompanyHandler;
        }

        public async Task<List<CollaboratorCompanyLinkResponseDto>> GetAll()
        {
            return await _readerCollaboratorHandler.HandleGetAllAsync();
        }

        public async Task<List<CollaboratorCompanyLinkResponseDto>> GetAllEnabled()
        {
            return await _readerCollaboratorHandler.HandleGetAllEnabledAsync();
        }

        public async Task<List<CollaboratorCompanyLinkResponseDto>?> GetCollaboratorById(long id)
        {
            return await _readerCollaboratorHandler.HandleByIdAsync(id);
        }

        public async Task UpdateCollaborator(long collaboratorId, CollaboratorCompanyLinkRequestDto dto)
        {
            await _readerCompanyHandler.HandleGetByIdAsync(dto.CompanyId);

            await _writerCollaboratorHandler.HandleUpdateAsync(dto, collaboratorId);

            await _writerCollaboratorCompanyLinkHandler.HandleUpdateAsync(dto, collaboratorId);
        }

        public async Task<long> AddCollaborator(CollaboratorCompanyLinkRequestDto dto)
        {
            var collaboratorId = await _writerCollaboratorHandler.HandleAddAsync(dto);

            await _writerCollaboratorCompanyLinkHandler.HandleAddAsync(dto, collaboratorId);

            return collaboratorId;
        }

        public async Task DeleteCollaborator(long collaboratorId)
        {
            await _writerCollaboratorHandler.HandleDeleteAsync(collaboratorId);
        }
    }
}
