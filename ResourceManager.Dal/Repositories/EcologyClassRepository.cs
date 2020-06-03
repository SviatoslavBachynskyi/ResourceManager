using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class EcologyClassRepository : BaseRepository<EcologyClass, int>, IEcologyClassRepository
    {
        public EcologyClassRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
