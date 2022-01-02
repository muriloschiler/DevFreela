using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;

namespace DevFreela.Application.Services.Interfaces{

    public interface IUserService{
        LoginViewModel Login(LoginInputModel loginModelInputModel);
        int AddUser(CreateUserInputModel createUserInputModel);
        UserDetailsViewModel GetUser(int id);
    }
}