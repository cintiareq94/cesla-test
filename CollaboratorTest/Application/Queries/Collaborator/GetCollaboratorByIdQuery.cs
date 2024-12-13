namespace CollaboratorTest.Application.Queries.Collaborator
{
    public class GetCollaboratorByIdQuery
    {

        public long Id { get; set; }

        public GetCollaboratorByIdQuery(long id)
        {
            Id = id;
        }
    }
}
