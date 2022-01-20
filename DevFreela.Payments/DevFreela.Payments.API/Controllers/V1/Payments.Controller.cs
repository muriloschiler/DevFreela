using System.Threading.Tasks;
using DevFreela.Payments.Core.DTO.InputModel;
using DevFreela.Payments.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Payments.API.Controllers
{
    [Route("api/v1/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> PayFreelancer([FromBody]PaymentInfoInputModel paymentInfoInputModel){
            var result = await _paymentService.Pay(paymentInfoInputModel);
            
            if(!result)
                return BadRequest();
            return NoContent();
        }
    }
}