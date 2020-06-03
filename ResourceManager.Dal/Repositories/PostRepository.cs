using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class PostRepository : BaseRepository<Post, int>, IPostRepository
    {
        public PostRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
