namespace CollaboratorTest.Application.DTO.Requests
{
    public class CollaboratorCompanyLinkRequestDto
    {
        public long CompanyId { get; set; }

        public bool IsEnabled { get; set; } = true;

        public CollaboratorRequestDto Collaborator { get; set; }
    }
}
