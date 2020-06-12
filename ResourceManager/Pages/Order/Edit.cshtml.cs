using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResourceManager.Authorize;
using ResourceManager.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManager
{
    [AuthorizeRoles(Role.Admin)]
    public class EditModel : PageModel
    {
        private readonly ResourceManager.Dal.ResourceManagerContext _context;

        public EditModel(ResourceManager.Dal.ResourceManagerContext context)
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
           ViewData["ApprovedById"] = new SelectList(_context.Workers, "Id", "Id");
           ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id");
           ViewData["OrderedById"] = new SelectList(_context.Workers, "Id", "Id");
           ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Address");
           ViewData["SupplyId"] = new SelectList(_context.Supplies, "Id", "AcceptedById");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
