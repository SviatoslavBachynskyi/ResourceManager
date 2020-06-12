using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResourceManager.Authorize;
using ResourceManager.Core.Models;
using System.Threading.Tasks;

namespace ResourceManager
{
    [AuthorizeRoles(Role.Admin)]
    public class DeleteModel : PageModel
    {
        private readonly ResourceManager.Dal.ResourceManagerContext _context;

        public DeleteModel(ResourceManager.Dal.ResourceManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.ApprovedBy)
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderedBy)
                .Include(o => o.Supplier)
                .Include(o => o.Supply).FirstOrDefaultAsync(m => m.Id == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders.FindAsync(id);

            if (Order != null)
            {
                _context.Orders.Remove(Order);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
