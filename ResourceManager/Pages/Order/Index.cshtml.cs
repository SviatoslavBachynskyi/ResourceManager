using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResourceManager.Authorize;
using ResourceManager.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager
{
    [AuthorizeRoles(Role.Admin)]
    public class IndexModel : PageModel
    {
        private readonly ResourceManager.Dal.ResourceManagerContext _context;

        public IndexModel(ResourceManager.Dal.ResourceManagerContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.ApprovedBy)
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderedBy)
                .Include(o => o.Supplier)
                .Include(o => o.Supply).ToListAsync();
        }
    }
}
