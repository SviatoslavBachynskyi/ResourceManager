using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class SupplyRepository : BaseRepository<Supply, int>, ISupplyRepository
    {
        public SupplyRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
