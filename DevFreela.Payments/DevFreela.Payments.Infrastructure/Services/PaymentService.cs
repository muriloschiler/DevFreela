using System.Threading.Tasks;
using DevFreela.Payments.Core.DTO.InputModel;
using DevFreela.Payments.Core.Interfaces;

namespace DevFreela.Payments.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<bool> Pay(PaymentInfoInputModel paymentInfoInputModel)
        {
            //Pagamento atraves do gateway de pagamento
            return  Task.FromResult(true);
        }
    }
}