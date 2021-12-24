using DevFreela.Application.DTO.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetCommentById
{
    public class GetCommentByIdQuery : IRequest<ProjectCommentDetailsViewModel>
    {


        public GetCommentByIdQuery(int projectId, int commentId)
        {
            this.ProjectId = projectId;
            this.CommentId = commentId;

        }
        public int ProjectId { get; private set; }
        public int CommentId { get; private set; }
    }
}