using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.EF;
using UserManagement.EF.Entities;

namespace UserManagement.DAL.Interfaces
{
    public interface IUserRepository : IRepository<UserManagementDbContext, User>
    {
        /// <summary>
        /// Method is used for retrieving all users from database.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> Get();

        /// <summary>
        /// Method is used to retrieve specific user fromd database by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetById(int id);
    }
}