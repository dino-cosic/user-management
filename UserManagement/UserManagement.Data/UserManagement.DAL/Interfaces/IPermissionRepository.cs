using System.Threading.Tasks;
using UserManagement.EF;
using UserManagement.EF.Entities;

namespace UserManagement.DAL.Interfaces
{
    public interface IPermissionRepository : IRepository<UserManagementDbContext, Permission>
    {
        /// <summary>
        /// Method is used to retrieve permission by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Permission> GetByIdAsync(int id);
    }
}