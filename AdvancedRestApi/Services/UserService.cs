using AdvancedRestApi.Data;
using AdvancedRestApi.Interfaces;
using AdvancedRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedRestApi.Services
{
    public class UserService : IUser
    {
        private readonly UserDbContext _userDbContext;

        public UserService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task AddUser(User user)
        {
            await _userDbContext.Users.AddAsync(user);
            await _userDbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _userDbContext.Users.FindAsync(id);
            _userDbContext.Users.Remove(user);
            await _userDbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userDbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _userDbContext.Users.FindAsync(id);
            return user;
        }

        public async Task UpdateUser(Guid id, User user)
        {
            var userObj = await _userDbContext.Users.FindAsync(id);
            userObj.Name = user.Name;
            userObj.Address = user.Address;
            userObj.Phone = user.Phone;
            userObj.BloodGroup = user.BloodGroup;
            await _userDbContext.SaveChangesAsync();
        }
    }
}
