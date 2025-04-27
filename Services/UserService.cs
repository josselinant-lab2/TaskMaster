using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Data;
using TaskMaster.Helpers;
using TaskMaster.Models;

namespace TaskMaster.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RegisterUserAsync(User user, string plainPassword)
        {
            user.Password = PasswordHelper.HashPassword(plainPassword);
            user.DateCreation = DateTime.UtcNow;

            await _dbContext.Users.AddAsync(user);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> IsEmailUsedAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> AuthenticateUserAsync(string email, string plainPassword)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return null; 
            }

            bool isValid = PasswordHelper.VerifyPassword(user.Password, plainPassword);
            return isValid ? user : null;
        }
    }
}
