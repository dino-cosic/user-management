using UserManagement.DAL.Interfaces;
using UserManagement.EF;
using UserManagement.EF.Entities;

namespace UserManagement.DAL.Repositories
{
    public class PermissionRepository : Repository<UserManagementDbContext, Permission>, IPermissionRepository
    {
        public PermissionRepository(UserManagementDbContext userManagementContext) : base(userManagementContext)
        {
        }
    }
}