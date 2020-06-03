using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class WorkerRepository : BaseRepository<Worker, int>, IWorkerRepository
    {
        public WorkerRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
