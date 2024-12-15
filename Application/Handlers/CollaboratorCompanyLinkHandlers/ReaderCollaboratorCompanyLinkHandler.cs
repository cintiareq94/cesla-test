using CollaboratorTest._2._Application.DTO.Responses;
using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorCompanyLinkHandler;
using CollaboratorTest._3._Domain.Interfaces.CollaboratorCompanyLinkInterfaces;

namespace CollaboratorTest._2._Application.Handlers.CollaboratorCompanyLinkHandlers
{
    public class ReaderCollaboratorCompanyLinkHandler : IReaderCollaboratorCompanyLinkHandler
    {
        private readonly ICollaboratorCompanyLinkQueryRepository _queryRepository;

        public ReaderCollaboratorCompanyLinkHandler(
            ICollaboratorCompanyLinkQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<CollaboratorCompanyLinkResponse>> HandleGetAll()
        {
            var collaboratorCompanyLinks = await _queryRepository.GetAllAsync();

            var response = new List<CollaboratorCompanyLinkResponse>();

            foreach (var link in collaboratorCompanyLinks)
            {
                var newDto = new CollaboratorCompanyLinkResponse
                {
                    Id = link.Id,
                    CollaboratorId = link.CollaboratorId,
                    CompanyId = link.CompanyId,
                    Role = link.Role,
                    Department = link.Department,
                    IsEnabled = link.IsEnabled
                };

                response.Add(newDto);
            }

            return response;
        }

        public async Task<List<CollaboratorCompanyLinkResponse>> HandleGetAllEnabled()
        {
            var collaboratorCompanyLinks = await _queryRepository.GetAllEnabledAsync();

            var response = new List<CollaboratorCompanyLinkResponse>();

            foreach (var link in collaboratorCompanyLinks)
            {
                var newDto = new CollaboratorCompanyLinkResponse
                {
                    Id = link.Id,
                    CollaboratorId = link.CollaboratorId,
                    CompanyId = link.CompanyId,
                    Role = link.Role,
                    Department = link.Department,
                    IsEnabled = link.IsEnabled
                };

                response.Add(newDto);
            }

            return response;
        }

        public async Task<CollaboratorCompanyLinkResponse?> HandleGetLinkById(long id)
        {
            var link = await _queryRepository.GetByIdAsync(id);

            if (link == null)
                throw new Exception($"CollaboratorCompanyLink with {id} not found");

            var response = new CollaboratorCompanyLinkResponse
            {
                Id = link.Id,
                CollaboratorId = link.CollaboratorId,
                CompanyId = link.CompanyId,
                Role = link.Role,
                Department = link.Department,
                IsEnabled = link.IsEnabled
            };

            return response;
        }

        public async Task<List<CollaboratorCompanyLinkResponse?>> HandleGetLinkByCollaboratorId(long id)
        {
            var links = await _queryRepository.GetByCollaboratorIdAsync(id);

            if (links == null) throw new ArgumentNullException(nameof(links));

            var response = new List<CollaboratorCompanyLinkResponse?>();

            foreach (var link in links)
            {
                var newDto = new CollaboratorCompanyLinkResponse
                {
                    Id = link.Id,
                    CollaboratorId = link.CollaboratorId,
                    CompanyId = link.CompanyId,
                    Role = link.Role,
                    Department = link.Department,
                    IsEnabled = link.IsEnabled
                };

                response.Add(newDto);
            }

            return response;
        }

        public async Task<List<CollaboratorCompanyLinkResponse>> HandleGetLinkByCompanyId(long id)
        {
            var links = await _queryRepository.GetByCompanyIdAsync(id);

            if (links == null) throw new ArgumentNullException(nameof(links));

            var response = new List<CollaboratorCompanyLinkResponse?>();

            foreach (var link in links)
            {
                var newDto = new CollaboratorCompanyLinkResponse
                {
                    Id = link.Id,
                    CollaboratorId = link.CollaboratorId,
                    CompanyId = link.CompanyId,
                    Role = link.Role,
                    Department = link.Department,
                    IsEnabled = link.IsEnabled
                };

                response.Add(newDto);
            }

            return response;
        }


        public async Task<CollaboratorCompanyLinkResponse?> HandleGetByCollaboratorAndCompanyIdAsync(long collaboratorId, long companyId)
        {
            var link = await _queryRepository.GetByCollaboratorAndCompanyIdAsync(collaboratorId, companyId);

            var response = new CollaboratorCompanyLinkResponse
            {
                Id = link.Id,
                CollaboratorId = link.CollaboratorId,
                CompanyId = link.CompanyId,
                Role = link.Role,
                Department = link.Department,
                IsEnabled = link.IsEnabled
            };

            return response;
        }
    }
}
