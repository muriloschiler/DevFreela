using System.Threading.Tasks;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;

namespace DevFreela.Application.Services.Interfaces{

    public interface IUserService{
        Task<LoginViewModel> LoginAsync(LoginInputModel loginModelInputModel);
        Task<int> AddUserAsync(CreateUserInputModel createUserInputModel);
        Task<UserDetailsViewModel> GetUserAsync(int id);
        
        Task<bool> addSkilAsync(AddSkilInputModel addSkilInputModel);
        

    }
}