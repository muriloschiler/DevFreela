using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Queries.GetAllComments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<ProjectCommentViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllCommentsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectCommentViewModel>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var ProjectComments = await _projectRepository.GetAllComments(request.ProjectId);
            var listProjectCommentsViewModel = ProjectComments
                                                    .Select(p => new ProjectCommentViewModel(p.Content,p.IdUser))
                                                    .ToList();

            return listProjectCommentsViewModel;        }
    }
}