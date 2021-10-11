using MiniNotes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniNotes.Data.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int userId);
        Task<User> GetUserByLogin(string login, string password);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}