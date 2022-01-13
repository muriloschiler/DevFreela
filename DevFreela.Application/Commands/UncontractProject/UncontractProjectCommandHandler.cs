using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.UncontractProject
{
    public class UncontractProjectCommandHandler : IRequestHandler<UncontractProjectCommand, Unit>
    {
        public readonly IProjectRepository _projectRepository;

        public UncontractProjectCommandHandler (IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(UncontractProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProject(request.idProject);
            if(project != null){
                project.Uncontract(request.idFreelancer);
            }
            return Unit.Value;
        }
    }
}