using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class ResourceRepository : BaseRepository<Resource, int>, IResourceRepository
    {
        public ResourceRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
