using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.HireProject
{
    public class HireProjectCommandHandler : IRequestHandler<HireProjectCommand, Unit>
    {
        public readonly IProjectRepository _projectRepository;

        public HireProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(HireProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProject(request.idProject);
            if(project !=null )
                project.Hire(request.idFreelancer);
            return Unit.Value;
        }
    }
}