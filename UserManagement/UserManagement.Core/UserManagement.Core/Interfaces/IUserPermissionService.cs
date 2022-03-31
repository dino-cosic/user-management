using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Core.Interfaces
{
    public interface IUserPermissionService
    {
        /// <summary>
        /// Method is used to retrieve all permissions assigned to user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<Permission>> GetUserPermissions(int userId);

        /// <summary>
        /// Method is used for updating permission
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        Task<Permission> UpdateUserPermissions(Permission permission);
    }
}