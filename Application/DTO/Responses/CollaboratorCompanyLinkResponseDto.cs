using CollaboratorTest.Application.DTO;

namespace CollaboratorTest._2._Application.DTO.Responses
{
    public class CollaboratorCompanyLinkResponseDto
    {
        public long CompanyId { get; set; }
        public bool IsCompanyEnabled { get; set; }
        public bool IsLinkEnabled { get; set; }
        public CollaboratorResponseDto Collaborator { get; set; }
    }
}