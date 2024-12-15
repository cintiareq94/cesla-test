using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorCompanyLinkHandler;
using CollaboratorTest._2._Application.Interfaces.Handlers.CompanyHandlers;
using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Application.DTO.Responses;
using CollaboratorTest.Application.Interfaces;

namespace CollaboratorTest.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IWriterCompanyHandler _writerCompanyHandler;
        private readonly IReaderCompanyHandler _readerCompanyHandler;
        private readonly IReaderCollaboratorCompanyLinkHandler _readerCollaboratorCompanyLinkHandler;
        private readonly IWriterCollaboratorCompanyLinkHandler _writerCollaboratorCompanyLinkHandler;

        public CompanyService(IWriterCompanyHandler writerCompanyHandler,
            IReaderCompanyHandler readerCompanyHandler,
            IReaderCollaboratorCompanyLinkHandler readerCollaboratorCompanyLinkHandler,
            IWriterCollaboratorCompanyLinkHandler writerCollaboratorCompanyLinkHandler)
        {
            _writerCompanyHandler = writerCompanyHandler;
            _readerCompanyHandler = readerCompanyHandler;
            _readerCollaboratorCompanyLinkHandler = readerCollaboratorCompanyLinkHandler;
            _writerCollaboratorCompanyLinkHandler = writerCollaboratorCompanyLinkHandler;
        }

        public async Task<List<CompanyResponseDto>> GetAllAsync()
        {
            var companies = await _readerCompanyHandler.HandleGetAllAsync();
            return companies.Select(c => new CompanyResponseDto
            {
                Id = c.Id,
                TradeName = c.TradeName,
                Address = c.Address,
                Document = c.Document,
                IsEnabled = c.IsEnabled,
                Phone = c.Phone
            }).OrderBy(c => c.TradeName).ToList();
        }

        public async Task<List<CompanyResponseDto>> GetAllEnabledAsync()
        {
            var companies = await _readerCompanyHandler.HandleGetAllEnabledAsync();
            return companies.Select(c => new CompanyResponseDto
            {
                Id = c.Id,
                TradeName = c.TradeName,
                Address = c.Address,
                Phone = c.Phone,
                Document = c.Document,
                IsEnabled = c.IsEnabled
            }).OrderBy(c => c.TradeName).ToList();
        }

        public async Task<CompanyResponseDto?> GetByIdAsync(long id)
        {
            var company = await _readerCompanyHandler.HandleGetByIdAsync(id);
            if (company == null) return null;

            return new CompanyResponseDto
            {
                Id = company.Id,
                TradeName = company.TradeName,
                Address = company.Address,
                Document = company.Document,
                IsEnabled = company.IsEnabled,
                Phone = company.Phone
            };
        }

        public async Task<long> AddAsync(CompanyRequestDto dto)
        {
            var company = await _readerCompanyHandler.HandleGetByDocumentAsync(dto.Document);

            long companyId;

            if (company.Document == null)
                companyId = await _writerCompanyHandler.HandleAddAsync(dto);
            else
                throw new Exception($"Company with Document {dto.Document} already exists.");

            return companyId;
        }

        public async Task UpdateAsync(long id, CompanyRequestDto dto)
        {
            var company = await _readerCompanyHandler.HandleGetByIdAsync(id);

            if (company == null) throw new Exception($"Company with ID {id} not found.");

            if (company.IsEnabled == true)
                await _writerCompanyHandler.HandleUpdateAsync(id, dto);
            else
                throw new Exception($"Company with ID {id} is disabled.");
        }

        public async Task DeleteAsync(long companyId)
        {
            await _writerCompanyHandler.HandleDeleteAsync(companyId);

            var links = await _readerCollaboratorCompanyLinkHandler.HandleGetLinkByCompanyId(companyId);

            if (links == null)
                return;

            if (links.Where(c => c.IsEnabled).Any())
            {
                foreach (var link in links)
                {
                    await _writerCollaboratorCompanyLinkHandler.HandleDeleteAsync(link.Id);
                }
            }
        }
    }
}