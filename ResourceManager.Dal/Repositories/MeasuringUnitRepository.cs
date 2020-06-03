using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class MeasuringUnitRepository : BaseRepository<MeasuringUnit, int>, IMeasuringUnitRepository
    {
        public MeasuringUnitRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
