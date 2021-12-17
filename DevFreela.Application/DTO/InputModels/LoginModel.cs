
namespace DevFreela.Application.DTO.InputModels
{
    public class LoginModel
    {

        public LoginModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;

        }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}