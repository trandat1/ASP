using AssimentASP.Common;
using AssimentASP.Data;

namespace AssimentASP.Contracts
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        Task<PaginatedResults<Product>> GetPaginated(int page,int pageSize,string keyword);
    }
}
