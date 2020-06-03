using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class SafetyClassRepository : BaseRepository<SafetyClass, int>, ISafetyClassRepository
    {
        public SafetyClassRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
