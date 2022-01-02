namespace DevFreela.Application.DTO.ViewModels
{
    public class LoginViewModel
    {

        public LoginViewModel(string jWTToken, string email)
        {
            this.JWTToken = jWTToken;
            this.Email = email;

        }
        public string JWTToken { get; set; }
        public string Email { get; set; }



    }
}