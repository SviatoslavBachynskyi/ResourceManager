﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResourceManager.Authorize;
using ResourceManager.Core.Models;
using ResourceManager.PageServices;
using ResourceManager.ViewModels;
using ResourceManager.ViewModels.SelectViewModels;
using System.Threading.Tasks;

namespace ResourceManager.Pages.Resource
{
    [AuthorizeRoles(Role.Admin)]
    public class CreateModel : PageModel
    {
        private readonly IResourcePageService _resourcePageService;

        public CreateModel(IResourcePageService resourcePageService)
        {
            this._resourcePageService = resourcePageService;
        }

        [BindProperty]
        public ResourceViewModel Resource { get; set; }

        public SelectList MeasuringUnits { get; set; }

        public SelectList Categories { get; set; }

        public SelectList SubCategories { get; set; }

        public SelectList SafetyClasses { get; set; }

        public SelectList EcologyClasses { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            this.Resource = new ResourceViewModel();

            this.MeasuringUnits =
                new SelectList(await this._resourcePageService.GetMeasuringUnitsAsync(),
                nameof(MeasuringUnitSelectViewModel.Id),
                nameof(MeasuringUnitSelectViewModel.Name));

            this.Categories =
                new SelectList(await this._resourcePageService.GetCategoriesAsync(),
                nameof(ResourceCategorySelectViewModel.Id),
                nameof(ResourceCategorySelectViewModel.Name));

            if (this.Resource.CategoryId != null)
            {
                this.SubCategories =
                new SelectList(await this._resourcePageService.GetSubCategoriesAsync(this.Resource.CategoryId.Value),
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

            return this.Page();
        }

        public async Task<IActionResult> OnGetSubCategoriesAsync(int? categoryId)
        {
            if (categoryId == null)
            {
                return this.BadRequest();
            }

            var result = new JsonResult(await this._resourcePageService.GetSubCategoriesAsync(categoryId.Value));

            return result;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            var id = await this._resourcePageService.CreateAsync(this.Resource);

            return this.RedirectToPage("./Details", new { Id = id});
        }
    }
}