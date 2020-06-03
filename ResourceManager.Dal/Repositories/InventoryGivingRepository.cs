using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class InventoryGivingRepository : BaseRepository<InventoryGiving, int>, IInventoryGivingRepository
    {
        public InventoryGivingRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
