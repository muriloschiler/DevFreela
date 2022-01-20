using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.ApplyProject
{
    public class ApllyInputCommandHandler : IRequestHandler<ApllyInputCommand, bool>
    {
        private IProjectRepository _projectRepository;

        public ApllyInputCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> Handle(ApllyInputCommand request, CancellationToken cancellationToken)
        {
            //Adicionar na ListCandidates
            var project = await _projectRepository.GetProject(request.idProject);
            
            if(project.Aplly(request.IdFreelancer))
                return true;
            
            return false;
        }
    }
}