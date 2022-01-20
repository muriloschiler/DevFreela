namespace DevFreela.Payments.Core.DTO.InputModel
{
    public class PaymentInfoInputModel
    {

        public PaymentInfoInputModel(int idProject, string creditCardNumber, string cvv, string expiresAt, string fullName, decimal amount)
        {
            this.IdProject = idProject;
            this.CreditCardNumber = creditCardNumber;
            this.Cvv = cvv;
            this.ExpiresAt = expiresAt;
            this.FullName = fullName;
            this.Amount = amount;

        }
        public int IdProject { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }
        public decimal Amount { get; set; }
    }
}