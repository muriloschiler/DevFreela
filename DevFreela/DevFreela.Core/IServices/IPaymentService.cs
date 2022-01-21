using System.Threading.Tasks;
using DevFreela.Core.DTO;

namespace DevFreela.Core.IServices
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoInputModel paymentInfoInputModel);
    }
}