
namespace DevFreela.Application.DTO.InputModels
{
    public class LoginInputModel
    {

        public LoginInputModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;

        }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}