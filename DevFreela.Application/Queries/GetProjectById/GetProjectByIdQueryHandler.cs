using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            Project project = await _projectRepository.GetProjectIncluded(request.Id);
                                                            
                                                            

            ProjectDetailsViewModel projectDetailsViewModel = new ProjectDetailsViewModel
                                                                        (
                                                                            project.Id,
                                                                            project.Title, 
                                                                            project.Description, 
                                                                            project.IdClient,
                                                                            project.Client,
                                                                            project.IdFreelancer,
                                                                            project.Freelancer, 
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