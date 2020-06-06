using ResourceManager.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.Core.Services
{
    public interface IResourceService
    {
        public Task<IEnumerable<ResourceDto>> GetAllAsync();
    }
}
