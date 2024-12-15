using CollaboratorTest._2._Application.DTO.Responses;
using CollaboratorTest.Application.DTO;
using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest._4._Infrastructure.Helpers
{
    public static class CollaboratorCompanyLinkHelper
    {
        public static List<CollaboratorCompanyLinkResponseDto> MapToResponseDtos(IEnumerable<Collaborator> collaborators)
        {
            var response = new List<CollaboratorCompanyLinkResponseDto>();

            foreach (var collaborator in collaborators)
            {
                var companyLinks = collaborator.CollaboratorCompanyLinks
                    .GroupBy(c => c.CompanyId)
                    .ToDictionary(g => g.Key, g => g.First());

                foreach (var colab in companyLinks)
                {
                    var companyId = colab.Key;
                    var link = colab.Value;

                    response.Add(new CollaboratorCompanyLinkResponseDto
                    {
                        CompanyId = companyId,
                        IsCompanyEnabled = link.Company.IsEnabled,
                        IsLinkEnabled = link.IsEnabled,
                        Collaborator = new CollaboratorResponseDto
                        {
                            Id = link.Collaborator.Id,
                            Name = link.Collaborator.Name,
                            Address = link.Collaborator.Address,
                            Email = link.Collaborator.Email,
                            Phone = link.Collaborator.Phone,
                            Document = link.Collaborator.Document,
                            Role = link.Role,
                            Department = link.Department,
                            CreationDate = link.Collaborator.CreationDate
                        }
                    });
                }
            }

            return response;
        }

        public static List<CollaboratorCompanyLinkResponseDto> MapCollaboratorToResponseDtos(Collaborator collaborator)
        {
            var response = new List<CollaboratorCompanyLinkResponseDto>();

            var companyLinks = collaborator.CollaboratorCompanyLinks
                .GroupBy(c => c.CompanyId)
                .ToDictionary(g => g.Key, g => g.First());

            foreach (var colab in companyLinks)
            {
                var companyId = colab.Key;
                var link = colab.Value;

                var newDto = new CollaboratorCompanyLinkResponseDto
                {
                    CompanyId = companyId,
                    IsCompanyEnabled = link.Company.IsEnabled,
                    IsLinkEnabled = link.IsEnabled,
                    Collaborator = new CollaboratorResponseDto
                    {
                        Id = link.Collaborator.Id,
                        Name = link.Collaborator.Name,
                        Address = link.Collaborator.Address,
                        Email = link.Collaborator.Email,
                        Phone = link.Collaborator.Phone,
                        Document = link.Collaborator.Document,
                        Role = link.Role,
                        Department = link.Department,
                        CreationDate = link.Collaborator.CreationDate
                    }
                };

                response.Add(newDto);
            }

            return response;
        }
    }
}
