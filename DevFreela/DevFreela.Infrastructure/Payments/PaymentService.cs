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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _paymentsBaseUrl;

        public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;
        }

        public async Task<bool> ProcessPayment(PaymentInfoInputModel paymentInfoInputModel)
        {
            //Fazer a requisicao para a DevFreela.Payments  
            var url = $"{_paymentsBaseUrl}/api/v1/payments";
            
            var paymentInfoContent = new StringContent(
                JsonSerializer.Serialize(paymentInfoInputModel),
                Encoding.UTF8,
                "application/json"
            );

            var httpClient = _httpClientFactory.CreateClient("Devfreela.Infrastructure.PaymentService");
            var response = await httpClient.PostAsync(url,paymentInfoContent);

            return response.IsSuccessStatusCode;
        }
    }
}