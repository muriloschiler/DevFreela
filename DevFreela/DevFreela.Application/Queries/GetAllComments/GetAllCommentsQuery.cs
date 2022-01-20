using System.Collections.Generic;
using DevFreela.Application.DTO.InputModels;
using MediatR;

namespace DevFreela.Application.Queries.GetAllComments
{
    public class GetAllCommentsQuery : IRequest<List<ProjectCommentViewModel>>
    {

        public GetAllCommentsQuery(int projectId)
        {
            this.ProjectId = projectId;

        }
        public int ProjectId { get; private set; }
    }
}