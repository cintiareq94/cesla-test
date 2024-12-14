namespace CollaboratorTest.Application.Commands.CollaboratorCommands
{
    public class AddCollaboratorCompanyLinkCommand
    {
        public long Id { get; set; }
        public long CollaboratorId { get; set; }
        public long CompanyId { get; set; }
        public bool IsEnabled { get; set; }
    }
}
