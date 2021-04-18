using MiniNotes_TodoList.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniNotes_TodoList.Data.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int userId);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}