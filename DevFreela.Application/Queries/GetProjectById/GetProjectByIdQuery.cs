using MediatR;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
    {

        public GetProjectByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
    }
}