using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.EF;
using UserManagement.EF.Entities;

namespace UserManagement.DAL.Interfaces
{
    public interface IUserPermissionRepository : IRepository<UserManagementDbContext, UserPermission>
    {
        /// <summary>
        /// Method is used to retrieve user assigned permissions.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<Permission>> GetUserPermissionsAsync(int userId);
        
        /// <summary>
        /// Method is used to delete relation between user and permission in UserPermissions table.
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        Task DeleteByPermissionIdAsync(int permissionId);
    }
}