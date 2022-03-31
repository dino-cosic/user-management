using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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

        public async Task<Permission> GetByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}