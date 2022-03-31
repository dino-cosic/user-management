using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Core.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
