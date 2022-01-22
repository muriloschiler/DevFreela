namespace DevFreela.Payments.Core.DTO.InputModel
{
    public class PaymentApprovedIntegrationEvent
    {
        public PaymentApprovedIntegrationEvent(int idProject)
        {
            IdProject = idProject;
        }

        public int IdProject { get; set; }
        
    }
}