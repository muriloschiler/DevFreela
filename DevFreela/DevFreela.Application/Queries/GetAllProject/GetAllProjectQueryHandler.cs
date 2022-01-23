using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetAllProject;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetProject
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;
        public GetAllProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {

            var projects = await _projectRepository.GetAllProjects(request.Query);
            var listProjectViewModel = projects
                                        .Select(p=> new ProjectViewModel(p.Id,p.Title,p.Description,p.IdClient,p.Client.Name,
                                                                         p.IdFreelancer,p.TotalCost,p.ProjectStatus))
                                        .ToList();
            return listProjectViewModel; 
        }
    }
}