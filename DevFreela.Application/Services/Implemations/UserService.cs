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
            User newUser = new User(createUserInputModel.Name,createUserInputModel.Email,
                                    createUserInputModel.BirthDate);
            _devFreelaDbContext.Users.Add(newUser);
            _devFreelaDbContext.SaveChanges();
            
        }
        public UserDetailsViewModel GetUser(int id)
        {
            UserDetailsViewModel userDetails = (UserDetailsViewModel)_devFreelaDbContext.Users.Where(u=> u.Id ==id)
                                                                        .Select(u=>new UserDetailsViewModel(
                                                                            u.Name,u.BirthDate,u.Email,u.CreatedAt,
                                                                            u.UserStatus,u.Skills,u.OwnedProjects,u.FreelancerProjects,
                                                                            u.Comments
                                                                        ));
                                                                        
            return userDetails;
        }

        public void Login(LoginModel loginModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
