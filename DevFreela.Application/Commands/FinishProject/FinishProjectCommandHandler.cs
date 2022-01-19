using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.DTO;
using DevFreela.Core.Entities;
using DevFreela.Core.IServices;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IPaymentService _paymentService;


        public FinishProjectCommandHandler(IProjectRepository projectRepository,IPaymentService paymentService)
        {
            _projectRepository = projectRepository;
            _paymentService = paymentService;

        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = await _projectRepository.GetProject(request.IdProject);
                if(project !=null)
                {
                    PaymentInfoInputModel paymentInfoInputModel  = new PaymentInfoInputModel{
                        IdProject = request.IdProject,
                        CreditCardNumber = request.CreditCardNumber,
                        Cvv = request.Cvv,
                        ExpiresAt = request.ExpiresAt,
                        FullName = request.FullName,
                        Amount = request.Amount
                    };
                    
                    if(await _paymentService.Payment(paymentInfoInputModel)){
                        await _projectRepository.FinishProject(project);
                        await _projectRepository.SaveChangesAsync();
                        return Unit.Value;
                    }
                    await _projectRepository.SetPaymentPending(project);
                    return Unit.Value;

                }
                return Unit.Value;
        }
    }
}





