namespace CollaboratorTest.Domain.Models.Entities
{
    public class CollaboratorCompanyLink
    {
        public long Id { get; set; }
        public long CollaboratorId { get; set; }
        public long CompanyId { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public bool IsEnabled { get; set; }
        public virtual Collaborator Collaborator { get; set; }
        public virtual Company Company { get; set; }
    }
}