using AssimentASP.Common;
using AssimentASP.Contracts;
using AssimentASP.Data;

namespace AssimentASP.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext db) : base(db)
        {

        }
        public async Task<PaginatedResults<Product>> GetPaginated(int page, int pageSize, string keyword)
        {
            return await GetPaginated(page, pageSize, t => t.Name.Contains(keyword ?? string.Empty));
        }
    }
}
