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
    public class DeleteModel : PageModel
    {
        private readonly IResourcePageService _resourcePageService;

        public DeleteModel(IResourcePageService resourcePageService)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            await this._resourcePageService.DeleteAsync(id.Value);
            return this.RedirectToPage("./Index");
        }
    }
}