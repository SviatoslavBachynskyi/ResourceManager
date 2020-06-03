using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class DistrictRepository : BaseRepository<District, int>, IDistrictRepository
    {
        public DistrictRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
