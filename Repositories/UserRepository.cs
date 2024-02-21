using Microsoft.EntityFrameworkCore;
using SaudePlus.Data;
using SaudePlus.Models;
using SaudePlus.Repositories.Interfaces;

namespace SaudePlus.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SystemDbContext _dbContext;
        public UserRepository(SystemDbContext SystemDbContext)
        {
            _dbContext = SystemDbContext;
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserModel> CreateUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null) {
                throw new Exception("User not found");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUserById(id);
            
            if (userById == null) {
                throw new Exception("User not found");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
