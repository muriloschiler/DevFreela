using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Core.IAuth;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implemations{
    public class UserService : IUserService
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;
        public readonly IAuthService _authService;
        public UserService(DevFreelaDbContext devFreelaDbContext,IAuthService authService)
        {
            _devFreelaDbContext=devFreelaDbContext;
            _authService=authService;
        }

        public async Task<bool> addSkil(AddSkilInputModel addSkilInputModel)
        {
            var user = await _devFreelaDbContext.Users.SingleOrDefaultAsync(u => u.Id == addSkilInputModel.idFreelancer);
            if(user == null)
                return false;
            
            var skill = await _devFreelaDbContext.Skills.SingleOrDefaultAsync(s => s.Id == addSkilInputModel.idSkill);
            if(skill == null)
                return false;

            user.SetSkills(skill.Id);
            await _devFreelaDbContext.SaveChangesAsync();
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
            await _devFreelaDbContext.Users.AddAsync(newUser);
            await _devFreelaDbContext.SaveChangesAsync();
            return newUser.Id;
            
        }
        public async Task<UserDetailsViewModel> GetUser(int id)
        {
            User user = await _devFreelaDbContext.Users.SingleOrDefaultAsync(u=>u.Id == id);
            UserDetailsViewModel userDetails = new UserDetailsViewModel(user.Name,user.BirthDate,user.Email,user.CreatedAt,
                                                                            user.UserStatus,user.Skills,user.OwnedProjects,
                                                                            user.FreelancerProjects,user.Comments);
                                                                        
            return userDetails;
        }

        public async Task<LoginViewModel> Login(LoginInputModel loginModelInputModel)
        {
            var passwordHash = _authService.ComputeSha256Hash(loginModelInputModel.Password);
            var user = await _devFreelaDbContext.Users
                .SingleOrDefaultAsync(u=>u.Email == loginModelInputModel.Email&&u.Password== passwordHash);
            
            if(user !=null ){
                var token = _authService.GenerateJWTToken(user.Email,user.Role.ToString());
                return new LoginViewModel(token,user.Email);
            }
            return null;                            
        }
    }
}
