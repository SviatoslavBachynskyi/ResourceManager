using Microsoft.AspNetCore.Mvc.RazorPages;
using ResourceManager.PageServices;
using ResourceManager.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager
{
    public class IndexModel : PageModel
    {
        private IResourcePageService _resourcePageService;

        public IndexModel(IResourcePageService resourcePageService)
        {
            this._resourcePageService = resourcePageService;
        }

        public IEnumerable<ResourceViewModel> Resources { get; set; } = new List<ResourceViewModel>();

        public async Task OnGetAsync()
        {
            this.Resources = await this._resourcePageService.GetAllAsync();
        }
    }
}