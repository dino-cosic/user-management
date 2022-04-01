using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Models.Requests;

namespace UserManagement.Core.Interfaces
{
    public interface IUserPermissionService
    {
        /// <summary>
        /// Method is used to retrieve all configured permissions.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Permission>> GetPermissionsAsync();

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
        Task AssignNewPermissionAsync(UpdatePermissionRequest assignPermissionRequest);

        /// <summary>
        /// Method is used for removing permission from an user.
        /// </summary>
        /// <param name="permissionRequest"></param>
        /// <returns></returns>
        Task RemovePermissionFromUserAsync(UpdatePermissionRequest permissionRequest);
    }
}