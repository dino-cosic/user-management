using UserManagement.EF;
using UserManagement.EF.Entities;

namespace UserManagement.DAL.Interfaces
{
    public interface IPermissionRepository : IRepository<UserManagementDbContext, Permission>
    {
    }
}