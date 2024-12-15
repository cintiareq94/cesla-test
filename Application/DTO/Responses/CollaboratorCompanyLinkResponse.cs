namespace CollaboratorTest._2._Application.DTO.Responses
{
    public class CollaboratorCompanyLinkResponse
    {
        public long Id { get; set; }
        public long CollaboratorId { get; set; }
        public long CompanyId { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public bool IsEnabled { get; set; }
    }
}