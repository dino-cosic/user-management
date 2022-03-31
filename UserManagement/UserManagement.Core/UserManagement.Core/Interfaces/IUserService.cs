using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Models.Requests;
using UserManagement.Models.Responses;

namespace UserManagement.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);
        Task<PagedListResponse<User>> GetAllAsync(UserPageParameters userPageParameters);
        Task<User> GetAsync(int id);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
