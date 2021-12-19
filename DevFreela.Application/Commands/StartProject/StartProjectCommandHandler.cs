using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _devFreelaDbContext;
        public StartProjectCommandHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext=devFreelaDbContext;
        }
        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = _devFreelaDbContext.Projects.SingleOrDefault(p=> p.Id == request.Id);
            if(project !=null){
                project.Start();        
                await _devFreelaDbContext.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}