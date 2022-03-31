using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.DAL.Interfaces;
using UserManagement.EF;
using UserManagement.EF.Entities;

namespace UserManagement.DAL.Repositories
{
    public class UserPermissionRepository : Repository<UserManagementDbContext, UserPermission>, IUserPermissionRepository
    {
        public UserPermissionRepository(UserManagementDbContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<IEnumerable<Permission>> GetUserPermissionsAsync(int userId)
        {
            var userPermissions = GetAll().Where(up => up.UserId == userId);

            return userPermissions.Any() ?
                await userPermissions.Select(up => up.Permission).ToListAsync() :
                Enumerable.Empty<Permission>();
        }
    }
}