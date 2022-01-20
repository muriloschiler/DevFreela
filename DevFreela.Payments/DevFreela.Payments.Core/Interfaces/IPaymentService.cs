using System.Threading.Tasks;
using DevFreela.Payments.Core.DTO.InputModel;

namespace DevFreela.Payments.Core.Interfaces
{
    public interface IPaymentService
    {
         Task<bool> Pay(PaymentInfoInputModel paymentInfoInputModel);
    }
}