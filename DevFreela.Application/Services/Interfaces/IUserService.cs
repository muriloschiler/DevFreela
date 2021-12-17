using DevFreela.Application.DTO.InputModels;

namespace DevFreela.Application.Services.Interfaces{

    public interface IUserService{
        void Login(LoginModel loginModel);
        void AddUser(CreateUserInputModel createUserInputModel);
        UserDetailsViewModel GetUser(int id);
    }
}