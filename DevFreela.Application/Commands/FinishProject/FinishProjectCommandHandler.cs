using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _devFreelaDbContext;
        public FinishProjectCommandHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext=devFreelaDbContext;
        }
        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p=> p.Id == request.Id);
                if(project !=null)
                {
                    project.Finish();
                    await _devFreelaDbContext.SaveChangesAsync();
                }
                return Unit.Value;
        }
    }
}