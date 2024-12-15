using System.Text.Json.Serialization;

namespace CollaboratorTest.Application.DTO.Requests
{
    public class CollaboratorCompanyLinkRequestDto
    {
        public long CompanyId { get; set; }
        public string CollaboratorRole { get; set; }
        public string CollaboratorDepartment { get; set; }
        [JsonIgnore]
        public bool IsEnabled { get; set; } = true;

        public CollaboratorRequestDto Collaborator { get; set; }
    }
}
