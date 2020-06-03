using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class WarehouseRepository : BaseRepository<Warehouse, int>, IWarehouseRepository
    {
        public WarehouseRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
