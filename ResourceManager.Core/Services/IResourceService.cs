using ResourceManager.Core.Dtos;
using ResourceManager.Core.Dtos.FilterDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.Core.Services
{
    public interface IResourceService
    {
        public Task<ResourceDto> GetByIdAsync(int id);

        public Task<IEnumerable<ResourceDto>> GetAllAsync(ResourceFilterDto resourceFilter = null);

        public Task UpdateAsync(ResourceDto resourceDto);

        public Task DeleteAsync(int id);
    }
}
