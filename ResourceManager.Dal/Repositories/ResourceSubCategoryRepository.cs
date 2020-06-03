using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class ResourceSubCategoryRepository : BaseRepository<ResourceSubCategory, int>, IResourceSubCategoryRepository
    {
        public ResourceSubCategoryRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
