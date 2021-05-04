using Microsoft.EntityFrameworkCore;
using MiniNotes.Data.Database;
using MiniNotes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniNotes.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _dbContext.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByLogin(string login, string password)
        {
            return await _dbContext.Users
                .Where(u => (u.UserName == login || u.Email == login) 
                    && u.Password == password)
                .FirstOrDefaultAsync();
        }

        public async Task AddUser(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}