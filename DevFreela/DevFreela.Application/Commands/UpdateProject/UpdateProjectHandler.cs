using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = await _projectRepository.GetProject(request.Id);
            if(project != null){

                project.Update(request.Title,request.Description,request.TotalCost);
                await _projectRepository.SaveChangesAsync();

                return Unit.Value;
            }
            return Unit.Value;
    }
}
}