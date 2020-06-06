using AutoMapper;
using ResourceManager.Core.Services;
using ResourceManager.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.PageServices
{
    public class ResourcePageService : IResourcePageService
    {
        private IResourceService _resourceService;
        private IMapper _mapper;
        public ResourcePageService(IResourceService resourceService, IMapper mapper)
        {
            this._resourceService = resourceService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ResourceViewModel>> GetAllAsync()
        {
            var resources = await this._resourceService.GetAllAsync();

            return this._mapper.Map<IEnumerable<ResourceViewModel>>(resources);
        }
    }
}
