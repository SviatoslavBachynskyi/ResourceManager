using ResourceManager.ViewModels;
using ResourceManager.ViewModels.FilterViewModels;
using ResourceManager.ViewModels.SelectViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.PageServices
{
    public interface IResourcePageService
    {
        Task<ResourceViewModel> GetByIdAsync(int id);

        Task<IEnumerable<ResourceViewModel>> GetAllAsync(ResourceFilterViewModel resourceFilter = null);

        Task DeleteAsync(int id);

        Task<IEnumerable<MeasuringUnitSelectViewModel>> GetMeasuringUnitsAsync();

        Task<IEnumerable<SafetyClassSelectViewModel>> GetSafetyClassesAsync();

        Task<IEnumerable<EcologyClassSelectViewModel>> GetEcologyClassesAsync();

        Task<IEnumerable<ResourceCategorySelectViewModel>> GetCategoriesAsync();

        Task<IEnumerable<ResourceSubCategorySelectViewModel>> GetSubCategoriesAsync(int ResourceCategoryId);
    }
}
