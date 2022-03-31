using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.DAL
{
    public interface IRepository<DbContext, TEntity>
        where DbContext : Microsoft.EntityFrameworkCore.DbContext
        where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);
    }
}