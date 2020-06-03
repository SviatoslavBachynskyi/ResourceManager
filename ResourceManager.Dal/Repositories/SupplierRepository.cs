using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier, int>, ISupplierRepository
    {
        public SupplierRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
