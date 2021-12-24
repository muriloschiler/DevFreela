using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Queries.GetProject
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, List<ProjectViewModel>>
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;

        public GetProjectQueryHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }

        public Task<List<ProjectViewModel>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {

            var projects = _devFreelaDbContext.Projects;
            var listProjectViewModel = projects
                                        .Select(p=> new ProjectViewModel(p.Id,p.Title,p.Description,p.IdClient,p.Client.Name,
                                                                         p.IdFreelancer,p.TotalCost,p.ProjectStatus))
                                        .ToList();
            return Task.FromResult(listProjectViewModel); 
        }
    }
}