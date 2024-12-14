namespace CollaboratorTest.Domain.Models.Entities
{
    public class CollaboratorCompanyLink
    {
        public long Id { get; set; }
        public long CollaboratorId { get; set; }
        public long CompanyId { get; set; }
        public bool IsEnabled { get; set; }

    }
}
