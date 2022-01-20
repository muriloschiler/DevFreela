using System.Threading.Tasks;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;

namespace DevFreela.Application.Services.Interfaces{

    public interface IUserService{
        Task<LoginViewModel> Login(LoginInputModel loginModelInputModel);
        Task<int> AddUser(CreateUserInputModel createUserInputModel);
        Task<UserDetailsViewModel> GetUser(int id);
        
        Task<bool> addSkil(AddSkilInputModel addSkilInputModel);
        

    }
}