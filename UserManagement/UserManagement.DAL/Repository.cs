using System;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.DAL
{
    public class Repository<DbContext, TEntity> : IRepository<DbContext, TEntity>
        where DbContext : Microsoft.EntityFrameworkCore.DbContext
        where TEntity : class, new()
    {
        protected readonly DbContext UserManagementContext;

        public Repository(DbContext userManagementContext)
        {
            UserManagementContext = userManagementContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return UserManagementContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await UserManagementContext.AddAsync(entity);
                await UserManagementContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                UserManagementContext.Update(entity);
                await UserManagementContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                UserManagementContext.Remove(entity);
                await UserManagementContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be removed: {ex.Message}");
            }
        }
    }
}
