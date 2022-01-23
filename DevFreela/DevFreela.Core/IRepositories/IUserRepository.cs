using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.IRepositories{
    public interface IUserRepository{
        Task<User> GetUserByIdAsync(int idUser);
        Task<User> LoginAsync(string userEmail , string passwordHash);
        Task AddUserAsync(User newUser);
        Task SaveChangesAsync();
    }
}