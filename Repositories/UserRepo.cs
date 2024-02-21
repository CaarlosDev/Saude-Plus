using Microsoft.EntityFrameworkCore;
using SaudePlus.Data;
using SaudePlus.Models;
using SaudePlus.Repositories.Interfaces;
using System;

namespace SaudePlus.Repositories
{
    public class UserRepo : IUsersRepo
    {
        private readonly SaudePlusDBContex _dbContext;
        public UserRepo(SaudePlusDBContex saudePlusDBContex)
        {
            _dbContext = saudePlusDBContex;
        }

        public async Task<List<UserModels>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModels> SearchByID(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<UserModels> Add(UserModels user, int id)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public async Task<UserModels> Update(int id)
        {
            UserModels userById = await SearchByID(id);
            throw new NotImplementedException();
            if (userById != null)
            {
                throw new Exception($"User By Id: {id}  not found");
            }
     //       userById.Username = UserModels.Username;
      //      userById.Password = UserModels.Password;

        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}