using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DevFreela.Core.DTO;
using DevFreela.Core.IServices;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IMessageBusService _messageBusService;
        public PaymentService(IMessageBusService messageBusService)
        {
            this._messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfoInputModel paymentInfoInputModel)
        {
            var paymentInfoContentJSON = JsonSerializer.Serialize(paymentInfoInputModel);
            var paymentInfoContentBYTES = Encoding.UTF8.GetBytes(paymentInfoContentJSON);

            _messageBusService.Publish("Payments",paymentInfoContentBYTES);
            
        }
    }
}