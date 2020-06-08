using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResourceManager.PageServices;
using ResourceManager.ViewModels;
using ResourceManager.ViewModels.FilterViewModels;
using ResourceManager.ViewModels.SelectViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager
{
    public class IndexModel : PageModel
    {
        private readonly IResourcePageService _resourcePageService;

        public IndexModel(IResourcePageService resourcePageService)
        {
            this._resourcePageService = resourcePageService;
        }

        public IEnumerable<ResourceViewModel> Resources { get; set; } = new List<ResourceViewModel>();

        public SelectList MeasuringUnits { get; set; }

        public SelectList Categories { get; set; }

        public SelectList SubCategories { get; set; }

        public SelectList SafetyClasses { get; set; }

        public SelectList EcologyClasses { get; set; }

        [BindProperty(SupportsGet = true)]
        public ResourceFilterViewModel Filter { get; set; }

        public async Task OnGetAsync()
        {
            this.Resources = await this._resourcePageService.GetAllAsync(this.Filter);

            this.MeasuringUnits =
                new SelectList(await this._resourcePageService.GetMeasuringUnitsAsync(),
                nameof(MeasuringUnitSelectViewModel.Id),
                nameof(MeasuringUnitSelectViewModel.Name));

            this.Categories =
                new SelectList(await this._resourcePageService.GetCategoriesAsync(),
                nameof(ResourceCategorySelectViewModel.Id),
                nameof(ResourceCategorySelectViewModel.Name));

            if (this.Filter.CategoryId != null)
            {
                this.SubCategories =
                new SelectList(await this._resourcePageService.GetSubCategoriesAsync(this.Filter.CategoryId.Value),
                nameof(ResourceSubCategorySelectViewModel.Id),
                nameof(ResourceSubCategorySelectViewModel.Name));
            }

            this.EcologyClasses =
                new SelectList(await this._resourcePageService.GetEcologyClassesAsync(),
                nameof(EcologyClassSelectViewModel.Id),
                nameof(EcologyClassSelectViewModel.CodeName));

            this.SafetyClasses =
                new SelectList(await this._resourcePageService.GetSafetyClassesAsync(),
                nameof(SafetyClassSelectViewModel.Id),
                nameof(SafetyClassSelectViewModel.CodeName));
        }

        public async Task<ActionResult> OnGetSubCategoriesAsync(int? categoryId)
        {
            if (categoryId == null)
            {
                return this.BadRequest();
            }

            var result = new JsonResult(await this._resourcePageService.GetSubCategoriesAsync(categoryId.Value));

            return result;
        }
    }
}