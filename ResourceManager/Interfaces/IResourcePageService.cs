using ResourceManager.ViewModels;
using ResourceManager.ViewModels.FilterViewModels;
using ResourceManager.ViewModels.SelectViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.PageServices
{
    public interface IResourcePageService
    {
        Task<ResourceViewModel> GetByIdAsync(int Id);

        Task<IEnumerable<ResourceViewModel>> GetAllAsync(ResourceFilterViewModel resourceFilter = null);

        Task<IEnumerable<MeasuringUnitSelectViewModel>> GetMeasuringUnitsAsync();

        Task<IEnumerable<SafetyClassSelectViewModel>> GetSafetyClassesAsync();

        Task<IEnumerable<EcologyClassSelectViewModel>> GetEcologyClassesAsync();

        Task<IEnumerable<ResourceCategorySelectViewModel>> GetCategoriesAsync();

        Task<IEnumerable<ResourceSubCategorySelectViewModel>> GetSubCategoriesAsync(int ResourceCategoryId);
    }
}
