using AssimentASP.Common;
using System.Linq.Expressions;

namespace AssimentASP.Contracts
{
    public interface IBaseRepository<T>
    {
        Task Create(T t);
        Task<T> GetOne(object id);
        Task<IEnumerable<T>> GetAll();
        Task<PaginatedResults<T>> GetPaginated(int page, int pageSize, Expression<Func<T, bool>> condition);
        Task Update(object id,object model);
        Task Delete(object id);
    }
}
