namespace CollaboratorTest.Application.Commands.Collaborator
{
    namespace CollaboratorTest.Application.Commands
    {

        public class AddCompanyCommand
        {

            public long Id { get; set; }
            public string TradeName { get; set; }
            public string Document { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public bool IsEnabled { get; set; }
        }

    }
}
