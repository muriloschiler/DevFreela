using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly DevFreelaDbContext _devFreelaDbContext;
        public CreateProjectCommandHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext=devFreelaDbContext;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            Project newProject = new Project(   request.Title,
                                                request.Description,
                                                request.IdClient,
                                                request.IdFreelancer,
                                                request.TotalCost);

            await _devFreelaDbContext.Projects.AddAsync(newProject);
            await _devFreelaDbContext.SaveChangesAsync();
            return newProject.Id;
        }
    }
}