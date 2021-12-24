using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetCommentById
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, ProjectCommentDetailsViewModel>
    {
            public readonly DevFreelaDbContext _devFreelaDbContext;

            public GetCommentByIdQueryHandler(DevFreelaDbContext devFreelaDbContext)
            {
                _devFreelaDbContext = devFreelaDbContext;
            }

        public async Task<ProjectCommentDetailsViewModel> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {

            var projectComment = await _devFreelaDbContext.ProjectComments.SingleOrDefaultAsync(p=> p.IdProject ==request.ProjectId && p.Id==request.ProjectId);
            var projectDetailsViewModel = new ProjectCommentDetailsViewModel(projectComment.Content,projectComment.IdProject,projectComment.IdUser,projectComment.CreatedAt);
        
            return projectDetailsViewModel;        }
    }
}