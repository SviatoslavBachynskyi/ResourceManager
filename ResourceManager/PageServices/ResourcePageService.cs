using AutoMapper;
using ResourceManager.Core.Dtos.FilterDtos;
using ResourceManager.Core.Services;
using ResourceManager.ViewModels;
using ResourceManager.ViewModels.FilterViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ResourceManager.ViewModels.SelectViewModels;
using ResourceManager.Core.Dtos;

namespace ResourceManager.PageServices
{
    public class ResourcePageService : IResourcePageService
    {
        private readonly IResourceService _resourceService;
        private readonly IMeasuringUnitService _measuringUnitService;
        private readonly IResourceCategoryService _resourceCategoryService;
        private readonly IResourceSubCategoryService _resourceSubCategoryService;
        private readonly ISafetyClassService _safetyClassService;
        private readonly IEcologyClassService _ecologyClassService;

        private readonly IMapper _mapper;
        public ResourcePageService(
            IResourceService resourceService,
            IMeasuringUnitService measuringUnitService,
            IResourceCategoryService resourceCategoryService,
            IResourceSubCategoryService resourceSubCategoryService,
            ISafetyClassService safetyClassService,
            IEcologyClassService ecologyClassService,
            IMapper mapper)
        {
            this._resourceService = resourceService;
            this._measuringUnitService = measuringUnitService;
            this._resourceCategoryService = resourceCategoryService;
            this._resourceSubCategoryService = resourceSubCategoryService;
            this._safetyClassService = safetyClassService;
            this._ecologyClassService = ecologyClassService;

            this._mapper = mapper;
        }

        public async Task<ResourceViewModel> GetByIdAsync(int id)
        {
            var resource = await this._resourceService.GetByIdAsync(id);

            return this._mapper.Map<ResourceViewModel>(resource);
        }

        public async Task<IEnumerable<ResourceViewModel>> GetAllAsync(ResourceFilterViewModel resourceFilter = null)
        {
            var filter = this._mapper.Map<ResourceFilterDto>(resourceFilter);

            var resources = await this._resourceService.GetAllAsync(filter);

            return this._mapper.Map<IEnumerable<ResourceViewModel>>(resources);
        }

        public async Task UpdateAsync(ResourceViewModel resource)
        {
            var resourceDto = this._mapper.Map<ResourceDto>(resource);

            await this._resourceService.UpdateAsync(resourceDto);
        }

        public async Task DeleteAsync(int id)
        {
            await this._resourceService.DeleteAsync(id);
        }

        public async Task<IEnumerable<MeasuringUnitSelectViewModel>> GetMeasuringUnitsAsync()
        {
            var units = await this._measuringUnitService.GetAllAsync();

            return this._mapper.Map<IEnumerable<MeasuringUnitSelectViewModel>>(units);
        }

        public async Task<IEnumerable<ResourceCategorySelectViewModel>> GetCategoriesAsync()
        {
            var categories = await this._resourceCategoryService.GetAllAsync();

            return this._mapper.Map<IEnumerable<ResourceCategorySelectViewModel>>(categories);
        }

        public async Task<IEnumerable<ResourceSubCategorySelectViewModel>> GetSubCategoriesAsync(int ResourceCategoryId)
        {
            var subCategories = await this._resourceSubCategoryService.GetAllAsync(ResourceCategoryId);

            return this._mapper.Map<IEnumerable<ResourceSubCategorySelectViewModel>>(subCategories);
        }

        public async Task<IEnumerable<SafetyClassSelectViewModel>> GetSafetyClassesAsync()
        {
            var classes = await this._safetyClassService.GetAllAsync();
            
            return this._mapper.Map<IEnumerable<SafetyClassSelectViewModel>>(classes);
        }

        public async Task<IEnumerable<EcologyClassSelectViewModel>> GetEcologyClassesAsync()
        {
            var classes = await this._ecologyClassService.GetAllAsync();

            return this._mapper.Map<IEnumerable<EcologyClassSelectViewModel>>(classes);
        }
    }
}
