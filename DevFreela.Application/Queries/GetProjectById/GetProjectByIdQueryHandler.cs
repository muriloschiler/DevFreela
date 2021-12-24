using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;

        public GetProjectByIdQueryHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            Project project = await _devFreelaDbContext.Projects
                                                            .Include(p=>p.Client)
                                                            .Include(p=>p.Freelancer)
                                                            .SingleOrDefaultAsync(p => p.Id == request.Id);
                                                            

            ProjectDetailsViewModel projectDetailsViewModel = new ProjectDetailsViewModel
                                                                        (
                                                                            project.Id,
                                                                            project.Title, 
                                                                            project.Description, 
                                                                            project.IdClient,
                                                                            project.Client.Name,
                                                                            project.Client.Email,
                                                                            project.IdFreelancer, 
                                                                            project.Freelancer.Name,
                                                                            project.Freelancer.Email,
                                                                            project.TotalCost, 
                                                                            project.CreatedAt,
                                                                            project.FinishedAt,
                                                                            project.StartedAt, 
                                                                            project.ProjectStatus, 
                                                                            project.Comments);
        
            return projectDetailsViewModel;
        }
    }
}