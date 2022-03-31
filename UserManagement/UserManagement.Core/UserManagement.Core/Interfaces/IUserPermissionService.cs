using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Models.Requests;

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
        /// Method is used for adding new permission to the user.
        /// </summary>
        /// <param name="assignPermissionRequest"></param>
        /// <returns></returns>
        Task AssignNewPermissionAsync(AssignPermissionRequest assignPermissionRequest);
    }
}