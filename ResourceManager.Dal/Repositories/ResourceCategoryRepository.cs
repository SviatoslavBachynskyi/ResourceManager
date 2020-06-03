using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class ResourceCategoryRepository : BaseRepository<ResourceCategory, int>, IResourceCategoryRepository
    {
        public ResourceCategoryRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
