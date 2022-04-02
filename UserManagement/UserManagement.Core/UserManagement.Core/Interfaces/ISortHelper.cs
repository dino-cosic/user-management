using System.Linq;

namespace UserManagement.Core.Interfaces
{
    public interface ISortHelper<T>
    {
        /// <summary>
        /// The method is used for applying sorting algorithm by any class property.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="orderByQueryString"></param>
        /// <returns></returns>
        IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString);
    }
}
