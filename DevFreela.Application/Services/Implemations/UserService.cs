using System.Linq;
using DevFreela.Application.DTO.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implemations{
    public class UserService : IUserService
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;
        public UserService(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext=devFreelaDbContext;
        }
        public void AddUser(CreateUserInputModel createUserInputModel)
        {
            User newUser = new User(createUserInputModel.Name,createUserInputModel.BirthDate,
                                    createUserInputModel.Email);
            _devFreelaDbContext.Users.Add(newUser);
            _devFreelaDbContext.SaveChanges();
            
        }
        public UserDetailsViewModel GetUser(int id)
        {
            User user = _devFreelaDbContext.Users.SingleOrDefault(u=>u.Id == id);
            UserDetailsViewModel userDetails = new UserDetailsViewModel(user.Name,user.BirthDate,user.Email,user.CreatedAt,
                                                                            user.UserStatus,user.Skills,user.OwnedProjects,
                                                                            user.FreelancerProjects,user.Comments);
                                                                        
            return userDetails;
        }

        public void Login(LoginModel loginModel)
        {
            throw new System.NotImplementedException();
        }
    }
}