using System.Threading.Tasks;
using DevFreela.Core.DTO;
using DevFreela.Core.IServices;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        public Task<bool> Payment(PaymentInfoInputModel paymentInfoInputModel)
        {
            //Pagamento pelo gateway de pagamento
            return Task.FromResult(true);
        }
    }
}