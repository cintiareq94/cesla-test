namespace CollaboratorTest.Application.Queries.CollaboratorQueries
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
