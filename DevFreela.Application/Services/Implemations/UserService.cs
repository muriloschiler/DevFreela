using System.Linq;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.DTO.ViewModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Core.IAuth;
using DevFreela.Infrastructure.Persistence;

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
        public int AddUser(CreateUserInputModel createUserInputModel)
        {
            User newUser = new User
            (
                createUserInputModel.Name,
                _authService.ComputeSha256Hash(createUserInputModel.Password),
                createUserInputModel.Role,
                createUserInputModel.BirthDate,
                createUserInputModel.Email
            );
            _devFreelaDbContext.Users.Add(newUser);
            _devFreelaDbContext.SaveChanges();
            return newUser.Id;
            
        }
        public UserDetailsViewModel GetUser(int id)
        {
            User user = _devFreelaDbContext.Users.SingleOrDefault(u=>u.Id == id);
            UserDetailsViewModel userDetails = new UserDetailsViewModel(user.Name,user.BirthDate,user.Email,user.CreatedAt,
                                                                            user.UserStatus,user.Skills,user.OwnedProjects,
                                                                            user.FreelancerProjects,user.Comments);
                                                                        
            return userDetails;
        }

        public LoginViewModel Login(LoginInputModel loginModelInputModel)
        {
            var passwordHash = _authService.ComputeSha256Hash(loginModelInputModel.Password);
            var user = _devFreelaDbContext.Users
                .SingleOrDefault(u=>u.Email == loginModelInputModel.Email&&u.Password== passwordHash);
            
            if(user !=null ){
                var token = _authService.GenerateJWTToken(user.Email,user.Role);
                return new LoginViewModel(token,user.Email);
            }
            return null;                            
        }
    }
}
