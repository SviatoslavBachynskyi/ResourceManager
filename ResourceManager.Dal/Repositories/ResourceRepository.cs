using Microsoft.EntityFrameworkCore;
using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;
using System.Linq;

namespace ResourceManager.Dal.Repositories
{
    public class ResourceRepository : BaseRepository<Resource, int>, IResourceRepository
    {
        public ResourceRepository(ResourceManagerContext context) : base(context)
        {
        }

        protected override IQueryable<Resource> ComplexEntities
        {
            get
            {
                return base.Entities
                    .Include(r => r.MeasuringUnit)
                    .Include(r => r.ResourceSubCategory).ThenInclude(r => r.ResourceCategory)
                    .Include(r => r.EcologyClass)
                    .Include(r => r.SafetyClass);
            }
        }
    }
}
