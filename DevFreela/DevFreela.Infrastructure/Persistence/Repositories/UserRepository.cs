using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories{
    public class UserRepository: IUserRepository
    {
        private readonly DevFreelaDbContext _devFreelaDbContext;

        public UserRepository(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }

        public async Task AddUserAsync(User newUser)
        {
            await _devFreelaDbContext.Users.AddAsync(newUser);
            await _devFreelaDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int idUser)
        {
            return await _devFreelaDbContext.Users.SingleOrDefaultAsync(u => u.Id == idUser);
        }

        public async Task<User> LoginAsync(string userEmail, string passwordHash)
        {
            return await _devFreelaDbContext.Users
                        .SingleOrDefaultAsync(u=>u.Email == userEmail && u.Password== passwordHash);
        }

        public async Task SaveChangesAsync()
        {
            await _devFreelaDbContext.SaveChangesAsync();
        }
    }
}