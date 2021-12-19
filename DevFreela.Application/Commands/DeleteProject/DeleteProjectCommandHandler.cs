using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _devFreelaDbContext;

        public DeleteProjectCommandHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext=devFreelaDbContext;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p=> p.Id == request.Id);
            if(project !=null){
                project.Cancel();
                await _devFreelaDbContext.SaveChangesAsync();
            }
        
            return Unit.Value;
        }
    }
}