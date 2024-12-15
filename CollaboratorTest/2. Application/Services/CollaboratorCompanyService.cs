using CollaboratorTest._2._Application.DTO.Responses;
using CollaboratorTest._2._Application.Interfaces;
using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorCompanyLinkHandler;
using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorHandlers;

namespace CollaboratorTest._2._Application.Services
{
    public class CollaboratorCompanyService : ICollaboratorCompanyService
    {
        private readonly IWriterCollaboratorCompanyLinkHandler _writerCollaboratorCompanyLinkHandler;
        private readonly IReaderCollaboratorCompanyLinkHandler _readerCollaboratorCompanyLinkHandler;

        public CollaboratorCompanyService(
            IWriterCollaboratorCompanyLinkHandler writerCollaboratorCompanyLinkHandler,
            IReaderCollaboratorCompanyLinkHandler readerCollaboratorCompanyLinkHandler)

        {
            _writerCollaboratorCompanyLinkHandler = writerCollaboratorCompanyLinkHandler;
            _readerCollaboratorCompanyLinkHandler = readerCollaboratorCompanyLinkHandler;
        }


        public async Task<CollaboratorCompanyLinkResponse> GetLinkById(long id)
        {
            return await _readerCollaboratorCompanyLinkHandler.HandleGetLinkById(id);
        }

        public async Task<List<CollaboratorCompanyLinkResponse>> GetAll()
        {
            return await _readerCollaboratorCompanyLinkHandler.HandleGetAll();
        }
        public async Task<List<CollaboratorCompanyLinkResponse>> GetAllEnabled()
        {
           return await _readerCollaboratorCompanyLinkHandler.HandleGetAllEnabled();
        }

        public async Task DeleteCollaboratorCompanyLink(long id)
        {
            await _writerCollaboratorCompanyLinkHandler.HandleDeleteAsync(id);
        }
    }
}

