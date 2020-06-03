using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class InventoryRepository : BaseRepository<Inventory, int>, IInventoryRepository
    {
        public InventoryRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
