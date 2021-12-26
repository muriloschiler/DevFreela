using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetCommentById
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, ProjectCommentDetailsViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public GetCommentByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectCommentDetailsViewModel> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {

            var projectComment = await _projectRepository.GetComment(request.ProjectId,request.CommentId);
            var projectDetailsViewModel = new ProjectCommentDetailsViewModel(projectComment.Content,projectComment.IdProject,projectComment.IdUser,projectComment.CreatedAt);
        
            return projectDetailsViewModel;        }
    }
}