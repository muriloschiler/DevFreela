using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Queries.GetAllComments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<ProjectCommentViewModel>>
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;

        public GetAllCommentsQueryHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }

        public Task<List<ProjectCommentViewModel>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var listProjectCommentsViewModel = _devFreelaDbContext.ProjectComments
                                                        .Where(p => p.IdProject == request.ProjectId)
                                                        .Select(p => new ProjectCommentViewModel(p.Content,p.IdUser))
                                                        .ToList();
            return Task.FromResult(listProjectCommentsViewModel);        }
    }
}