using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;
        public UpdateProjectHandler (DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext=devFreelaDbContext;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == request.Id);
            if(project != null){
                project.Update(request.Title,request.Description,request.TotalCost);
                await _devFreelaDbContext.SaveChangesAsync();
                return Unit.Value;
            }
            return Unit.Value;
    }
}
}