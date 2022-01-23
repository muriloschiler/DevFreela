using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Core.IAuth;
using DevFreela.Core.IRepositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implemations{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _devFreelaDbContext;
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public UserService(DevFreelaDbContext devFreelaDbContext,IAuthService authService,IUserRepository userRepository)
        {
            _devFreelaDbContext=devFreelaDbContext;
            _authService=authService;
            _userRepository = userRepository;
        }

        public async Task<bool> addSkil(AddSkilInputModel addSkilInputModel)
        {
            var user = await _userRepository.GetUserByIdAsync(addSkilInputModel.idFreelancer);
            if(user == null)
                return false;
            
            var skill = await _devFreelaDbContext.Skills.SingleOrDefaultAsync(s => s.Id == addSkilInputModel.idSkill);
            if(skill == null)
                return false;

            user.SetSkills(skill.Id);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<int> AddUser(CreateUserInputModel createUserInputModel)
        {
            User newUser = new User
            (
                createUserInputModel.Name,
                _authService.ComputeSha256Hash(createUserInputModel.Password),
                createUserInputModel.Role,
                createUserInputModel.BirthDate,
                createUserInputModel.Email
            );
            await _userRepository.AddUserAsync(newUser);
            return newUser.Id;
            
        }
        public async Task<UserDetailsViewModel> GetUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            UserDetailsViewModel userDetails = new UserDetailsViewModel(user.Name,user.BirthDate,user.Email,user.CreatedAt,
                                                                            user.UserStatus,user.Skills,user.OwnedProjects,
                                                                            user.FreelancerProjects,user.Comments);
                                                                        
            return userDetails;
        }

        public async Task<LoginViewModel> Login(LoginInputModel loginModelInputModel)
        {
            var passwordHash = _authService.ComputeSha256Hash(loginModelInputModel.Password);
            var user = await _userRepository.LoginAsync(loginModelInputModel.Email,passwordHash);
            
            if(user !=null ){
                var token = _authService.GenerateJWTToken(user.Email,user.Role.ToString());
                return new LoginViewModel(token,user.Email);
            }
            return null;                            
        }
    }
}
