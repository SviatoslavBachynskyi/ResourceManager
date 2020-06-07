using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class InventoryGivingStatusRepository : BaseRepository<InventoryGivingStatus, int>, IInventoryGivingStatusRepository
    {
        public InventoryGivingStatusRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
