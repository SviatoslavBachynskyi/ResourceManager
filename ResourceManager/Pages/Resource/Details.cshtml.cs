using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResourceManager.PageServices;
using ResourceManager.ViewModels;

namespace ResourceManager
{
    public class DetailsModel : PageModel
    {
        private readonly IResourcePageService _resourcePageService;

        public DetailsModel(IResourcePageService resourcePageService)
        {
            this._resourcePageService = resourcePageService;
        }

        public ResourceViewModel Resource { get; set; }

        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null)
            {
                return this.NotFound();
            }

            this.Resource = await this._resourcePageService.GetByIdAsync(Id.Value);
            if (this.Resource == null)
            {
                return this.NotFound();
            }

            return this.Page();
        }
    }
}