using System.Threading.Tasks;
using DevFreela.Core.DTO;

namespace DevFreela.Core.IServices
{
    public interface IPaymentService
    {
         Task<bool> Payment(PaymentInfoInputModel paymentInfoInputModel);
    }
}