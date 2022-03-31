using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.DAL.Interfaces;
using UserManagement.EF;
using UserManagement.EF.Entities;

namespace UserManagement.DAL.Repositories
{
    public class UserRepository : Repository<UserManagementDbContext, User>, IUserRepository
    {
        public UserRepository(UserManagementDbContext userManagementContext) : base(userManagementContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await GetAll().OrderBy(u => u.Id).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}