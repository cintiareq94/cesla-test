namespace CollaboratorTest.Domain.Models.Entities
{
    public class Collaborator
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Document { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<CollaboratorCompanyLink> CollaboratorCompanyLinks { get; set; }
    }
}