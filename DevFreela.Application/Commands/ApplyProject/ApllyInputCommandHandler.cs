using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DevFreela.Application.Commands.ApplyProject
{
    public class ApllyInputCommandHandler : IRequestHandler<ApllyInputCommand, Unit>
    {
        public Task<Unit> Handle(ApllyInputCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}