using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AttendanceFull.Services
{
    public class UserService : IUserService
    {
        private readonly AttendanceContext _context;

        public UserService(AttendanceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUser(User user)
        {
            try
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"Error while saving the user, {Ex.Message}");
                throw;
            }
        }

        public async Task UpdateUser(int id, User newUser) 
        {
            try
            {
                var actual = _context.Users.Find(id);
                if (actual != null)
                {
                    actual.Name = newUser.Name;
                    actual.Nickname = newUser.Nickname;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"Error while updating the user, {Ex.Message}");
                throw;
            }
        }
    }
}

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task AddUser(User user);
    Task UpdateUser(int id, User newUser);
}